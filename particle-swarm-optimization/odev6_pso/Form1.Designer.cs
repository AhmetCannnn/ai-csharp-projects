namespace odev6_pso
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numParticleCount = new System.Windows.Forms.NumericUpDown();
            this.numDimensions = new System.Windows.Forms.NumericUpDown();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.numC1 = new System.Windows.Forms.NumericUpDown();
            this.numC2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numW = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.cbFunctions = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParticleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimensions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numW)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.label7);
            this.groupBoxParams.Controls.Add(this.cbFunctions);
            this.groupBoxParams.Controls.Add(this.numW);
            this.groupBoxParams.Controls.Add(this.label6);
            this.groupBoxParams.Controls.Add(this.numC2);
            this.groupBoxParams.Controls.Add(this.numC1);
            this.groupBoxParams.Controls.Add(this.numIterations);
            this.groupBoxParams.Controls.Add(this.numDimensions);
            this.groupBoxParams.Controls.Add(this.numParticleCount);
            this.groupBoxParams.Controls.Add(this.label5);
            this.groupBoxParams.Controls.Add(this.label4);
            this.groupBoxParams.Controls.Add(this.label3);
            this.groupBoxParams.Controls.Add(this.label2);
            this.groupBoxParams.Controls.Add(this.label1);
            this.groupBoxParams.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(304, 245);
            this.groupBoxParams.TabIndex = 0;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "PSO Parametreleri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parçacık Sayısı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Boyut (Dim):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "İterasyon Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "c1 (Bilişsel Faktör):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "c2 (Sosyal Faktör):";
            // 
            // numParticleCount
            // 
            this.numParticleCount.Location = new System.Drawing.Point(170, 23);
            this.numParticleCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numParticleCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numParticleCount.Name = "numParticleCount";
            this.numParticleCount.Size = new System.Drawing.Size(120, 20);
            this.numParticleCount.TabIndex = 5;
            this.numParticleCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numDimensions
            // 
            this.numDimensions.Location = new System.Drawing.Point(170, 51);
            this.numDimensions.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDimensions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDimensions.Name = "numDimensions";
            this.numDimensions.Size = new System.Drawing.Size(120, 20);
            this.numDimensions.TabIndex = 6;
            this.numDimensions.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(170, 79);
            this.numIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIterations.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(120, 20);
            this.numIterations.TabIndex = 7;
            this.numIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numC1
            // 
            this.numC1.DecimalPlaces = 2;
            this.numC1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numC1.Location = new System.Drawing.Point(170, 107);
            this.numC1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numC1.Name = "numC1";
            this.numC1.Size = new System.Drawing.Size(120, 20);
            this.numC1.TabIndex = 8;
            this.numC1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numC2
            // 
            this.numC2.DecimalPlaces = 2;
            this.numC2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numC2.Location = new System.Drawing.Point(170, 135);
            this.numC2.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numC2.Name = "numC2";
            this.numC2.Size = new System.Drawing.Size(120, 20);
            this.numC2.TabIndex = 9;
            this.numC2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "w (Eylemsizlik Ağırlığı):";
            // 
            // numW
            // 
            this.numW.DecimalPlaces = 2;
            this.numW.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numW.Location = new System.Drawing.Point(170, 163);
            this.numW.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numW.Name = "numW";
            this.numW.Size = new System.Drawing.Size(120, 20);
            this.numW.TabIndex = 11;
            this.numW.Value = new decimal(new int[] {
            73,
            0,
            0,
            131072});
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStart.Location = new System.Drawing.Point(12, 263);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(304, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "PSO Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(322, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 400);
            this.panel1.TabIndex = 2;
            // 
            // rtbResults
            // 
            this.rtbResults.Location = new System.Drawing.Point(12, 303);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.Size = new System.Drawing.Size(304, 109);
            this.rtbResults.TabIndex = 3;
            this.rtbResults.Text = "";
            // 
            // cbFunctions
            // 
            this.cbFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunctions.FormattingEnabled = true;
            this.cbFunctions.Items.AddRange(new object[] {
            "Sphere Fonksiyonu",
            "Rosenbrock Fonksiyonu",
            "Griewank Fonksiyonu",
            "Rastrigin Fonksiyonu"});
            this.cbFunctions.Location = new System.Drawing.Point(170, 191);
            this.cbFunctions.Name = "cbFunctions";
            this.cbFunctions.Size = new System.Drawing.Size(120, 21);
            this.cbFunctions.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Test Fonksiyonu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 425);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxParams);
            this.Name = "Form1";
            this.Text = "PSO Algoritması";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParticleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimensions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numParticleCount;
        private System.Windows.Forms.NumericUpDown numDimensions;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.NumericUpDown numC1;
        private System.Windows.Forms.NumericUpDown numC2;
        private System.Windows.Forms.NumericUpDown numW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbResults;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFunctions;
    }
}

