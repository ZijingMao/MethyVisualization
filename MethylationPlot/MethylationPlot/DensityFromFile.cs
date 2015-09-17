using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MethylationPlot
{
    public class DensityFromFile
    {
        private const int LENGTH = 100;

        public static string FileName { get; set; }

        private int[,] ReadFromPosition(long position)
        {            
            int lineNumber = 0;
            int i = 0;            
            
            string line;
            //char[] line = new char[LENGTH*3];
            int[,] binArray = new int[11, LENGTH];

            FileName = MethyPlot.FileName;
            StreamReader sr = new StreamReader(FileName, System.Text.Encoding.Default);
            
            //while (sr.Read(line, (int)position, LENGTH) != LENGTH)
            while((line = sr.ReadLine()) != null)
            {
                int p = 0;
                int index = 0;
                int length = 0;

                lineNumber++;
                if (MethyPlot.IsGrads == true && lineNumber == 1)
                    continue;
                if (MethyPlot.IsGrads == false && lineNumber == 2)
                    continue;

                while(index < position / 100)
                {
                    if (line[p++] == ',')
                    {
                        index++;    // Get the correct index
                    }
                }

                while (length < 100)
                {
                    StringBuilder sb = new StringBuilder();
                    while (line[p] != ',')
                    {
                        sb.Append(line[p++]);
                    }
                    if (lineNumber == 2)
                    {
                        double gamma = Convert.ToDouble(sb.ToString());
                        int grad = (int)(gamma * 180);
                        binArray[i, length] = 240 - grad;
                    }
                    else
                    {
                        binArray[i, length] = Convert.ToInt32(sb.ToString());
                    }
                    p++;
                    length++;
                }
                i++;
            }

            sr.Close();

            return binArray;
        }

        //private static int[] ConvertStrToArray(string str, long position)
        //{
        //    long binNumber;
        //    string[] strArray = null;
        //    int[] densityArray = new int[LENGTH];

        //    strArray = str.Split(new char[] { ',' });
        //    binNumber = position / LENGTH;

        //    for (int j = 0; j < LENGTH; j++)
        //    {
        //        densityArray[j] = 240;
        //    }

        //    for (int i = 0; i < LENGTH; i++)
        //    {
        //        densityArray[i] = Convert.ToInt32(strArray[i]);
        //    }
        //    return densityArray;
        //}

        internal double GetDensity(int x, int y)
        {
            int[,] binArray = new int[11, LENGTH];
            long position = 0;
            long length;

            if (MethyPlot.Position != 0)
            {
                position = MethyPlot.Position; 
            }

            length = MethyPlot.FileLength;
            length = length * LENGTH;

            if ((length - 100 * LENGTH) < position) 
            {
                position = (length - 100 * LENGTH);
            }

            binArray = ReadFromPosition(position);

            return binArray[x, y];
        }

        internal double Normalization(double density)
        {
            if (density >= 70) return 0;
            if (density < 70 && density >= 10) return (62.5 - density * 1.25);
            if (density < 10 && density >= 5) return (190 - density * 14);
            return (240 - density * 24);
        }

        internal static int GetFileLength()
        {
            string line = null;
            int index = 1, p = 0;

            FileName = MethyPlot.FileName;
            StreamReader sr = new StreamReader(FileName, System.Text.Encoding.Default);

            if ((line = sr.ReadLine()) != null)
            {
                for (p = 0; p < line.Length; p++)
                {
                    if (line[p] == ',')
                        index++;
                }
            }

            sr.Close();

            return index;
        }
    }
}
