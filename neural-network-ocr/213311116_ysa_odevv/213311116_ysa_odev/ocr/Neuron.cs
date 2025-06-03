using System;
using System.Collections.Generic;

namespace OCR
{
    /// <summary>
    /// Yapay sinir ağının temel yapıtaşı olan nöron sınıfı
    /// Her nöron, ağırlıklar ve bias değeri içerir
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// Nöronun giriş bağlantılarının ağırlıkları
        /// </summary>
        public List<double> Weights { get; private set; }
        
        /// <summary>
        /// Nöronun bias değeri (kaydırma terimi)
        /// </summary>
        public double Bias { get; private set; }
        
        /// <summary>
        /// Nöronun son hesaplanan çıktı değeri
        /// </summary>
        public double Output { get; private set; }
        
        /// <summary>
        /// Geri yayılım sırasında hesaplanan hata delta değeri
        /// </summary>
        public double Delta { get; set; }

        /// <summary>
        /// Nöron yapıcı metodu
        /// </summary>
        /// <param name="inputCount">Nörona bağlanan girdi sayısı</param>
        public Neuron(int inputCount)
        {
            Weights = new List<double>();
            Random random = new Random();
            
            // Ağırlıkları rastgele başlat (-1 ile 1 arasında)
            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(random.NextDouble() * 2 - 1);
            }
            
            // Bias'ı rastgele başlat (-1 ile 1 arasında)
            Bias = random.NextDouble() * 2 - 1;
        }

        /// <summary>
        /// Nöronun çıktısını hesaplar
        /// </summary>
        /// <param name="inputs">Nörona gelen girdi değerleri</param>
        /// <returns>Sigmoid fonksiyonu uygulanmış çıktı değeri</returns>
        public double CalculateOutput(List<double> inputs)
        {
            if (inputs.Count != Weights.Count)
                throw new ArgumentException("Girdi sayısı ağırlık sayısına eşit olmalıdır.");

            // Ağırlıklı toplam hesapla: z = Σ(w_i * x_i) + b
            double sum = Bias;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }

            // Sigmoid aktivasyon fonksiyonu: f(z) = 1 / (1 + e^(-z))
            Output = 1 / (1 + Math.Exp(-sum));
            return Output;
        }

        /// <summary>
        /// Geri yayılım algoritması ile ağırlıkları ve bias değerini günceller
        /// </summary>
        /// <param name="inputs">Nörona gelen girdi değerleri</param>
        /// <param name="learningRate">Öğrenme hızı</param>
        public void UpdateWeights(List<double> inputs, double learningRate)
        {
            // w_new = w_old + (learningRate * delta * input)
            for (int i = 0; i < Weights.Count; i++)
            {
                Weights[i] += learningRate * Delta * inputs[i];
            }
            
            // b_new = b_old + (learningRate * delta)
            Bias += learningRate * Delta;
        }
    }
} 