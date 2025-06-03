using System;

namespace odev5_abc
{
    public class Bee
    {
        public double[] Position { get; set; }
        public double Fitness { get; set; }
        public int Trial { get; set; }
        private double[] BoundsMin;
        private double[] BoundsMax;
        private static Random rnd = new Random();

        public Bee(int dimension, double[] boundsMin, double[] boundsMax)
        {
            Position = new double[dimension];
            BoundsMin = boundsMin;
            BoundsMax = boundsMax;
            RandomizePosition();
        }

        public void RandomizePosition()
        {
            for (int i = 0; i < Position.Length; i++)
                Position[i] = BoundsMin[i] + rnd.NextDouble() * (BoundsMax[i] - BoundsMin[i]);
        }

        public Bee Clone()
        {
            Bee clone = new Bee(Position.Length, BoundsMin, BoundsMax);
            Array.Copy(Position, clone.Position, Position.Length);
            clone.Fitness = Fitness;
            clone.Trial = Trial;
            return clone;
        }
    }
} 