using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace odev5_abc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Varsayılan değerleri ayarla
            textBoxFoodNumber.Text = "20";
            textBoxLimit.Text = "100";
            textBoxMaxCycle.Text = "1000";
            textBoxDimension.Text = "2";
            textBoxBoundsMin.Text = "-5,-5";
            textBoxBoundsMax.Text = "5,5";

            // Chart ayarları
            if (chartConvergence.ChartAreas.Count == 0)
            {
                chartConvergence.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());
                chartConvergence.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());
                chartConvergence.ChartAreas[0].AxisX.Title = "İterasyon";
                chartConvergence.ChartAreas[0].AxisY.Title = "En İyi Fitness";
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                int foodNumber = int.Parse(textBoxFoodNumber.Text);
                int limit = int.Parse(textBoxLimit.Text);
                int maxCycle = int.Parse(textBoxMaxCycle.Text);
                int dimension = int.Parse(textBoxDimension.Text);
                double[] boundsMin = Array.ConvertAll(textBoxBoundsMin.Text.Split(','), double.Parse);
                double[] boundsMax = Array.ConvertAll(textBoxBoundsMax.Text.Split(','), double.Parse);

                ABCAlgorithm abc = new ABCAlgorithm(foodNumber, limit, maxCycle, dimension, boundsMin, boundsMax);
                abc.Run();

                // Sonuçları göster
                listBoxBestSolution.Items.Clear();
                listBoxBestSolution.Items.Add($"Amaç Fonksiyonu: {abc.BestBee.Fitness}");
                for (int i = 0; i < abc.BestBee.Position.Length; i++)
                {
                    listBoxBestSolution.Items.Add($"x[{i}] = {abc.BestBee.Position[i]}");
                }

                // Yakınsama grafiği
                chartConvergence.Series.Clear();
                Series series = new Series("Yakınsama");
                series.ChartType = SeriesChartType.Line;
                for (int i = 0; i < abc.Convergence.Count; i++)
                {
                    series.Points.AddXY(i, abc.Convergence[i]);
                }
                chartConvergence.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
