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

namespace odev6_pso
{
    public partial class Form1 : Form
    {
        private Chart convergenceChart;
        private PSO pso;
        private List<double> iterations = new List<double>();
        private List<double> bestFitness = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ComboBox başlangıç değeri ayarla
            cbFunctions.SelectedIndex = 0;

            // Grafiği oluştur
            CreateChart();
        }

        private void CreateChart()
        {
            // Chart nesnesi oluştur
            convergenceChart = new Chart();
            convergenceChart.Parent = panel1;
            convergenceChart.Dock = DockStyle.Fill;

            // Chart alanı oluştur
            ChartArea chartArea = new ChartArea("Convergence");
            chartArea.AxisX.Title = "İterasyon";
            chartArea.AxisY.Title = "En iyi uygunluk değeri";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BorderColor = Color.LightGray;
            convergenceChart.ChartAreas.Add(chartArea);

            // Veri serisi oluştur
            Series series = new Series("Best Fitness");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Blue;
            convergenceChart.Series.Add(series);

            // Lejant oluştur
            Legend legend = new Legend("Legend");
            convergenceChart.Legends.Add(legend);
            convergenceChart.Titles.Add(new Title("PSO Yakınsama Grafiği", Docking.Top, new Font("Arial", 12, FontStyle.Bold), Color.Black));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Parametreleri al
                int particleCount = (int)numParticleCount.Value;
                int dimensions = (int)numDimensions.Value;
                int maxIterations = (int)numIterations.Value;
                double c1 = (double)numC1.Value;
                double c2 = (double)numC2.Value;
                double w = (double)numW.Value;

                // Seçilen fonksiyonu belirle
                FitnessFunction fitnessFunction = null;
                string functionName = "";
                double[] lowerBounds = null;
                double[] upperBounds = null;

                switch (cbFunctions.SelectedIndex)
                {
                    case 0: // Sphere
                        fitnessFunction = TestFunctions.Sphere;
                        functionName = "Sphere";
                        lowerBounds = Enumerable.Repeat(-100.0, dimensions).ToArray();
                        upperBounds = Enumerable.Repeat(100.0, dimensions).ToArray();
                        break;
                    case 1: // Rosenbrock
                        fitnessFunction = TestFunctions.Rosenbrock;
                        functionName = "Rosenbrock";
                        lowerBounds = Enumerable.Repeat(-30.0, dimensions).ToArray();
                        upperBounds = Enumerable.Repeat(30.0, dimensions).ToArray();
                        break;
                    case 2: // Griewank
                        fitnessFunction = TestFunctions.Griewank;
                        functionName = "Griewank";
                        lowerBounds = Enumerable.Repeat(-600.0, dimensions).ToArray();
                        upperBounds = Enumerable.Repeat(600.0, dimensions).ToArray();
                        break;
                    case 3: // Rastrigin
                        fitnessFunction = TestFunctions.Rastrigin;
                        functionName = "Rastrigin";
                        lowerBounds = Enumerable.Repeat(-5.12, dimensions).ToArray();
                        upperBounds = Enumerable.Repeat(5.12, dimensions).ToArray();
                        break;
                }

                // PSO algoritmasını başlat
                pso = new PSO(particleCount, dimensions, maxIterations, c1, c2, w, fitnessFunction, lowerBounds, upperBounds);
                pso.OnIterationCompleted += Pso_OnIterationCompleted;

                // Verileri temizle
                iterations.Clear();
                bestFitness.Clear();
                convergenceChart.Series[0].Points.Clear();
                rtbResults.Clear();

                // PSO çalıştır
                Particle bestParticle = pso.Run();

                // Sonuçları göster
                rtbResults.AppendText($"Fonksiyon: {functionName}\n");
                rtbResults.AppendText($"En iyi uygunluk değeri: {bestParticle.BestFitness:F6}\n");
                rtbResults.AppendText("En iyi konum (x): ");
                for (int i = 0; i < bestParticle.BestPosition.Length; i++)
                {
                    rtbResults.AppendText($"{bestParticle.BestPosition[i]:F6}");
                    if (i < bestParticle.BestPosition.Length - 1)
                        rtbResults.AppendText(", ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pso_OnIterationCompleted(object sender, IterationEventArgs e)
        {
            // Grafiği güncelle
            iterations.Add(e.Iteration);
            bestFitness.Add(e.BestFitness);

            // UI thread'inde grafik güncelleme
            if (convergenceChart.InvokeRequired)
            {
                convergenceChart.Invoke(new Action(() => UpdateChart(e.Iteration, e.BestFitness)));
            }
            else
            {
                UpdateChart(e.Iteration, e.BestFitness);
            }
        }

        private void UpdateChart(int iteration, double fitness)
        {
            convergenceChart.Series[0].Points.AddXY(iteration, fitness);
            convergenceChart.Update();
        }
    }

    // Test fonksiyonları
    public static class TestFunctions
    {
        // Sphere fonksiyonu
        public static double Sphere(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i];
            }
            return sum;
        }

        // Rosenbrock fonksiyonu
        public static double Rosenbrock(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                sum += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + Math.Pow(x[i] - 1, 2);
            }
            return sum;
        }

        // Griewank fonksiyonu
        public static double Griewank(double[] x)
        {
            double sum = 0;
            double product = 1;

            for (int i = 0; i < x.Length; i++)
            {
                sum += (x[i] * x[i]) / 4000.0;
                product *= Math.Cos(x[i] / Math.Sqrt(i + 1));
            }

            return sum - product + 1;
        }

