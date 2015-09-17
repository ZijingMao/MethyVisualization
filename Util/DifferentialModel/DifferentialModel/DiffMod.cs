using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DifferentialModel
{
    public partial class DiffMod : Form
    {
        public static string FileName { get; set; }

        public DiffMod()
        {
            InitializeComponent();
        }

        private void btnGetF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "Open";
            openFD.FileName = "";
            openFD.Filter = "All files|*.*";
            openFD.ValidateNames = true;
            openFD.CheckFileExists = true;
            openFD.CheckPathExists = true;

            try
            {
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFD.FileName;
                    txtPath.Text = FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int[][] array = FileHelper.ReadFile();
            LogDiffMod lGM = new LogDiffMod(array);
            int[] seq = lGM.convertState(array);
            double likelihood = lGM.Learn(seq, 30, 0.00001);
            double[,] gamma = lGM.Gamma;
            int[] mark = lGM.Mark;

            FileHelper.WriteFile(mark);
        }
    }
}
