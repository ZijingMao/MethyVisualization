using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MethylationPlot
{
    public class Square
    {
        DensityFromFile densityFromFile = new DensityFromFile();

        public Color MyGrid(int x, int y)
        {
            double density = densityFromFile.GetDensity(x, y);
            double lum = densityFromFile.Normalization(density);

            if (density == 0)
                lum = 160;
            else
                lum = 240;
            

            HSLColor hslColor = new HSLColor(0.0, 240.0, lum);
            Color color = (Color)hslColor;
            return color;
        }

        public Color JudgeGrid(int x, int y)
        {
            double lum = 0;
            double density = densityFromFile.GetDensity(x, y);

            //if (MethyPlot.IsGrads)
            //{
            //    lum = densityFromFile.GetDensity(x, y);
            //}
            //else
            //{
                if (density == 0)
                    lum = 240;
                else if (density == 1)
                    lum = 160;
                else
                    lum = 40;
            //}

            HSLColor hslColor = new HSLColor(70.0, 160.0, lum);
            Color color = (Color)hslColor;
            return color;
        }
    }
}
