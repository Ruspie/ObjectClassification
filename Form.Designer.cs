namespace Test
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSettings = new System.Windows.Forms.Panel();
            this.buttonRun = new System.Windows.Forms.Button();
            this.labelSecondPC = new System.Windows.Forms.Label();
            this.labelFirstPC = new System.Windows.Forms.Label();
            this.labelFalseAlarmProbability = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.Panel();
            this.labelProbabilityOfTotalClassificationError = new System.Windows.Forms.Label();
            this.textBoxProbabilityOfTotalClassificationError = new System.Windows.Forms.TextBox();
            this.labelProbabilityMissingDetection = new System.Windows.Forms.Label();
            this.textBoxProbabilityMissingDetection = new System.Windows.Forms.TextBox();
            this.textBoxFalseAlarmProbability = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDownFirstPC = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSecondPC = new System.Windows.Forms.NumericUpDown();
            this.panelSettings.SuspendLayout();
            this.panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondPC)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.numericUpDownSecondPC);
            this.panelSettings.Controls.Add(this.numericUpDownFirstPC);
            this.panelSettings.Controls.Add(this.buttonRun);
            this.panelSettings.Controls.Add(this.labelSecondPC);
            this.panelSettings.Controls.Add(this.labelFirstPC);
            this.panelSettings.Location = new System.Drawing.Point(12, 12);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(778, 31);
            this.panelSettings.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(371, 3);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // labelSecondPC
            // 
            this.labelSecondPC.AutoSize = true;
            this.labelSecondPC.Location = new System.Drawing.Point(178, 8);
            this.labelSecondPC.Name = "labelSecondPC";
            this.labelSecondPC.Size = new System.Drawing.Size(61, 13);
            this.labelSecondPC.TabIndex = 2;
            this.labelSecondPC.Text = "Second PC";
            // 
            // labelFirstPC
            // 
            this.labelFirstPC.AutoSize = true;
            this.labelFirstPC.Location = new System.Drawing.Point(3, 8);
            this.labelFirstPC.Name = "labelFirstPC";
            this.labelFirstPC.Size = new System.Drawing.Size(43, 13);
            this.labelFirstPC.TabIndex = 0;
            this.labelFirstPC.Text = "First PC";
            // 
            // labelFalseAlarmProbability
            // 
            this.labelFalseAlarmProbability.AutoSize = true;
            this.labelFalseAlarmProbability.Location = new System.Drawing.Point(3, 9);
            this.labelFalseAlarmProbability.Name = "labelFalseAlarmProbability";
            this.labelFalseAlarmProbability.Size = new System.Drawing.Size(110, 13);
            this.labelFalseAlarmProbability.TabIndex = 2;
            this.labelFalseAlarmProbability.Text = "False alarm probability";
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.labelProbabilityOfTotalClassificationError);
            this.panelResult.Controls.Add(this.textBoxProbabilityOfTotalClassificationError);
            this.panelResult.Controls.Add(this.labelProbabilityMissingDetection);
            this.panelResult.Controls.Add(this.textBoxProbabilityMissingDetection);
            this.panelResult.Controls.Add(this.labelFalseAlarmProbability);
            this.panelResult.Controls.Add(this.textBoxFalseAlarmProbability);
            this.panelResult.Location = new System.Drawing.Point(12, 498);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(778, 33);
            this.panelResult.TabIndex = 2;
            // 
            // labelProbabilityOfTotalClassificationError
            // 
            this.labelProbabilityOfTotalClassificationError.AutoSize = true;
            this.labelProbabilityOfTotalClassificationError.Location = new System.Drawing.Point(488, 9);
            this.labelProbabilityOfTotalClassificationError.Name = "labelProbabilityOfTotalClassificationError";
            this.labelProbabilityOfTotalClassificationError.Size = new System.Drawing.Size(177, 13);
            this.labelProbabilityOfTotalClassificationError.TabIndex = 6;
            this.labelProbabilityOfTotalClassificationError.Text = "Probability of total classification error";
            // 
            // textBoxProbabilityOfTotalClassificationError
            // 
            this.textBoxProbabilityOfTotalClassificationError.Location = new System.Drawing.Point(671, 6);
            this.textBoxProbabilityOfTotalClassificationError.Name = "textBoxProbabilityOfTotalClassificationError";
            this.textBoxProbabilityOfTotalClassificationError.Size = new System.Drawing.Size(100, 20);
            this.textBoxProbabilityOfTotalClassificationError.TabIndex = 5;
            // 
            // labelProbabilityMissingDetection
            // 
            this.labelProbabilityMissingDetection.AutoSize = true;
            this.labelProbabilityMissingDetection.Location = new System.Drawing.Point(225, 9);
            this.labelProbabilityMissingDetection.Name = "labelProbabilityMissingDetection";
            this.labelProbabilityMissingDetection.Size = new System.Drawing.Size(151, 13);
            this.labelProbabilityMissingDetection.TabIndex = 4;
            this.labelProbabilityMissingDetection.Text = "Probability of missing detection";
            // 
            // textBoxProbabilityMissingDetection
            // 
            this.textBoxProbabilityMissingDetection.Location = new System.Drawing.Point(382, 6);
            this.textBoxProbabilityMissingDetection.Name = "textBoxProbabilityMissingDetection";
            this.textBoxProbabilityMissingDetection.Size = new System.Drawing.Size(100, 20);
            this.textBoxProbabilityMissingDetection.TabIndex = 3;
            // 
            // textBoxFalseAlarmProbability
            // 
            this.textBoxFalseAlarmProbability.Location = new System.Drawing.Point(119, 6);
            this.textBoxFalseAlarmProbability.Name = "textBoxFalseAlarmProbability";
            this.textBoxFalseAlarmProbability.Size = new System.Drawing.Size(100, 20);
            this.textBoxFalseAlarmProbability.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(778, 443);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // numericUpDownFirstPC
            // 
            this.numericUpDownFirstPC.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericUpDownFirstPC.DecimalPlaces = 2;
            this.numericUpDownFirstPC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownFirstPC.Location = new System.Drawing.Point(52, 6);
            this.numericUpDownFirstPC.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFirstPC.Name = "numericUpDownFirstPC";
            this.numericUpDownFirstPC.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFirstPC.TabIndex = 5;
            this.numericUpDownFirstPC.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.numericUpDownFirstPC.ValueChanged += new System.EventHandler(this.numericUpDownFirstPC_ValueChanged);
            // 
            // numericUpDownSecondPC
            // 
            this.numericUpDownSecondPC.DecimalPlaces = 2;
            this.numericUpDownSecondPC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownSecondPC.Location = new System.Drawing.Point(245, 6);
            this.numericUpDownSecondPC.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSecondPC.Name = "numericUpDownSecondPC";
            this.numericUpDownSecondPC.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSecondPC.TabIndex = 6;
            this.numericUpDownSecondPC.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.numericUpDownSecondPC.ValueChanged += new System.EventHandler(this.numericUpDownSecondPC_ValueChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 537);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelSettings);
            this.Name = "Form";
            this.Text = "Lab3 Alex Begun 451001";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondPC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelSecondPC;
        private System.Windows.Forms.Label labelFirstPC;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelFalseAlarmProbability;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label labelProbabilityMissingDetection;
        private System.Windows.Forms.TextBox textBoxProbabilityMissingDetection;
        private System.Windows.Forms.TextBox textBoxFalseAlarmProbability;
        private System.Windows.Forms.Label labelProbabilityOfTotalClassificationError;
        private System.Windows.Forms.TextBox textBoxProbabilityOfTotalClassificationError;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDownSecondPC;
        private System.Windows.Forms.NumericUpDown numericUpDownFirstPC;
    }
}

