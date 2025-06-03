namespace bulanik_mantik_odev
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackHassaslik = new System.Windows.Forms.TrackBar();
            this.numHassaslik = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.trackKirlilik = new System.Windows.Forms.TrackBar();
            this.numKirlilik = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.trackMiktar = new System.Windows.Forms.TrackBar();
            this.numMiktar = new System.Windows.Forms.NumericUpDown();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDonusHizi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDeterjan = new System.Windows.Forms.Label();
            this.rulesPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvKurallar = new System.Windows.Forms.DataGridView();
            this.colKural = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTetikleme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHassaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHassaslik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackKirlilik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKirlilik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).BeginInit();
            this.outputPanel.SuspendLayout();
            this.rulesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKurallar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.mainPanel.Controls.Add(this.inputPanel);
            this.mainPanel.Controls.Add(this.outputPanel);
            this.mainPanel.Controls.Add(this.rulesPanel);
            this.mainPanel.Controls.Add(this.chartPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(660, 510);
            this.mainPanel.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.BackColor = System.Drawing.Color.White;
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPanel.Controls.Add(this.btnHesapla);
            this.inputPanel.Controls.Add(this.label1);
            this.inputPanel.Controls.Add(this.trackHassaslik);
            this.inputPanel.Controls.Add(this.numHassaslik);
            this.inputPanel.Controls.Add(this.label2);
            this.inputPanel.Controls.Add(this.trackKirlilik);
            this.inputPanel.Controls.Add(this.numKirlilik);
            this.inputPanel.Controls.Add(this.label3);
            this.inputPanel.Controls.Add(this.trackMiktar);
            this.inputPanel.Controls.Add(this.numMiktar);
            this.inputPanel.Location = new System.Drawing.Point(20, 20);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Padding = new System.Windows.Forms.Padding(10);
            this.inputPanel.Size = new System.Drawing.Size(300, 250);
            this.inputPanel.TabIndex = 0;
            // 
            // btnHesapla
            // 
            this.btnHesapla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHesapla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHesapla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesapla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHesapla.ForeColor = System.Drawing.Color.White;
            this.btnHesapla.Location = new System.Drawing.Point(10, 10);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(270, 40);
            this.btnHesapla.TabIndex = 0;
            this.btnHesapla.Text = "HESAPLA";
            this.btnHesapla.UseVisualStyleBackColor = false;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hassaslık";
            // 
            // trackHassaslik
            // 
            this.trackHassaslik.Location = new System.Drawing.Point(10, 85);
            this.trackHassaslik.Maximum = 100;
            this.trackHassaslik.Name = "trackHassaslik";
            this.trackHassaslik.Size = new System.Drawing.Size(200, 56);
            this.trackHassaslik.TabIndex = 2;
            // 
            // numHassaslik
            // 
            this.numHassaslik.DecimalPlaces = 1;
            this.numHassaslik.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHassaslik.Location = new System.Drawing.Point(220, 85);
            this.numHassaslik.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHassaslik.Name = "numHassaslik";
            this.numHassaslik.Size = new System.Drawing.Size(60, 27);
            this.numHassaslik.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kirlilik";
            // 
            // trackKirlilik
            // 
            this.trackKirlilik.Location = new System.Drawing.Point(10, 155);
            this.trackKirlilik.Maximum = 100;
            this.trackKirlilik.Name = "trackKirlilik";
            this.trackKirlilik.Size = new System.Drawing.Size(200, 56);
            this.trackKirlilik.TabIndex = 5;
            // 
            // numKirlilik
            // 
            this.numKirlilik.DecimalPlaces = 1;
            this.numKirlilik.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numKirlilik.Location = new System.Drawing.Point(220, 155);
            this.numKirlilik.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numKirlilik.Name = "numKirlilik";
            this.numKirlilik.Size = new System.Drawing.Size(60, 27);
            this.numKirlilik.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label3.Location = new System.Drawing.Point(10, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Miktar";
            // 
            // trackMiktar
            // 
            this.trackMiktar.Location = new System.Drawing.Point(10, 225);
            this.trackMiktar.Maximum = 100;
            this.trackMiktar.Name = "trackMiktar";
            this.trackMiktar.Size = new System.Drawing.Size(200, 56);
            this.trackMiktar.TabIndex = 8;
            // 
            // numMiktar
            // 
            this.numMiktar.DecimalPlaces = 1;
            this.numMiktar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMiktar.Location = new System.Drawing.Point(220, 225);
            this.numMiktar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMiktar.Name = "numMiktar";
            this.numMiktar.Size = new System.Drawing.Size(60, 27);
            this.numMiktar.TabIndex = 9;
            // 
            // outputPanel
            // 
            this.outputPanel.BackColor = System.Drawing.Color.White;
            this.outputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputPanel.Controls.Add(this.label4);
            this.outputPanel.Controls.Add(this.lblDonusHizi);
            this.outputPanel.Controls.Add(this.label5);
            this.outputPanel.Controls.Add(this.lblSure);
            this.outputPanel.Controls.Add(this.label6);
            this.outputPanel.Controls.Add(this.lblDeterjan);
            this.outputPanel.Location = new System.Drawing.Point(340, 20);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Padding = new System.Windows.Forms.Padding(10);
            this.outputPanel.Size = new System.Drawing.Size(300, 100);
            this.outputPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dönüş Hızı:";
            // 
            // lblDonusHizi
            // 
            this.lblDonusHizi.AutoSize = true;
            this.lblDonusHizi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDonusHizi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblDonusHizi.Location = new System.Drawing.Point(100, 10);
            this.lblDonusHizi.Name = "lblDonusHizi";
            this.lblDonusHizi.Size = new System.Drawing.Size(18, 20);
            this.lblDonusHizi.TabIndex = 1;
            this.lblDonusHizi.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Süre:";
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblSure.Location = new System.Drawing.Point(100, 40);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(18, 20);
            this.lblSure.TabIndex = 3;
            this.lblSure.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.label6.Location = new System.Drawing.Point(10, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Deterjan:";
            // 
            // lblDeterjan
            // 
            this.lblDeterjan.AutoSize = true;
            this.lblDeterjan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDeterjan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblDeterjan.Location = new System.Drawing.Point(100, 70);
            this.lblDeterjan.Name = "lblDeterjan";
            this.lblDeterjan.Size = new System.Drawing.Size(18, 20);
            this.lblDeterjan.TabIndex = 5;
            this.lblDeterjan.Text = "0";
            // 
            // rulesPanel
            // 
            this.rulesPanel.BackColor = System.Drawing.Color.White;
            this.rulesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rulesPanel.Controls.Add(this.label7);
            this.rulesPanel.Controls.Add(this.dgvKurallar);
            this.rulesPanel.Location = new System.Drawing.Point(20, 290);
            this.rulesPanel.Name = "rulesPanel";
            this.rulesPanel.Padding = new System.Windows.Forms.Padding(10);
            this.rulesPanel.Size = new System.Drawing.Size(620, 200);
            this.rulesPanel.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tetiklenen Kurallar";
            // 
            // dgvKurallar
            // 
            this.dgvKurallar.BackgroundColor = System.Drawing.Color.White;
            this.dgvKurallar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKurallar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKurallar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKural,
            this.colTetikleme});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKurallar.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKurallar.Location = new System.Drawing.Point(10, 40);
            this.dgvKurallar.Name = "dgvKurallar";
            this.dgvKurallar.RowHeadersWidth = 51;
            this.dgvKurallar.Size = new System.Drawing.Size(600, 150);
            this.dgvKurallar.TabIndex = 1;
            // 
            // colKural
            // 
            this.colKural.MinimumWidth = 6;
            this.colKural.Name = "colKural";
            this.colKural.Width = 125;
            // 
            // colTetikleme
            // 
            this.colTetikleme.MinimumWidth = 6;
            this.colTetikleme.Name = "colTetikleme";
            this.colTetikleme.Width = 125;
            // 
            // chartPanel
            // 
            this.chartPanel.Location = new System.Drawing.Point(0, 0);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(200, 100);
            this.chartPanel.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 510);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulanık Çamaşır Makinesi Kontrol Sistemi";
            this.mainPanel.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHassaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHassaslik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackKirlilik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKirlilik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiktar)).EndInit();
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.rulesPanel.ResumeLayout(false);
            this.rulesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKurallar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Panel rulesPanel;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackHassaslik;
        private System.Windows.Forms.TrackBar trackKirlilik;
        private System.Windows.Forms.TrackBar trackMiktar;
        private System.Windows.Forms.NumericUpDown numHassaslik;
        private System.Windows.Forms.NumericUpDown numKirlilik;
        private System.Windows.Forms.NumericUpDown numMiktar;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Label lblDonusHizi;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label lblDeterjan;
        private System.Windows.Forms.DataGridView dgvKurallar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKural;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTetikleme;
    }
}

