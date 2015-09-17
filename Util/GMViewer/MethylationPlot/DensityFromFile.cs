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

        public static string FileNameN { get; set; }

        public static string FileNameC { get; set; }

        public static string FileNameD { get; set; }

        public static int[,] BinArrayC { get; set; }

        public static int[,] BinArrayN { get; set; }

        public static int[,] BinArrayD { get; set; }    

        private int[,] ReadFromPosition(long position,string fileName)
        {            
            int lineNumber = 0;
            int i = 0;            
            
            string line;
            //char[] line = new char[LENGTH*3];
            int[,] binArray = new int[11, LENGTH];

            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
            
            //while (sr.Read(line, (int)position, LENGTH) != LENGTH)
            while((line = sr.ReadLine()) != null)
            {
                int p = 0;
                int index = 0;
                int length = 0;

                lineNumber++;

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
                    binArray[i, length] = Convert.ToInt32(sb.ToString());
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

        internal double GetDensity(int x, int y, int type)
        {
            int position = 0;
            int length;

            if (GMPlot.Position != 0)
            {
                position = GMPlot.Position; 
            }

            length = GMPlot.FileLength;
            length = length * LENGTH;

            if ((length - 100 * LENGTH) < position) 
            {
                position = (length - 100 * LENGTH);
            }

            //binArray = ReadFromPosition(position, fileName);

            int index = position / 100;

            if (type == 0)
            {
                return BinArrayN[x, index + y];
            }
            else
            {
                return BinArrayC[x, index + y];
            }
        }

        internal double Normalization(double density)
        {
            if (density >= 70) return 0;
            if (density < 70 && density >= 10) return (62.5 - density * 1.25);
            if (density < 10 && density >= 5) return (190 - density * 14);
            return (240 - density * 24);
        }

        internal static int GetFileLength(string fileName)
        {
            string line = null;
            int index = 1, p = 0;

            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);

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

        internal double GetDensityD(int x, int y, string fileName)
        {
            int position = 0;
            int length;

            if (GMPlot.Position != 0)
            {
                position = GMPlot.Position;
            }

            length = GMPlot.FileLength;
            length = length * LENGTH;

            if ((length - 100 * LENGTH) < position)
            {
                position = (length - 100 * LENGTH);
            }

            int index = position / 100;

            return BinArrayD[x, index + y];
        }

        internal static int[,] ReadFileD(string fileName, int FileLength)
        {
            int lineNumber = 0;
            int i = 0;

            string line;
            //char[] line = new char[LENGTH*3];
            int[,] binArrayD = new int[1, FileLength];

            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);

            //while (sr.Read(line, (int)position, LENGTH) != LENGTH)
            while ((line = sr.ReadLine()) != null)
            {
                int p = 0;
                int length = 0;

                lineNumber++;
                
                while (length < FileLength)
                {
                    StringBuilder sb = new StringBuilder();
                    while (p < line.Length && line[p] != ',')
                    {
                        sb.Append(line[p++]);
                    }
                    binArrayD[i, length] = Convert.ToInt32(sb.ToString());
                    p++;
                    length++;
                }
                i++;
            }

            sr.Close();

            return binArrayD;
        }

        internal static int[,] ReadFile(string fileName, int FileLength)
        {
            int lineNumber = 0;
            int i = 0;

            string line;
            //char[] line = new char[LENGTH*3];
            int[,] binArray = new int[11, FileLength];

            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);

            //while (sr.Read(line, (int)position, LENGTH) != LENGTH)
            while ((line = sr.ReadLine()) != null)
            {
                int p = 0;
                int length = 0;

                lineNumber++;

                while (length < FileLength)
                {
                    StringBuilder sb = new StringBuilder();
                    while (p < line.Length && line[p] != ',')
                    {
                        sb.Append(line[p++]);
                    }
                    binArray[i, length] = Convert.ToInt32(sb.ToString());
                    p++;
                    length++;
                }
                i++;
            }

            sr.Close();

            return binArray;
        }
    }
}
