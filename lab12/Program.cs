using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.GUI;

namespace Lab12_MasterDetail_Transaction
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string outDir = @"c:\Users\USER\Downloads\orracle\lab12\screenshots";
            if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

            ApplicationConfiguration.Initialize();

            if (args != null && (args.Contains("--capture") || args.Contains("-c")))
            {
                try
                {
                    ScreenshotCapture.CaptureAll(outDir);
                }
                catch (Exception ex)
                {
                    File.WriteAllText(Path.Combine(outDir, "capture_error.txt"), ex.ToString());
                }
                return;
            }

            Application.Run(new frmMain());
        }
    }
}
