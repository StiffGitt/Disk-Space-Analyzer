namespace lab6
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            folderBrowserDialog = new FolderBrowserDialog();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            buttonDialog = new Button();
            textBox1 = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(30, 62);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(418, 103);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.Click += listView1_Click;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Total";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Free";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 4;
            columnHeader4.Text = "Used/Total";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.DisplayIndex = 3;
            columnHeader5.Text = "Used/Total";
            columnHeader5.Width = 120;
            // 
            // buttonDialog
            // 
            buttonDialog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDialog.Location = new Point(380, 195);
            buttonDialog.Name = "buttonDialog";
            buttonDialog.Size = new Size(75, 24);
            buttonDialog.TabIndex = 4;
            buttonDialog.Text = "...";
            buttonDialog.UseVisualStyleBackColor = true;
            buttonDialog.Click += buttonDialog_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.FileSystem;
            textBox1.Location = new Point(30, 196);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(333, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(380, 234);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(288, 234);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(30, 12);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(100, 19);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "&All Local Drive";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(30, 37);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(107, 19);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "&Individual Drive";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(30, 171);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(69, 19);
            radioButton3.TabIndex = 10;
            radioButton3.TabStop = true;
            radioButton3.Text = "A &Folder";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(buttonDialog);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MinimumSize = new Size(500, 300);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Disk or Folder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button buttonDialog;
        private TextBox textBox1;
        private Button buttonOk;
        private Button buttonCancel;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private ColumnHeader columnHeader5;
    }
}