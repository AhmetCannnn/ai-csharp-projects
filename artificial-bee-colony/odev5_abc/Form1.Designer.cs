namespace odev5_abc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelFoodNumber;
        private System.Windows.Forms.TextBox textBoxFoodNumber;
        private System.Windows.Forms.Label labelLimit;
        private System.Windows.Forms.TextBox textBoxLimit;
        private System.Windows.Forms.Label labelMaxCycle;
        private System.Windows.Forms.TextBox textBoxMaxCycle;
        private System.Windows.Forms.Label labelDimension;
        private System.Windows.Forms.TextBox textBoxDimension;
        private System.Windows.Forms.Label labelBoundsMin;
        private System.Windows.Forms.TextBox textBoxBoundsMin;
        private System.Windows.Forms.Label labelBoundsMax;
        private System.Windows.Forms.TextBox textBoxBoundsMax;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConvergence;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ListBox listBoxBestSolution;

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
            this.labelFoodNumber = new System.Windows.Forms.Label();
            this.textBoxFoodNumber = new System.Windows.Forms.TextBox();
            this.labelLimit = new System.Windows.Forms.Label();
            this.textBoxLimit = new System.Windows.Forms.TextBox();
            this.labelMaxCycle = new System.Windows.Forms.Label();
            this.textBoxMaxCycle = new System.Windows.Forms.TextBox();
            this.labelDimension = new System.Windows.Forms.Label();
            this.textBoxDimension = new System.Windows.Forms.TextBox();
            this.labelBoundsMin = new System.Windows.Forms.Label();
            this.textBoxBoundsMin = new System.Windows.Forms.TextBox();
            this.labelBoundsMax = new System.Windows.Forms.Label();
            this.textBoxBoundsMax = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.chartConvergence = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelResult = new System.Windows.Forms.Label();
            this.listBoxBestSolution = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartConvergence)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFoodNumber
            // 
            this.labelFoodNumber.AutoSize = true;
            this.labelFoodNumber.Location = new System.Drawing.Point(20, 20);
            this.labelFoodNumber.Name = "labelFoodNumber";
            this.labelFoodNumber.Size = new System.Drawing.Size(120, 13);
            this.labelFoodNumber.Text = "Food Number (Arı Sayısı):";
            // 
            // textBoxFoodNumber
            // 
            this.textBoxFoodNumber.Location = new System.Drawing.Point(160, 17);
            this.textBoxFoodNumber.Name = "textBoxFoodNumber";
            this.textBoxFoodNumber.Size = new System.Drawing.Size(100, 20);
            // 
            // labelLimit
            // 
            this.labelLimit.AutoSize = true;
            this.labelLimit.Location = new System.Drawing.Point(20, 50);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(34, 13);
            this.labelLimit.Text = "Limit:";
            // 
            // textBoxLimit
            // 
            this.textBoxLimit.Location = new System.Drawing.Point(160, 47);
            this.textBoxLimit.Name = "textBoxLimit";
            this.textBoxLimit.Size = new System.Drawing.Size(100, 20);
            // 
            // labelMaxCycle
            // 
            this.labelMaxCycle.AutoSize = true;
            this.labelMaxCycle.Location = new System.Drawing.Point(20, 80);
            this.labelMaxCycle.Name = "labelMaxCycle";
            this.labelMaxCycle.Size = new System.Drawing.Size(61, 13);
            this.labelMaxCycle.Text = "Max Cycle:";
            // 
            // textBoxMaxCycle
            // 
            this.textBoxMaxCycle.Location = new System.Drawing.Point(160, 77);
            this.textBoxMaxCycle.Name = "textBoxMaxCycle";
            this.textBoxMaxCycle.Size = new System.Drawing.Size(100, 20);
            // 
            // labelDimension
            // 
            this.labelDimension.AutoSize = true;
            this.labelDimension.Location = new System.Drawing.Point(20, 110);
            this.labelDimension.Name = "labelDimension";
            this.labelDimension.Size = new System.Drawing.Size(59, 13);
            this.labelDimension.Text = "Dimension:";
            // 
            // textBoxDimension
            // 
            this.textBoxDimension.Location = new System.Drawing.Point(160, 107);
            this.textBoxDimension.Name = "textBoxDimension";
            this.textBoxDimension.Size = new System.Drawing.Size(100, 20);
            // 
            // labelBoundsMin
            // 
            this.labelBoundsMin.AutoSize = true;
            this.labelBoundsMin.Location = new System.Drawing.Point(20, 140);
            this.labelBoundsMin.Name = "labelBoundsMin";
            this.labelBoundsMin.Size = new System.Drawing.Size(110, 13);
            this.labelBoundsMin.Text = "Alt Sınır (virgülle):";
            // 
            // textBoxBoundsMin
            // 
            this.textBoxBoundsMin.Location = new System.Drawing.Point(160, 137);
            this.textBoxBoundsMin.Name = "textBoxBoundsMin";
            this.textBoxBoundsMin.Size = new System.Drawing.Size(100, 20);
            // 
            // labelBoundsMax
            // 
            this.labelBoundsMax.AutoSize = true;
            this.labelBoundsMax.Location = new System.Drawing.Point(20, 170);
            this.labelBoundsMax.Name = "labelBoundsMax";
            this.labelBoundsMax.Size = new System.Drawing.Size(113, 13);
            this.labelBoundsMax.Text = "Üst Sınır (virgülle):";
            // 
            // textBoxBoundsMax
            // 
            this.textBoxBoundsMax.Location = new System.Drawing.Point(160, 167);
            this.textBoxBoundsMax.Name = "textBoxBoundsMax";
            this.textBoxBoundsMax.Size = new System.Drawing.Size(100, 20);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(160, 200);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(100, 30);
            this.buttonRun.Text = "Başlat";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // chartConvergence
            // 
            this.chartConvergence.Location = new System.Drawing.Point(300, 17);
            this.chartConvergence.Name = "chartConvergence";
            this.chartConvergence.Size = new System.Drawing.Size(450, 250);
            this.chartConvergence.TabIndex = 0;
            this.chartConvergence.Text = "Yakınsama Grafiği";
            this.chartConvergence.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title("Yakınsama Grafiği"));
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(20, 250);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(80, 13);
            this.labelResult.Text = "En İyi Sonuç:";
            // 
            // listBoxBestSolution
            // 
            this.listBoxBestSolution.Location = new System.Drawing.Point(20, 270);
            this.listBoxBestSolution.Name = "listBoxBestSolution";
            this.listBoxBestSolution.Size = new System.Drawing.Size(240, 95);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.labelFoodNumber);
            this.Controls.Add(this.textBoxFoodNumber);
            this.Controls.Add(this.labelLimit);
            this.Controls.Add(this.textBoxLimit);
            this.Controls.Add(this.labelMaxCycle);
            this.Controls.Add(this.textBoxMaxCycle);
            this.Controls.Add(this.labelDimension);
            this.Controls.Add(this.textBoxDimension);
            this.Controls.Add(this.labelBoundsMin);
            this.Controls.Add(this.textBoxBoundsMin);
            this.Controls.Add(this.labelBoundsMax);
            this.Controls.Add(this.textBoxBoundsMax);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.chartConvergence);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.listBoxBestSolution);
            this.Text = "ABC Algoritması - Yapay Arı Kolonisi";
            ((System.ComponentModel.ISupportInitialize)(this.chartConvergence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

