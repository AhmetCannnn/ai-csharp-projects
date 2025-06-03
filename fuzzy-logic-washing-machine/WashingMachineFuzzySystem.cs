using System.Collections.Generic;
using System.Drawing;

namespace BulanikCamasirMakinesi
{
    // Çamaşır makinesi bulanık sistemini oluşturan sınıf
    public class WashingMachineFuzzySystem
    {
        private FuzzyLogicSystem fuzzySystem;

        // Giriş değişkenleri
        public FuzzyVariable Hassaslik { get; private set; }
        public FuzzyVariable Miktar { get; private set; }
        public FuzzyVariable Kirlilik { get; private set; }

        // Çıkış değişkenleri
        public FuzzyVariable DonusHizi { get; private set; }
        public FuzzyVariable Sure { get; private set; }
        public FuzzyVariable DeterjanMiktari { get; private set; }

        public WashingMachineFuzzySystem()
        {
            fuzzySystem = new FuzzyLogicSystem();
            InitializeSystem();
        }

        // Bulanık sistemin değişkenlerini ve kurallarını başlatır
        private void InitializeSystem()
        {
            // Giriş değişkenlerini oluştur
            CreateInputVariables();

            // Çıkış değişkenlerini oluştur
            CreateOutputVariables();

            // Kuralları oluştur
            CreateRules();
        }

