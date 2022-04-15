
namespace TestApp
{
    partial class Output
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
            this.announcement = new System.Windows.Forms.Label();
            this.csvLink = new System.Windows.Forms.LinkLabel();
            this.btn_go_to_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // announcement
            // 
            this.announcement.AutoSize = true;
            this.announcement.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.announcement.Location = new System.Drawing.Point(175, 168);
            this.announcement.Name = "announcement";
            this.announcement.Size = new System.Drawing.Size(446, 45);
            this.announcement.TabIndex = 0;
            this.announcement.Text = "Plik wynikowy jest już gotowy:";
            // 
            // csvLink
            // 
            this.csvLink.AutoSize = true;
            this.csvLink.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.csvLink.Location = new System.Drawing.Point(184, 238);
            this.csvLink.Name = "csvLink";
            this.csvLink.Size = new System.Drawing.Size(0, 32);
            this.csvLink.TabIndex = 1;
            this.csvLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.csvLink_LinkClicked);
            // 
            // btn_go_to_start
            // 
            this.btn_go_to_start.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_go_to_start.Location = new System.Drawing.Point(13, 13);
            this.btn_go_to_start.Name = "btn_go_to_start";
            this.btn_go_to_start.Size = new System.Drawing.Size(288, 65);
            this.btn_go_to_start.TabIndex = 2;
            this.btn_go_to_start.Text = "Wczytaj kolejny zestaw";
            this.btn_go_to_start.UseVisualStyleBackColor = true;
            this.btn_go_to_start.Click += new System.EventHandler(this.btn_go_to_start_Click);
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_go_to_start);
            this.Controls.Add(this.csvLink);
            this.Controls.Add(this.announcement);
            this.Name = "Output";
            this.Text = "Output";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label announcement;
        private System.Windows.Forms.LinkLabel csvLink;
        private System.Windows.Forms.Button btn_go_to_start;
    }
}