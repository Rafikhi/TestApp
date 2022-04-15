
namespace TestApp
{
    partial class Check
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.counter = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(87, 198);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(639, 41);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.counter.Location = new System.Drawing.Point(154, 145);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(0, 32);
            this.counter.TabIndex = 1;
            // 
            // end
            // 
            this.end.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.end.Location = new System.Drawing.Point(277, 343);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(190, 58);
            this.end.TabIndex = 2;
            this.end.Text = "Zakończ";
            this.end.UseVisualStyleBackColor = true;
            this.end.Visible = false;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.end);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.progressBar);
            this.Name = "Check";
            this.Text = "Check";
            this.Shown += new System.EventHandler(this.Check_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Button end;
    }
}