        // Giriş değişkenlerini oluşturur
        private void CreateInputVariables()
        {
            // Hassaslık değişkeni (0-10)
            Hassaslik = new FuzzyVariable("Hassaslık", 0, 10, VariableType.Input);

            // Hassas
            Hassaslik.AddFuzzySet(new FuzzySet("Hassas", MembershipFunctionType.Trapezoid, 
                new double[] { -4, -1.5, 2, 4 }, Color.Blue));

            // Orta
            Hassaslik.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 2, 5, 8 }, Color.Green));

            // Sağlam
            Hassaslik.AddFuzzySet(new FuzzySet("Sağlam", MembershipFunctionType.Trapezoid, 
                new double[] { 6, 8, 11.5, 14 }, Color.Red));

            fuzzySystem.AddInputVariable(Hassaslik);

            // Miktar değişkeni (0-10)
            Miktar = new FuzzyVariable("Miktar", 0, 10, VariableType.Input);

            // Küçük
            Miktar.AddFuzzySet(new FuzzySet("Küçük", MembershipFunctionType.Trapezoid, 
                new double[] { -4, -1.5, 2, 4 }, Color.Blue));

            // Orta
            Miktar.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 2, 5, 8 }, Color.Green));

            // Büyük
            Miktar.AddFuzzySet(new FuzzySet("Büyük", MembershipFunctionType.Trapezoid, 
                new double[] { 6, 8, 11.5, 14 }, Color.Red));

            fuzzySystem.AddInputVariable(Miktar);

            // Kirlilik değişkeni (0-10)
            Kirlilik = new FuzzyVariable("Kirlilik", 0, 10, VariableType.Input);

            // Küçük
            Kirlilik.AddFuzzySet(new FuzzySet("Küçük", MembershipFunctionType.Trapezoid, 
                new double[] { -4, -1.5, 2, 4 }, Color.Blue));

            // Orta
            Kirlilik.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 2, 5, 8 }, Color.Green));

            // Büyük
            Kirlilik.AddFuzzySet(new FuzzySet("Büyük", MembershipFunctionType.Trapezoid, 
                new double[] { 6, 8, 11.5, 14 }, Color.Red));

            fuzzySystem.AddInputVariable(Kirlilik);
        }

        // Çıkış değişkenlerini oluşturur
        private void CreateOutputVariables()
        {
            // Dönüş Hızı değişkeni (0-10)
            DonusHizi = new FuzzyVariable("Dönüş Hızı", 0, 10, VariableType.Output);

            // Hassas
            DonusHizi.AddFuzzySet(new FuzzySet("Hassas", MembershipFunctionType.Trapezoid, 
                new double[] { -5.8, -2.8, 0.5, 1.5 }, Color.Blue));

            // Normal-Hassas
            DonusHizi.AddFuzzySet(new FuzzySet("Normal-Hassas", MembershipFunctionType.Triangle, 
                new double[] { 0.8, 2.5, 4.2 }, Color.LightBlue));

            // Orta
            DonusHizi.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 3.5, 5, 6.5 }, Color.Green));

            // Normal-Güçlü
            DonusHizi.AddFuzzySet(new FuzzySet("Normal-Güçlü", MembershipFunctionType.Triangle, 
                new double[] { 5.8, 7.5, 9.2 }, Color.Orange));

            // Güçlü
            DonusHizi.AddFuzzySet(new FuzzySet("Güçlü", MembershipFunctionType.Trapezoid, 
                new double[] { 8.5, 9.5, 12.8, 15.8 }, Color.Red));

            fuzzySystem.AddOutputVariable(DonusHizi);

            // Süre değişkeni (0-100)
            Sure = new FuzzyVariable("Süre", 0, 100, VariableType.Output);

            // Kısa
            Sure.AddFuzzySet(new FuzzySet("Kısa", MembershipFunctionType.Trapezoid, 
                new double[] { -30, -5, 10, 25 }, Color.Blue));

            // Normal-Kısa
            Sure.AddFuzzySet(new FuzzySet("Normal-Kısa", MembershipFunctionType.Triangle, 
                new double[] { 15, 30, 45 }, Color.LightBlue));

            // Orta
            Sure.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 35, 50, 65 }, Color.Green));

            // Normal-Uzun
            Sure.AddFuzzySet(new FuzzySet("Normal-Uzun", MembershipFunctionType.Triangle, 
                new double[] { 55, 70, 85 }, Color.Orange));

            // Uzun
            Sure.AddFuzzySet(new FuzzySet("Uzun", MembershipFunctionType.Trapezoid, 
                new double[] { 75, 90, 105, 130 }, Color.Red));

            fuzzySystem.AddOutputVariable(Sure);

            // Deterjan Miktarı değişkeni (0-300)
            DeterjanMiktari = new FuzzyVariable("Deterjan Miktarı", 0, 300, VariableType.Output);

            // Çok Az
            DeterjanMiktari.AddFuzzySet(new FuzzySet("Çok Az", MembershipFunctionType.Trapezoid, 
                new double[] { 0, 0, 20, 85 }, Color.Blue));

            // Az
            DeterjanMiktari.AddFuzzySet(new FuzzySet("Az", MembershipFunctionType.Triangle, 
                new double[] { 20, 85, 150 }, Color.LightBlue));

            // Orta
            DeterjanMiktari.AddFuzzySet(new FuzzySet("Orta", MembershipFunctionType.Triangle, 
                new double[] { 85, 150, 215 }, Color.Green));

            // Fazla
            DeterjanMiktari.AddFuzzySet(new FuzzySet("Fazla", MembershipFunctionType.Triangle, 
                new double[] { 150, 215, 280 }, Color.Orange));

            // Çok Fazla
            DeterjanMiktari.AddFuzzySet(new FuzzySet("Çok Fazla", MembershipFunctionType.Trapezoid, 
                new double[] { 215, 280, 300, 300 }, Color.Red));

            fuzzySystem.AddOutputVariable(DeterjanMiktari);
        }

        // Bulanık kuralları oluşturur
        private void CreateRules()
        {
            int ruleCounter = 1;

            // Hassaslık = Hassas
            for (int i = 0; i < 3; i++) // Miktar: Küçük, Orta, Büyük
            {
                for (int j = 0; j < 3; j++) // Kirlilik: Küçük, Orta, Büyük
                {
                    var rule = new FuzzyRule(ruleCounter++);
                    
                    // Koşullar
                    rule.AddAntecedent(new FuzzyCondition(Hassaslik, "Hassas"));
                    rule.AddAntecedent(new FuzzyCondition(Miktar, GetLabelForIndex(i)));
                    rule.AddAntecedent(new FuzzyCondition(Kirlilik, GetLabelForIndex(j)));

                    // Sonuçlar
                    rule.AddConsequent(SetRuleOutput(0, i, j, rule));

                    fuzzySystem.AddRule(rule);
                }
            }

            // Hassaslık = Orta
            for (int i = 0; i < 3; i++) // Miktar: Küçük, Orta, Büyük
            {
                for (int j = 0; j < 3; j++) // Kirlilik: Küçük, Orta, Büyük
                {
                    var rule = new FuzzyRule(ruleCounter++);
                    
                    // Koşullar
                    rule.AddAntecedent(new FuzzyCondition(Hassaslik, "Orta"));
                    rule.AddAntecedent(new FuzzyCondition(Miktar, GetLabelForIndex(i)));
                    rule.AddAntecedent(new FuzzyCondition(Kirlilik, GetLabelForIndex(j)));

                    // Sonuçlar
                    rule.AddConsequent(SetRuleOutput(1, i, j, rule));

                    fuzzySystem.AddRule(rule);
                }
            }

            // Hassaslık = Sağlam
            for (int i = 0; i < 3; i++) // Miktar: Küçük, Orta, Büyük
            {
                for (int j = 0; j < 3; j++) // Kirlilik: Küçük, Orta, Büyük
                {
                    var rule = new FuzzyRule(ruleCounter++);
                    
                    // Koşullar
                    rule.AddAntecedent(new FuzzyCondition(Hassaslik, "Sağlam"));
                    rule.AddAntecedent(new FuzzyCondition(Miktar, GetLabelForIndex(i)));
                    rule.AddAntecedent(new FuzzyCondition(Kirlilik, GetLabelForIndex(j)));

                    // Sonuçlar
                    rule.AddConsequent(SetRuleOutput(2, i, j, rule));

                    fuzzySystem.AddRule(rule);
                }
            }
        }

        // Değişken indeksine göre etiketi döndürür
        private string GetLabelForIndex(int index)
        {
            switch (index)
            {
                case 0: return "Küçük";
                case 1: return "Orta";
                case 2: return "Büyük";
                default: return "Orta";
            }
        }

        // Kural çıkışlarını ayarlar
        private FuzzyConsequent SetRuleOutput(int hassaslikIndex, int miktarIndex, int kirlilikIndex, FuzzyRule rule)
        {
            // Dönüş Hızı
            string donusHiziLabel;
            if (hassaslikIndex == 0) // Hassas
            {
                if (kirlilikIndex == 0) donusHiziLabel = "Hassas";
                else if (kirlilikIndex == 1) donusHiziLabel = "Hassas";
                else donusHiziLabel = "Normal-Hassas";
            }
            else if (hassaslikIndex == 1) // Orta
            {
                if (kirlilikIndex == 0) donusHiziLabel = "Normal-Hassas";
                else if (kirlilikIndex == 1) donusHiziLabel = "Orta";
                else donusHiziLabel = "Normal-Güçlü";
            }
            else // Sağlam
            {
                if (kirlilikIndex == 0) donusHiziLabel = "Normal-Güçlü";
                else if (kirlilikIndex == 1) donusHiziLabel = "Normal-Güçlü";
                else donusHiziLabel = "Güçlü";
            }
            rule.AddConsequent(new FuzzyConsequent(DonusHizi, donusHiziLabel));

            // Süre
            string sureLabel;
            if (kirlilikIndex == 0) // Az kirli
            {
                if (miktarIndex == 0) sureLabel = "Kısa";
                else if (miktarIndex == 1) sureLabel = "Normal-Kısa";
                else sureLabel = "Orta";
            }
            else if (kirlilikIndex == 1) // Orta kirli
            {
                if (miktarIndex == 0) sureLabel = "Normal-Kısa";
                else if (miktarIndex == 1) sureLabel = "Orta";
                else sureLabel = "Normal-Uzun";
            }
            else // Çok kirli
            {
                if (miktarIndex == 0) sureLabel = "Orta";
                else if (miktarIndex == 1) sureLabel = "Normal-Uzun";
                else sureLabel = "Uzun";
            }
            rule.AddConsequent(new FuzzyConsequent(Sure, sureLabel));

            // Deterjan Miktarı
            string deterjanLabel;
            if (kirlilikIndex == 0) // Az kirli
            {
                if (miktarIndex == 0) deterjanLabel = "Çok Az";
                else if (miktarIndex == 1) deterjanLabel = "Az";
                else deterjanLabel = "Orta";
            }
            else if (kirlilikIndex == 1) // Orta kirli
            {
                if (miktarIndex == 0) deterjanLabel = "Az";
                else if (miktarIndex == 1) deterjanLabel = "Orta";
                else deterjanLabel = "Fazla";
            }
            else // Çok kirli
            {
                if (miktarIndex == 0) deterjanLabel = "Orta";
                else if (miktarIndex == 1) deterjanLabel = "Fazla";
                else deterjanLabel = "Çok Fazla";
            }
            return new FuzzyConsequent(DeterjanMiktari, deterjanLabel);
        }

        // Çamaşır makinesinin çıkışlarını hesaplar
        public Dictionary<string, double> CalculateOutputs(double hassaslik, double miktar, double kirlilik)
        {
            // Giriş değerlerini hazırla
            Dictionary<FuzzyVariable, double> inputs = new Dictionary<FuzzyVariable, double>
            {
                { Hassaslik, hassaslik },
                { Miktar, miktar },
                { Kirlilik, kirlilik }
            };

            // Hesaplamayı yap
            var results = fuzzySystem.ProcessInputs(inputs);

            // Sonuçları isimlerle döndür
            Dictionary<string, double> namedResults = new Dictionary<string, double>();
            foreach (var result in results)
            {
                namedResults[result.Key.Name] = result.Value;
            }

            return namedResults;
        }

        // Centroid yöntemiyle çıkışları hesaplar
        public Dictionary<string, double> CalculateOutputsCentroid(double hassaslik, double miktar, double kirlilik)
        {
            // Giriş değerlerini hazırla
            Dictionary<FuzzyVariable, double> inputs = new Dictionary<FuzzyVariable, double>
            {
                { Hassaslik, hassaslik },
                { Miktar, miktar },
                { Kirlilik, kirlilik }
            };

            // Hesaplamayı yap
            var results = fuzzySystem.ProcessInputsCentroid(inputs);

            // Sonuçları isimlerle döndür
            Dictionary<string, double> namedResults = new Dictionary<string, double>();
            foreach (var result in results)
            {
                namedResults[result.Key.Name] = result.Value;
            }

            return namedResults;
        }

        // Ateşlenen kuralları döndürür
        public Dictionary<FuzzyRule, double> GetActivatedRules(double hassaslik, double miktar, double kirlilik)
        {
            Dictionary<FuzzyVariable, double> inputs = new Dictionary<FuzzyVariable, double>
            {
                { Hassaslik, hassaslik },
                { Miktar, miktar },
                { Kirlilik, kirlilik }
            };

            return fuzzySystem.GetActivatedRules(inputs);
        }

        // Bulanıklaştırılmış giriş değerlerini döndürür
        public Dictionary<FuzzyVariable, Dictionary<string, double>> GetFuzzifiedInputs(double hassaslik, double miktar, double kirlilik)
        {
            Dictionary<FuzzyVariable, double> inputs = new Dictionary<FuzzyVariable, double>
            {
                { Hassaslik, hassaslik },
                { Miktar, miktar },
                { Kirlilik, kirlilik }
            };

            return fuzzySystem.GetFuzzifiedInputs(inputs);
        }

        // Çıkış değişkenleri için bulanık küme aktivasyon seviyelerini hesaplar
        public Dictionary<string, Dictionary<string, double>> GetOutputActivationLevels(double hassaslik, double miktar, double kirlilik)
        {
            Dictionary<FuzzyVariable, double> inputs = new Dictionary<FuzzyVariable, double>
            {
                { Hassaslik, hassaslik },
                { Miktar, miktar },
                { Kirlilik, kirlilik }
            };

            var activatedRules = fuzzySystem.GetActivatedRules(inputs);

            // Her çıkış değişkeni için bulanık kümelerin aktivasyon seviyelerini hesapla
            Dictionary<string, Dictionary<string, double>> outputActivations = new Dictionary<string, Dictionary<string, double>>();
            
            foreach (var outputVar in fuzzySystem.OutputVariables)
            {
                var activationLevels = new Dictionary<string, double>();
                
                // Her bulanık küme için başlangıçta 0 değeri ata
                foreach (var fuzzySet in outputVar.FuzzySets)
                {
                    activationLevels[fuzzySet.Name] = 0;
                }
                
                // Her kural için ilgili çıkışlar üzerinde max operatörü
                foreach (var rule in activatedRules.Keys)
                {
                    double activationLevel = activatedRules[rule];
                    
                    foreach (var consequent in rule.Consequents)
                    {
                        if (consequent.Variable == outputVar)
                        {
                            // Max operatörü
                            activationLevels[consequent.FuzzySetName] = 
                                System.Math.Max(activationLevels[consequent.FuzzySetName], activationLevel);
                        }
                    }
                }
                
                outputActivations[outputVar.Name] = activationLevels;
            }
            
            return outputActivations;
        }
    }
} 