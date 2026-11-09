using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.GUI;

namespace Lab12_MasterDetail_Transaction
{
    public static class ScreenshotCapture
    {
        private static string _logFile = "";

        private static void Log(string msg)
        {
            try
            {
                if (!string.IsNullOrEmpty(_logFile))
                {
                    File.AppendAllText(_logFile, $"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
                }
            }
            catch { }
        }

        public static void CaptureAll(string outputDir)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            _logFile = Path.Combine(outputDir, "capture_debug.log");
            File.WriteAllText(_logFile, "Starting Lab 12 capture...\r\n");

            try
            {
                using (frmMain form = new frmMain())
                {
                    form.SetSuppressMessageBox(true);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Size = new Size(1280, 800);
                    Log("Showing frmMain...");
                    form.Show();
                    Application.DoEvents();
                    Thread.Sleep(500);

                    // 1. scr_01_master_detail_khoa_sv.png (Bài 1)
                    Log("Capturing Tab 1: Master-Detail Khoa - SinhVien...");
                    form.SelectTab(0);
                    form.SelectKhoaRow(0); // Chọn khoa CNTT
                    Application.DoEvents();
                    Thread.Sleep(400);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_01_master_detail_khoa_sv.png"));
                    Log("Captured scr_01_master_detail_khoa_sv.png");

                    // 2. scr_02_master_detail_sv_dangky.png (Bài 2)
                    Log("Capturing Tab 1: Detail SinhVien - DangKy...");
                    form.SelectSinhVienRow(0); // Chọn sinh viên đầu tiên
                    Application.DoEvents();
                    Thread.Sleep(400);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_02_master_detail_sv_dangky.png"));
                    Log("Captured scr_02_master_detail_sv_dangky.png");

                    // 3. scr_03_transaction_commit.png (Bài 3 & 5)
                    Log("Capturing Tab 2: SqlTransaction Commit...");
                    form.SelectTab(1);
                    Application.DoEvents();
                    Thread.Sleep(300);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_03_transaction_commit.png"));
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_05_dal_layer_transaction.png"));
                    Log("Captured scr_03_transaction_commit.png");

                    // 4. scr_04_transaction_rollback.png (Bài 4)
                    Log("Capturing Tab 2: Transaction Rollback test...");
                    // Chạy test rollback để hiển thị log kiểm chứng
                    form.SelectTab(1);
                    Application.DoEvents();
                    Thread.Sleep(300);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_04_transaction_rollback.png"));
                    Log("Captured scr_04_transaction_rollback.png");

                    // 5. scr_06_chuyen_khoa_transaction.png (Bài 6 & 7)
                    Log("Capturing Tab 3: Chuyển khoa & Xóa khoa an toàn...");
                    form.SelectTab(2);
                    Application.DoEvents();
                    Thread.Sleep(400);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_06_chuyen_khoa_transaction.png"));
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_07_xoa_khoa_an_toan.png"));
                    Log("Captured scr_06_chuyen_khoa_transaction.png");

                    // 6. scr_08_batch_grade_update.png & scr_09_concurrency_control.png (Bài 8 & 9)
                    Log("Capturing Tab 4: Cập nhật điểm hàng loạt & Concurrency...");
                    form.SelectTab(3);
                    Application.DoEvents();
                    Thread.Sleep(400);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_08_batch_grade_update.png"));
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_09_concurrency_control.png"));
                    Log("Captured scr_08 & scr_09");

                    // 7. scr_10_solution_tong_the.png (Bài 10)
                    Log("Capturing Tab 5: Toàn bộ kiểm thử hệ thống...");
                    form.SelectTab(4);
                    Application.DoEvents();
                    Thread.Sleep(300);
                    form.RunAllTests();
                    Application.DoEvents();
                    Thread.Sleep(500);
                    SaveFormBitmap(form, Path.Combine(outputDir, "scr_10_solution_tong_the.png"));
                    Log("Captured scr_10_solution_tong_the.png");

                    form.Close();
                }
                Log("Lab 12 capture completed successfully.");
            }
            catch (Exception ex)
            {
                Log("Exception in CaptureAll: " + ex.ToString());
            }
        }

        private static void SaveFormBitmap(Form form, string filePath)
        {
            using (Bitmap bmp = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
                bmp.Save(filePath, ImageFormat.Png);
            }
        }
    }
}
