using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lab6
{
    public partial class Form2 : Form
    {
        public string path;
        Form1 parent;
        public int checkedButton { get; private set; }
        public Form2(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            checkedButton = 0;
            MakeListView();
        }

        private void MakeListView()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                var item = new ListViewItem(drive.Name);
                NumberFormatInfo setPrecision = new NumberFormatInfo();
                setPrecision.NumberDecimalDigits = 1;
                item.SubItems.Add($"{((float)drive.TotalSize / 1024 / 1024 / 1024).ToString("N", setPrecision)} GB");
                item.SubItems.Add($"{((float)drive.AvailableFreeSpace / 1024 / 1024 / 1024).ToString("N", setPrecision)} GB");
                setPrecision.NumberDecimalDigits = 2;
                item.SubItems.Add($"{(((float)drive.TotalSize - (float)drive.AvailableFreeSpace) / drive.TotalSize * 100).ToString("N", setPrecision)} %");

                ProgressBar b = new ProgressBar();
                b.Minimum = 0;
                b.Maximum = 100;
                b.Value = 50;

                item.SubItems.Add($"{((float)drive.TotalSize - (float)drive.AvailableFreeSpace) / drive.TotalSize}");
                //int idx = 4;
                //item.SubItems[idx].Tag = b;
                //item.UseItemStyleForSubItems = false;
                //item.SubItems[idx].BackColor = Color.Gray;
                //item.SubItems[idx].ForeColor = Color.Black;

                listView1.Items.Add(item);
            }
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }

        }

        private void buttonDialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBox1.Text = folderBrowserDialog.SelectedPath;
            radioButton3.Checked = true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            if (Directory.Exists(textBox1.Text) || File.Exists(textBox1.Text))
                textBox1.ForeColor = Color.Black;
            else
                textBox1.ForeColor = Color.Red;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                checkedButton = 1;
            else if (radioButton2.Checked)
                checkedButton = 2;
            else if (radioButton3.Checked)
                checkedButton = 3;
            switch (checkedButton)
            {
                case 1:
                    path = "";
                    break;
                case 2:
                    if (listView1.SelectedItems.Count > 0)
                        path = listView1.SelectedItems[0].Text;
                    //parent.rootPath.Add(listView1.SelectedItems[0].Text);
                    else
                        checkedButton = 0;
                    break;
                case 3:
                    path = textBox1.Text;
                    //parent.rootPath.Add(textBox1.Text);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            checkedButton = 0;
            this.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                // Ustawienia paska postępu
                int progress = (int)(double.Parse(e.SubItem.Text) * 100);
                int progressBarWidth = e.SubItem.Bounds.Width - 4;
                int progressBarHeight = e.SubItem.Bounds.Height - 4;
                int progressBarX = e.SubItem.Bounds.X + 2;
                int progressBarY = e.SubItem.Bounds.Y + 2;

                // Rysowanie paska postępu
                Brush backgrd = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(backgrd, progressBarX, progressBarY, progressBarWidth, progressBarHeight);
                Brush brush = new SolidBrush(Color.Magenta);
                int fillWidth = (int)Math.Round((double)progress / 100 * progressBarWidth);
                e.Graphics.FillRectangle(brush, progressBarX, progressBarY, fillWidth, progressBarHeight);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}
