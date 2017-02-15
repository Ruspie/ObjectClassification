using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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
                DrawCoordinateSystem(graphics, -10);
                pictureBox.Image = bitmap;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try {
                Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                double firstPc = double.Parse(numericUpDownFirstPC.Text);
                double secondPc = double.Parse(numericUpDownSecondPC.Text);

                List<double> firstResultList = new List<double>();
                List<double> secondResultList = new List<double>();
                int delimiter;

                ObjectClassificator.ObjectClassification(firstPc, secondPc, pictureBox.Width, 300, firstResultList, secondResultList, out delimiter);

                double falseAlarmProbability = ObjectClassificator.GetFalseAlarmProbability(firstResultList,
                    secondResultList, delimiter);
                double missingDetectionProbability = ObjectClassificator.GetMissingDetectionProbability(firstPc,
                    secondPc, firstResultList, secondResultList, delimiter);

                textBoxFalseAlarmProbability.Text =
                    Math.Round(falseAlarmProbability, 3).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityMissingDetection.Text =
                    Math.Round(missingDetectionProbability, 3).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityOfTotalClassificationError.Text =
                    Math.Round(falseAlarmProbability + missingDetectionProbability, 3)
                        .ToString(CultureInfo.CurrentCulture);
                DrawGraph(graphics, pictureBox.Width, firstResultList, secondResultList, 300);
                DrawCoordinateSystem(graphics, delimiter);
                pictureBox.Image = bitmap;
                graphics.Dispose();
                
            }
            catch (Exception) {
                MessageBox.Show(Resources.Form_buttonRun_Click_Something_went_wrong_,
                    Resources.Form_buttonRun_Click_Error_, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(Graphics graphics, int pictureWidth, List<double> firstResultList, List<double> secondResultList, int coefficient)
        {
            for (int i = 1; i < pictureWidth; i++) {
                graphics.DrawLine(new Pen(Color.Blue),
                    new Point(i - 1, (pictureBox.Height - (int) (firstResultList[i - 1] * pictureBox.Height * coefficient))),
                    new Point(i, (pictureBox.Height - (int) (firstResultList[i] * pictureBox.Height * coefficient))));
                graphics.DrawLine(new Pen(Color.Red),
                    new Point(i - 1, (pictureBox.Height - (int) (secondResultList[i - 1] * pictureBox.Height * coefficient))),
                    new Point(i, (pictureBox.Height - (int) (secondResultList[i] * pictureBox.Height * coefficient))));
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

        private void DrawCoordinateSystem(Graphics graphics, int delimiter)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black)) {
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(delimiter, 0),
                    new Point(delimiter, pictureBox.Height));
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
            public static double GetFalseAlarmProbability(List<double> firstResultList, List<double> secondResultList,
                int delimiter)
            {
                return secondResultList.Take(delimiter).Sum();
            }

            public static double GetMissingDetectionProbability(double firstPc, double secondPc,
                List<double> firstResultList,
                List<double> secondResultList, int delimiter)
            {
                return firstPc > secondPc
                    ? secondResultList.Skip(delimiter).Sum()
                    : firstResultList.Skip(delimiter).Sum();
            }

            private static void InitializePoints(IList<int> firstPoints, IList<int> secondPoints)
            {
                Random random = new Random((int) DateTime.Now.Ticks);
                for (int i = 0; i < PointsCount; i++) {
                    firstPoints.Add(random.Next(100, 550));
                    secondPoints.Add(random.Next(0, 450));
                }
            }

            private static void GetMu(IReadOnlyList<int> firstPoints, IReadOnlyList<int> secondPoints,
                out double firstMu, out double secondMu)
            {
                firstMu = 0;
                secondMu = 0;
                for (int i = 0; i < PointsCount; i++) {
                    firstMu += firstPoints[i];
                    secondMu += secondPoints[i];
                }
                firstMu /= PointsCount;
                secondMu /= PointsCount;
            }

            private static void GetSigma(IReadOnlyList<int> firstPoints, IReadOnlyList<int> secondPoints,
                out double firstSigma, out double secondSigma, double firstMu, double secondMu)
            {
                firstSigma = 0;
                secondSigma = 0;
                for (int i = 0; i < PointsCount; i++) {
                    firstSigma += Math.Pow(firstPoints[i] - firstMu, 2);
                    secondSigma += Math.Pow(secondPoints[i] - secondMu, 2);
                }
                firstSigma = Math.Sqrt(firstSigma / PointsCount);
                secondSigma = Math.Sqrt(secondSigma / PointsCount);
            }

            public static void ObjectClassification(double firstPc, double secondPc, int pictureWidth, int coefficient,
                List<double> firstResultList, List<double> secondResultList, out int delimiter)
            {
                List<int> firstPoints = new List<int>();
                List<int> secondPoints = new List<int>();
                double firstMu, secondMu;

                InitializePoints(firstPoints, secondPoints);
                GetMu(firstPoints, secondPoints, out firstMu, out secondMu);

                double firstSigma, secondSigma;
                GetSigma(firstPoints, secondPoints, out firstSigma, out secondSigma, firstMu, secondMu);

                firstResultList.Clear();
                secondResultList.Clear();
                delimiter = 0;
                for (int x = 0; x < pictureWidth; x++) {
                    firstResultList.Add(Math.Exp(-0.5 * Math.Pow((x - Offset - firstMu) / firstSigma, 2)) /
                                    (firstSigma * Math.Sqrt(2 * Math.PI)) * firstPc);
                    secondResultList.Add(Math.Exp(-0.5 * Math.Pow((x - Offset - secondMu) / secondSigma, 2)) /
                                     (secondSigma * Math.Sqrt(2 * Math.PI)) * secondPc);

                    if (Math.Abs(firstResultList[x] * coefficient - secondResultList[x] * coefficient) < 0.002) {
                        delimiter = x;
                    }
                }
            }
        }
    }
}
