using System;
using System.Windows.Forms;

namespace OCR
{
    /// <summary>
    /// Uygulama giriş noktası
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası
        /// Windows formunu başlatarak OCR uygulamasını çalıştırır
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Ana form penceresini başlat
        }
    }
}