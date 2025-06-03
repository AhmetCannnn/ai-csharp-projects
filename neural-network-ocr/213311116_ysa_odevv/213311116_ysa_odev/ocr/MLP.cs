using System;
using System.Collections.Generic;
using System.Linq;

namespace OCR
{
    /// <summary>
    /// Çok Katmanlı Algılayıcı (Multi-Layer Perceptron) sınıfı
    /// Yapay sinir ağı yapısını ve algoritmaları içerir
    /// </summary>
    public class MLP
    {
        private List<List<Neuron>> layers; // Sinir ağı katmanları
        private double learningRate;       // Öğrenme hızı

        /// <summary>
        /// MLP yapıcı metodu
        /// </summary>
        /// <param name="inputSize">Giriş katmanı nöron sayısı</param>
        /// <param name="hiddenSize">Gizli katman nöron sayısı</param>
        /// <param name="outputSize">Çıkış katmanı nöron sayısı</param>
        /// <param name="learningRate">Öğrenme hızı (varsayılan: 0.1)</param>
        public MLP(int inputSize, int hiddenSize, int outputSize, double learningRate = 0.1)
        {
            this.learningRate = learningRate;
            layers = new List<List<Neuron>>();

            // İlk gizli katmanı oluştur
            var hiddenLayer = new List<Neuron>();
            for (int i = 0; i < hiddenSize; i++)
            {
                hiddenLayer.Add(new Neuron(inputSize));
            }
            layers.Add(hiddenLayer);

            // İkinci gizli katmanı oluştur
            var hiddenLayer2 = new List<Neuron>();
            for (int i = 0; i < hiddenSize; i++)
            {
                hiddenLayer2.Add(new Neuron(hiddenSize));
            }
            layers.Add(hiddenLayer2);

            // Çıkış katmanını oluştur
            var outputLayer = new List<Neuron>();
            for (int i = 0; i < outputSize; i++)
            {
                outputLayer.Add(new Neuron(hiddenSize));
            }
            layers.Add(outputLayer);
        }

        /// <summary>
        /// İleri yayılım algoritması - girdileri sinir ağından geçirerek çıktıları hesaplar
        /// </summary>
        /// <param name="inputs">Girdi değerleri listesi</param>
        /// <returns>Çıkış katmanının ürettiği değerler</returns>
        public List<double> Forward(List<double> inputs)
        {
            List<double> currentInputs = inputs;

            // Her katman için ileri yayılım işlemi
            foreach (var layer in layers)
            {
                List<double> layerOutputs = new List<double>();
                foreach (var neuron in layer)
                {
                    layerOutputs.Add(neuron.CalculateOutput(currentInputs));
                }
                currentInputs = layerOutputs; // Bir sonraki katmanın girdisi olarak çıktıları kullan
            }

            return currentInputs; // Son katmanın çıktıları
        }

        /// <summary>
        /// Geri yayılım algoritması - sinir ağını eğitmek için kullanılır
        /// </summary>
        /// <param name="inputs">Girdi değerleri</param>
        /// <param name="targets">Beklenen çıktı değerleri</param>
        public void Train(List<double> inputs, List<double> targets)
        {
            // İleri yayılım - tüm nöronların çıktılarını hesapla
            List<List<double>> layerOutputs = new List<List<double>>();
            List<double> currentInputs = inputs;

            foreach (var layer in layers)
            {
                List<double> outputs = new List<double>();
                foreach (var neuron in layer)
                {
                    outputs.Add(neuron.CalculateOutput(currentInputs));
                }
                layerOutputs.Add(outputs);
                currentInputs = outputs;
            }

            // Geri yayılım - hataları hesapla ve ağırlıkları güncelle
            for (int layerIndex = layers.Count - 1; layerIndex >= 0; layerIndex--)
            {
                var layer = layers[layerIndex];
                var outputs = layerOutputs[layerIndex];

                for (int neuronIndex = 0; neuronIndex < layer.Count; neuronIndex++)
                {
                    var neuron = layer[neuronIndex];
                    double output = outputs[neuronIndex];

                    if (layerIndex == layers.Count - 1)
                    {
                        // Çıkış katmanı için hata hesaplama (hedef - çıktı)
                        double target = targets[neuronIndex];
                        neuron.Delta = output * (1 - output) * (target - output);
                    }
                    else
                    {
                        // Gizli katmanlar için hata hesaplama (bir sonraki katmanın hatalarına göre)
                        double error = 0;
                        var nextLayer = layers[layerIndex + 1];
                        for (int j = 0; j < nextLayer.Count; j++)
                        {
                            error += nextLayer[j].Delta * nextLayer[j].Weights[neuronIndex];
                        }
                        neuron.Delta = output * (1 - output) * error;
                    }

                    // Ağırlıkları güncelle
                    List<double> neuronInputs = layerIndex == 0 ? inputs : layerOutputs[layerIndex - 1];
                    neuron.UpdateWeights(neuronInputs, learningRate);
                }
            }
        }

        /// <summary>
        /// Sınıflandırma sonucunu döndürür
        /// </summary>
        /// <param name="inputs">Girdi değerleri</param>
        /// <returns>En yüksek çıktı değerine sahip nöronun indeksi</returns>
        public int Predict(List<double> inputs)
        {
            var outputs = Forward(inputs);
            return outputs.IndexOf(outputs.Max()); // En yüksek çıktıya sahip nöronun indeksi
        }
    }
} 