
namespace _211104_FileManager
{
    partial class WinForms_FileManager2
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
            this.button_createDir = new System.Windows.Forms.Button();
            this.listBox_currentDirL = new System.Windows.Forms.ListBox();
            this.textBox_createDir = new System.Windows.Forms.TextBox();
            this.button_deleteDir = new System.Windows.Forms.Button();
            this.textBox_deleteDir = new System.Windows.Forms.TextBox();
            this.listBox_currentDirR = new System.Windows.Forms.ListBox();
            this.button_copyFile = new System.Windows.Forms.Button();
            this.button_moveFile = new System.Windows.Forms.Button();
            this.button_deleteFile = new System.Windows.Forms.Button();
            this.dgv_L = new System.Windows.Forms.DataGridView();
            this.dgv_R = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_R)).BeginInit();
            this.SuspendLayout();
            // 
            // button_createDir
            // 
            this.button_createDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_createDir.Location = new System.Drawing.Point(23, 10);
            this.button_createDir.Margin = new System.Windows.Forms.Padding(2);
            this.button_createDir.Name = "button_createDir";
            this.button_createDir.Size = new System.Drawing.Size(143, 27);
            this.button_createDir.TabIndex = 4;
            this.button_createDir.Text = "Create Directory:";
            this.button_createDir.UseVisualStyleBackColor = true;
            this.button_createDir.Click += new System.EventHandler(this.Button_createDir_Click);
            // 
            // listBox_currentDirL
            // 
            this.listBox_currentDirL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_currentDirL.FormattingEnabled = true;
            this.listBox_currentDirL.ItemHeight = 16;
            this.listBox_currentDirL.Location = new System.Drawing.Point(23, 41);
            this.listBox_currentDirL.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_currentDirL.Name = "listBox_currentDirL";
            this.listBox_currentDirL.Size = new System.Drawing.Size(620, 20);
            this.listBox_currentDirL.TabIndex = 2;
            // 
            // textBox_createDir
            // 
            this.textBox_createDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_createDir.Location = new System.Drawing.Point(171, 12);
            this.textBox_createDir.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_createDir.Name = "textBox_createDir";
            this.textBox_createDir.Size = new System.Drawing.Size(149, 23);
            this.textBox_createDir.TabIndex = 5;
            // 
            // button_deleteDir
            // 
            this.button_deleteDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_deleteDir.Location = new System.Drawing.Point(347, 10);
            this.button_deleteDir.Margin = new System.Windows.Forms.Padding(2);
            this.button_deleteDir.Name = "button_deleteDir";
            this.button_deleteDir.Size = new System.Drawing.Size(143, 27);
            this.button_deleteDir.TabIndex = 6;
            this.button_deleteDir.Text = "Delete Directory:";
            this.button_deleteDir.UseVisualStyleBackColor = true;
            this.button_deleteDir.Click += new System.EventHandler(this.Button_deleteDir_Click);
            // 
            // textBox_deleteDir
            // 
            this.textBox_deleteDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_deleteDir.Location = new System.Drawing.Point(494, 12);
            this.textBox_deleteDir.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_deleteDir.Name = "textBox_deleteDir";
            this.textBox_deleteDir.Size = new System.Drawing.Size(149, 23);
            this.textBox_deleteDir.TabIndex = 7;
            // 
            // listBox_currentDirR
            // 
            this.listBox_currentDirR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_currentDirR.FormattingEnabled = true;
            this.listBox_currentDirR.ItemHeight = 16;
            this.listBox_currentDirR.Location = new System.Drawing.Point(647, 41);
            this.listBox_currentDirR.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_currentDirR.Name = "listBox_currentDirR";
            this.listBox_currentDirR.Size = new System.Drawing.Size(620, 20);
            this.listBox_currentDirR.TabIndex = 3;
            // 
            // button_copyFile
            // 
            this.button_copyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_copyFile.Location = new System.Drawing.Point(647, 10);
            this.button_copyFile.Margin = new System.Windows.Forms.Padding(2);
            this.button_copyFile.Name = "button_copyFile";
            this.button_copyFile.Size = new System.Drawing.Size(143, 27);
            this.button_copyFile.TabIndex = 8;
            this.button_copyFile.Text = "Copy file";
            this.button_copyFile.UseVisualStyleBackColor = true;
            this.button_copyFile.Click += new System.EventHandler(this.Button_copyFile_Click);
            // 
            // button_moveFile
            // 
            this.button_moveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_moveFile.Location = new System.Drawing.Point(794, 10);
            this.button_moveFile.Margin = new System.Windows.Forms.Padding(2);
            this.button_moveFile.Name = "button_moveFile";
            this.button_moveFile.Size = new System.Drawing.Size(143, 27);
            this.button_moveFile.TabIndex = 9;
            this.button_moveFile.Text = "Move file";
            this.button_moveFile.UseVisualStyleBackColor = true;
            this.button_moveFile.Click += new System.EventHandler(this.Button_moveFile_Click);
            // 
            // button_deleteFile
            // 
            this.button_deleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_deleteFile.Location = new System.Drawing.Point(941, 10);
            this.button_deleteFile.Margin = new System.Windows.Forms.Padding(2);
            this.button_deleteFile.Name = "button_deleteFile";
            this.button_deleteFile.Size = new System.Drawing.Size(143, 27);
            this.button_deleteFile.TabIndex = 10;
            this.button_deleteFile.Text = "Delete file";
            this.button_deleteFile.UseVisualStyleBackColor = true;
            this.button_deleteFile.Click += new System.EventHandler(this.Button_deleteFile_Click);
            // 
            // dgv_L
            // 
            this.dgv_L.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_L.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_L.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_L.Location = new System.Drawing.Point(20, 71);
            this.dgv_L.Name = "dgv_L";
            this.dgv_L.ReadOnly = true;
            this.dgv_L.Size = new System.Drawing.Size(623, 565);
            this.dgv_L.StandardTab = true;
            this.dgv_L.TabIndex = 0;
            this.dgv_L.SelectionChanged += new System.EventHandler(this.Dgv_L_SelectionChanged);
            this.dgv_L.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_L_KeyDown);
            // 
            // dgv_R
            // 
            this.dgv_R.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_R.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_R.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_R.Location = new System.Drawing.Point(647, 71);
            this.dgv_R.Name = "dgv_R";
            this.dgv_R.ReadOnly = true;
            this.dgv_R.Size = new System.Drawing.Size(623, 565);
            this.dgv_R.StandardTab = true;
            this.dgv_R.TabIndex = 1;
            this.dgv_R.SelectionChanged += new System.EventHandler(this.Dgv_R_SelectionChanged);
            this.dgv_R.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_R_KeyDown);
            // 
            // WinForms_FileManager2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.dgv_R);
            this.Controls.Add(this.dgv_L);
            this.Controls.Add(this.button_deleteFile);
            this.Controls.Add(this.button_moveFile);
            this.Controls.Add(this.button_copyFile);
            this.Controls.Add(this.listBox_currentDirR);
            this.Controls.Add(this.textBox_deleteDir);
            this.Controls.Add(this.button_deleteDir);
            this.Controls.Add(this.textBox_createDir);
            this.Controls.Add(this.listBox_currentDirL);
            this.Controls.Add(this.button_createDir);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WinForms_FileManager2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_R)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_createDir;
        private System.Windows.Forms.ListBox listBox_currentDirL;
        private System.Windows.Forms.TextBox textBox_createDir;
        private System.Windows.Forms.Button button_deleteDir;
        private System.Windows.Forms.TextBox textBox_deleteDir;
        private System.Windows.Forms.ListBox listBox_currentDirR;
        private System.Windows.Forms.Button button_copyFile;
        private System.Windows.Forms.Button button_moveFile;
        private System.Windows.Forms.Button button_deleteFile;
        private System.Windows.Forms.DataGridView dgv_L;
        private System.Windows.Forms.DataGridView dgv_R;
    }
}

