using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BulanikCamasirMakinesi
{
    // Bulanık mantık sistemi sınıfı
    public class FuzzyLogicSystem
    {
        public List<FuzzyVariable> InputVariables { get; set; }
        public List<FuzzyVariable> OutputVariables { get; set; }
        public List<FuzzyRule> Rules { get; set; }

        public FuzzyLogicSystem()
        {
            InputVariables = new List<FuzzyVariable>();
            OutputVariables = new List<FuzzyVariable>();
            Rules = new List<FuzzyRule>();
        }

        // Sisteme giriş değişkeni ekler
        public void AddInputVariable(FuzzyVariable variable)
        {
            InputVariables.Add(variable);
        }

        // Sisteme çıkış değişkeni ekler
        public void AddOutputVariable(FuzzyVariable variable)
        {
            OutputVariables.Add(variable);
        }

        // Sisteme kural ekler
        public void AddRule(FuzzyRule rule)
        {
            Rules.Add(rule);
        }

        // Mamdani bulanık çıkarım sistemini çalıştırır
        public Dictionary<FuzzyVariable, double> ProcessInputs(Dictionary<FuzzyVariable, double> inputValues)
        {
            // Giriş değerlerinin bulanıklaştırılması
            Dictionary<FuzzyVariable, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<FuzzyVariable, Dictionary<string, double>>();
            foreach (var variable in InputVariables)
            {
                if (inputValues.TryGetValue(variable, out double value))
                {
                    fuzzifiedInputs[variable] = variable.Fuzzify(value);
                }
            }

            // Kuralların değerlendirilmesi
            Dictionary<FuzzyRule, double> ruleEvaluations = new Dictionary<FuzzyRule, double>();
            foreach (var rule in Rules)
            {
                double activationLevel = rule.EvaluateRule(inputValues);
                ruleEvaluations[rule] = activationLevel;
            }

            // Her çıkış değişkeni için bulanık kümelerin birleştirilmesi
            Dictionary<FuzzyVariable, Dictionary<string, double>> outputFuzzySets = new Dictionary<FuzzyVariable, Dictionary<string, double>>();
            foreach (var outputVar in OutputVariables)
            {
                Dictionary<string, double> outputSetValues = new Dictionary<string, double>();

                // Her bulanık küme için başlangıçta 0 değeri ata
                foreach (var fuzzySet in outputVar.FuzzySets)
                {
                    outputSetValues[fuzzySet.Name] = 0;
                }

                // Her kural için ilgili çıkışlar üzerinde max operatörünü uygula
                foreach (var evaluation in ruleEvaluations.Where(e => e.Value > 0))
                {
                    FuzzyRule rule = evaluation.Key;
                    double activationLevel = evaluation.Value;

                    foreach (var consequent in rule.Consequents.Where(c => c.Variable == outputVar))
                    {
                        // Max operatörü ile bulanık kümeleri birleştir
                        if (!outputSetValues.ContainsKey(consequent.FuzzySetName))
                        {
                            outputSetValues[consequent.FuzzySetName] = activationLevel;
                        }
                        else
                        {
                            outputSetValues[consequent.FuzzySetName] = Math.Max(outputSetValues[consequent.FuzzySetName], activationLevel);
                        }
                    }
                }

                outputFuzzySets[outputVar] = outputSetValues;
            }

            // Durulaştırma (ağırlıklı ortalama yöntemi)
            Dictionary<FuzzyVariable, double> crispOutputs = new Dictionary<FuzzyVariable, double>();
            foreach (var outputVar in OutputVariables)
            {
                if (outputFuzzySets.TryGetValue(outputVar, out var fuzzyValues))
                {
                    double crispValue = outputVar.DefuzzifyWeightedAverage(fuzzyValues);
                    crispOutputs[outputVar] = crispValue;
                }
            }

            return crispOutputs;
        }

        // Ağırlık merkezi yöntemi kullanarak çıkışları hesaplar
        public Dictionary<FuzzyVariable, double> ProcessInputsCentroid(Dictionary<FuzzyVariable, double> inputValues)
        {
            // Giriş değerlerinin bulanıklaştırılması
            Dictionary<FuzzyVariable, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<FuzzyVariable, Dictionary<string, double>>();
            foreach (var variable in InputVariables)
            {
                if (inputValues.TryGetValue(variable, out double value))
                {
                    fuzzifiedInputs[variable] = variable.Fuzzify(value);
                }
            }

            // Kuralların değerlendirilmesi
            Dictionary<FuzzyRule, double> ruleEvaluations = new Dictionary<FuzzyRule, double>();
            foreach (var rule in Rules)
            {
                double activationLevel = rule.EvaluateRule(inputValues);
                ruleEvaluations[rule] = activationLevel;
            }

            // Her çıkış değişkeni için bulanık kümelerin birleştirilmesi
            Dictionary<FuzzyVariable, Dictionary<string, double>> outputFuzzySets = new Dictionary<FuzzyVariable, Dictionary<string, double>>();
            foreach (var outputVar in OutputVariables)
            {
                Dictionary<string, double> outputSetValues = new Dictionary<string, double>();

                // Her bulanık küme için başlangıçta 0 değeri ata
                foreach (var fuzzySet in outputVar.FuzzySets)
                {
                    outputSetValues[fuzzySet.Name] = 0;
                }

                // Her kural için ilgili çıkışlar üzerinde max operatörünü uygula
                foreach (var evaluation in ruleEvaluations.Where(e => e.Value > 0))
                {
                    FuzzyRule rule = evaluation.Key;
                    double activationLevel = evaluation.Value;

                    foreach (var consequent in rule.Consequents.Where(c => c.Variable == outputVar))
                    {
                        // Max operatörü ile bulanık kümeleri birleştir
                        if (!outputSetValues.ContainsKey(consequent.FuzzySetName))
                        {
                            outputSetValues[consequent.FuzzySetName] = activationLevel;
                        }
                        else
                        {
                            outputSetValues[consequent.FuzzySetName] = Math.Max(outputSetValues[consequent.FuzzySetName], activationLevel);
                        }
                    }
                }

                outputFuzzySets[outputVar] = outputSetValues;
            }

            // Durulaştırma (centroid yöntemi)
            Dictionary<FuzzyVariable, double> crispOutputs = new Dictionary<FuzzyVariable, double>();
            foreach (var outputVar in OutputVariables)
            {
                if (outputFuzzySets.TryGetValue(outputVar, out var fuzzyValues))
                {
                    double crispValue = outputVar.DefuzzifyCentroid(fuzzyValues);
                    crispOutputs[outputVar] = crispValue;
                }
            }

            return crispOutputs;
        }

        // Ateşlenen kuralları ve onların ateşleme seviyelerini verir
        public Dictionary<FuzzyRule, double> GetActivatedRules(Dictionary<FuzzyVariable, double> inputValues)
        {
            Dictionary<FuzzyRule, double> activatedRules = new Dictionary<FuzzyRule, double>();
            
            foreach (var rule in Rules)
            {
                double activationLevel = rule.EvaluateRule(inputValues);
                if (activationLevel > 0)
                {
                    activatedRules[rule] = activationLevel;
                }
            }
            
            return activatedRules;
        }

        // Bulanık sistemin giriş üyelik fonksiyonlarının üyelik derecelerini hesaplar
        public Dictionary<FuzzyVariable, Dictionary<string, double>> GetFuzzifiedInputs(Dictionary<FuzzyVariable, double> inputValues)
        {
            Dictionary<FuzzyVariable, Dictionary<string, double>> fuzzifiedInputs = new Dictionary<FuzzyVariable, Dictionary<string, double>>();
            
            foreach (var variable in InputVariables)
            {
                if (inputValues.TryGetValue(variable, out double value))
                {
                    fuzzifiedInputs[variable] = variable.Fuzzify(value);
                }
            }
            
            return fuzzifiedInputs;
        }

        // Giriş adıyla değişkeni bul
        public FuzzyVariable GetInputVariableByName(string name)
        {
            return InputVariables.FirstOrDefault(v => v.Name == name);
        }

        // Çıkış adıyla değişkeni bul
        public FuzzyVariable GetOutputVariableByName(string name)
        {
            return OutputVariables.FirstOrDefault(v => v.Name == name);
        }
    }
} 