using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DifferentialSimulator
{
    public partial class DiffSim : Form
    {
        public static int Pos = 0;

        public int[,] R;
        public int[] D;

        DrawPanel d = new DrawPanel();

        public DiffSim()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Pos = 0;

            Simulator s = new Simulator();
            R = s.Gen();
            D = s.diff;

            FileHelper.WriteDiff(D);
            FileHelper.WriteFile(R);

            d.FillSquare(pnlDiff, R, D);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Pos > 9000)
            {
                Pos = 9000;
            }
            else
            {
                Pos += 100;
                int[,] reads = new int[2, 100];
                int[] diff = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    diff[i] = D[Pos + i];
                    for (int j = 0; j < 2; j++)
                    {
                        reads[j, i] = R[j, Pos + i];
                    }
                }
                d.FillSquare(pnlDiff, reads, diff);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Pos < 100)
            {
                Pos = 0;
            }
            else
            {
                Pos -= 100;
                int[,] reads = new int[2, 100];
                int[] diff = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    diff[i] = D[Pos + i];
                    for (int j = 0; j < 2; j++)
                    {
                        reads[j, i] = R[j, Pos + i];
                    }
                }
                d.FillSquare(pnlDiff, reads, diff);
            }
        }

        private void pnlDiff_Paint(object sender, PaintEventArgs e)
        {
            d.DrawLine(pnlDiff);
        }
    }
}
