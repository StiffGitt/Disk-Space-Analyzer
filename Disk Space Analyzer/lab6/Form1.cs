using System.Security.AccessControl;
using System.Windows.Forms;
using System.IO;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Compression;
using System.Drawing;
using System.Security.Policy;
using System.Globalization;
using Microsoft.VisualBasic.ApplicationServices;

namespace lab6
{
    public partial class Form1 : Form
    {
        private List<string> rootPath;
        private MyTree myTree;
        private Dictionary<string, int> myTreeDictionary;
        private Dictionary<string, long> myTreeSizeDictionary;
        private Dictionary<string, DirInfo> directoriesSize;

        private struct DirInfo
        {
            public int subdirs;
            public int files;
            public long size;

            public DirInfo(int subdirs, int files, long size)
            {
                this.subdirs = subdirs;
                this.files = files;
                this.size = size;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            rootPath = new List<string>();
            myTreeDictionary = new Dictionary<string, int>();
            myTreeSizeDictionary = new Dictionary<string, long>();
            directoriesSize = new Dictionary<string, DirInfo>();
            myTree = new MyTree(tView);
            NewTree();
        }
        private void NewTree(int opt = 1, string path = "")
        {
            if (backgroundWorker.IsBusy)
                CancelProcess();
            rootPath.Clear();
            if (opt == 1)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    rootPath.Add(drive.Name);
                }
            }
            if (path != "")
                rootPath.Add(path);
            myTree.InitializeTree(opt, path);
            cancelToolStripMenuItem.Enabled = true;
            backgroundWorker.RunWorkerAsync();
        }
        private void CancelProcess()
        {
            backgroundWorker.CancelAsync();
            while (backgroundWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }
        void Child_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Form2 frm = (Form2)sender;
            if (frm.checkedButton != 0)
            {
                NewTree(frm.checkedButton, frm.path);
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dialogBox = new Form2(this);
            dialogBox.FormClosed += new FormClosedEventHandler(Child_Form_Closed);
            dialogBox.ShowDialog();
        }
        private void tView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            myTree.expandTree((string)e.Node.Tag, (TreeNode)e.Node);
        }
        private void tView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            myTree.expandTree((string)e.Node.Tag, (TreeNode)e.Node);
            labelDetails.Text = GetDetailInfo((string)e.Node.Tag);

        }
        private string GetDetailInfo(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                return "";
            }
            string resultString = "";
            try
            {

                string[] column1 = { "Full path:", "Size:", "Items:", "Files:", "Subdirs:", "Last change:" };
                string[] column2 = new string[column1.Length];
                column2[0] = path;
                if (Directory.Exists(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (directoriesSize.ContainsKey(path))
                    {
                        DirInfo dInfo = directoriesSize[path];
                        column2[1] = Functions.SizeToString(dInfo.size);
                        column2[2] = $"{dInfo.files + dInfo.subdirs}";
                        column2[3] = $"{dInfo.files}";
                        column2[4] = $"{dInfo.subdirs}";
                    }
                    else
                    {
                        column2[1] = "";
                        column2[2] = "";
                        column2[3] = "";
                        column2[4] = "";
                    }
                    column2[5] = dirInfo.LastWriteTime.ToString();
                }
                else if (File.Exists(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    NumberFormatInfo setPrecision = new NumberFormatInfo();
                    setPrecision.NumberDecimalDigits = 1;
                    column2[1] = Functions.SizeToString(fileInfo.Length);
                    column2[2] = "";
                    column2[3] = "";
                    column2[4] = "";
                    column2[5] = fileInfo.LastWriteTime.ToString();
                }
                int column1Width = 20;
                string formatString = "{0,-20} {1,20}";
                for (int i = 0; i < column1.Length; i++)
                {
                    if (column2[i] != "")
                    {
                        resultString += string.Format(formatString, column1[i], column2[i]) + "\n";
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return $"Full path: {path}\n Unauthorized access";
            }
            return resultString;
        }



        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<string> roots = rootPath;
            int subddirsCount = 0;
            myTreeDictionary.Clear();
            myTreeSizeDictionary.Clear();
            directoriesSize.Clear();
            foreach (string root in roots)
            {
                if (backgroundWorker.CancellationPending)
                    break;
                subddirsCount += countDirs(root);
            }
            int progress = 0;
            long size = 0;
            int subdirs = 0;
            int files = 0;
            try
            {
                foreach (string root in roots)
                {
                    if (backgroundWorker.CancellationPending)
                        break;
                    if (Directory.Exists(root))
                    {
                        foreach (var dir in Directory.GetDirectories(root))
                        {
                            if (backgroundWorker.CancellationPending)
                                break;
                            (int t1, int t2, long t3) = GoDeep(dir);
                            files += t1;
                            subdirs += t2;
                            size += t3;
                            progress++;
                            backgroundWorker.ReportProgress((progress * 100) / subddirsCount);
                        }
                        foreach (var fInfo in new DirectoryInfo(root).GetFiles())
                        {
                            if (backgroundWorker.CancellationPending)
                                break;
                            AddToMap(fInfo);
                            size += fInfo.Length;
                            files++;
                        }
                        directoriesSize[root] = new DirInfo(subdirs, files, size);
                    }

                }
            }
            catch (UnauthorizedAccessException ex) { }
        }
        private int countDirs(string root)
        {
            int count = 0;
            try
            {
                if (Directory.Exists(root))
                {
                    foreach (var dir in Directory.GetDirectories(root))
                    {
                        if (backgroundWorker.CancellationPending)
                            break;
                        count++;
                    }
                }
            }
            catch (UnauthorizedAccessException ex) { }
            return count;
        }

        private (int, int, long) GoDeep(string root)
        {
            long size = 0;
            int subdirs = 0;
            int files = 0;
            try
            {
                if (Directory.Exists(root))
                {
                    foreach (var dir in Directory.GetDirectories(root))
                    {
                        if (backgroundWorker.CancellationPending)
                            break;
                        (int t1, int t2, long t3) = GoDeep(dir);
                        files += t1;
                        subdirs += t2;
                        size += t3;
                    }
                    foreach (var fInfo in new DirectoryInfo(root).GetFiles())
                    {
                        AddToMap(fInfo);
                        //AddToMap(fInfo);
                        files++;
                        size += fInfo.Length;
                    }
                    directoriesSize[root] = new DirInfo(subdirs, files, size);
                }
            }
            catch (UnauthorizedAccessException ex) { }
            return (subdirs, files, size);
        }

        private void AddToMap(FileInfo fInfo)
        {
            if (!fInfo.Exists)
                return;
            if (myTreeDictionary.ContainsKey(fInfo.Extension))
            {
                myTreeDictionary[fInfo.Extension] += 1;
                myTreeSizeDictionary[fInfo.Extension] += fInfo.Length;
            }
            else
            {
                myTreeDictionary[fInfo.Extension] = 1;
                myTreeSizeDictionary[fInfo.Extension] = fInfo.Length;
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 0;
            cancelToolStripMenuItem.Enabled = false;
            DrawChart();
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (toolStripProgressBar != null)
                toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelProcess();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            if ((string)comboBox.SelectedItem == "Bar chart")
            {
                var chart = new Chart(myTreeDictionary, myTreeSizeDictionary, chartBox.Width, chartBox.Height, 0);
                chartBox.Image = chart.Bitmap;
            }
            else if ((string)comboBox.SelectedItem == "Log bar chart")
            {
                var chart = new Chart(myTreeDictionary, myTreeSizeDictionary, chartBox.Width, chartBox.Height, 1);
                chartBox.Image = chart.Bitmap;
            }
            else if ((string)comboBox.SelectedItem == "Pie chart")
            {
                var chart = new Chart(myTreeDictionary, myTreeSizeDictionary, chartBox.Width, chartBox.Height, 2);
                chartBox.Image = chart.Bitmap;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}