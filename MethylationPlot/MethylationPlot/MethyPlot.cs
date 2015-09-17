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
    public partial class MethyPlot : Form
    {
        DrawPanel drawPanel = new DrawPanel();

        public static string FileName { get; set; }

        public static int FileLength { get; set; }

        public static long Position { get; set; }

        public static bool IsGrads { get; set; }

        private const int COLUMN = 100;
        private const int LENGTH = 100;

        public MethyPlot()
        {
            InitializeComponent();
        }

        private void PanelMethy_Paint(object sender, PaintEventArgs e)
        {
            drawPanel.DrawLine(PanelMethy);

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
            openFDMethy.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFDMethy.Filter = "*.txt|*.txt";
            openFDMethy.ValidateNames = true;
            openFDMethy.CheckFileExists = true;
            openFDMethy.CheckPathExists = true;

            try 
            {
                if (openFDMethy.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFDMethy.FileName;
                    FileLength = DensityFromFile.GetFileLength();
                    MessageBox.Show("Load file: " + FileName + " successfully." 
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

            if (FileName == null)
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            long position = Convert.ToInt64(positionStr);

            Position = position;

            if (position <= (FileLength * LENGTH - COLUMN * LENGTH))
            {
                drawPanel.FillSquare(PanelMethy);        
            }
            else
            {
                MessageBox.Show("Position exceeded.");
            }
        }

        private void PanelMethy_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (FileName == null || txtBoxPos.Text == "")
            {
                MessageBox.Show("Please fill information.");
                return;
            }

            Point p = PanelMethy.PointToClient(Control.MousePosition);

            double density;
            int y = p.X / 10;
            int x = p.Y / 10;

            DensityFromFile densityFromFile = new DensityFromFile();
            density = densityFromFile.GetDensity(x, y);
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
            long end;
            end = DensityFromFile.GetFileLength() * LENGTH - COLUMN * LENGTH;

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
    }
}
