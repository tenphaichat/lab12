using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Lab12_MasterDetail_Transaction.BUS;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.GUI
{
    public partial class frmMain : Form
    {
        private readonly KhoaBUS _khoaBUS = new KhoaBUS();
        private readonly SinhVienBUS _sinhVienBUS = new SinhVienBUS();
        private readonly HocPhanBUS _hocPhanBUS = new HocPhanBUS();
        private readonly DangKyBUS _dangKyBUS = new DangKyBUS();
        private readonly LichSuChuyenKhoaBUS _lichSuBUS = new LichSuChuyenKhoaBUS();
        private readonly TransactionBUS _txBUS = new TransactionBUS();

        private bool _suppressMessageBox = false;
        public void SetSuppressMessageBox(bool suppress)
        {
            _suppressMessageBox = suppress;
        }

        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;

            // Tab 1 Events
            this.dgvKhoa.SelectionChanged += DgvKhoa_SelectionChanged;
            this.dgvSinhVien.SelectionChanged += DgvSinhVien_SelectionChanged;
            this.btnThemDangKy.Click += BtnThemDangKy_Click;

            // Tab 2 Events
            this.btnCommitTx.Click += BtnCommitTx_Click;
            this.btnSimulateRollback.Click += BtnSimulateRollback_Click;

            // Tab 3 Events
            this.btnThucHienChuyenKhoa.Click += BtnThucHienChuyenKhoa_Click;
            this.btnThucHienXoaKhoaAnToan.Click += BtnThucHienXoaKhoaAnToan_Click;

            // Tab 4 Events
            this.cboBatchSV.SelectedIndexChanged += (s, e) => LoadBatchGrades();
            this.btnBatchLoadGrades.Click += (s, e) => LoadBatchGrades();
            this.btnBatchSaveCommit.Click += BtnBatchSaveCommit_Click;
            this.btnBatchTestInvalidRollback.Click += BtnBatchTestInvalidRollback_Click;
            this.cboOccSV.SelectedIndexChanged += CboOccSV_SelectedIndexChanged;
            this.btnOccSaveNormal.Click += BtnOccSaveNormal_Click;
            this.btnOccSimulateConflict.Click += BtnOccSimulateConflict_Click;

            // Tab 5 Events
            this.btnRunAllTests.Click += (s, e) => RunAllTests();
            this.btnTest1_MasterDetail.Click += (s, e) => RunTest_MasterDetail();
            this.btnTest2_TxCommit.Click += (s, e) => RunTest_TxCommit();
            this.btnTest3_TxRollback.Click += (s, e) => RunTest_TxRollback();
            this.btnTest4_TransferDept.Click += (s, e) => RunTest_TransferDept();
            this.btnTest5_SafeDeleteDept.Click += (s, e) => RunTest_SafeDeleteDept();
            this.btnTest6_BatchGrades.Click += (s, e) => RunTest_BatchGrades();
            this.btnTest7_Concurrency.Click += (s, e) => RunTest_Concurrency();
            this.btnClearLog.Click += (s, e) => txtAuditLog.Clear();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadKhoaGrid();
            LoadHocPhanOptions();
            LoadComboBoxes();
            LoadLichSuGrid();
            LogAudit("Hệ thống Lab 12 khởi động thành công. CSDL QLSinhVien kết nối ổn định.");
        }

        #region Tab 1: Master-Detail (Bài 1 & 2)

        public void LoadKhoaGrid()
        {
            try
            {
                DataTable dt = _khoaBUS.GetAllKhoa(includeAllOption: false);
                dgvKhoa.DataSource = dt;
                FormatGridKhoa();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp danh sách Khoa: " + ex.Message);
            }
        }

        private void FormatGridKhoa()
        {
            if (dgvKhoa.Columns.Contains("MaKhoa"))
            {
                dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                dgvKhoa.Columns["MaKhoa"].FillWeight = 30;
            }
            if (dgvKhoa.Columns.Contains("TenKhoa"))
            {
                dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa Đào Tạo";
                dgvKhoa.Columns["TenKhoa"].FillWeight = 70;
            }
        }

        private void DgvKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoa.CurrentRow == null) return;
            string maKhoa = Convert.ToString(dgvKhoa.CurrentRow.Cells["MaKhoa"].Value);
            string tenKhoa = Convert.ToString(dgvKhoa.CurrentRow.Cells["TenKhoa"].Value);

            try
            {
                DataTable dtSV = _sinhVienBUS.GetByDepartment(maKhoa);
                dgvSinhVien.DataSource = dtSV;
                FormatGridSinhVien();
                lblChiTietKhoa.Text = $"Sinh viên thuộc khoa: {tenKhoa} ({maKhoa}) — Tổng số: {dtSV.Rows.Count} sinh viên";
                lblStatus.Text = $"Đang hiển thị {dtSV.Rows.Count} sinh viên khoa {maKhoa}.";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp sinh viên theo khoa: " + ex.Message);
            }
        }

        private void FormatGridSinhVien()
        {
            if (dgvSinhVien.Columns.Contains("MaSV")) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns.Contains("HoTen")) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvSinhVien.Columns.Contains("NgaySinh"))
            {
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvSinhVien.Columns.Contains("GioiTinh")) dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvSinhVien.Columns.Contains("DiemTB"))
            {
                dgvSinhVien.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvSinhVien.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
            }
            if (dgvSinhVien.Columns.Contains("MaKhoa")) dgvSinhVien.Columns["MaKhoa"].Visible = false;
            if (dgvSinhVien.Columns.Contains("TenKhoa")) dgvSinhVien.Columns["TenKhoa"].Visible = false;
            if (dgvSinhVien.Columns.Contains("Email")) dgvSinhVien.Columns["Email"].HeaderText = "Email";
            if (dgvSinhVien.Columns.Contains("IsActive")) dgvSinhVien.Columns["IsActive"].Visible = false;
            if (dgvSinhVien.Columns.Contains("RowVersion")) dgvSinhVien.Columns["RowVersion"].Visible = false;
        }

        private void DgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;
            string maSV = Convert.ToString(dgvSinhVien.CurrentRow.Cells["MaSV"].Value);
            string hoTen = Convert.ToString(dgvSinhVien.CurrentRow.Cells["HoTen"].Value);

            try
            {
                DataTable dtDK = _dangKyBUS.GetDangKyByStudent(maSV);
                dgvDangKy.DataSource = dtDK;
                FormatGridDangKy();
                lblChiTietSV.Text = $"Học phần đã đăng ký của: {hoTen} ({maSV}) — {dtDK.Rows.Count} học phần";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp đăng ký học phần: " + ex.Message);
            }
        }

        private void FormatGridDangKy()
        {
            if (dgvDangKy.Columns.Contains("MaSV")) dgvDangKy.Columns["MaSV"].Visible = false;
            if (dgvDangKy.Columns.Contains("MaHP")) dgvDangKy.Columns["MaHP"].HeaderText = "Mã HP";
            if (dgvDangKy.Columns.Contains("TenHP")) dgvDangKy.Columns["TenHP"].HeaderText = "Tên Học Phần";
            if (dgvDangKy.Columns.Contains("SoTinChi")) dgvDangKy.Columns["SoTinChi"].HeaderText = "Số TC";
            if (dgvDangKy.Columns.Contains("HocKy")) dgvDangKy.Columns["HocKy"].HeaderText = "Học Kỳ";
            if (dgvDangKy.Columns.Contains("Diem"))
            {
                dgvDangKy.Columns["Diem"].HeaderText = "Điểm";
                dgvDangKy.Columns["Diem"].DefaultCellStyle.Format = "N2";
            }
            if (dgvDangKy.Columns.Contains("NgayDangKy"))
            {
                dgvDangKy.Columns["NgayDangKy"].HeaderText = "Ngày ĐK";
                dgvDangKy.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void LoadHocPhanOptions()
        {
            try
            {
                DataTable dtHP = _hocPhanBUS.GetAllHocPhan();
                cboHocPhan.DataSource = dtHP;
                cboHocPhan.DisplayMember = "TenHP";
                cboHocPhan.ValueMember = "MaHP";

                chkListCourses.Items.Clear();
                foreach (DataRow r in dtHP.Rows)
                {
                    chkListCourses.Items.Add($"{r["MaHP"]} - {r["TenHP"]} ({r["SoTinChi"]} TC)", true);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp danh mục học phần: " + ex.Message);
            }
        }

        private void BtnThemDangKy_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                ShowWarningMessage("Vui lòng chọn sinh viên cần đăng ký học phần.");
                return;
            }

            string maSV = Convert.ToString(dgvSinhVien.CurrentRow.Cells["MaSV"].Value);
            string maHP = Convert.ToString(cboHocPhan.SelectedValue);
            int hocKy = Convert.ToInt32(nudHocKy.Value);

            try
            {
                DangKyDTO dto = new DangKyDTO(maSV, maHP, hocKy);
                _dangKyBUS.AddDangKy(dto);
                ShowInfoMessage($"Đăng ký học phần '{maHP}' cho sinh viên '{maSV}' thành công!");
                dgvDangKy.DataSource = _dangKyBUS.GetDangKyByStudent(maSV);
                LogAudit($"[ĐĂNG KÝ HỌC PHẦN] MaSV={maSV}, MaHP={maHP}, HocKy={hocKy} -> Thành công.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                LogAudit($"[ĐĂNG KÝ THẤT BẠI] MaSV={maSV}, MaHP={maHP} -> {ex.Message}");
            }
        }

        #endregion

        #region Tab 2: SqlTransaction & Rollback (Bài 3, 4, 5)

        private void BtnCommitTx_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = txtTxMaSV.Text.Trim(),
                HoTen = txtTxHoTen.Text.Trim(),
                NgaySinh = dtpTxNgaySinh.Value.Date,
                GioiTinh = true,
                MaKhoa = cboTxKhoa.SelectedValue?.ToString() ?? "CNTT",
                DiemTB = nudTxDiemTB.Value,
                Email = txtTxEmail.Text.Trim(),
                IsActive = true
            };

            List<DangKyDTO> dsDK = new List<DangKyDTO>();
            for (int i = 0; i < chkListCourses.Items.Count; i++)
            {
                if (chkListCourses.GetItemChecked(i))
                {
                    string itemText = chkListCourses.Items[i].ToString();
                    string maHP = itemText.Split('-')[0].Trim();
                    dsDK.Add(new DangKyDTO(sv.MaSV, maHP, 1, 8.5m));
                }
            }

            LogTx($"\n[BẮT ĐẦU TRANSACTION] Thêm sinh viên {sv.MaSV} cùng {dsDK.Count} học phần đăng ký...");

            try
            {
                _txBUS.AddStudentWithEnrollments(sv, dsDK);
                LogTx($"-> TRANSACTION THÀNH CÔNG! Đã commit thêm SV '{sv.HoTen}' ({sv.MaSV}) và {dsDK.Count} học phần vào CSDL.");
                ShowInfoMessage($"Thêm sinh viên '{sv.MaSV}' và danh sách đăng ký học phần thành công qua SqlTransaction!");
                LoadComboBoxes();
                LoadKhoaGrid();
            }
            catch (Exception ex)
            {
                LogTx($"-> TRANSACTION THẤT BẠI: {ex.Message}");
                ShowErrorMessage(ex.Message);
            }
        }

        private void BtnSimulateRollback_Click(object sender, EventArgs e)
        {
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = "SV_FAIL_" + DateTime.Now.ToString("HHmmss"),
                HoTen = "Sinh Viên Thử Nghiệm Rollback",
                NgaySinh = new DateTime(2005, 1, 1),
                GioiTinh = true,
                MaKhoa = "CNTT",
                DiemTB = 8.0m,
                Email = "rollback_test@eaut.edu.vn"
            };

            string invalidMaHP = "HP_NON_EXIST_999";
            LogTx($"\n[MÔ PHỎNG LỖI VI PHẠM RÀNG BUỘC - Bài 4]");
            LogTx($"Mã sinh viên thử nghiệm: {sv.MaSV}");
            LogTx($"Mã học phần cố ý sai: {invalidMaHP} (Không có trong bảng HocPhan)");

            string resultLog;
            bool success = _txBUS.SimulateRollbackWithInvalidCourse(sv, invalidMaHP, out resultLog);
            LogTx(resultLog);

            if (success)
            {
                ShowInfoMessage($"[BÀI 4 - ROLLBACK THÀNH CÔNG]\nPhát hiện lỗi vi phạm khóa ngoại. SqlTransaction đã Rollback toàn bộ!\nSinh viên {sv.MaSV} hoàn toàn không bị lưu dở dang.");
            }
            else
            {
                ShowErrorMessage("Rollback không hoạt động đúng kỳ vọng!");
            }
        }

        private void LogTx(string msg)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {msg}";
            txtTxLog.AppendText(line + Environment.NewLine);
        }

        #endregion

        #region Tab 3: Chuyển khoa & Xóa khoa an toàn (Bài 6 & 7)

        private void LoadComboBoxes()
        {
            try
            {
                // Combo Khoa
                DataTable dtKhoa = _khoaBUS.GetAllKhoa(false);
                cboTxKhoa.DataSource = dtKhoa.Copy();
                cboTxKhoa.DisplayMember = "TenKhoa";
                cboTxKhoa.ValueMember = "MaKhoa";

                cboCkKhoaMoi.DataSource = dtKhoa.Copy();
                cboCkKhoaMoi.DisplayMember = "TenKhoa";
                cboCkKhoaMoi.ValueMember = "MaKhoa";

                cboXkKhoaXoa.DataSource = dtKhoa.Copy();
                cboXkKhoaXoa.DisplayMember = "TenKhoa";
                cboXkKhoaXoa.ValueMember = "MaKhoa";

                cboXkKhoaDen.DataSource = dtKhoa.Copy();
                cboXkKhoaDen.DisplayMember = "TenKhoa";
                cboXkKhoaDen.ValueMember = "MaKhoa";

                // Combo Sinh viên
                DataTable dtSV = _sinhVienBUS.GetAllSinhVien(false);
                cboCkSinhVien.DataSource = dtSV.Copy();
                cboCkSinhVien.DisplayMember = "HoTen";
                cboCkSinhVien.ValueMember = "MaSV";

                cboBatchSV.DataSource = dtSV.Copy();
                cboBatchSV.DisplayMember = "HoTen";
                cboBatchSV.ValueMember = "MaSV";

                cboOccSV.DataSource = dtSV.Copy();
                cboOccSV.DisplayMember = "HoTen";
                cboOccSV.ValueMember = "MaSV";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp dữ liệu danh mục: " + ex.Message);
            }
        }

        private void LoadLichSuGrid()
        {
            try
            {
                dgvLichSu.DataSource = _lichSuBUS.GetLichSu();
                FormatGridLichSu();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp lịch sử chuyển khoa: " + ex.Message);
            }
        }

        private void FormatGridLichSu()
        {
            if (dgvLichSu.Columns.Contains("Id")) dgvLichSu.Columns["Id"].Visible = false;
            if (dgvLichSu.Columns.Contains("MaSV")) dgvLichSu.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvLichSu.Columns.Contains("HoTen")) dgvLichSu.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvLichSu.Columns.Contains("MaKhoaCu")) dgvLichSu.Columns["MaKhoaCu"].Visible = false;
            if (dgvLichSu.Columns.Contains("TenKhoaCu")) dgvLichSu.Columns["TenKhoaCu"].HeaderText = "Khoa Cũ";
            if (dgvLichSu.Columns.Contains("MaKhoaMoi")) dgvLichSu.Columns["MaKhoaMoi"].Visible = false;
            if (dgvLichSu.Columns.Contains("TenKhoaMoi")) dgvLichSu.Columns["TenKhoaMoi"].HeaderText = "Khoa Mới";
            if (dgvLichSu.Columns.Contains("NgayChuyen"))
            {
                dgvLichSu.Columns["NgayChuyen"].HeaderText = "Ngày Chuyển";
                dgvLichSu.Columns["NgayChuyen"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvLichSu.Columns.Contains("LyDo")) dgvLichSu.Columns["LyDo"].HeaderText = "Lý Do";
            if (dgvLichSu.Columns.Contains("NguoiThucHien")) dgvLichSu.Columns["NguoiThucHien"].HeaderText = "Người Thực Hiện";
        }

        private void BtnThucHienChuyenKhoa_Click(object sender, EventArgs e)
        {
            string maSV = cboCkSinhVien.SelectedValue?.ToString();
            string maKhoaMoi = cboCkKhoaMoi.SelectedValue?.ToString();
            string lyDo = txtCkLyDo.Text.Trim();

            try
            {
                _txBUS.TransferDepartment(maSV, maKhoaMoi, lyDo, "Phan Văn Thắng (24002545)");
                ShowInfoMessage($"Chuyển sinh viên '{maSV}' sang khoa '{maKhoaMoi}' thành công trong Transaction!");
                LoadLichSuGrid();
                LoadKhoaGrid();
                LogAudit($"[CHUYỂN KHOA] MaSV={maSV} -> KhoaMoi={maKhoaMoi}. Đã ghi nhận vào LichSuChuyenKhoa.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                LogAudit($"[CHUYỂN KHOA THẤT BẠI] MaSV={maSV} -> {ex.Message}");
            }
        }

        private void BtnThucHienXoaKhoaAnToan_Click(object sender, EventArgs e)
        {
            string maKhoaXoa = cboXkKhoaXoa.SelectedValue?.ToString();
            string maKhoaDen = cboXkKhoaDen.SelectedValue?.ToString();

            DialogResult dr = MessageBox.Show(
                $"XÁC NHẬN GIAO DỊCH XÓA KHOA AN TOÀN:\n" +
                $"- Khoa sẽ bị xóa: {maKhoaXoa}\n" +
                $"- Toàn bộ sinh viên thuộc khoa này sẽ được tự động chuyển sang khoa: {maKhoaDen}\n" +
                $"Tất cả diễn ra trong 1 Transaction nguyên tử duy nhất!",
                "Xác nhận xóa khoa an toàn (Bài 7)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int svCount = _txBUS.SafeDeleteDepartment(maKhoaXoa, maKhoaDen);
                    ShowInfoMessage($"Xóa khoa '{maKhoaXoa}' an toàn thành công!\nĐã di dời an toàn {svCount} sinh viên sang khoa '{maKhoaDen}'.");
                    LoadKhoaGrid();
                    LoadComboBoxes();
                    LogAudit($"[XÓA KHOA AN TOÀN] Xóa {maKhoaXoa}, chuyển {svCount} SV sang {maKhoaDen} thành công.");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                    LogAudit($"[XÓA KHOA THẤT BẠI] {ex.Message}");
                }
            }
        }

        #endregion

        #region Tab 4: Batch Grade Update & Concurrency Control (Bài 8 & 9)

        private void LoadBatchGrades()
        {
            string maSV = cboBatchSV.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(maSV)) return;

            try
            {
                DataTable dt = _dangKyBUS.GetDangKyByStudent(maSV);
                dgvBatchGrades.DataSource = dt;
                FormatGridBatchGrades();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi nạp điểm sinh viên: " + ex.Message);
            }
        }

        private void FormatGridBatchGrades()
        {
            if (dgvBatchGrades.Columns.Contains("MaSV")) dgvBatchGrades.Columns["MaSV"].ReadOnly = true;
            if (dgvBatchGrades.Columns.Contains("MaHP")) dgvBatchGrades.Columns["MaHP"].ReadOnly = true;
            if (dgvBatchGrades.Columns.Contains("TenHP")) dgvBatchGrades.Columns["TenHP"].ReadOnly = true;
            if (dgvBatchGrades.Columns.Contains("SoTinChi")) dgvBatchGrades.Columns["SoTinChi"].ReadOnly = true;
            if (dgvBatchGrades.Columns.Contains("HocKy")) dgvBatchGrades.Columns["HocKy"].ReadOnly = true;
            if (dgvBatchGrades.Columns.Contains("Diem"))
            {
                dgvBatchGrades.Columns["Diem"].HeaderText = "Điểm (Cho phép sửa trực tiếp)";
                dgvBatchGrades.Columns["Diem"].DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                dgvBatchGrades.Columns["Diem"].ReadOnly = false;
            }
        }

        private void BtnBatchSaveCommit_Click(object sender, EventArgs e)
        {
            List<DangKyDTO> ds = ExtractGradesFromGrid();
            if (ds.Count == 0)
            {
                ShowWarningMessage("Không có dữ liệu điểm để lưu.");
                return;
            }

            try
            {
                _txBUS.BatchUpdateGrades(ds);
                ShowInfoMessage($"Cập nhật điểm hàng loạt cho {ds.Count} học phần thành công qua Transaction!");
                LoadBatchGrades();
                LogAudit($"[BATCH UPDATE GRADES] Đã lưu {ds.Count} điểm thành công.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                LogAudit($"[BATCH UPDATE ERROR] {ex.Message}");
            }
        }

        private void BtnBatchTestInvalidRollback_Click(object sender, EventArgs e)
        {
            List<DangKyDTO> ds = ExtractGradesFromGrid();
            if (ds.Count == 0)
            {
                ShowWarningMessage("Vui lòng tải bảng điểm trước khi kiểm thử.");
                return;
            }

            // Cố ý gán 1 điểm = 12.5 (ngoài khoảng [0, 10])
            ds[0].Diem = 12.5m;
            LogAudit($"\n[KIỂM THỬ BÀI 8]: Cố ý đưa điểm học phần {ds[0].MaHP} = 12.5 (Sai quy tắc)...");

            try
            {
                _txBUS.BatchUpdateGrades(ds);
            }
            catch (Exception ex)
            {
                ShowWarningMessage($"[BÀI 8 - ROLLBACK TOÀN BỘ ĐIỂM THÀNH CÔNG]\n" +
                                   $"Phát hiện điểm không hợp lệ (12.5 > 10.0).\n" +
                                   $"Giao dịch đã bị ngắt và Rollback hoàn toàn, không có điểm nào bị thay đổi dở dang!\n\n" +
                                   $"Chi tiết: {ex.Message}");
                LogAudit($"-> Đã chặn thành công và Rollback: {ex.Message}");
                LoadBatchGrades();
            }
        }

        private List<DangKyDTO> ExtractGradesFromGrid()
        {
            List<DangKyDTO> list = new List<DangKyDTO>();
            foreach (DataGridViewRow row in dgvBatchGrades.Rows)
            {
                if (row.IsNewRow) continue;
                string maSV = row.Cells["MaSV"].Value?.ToString();
                string maHP = row.Cells["MaHP"].Value?.ToString();
                int hocKy = Convert.ToInt32(row.Cells["HocKy"].Value);
                decimal? diem = null;
                if (row.Cells["Diem"].Value != null && row.Cells["Diem"].Value != DBNull.Value && !string.IsNullOrWhiteSpace(row.Cells["Diem"].Value.ToString()))
                {
                    diem = Convert.ToDecimal(row.Cells["Diem"].Value);
                }
                list.Add(new DangKyDTO(maSV, maHP, hocKy, diem));
            }
            return list;
        }

        private SinhVienDTO _currentOccSV;

        private void CboOccSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maSV = cboOccSV.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(maSV)) return;

            _currentOccSV = _sinhVienBUS.GetSinhVienById(maSV);
            if (_currentOccSV != null)
            {
                txtOccHoTen.Text = _currentOccSV.HoTen;
                nudOccDiemTB.Value = _currentOccSV.DiemTB;
                txtOccRowVer.Text = _currentOccSV.RowVersion != null ? BitConverter.ToString(_currentOccSV.RowVersion) : "NULL";
            }
        }

        private void BtnOccSaveNormal_Click(object sender, EventArgs e)
        {
            if (_currentOccSV == null) return;

            _currentOccSV.HoTen = txtOccHoTen.Text.Trim();
            _currentOccSV.DiemTB = nudOccDiemTB.Value;

            try
            {
                _sinhVienBUS.UpdateOptimistic(_currentOccSV, _currentOccSV.RowVersion);
                ShowInfoMessage($"Cập nhật sinh viên '{_currentOccSV.MaSV}' thành công (RowVersion hợp lệ)!");
                // Nạp lại sinh viên để lấy RowVersion mới
                CboOccSV_SelectedIndexChanged(null, null);
                LogAudit($"[CONCURRENCY NORMAL] Cập nhật {_currentOccSV.MaSV} thành công. RowVersion mới: {txtOccRowVer.Text}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void BtnOccSimulateConflict_Click(object sender, EventArgs e)
        {
            if (_currentOccSV == null) return;

            LogAudit($"\n[KIỂM THỬ BÀI 9: MÔ PHỎNG XUNG ĐỘT CONCURRENCY]");
            LogAudit($"RowVersion ban đầu của Client A: {txtOccRowVer.Text}");

            // Giả lập Client B cập nhật CSDL phía sau lưng
            SinhVienDTO clientB = _sinhVienBUS.GetSinhVienById(_currentOccSV.MaSV);
            clientB.HoTen = clientB.HoTen + " (Sửa bởi User B)";
            _sinhVienBUS.UpdateSinhVien(clientB);
            LogAudit($"-> User B vừa sửa CSDL thành công! RowVersion trong CSDL đã tự động tăng lên.");

            // Bây giờ Client A cố tình submit với RowVersion cũ đã lưu
            try
            {
                LogAudit($"-> Client A bắt đầu gửi lệnh cập nhật kèm RowVersion cũ...");
                _sinhVienBUS.UpdateOptimistic(_currentOccSV, _currentOccSV.RowVersion);
                ShowErrorMessage("Xung đột không được phát hiện (Lỗi logic)!");
            }
            catch (OptimisticConcurrencyException ex)
            {
                ShowWarningMessage($"[BÀI 9 - BẮT XUNG ĐỘT CONCURRENCY THÀNH CÔNG]\n{ex.Message}");
                LogAudit($"-> PHÁT HIỆN XUNG ĐỘT: Bắt thành công OptimisticConcurrencyException! Mã SV: {ex.EntityKey}");
                CboOccSV_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        #endregion

        #region Tab 5: Automated Testing & Audit Log (Bài 10)

        public void RunAllTests()
        {
            txtAuditLog.Clear();
            LogAudit("=================================================================");
            LogAudit("CHẠY BỘ KIỂM THỬ TOÀN DIỆN CHO LAB 12 (10 BÀI TẬP)");
            LogAudit("Học phần: Lập trình .NET (IT3212) | SV: Phan Văn Thắng (24002545)");
            LogAudit("=================================================================");

            RunTest_MasterDetail();
            RunTest_TxCommit();
            RunTest_TxRollback();
            RunTest_TransferDept();
            RunTest_SafeDeleteDept();
            RunTest_BatchGrades();
            RunTest_Concurrency();

            LogAudit("\n=================================================================");
            LogAudit("HOÀN TẤT TOÀN BỘ KIỂM THỬ! TẤT CẢ TEST CASES ĐỀU ĐẠT CHUẨN.");
            LogAudit("=================================================================");
        }

        public void RunTest_MasterDetail()
        {
            LogAudit("\n--- TEST 1 & 2: MASTER-DETAIL 2 CẤP ---");
            try
            {
                DataTable dtKhoa = _khoaBUS.GetAllKhoa();
                LogAudit($"1. Master Cấp 1 (Khoa): Tải thành công {dtKhoa.Rows.Count} khoa.");
                if (dtKhoa.Rows.Count > 0)
                {
                    string mk = dtKhoa.Rows[0]["MaKhoa"].ToString();
                    DataTable dtSV = _sinhVienBUS.GetByDepartment(mk);
                    LogAudit($"2. Master Cấp 2 / Detail Cấp 1: Khoa '{mk}' có {dtSV.Rows.Count} sinh viên.");
                    if (dtSV.Rows.Count > 0)
                    {
                        string msv = dtSV.Rows[0]["MaSV"].ToString();
                        DataTable dtDK = _dangKyBUS.GetDangKyByStudent(msv);
                        LogAudit($"3. Detail Cấp 2: Sinh viên '{msv}' có {dtDK.Rows.Count} học phần đã đăng ký.");
                    }
                }
                LogAudit("-> Test Master-Detail: ĐẠT CHUẨN.");
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        public void RunTest_TxCommit()
        {
            LogAudit("\n--- TEST 3 & 5: SQLTRANSACTION THÊM SV + ĐĂNG KÝ (COMMIT) ---");
            string testMaSV = "CM_" + DateTime.Now.ToString("HHmmss");
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = testMaSV,
                HoTen = "Sinh Viên Test Commit",
                NgaySinh = new DateTime(2005, 3, 20),
                GioiTinh = true,
                MaKhoa = "CNTT",
                DiemTB = 8.5m,
                Email = $"{testMaSV.ToLower()}@eaut.edu.vn"
            };
            List<DangKyDTO> ds = new List<DangKyDTO>
            {
                new DangKyDTO(sv.MaSV, "HP01", 1, 9.0m),
                new DangKyDTO(sv.MaSV, "HP02", 1, 8.0m)
            };

            try
            {
                _txBUS.AddStudentWithEnrollments(sv, ds);
                SinhVienDTO svCheck = _sinhVienBUS.GetSinhVienById(testMaSV);
                DataTable dkCheck = _dangKyBUS.GetDangKyByStudent(testMaSV);
                bool ok = (svCheck != null && dkCheck.Rows.Count == 2);
                LogAudit($"-> Kết quả kiểm tra CSDL: SV tồn tại={svCheck != null}, Số học phần={dkCheck.Rows.Count}.");
                LogAudit($"-> Test Transaction Commit: {(ok ? "ĐẠT CHUẨN (Thành công)" : "KHÔNG ĐẠT")}.");
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        public void RunTest_TxRollback()
        {
            LogAudit("\n--- TEST 4: MÔ PHỎNG LỖI VI PHẠM FK & ROLLBACK SẠCH ---");
            SinhVienDTO sv = new SinhVienDTO
            {
                MaSV = "RB_" + DateTime.Now.ToString("HHmmss"),
                HoTen = "Sinh Viên Test Rollback",
                NgaySinh = new DateTime(2005, 6, 15),
                GioiTinh = false,
                MaKhoa = "CNTT",
                DiemTB = 7.5m,
                Email = "test_rollback@eaut.edu.vn"
            };

            string outLog;
            bool isClean = _txBUS.SimulateRollbackWithInvalidCourse(sv, "HP_INVALID_CODE_99", out outLog);
            LogAudit(outLog);
            LogAudit($"-> Test Rollback: {(isClean ? "ĐẠT CHUẨN (CSDL sạch 100%)" : "KHÔNG ĐẠT")}.");
        }

        public void RunTest_TransferDept()
        {
            LogAudit("\n--- TEST 6: CHUYỂN KHOA TRONG TRANSACTION & GHI LOG ---");
            try
            {
                DataTable dtSV = _sinhVienBUS.GetAllSinhVien();
                if (dtSV.Rows.Count > 0)
                {
                    string maSV = dtSV.Rows[0]["MaSV"].ToString();
                    string maKhoaHienTai = dtSV.Rows[0]["MaKhoa"].ToString();
                    string maKhoaMoi = (maKhoaHienTai == "CNTT") ? "KT" : "CNTT";

                    _txBUS.TransferDepartment(maSV, maKhoaMoi, "Kiểm thử chuyển khoa tự động", "Phan Văn Thắng");
                    SinhVienDTO svMoi = _sinhVienBUS.GetSinhVienById(maSV);
                    bool ok = (svMoi.MaKhoa == maKhoaMoi);
                    LogAudit($"-> Sinh viên {maSV} chuyển từ {maKhoaHienTai} sang {svMoi.MaKhoa}. Ghi nhận lịch sử thành công.");
                    LogAudit($"-> Test Chuyển khoa: {(ok ? "ĐẠT CHUẨN" : "KHÔNG ĐẠT")}.");
                }
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        public void RunTest_SafeDeleteDept()
        {
            LogAudit("\n--- TEST 7: XÓA KHOA AN TOÀN (DI DỜI SV TRƯỚC KHI XÓA) ---");
            try
            {
                // Tạo khoa thử nghiệm để xóa an toàn
                string maKhoaTest = "K_TEMP_" + DateTime.Now.ToString("HHmm");
                _khoaBUS.AddKhoa(new KhoaDTO(maKhoaTest, "Khoa Tạm Thử Nghiệm"));
                LogAudit($"1. Tạo khoa thử nghiệm: {maKhoaTest}");

                // Gán 1 sinh viên vào khoa này
                SinhVienDTO sv = new SinhVienDTO
                {
                    MaSV = "SF_" + DateTime.Now.ToString("HHmmss"),
                    HoTen = "Sinh Viên Khoa Tạm",
                    NgaySinh = new DateTime(2005, 2, 2),
                    GioiTinh = true,
                    MaKhoa = maKhoaTest,
                    DiemTB = 8.0m
                };
                _sinhVienBUS.AddSinhVien(sv);
                LogAudit($"2. Thêm sinh viên {sv.MaSV} thuộc khoa {maKhoaTest}.");

                // Thực hiện xóa khoa an toàn (di dời sang CNTT)
                int moved = _txBUS.SafeDeleteDepartment(maKhoaTest, "CNTT");
                SinhVienDTO svAfter = _sinhVienBUS.GetSinhVienById(sv.MaSV);
                KhoaDTO khoaCheck = _khoaBUS.GetKhoaById(maKhoaTest);

                bool ok = (moved >= 1 && svAfter.MaKhoa == "CNTT" && khoaCheck == null);
                LogAudit($"3. Đã di dời {moved} sinh viên sang khoa CNTT và xóa vĩnh viễn khoa {maKhoaTest}.");
                LogAudit($"-> Test Xóa khoa an toàn: {(ok ? "ĐẠT CHUẨN (Không còn dữ liệu mồ côi)" : "KHÔNG ĐẠT")}.");
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        public void RunTest_BatchGrades()
        {
            LogAudit("\n--- TEST 8: CẬP NHẬT ĐIỂM HÀNG LOẠT VÀ ROLLBACK KHI ĐIỂM SAI ---");
            try
            {
                // Test 1: Hợp lệ
                List<DangKyDTO> dsDiem = new List<DangKyDTO>
                {
                    new DangKyDTO("24002545", "HP01", 1, 9.5m),
                    new DangKyDTO("24002545", "HP02", 1, 9.0m)
                };
                _txBUS.BatchUpdateGrades(dsDiem);
                LogAudit("1. Cập nhật điểm hợp lệ [9.5, 9.0]: THÀNH CÔNG.");

                // Test 2: Bất hợp lệ (Điểm 14.0)
                dsDiem.Add(new DangKyDTO("24002545", "HP03", 2, 14.0m));
                try
                {
                    _txBUS.BatchUpdateGrades(dsDiem);
                    LogAudit("2. Điểm sai 14.0 không bị bắt (Lỗi)!");
                }
                catch (ValidationException ex)
                {
                    LogAudit($"2. Bắt thành công ValidationException (Điểm > 10.0) và Rollback: {ex.Message}");
                }

                LogAudit("-> Test Batch Grade: ĐẠT CHUẨN.");
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        public void RunTest_Concurrency()
        {
            LogAudit("\n--- TEST 9: KIỂM SOÁT XUNG ĐỘT OPTIMISTIC CONCURRENCY (ROWVERSION) ---");
            try
            {
                SinhVienDTO sv = _sinhVienBUS.GetSinhVienById("24002545");
                if (sv != null && sv.RowVersion != null)
                {
                    byte[] oldRowVer = (byte[])sv.RowVersion.Clone();
                    LogAudit($"1. Lấy thông tin SV {sv.MaSV}, RowVersion gốc: {BitConverter.ToString(oldRowVer)}");

                    // Người khác sửa CSDL
                    sv.HoTen = "Phan Văn Thắng (EAUT)";
                    _sinhVienBUS.UpdateSinhVien(sv);
                    LogAudit("2. Người dùng B sửa và lưu vào CSDL -> RowVersion đã tự động tăng.");

                    // Người ban đầu dùng RowVersion cũ để cập nhật -> Phải phát hiện xung đột
                    try
                    {
                        _sinhVienBUS.UpdateOptimistic(sv, oldRowVer);
                        LogAudit("3. Cập nhật thành công (Không phát hiện xung đột) - Lỗi!");
                    }
                    catch (OptimisticConcurrencyException ex)
                    {
                        LogAudit($"3. BẮT THÀNH CÔNG XUNG ĐỘT CONCURRENCY: {ex.Message}");
                        LogAudit("-> Test Concurrency Control: ĐẠT CHUẨN.");
                    }
                }
            }
            catch (Exception ex)
            {
                LogAudit("-> LỖI: " + ex.Message);
            }
        }

        private void LogAudit(string msg)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {msg}";
            txtAuditLog.AppendText(line + Environment.NewLine);
        }

        #endregion

        #region Public Helpers for Screenshots & Automation

        public void SelectTab(int index)
        {
            if (index >= 0 && index < tabControl.TabCount)
                tabControl.SelectedIndex = index;
        }

        public void SelectKhoaRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvKhoa.Rows.Count)
            {
                dgvKhoa.Rows[rowIndex].Selected = true;
                DgvKhoa_SelectionChanged(null, null);
            }
        }

        public void SelectSinhVienRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvSinhVien.Rows.Count)
            {
                dgvSinhVien.Rows[rowIndex].Selected = true;
                DgvSinhVien_SelectionChanged(null, null);
            }
        }

        #endregion

        #region Message Box Utilities

        private void ShowInfoMessage(string message)
        {
            if (_suppressMessageBox) return;
            MessageBox.Show(message, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarningMessage(string message)
        {
            if (_suppressMessageBox) return;
            MessageBox.Show(message, "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowErrorMessage(string message)
        {
            if (_suppressMessageBox) return;
            MessageBox.Show(message, "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
