using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MethylationPlot
{
    public class DrawPanel
    {
        public int Row { get; set; }
        public int Column { get; set; }

        internal void DrawLine(Panel PanelMethy)
        {
            this.Row = 11;
            this.Column = 100;
            Graphics g = PanelMethy.CreateGraphics();

            for (int i = 1; i < Row; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0, PanelMethy.Height / Row * i,
                    PanelMethy.Width, PanelMethy.Height / Row * i);
            }

            for (int i = 1; i < Column; i++)
            {
                g.DrawLine(new Pen(Color.Black), PanelMethy.Width / Column * i, 0,
                    PanelMethy.Width / Column * i, PanelMethy.Height);
            }
        }

        internal void FillSquare(Panel PanelMethy, int type)
        {
            Graphics g = PanelMethy.CreateGraphics();
            Square square = new Square();

            for (int j = 0; j < Column; j++)
            {
                g.FillRectangle(new SolidBrush(square.JudgeGrid(0, j, type)), PanelMethy.Width / Column * j + 2,
                        1, 7, 8);
                for (int i = 1; i < Row; i++)
                {
                    g.FillRectangle(new SolidBrush(square.MyGrid(i, j, type)), PanelMethy.Width / Column * j + 2,
                        PanelMethy.Height / Row * i + 2, 7, 7);
                }
            }
        }

        internal void DrawCol(Panel PanelMethy)
        {
            this.Column = 100;
            Graphics g = PanelMethy.CreateGraphics();

            for (int i = 1; i < Column; i++)
            {
                g.DrawLine(new Pen(Color.Black), PanelMethy.Width / Column * i, 0,
                    PanelMethy.Width / Column * i, PanelMethy.Height);
            }
        }

        internal void FillDiff(Panel PanelMethy, string fileName)
        {
            Graphics g = PanelMethy.CreateGraphics();
            Square square = new Square();

            for (int j = 0; j < Column; j++)
            {
                g.FillRectangle(new SolidBrush(square.JudgeGridD(0, j, fileName)), PanelMethy.Width / Column * j + 2,
                        1, 7, 8);
            }
        }
    }
}
