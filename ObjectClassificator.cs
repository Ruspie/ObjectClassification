using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public static class ObjectClassificator
    {
        
        public static double GetFalseAlarmProbability(IEnumerable<double> secondResultList, int delimiter)
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
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < Constants.PointsCount; i++)
            {
                firstPoints.Add(random.Next(100, 550));
                secondPoints.Add(random.Next(0, 450));
            }
        }

        private static void GetMu(IReadOnlyList<int> firstPoints, IReadOnlyList<int> secondPoints,
            out double firstMu, out double secondMu)
        {
            firstMu = 0;
            secondMu = 0;
            for (int i = 0; i < Constants.PointsCount; i++)
            {
                firstMu += firstPoints[i];
                secondMu += secondPoints[i];
            }
            firstMu /= Constants.PointsCount;
            secondMu /= Constants.PointsCount;
        }

        private static void GetSigma(IReadOnlyList<int> firstPoints, IReadOnlyList<int> secondPoints,
            out double firstSigma, out double secondSigma, double firstMu, double secondMu)
        {
            firstSigma = 0;
            secondSigma = 0;
            for (int i = 0; i < Constants.PointsCount; i++)
            {
                firstSigma += Math.Pow(firstPoints[i] - firstMu, 2);
                secondSigma += Math.Pow(secondPoints[i] - secondMu, 2);
            }
            firstSigma = Math.Sqrt(firstSigma / Constants.PointsCount);
            secondSigma = Math.Sqrt(secondSigma / Constants.PointsCount);
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
            for (int x = 0; x < pictureWidth; x++)
            {
                firstResultList.Add(Math.Exp(-0.5 * Math.Pow((x - Constants.Offset - firstMu) / firstSigma, 2)) /
                                (firstSigma * Math.Sqrt(2 * Math.PI)) * firstPc);
                secondResultList.Add(Math.Exp(-0.5 * Math.Pow((x - Constants.Offset - secondMu) / secondSigma, 2)) /
                                 (secondSigma * Math.Sqrt(2 * Math.PI)) * secondPc);

                if (Math.Abs(firstResultList[x] * coefficient - secondResultList[x] * coefficient) < 0.002)
                {
                    delimiter = x;
                }
            }
        }
    }
}
