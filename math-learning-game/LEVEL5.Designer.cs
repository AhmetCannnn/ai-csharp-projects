namespace homework1
{
    partial class LEVEL5
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(235, 366);
            button1.Name = "button1";
            button1.Size = new Size(314, 29);
            button1.TabIndex = 0;
            button1.Text = "BAŞLAMAK İÇİN TIKLAYINIZ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(138, 46);
            label1.Name = "label1";
            label1.Size = new Size(559, 52);
            label1.TabIndex = 1;
            label1.Text = "5.SEVİYEYE HOŞGELDİNİZ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(50, 192);
            label2.Name = "label2";
            label2.Size = new Size(717, 31);
            label2.TabIndex = 2;
            label2.Text = "Bu seviye 5 basamaklı sayılarla 4 işlem sorularından oluşmaktadır.";
            // 
            // LEVEL5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LEVEL5";
            Text = "LEVEL5";
            Load += LEVEL5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
    }
}