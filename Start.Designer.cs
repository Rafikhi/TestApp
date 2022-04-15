
namespace TestApp
{
    partial class Start
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
            this.txt_file = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_file_path = new System.Windows.Forms.TextBox();
            this.folder_path = new System.Windows.Forms.TextBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.file_path_btn = new System.Windows.Forms.Button();
            this.folder_path_btn = new System.Windows.Forms.Button();
            this.browse_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.browse_file = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txt_file
            // 
            this.txt_file.AutoSize = true;
            this.txt_file.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_file.Location = new System.Drawing.Point(129, 48);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(157, 32);
            this.txt_file.TabIndex = 0;
            this.txt_file.Text = "Plik tekstowy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(129, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder:";
            // 
            // txt_file_path
            // 
            this.txt_file_path.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_file_path.Location = new System.Drawing.Point(129, 83);
            this.txt_file_path.Name = "txt_file_path";
            this.txt_file_path.Size = new System.Drawing.Size(387, 39);
            this.txt_file_path.TabIndex = 2;
            this.txt_file_path.TextChanged += new System.EventHandler(this.txt_file_path_TextChanged);
            // 
            // folder_path
            // 
            this.folder_path.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.folder_path.Location = new System.Drawing.Point(129, 194);
            this.folder_path.Name = "folder_path";
            this.folder_path.Size = new System.Drawing.Size(387, 39);
            this.folder_path.TabIndex = 3;
            this.folder_path.TextChanged += new System.EventHandler(this.folder_path_TextChanged);
            // 
            // confirm_btn
            // 
            this.confirm_btn.Enabled = false;
            this.confirm_btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirm_btn.Location = new System.Drawing.Point(296, 348);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(137, 48);
            this.confirm_btn.TabIndex = 4;
            this.confirm_btn.Text = "Zatwierdź";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // file_path_btn
            // 
            this.file_path_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.file_path_btn.Location = new System.Drawing.Point(543, 83);
            this.file_path_btn.Name = "file_path_btn";
            this.file_path_btn.Size = new System.Drawing.Size(152, 39);
            this.file_path_btn.TabIndex = 5;
            this.file_path_btn.Text = "Wybierz plik";
            this.file_path_btn.UseVisualStyleBackColor = true;
            this.file_path_btn.Click += new System.EventHandler(this.file_path_btn_Click);
            // 
            // folder_path_btn
            // 
            this.folder_path_btn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.folder_path_btn.Location = new System.Drawing.Point(543, 194);
            this.folder_path_btn.Name = "folder_path_btn";
            this.folder_path_btn.Size = new System.Drawing.Size(152, 38);
            this.folder_path_btn.TabIndex = 6;
            this.folder_path_btn.Text = "Wybierz folder";
            this.folder_path_btn.UseVisualStyleBackColor = true;
            this.folder_path_btn.Click += new System.EventHandler(this.folder_path_btn_Click);
            // 
            // browse_file
            // 
            this.browse_file.FileName = "openFileDialog1";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.folder_path_btn);
            this.Controls.Add(this.file_path_btn);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.folder_path);
            this.Controls.Add(this.txt_file_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_file);
            this.Name = "Start";
            this.Text = "Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_file_path;
        private System.Windows.Forms.TextBox folder_path;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button file_path_btn;
        private System.Windows.Forms.Button folder_path_btn;
        private System.Windows.Forms.FolderBrowserDialog browse_folder;
        private System.Windows.Forms.OpenFileDialog browse_file;
    }
}