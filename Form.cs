using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Test.Properties;

namespace Test
{
    public partial class Form : System.Windows.Forms.Form
    { 
        public Form()
        {
            InitializeComponent();

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap)) {
                Drawer.DrawCoordinateSystem(graphics, DefaultFont, -10, pictureBox.Width, pictureBox.Height);
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

                double falseAlarmProbability = ObjectClassificator.GetFalseAlarmProbability(secondResultList, delimiter);
                double missingDetectionProbability = ObjectClassificator.GetMissingDetectionProbability(firstPc,
                    secondPc, firstResultList, secondResultList, delimiter);

                textBoxFalseAlarmProbability.Text =
                    Math.Round(falseAlarmProbability, 3).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityMissingDetection.Text =
                    Math.Round(missingDetectionProbability, 3).ToString(CultureInfo.CurrentCulture);
                textBoxProbabilityOfTotalClassificationError.Text =
                    Math.Round(falseAlarmProbability + missingDetectionProbability, 3)
                        .ToString(CultureInfo.CurrentCulture);

                Drawer.DrawGraph(graphics, firstResultList, secondResultList, 300, pictureBox.Width, pictureBox.Height);
                Drawer.DrawCoordinateSystem(graphics, DefaultFont, delimiter, pictureBox.Width, pictureBox.Height);

                pictureBox.Image = bitmap;
                graphics.Dispose();
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

        
    }
}
