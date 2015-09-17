using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentialModel
{
    public class LogDiffMod
    {
        public int x = 0;

        public double[] Probabilities { get; set; }

        public double Weight { get; set; }

        public double[] Denominator { get; set; }

        public double[,] N { get; set; }

        public double[,] C { get; set; }    // The value for transition on cancer when differential occurs

        public double[] Pi { get; set; }    // Initial probability of methy to unmethy

        public double[] PiC { get; set; }   

        public double[,] D { get; set; }

        public int States { get; set; }

        public int Symbols { get; set; }

        public int[] Mark { get; set; }

        public int T { get; set; }

        public double[,] Gamma { get; set; }

        public LogDiffMod(int[][] reads)
        {
            States = 2;
            Symbols = 4;
            Weight = 0.3;
            T = reads[0].Length;

            #region Transition, InitB, B, Probabilities Init

            Pi = new double[2];
            Pi[0] = 0.00000001;
            Pi[1] = 0.99999999;

            PiC = new double[2];
            PiC[0] = 0.1;
            PiC[1] = 0.9;

            N = new double[States, States];
            N[0, 0] = 0.7593;
            N[0, 1] = 0.2406;
            N[1, 0] = 0.0554;
            N[1, 1] = 0.9446;

            C = new double[States, States];
            C[0, 0] = 0.8;
            C[0, 1] = 0.2;
            C[1, 0] = 0.2;
            C[1, 1] = 0.8;

            D = new double[States, States];
            for (int i = 0; i < States; i++)
            {
                for (int j = 0; j < States; j++)
                {
                    if (i == j)
                    {
                        D[i, j] = 0.65;
                    }
                    else
                    {
                        D[i, j] = 0.35 / (States - 1);
                    }
                }
            }

            Probabilities = new double[States];
            Probabilities[0] = 0.9;
            for (int i = 1; i < States; i++)
            {
                Probabilities[i] = 0.1 / (States - 1);
            }

            Mark = new int[T];
            for (int i = 0; i < T; i++)
            {
                Mark[i] = 0;
            }

            #endregion
        }

        public double Learn(int[] observations, int iterations, double tolerance)
        {
            if (iterations == 0 && tolerance == 0)
            {
                throw new ArgumentException("Iterations and limit cannot be both zero.");
            }

            this.T = observations.Length;
            int currentIteration = 1;
            bool stop = false;

            int[] mark = new int[T];

            // 1. Initialization
            double[, ,] epsilon = new double[T, States, States];
            double[,] gamma = new double[T, States];

            double oldLikelihood = Double.MinValue;
            double newLikelihood = 0;

            do // Until convergence or max iterations is reached
            {
                // For each sequence in the observations input
                double[] scaling;

                // 1st step - Calculating the forward probability and the
                //            backward probability for each HMM state.
                double[,] fwd = forward(observations, out scaling);
                double[,] bwd = backward(observations, scaling);

                // Calculate gamma values for next computations
                for (int t = 0; t < T; t++)
                {
                    double s = 0;

                    for (int k = 0; k < States; k++)
                        s += gamma[t, k] = fwd[t, k] * bwd[t, k];

                    if (s != 0) // Scaling for computing
                    {
                        for (int k = 0; k < States; k++)
                            gamma[t, k] /= s;
                    }
                }

                // Calculate epsilon values for next computations
                for (int t = 0; t < T - 1; t++)
                {
                    double s = 0;

                    for (int k = 0; k < States; k++)
                    {
                        for (int l = 0; l < States; l++)
                        {
                            if (l == 0) // There is no difference
                            {
                                s += epsilon[t, k, l]
                                    = fwd[t, k] * D[k, l] * bwd[t + 1, l] *
                                N[observations[t] % 2, observations[t + 1] % 2] *
                                N[observations[t] / 2, observations[t + 1] / 2];
                            }
                            else    // If D is 1 means differential, cancer should use its own transition
                            {   
                                s += epsilon[t, k, l]
                                    = fwd[t, k] * D[k, l] * bwd[t + 1, l] *
                                N[observations[t] % 2, observations[t + 1] % 2] *
                                C[observations[t] / 2, observations[t + 1] / 2];
                            }
                        }
                    }
                    // scaling
                    if (s != 0)
                    {
                        for (int k = 0; k < States; k++)
                        {
                            for (int l = 0; l < States; l++)
                            {
                                epsilon[t, k, l] /= s;
                            }
                        }
                    }
                }

                // Compute log-likelihood for the given sequence
                for (int t = 0; t < scaling.Length; t++)
                    newLikelihood += Math.Log(scaling[t]);
                if (CheckConvergence(oldLikelihood, newLikelihood,
                    currentIteration, iterations, tolerance))
                {
                    stop = true;
                }
                else
                {
                    // 3. Continue with parameter re-estimation
                    currentIteration++;
                    oldLikelihood = newLikelihood;
                    newLikelihood = 0.0;

                    // 3.1 Re-estimation of initial state probabilities
                    for (int k = 0; k < States; k++)
                    {
                        Probabilities[k] = gamma[0, k];
                    }

                    // 3.2 Re-estimation of transition probabilities 
                    for (int i = 0; i < States; i++)
                    {
                        for (int j = 0; j < States; j++)
                        {
                            double den = 0, num = 0;

                            for (int l = 0; l < T - 1; l++)
                                num += epsilon[l, i, j];
                            for (int l = 0; l < T - 1; l++)
                                den += gamma[l, i];

                            D[i, j] = (den != 0) ? num / den : 0.0;
                        }
                    }

                    // 3.3 Re-estimation of C[i, j]
                    int[,] count = new int[States, States];
                    for (int t = 1; t < T; t++)
                    {
                        if (gamma[t, 0] < gamma[t, 1])
                        {
                            count[observations[t - 1] / 2, observations[t] / 2]++;
                        }
                    }

                    C[0, 0] = count[0, 0] * 1.0 / (count[0, 0] + count[0, 1]);
                    C[0, 1] = count[0, 1] * 1.0 / (count[0, 0] + count[0, 1]);
                    C[1, 0] = count[1, 0] * 1.0 / (count[1, 0] + count[1, 1]);
                    C[1, 1] = count[1, 1] * 1.0 / (count[1, 0] + count[1, 1]);
                }

                for (int t = 1; t < T; t++)
                {
                    if (gamma[t, 0] > gamma[t, 1])
                    {
                        Mark[t] = 0;
                    }
                    else
                    {
                        Mark[t] = 1;
                    }
                }

                x++;
                if (x == 2)
                { };

            } while (stop == false);

            for (int i = 0; i < 1; i++)
            {
                mark = MarkState(gamma);
            }

            this.Mark = mark;
            this.Gamma = gamma;

            return newLikelihood;
        }

        private int[] MarkState(double[,] gamma)
        {
            // Get the length of the sequence
            int len = gamma.GetLength(0);

            int[] mark = new int[len];

            // Store the mark of sequence using max likelihood
            for (int i = 0; i < len; i++)
            {
                mark[i] = 0;
                for (int j = 0; j < States - 1; j++)
                {
                    if (gamma[i, mark[i]] < gamma[i, j + 1])
                    {
                        mark[i] = j + 1;
                    }
                }
            }

            return mark;
        }

        private bool CheckConvergence(double oldLikelihood,
            double newLikelihood, int currentIteration, int maxIterations, double tolerance)
        {
            if (tolerance > 0)
            {
                if (Math.Abs(oldLikelihood - newLikelihood) <= tolerance)
                    return true;

                if (maxIterations > 0)
                {
                    if (currentIteration >= maxIterations)
                        return true;
                }
            }
            else
            {
                if (currentIteration == maxIterations)
                    return true;
            }

            if (Double.IsNaN(newLikelihood) || Double.IsInfinity(newLikelihood))
            {
                return true;
            }

            return false;
        }

        private double[,] backward(int[] observations, double[] c)
        {
            int T = observations.Length;
            double[] pi = Probabilities;

            double[,] bwd = new double[T, States];

            // 1. Initialization
            for (int i = 0; i < States; i++)
            {
                bwd[T - 1, i] = 1.0 / c[T - 1];
            }

            // 2. Induction
            for (int t = T - 2; t >= 0; t--)
            {
                for (int i = 0; i < States; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < States; j++)
                    {
                        if (i == 0)
                        {
                            sum += D[i, j] * (N[observations[t] / 2, observations[t + 1] / 2]
                            * N[observations[t] % 2, observations[t + 1] % 2]) * bwd[t + 1, j];
                        }
                        else
                        {
                            sum += D[i, j] * (C[observations[t] / 2, observations[t + 1] / 2]
                            * N[observations[t] % 2, observations[t + 1] % 2]) * bwd[t + 1, j];
                        }
                    }
                    bwd[t, i] += sum / c[t];
                }
            }
            return bwd;
        }

        private double[,] forward(int[] observations, out double[] c)
        {
            int T = observations.Length;
            double[] pi = Probabilities;

            double[,] fwd = new double[T, States];
            c = new double[T];

            // 1. Initialization
            for (int i = 0; i < States; i++)
            {
                fwd[0, i] = pi[i];
                if (i == 0)
                {
                    fwd[0, i] *= Pi[observations[0] % 2] * Pi[observations[0] / 2];
                }
                else
                {
                    fwd[0, i] *= Pi[observations[0] % 2] * PiC[observations[0] / 2];
                }
                c[0] += fwd[0, i];
            }
            // scaling
            if (c[0] != 0)
            {
                for (int i = 0; i < States; i++)
                {
                    fwd[0, i] = fwd[0, i] / c[0];
                }
            }

            // 2. Induction
            for (int t = 1; t < T; t++)
            {
                for (int i = 0; i < States; i++)
                {
                    double p = 0;
                    if (i == 0)
                    {
                        p = N[observations[t - 1] / 2, observations[t] / 2]
                        * N[observations[t - 1] % 2, observations[t] % 2];
                    }
                    else
                    {
                        p = C[observations[t - 1] / 2, observations[t] / 2]
                        * N[observations[t - 1] % 2, observations[t] % 2];
                    }

                    double sum = 0.0;
                    for (int j = 0; j < States; j++)
                    {
                        sum += fwd[t - 1, j] * D[j, i];
                    }
                    fwd[t, i] = sum * p;

                    c[t] += fwd[t, i];
                }

                if (c[t] != 0)
                {
                    for (int i = 0; i < States; i++)
                    {
                        fwd[t, i] = fwd[t, i] / c[t];
                    }
                }
            }

            return fwd;
        }

        public int[] convertState(int[][] reads)
        {
            int len = reads[0].Length;
            int[] states = new int[len];
            for (int i = 0; i < len; i++)
            {
                int tmp = 0;
                for (int j = 0; j < reads.Length; j++)
                {
                    tmp += (int)(reads[j][i] * Math.Pow(2, j));
                }
                states[i] = tmp;
            }
            return states;
        }
    }
}
