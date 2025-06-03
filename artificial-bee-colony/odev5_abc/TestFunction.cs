using System;

namespace odev5_abc
{
    public static class TestFunction
    {
        // Sphere fonksiyonu: f(x) = sum(xi^2)
        public static double Evaluate(double[] x)
        {
            double sum = 0;
            foreach (var xi in x)
                sum += xi * xi;
            return sum;
        }
    }
} 