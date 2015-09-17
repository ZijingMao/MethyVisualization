using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MethylationPlot
{
    public partial class GMPlot : Form
    {
        DrawPanel drawPanel = new DrawPanel();

        public static string FileNameN { get; set; }

        public static string FileNameC { get; set; }

        public static string FileNameD { get; set; }

        public static int FileLength { get; set; }

        public static int Position { get; set; }

        public static bool IsGrads { get; set; }

        private const int COLUMN = 100;
        private const int LENGTH = 100;

        public GMPlot()
        {
            InitializeComponent();
        }

        private void PanelMethy_Paint(object sender, PaintEventArgs e)
        {
            drawPanel.DrawLine(PanelMethyNormal);

            //if (FileName != null && txtBoxPos.Text == null)
            //{
            //    drawPanel.FillSquare(PanelMethy);
            //}
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFDMethy = new OpenFileDialog();
            openFDMethy.Title = "Open";
            openFDMethy.FileName = "";
            //openFDMethy.Filter = "*.txt|*.txt";
            openFDMethy.ValidateNames = true;
            openFDMethy.CheckFileExists = true;
            openFDMethy.CheckPathExists = true;

            try 
            {
                if (openFDMethy.ShowDialog() == DialogResult.OK)
                {
                    FileNameD = openFDMethy.FileName;
                    FileLength = DensityFromFile.GetFileLength(FileNameD);
                    DensityFromFile.BinArrayD = DensityFromFile.ReadFileD(FileNameD, FileLength);
                    MessageBox.Show("Load file: " + FileNameD + " successfully." 
                        + "\n       Bins length: " + Convert.ToString(FileLength));
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString()); 
            }
        }

        private void txtBoxPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < 48 || e.KeyChar > 57) &&
                e.KeyChar != 8 && e.KeyChar != 13)
            {
                //MessageBox.Show("Please enter a number");
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string positionStr = txtBoxPos.Text;

            if (positionStr == "")
            {
                MessageBox.Show("Please enter a number.");
                return;
            }

            if (FileNameC == null && FileNameN == null && FileNameD == null)
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            int position = Convert.ToInt32(positionStr);

            Position = position;

            if (position <= (FileLength * LENGTH - COLUMN * LENGTH))
            {
                drawPanel.FillSquare(PanelMethyNormal, 0);
                drawPanel.FillSquare(PanelMethyCancer, 1);
                drawPanel.FillDiff(pnlDiff, FileNameD); 
            }
            else
            {
                MessageBox.Show("Position exceeded.");
            }
        }

        private void PanelMethy_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (FileNameN == null || txtBoxPos.Text == "")
            {
                MessageBox.Show("Please fill information.");
                return;
            }

            Point p = PanelMethyNormal.PointToClient(Control.MousePosition);

            double density;
            int y = p.X / 10;
            int x = p.Y / 10;

            DensityFromFile densityFromFile = new DensityFromFile();
            density = densityFromFile.GetDensity(x, y, 0);
            MessageBox.Show("Density: "+Convert.ToString(density));
        }

        private void txtBoxJump_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) &&
                e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            int end;
            end = DensityFromFile.GetFileLength(FileNameD) * LENGTH - COLUMN * LENGTH;

            if (txtBoxJump.Text == "")
            {
                MessageBox.Show("Please enter a number.");
                return;
            }

            int distance = Convert.ToInt32(txtBoxJump.Text);

            Position = Position + distance;
            if (Position >= end)
            {
                Position = end;
            }

            txtBoxPos.Text = Convert.ToString(Position);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (txtBoxJump.Text == "")
            {
                MessageBox.Show("Please enter a number.");
                return;
            }

            int distance = Convert.ToInt32(txtBoxJump.Text);

            Position = Position - distance;
            if (Position <= 0)
            {
                Position = 0;
            }

            txtBoxPos.Text = Convert.ToString(Position);
        }

        private void chkGrads_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGrads.Checked)
            {
                IsGrads = true;
            }
            else
            {
                IsGrads = false;
            }
        }

        private void PanelMethyCancer_Paint(object sender, PaintEventArgs e)
        {
            drawPanel.DrawLine(PanelMethyCancer);
        }

        private void pnlDiff_Paint(object sender, PaintEventArgs e)
        {
            drawPanel.DrawCol(pnlDiff);
        }

        private void PanelMethyCancer_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (FileNameC == null || txtBoxPos.Text == "")
            {
                MessageBox.Show("Please fill information.");
                return;
            }

            Point p = PanelMethyCancer.PointToClient(Control.MousePosition);

            double density;
            int y = p.X / 10;
            int x = p.Y / 10;

            DensityFromFile densityFromFile = new DensityFromFile();
            density = densityFromFile.GetDensity(x, y, 1);
            MessageBox.Show("Density: " + Convert.ToString(density));
        }

        private void btnCancer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFDMethy = new OpenFileDialog();
            openFDMethy.Title = "Open";
            openFDMethy.FileName = "";
            //openFDMethy.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //openFDMethy.Filter = "*.txt|*.txt";
            openFDMethy.ValidateNames = true;
            openFDMethy.CheckFileExists = true;
            openFDMethy.CheckPathExists = true;

            try
            {
                if (openFDMethy.ShowDialog() == DialogResult.OK)
                {
                    FileNameC = openFDMethy.FileName;
                    FileLength = DensityFromFile.GetFileLength(FileNameC);
                    DensityFromFile.BinArrayC = DensityFromFile.ReadFile(FileNameC, FileLength);
                    MessageBox.Show("Load file: " + FileNameC + " successfully."
                        + "\n       Bins length: " + Convert.ToString(FileLength));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFDMethy = new OpenFileDialog();
            openFDMethy.Title = "Open";
            openFDMethy.FileName = "";
            //openFDMethy.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //openFDMethy.Filter = "*.txt|*.txt";
            openFDMethy.ValidateNames = true;
            openFDMethy.CheckFileExists = true;
            openFDMethy.CheckPathExists = true;

            try
            {
                if (openFDMethy.ShowDialog() == DialogResult.OK)
                {
                    FileNameN = openFDMethy.FileName;
                    FileLength = DensityFromFile.GetFileLength(FileNameN);
                    DensityFromFile.BinArrayN = DensityFromFile.ReadFile(FileNameN, FileLength);
                    MessageBox.Show("Load file: " + FileNameN + " successfully."
                        + "\n       Bins length: " + Convert.ToString(FileLength));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
