using System;
using System.Collections.Generic;

namespace BulanikCamasirMakinesi
{
    // Bulanık koşul sınıfı
    public class FuzzyCondition
    {
        public FuzzyVariable Variable { get; set; }
        public string FuzzySetName { get; set; }

        public FuzzyCondition(FuzzyVariable variable, string fuzzySetName)
        {
            Variable = variable;
            FuzzySetName = fuzzySetName;
        }

        // Belirli bir değer için üyelik derecesini hesaplar
        public double GetMembershipDegree(double value)
        {
            Dictionary<string, double> membershipDegrees = Variable.Fuzzify(value);
            if (membershipDegrees.ContainsKey(FuzzySetName))
                return membershipDegrees[FuzzySetName];
            return 0;
        }
    }

    // Bulanık sonuç sınıfı
    public class FuzzyConsequent
    {
        public FuzzyVariable Variable { get; set; }
        public string FuzzySetName { get; set; }

        public FuzzyConsequent(FuzzyVariable variable, string fuzzySetName)
        {
            Variable = variable;
            FuzzySetName = fuzzySetName;
        }
    }

    // Bulanık kural sınıfı
    public class FuzzyRule
    {
        public int RuleNumber { get; set; }
        public List<FuzzyCondition> Antecedents { get; set; }
        public List<FuzzyConsequent> Consequents { get; set; }

        public FuzzyRule(int ruleNumber)
        {
            RuleNumber = ruleNumber;
            Antecedents = new List<FuzzyCondition>();
            Consequents = new List<FuzzyConsequent>();
        }

        // Kurala koşul ekler
        public void AddAntecedent(FuzzyCondition antecedent)
        {
            Antecedents.Add(antecedent);
        }

        // Kurala sonuç ekler
        public void AddConsequent(FuzzyConsequent consequent)
        {
            Consequents.Add(consequent);
        }

        // Mamdani min operatörünü kullanarak kuralın ateşleme seviyesini hesaplar
        public double EvaluateRule(Dictionary<FuzzyVariable, double> inputValues)
        {
            if (Antecedents.Count == 0)
                return 0;

            // Min operatörü ile tüm koşulları değerlendir
            double minMembership = double.MaxValue;

            foreach (var antecedent in Antecedents)
            {
                if (inputValues.TryGetValue(antecedent.Variable, out double value))
                {
                    double membershipDegree = antecedent.GetMembershipDegree(value);
                    minMembership = Math.Min(minMembership, membershipDegree);
                }
                else
                {
                    return 0; // Değer bulunamadıysa kural ateşlemez
                }
            }

            return minMembership;
        }

        // Kuralın metinsel gösterimini döndürür
        public override string ToString()
        {
            string ruleText = $"Kural {RuleNumber}: IF ";
            
            for (int i = 0; i < Antecedents.Count; i++)
            {
                if (i > 0)
                    ruleText += " AND ";
                
                ruleText += $"{Antecedents[i].Variable.Name} = {Antecedents[i].FuzzySetName}";
            }

            ruleText += " THEN ";

            for (int i = 0; i < Consequents.Count; i++)
            {
                if (i > 0)
                    ruleText += " AND ";
                
                ruleText += $"{Consequents[i].Variable.Name} = {Consequents[i].FuzzySetName}";
            }

            return ruleText;
        }
    }
} 