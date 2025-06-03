namespace odev2_genetik_algoritma
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.populasyon = new System.Windows.Forms.Label();
            this.trackCaprazlama = new System.Windows.Forms.TrackBar();
            this.caprazlama_oran = new System.Windows.Forms.Label();
            this.lbl_trcbar_caprazlama = new System.Windows.Forms.Label();
            this.trackMutasyon = new System.Windows.Forms.TrackBar();
            this.lbl_trcbar_mutasyon = new System.Windows.Forms.Label();
            this.mutasyon = new System.Windows.Forms.Label();
            this.seckinlik = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.jenerasyon = new System.Windows.Forms.Label();
            this.trackSeckinlik = new System.Windows.Forms.TrackBar();
            this.lbl_trcbar_seckinlik = new System.Windows.Forms.Label();
            this.baslangıc_populasyonu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fitness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dogal_secilim = new System.Windows.Forms.Button();
            this.caprazla = new System.Windows.Forms.Button();
            this.mutasyonla = new System.Windows.Forms.Button();
            this.genetik_algoritma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCaprazlama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMutasyon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSeckinlik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(207, 65);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // populasyon
            // 
            this.populasyon.AutoSize = true;
            this.populasyon.Location = new System.Drawing.Point(68, 65);
            this.populasyon.Name = "populasyon";
            this.populasyon.Size = new System.Drawing.Size(126, 16);
            this.populasyon.TabIndex = 1;
            this.populasyon.Text = "Popülasyon Boyutu:";
            // 
            // trackCaprazlama
            // 
            this.trackCaprazlama.Location = new System.Drawing.Point(207, 93);
            this.trackCaprazlama.Minimum = 1;
            this.trackCaprazlama.Name = "trackCaprazlama";
            this.trackCaprazlama.Size = new System.Drawing.Size(104, 56);
            this.trackCaprazlama.TabIndex = 2;
            this.trackCaprazlama.Value = 7;
            this.trackCaprazlama.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // caprazlama_oran
            // 
            this.caprazlama_oran.AutoSize = true;
            this.caprazlama_oran.Location = new System.Drawing.Point(74, 93);
            this.caprazlama_oran.Name = "caprazlama_oran";
            this.caprazlama_oran.Size = new System.Drawing.Size(118, 16);
            this.caprazlama_oran.TabIndex = 3;
            this.caprazlama_oran.Text = "Çaprazlama Oranı:";
            // 
            // lbl_trcbar_caprazlama
            // 
            this.lbl_trcbar_caprazlama.AutoSize = true;
            this.lbl_trcbar_caprazlama.Location = new System.Drawing.Point(242, 133);
            this.lbl_trcbar_caprazlama.Name = "lbl_trcbar_caprazlama";
            this.lbl_trcbar_caprazlama.Size = new System.Drawing.Size(24, 16);
            this.lbl_trcbar_caprazlama.TabIndex = 4;
            this.lbl_trcbar_caprazlama.Text = "0,7";
            // 
            // trackMutasyon
            // 
            this.trackMutasyon.Location = new System.Drawing.Point(207, 158);
            this.trackMutasyon.Minimum = 1;
            this.trackMutasyon.Name = "trackMutasyon";
            this.trackMutasyon.Size = new System.Drawing.Size(104, 56);
            this.trackMutasyon.TabIndex = 5;
            this.trackMutasyon.Value = 3;
            this.trackMutasyon.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // lbl_trcbar_mutasyon
            // 
            this.lbl_trcbar_mutasyon.AutoSize = true;
            this.lbl_trcbar_mutasyon.Location = new System.Drawing.Point(242, 198);
            this.lbl_trcbar_mutasyon.Name = "lbl_trcbar_mutasyon";
            this.lbl_trcbar_mutasyon.Size = new System.Drawing.Size(31, 16);
            this.lbl_trcbar_mutasyon.TabIndex = 6;
            this.lbl_trcbar_mutasyon.Text = "0,03";
            // 
            // mutasyon
            // 
            this.mutasyon.AutoSize = true;
            this.mutasyon.Location = new System.Drawing.Point(89, 158);
            this.mutasyon.Name = "mutasyon";
            this.mutasyon.Size = new System.Drawing.Size(103, 16);
            this.mutasyon.TabIndex = 7;
            this.mutasyon.Text = "Mutasyon Oranı:";
            this.mutasyon.Click += new System.EventHandler(this.label2_Click);
            // 
            // seckinlik
            // 
            this.seckinlik.AutoSize = true;
            this.seckinlik.Location = new System.Drawing.Point(85, 223);
            this.seckinlik.Name = "seckinlik";
            this.seckinlik.Size = new System.Drawing.Size(99, 16);
            this.seckinlik.TabIndex = 8;
            this.seckinlik.Text = "Seçkinlik Oranı:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(207, 300);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown3.TabIndex = 10;
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // jenerasyon
            // 
            this.jenerasyon.AutoSize = true;
            this.jenerasyon.Location = new System.Drawing.Point(74, 300);
            this.jenerasyon.Name = "jenerasyon";
            this.jenerasyon.Size = new System.Drawing.Size(116, 16);
            this.jenerasyon.TabIndex = 11;
            this.jenerasyon.Text = "Jenerasyon Oranı:";
            // 
            // trackSeckinlik
            // 
            this.trackSeckinlik.Location = new System.Drawing.Point(207, 223);
            this.trackSeckinlik.Maximum = 100;
            this.trackSeckinlik.Name = "trackSeckinlik";
            this.trackSeckinlik.Size = new System.Drawing.Size(104, 56);
            this.trackSeckinlik.TabIndex = 12;
            this.trackSeckinlik.TickFrequency = 5;
            this.trackSeckinlik.Scroll += new System.EventHandler(this.trackSeckinlik_Scroll);
            // 
            // lbl_trcbar_seckinlik
            // 
            this.lbl_trcbar_seckinlik.AutoSize = true;
            this.lbl_trcbar_seckinlik.Location = new System.Drawing.Point(242, 263);
            this.lbl_trcbar_seckinlik.Name = "lbl_trcbar_seckinlik";
            this.lbl_trcbar_seckinlik.Size = new System.Drawing.Size(31, 16);
            this.lbl_trcbar_seckinlik.TabIndex = 13;
            this.lbl_trcbar_seckinlik.Text = "0.20";
            // 
            // baslangıc_populasyonu
            // 
            this.baslangıc_populasyonu.Location = new System.Drawing.Point(416, 58);
            this.baslangıc_populasyonu.Name = "baslangıc_populasyonu";
            this.baslangıc_populasyonu.Size = new System.Drawing.Size(293, 44);
            this.baslangıc_populasyonu.TabIndex = 17;
            this.baslangıc_populasyonu.Text = "Başlangıç Populasyonunu Oluştur";
            this.baslangıc_populasyonu.UseVisualStyleBackColor = true;
            this.baslangıc_populasyonu.Click += new System.EventHandler(this.baslangıc_populasyonu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Fitness});
            this.dataGridView1.Location = new System.Drawing.Point(803, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(427, 292);
            this.dataGridView1.TabIndex = 18;
            // 
            // X
            // 
            this.X.HeaderText = "X Koordinatı";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.Width = 125;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y Koordinatı";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.Width = 125;
            // 
            // Fitness
            // 
            this.Fitness.HeaderText = "Fitness Değeri";
            this.Fitness.MinimumWidth = 6;
            this.Fitness.Name = "Fitness";
            this.Fitness.Width = 125;
            // 
            // dogal_secilim
            // 
            this.dogal_secilim.Location = new System.Drawing.Point(416, 108);
            this.dogal_secilim.Name = "dogal_secilim";
            this.dogal_secilim.Size = new System.Drawing.Size(293, 41);
            this.dogal_secilim.TabIndex = 19;
            this.dogal_secilim.Text = "Doğal Seçilim Uygula";
            this.dogal_secilim.UseVisualStyleBackColor = true;
            this.dogal_secilim.Click += new System.EventHandler(this.dogal_secilim_Click);
            // 
            // caprazla
            // 
            this.caprazla.Location = new System.Drawing.Point(416, 158);
            this.caprazla.Name = "caprazla";
            this.caprazla.Size = new System.Drawing.Size(293, 35);
            this.caprazla.TabIndex = 20;
            this.caprazla.Text = "Çaprazlama İşlemi Uygula";
            this.caprazla.UseVisualStyleBackColor = true;
            this.caprazla.Click += new System.EventHandler(this.caprazla_Click);
            // 
            // mutasyonla
            // 
            this.mutasyonla.Location = new System.Drawing.Point(416, 198);
            this.mutasyonla.Name = "mutasyonla";
            this.mutasyonla.Size = new System.Drawing.Size(293, 30);
            this.mutasyonla.TabIndex = 21;
            this.mutasyonla.Text = "Mutasyon İşlemi Uygula";
            this.mutasyonla.UseVisualStyleBackColor = true;
            this.mutasyonla.Click += new System.EventHandler(this.mutasyonla_Click);
            // 
            // genetik_algoritma
            // 
            this.genetik_algoritma.Location = new System.Drawing.Point(416, 234);
            this.genetik_algoritma.Name = "genetik_algoritma";
            this.genetik_algoritma.Size = new System.Drawing.Size(293, 34);
            this.genetik_algoritma.TabIndex = 22;
            this.genetik_algoritma.Text = "Genetik Algoritmayı Uygula";
            this.genetik_algoritma.UseVisualStyleBackColor = true;
            this.genetik_algoritma.Click += new System.EventHandler(this.genetik_algoritma_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 682);
            this.Controls.Add(this.genetik_algoritma);
            this.Controls.Add(this.mutasyonla);
            this.Controls.Add(this.caprazla);
            this.Controls.Add(this.dogal_secilim);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.baslangıc_populasyonu);
            this.Controls.Add(this.lbl_trcbar_seckinlik);
            this.Controls.Add(this.trackSeckinlik);
            this.Controls.Add(this.jenerasyon);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.seckinlik);
            this.Controls.Add(this.mutasyon);
            this.Controls.Add(this.lbl_trcbar_mutasyon);
            this.Controls.Add(this.trackMutasyon);
            this.Controls.Add(this.lbl_trcbar_caprazlama);
            this.Controls.Add(this.caprazlama_oran);
            this.Controls.Add(this.trackCaprazlama);
            this.Controls.Add(this.populasyon);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCaprazlama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMutasyon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSeckinlik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label populasyon;
        private System.Windows.Forms.TrackBar trackCaprazlama;
        private System.Windows.Forms.Label caprazlama_oran;
        private System.Windows.Forms.Label lbl_trcbar_caprazlama;
        private System.Windows.Forms.TrackBar trackMutasyon;
        private System.Windows.Forms.Label lbl_trcbar_mutasyon;
        private System.Windows.Forms.Label mutasyon;
        private System.Windows.Forms.Label seckinlik;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label jenerasyon;
        private System.Windows.Forms.TrackBar trackSeckinlik;
        private System.Windows.Forms.Label lbl_trcbar_seckinlik;
        private System.Windows.Forms.Button baslangıc_populasyonu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fitness;
        private System.Windows.Forms.Button dogal_secilim;
        private System.Windows.Forms.Button caprazla;
        private System.Windows.Forms.Button mutasyonla;
        private System.Windows.Forms.Button genetik_algoritma;
    }
}

