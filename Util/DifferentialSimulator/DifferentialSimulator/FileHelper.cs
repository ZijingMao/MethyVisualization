using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DifferentialSimulator
{
    public class FileHelper
    {
        public static void WriteFile(int[,] reads)
        {
            StreamWriter sw = new StreamWriter("reads.txt");

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 10000; i++)
                {
                    sw.Write(reads[j, i]);
                    if (i != 9999)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
                sw.Flush();
            }

            sw.Close();
        }

        public static void WriteDiff(int[] diff)
        {
            StreamWriter sw = new StreamWriter("diff.txt");

            for (int i = 0; i < 10000; i++)
            {
                sw.Write(diff[i]);
                if (i != 9999)
                {
                    sw.Write(",");
                }
                sw.Flush();
            }

            sw.Close();
        }
    }
}
