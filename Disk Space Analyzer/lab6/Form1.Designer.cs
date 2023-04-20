namespace lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            tView = new TreeView();
            splitContainer1 = new SplitContainer();
            buttonSelect = new Button();
            tabControl = new TabControl();
            tabDetails = new TabPage();
            labelDetails = new Label();
            tabCharts = new TabPage();
            comboBox = new ComboBox();
            labelChartType = new Label();
            chartBox = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            tabDetails.SuspendLayout();
            tabCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBox).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectToolStripMenuItem, cancelToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            selectToolStripMenuItem.Size = new Size(180, 22);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            cancelToolStripMenuItem.Size = new Size(180, 22);
            cancelToolStripMenuItem.Text = "Cancel";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // tView
            // 
            tView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tView.ForeColor = SystemColors.InfoText;
            tView.Location = new Point(0, 61);
            tView.Name = "tView";
            tView.Size = new Size(265, 329);
            tView.TabIndex = 2;
            tView.BeforeExpand += tView_BeforeExpand;
            tView.BeforeSelect += tView_BeforeSelect;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonSelect);
            splitContainer1.Panel1.Controls.Add(tView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl);
            splitContainer1.Size = new Size(784, 390);
            splitContainer1.SplitterDistance = 261;
            splitContainer1.TabIndex = 3;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelect.Location = new Point(171, 32);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 3;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += selectToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabDetails);
            tabControl.Controls.Add(tabCharts);
            tabControl.Location = new Point(3, 27);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(516, 363);
            tabControl.TabIndex = 0;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(labelDetails);
            tabDetails.Location = new Point(4, 24);
            tabDetails.Name = "tabDetails";
            tabDetails.Padding = new Padding(3);
            tabDetails.Size = new Size(508, 335);
            tabDetails.TabIndex = 0;
            tabDetails.Text = "Details";
            tabDetails.UseVisualStyleBackColor = true;
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.Location = new Point(7, 12);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(0, 15);
            labelDetails.TabIndex = 0;
            labelDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabCharts
            // 
            tabCharts.Controls.Add(comboBox);
            tabCharts.Controls.Add(labelChartType);
            tabCharts.Controls.Add(chartBox);
            tabCharts.Location = new Point(4, 24);
            tabCharts.Name = "tabCharts";
            tabCharts.Padding = new Padding(3);
            tabCharts.Size = new Size(508, 335);
            tabCharts.TabIndex = 1;
            tabCharts.Text = "Charts";
            tabCharts.UseVisualStyleBackColor = true;
            // 
            // comboBox
            // 
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Bar chart", "Log bar chart", "Pie chart" });
            comboBox.Location = new Point(71, 10);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 23);
            comboBox.TabIndex = 0;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // labelChartType
            // 
            labelChartType.AutoSize = true;
            labelChartType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelChartType.Location = new Point(3, 13);
            labelChartType.Name = "labelChartType";
            labelChartType.Size = new Size(65, 15);
            labelChartType.TabIndex = 1;
            labelChartType.Text = "Chart type:";
            // 
            // chartBox
            // 
            chartBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartBox.BackColor = Color.Transparent;
            chartBox.Location = new Point(3, 35);
            chartBox.Name = "chartBox";
            chartBox.Size = new Size(502, 297);
            chartBox.TabIndex = 2;
            chartBox.TabStop = false;
            chartBox.SizeChanged += comboBox_SelectedIndexChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar });
            statusStrip1.Location = new Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.RightToLeft = RightToLeft.No;
            toolStripProgressBar.Size = new Size(100, 16);
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 450);
            Name = "Form1";
            Text = "Disk Space Analyzer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabDetails.PerformLayout();
            tabCharts.ResumeLayout(false);
            tabCharts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartBox).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private TreeView tView;
        private SplitContainer splitContainer1;
        private Button buttonSelect;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar;
        private TabControl tabControl;
        private TabPage tabDetails;
        private TabPage tabCharts;
        private Label labelDetails;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Label labelChartType;
        private ComboBox comboBox;
        private PictureBox chartBox;
    }
}