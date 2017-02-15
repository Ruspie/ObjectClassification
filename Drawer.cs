using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    public static class Drawer
    {
        public static void DrawCoordinateSystem(Graphics graphics, Font font, int delimiter, int pictureWidth, int pictureHeight)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(delimiter, 0),
                    new Point(delimiter, pictureHeight));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, pictureHeight - 1),
                    new Point(pictureWidth, pictureHeight - 1));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Constants.Offset, 0),
                    new Point(Constants.Offset, pictureHeight - 1));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Constants.Offset - 5, 15),
                    new Point(Constants.Offset, 0));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(Constants.Offset + 5, 15),
                    new Point(Constants.Offset, 0));
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(pictureWidth - 15, pictureHeight - 6),
                    new Point(pictureWidth, pictureHeight - 1));
                graphics.DrawLine(new Pen(Color.Blue, 3), new Point(pictureWidth - 150, 15),
                    new Point(pictureWidth - 100, 15));
                graphics.DrawLine(new Pen(Color.Red, 3), new Point(pictureWidth - 150, 30),
                    new Point(pictureWidth - 100, 30));
                graphics.DrawString("p(X / C1) P(C1)", font, brush,
                    pictureWidth - 90, 5);
                graphics.DrawString("p(X / C2) P(C2)", font, brush,
                    pictureWidth - 90, 25);
            }
        }

        public static void DrawGraph(Graphics graphics, List<double> firstResultList, List<double> secondResultList, int coefficient, int pictureWidth, int pictureHeight)
        {
            for (int i = 1; i < pictureWidth; i++)
            {
                graphics.DrawLine(new Pen(Color.Blue),
                    new Point(i - 1, (pictureHeight - (int)(firstResultList[i - 1] * pictureHeight * coefficient))),
                    new Point(i, (pictureHeight - (int)(firstResultList[i] * pictureHeight * coefficient))));
                graphics.DrawLine(new Pen(Color.Red),
                    new Point(i - 1, (pictureHeight - (int)(secondResultList[i - 1] * pictureHeight * coefficient))),
                    new Point(i, (pictureHeight - (int)(secondResultList[i] * pictureHeight * coefficient))));
            }
        }
    }
}
