using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DifferentialSimulator
{
    public class DrawPanel
    {
        public int Row { get; set; }
        public int Column { get; set; }

        internal void DrawLine(Panel pnlDiff)
        {
            this.Row = 3;
            this.Column = 100;
            Graphics g = pnlDiff.CreateGraphics();

            for (int i = 1; i < Row; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0, pnlDiff.Height / Row * i,
                    pnlDiff.Width, pnlDiff.Height / Row * i);
            }

            for (int i = 1; i < Column; i++)
            {
                g.DrawLine(new Pen(Color.Black), pnlDiff.Width / Column * i, 0,
                    pnlDiff.Width / Column * i, pnlDiff.Height);
            }
        }

        internal void FillSquare(Panel pnlDiff, int[,] reads, int[] diff)
        {
            Graphics g = pnlDiff.CreateGraphics();
            Square square = new Square();

            for (int j = 0; j < Column; j++)
            {
                g.FillRectangle(new SolidBrush(square.JudgeGrid(j, diff)), pnlDiff.Width / Column * j + 2,
                        1, 4, 8);
                for (int i = 1; i < Row; i++)
                {
                    g.FillRectangle(new SolidBrush(square.MyGrid(i, j, reads)), pnlDiff.Width / Column * j + 2,
                        pnlDiff.Height / Row * i + 2, 4, 8);
                }
            }
        }
    }
}
