using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BulanikCamasirMakinesi
{
    // Değişken türleri (giriş veya çıkış)
    public enum VariableType
    {
        Input,
        Output
    }

    // Bulanık değişken sınıfı
    public class FuzzyVariable
    {
        public string Name { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public VariableType Type { get; set; }
        public List<FuzzySet> FuzzySets { get; set; }

        public FuzzyVariable(string name, double minValue, double maxValue, VariableType type)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            Type = type;
            FuzzySets = new List<FuzzySet>();
        }

        // Değişkene bulanık küme ekler
        public void AddFuzzySet(FuzzySet fuzzySet)
        {
            FuzzySets.Add(fuzzySet);
        }

        // Belirli bir değer için tüm bulanık kümelerdeki üyelik derecelerini hesaplar
        public Dictionary<string, double> Fuzzify(double value)
        {
            Dictionary<string, double> membershipDegrees = new Dictionary<string, double>();

            foreach (var fuzzySet in FuzzySets)
            {
                double degree = fuzzySet.GetMembershipDegree(value);
                membershipDegrees[fuzzySet.Name] = degree;
            }

            return membershipDegrees;
        }

        // Bulanık bir çıktı değişkenini ağırlık merkezi yöntemiyle durulaştırır
        public double DefuzzifyCentroid(Dictionary<string, double> activationValues, int samplePoints = 100)
        {
            double step = (MaxValue - MinValue) / samplePoints;
            double sumOfMoments = 0;
            double sumOfAreas = 0;

            for (double x = MinValue; x <= MaxValue; x += step)
            {
                double membershipDegree = 0;

                // Her bulanık küme için en büyük değeri al (max operatörü)
                foreach (var fuzzySet in FuzzySets)
                {
                    if (activationValues.ContainsKey(fuzzySet.Name) && activationValues[fuzzySet.Name] > 0)
                    {
                        double setMembership = Math.Min(fuzzySet.GetMembershipDegree(x), activationValues[fuzzySet.Name]);
                        membershipDegree = Math.Max(membershipDegree, setMembership);
                    }
                }

                sumOfMoments += x * membershipDegree * step;
                sumOfAreas += membershipDegree * step;
            }

            if (sumOfAreas == 0)
                return (MaxValue + MinValue) / 2; // Varsayılan değer

            return sumOfMoments / sumOfAreas;
        }

        // Bulanık bir çıktı değişkenini ağırlıklı ortalama yöntemiyle durulaştırır
        public double DefuzzifyWeightedAverage(Dictionary<string, double> activationValues)
        {
            double numerator = 0;
            double denominator = 0;

            foreach (var fuzzySet in FuzzySets)
            {
                if (activationValues.ContainsKey(fuzzySet.Name) && activationValues[fuzzySet.Name] > 0)
                {
                    // Bulanık kümenin merkez noktasını hesapla
                    double center = CalculateCenter(fuzzySet);
                    numerator += center * activationValues[fuzzySet.Name];
                    denominator += activationValues[fuzzySet.Name];
                }
            }

            if (denominator == 0)
                return (MaxValue + MinValue) / 2; // Varsayılan değer

            return numerator / denominator;
        }

        // Bulanık kümenin merkez noktasını hesaplar
        private double CalculateCenter(FuzzySet fuzzySet)
        {
            switch (fuzzySet.Type)
            {
                case MembershipFunctionType.Triangle:
                    return fuzzySet.Parameters[1]; // Üçgenin tepe noktası

                case MembershipFunctionType.Trapezoid:
                    return (fuzzySet.Parameters[1] + fuzzySet.Parameters[2]) / 2; // Yamuk üst kısmının ortası

                default:
                    return 0;
            }
        }

        // Belirtilen isimli bulanık kümeyi bulur
        public FuzzySet GetFuzzySetByName(string name)
        {
            return FuzzySets.FirstOrDefault(fs => fs.Name == name);
        }
    }
} 