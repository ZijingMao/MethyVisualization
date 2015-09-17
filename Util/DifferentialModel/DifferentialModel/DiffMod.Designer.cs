namespace DifferentialModel
{
    partial class DiffMod
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGetF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(205, 237);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 14);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(170, 20);
            this.txtPath.TabIndex = 5;
            // 
            // btnGetF
            // 
            this.btnGetF.Location = new System.Drawing.Point(205, 12);
            this.btnGetF.Name = "btnGetF";
            this.btnGetF.Size = new System.Drawing.Size(75, 23);
            this.btnGetF.TabIndex = 4;
            this.btnGetF.Text = "GetFile";
            this.btnGetF.UseVisualStyleBackColor = true;
            this.btnGetF.Click += new System.EventHandler(this.btnGetF_Click);
            // 
            // DiffMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnGetF);
            this.Name = "DiffMod";
            this.Text = "Differential Model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGetF;
    }
}

