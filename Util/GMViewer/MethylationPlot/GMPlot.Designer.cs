namespace MethylationPlot
{
    partial class GMPlot
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
            this.PanelMethyNormal = new System.Windows.Forms.Panel();
            this.btnDiff = new System.Windows.Forms.Button();
            this.txtBoxPos = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.txtBoxJump = new System.Windows.Forms.TextBox();
            this.chkGrads = new System.Windows.Forms.CheckBox();
            this.PanelMethyCancer = new System.Windows.Forms.Panel();
            this.pnlDiff = new System.Windows.Forms.Panel();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnCancer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PanelMethyNormal
            // 
            this.PanelMethyNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMethyNormal.Location = new System.Drawing.Point(15, 74);
            this.PanelMethyNormal.Name = "PanelMethyNormal";
            this.PanelMethyNormal.Size = new System.Drawing.Size(1002, 112);
            this.PanelMethyNormal.TabIndex = 0;
            this.PanelMethyNormal.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMethy_Paint);
            this.PanelMethyNormal.MouseCaptureChanged += new System.EventHandler(this.PanelMethy_MouseCaptureChanged);
            // 
            // btnDiff
            // 
            this.btnDiff.Location = new System.Drawing.Point(942, 12);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(75, 23);
            this.btnDiff.TabIndex = 1;
            this.btnDiff.Text = "Get Diff";
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnGetFile_Click);
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
            // PanelMethyCancer
            // 
            this.PanelMethyCancer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMethyCancer.Location = new System.Drawing.Point(15, 196);
            this.PanelMethyCancer.Name = "PanelMethyCancer";
            this.PanelMethyCancer.Size = new System.Drawing.Size(1002, 112);
            this.PanelMethyCancer.TabIndex = 1;
            this.PanelMethyCancer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMethyCancer_Paint);
            this.PanelMethyCancer.MouseCaptureChanged += new System.EventHandler(this.PanelMethyCancer_MouseCaptureChanged);
            // 
            // pnlDiff
            // 
            this.pnlDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiff.Location = new System.Drawing.Point(15, 51);
            this.pnlDiff.Name = "pnlDiff";
            this.pnlDiff.Size = new System.Drawing.Size(1002, 12);
            this.pnlDiff.TabIndex = 1;
            this.pnlDiff.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDiff_Paint);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(714, 12);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(75, 23);
            this.btnNormal.TabIndex = 9;
            this.btnNormal.Text = "Get Nor";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnCancer
            // 
            this.btnCancer.Location = new System.Drawing.Point(829, 12);
            this.btnCancer.Name = "btnCancer";
            this.btnCancer.Size = new System.Drawing.Size(75, 23);
            this.btnCancer.TabIndex = 10;
            this.btnCancer.Text = "Get Can";
            this.btnCancer.UseVisualStyleBackColor = true;
            this.btnCancer.Click += new System.EventHandler(this.btnCancer_Click);
            // 
            // GMPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 325);
            this.Controls.Add(this.btnCancer);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.pnlDiff);
            this.Controls.Add(this.PanelMethyCancer);
            this.Controls.Add(this.chkGrads);
            this.Controls.Add(this.txtBoxJump);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtBoxPos);
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.PanelMethyNormal);
            this.Name = "GMPlot";
            this.Text = "GM Plot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelMethyNormal;
        private System.Windows.Forms.Button btnDiff;
        private System.Windows.Forms.TextBox txtBoxPos;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TextBox txtBoxJump;
        private System.Windows.Forms.CheckBox chkGrads;
        private System.Windows.Forms.Panel PanelMethyCancer;
        private System.Windows.Forms.Panel pnlDiff;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnCancer;
    }
}

