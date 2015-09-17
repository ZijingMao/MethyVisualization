using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DifferentialModel
{
    public class FileHelper
    {
        public static string FileName { get; set; }

        public static void WriteFile(int[] mark)
        {
            StreamWriter sw = new StreamWriter(FileName + ".txt");

            for (int i = 0; i < mark.Length; i++)
            {
                sw.Write(mark[i]);
                if (i != mark.Length-1)
                {
                    sw.Write(",");
                }
                sw.Flush();
            }

            sw.Close();
        }

        public static int[][] ReadFile()
        {
            FileName = DiffMod.FileName;
            if (FileName == null)
            {
                MessageBox.Show("No file found.");
                return null;
            }

            int lineNumber = File.ReadAllLines(FileName).Length;

            string line;
            int length = 0, i = 0;

            int[][] binArray = new int[lineNumber][];
            StreamReader sr = new StreamReader(FileName, System.Text.Encoding.Default);

            while ((line = sr.ReadLine()) != null)
            {
                string[] tmp = line.Split(',');
                length = tmp.Length;
                int g = 0;
                binArray[i] = new int[length];

                for (g = 0; g < tmp.Length; g++)
                {
                    binArray[i][g] = Convert.ToInt32(tmp[g]);
                }

                i++;
            }

            sr.Close();
            return binArray;
        }
    }
}
