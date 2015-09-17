namespace MethylationPlot
{
    partial class MethyPlot
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
            this.PanelMethy = new System.Windows.Forms.Panel();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.txtBoxPos = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.txtBoxJump = new System.Windows.Forms.TextBox();
            this.chkGrads = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PanelMethy
            // 
            this.PanelMethy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMethy.Location = new System.Drawing.Point(15, 50);
            this.PanelMethy.Name = "PanelMethy";
            this.PanelMethy.Size = new System.Drawing.Size(1002, 112);
            this.PanelMethy.TabIndex = 0;
            this.PanelMethy.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMethy_Paint);
            this.PanelMethy.MouseCaptureChanged += new System.EventHandler(this.PanelMethy_MouseCaptureChanged);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(942, 12);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 1;
            this.btnGetFile.Text = "Get File";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // txtBoxPos
            // 
            this.txtBoxPos.Location = new System.Drawing.Point(70, 14);
            this.txtBoxPos.MaxLength = 11;
            this.txtBoxPos.Name = "txtBoxPos";
            this.txtBoxPos.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPos.TabIndex = 2;
            this.txtBoxPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPos_KeyPress);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(18, 20);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Position:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(189, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(310, 13);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(35, 23);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.Text = "<<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            this.btnLeft.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(444, 14);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(35, 23);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = ">>";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            this.btnRight.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtBoxJump
            // 
            this.txtBoxJump.Location = new System.Drawing.Point(352, 15);
            this.txtBoxJump.MaxLength = 5;
            this.txtBoxJump.Name = "txtBoxJump";
            this.txtBoxJump.Size = new System.Drawing.Size(86, 20);
            this.txtBoxJump.TabIndex = 7;
            this.txtBoxJump.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxJump_KeyPress);
            // 
            // chkGrads
            // 
            this.chkGrads.AutoSize = true;
            this.chkGrads.Location = new System.Drawing.Point(526, 17);
            this.chkGrads.Name = "chkGrads";
            this.chkGrads.Size = new System.Drawing.Size(81, 17);
            this.chkGrads.TabIndex = 8;
            this.chkGrads.Text = "ShowGrads";
            this.chkGrads.UseVisualStyleBackColor = true;
            this.chkGrads.CheckedChanged += new System.EventHandler(this.chkGrads_CheckedChanged);
            // 
            // MethyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 183);
            this.Controls.Add(this.chkGrads);
            this.Controls.Add(this.txtBoxJump);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtBoxPos);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.PanelMethy);
            this.Name = "MethyPlot";
            this.Text = "Methylation Plot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelMethy;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.TextBox txtBoxPos;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TextBox txtBoxJump;
        private System.Windows.Forms.CheckBox chkGrads;
    }
}

