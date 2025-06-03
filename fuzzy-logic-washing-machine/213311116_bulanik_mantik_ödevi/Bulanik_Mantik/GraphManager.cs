using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BulanikCamasirMakinesi
{
    // Grafik çizimi için yardımcı sınıf
    public class GraphManager
    {
        // Bulanık değişken grafiğini çizer
        public static void DrawFuzzyVariable(Graphics g, FuzzyVariable variable, RectangleF bounds, float scaleX = 1.0f, float scaleY = 1.0f)
        {
            float width = bounds.Width;
            float height = bounds.Height;
            float minX = (float)variable.MinValue * scaleX;
            float maxX = (float)variable.MaxValue * scaleX;

            // Eksenleri çiz
            using (Pen axisPen = new Pen(Color.DarkGray, 1))
            {
                // X ekseni
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
                
                // Y ekseni
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Left, bounds.Top);
            }

            // Eksenleri etiketle
            using (Font font = new Font("Segoe UI", 8))
            using (SolidBrush textBrush = new SolidBrush(Color.DarkSlateGray))
            {
                // X ekseni etiketleri
                g.DrawString(variable.MinValue.ToString("0.0"), font, textBrush, bounds.Left, bounds.Bottom + 5);
                g.DrawString(variable.MaxValue.ToString("0.0"), font, textBrush, bounds.Right - 20, bounds.Bottom + 5);
                
                // Y ekseni etiketleri
                g.DrawString("0", font, textBrush, bounds.Left - 15, bounds.Bottom - 5);
                g.DrawString("1", font, textBrush, bounds.Left - 15, bounds.Top);
            }

            // Her bulanık kümeyi ayrı renkle çiz
            foreach (var fuzzySet in variable.FuzzySets)
            {
                Color setColor = fuzzySet.DisplayColor;
                
                using (Pen setpen = new Pen(setColor, 2))
                {
                    // Grafiği değer aralığına göre ölçeklendir
                    float range = maxX - minX;
                    float xScale = width / range;
                    
                    // Bulanık kümenin çizim noktalarını al
                    List<PointF> points = fuzzySet.GetPointsForDrawing(minX / scaleX, maxX / scaleX, height, 200);
                    
                    // Noktaları ekran koordinatlarına dönüştür
                    for (int i = 0; i < points.Count; i++)
                    {
                        float x = ((points[i].X * scaleX) - minX) * xScale + bounds.Left;
                        float y = bounds.Bottom - points[i].Y;
                        points[i] = new PointF(x, y);
                    }
                    
                    // Grafiği çiz - önce dolgu ile
                    if (points.Count > 1)
                    {
                        // Dolgu için alanı kapat
                        List<PointF> fillPoints = new List<PointF>(points);
                        fillPoints.Add(new PointF(points[points.Count - 1].X, bounds.Bottom));
                        fillPoints.Add(new PointF(points[0].X, bounds.Bottom));
                        
                        // Yarı saydam dolgu
                        using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(40, setColor)))
                        {
                            g.FillPolygon(fillBrush, fillPoints.ToArray());
                        }
                        
                        // Kenar çizgisi
                        g.DrawLines(setpen, points.ToArray());
                    }

                    // Bulanık küme etiketini çiz
                    using (Font font = new Font("Segoe UI", 8, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(setColor))
                    {
                        // Etiketin merkez noktasını hesapla
                        float xCenter = 0;
                        if (fuzzySet.Type == MembershipFunctionType.Triangle)
                        {
                            xCenter = ((float)fuzzySet.Parameters[1] * scaleX - minX) * xScale + bounds.Left;
                        }
                        else if (fuzzySet.Type == MembershipFunctionType.Trapezoid)
                        {
                            xCenter = (((float)(fuzzySet.Parameters[1] + fuzzySet.Parameters[2]) / 2 * scaleX) - minX) * xScale + bounds.Left;
                        }

                        // Etiketi çiz
                        g.DrawString(fuzzySet.Name, font, textBrush, xCenter - 15, bounds.Top);
                    }
                }
            }
        }

        // Çıkış değişkeni grafiğini ve aktif kümelerini çizer
        public static void DrawFuzzyOutputVariable(Graphics g, FuzzyVariable variable, RectangleF bounds, Dictionary<string, double> activationLevels)
        {
            float width = bounds.Width;
            float height = bounds.Height;
            float minX = (float)variable.MinValue;
            float maxX = (float)variable.MaxValue;

            // Eksenleri çiz
            using (Pen axisPen = new Pen(Color.DarkGray, 1))
            {
                // X ekseni
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
                
                // Y ekseni
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Left, bounds.Top);
            }

            // Ölçeklendirme faktörleri
            float range = maxX - minX;
            float xScale = width / range;
            
            // Önce tüm bulanık kümelerin konturlarını çiz
            foreach (var fuzzySet in variable.FuzzySets)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(100, fuzzySet.DisplayColor), 1))
                {
                    // Grafiği değer aralığına göre ölçeklendir
                    // Bulanık kümenin çizim noktalarını al
                    List<PointF> points = fuzzySet.GetPointsForDrawing(minX, maxX, height, 200);
                    
                    // Noktaları ekran koordinatlarına dönüştür
                    for (int i = 0; i < points.Count; i++)
                    {
                        float x = (points[i].X - minX) * xScale + bounds.Left;
                        float y = bounds.Bottom - points[i].Y;
                        points[i] = new PointF(x, y);
                    }
                    
                    // Kontur çizgilerini çiz
                    if (points.Count > 1)
                    {
                        g.DrawLines(borderPen, points.ToArray());
                    }
                }
            }
            
            // Ateşlenen her bulanık küme için alan çiz
            foreach (var fuzzySet in variable.FuzzySets)
            {
                if (activationLevels.TryGetValue(fuzzySet.Name, out double activationLevel) && activationLevel > 0)
                {
                    using (Pen borderPen = new Pen(fuzzySet.DisplayColor, 1.5f))
                    using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(80, fuzzySet.DisplayColor)))
                    {
                        // Kesilmiş alanı hesapla
                        List<PointF> points = new List<PointF>();
                        
                        // Başlangıç noktası
                        points.Add(new PointF(bounds.Left, bounds.Bottom));
                        
                        // Üst eğri için noktaları hesapla
                        int numPoints = 100;
                        for (int i = 0; i <= numPoints; i++)
                        {
                            float x = minX + (range * i / numPoints);
                            float membershipDegree = (float)Math.Min(fuzzySet.GetMembershipDegree(x), activationLevel);
                            float screenX = (x - minX) * xScale + bounds.Left;
                            float screenY = bounds.Bottom - (membershipDegree * height);
                            points.Add(new PointF(screenX, screenY));
                        }
                        
                        // Bitiş noktası
                        points.Add(new PointF(bounds.Right, bounds.Bottom));
                        
                        // Alanı dolgu ile çiz
                        g.FillPolygon(fillBrush, points.ToArray());
                        
                        // Kesim çizgisi
                        g.DrawLine(new Pen(fuzzySet.DisplayColor, 1) { DashStyle = DashStyle.Dash }, 
                            bounds.Left, bounds.Bottom - (float)(activationLevel * height),
                            bounds.Right, bounds.Bottom - (float)(activationLevel * height));
                        
                        // Etiket
                        using (Font font = new Font("Segoe UI", 8))
                        {
                            string actText = fuzzySet.Name + ": " + activationLevel.ToString("0.00");
                            g.DrawString(actText, font, new SolidBrush(fuzzySet.DisplayColor), 
                                bounds.Left + 5, bounds.Bottom - (float)(activationLevel * height) - 15);
                        }
                    }
                }
            }

            // Koordinat etiketleri
            using (Font font = new Font("Segoe UI", 8))
            using (SolidBrush textBrush = new SolidBrush(Color.DarkSlateGray))
            {
                g.DrawString(variable.MinValue.ToString("0.0"), font, textBrush, bounds.Left, bounds.Bottom + 2);
                g.DrawString(variable.MaxValue.ToString("0.0"), font, textBrush, bounds.Right - 20, bounds.Bottom + 2);
                g.DrawString("0", font, textBrush, bounds.Left - 15, bounds.Bottom - 5);
                g.DrawString("1", font, textBrush, bounds.Left - 15, bounds.Top);
            }
        }

        // Durulaştırılmış çıkış değerini çizer
        public static void DrawDefuzzifiedValue(Graphics g, FuzzyVariable variable, double value, RectangleF bounds)
        {
            float width = bounds.Width;
            float height = bounds.Height;
            float minX = (float)variable.MinValue;
            float maxX = (float)variable.MaxValue;
            float range = maxX - minX;
            float xScale = width / range;

            // Değeri çiz
            float x = (float)((value - minX) * xScale + bounds.Left);
            using (Pen valuePen = new Pen(Color.Red, 2))
            {
                g.DrawLine(valuePen, x, bounds.Bottom, x, bounds.Top);

                // Ok başı
                const float arrowSize = 5;
                PointF[] arrowHead = new PointF[]
                {
                    new PointF(x, bounds.Top),
                    new PointF(x - arrowSize, bounds.Top + arrowSize * 2),
                    new PointF(x + arrowSize, bounds.Top + arrowSize * 2)
                };
                g.FillPolygon(Brushes.Red, arrowHead);
            }
            
            // Değer etiketini çiz
            using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.Red))
            {
                string valueText = value.ToString("0.00");
                SizeF textSize = g.MeasureString(valueText, font);
                g.DrawString(valueText, font, textBrush, x - textSize.Width / 2, bounds.Bottom - 20);
            }
        }

        // Bulanık küme alanlarını çizer (eski metod uyumluluk için tutuldu)
        public static void DrawFuzzyOutputArea(Graphics g, FuzzyVariable variable, Dictionary<string, double> activationLevels, RectangleF bounds)
        {
            DrawFuzzyOutputVariable(g, variable, bounds, activationLevels);
        }
    }
} 