        // Rastrigin fonksiyonu
        public static double Rastrigin(double[] x)
        {
            double sum = 10 * x.Length;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i] - 10 * Math.Cos(2 * Math.PI * x[i]);
            }
            return sum;
        }
    }

    // Uygunluk fonksiyonu delegesi
    public delegate double FitnessFunction(double[] position);

    // İterasyon tamamlandığında tetiklenecek olay için argümanlar
    public class IterationEventArgs : EventArgs
    {
        public int Iteration { get; }
        public double BestFitness { get; }

        public IterationEventArgs(int iteration, double bestFitness)
        {
            Iteration = iteration;
            BestFitness = bestFitness;
        }
    }

    // Parçacık sınıfı
    public class Particle
    {
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }
        public double[] BestPosition { get; set; }
        public double Fitness { get; set; }
        public double BestFitness { get; set; }

        private readonly Random random = new Random();
        private readonly double[] lowerBounds;
        private readonly double[] upperBounds;

        public Particle(int dimensions, double[] lowerBounds, double[] upperBounds)
        {
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;

            Position = new double[dimensions];
            Velocity = new double[dimensions];
            BestPosition = new double[dimensions];

            // Rastgele başlangıç pozisyonu ve hızı ata
            for (int i = 0; i < dimensions; i++)
            {
                Position[i] = lowerBounds[i] + random.NextDouble() * (upperBounds[i] - lowerBounds[i]);
                Velocity[i] = (random.NextDouble() * 2 - 1) * (upperBounds[i] - lowerBounds[i]) * 0.1; // -0.1 ile 0.1 arasında kısıtlanmış hız
                BestPosition[i] = Position[i];
            }

            Fitness = double.MaxValue;
            BestFitness = double.MaxValue;
        }

        public void UpdateVelocity(double w, double c1, double c2, double[] globalBestPosition)
        {
            for (int i = 0; i < Velocity.Length; i++)
            {
                double r1 = random.NextDouble();
                double r2 = random.NextDouble();

                // Hız güncellemesi PSO formülü
                Velocity[i] = w * Velocity[i] +
                              c1 * r1 * (BestPosition[i] - Position[i]) +
                              c2 * r2 * (globalBestPosition[i] - Position[i]);

                // Hız sınırlandırma
                double maxVelocity = (upperBounds[i] - lowerBounds[i]) * 0.1;
                if (Velocity[i] > maxVelocity) Velocity[i] = maxVelocity;
                if (Velocity[i] < -maxVelocity) Velocity[i] = -maxVelocity;
            }
        }

        public void UpdatePosition()
        {
            for (int i = 0; i < Position.Length; i++)
            {
                Position[i] += Velocity[i];

                // Konum sınırlarını kontrol et
                if (Position[i] < lowerBounds[i]) Position[i] = lowerBounds[i];
                if (Position[i] > upperBounds[i]) Position[i] = upperBounds[i];
            }
        }

        public void UpdateFitness(FitnessFunction fitnessFunction)
        {
            Fitness = fitnessFunction(Position);

            // Kişisel en iyi pozisyonu güncelle
            if (Fitness < BestFitness)
            {
                BestFitness = Fitness;
                Array.Copy(Position, BestPosition, Position.Length);
            }
        }
    }

    // PSO Algoritması
    public class PSO
    {
        private readonly int particleCount;
        private readonly int dimensions;
        private readonly int maxIterations;
        private readonly double c1;
        private readonly double c2;
        private readonly double w;
        private readonly FitnessFunction fitnessFunction;
        private readonly double[] lowerBounds;
        private readonly double[] upperBounds;

        private Particle[] particles;
        private Particle globalBestParticle;

        // İterasyon tamamlandı olayı
        public event EventHandler<IterationEventArgs> OnIterationCompleted;

        public PSO(int particleCount, int dimensions, int maxIterations, double c1, double c2, double w,
            FitnessFunction fitnessFunction, double[] lowerBounds, double[] upperBounds)
        {
            this.particleCount = particleCount;
            this.dimensions = dimensions;
            this.maxIterations = maxIterations;
            this.c1 = c1;
            this.c2 = c2;
            this.w = w;
            this.fitnessFunction = fitnessFunction;
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;
        }

        public Particle Run()
        {
            // Parçacıkları başlat
            InitializeParticles();

            // Algoritma döngüsü
            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                // Tüm parçacıkları güncelle
                foreach (var particle in particles)
                {
                    // Parçacık hızını güncelle
                    particle.UpdateVelocity(w, c1, c2, globalBestParticle.BestPosition);

                    // Parçacık konumunu güncelle
                    particle.UpdatePosition();

                    // Parçacık uygunluğunu güncelle
                    particle.UpdateFitness(fitnessFunction);

                    // Küresel en iyi parçacığı güncelle
                    if (particle.BestFitness < globalBestParticle.BestFitness)
                    {
                        globalBestParticle = particle;
                    }
                }

                // İterasyon tamamlandı olayını tetikle
                OnIterationCompleted?.Invoke(this, new IterationEventArgs(iteration, globalBestParticle.BestFitness));
            }

            return globalBestParticle;
        }

        private void InitializeParticles()
        {
            particles = new Particle[particleCount];

            // Parçacıkları oluştur
            for (int i = 0; i < particleCount; i++)
            {
                particles[i] = new Particle(dimensions, lowerBounds, upperBounds);
                particles[i].UpdateFitness(fitnessFunction);
            }

            // Küresel en iyi parçacığı belirle
            globalBestParticle = particles[0];
            for (int i = 1; i < particleCount; i++)
            {
                if (particles[i].Fitness < globalBestParticle.Fitness)
                {
                    globalBestParticle = particles[i];
                }
            }
        }
    }
}
