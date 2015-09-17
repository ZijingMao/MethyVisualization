using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DifferentialSimulator
{
    public class Square
    {
        internal Color MyGrid(int i, int j, int[,] reads)
        {
            double lum = 0;
            double density = reads[i - 1, j];

            if (density == 0)
                lum = 160;
            else
                lum = 240;

            HSLColor hslColor = new HSLColor(0.0, 240.0, lum);
            Color color = (Color)hslColor;
            return color;
        }

        internal Color JudgeGrid(int j, int[] diff)
        {
            double lum = 0;
            double density = diff[j];

            if (density == 1)
                lum = 160;
            else
                lum = 240;

            HSLColor hslColor = new HSLColor(70.0, 160.0, lum);
            Color color = (Color)hslColor;
            return color;
        }
    }
}
