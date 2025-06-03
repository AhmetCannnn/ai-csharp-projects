using System;
using System.Collections.Generic;
using System.Drawing;

namespace BulanikCamasirMakinesi
{
    // Üyelik fonksiyonu türleri
    public enum MembershipFunctionType
    {
        Triangle,
        Trapezoid
    }

    // Bulanık küme sınıfı
    public class FuzzySet
    {
        public string Name { get; set; }
        public MembershipFunctionType Type { get; set; }
        public double[] Parameters { get; set; }
        public Color DisplayColor { get; set; }

        public FuzzySet(string name, MembershipFunctionType type, double[] parameters, Color color)
        {
            Name = name;
            Type = type;
            Parameters = parameters;
            DisplayColor = color;
        }

        // Bir değerin üyelik derecesini hesaplar
        public double GetMembershipDegree(double value)
        {
            switch (Type)
            {
                case MembershipFunctionType.Triangle:
                    return CalculateTriangleMembership(value);
                case MembershipFunctionType.Trapezoid:
                    return CalculateTrapezoidMembership(value);
                default:
                    return 0;
            }
        }

        // Üçgen üyelik fonksiyonu hesaplaması
        private double CalculateTriangleMembership(double x)
        {
            if (Parameters.Length != 3)
                throw new InvalidOperationException("Üçgen üyelik fonksiyonu 3 parametre gerektirir");

            double a = Parameters[0]; // sol uç
            double b = Parameters[1]; // tepe
            double c = Parameters[2]; // sağ uç

            if (x <= a || x >= c)
                return 0;
            else if (x < b)
                return (x - a) / (b - a);
            else
                return (c - x) / (c - b);
        }

        // Yamuk üyelik fonksiyonu hesaplaması
        private double CalculateTrapezoidMembership(double x)
        {
            if (Parameters.Length != 4)
                throw new InvalidOperationException("Yamuk üyelik fonksiyonu 4 parametre gerektirir");

            double a = Parameters[0]; // sol kenar başlangıcı
            double b = Parameters[1]; // sol üst kenar
            double c = Parameters[2]; // sağ üst kenar
            double d = Parameters[3]; // sağ kenar bitişi

            if (x <= a || x >= d)
                return 0;
            else if (x >= b && x <= c)
                return 1;
            else if (x < b)
                return (x - a) / (b - a);
            else
                return (d - x) / (d - c);
        }

        // Grafikte çizim için kullanılacak noktaları hesaplar
        public List<PointF> GetPointsForDrawing(float minX, float maxX, float height, int pointCount = 100)
        {
            List<PointF> points = new List<PointF>();
            float step = (maxX - minX) / pointCount;

            for (float x = minX; x <= maxX; x += step)
            {
                float y = (float)GetMembershipDegree(x) * height;
                points.Add(new PointF(x, y));
            }

            return points;
        }
    }
} 