using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Test.Properties;

namespace Test
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const int PointsCount = 10000;
        private const int Offset = 100;
        public Form()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap)) {
                DrawGraph(graphics, -10);
                pictureBox.Image = bitmap;
            }
           
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try {
                double firstPc = double.Parse(numericUpDownFirstPC.Text);
                double secondPc = double.Parse(numericUpDownSecondPC.Text);
                ObjectClassification(firstPc, secondPc);
            }
            catch (Exception) {
                MessageBox.Show(Resources.Form_buttonRun_Click_Something_went_wrong_,
                    Resources.Form_buttonRun_Click_Error_, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        
        

        private void numericUpDownSecondPC_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownFirstPC.Value = numericUpDownFirstPC.Maximum - numericUpDownSecondPC.Value;
        }

        private void numericUpDownFirstPC_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownSecondPC.Value = numericUpDownSecondPC.Maximum - numericUpDownFirstPC.Value;
        }

        private void DrawGraph(Graphics graphics, int delimiter)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(delimiter, 0), new Point(delimiter, pictureBox.Height));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, pictureBox.Height - 1),
                    new Point(pictureBox.Width, pictureBox.Height - 1));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Offset, 0),
                    new Point(Offset, pictureBox.Height - 1));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Offset - 5, 15),
                    new Point(Offset, 0));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Offset + 5, 15),
                    new Point(Offset, 0));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(pictureBox.Width - 15, pictureBox.Height - 6),
                    new Point(pictureBox.Width, pictureBox.Height - 1));
                graphics.DrawLine(new Pen(Color.Blue, 3), new Point(pictureBox.Width - 150, 15),
                    new Point(pictureBox.Width - 100, 15));
                graphics.DrawLine(new Pen(Color.Red, 3), new Point(pictureBox.Width - 150, 30),
                    new Point(pictureBox.Width - 100, 30));
                graphics.DrawString("p(X / C1) P(C1)", DefaultFont, brush,
                    pictureBox.Width - 90, 5);
                graphics.DrawString("p(X / C2) P(C2)", DefaultFont, brush,
                    pictureBox.Width - 90, 25);
            }
        }

        private static class ObjectClassificator
        {
            private static void InitializePoints(IList<int> firstPoints, IList<int> secondPoints)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < PointsCount; i++)
                {
                    firstPoints[i] = random.Next(100, 550);
                    secondPoints[i] = random.Next(0, 450);
                }
            }

            private static void GetMu(IReadOnlyList<int> firstPoints, IReadOnlyList<int> secondPoints, out double firstMu, out double secondMu)
            {
                firstMu = 0;
                secondMu = 0;
                for (int i = 0; i < PointsCount; i++)
                {
                    firstMu += firstPoints[i];
                    secondMu += secondPoints[i];
                }
                firstMu /= PointsCount;
                secondMu /= PointsCount;
            }

            private static void GetSigma(int[] firstPoints, int[] secondPoints, out double firstSigma, out double secondSigma, double firstMu, double secondMu)
            {
                firstSigma = 0;
                secondSigma = 0;
                for (int i = 0; i < PointsCount; i++)
                {
                    firstSigma += Math.Pow(firstPoints[i] - firstMu, 2);
                    secondSigma += Math.Pow(secondPoints[i] - secondMu, 2);
                }
                firstSigma = Math.Sqrt(firstSigma / PointsCount);
                secondSigma = Math.Sqrt(secondSigma / PointsCount);
            }

            private void ObjectClassification(double firstPc, double secondPc)
            {
                Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics graphics = Graphics.FromImage(bitmap);

                int[] firstPoints = new int[PointsCount];
                int[] secondPoints = new int[PointsCount];
                double firstMu, secondMu;

                InitializePoints(firstPoints, secondPoints);
                GetMu(firstPoints, secondPoints, out firstMu, out secondMu);

                double firstSigma, secondSigma;
                GetSigma(firstPoints, secondPoints, out firstSigma, out secondSigma, firstMu, secondMu);

                double[] firstResult = new double[pictureBox.Width];
                double[] secondResult = new double[pictureBox.Width];
                int delimiter = 0;

                for (int x = 0; x < pictureBox.Width; x++)
                {
                    firstResult[x] = Math.Exp(-0.5 * Math.Pow((x - Offset - firstMu) / firstSigma, 2)) /
                                     (firstSigma * Math.Sqrt(2 * Math.PI)) * firstPc;
                    secondResult[x] = Math.Exp(-0.5 * Math.Pow((x - Offset - secondMu) / secondSigma, 2)) /
                                      (secondSigma * Math.Sqrt(2 * Math.PI)) * secondPc;

                    if (Math.Abs(firstResult[x] * 300 - secondResult[x] * 300) < 0.002)
                    {
                        delimiter = x;
                    }
                    if (x != 0)
                    {
                        graphics.DrawLine(new Pen(Color.Blue),
                            new Point(x - 1, (pictureBox.Height - (int)(firstResult[x - 1] * pictureBox.Height * 300))),
                            new Point(x, (pictureBox.Height - (int)(firstResult[x] * pictureBox.Height * 300))));
                        graphics.DrawLine(new Pen(Color.Red),
                            new Point(x - 1, (pictureBox.Height - (int)(secondResult[x - 1] * pictureBox.Height * 300))),
                            new Point(x, (pictureBox.Height - (int)(secondResult[x] * pictureBox.Height * 300))));
                    }
                }
                double falseAlarmProbability = secondResult.Take(delimiter).Sum();
                var missingDetectionProbability = firstPc > secondPc ? secondResult.Skip(delimiter).Sum() : firstResult.Skip(delimiter).Sum();

                DrawGraph(graphics, delimiter);

                pictureBox.Image = bitmap;
                textBoxFalseAlarmProbability.Text = Math.Round(falseAlarmProbability, 8).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityMissingDetection.Text = Math.Round(missingDetectionProbability, 8).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityOfTotalClassificationError.Text = Math.Round(falseAlarmProbability + missingDetectionProbability, 8).ToString(CultureInfo.CurrentCulture);
                graphics.Dispose();
            }
        }
    }
}
