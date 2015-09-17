using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentialSimulator
{
    public class Simulator
    {
        public int[,] Reads { get; set; }

        public double[] Probabilities { get; set; }

        public double[] Denominator { get; set; }

        public double[,] N { get; set; }

        public double[] Pi { get; set; }    // Initial probability of methy to unmethy

        public double[,] D { get; set; }

        public double[,] C { get; set; }

        public int States { get; set; }

        public int Symbols { get; set; }

        public int[] Mark { get; set; }

        public int T { get; set; }

        public int[] diff = new int[10000];

        public Random ran = new Random();

        public Simulator()
        {
            States = 2;
            Symbols = 4;

            Pi = new double[2];
            Pi[0] = 0.1;
            Pi[1] = 0.9;

            N = new double[States, States];
            N[0, 0] = 0.7217;
            N[0, 1] = 0.2783;
            N[1, 0] = 0.0917;
            N[1, 1] = 0.9083;

            C = new double[States, States];
            C[0, 0] = 0.1017;
            C[0, 1] = 0.8983;
            C[1, 0] = 0.8817;
            C[1, 1] = 0.1183;

            D = new double[States, States];

            D[0, 0] = 0.88;
            D[0, 1] = 0.11;
            D[1, 0] = 0.37;
            D[1, 1] = 0.63;

            Probabilities = new double[States];
            Probabilities[0] = 0.1;
            for (int i = 1; i < States; i++)
            {
                Probabilities[i] = 0.9 / (States - 1);
            }

            Mark = new int[T];
            for (int i = 0; i < T; i++)
            {
                Mark[i] = 0;
            }
        }

        public int[,] Gen()
        {
            double RandKey = 0.0;

            int[,] reads = new int[2, 10000];

            // Generate differential line
            RandKey = ran.NextDouble();
            if (RandKey < Pi[1])
            {
                diff[0] = 0;    // non differential
            }
            else
            {
                diff[0] = 1;
            }
            for (int i = 1; i < 10000; i++)
            {
                RandKey = ran.NextDouble();

                if (diff[i - 1] == 1)
                {
                    if (RandKey < D[1, 1])
                    {
                        diff[i] = diff[i - 1];
                    }
                    else
                    {
                        diff[i] = (diff[i - 1] + 1) % 2;
                    }
                }
                else
                {
                    if (RandKey < D[0, 0])
                    {
                        diff[i] = diff[i - 1];
                    }
                    else
                    {
                        diff[i] = (diff[i - 1] + 1) % 2;
                    }
                }
            }

            // Generate normal line
            RandKey = ran.NextDouble();
            if (RandKey < Pi[1])
            {
                reads[0, 0] = 1;
            }
            else
            {
                reads[0, 0] = 0;
            }
            for (int i = 1; i < 10000; i++)
            {
                RandKey = ran.NextDouble();

                if (reads[0, i - 1] == 1)
                {
                    if (RandKey < N[1, 1])
                    {
                        reads[0, i] = reads[0, i - 1];
                    }
                    else
                    {
                        reads[0, i] = (reads[0, i - 1] + 1) % 2;
                    }
                }
                else
                {
                    if (RandKey < N[0, 0])
                    {
                        reads[0, i] = reads[0, i - 1];
                    }
                    else
                    {
                        reads[0, i] = (reads[0, i - 1] + 1) % 2;
                    }
                }
            }

            // Generate Cancer line
            // if diff = 0, use transition N; else use transition C
            RandKey = ran.NextDouble();
            if (diff[0] == 0)
            {
                reads[1, 0] = reads[0, 0];
            }
            else
            {
                if (RandKey < Pi[1])
                {
                    reads[1, 0] = 1;
                }
                else
                {
                    reads[1, 0] = 0;
                }
            }

            for (int i = 1; i < 10000; i++)
            {
                RandKey = ran.NextDouble();
                if (diff[i] == 0)
                {
                    reads[1, i] = reads[0, i];
                }
                else
                {
                    if (reads[1, i - 1] == 1)
                    {
                        if (RandKey < C[1, 1])
                        {
                            reads[1, i] = reads[1, i - 1];
                        }
                        else
                        {
                            reads[1, i] = (reads[1, i - 1] + 1) % 2;
                        }
                    }
                    else
                    {
                        if (RandKey < C[0, 0])
                        {
                            reads[1, i] = reads[1, i - 1];
                        }
                        else
                        {
                            reads[1, i] = (reads[1, i - 1] + 1) % 2;
                        }
                    }
                }
            }

            return reads;
        }
    }
}
