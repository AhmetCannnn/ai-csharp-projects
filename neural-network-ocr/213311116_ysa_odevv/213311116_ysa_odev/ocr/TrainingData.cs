using System.Collections.Generic;

namespace OCR
{
    /// <summary>
    /// Harflerin tanınması için kullanılan eğitim verilerini içeren sınıf
    /// </summary>
    public static class TrainingData
    {
        /// <summary>
        /// 5 harfin (A-E) 7x5 matris şeklindeki piksel gösterimleri
        /// 1: aktif piksel, 0: pasif piksel
        /// </summary>
        public static readonly int[,,] TrainingInputs = new int[5, 7, 5]
        {
            { // A
                {0,0,1,0,0},
                {0,1,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,1},
                {1,0,0,0,1},
                {1,0,0,0,1}
            },
            { // B
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0}
            },
            { // C
                {0,0,1,1,1},
                {0,1,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {0,1,0,0,0},
                {0,0,1,1,1}
            },
            { // D
                {1,1,1,0,0},
                {1,0,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,1,0},
                {1,1,1,0,0}
            },
            { // E
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1}
            }
        };

        /// <summary>
        /// Her harfin beklenen çıktı vektörü (one-hot encoding)
        /// Örn: A = [1,0,0,0,0], B = [0,1,0,0,0], ...
        /// </summary>
        public static readonly int[,] ExpectedOutputs = new int[5, 5]
        {
            // A, B, C, D, E
            {1, 0, 0, 0, 0}, // A
            {0, 1, 0, 0, 0}, // B
            {0, 0, 1, 0, 0}, // C
            {0, 0, 0, 1, 0}, // D
            {0, 0, 0, 0, 1}  // E
        };

        /// <summary>
        /// Belirtilen harfin matris gösterimini düz bir liste olarak döndürür
        /// </summary>
        /// <param name="letterIndex">Harf indeksi (0: A, 1: B, ...)</param>
        /// <returns>7x5 matrisi düzleştirilmiş hali (35 elemanlı liste)</returns>
        public static List<double> GetFlattenedInput(int letterIndex)
        {
            var result = new List<double>();
            
            // 7x5 matrisini satır satır tarayarak düz bir liste oluştur
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    result.Add(TrainingInputs[letterIndex, i, j]);
                }
            }
            
            return result;
        }

        /// <summary>
        /// Belirtilen harfin beklenen çıktı vektörünü döndürür
        /// </summary>
        /// <param name="letterIndex">Harf indeksi (0: A, 1: B, ...)</param>
        /// <returns>One-hot encoded çıktı vektörü</returns>
        public static List<double> GetExpectedOutput(int letterIndex)
        {
            var result = new List<double>();
            
            // One-hot encoding vektörünü oluştur
            for (int i = 0; i < 5; i++)
            {
                result.Add(ExpectedOutputs[letterIndex, i]);
            }
            
            return result;
        }
    }
} 