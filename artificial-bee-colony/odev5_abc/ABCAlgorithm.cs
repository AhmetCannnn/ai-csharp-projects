using System;
using System.Collections.Generic;

namespace odev5_abc
{
    public class ABCAlgorithm
    {
        public int FoodNumber { get; set; }
        public int Limit { get; set; }
        public int MaxCycle { get; set; }
        public int Dimension { get; set; }
        public double[] BoundsMin { get; set; }
        public double[] BoundsMax { get; set; }
        public List<Bee> FoodSources { get; set; }
        public List<double> Convergence { get; set; }
        public Bee BestBee { get; set; }
        private static Random rnd = new Random();

        public ABCAlgorithm(int foodNumber, int limit, int maxCycle, int dimension, double[] boundsMin, double[] boundsMax)
        {
            FoodNumber = foodNumber;
            Limit = limit;
            MaxCycle = maxCycle;
            Dimension = dimension;
            BoundsMin = boundsMin;
            BoundsMax = boundsMax;
            FoodSources = new List<Bee>();
            Convergence = new List<double>();
        }

        public void Initialize()
        {
            FoodSources.Clear();
            for (int i = 0; i < FoodNumber; i++)
            {
                Bee bee = new Bee(Dimension, BoundsMin, BoundsMax);
                bee.Fitness = TestFunction.Evaluate(bee.Position);
                bee.Trial = 0;
                FoodSources.Add(bee);
            }
            BestBee = FoodSources[0].Clone();
            foreach (var bee in FoodSources)
            {
                if (bee.Fitness < BestBee.Fitness)
                    BestBee = bee.Clone();
            }
        }

        public void Run()
        {
            Initialize();
            for (int cycle = 0; cycle < MaxCycle; cycle++)
            {
                // Employed Bees
                for (int i = 0; i < FoodNumber; i++)
                {
                    Bee bee = FoodSources[i];
                    Bee newBee = GenerateNeighbor(bee, i);
                    newBee.Fitness = TestFunction.Evaluate(newBee.Position);
                    if (newBee.Fitness < bee.Fitness)
                    {
                        FoodSources[i] = newBee;
                        FoodSources[i].Trial = 0;
                    }
                    else
                    {
                        bee.Trial++;
                    }
                }

                // Onlooker Bees
                double[] fitnesses = new double[FoodNumber];
                double maxFit = double.MinValue;
                for (int i = 0; i < FoodNumber; i++)
                {
                    fitnesses[i] = 1.0 / (1.0 + FoodSources[i].Fitness);
                    if (fitnesses[i] > maxFit) maxFit = fitnesses[i];
                }
                for (int i = 0; i < FoodNumber; i++)
                {
                    double prob = 0.9 * (fitnesses[i] / maxFit) + 0.1;
                    if (rnd.NextDouble() < prob)
                    {
                        Bee bee = FoodSources[i];
                        Bee newBee = GenerateNeighbor(bee, i);
                        newBee.Fitness = TestFunction.Evaluate(newBee.Position);
                        if (newBee.Fitness < bee.Fitness)
                        {
                            FoodSources[i] = newBee;
                            FoodSources[i].Trial = 0;
                        }
                        else
                        {
                            bee.Trial++;
                        }
                    }
                }

                // Scout Bees
                for (int i = 0; i < FoodNumber; i++)
                {
                    if (FoodSources[i].Trial > Limit)
                    {
                        FoodSources[i] = new Bee(Dimension, BoundsMin, BoundsMax);
                        FoodSources[i].Fitness = TestFunction.Evaluate(FoodSources[i].Position);
                        FoodSources[i].Trial = 0;
                    }
                }

                // En iyi çözümü güncelle
                foreach (var bee in FoodSources)
                {
                    if (bee.Fitness < BestBee.Fitness)
                        BestBee = bee.Clone();
                }
                Convergence.Add(BestBee.Fitness);
            }
        }

        private Bee GenerateNeighbor(Bee bee, int beeIndex)
        {
            Bee neighbor = bee.Clone();
            int paramIndex = rnd.Next(Dimension);
            int k;
            do { k = rnd.Next(FoodNumber); } while (k == beeIndex);
            double phi = (rnd.NextDouble() * 2) - 1; // [-1,1]
            neighbor.Position[paramIndex] = bee.Position[paramIndex] + phi * (bee.Position[paramIndex] - FoodSources[k].Position[paramIndex]);
            // Sınır kontrolü
            if (neighbor.Position[paramIndex] < BoundsMin[paramIndex]) neighbor.Position[paramIndex] = BoundsMin[paramIndex];
            if (neighbor.Position[paramIndex] > BoundsMax[paramIndex]) neighbor.Position[paramIndex] = BoundsMax[paramIndex];
            return neighbor;
        }
    }
} 