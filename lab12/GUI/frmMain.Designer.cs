namespace Lab12_MasterDetail_Transaction.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMasterDetail = new System.Windows.Forms.TabPage();
            this.splitContainerMaster = new System.Windows.Forms.SplitContainer();
            this.grpKhoa = new System.Windows.Forms.GroupBox();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.splitContainerDetail = new System.Windows.Forms.SplitContainer();
            this.grpSinhVien = new System.Windows.Forms.GroupBox();
            this.lblChiTietKhoa = new System.Windows.Forms.Label();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.grpDangKy = new System.Windows.Forms.GroupBox();
            this.pnlThemDangKy = new System.Windows.Forms.Panel();
            this.lblChonHP = new System.Windows.Forms.Label();
            this.cboHocPhan = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.nudHocKy = new System.Windows.Forms.NumericUpDown();
            this.btnThemDangKy = new System.Windows.Forms.Button();
            this.lblChiTietSV = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.tabTransaction = new System.Windows.Forms.TabPage();
            this.splitContainerTx = new System.Windows.Forms.SplitContainer();
            this.grpTxForm = new System.Windows.Forms.GroupBox();
            this.txtTxEmail = new System.Windows.Forms.TextBox();
            this.lblTxEmail = new System.Windows.Forms.Label();
            this.cboTxKhoa = new System.Windows.Forms.ComboBox();
            this.lblTxKhoa = new System.Windows.Forms.Label();
            this.nudTxDiemTB = new System.Windows.Forms.NumericUpDown();
            this.lblTxDiem = new System.Windows.Forms.Label();
            this.dtpTxNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblTxNgaySinh = new System.Windows.Forms.Label();
            this.txtTxHoTen = new System.Windows.Forms.TextBox();
            this.lblTxHoTen = new System.Windows.Forms.Label();
            this.txtTxMaSV = new System.Windows.Forms.TextBox();
            this.lblTxMaSV = new System.Windows.Forms.Label();
            this.lblTxCourses = new System.Windows.Forms.Label();
            this.chkListCourses = new System.Windows.Forms.CheckedListBox();
            this.btnCommitTx = new System.Windows.Forms.Button();
            this.btnSimulateRollback = new System.Windows.Forms.Button();
            this.grpTxLog = new System.Windows.Forms.GroupBox();
            this.txtTxLog = new System.Windows.Forms.TextBox();
            this.tabChuyenKhoa = new System.Windows.Forms.TabPage();
            this.splitContainerCK = new System.Windows.Forms.SplitContainer();
            this.grpChuyenKhoaAction = new System.Windows.Forms.GroupBox();
            this.lblCkTitle1 = new System.Windows.Forms.Label();
            this.lblCkSV = new System.Windows.Forms.Label();
            this.cboCkSinhVien = new System.Windows.Forms.ComboBox();
            this.lblCkKhoaMoi = new System.Windows.Forms.Label();
            this.cboCkKhoaMoi = new System.Windows.Forms.ComboBox();
            this.lblCkLyDo = new System.Windows.Forms.Label();
            this.txtCkLyDo = new System.Windows.Forms.TextBox();
            this.btnThucHienChuyenKhoa = new System.Windows.Forms.Button();
            this.lblCkDivider = new System.Windows.Forms.Label();
            this.lblCkTitle2 = new System.Windows.Forms.Label();
            this.lblXkKhoaXoa = new System.Windows.Forms.Label();
            this.cboXkKhoaXoa = new System.Windows.Forms.ComboBox();
            this.lblXkKhoaDen = new System.Windows.Forms.Label();
            this.cboXkKhoaDen = new System.Windows.Forms.ComboBox();
            this.btnThucHienXoaKhoaAnToan = new System.Windows.Forms.Button();
            this.grpLichSuGrid = new System.Windows.Forms.GroupBox();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.tabDiemConcurrency = new System.Windows.Forms.TabPage();
            this.splitContainerDC = new System.Windows.Forms.SplitContainer();
            this.grpBatchGrade = new System.Windows.Forms.GroupBox();
            this.pnlBatchGradeHeader = new System.Windows.Forms.Panel();
            this.lblBatchFilterSV = new System.Windows.Forms.Label();
            this.cboBatchSV = new System.Windows.Forms.ComboBox();
            this.btnBatchLoadGrades = new System.Windows.Forms.Button();
            this.btnBatchSaveCommit = new System.Windows.Forms.Button();
            this.btnBatchTestInvalidRollback = new System.Windows.Forms.Button();
            this.dgvBatchGrades = new System.Windows.Forms.DataGridView();
            this.grpConcurrency = new System.Windows.Forms.GroupBox();
            this.lblOccNotice = new System.Windows.Forms.Label();
            this.lblOccSV = new System.Windows.Forms.Label();
            this.cboOccSV = new System.Windows.Forms.ComboBox();
            this.lblOccHoTen = new System.Windows.Forms.Label();
            this.txtOccHoTen = new System.Windows.Forms.TextBox();
            this.lblOccDiemTB = new System.Windows.Forms.Label();
            this.nudOccDiemTB = new System.Windows.Forms.NumericUpDown();
            this.lblOccRowVer = new System.Windows.Forms.Label();
            this.txtOccRowVer = new System.Windows.Forms.TextBox();
            this.btnOccSaveNormal = new System.Windows.Forms.Button();
            this.btnOccSimulateConflict = new System.Windows.Forms.Button();
            this.tabKiemThu = new System.Windows.Forms.TabPage();
            this.splitContainerKT = new System.Windows.Forms.SplitContainer();
            this.grpTestButtons = new System.Windows.Forms.GroupBox();
            this.btnRunAllTests = new System.Windows.Forms.Button();
            this.btnTest1_MasterDetail = new System.Windows.Forms.Button();
            this.btnTest2_TxCommit = new System.Windows.Forms.Button();
            this.btnTest3_TxRollback = new System.Windows.Forms.Button();
            this.btnTest4_TransferDept = new System.Windows.Forms.Button();
            this.btnTest5_SafeDeleteDept = new System.Windows.Forms.Button();
            this.btnTest6_BatchGrades = new System.Windows.Forms.Button();
            this.btnTest7_Concurrency = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.grpAuditLog = new System.Windows.Forms.GroupBox();
            this.txtAuditLog = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStudentInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabMasterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaster)).BeginInit();
            this.splitContainerMaster.Panel1.SuspendLayout();
            this.splitContainerMaster.Panel2.SuspendLayout();
            this.splitContainerMaster.SuspendLayout();
            this.grpKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetail)).BeginInit();
            this.splitContainerDetail.Panel1.SuspendLayout();
            this.splitContainerDetail.Panel2.SuspendLayout();
            this.splitContainerDetail.SuspendLayout();
            this.grpSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.grpDangKy.SuspendLayout();
            this.pnlThemDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.tabTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTx)).BeginInit();
            this.splitContainerTx.Panel1.SuspendLayout();
            this.splitContainerTx.Panel2.SuspendLayout();
            this.splitContainerTx.SuspendLayout();
            this.grpTxForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTxDiemTB)).BeginInit();
            this.grpTxLog.SuspendLayout();
            this.tabChuyenKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCK)).BeginInit();
            this.splitContainerCK.Panel1.SuspendLayout();
            this.splitContainerCK.Panel2.SuspendLayout();
            this.splitContainerCK.SuspendLayout();
            this.grpChuyenKhoaAction.SuspendLayout();
            this.grpLichSuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.tabDiemConcurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDC)).BeginInit();
            this.splitContainerDC.Panel1.SuspendLayout();
            this.splitContainerDC.Panel2.SuspendLayout();
            this.splitContainerDC.SuspendLayout();
            this.grpBatchGrade.SuspendLayout();
            this.pnlBatchGradeHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchGrades)).BeginInit();
            this.grpConcurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOccDiemTB)).BeginInit();
            this.tabKiemThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKT)).BeginInit();
            this.splitContainerKT.Panel1.SuspendLayout();
            this.splitContainerKT.Panel2.SuspendLayout();
            this.splitContainerKT.SuspendLayout();
            this.grpTestButtons.SuspendLayout();
            this.grpAuditLog.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMasterDetail);
            this.tabControl.Controls.Add(this.tabTransaction);
            this.tabControl.Controls.Add(this.tabChuyenKhoa);
            this.tabControl.Controls.Add(this.tabDiemConcurrency);
            this.tabControl.Controls.Add(this.tabKiemThu);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1262, 727);
            this.tabControl.TabIndex = 0;
            // 
            // tabMasterDetail
            // 
            this.tabMasterDetail.Controls.Add(this.splitContainerMaster);
            this.tabMasterDetail.Location = new System.Drawing.Point(4, 30);
            this.tabMasterDetail.Name = "tabMasterDetail";
            this.tabMasterDetail.Padding = new System.Windows.Forms.Padding(6);
            this.tabMasterDetail.Size = new System.Drawing.Size(1254, 693);
            this.tabMasterDetail.TabIndex = 0;
            this.tabMasterDetail.Text = "1. Master-Detail (Khoa - SinhVien - DangKy)";
            this.tabMasterDetail.UseVisualStyleBackColor = true;
            // 
            // splitContainerMaster
            // 
            this.splitContainerMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaster.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMaster.Location = new System.Drawing.Point(6, 6);
            this.splitContainerMaster.Name = "splitContainerMaster";
            this.splitContainerMaster.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMaster.Panel1
            // 
            this.splitContainerMaster.Panel1.Controls.Add(this.grpKhoa);
            // 
            // splitContainerMaster.Panel2
            // 
            this.splitContainerMaster.Panel2.Controls.Add(this.splitContainerDetail);
            this.splitContainerMaster.Size = new System.Drawing.Size(1242, 681);
            this.splitContainerMaster.SplitterDistance = 180;
            this.splitContainerMaster.TabIndex = 0;
            // 
            // grpKhoa
            // 
            this.grpKhoa.Controls.Add(this.dgvKhoa);
            this.grpKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKhoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpKhoa.Location = new System.Drawing.Point(0, 0);
            this.grpKhoa.Name = "grpKhoa";
            this.grpKhoa.Padding = new System.Windows.Forms.Padding(6);
            this.grpKhoa.Size = new System.Drawing.Size(1242, 180);
            this.grpKhoa.TabIndex = 0;
            this.grpKhoa.TabStop = false;
            this.grpKhoa.Text = "[Master Cấp 1] Danh sách Khoa đào tạo (Chọn khoa để lọc sinh viên - Bài 1)";
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.AllowUserToAddRows = false;
            this.dgvKhoa.AllowUserToDeleteRows = false;
            this.dgvKhoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoa.Location = new System.Drawing.Point(6, 28);
            this.dgvKhoa.MultiSelect = false;
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.ReadOnly = true;
            this.dgvKhoa.RowHeadersVisible = false;
            this.dgvKhoa.RowHeadersWidth = 51;
            this.dgvKhoa.RowTemplate.Height = 28;
            this.dgvKhoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoa.Size = new System.Drawing.Size(1230, 146);
            this.dgvKhoa.TabIndex = 0;
            // 
            // splitContainerDetail
            // 
            this.splitContainerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetail.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDetail.Name = "splitContainerDetail";
            // 
            // splitContainerDetail.Panel1
            // 
            this.splitContainerDetail.Panel1.Controls.Add(this.grpSinhVien);
            // 
            // splitContainerDetail.Panel2
            // 
            this.splitContainerDetail.Panel2.Controls.Add(this.grpDangKy);
            this.splitContainerDetail.Size = new System.Drawing.Size(1242, 497);
            this.splitContainerDetail.SplitterDistance = 650;
            this.splitContainerDetail.TabIndex = 0;
            // 
            // grpSinhVien
            // 
            this.grpSinhVien.Controls.Add(this.lblChiTietKhoa);
            this.grpSinhVien.Controls.Add(this.dgvSinhVien);
            this.grpSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSinhVien.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpSinhVien.Location = new System.Drawing.Point(0, 0);
            this.grpSinhVien.Name = "grpSinhVien";
            this.grpSinhVien.Padding = new System.Windows.Forms.Padding(6);
            this.grpSinhVien.Size = new System.Drawing.Size(650, 497);
            this.grpSinhVien.TabIndex = 0;
            this.grpSinhVien.TabStop = false;
            this.grpSinhVien.Text = "[Master Cấp 2 / Detail Cấp 1] Sinh viên thuộc khoa (Bài 1)";
            // 
            // lblChiTietKhoa
            // 
            this.lblChiTietKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.lblChiTietKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChiTietKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChiTietKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            this.lblChiTietKhoa.Location = new System.Drawing.Point(6, 28);
            this.lblChiTietKhoa.Name = "lblChiTietKhoa";
            this.lblChiTietKhoa.Padding = new System.Windows.Forms.Padding(4);
            this.lblChiTietKhoa.Size = new System.Drawing.Size(638, 30);
            this.lblChiTietKhoa.TabIndex = 1;
            this.lblChiTietKhoa.Text = "Sinh viên thuộc khoa: Chưa chọn";
            this.lblChiTietKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(6, 64);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.RowTemplate.Height = 28;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(638, 427);
            this.dgvSinhVien.TabIndex = 0;
            // 
            // grpDangKy
            // 
            this.grpDangKy.Controls.Add(this.pnlThemDangKy);
            this.grpDangKy.Controls.Add(this.lblChiTietSV);
            this.grpDangKy.Controls.Add(this.dgvDangKy);
            this.grpDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDangKy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpDangKy.Location = new System.Drawing.Point(0, 0);
            this.grpDangKy.Name = "grpDangKy";
            this.grpDangKy.Padding = new System.Windows.Forms.Padding(6);
            this.grpDangKy.Size = new System.Drawing.Size(588, 497);
            this.grpDangKy.TabIndex = 0;
            this.grpDangKy.TabStop = false;
            this.grpDangKy.Text = "[Detail Cấp 2] Học phần đã đăng ký của sinh viên (Bài 2)";
            // 
            // pnlThemDangKy
            // 
            this.pnlThemDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlThemDangKy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThemDangKy.Controls.Add(this.btnThemDangKy);
            this.pnlThemDangKy.Controls.Add(this.nudHocKy);
            this.pnlThemDangKy.Controls.Add(this.lblHocKy);
            this.pnlThemDangKy.Controls.Add(this.cboHocPhan);
            this.pnlThemDangKy.Controls.Add(this.lblChonHP);
            this.pnlThemDangKy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThemDangKy.Location = new System.Drawing.Point(6, 441);
            this.pnlThemDangKy.Name = "pnlThemDangKy";
            this.pnlThemDangKy.Size = new System.Drawing.Size(576, 50);
            this.pnlThemDangKy.TabIndex = 2;
            // 
            // lblChonHP
            // 
            this.lblChonHP.AutoSize = true;
            this.lblChonHP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChonHP.Location = new System.Drawing.Point(5, 14);
            this.lblChonHP.Name = "lblChonHP";
            this.lblChonHP.Size = new System.Drawing.Size(69, 20);
            this.lblChonHP.TabIndex = 0;
            this.lblChonHP.Text = "Học phần:";
            // 
            // cboHocPhan
            // 
            this.cboHocPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocPhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboHocPhan.FormattingEnabled = true;
            this.cboHocPhan.Location = new System.Drawing.Point(78, 10);
            this.cboHocPhan.Name = "cboHocPhan";
            this.cboHocPhan.Size = new System.Drawing.Size(250, 28);
            this.cboHocPhan.TabIndex = 1;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHocKy.Location = new System.Drawing.Point(335, 14);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(30, 20);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "HK:";
            // 
            // nudHocKy
            // 
            this.nudHocKy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudHocKy.Location = new System.Drawing.Point(370, 11);
            this.nudHocKy.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.nudHocKy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudHocKy.Name = "nudHocKy";
            this.nudHocKy.Size = new System.Drawing.Size(55, 27);
            this.nudHocKy.TabIndex = 3;
            this.nudHocKy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemDangKy
            // 
            this.btnThemDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnThemDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDangKy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThemDangKy.ForeColor = System.Drawing.Color.White;
            this.btnThemDangKy.Location = new System.Drawing.Point(435, 8);
            this.btnThemDangKy.Name = "btnThemDangKy";
            this.btnThemDangKy.Size = new System.Drawing.Size(130, 32);
            this.btnThemDangKy.TabIndex = 4;
            this.btnThemDangKy.Text = "+ Đăng ký";
            this.btnThemDangKy.UseVisualStyleBackColor = false;
            // 
            // lblChiTietSV
            // 
            this.lblChiTietSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.lblChiTietSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChiTietSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChiTietSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.lblChiTietSV.Location = new System.Drawing.Point(6, 28);
            this.lblChiTietSV.Name = "lblChiTietSV";
            this.lblChiTietSV.Padding = new System.Windows.Forms.Padding(4);
            this.lblChiTietSV.Size = new System.Drawing.Size(576, 30);
            this.lblChiTietSV.TabIndex = 1;
            this.lblChiTietSV.Text = "Học phần của sinh viên: Chưa chọn";
            this.lblChiTietSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.AllowUserToAddRows = false;
            this.dgvDangKy.AllowUserToDeleteRows = false;
            this.dgvDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangKy.BackgroundColor = System.Drawing.Color.White;
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Location = new System.Drawing.Point(6, 64);
            this.dgvDangKy.MultiSelect = false;
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.ReadOnly = true;
            this.dgvDangKy.RowHeadersVisible = false;
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.RowTemplate.Height = 28;
            this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKy.Size = new System.Drawing.Size(576, 371);
            this.dgvDangKy.TabIndex = 0;
            // 
            // tabTransaction
            // 
            this.tabTransaction.Controls.Add(this.splitContainerTx);
            this.tabTransaction.Location = new System.Drawing.Point(4, 30);
            this.tabTransaction.Name = "tabTransaction";
            this.tabTransaction.Padding = new System.Windows.Forms.Padding(6);
            this.tabTransaction.Size = new System.Drawing.Size(1254, 693);
            this.tabTransaction.TabIndex = 1;
            this.tabTransaction.Text = "2. Giao dịch SqlTransaction & Rollback (Bài 3, 4, 5)";
            this.tabTransaction.UseVisualStyleBackColor = true;
            // 
            // splitContainerTx
            // 
            this.splitContainerTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTx.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTx.Location = new System.Drawing.Point(6, 6);
            this.splitContainerTx.Name = "splitContainerTx";
            // 
            // splitContainerTx.Panel1
            // 
            this.splitContainerTx.Panel1.Controls.Add(this.grpTxForm);
            // 
            // splitContainerTx.Panel2
            // 
            this.splitContainerTx.Panel2.Controls.Add(this.grpTxLog);
            this.splitContainerTx.Size = new System.Drawing.Size(1242, 681);
            this.splitContainerTx.SplitterDistance = 460;
            this.splitContainerTx.TabIndex = 0;
            // 
            // grpTxForm
            // 
            this.grpTxForm.Controls.Add(this.btnSimulateRollback);
            this.grpTxForm.Controls.Add(this.btnCommitTx);
            this.grpTxForm.Controls.Add(this.chkListCourses);
            this.grpTxForm.Controls.Add(this.lblTxCourses);
            this.grpTxForm.Controls.Add(this.txtTxEmail);
            this.grpTxForm.Controls.Add(this.lblTxEmail);
            this.grpTxForm.Controls.Add(this.cboTxKhoa);
            this.grpTxForm.Controls.Add(this.lblTxKhoa);
            this.grpTxForm.Controls.Add(this.nudTxDiemTB);
            this.grpTxForm.Controls.Add(this.lblTxDiem);
            this.grpTxForm.Controls.Add(this.dtpTxNgaySinh);
            this.grpTxForm.Controls.Add(this.lblTxNgaySinh);
            this.grpTxForm.Controls.Add(this.txtTxHoTen);
            this.grpTxForm.Controls.Add(this.lblTxHoTen);
            this.grpTxForm.Controls.Add(this.txtTxMaSV);
            this.grpTxForm.Controls.Add(this.lblTxMaSV);
            this.grpTxForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTxForm.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpTxForm.Location = new System.Drawing.Point(0, 0);
            this.grpTxForm.Name = "grpTxForm";
            this.grpTxForm.Size = new System.Drawing.Size(460, 681);
            this.grpTxForm.TabIndex = 0;
            this.grpTxForm.TabStop = false;
            this.grpTxForm.Text = "Nhập sinh viên & Danh sách học phần đăng ký ban đầu";
            // 
            // txtTxMaSV
            // 
            this.txtTxMaSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTxMaSV.Location = new System.Drawing.Point(125, 32);
            this.txtTxMaSV.Name = "txtTxMaSV";
            this.txtTxMaSV.Size = new System.Drawing.Size(315, 29);
            this.txtTxMaSV.TabIndex = 1;
            this.txtTxMaSV.Text = "SV_TX_01";
            // 
            // lblTxMaSV
            // 
            this.lblTxMaSV.AutoSize = true;
            this.lblTxMaSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxMaSV.Location = new System.Drawing.Point(15, 35);
            this.lblTxMaSV.Name = "lblTxMaSV";
            this.lblTxMaSV.Size = new System.Drawing.Size(58, 21);
            this.lblTxMaSV.TabIndex = 0;
            this.lblTxMaSV.Text = "Mã SV:";
            // 
            // txtTxHoTen
            // 
            this.txtTxHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTxHoTen.Location = new System.Drawing.Point(125, 72);
            this.txtTxHoTen.Name = "txtTxHoTen";
            this.txtTxHoTen.Size = new System.Drawing.Size(315, 29);
            this.txtTxHoTen.TabIndex = 3;
            this.txtTxHoTen.Text = "Trần Giao Dịch";
            // 
            // lblTxHoTen
            // 
            this.lblTxHoTen.AutoSize = true;
            this.lblTxHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxHoTen.Location = new System.Drawing.Point(15, 75);
            this.lblTxHoTen.Name = "lblTxHoTen";
            this.lblTxHoTen.Size = new System.Drawing.Size(59, 21);
            this.lblTxHoTen.TabIndex = 2;
            this.lblTxHoTen.Text = "Họ tên:";
            // 
            // dtpTxNgaySinh
            // 
            this.dtpTxNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpTxNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpTxNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTxNgaySinh.Location = new System.Drawing.Point(125, 112);
            this.dtpTxNgaySinh.Name = "dtpTxNgaySinh";
            this.dtpTxNgaySinh.Size = new System.Drawing.Size(160, 29);
            this.dtpTxNgaySinh.TabIndex = 5;
            this.dtpTxNgaySinh.Value = new System.DateTime(2005, 5, 15, 0, 0, 0, 0);
            // 
            // lblTxNgaySinh
            // 
            this.lblTxNgaySinh.AutoSize = true;
            this.lblTxNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxNgaySinh.Location = new System.Drawing.Point(15, 115);
            this.lblTxNgaySinh.Name = "lblTxNgaySinh";
            this.lblTxNgaySinh.Size = new System.Drawing.Size(83, 21);
            this.lblTxNgaySinh.TabIndex = 4;
            this.lblTxNgaySinh.Text = "Ngày sinh:";
            // 
            // nudTxDiemTB
            // 
            this.nudTxDiemTB.DecimalPlaces = 2;
            this.nudTxDiemTB.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudTxDiemTB.Location = new System.Drawing.Point(365, 113);
            this.nudTxDiemTB.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudTxDiemTB.Name = "nudTxDiemTB";
            this.nudTxDiemTB.Size = new System.Drawing.Size(75, 29);
            this.nudTxDiemTB.TabIndex = 7;
            this.nudTxDiemTB.Value = new decimal(new int[] { 85, 0, 0, 65536 });
            // 
            // lblTxDiem
            // 
            this.lblTxDiem.AutoSize = true;
            this.lblTxDiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxDiem.Location = new System.Drawing.Point(295, 115);
            this.lblTxDiem.Name = "lblTxDiem";
            this.lblTxDiem.Size = new System.Drawing.Size(71, 21);
            this.lblTxDiem.TabIndex = 6;
            this.lblTxDiem.Text = "Điểm TB:";
            // 
            // cboTxKhoa
            // 
            this.cboTxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTxKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTxKhoa.FormattingEnabled = true;
            this.cboTxKhoa.Location = new System.Drawing.Point(125, 152);
            this.cboTxKhoa.Name = "cboTxKhoa";
            this.cboTxKhoa.Size = new System.Drawing.Size(315, 29);
            this.cboTxKhoa.TabIndex = 9;
            // 
            // lblTxKhoa
            // 
            this.lblTxKhoa.AutoSize = true;
            this.lblTxKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxKhoa.Location = new System.Drawing.Point(15, 155);
            this.lblTxKhoa.Name = "lblTxKhoa";
            this.lblTxKhoa.Size = new System.Drawing.Size(49, 21);
            this.lblTxKhoa.TabIndex = 8;
            this.lblTxKhoa.Text = "Khoa:";
            // 
            // txtTxEmail
            // 
            this.txtTxEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTxEmail.Location = new System.Drawing.Point(125, 192);
            this.txtTxEmail.Name = "txtTxEmail";
            this.txtTxEmail.Size = new System.Drawing.Size(315, 29);
            this.txtTxEmail.TabIndex = 11;
            this.txtTxEmail.Text = "giaodich@eaut.edu.vn";
            // 
            // lblTxEmail
            // 
            this.lblTxEmail.AutoSize = true;
            this.lblTxEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTxEmail.Location = new System.Drawing.Point(15, 195);
            this.lblTxEmail.Name = "lblTxEmail";
            this.lblTxEmail.Size = new System.Drawing.Size(51, 21);
            this.lblTxEmail.TabIndex = 10;
            this.lblTxEmail.Text = "Email:";
            // 
            // lblTxCourses
            // 
            this.lblTxCourses.AutoSize = true;
            this.lblTxCourses.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTxCourses.Location = new System.Drawing.Point(15, 235);
            this.lblTxCourses.Name = "lblTxCourses";
            this.lblTxCourses.Size = new System.Drawing.Size(262, 21);
            this.lblTxCourses.TabIndex = 12;
            this.lblTxCourses.Text = "Chọn các học phần đăng ký ban đầu:";
            // 
            // chkListCourses
            // 
            this.chkListCourses.CheckOnClick = true;
            this.chkListCourses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkListCourses.FormattingEnabled = true;
            this.chkListCourses.Location = new System.Drawing.Point(15, 265);
            this.chkListCourses.Name = "chkListCourses";
            this.chkListCourses.Size = new System.Drawing.Size(425, 180);
            this.chkListCourses.TabIndex = 13;
            // 
            // btnCommitTx
            // 
            this.btnCommitTx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnCommitTx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommitTx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommitTx.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCommitTx.ForeColor = System.Drawing.Color.White;
            this.btnCommitTx.Location = new System.Drawing.Point(15, 465);
            this.btnCommitTx.Name = "btnCommitTx";
            this.btnCommitTx.Size = new System.Drawing.Size(425, 42);
            this.btnCommitTx.TabIndex = 14;
            this.btnCommitTx.Text = "Thực hiện Giao dịch Thành công (Commit - Bài 3)";
            this.btnCommitTx.UseVisualStyleBackColor = false;
            // 
            // btnSimulateRollback
            // 
            this.btnSimulateRollback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnSimulateRollback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimulateRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulateRollback.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSimulateRollback.ForeColor = System.Drawing.Color.White;
            this.btnSimulateRollback.Location = new System.Drawing.Point(15, 520);
            this.btnSimulateRollback.Name = "btnSimulateRollback";
            this.btnSimulateRollback.Size = new System.Drawing.Size(425, 42);
            this.btnSimulateRollback.TabIndex = 15;
            this.btnSimulateRollback.Text = "Mô phỏng Lỗi vi phạm FK & Rollback toàn bộ (Bài 4)";
            this.btnSimulateRollback.UseVisualStyleBackColor = false;
            // 
            // grpTxLog
            // 
            this.grpTxLog.Controls.Add(this.txtTxLog);
            this.grpTxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTxLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpTxLog.Location = new System.Drawing.Point(0, 0);
            this.grpTxLog.Name = "grpTxLog";
            this.grpTxLog.Padding = new System.Windows.Forms.Padding(6);
            this.grpTxLog.Size = new System.Drawing.Size(778, 681);
            this.grpTxLog.TabIndex = 0;
            this.grpTxLog.TabStop = false;
            this.grpTxLog.Text = "Nhật ký thực thi SqlTransaction (Kiểm chứng Commit / Rollback)";
            // 
            // txtTxLog
            // 
            this.txtTxLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTxLog.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTxLog.Location = new System.Drawing.Point(6, 28);
            this.txtTxLog.Multiline = true;
            this.txtTxLog.Name = "txtTxLog";
            this.txtTxLog.ReadOnly = true;
            this.txtTxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTxLog.Size = new System.Drawing.Size(766, 647);
            this.txtTxLog.TabIndex = 0;
            // 
            // tabChuyenKhoa
            // 
            this.tabChuyenKhoa.Controls.Add(this.splitContainerCK);
            this.tabChuyenKhoa.Location = new System.Drawing.Point(4, 30);
            this.tabChuyenKhoa.Name = "tabChuyenKhoa";
            this.tabChuyenKhoa.Padding = new System.Windows.Forms.Padding(6);
            this.tabChuyenKhoa.Size = new System.Drawing.Size(1254, 693);
            this.tabChuyenKhoa.TabIndex = 2;
            this.tabChuyenKhoa.Text = "3. Chuyển khoa & Xóa khoa an toàn (Bài 6 & 7)";
            this.tabChuyenKhoa.UseVisualStyleBackColor = true;
            // 
            // splitContainerCK
            // 
            this.splitContainerCK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCK.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerCK.Location = new System.Drawing.Point(6, 6);
            this.splitContainerCK.Name = "splitContainerCK";
            // 
            // splitContainerCK.Panel1
            // 
            this.splitContainerCK.Panel1.Controls.Add(this.grpChuyenKhoaAction);
            // 
            // splitContainerCK.Panel2
            // 
            this.splitContainerCK.Panel2.Controls.Add(this.grpLichSuGrid);
            this.splitContainerCK.Size = new System.Drawing.Size(1242, 681);
            this.splitContainerCK.SplitterDistance = 460;
            this.splitContainerCK.TabIndex = 0;
            // 
            // grpChuyenKhoaAction
            // 
            this.grpChuyenKhoaAction.Controls.Add(this.btnThucHienXoaKhoaAnToan);
            this.grpChuyenKhoaAction.Controls.Add(this.cboXkKhoaDen);
            this.grpChuyenKhoaAction.Controls.Add(this.lblXkKhoaDen);
            this.grpChuyenKhoaAction.Controls.Add(this.cboXkKhoaXoa);
            this.grpChuyenKhoaAction.Controls.Add(this.lblXkKhoaXoa);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkTitle2);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkDivider);
            this.grpChuyenKhoaAction.Controls.Add(this.btnThucHienChuyenKhoa);
            this.grpChuyenKhoaAction.Controls.Add(this.txtCkLyDo);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkLyDo);
            this.grpChuyenKhoaAction.Controls.Add(this.cboCkKhoaMoi);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkKhoaMoi);
            this.grpChuyenKhoaAction.Controls.Add(this.cboCkSinhVien);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkSV);
            this.grpChuyenKhoaAction.Controls.Add(this.lblCkTitle1);
            this.grpChuyenKhoaAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChuyenKhoaAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpChuyenKhoaAction.Location = new System.Drawing.Point(0, 0);
            this.grpChuyenKhoaAction.Name = "grpChuyenKhoaAction";
            this.grpChuyenKhoaAction.Size = new System.Drawing.Size(460, 681);
            this.grpChuyenKhoaAction.TabIndex = 0;
            this.grpChuyenKhoaAction.TabStop = false;
            this.grpChuyenKhoaAction.Text = "Thao tác Giao dịch Quản trị Khoa";
            // 
            // lblCkTitle1
            // 
            this.lblCkTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblCkTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCkTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCkTitle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCkTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCkTitle1.Location = new System.Drawing.Point(3, 25);
            this.lblCkTitle1.Name = "lblCkTitle1";
            this.lblCkTitle1.Padding = new System.Windows.Forms.Padding(4);
            this.lblCkTitle1.Size = new System.Drawing.Size(454, 30);
            this.lblCkTitle1.TabIndex = 0;
            this.lblCkTitle1.Text = "1. Chuyển sinh viên sang khoa khác (Bài 6 - Ghi lịch sử)";
            this.lblCkTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCkSV
            // 
            this.lblCkSV.AutoSize = true;
            this.lblCkSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCkSV.Location = new System.Drawing.Point(15, 75);
            this.lblCkSV.Name = "lblCkSV";
            this.lblCkSV.Size = new System.Drawing.Size(117, 21);
            this.lblCkSV.TabIndex = 1;
            this.lblCkSV.Text = "Chọn sinh viên:";
            // 
            // cboCkSinhVien
            // 
            this.cboCkSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCkSinhVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboCkSinhVien.FormattingEnabled = true;
            this.cboCkSinhVien.Location = new System.Drawing.Point(140, 72);
            this.cboCkSinhVien.Name = "cboCkSinhVien";
            this.cboCkSinhVien.Size = new System.Drawing.Size(305, 29);
            this.cboCkSinhVien.TabIndex = 2;
            // 
            // lblCkKhoaMoi
            // 
            this.lblCkKhoaMoi.AutoSize = true;
            this.lblCkKhoaMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCkKhoaMoi.Location = new System.Drawing.Point(15, 118);
            this.lblCkKhoaMoi.Name = "lblCkKhoaMoi";
            this.lblCkKhoaMoi.Size = new System.Drawing.Size(121, 21);
            this.lblCkKhoaMoi.TabIndex = 3;
            this.lblCkKhoaMoi.Text = "Khoa chuyển tới:";
            // 
            // cboCkKhoaMoi
            // 
            this.cboCkKhoaMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCkKhoaMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboCkKhoaMoi.FormattingEnabled = true;
            this.cboCkKhoaMoi.Location = new System.Drawing.Point(140, 115);
            this.cboCkKhoaMoi.Name = "cboCkKhoaMoi";
            this.cboCkKhoaMoi.Size = new System.Drawing.Size(305, 29);
            this.cboCkKhoaMoi.TabIndex = 4;
            // 
            // lblCkLyDo
            // 
            this.lblCkLyDo.AutoSize = true;
            this.lblCkLyDo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCkLyDo.Location = new System.Drawing.Point(15, 160);
            this.lblCkLyDo.Name = "lblCkLyDo";
            this.lblCkLyDo.Size = new System.Drawing.Size(51, 21);
            this.lblCkLyDo.TabIndex = 5;
            this.lblCkLyDo.Text = "Lý do:";
            // 
            // txtCkLyDo
            // 
            this.txtCkLyDo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCkLyDo.Location = new System.Drawing.Point(140, 157);
            this.txtCkLyDo.Name = "txtCkLyDo";
            this.txtCkLyDo.Size = new System.Drawing.Size(305, 29);
            this.txtCkLyDo.TabIndex = 6;
            this.txtCkLyDo.Text = "Chuyển ngành theo định hướng đào tạo mới";
            // 
            // btnThucHienChuyenKhoa
            // 
            this.btnThucHienChuyenKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThucHienChuyenKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucHienChuyenKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHienChuyenKhoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThucHienChuyenKhoa.ForeColor = System.Drawing.Color.White;
            this.btnThucHienChuyenKhoa.Location = new System.Drawing.Point(140, 200);
            this.btnThucHienChuyenKhoa.Name = "btnThucHienChuyenKhoa";
            this.btnThucHienChuyenKhoa.Size = new System.Drawing.Size(305, 38);
            this.btnThucHienChuyenKhoa.TabIndex = 7;
            this.btnThucHienChuyenKhoa.Text = "Chuyển khoa (Transaction)";
            this.btnThucHienChuyenKhoa.UseVisualStyleBackColor = false;
            // 
            // lblCkDivider
            // 
            this.lblCkDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCkDivider.Location = new System.Drawing.Point(15, 260);
            this.lblCkDivider.Name = "lblCkDivider";
            this.lblCkDivider.Size = new System.Drawing.Size(430, 2);
            this.lblCkDivider.TabIndex = 8;
            // 
            // lblCkTitle2
            // 
            this.lblCkTitle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblCkTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCkTitle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCkTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblCkTitle2.Location = new System.Drawing.Point(15, 280);
            this.lblCkTitle2.Name = "lblCkTitle2";
            this.lblCkTitle2.Padding = new System.Windows.Forms.Padding(4);
            this.lblCkTitle2.Size = new System.Drawing.Size(430, 30);
            this.lblCkTitle2.TabIndex = 9;
            this.lblCkTitle2.Text = "2. Xóa khoa an toàn (Bài 7 - Chuyển toàn bộ SV rồi xóa)";
            this.lblCkTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXkKhoaXoa
            // 
            this.lblXkKhoaXoa.AutoSize = true;
            this.lblXkKhoaXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblXkKhoaXoa.Location = new System.Drawing.Point(15, 330);
            this.lblXkKhoaXoa.Name = "lblXkKhoaXoa";
            this.lblXkKhoaXoa.Size = new System.Drawing.Size(107, 21);
            this.lblXkKhoaXoa.TabIndex = 10;
            this.lblXkKhoaXoa.Text = "Khoa cần xóa:";
            // 
            // cboXkKhoaXoa
            // 
            this.cboXkKhoaXoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXkKhoaXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboXkKhoaXoa.FormattingEnabled = true;
            this.cboXkKhoaXoa.Location = new System.Drawing.Point(140, 327);
            this.cboXkKhoaXoa.Name = "cboXkKhoaXoa";
            this.cboXkKhoaXoa.Size = new System.Drawing.Size(305, 29);
            this.cboXkKhoaXoa.TabIndex = 11;
            // 
            // lblXkKhoaDen
            // 
            this.lblXkKhoaDen.AutoSize = true;
            this.lblXkKhoaDen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblXkKhoaDen.Location = new System.Drawing.Point(15, 375);
            this.lblXkKhoaDen.Name = "lblXkKhoaDen";
            this.lblXkKhoaDen.Size = new System.Drawing.Size(123, 21);
            this.lblXkKhoaDen.TabIndex = 12;
            this.lblXkKhoaDen.Text = "Khoa nhận lại SV:";
            // 
            // cboXkKhoaDen
            // 
            this.cboXkKhoaDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXkKhoaDen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboXkKhoaDen.FormattingEnabled = true;
            this.cboXkKhoaDen.Location = new System.Drawing.Point(140, 372);
            this.cboXkKhoaDen.Name = "cboXkKhoaDen";
            this.cboXkKhoaDen.Size = new System.Drawing.Size(305, 29);
            this.cboXkKhoaDen.TabIndex = 13;
            // 
            // btnThucHienXoaKhoaAnToan
            // 
            this.btnThucHienXoaKhoaAnToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnThucHienXoaKhoaAnToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucHienXoaKhoaAnToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHienXoaKhoaAnToan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThucHienXoaKhoaAnToan.ForeColor = System.Drawing.Color.White;
            this.btnThucHienXoaKhoaAnToan.Location = new System.Drawing.Point(140, 420);
            this.btnThucHienXoaKhoaAnToan.Name = "btnThucHienXoaKhoaAnToan";
            this.btnThucHienXoaKhoaAnToan.Size = new System.Drawing.Size(305, 38);
            this.btnThucHienXoaKhoaAnToan.TabIndex = 14;
            this.btnThucHienXoaKhoaAnToan.Text = "Xóa khoa an toàn (Transaction)";
            this.btnThucHienXoaKhoaAnToan.UseVisualStyleBackColor = false;
            // 
            // grpLichSuGrid
            // 
            this.grpLichSuGrid.Controls.Add(this.dgvLichSu);
            this.grpLichSuGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLichSuGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpLichSuGrid.Location = new System.Drawing.Point(0, 0);
            this.grpLichSuGrid.Name = "grpLichSuGrid";
            this.grpLichSuGrid.Padding = new System.Windows.Forms.Padding(6);
            this.grpLichSuGrid.Size = new System.Drawing.Size(778, 681);
            this.grpLichSuGrid.TabIndex = 0;
            this.grpLichSuGrid.TabStop = false;
            this.grpLichSuGrid.Text = "Bảng nhật ký LichSuChuyenKhoa (Ghi nhận tự động từ Transaction)";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.Location = new System.Drawing.Point(6, 28);
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 28;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(766, 647);
            this.dgvLichSu.TabIndex = 0;
            // 
            // tabDiemConcurrency
            // 
            this.tabDiemConcurrency.Controls.Add(this.splitContainerDC);
            this.tabDiemConcurrency.Location = new System.Drawing.Point(4, 30);
            this.tabDiemConcurrency.Name = "tabDiemConcurrency";
            this.tabDiemConcurrency.Padding = new System.Windows.Forms.Padding(6);
            this.tabDiemConcurrency.Size = new System.Drawing.Size(1254, 693);
            this.tabDiemConcurrency.TabIndex = 3;
            this.tabDiemConcurrency.Text = "4. Cập nhật điểm hàng loạt & Kiểm soát xung đột (Bài 8 & 9)";
            this.tabDiemConcurrency.UseVisualStyleBackColor = true;
            // 
            // splitContainerDC
            // 
            this.splitContainerDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDC.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDC.Location = new System.Drawing.Point(6, 6);
            this.splitContainerDC.Name = "splitContainerDC";
            // 
            // splitContainerDC.Panel1
            // 
            this.splitContainerDC.Panel1.Controls.Add(this.grpBatchGrade);
            // 
            // splitContainerDC.Panel2
            // 
            this.splitContainerDC.Panel2.Controls.Add(this.grpConcurrency);
            this.splitContainerDC.Size = new System.Drawing.Size(1242, 681);
            this.splitContainerDC.SplitterDistance = 750;
            this.splitContainerDC.TabIndex = 0;
            // 
            // grpBatchGrade
            // 
            this.grpBatchGrade.Controls.Add(this.dgvBatchGrades);
            this.grpBatchGrade.Controls.Add(this.pnlBatchGradeHeader);
            this.grpBatchGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatchGrade.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpBatchGrade.Location = new System.Drawing.Point(0, 0);
            this.grpBatchGrade.Name = "grpBatchGrade";
            this.grpBatchGrade.Padding = new System.Windows.Forms.Padding(6);
            this.grpBatchGrade.Size = new System.Drawing.Size(750, 681);
            this.grpBatchGrade.TabIndex = 0;
            this.grpBatchGrade.TabStop = false;
            this.grpBatchGrade.Text = "Cập nhật điểm hàng loạt (Bài 8: Kiểm tra [0, 10] & Rollback toàn bộ)";
            // 
            // pnlBatchGradeHeader
            // 
            this.pnlBatchGradeHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBatchGradeHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBatchGradeHeader.Controls.Add(this.btnBatchTestInvalidRollback);
            this.pnlBatchGradeHeader.Controls.Add(this.btnBatchSaveCommit);
            this.pnlBatchGradeHeader.Controls.Add(this.btnBatchLoadGrades);
            this.pnlBatchGradeHeader.Controls.Add(this.cboBatchSV);
            this.pnlBatchGradeHeader.Controls.Add(this.lblBatchFilterSV);
            this.pnlBatchGradeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBatchGradeHeader.Location = new System.Drawing.Point(6, 28);
            this.pnlBatchGradeHeader.Name = "pnlBatchGradeHeader";
            this.pnlBatchGradeHeader.Size = new System.Drawing.Size(738, 90);
            this.pnlBatchGradeHeader.TabIndex = 0;
            // 
            // lblBatchFilterSV
            // 
            this.lblBatchFilterSV.AutoSize = true;
            this.lblBatchFilterSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBatchFilterSV.Location = new System.Drawing.Point(10, 15);
            this.lblBatchFilterSV.Name = "lblBatchFilterSV";
            this.lblBatchFilterSV.Size = new System.Drawing.Size(107, 20);
            this.lblBatchFilterSV.TabIndex = 0;
            this.lblBatchFilterSV.Text = "Chọn sinh viên:";
            // 
            // cboBatchSV
            // 
            this.cboBatchSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboBatchSV.FormattingEnabled = true;
            this.cboBatchSV.Location = new System.Drawing.Point(125, 12);
            this.cboBatchSV.Name = "cboBatchSV";
            this.cboBatchSV.Size = new System.Drawing.Size(320, 28);
            this.cboBatchSV.TabIndex = 1;
            // 
            // btnBatchLoadGrades
            // 
            this.btnBatchLoadGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnBatchLoadGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchLoadGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchLoadGrades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBatchLoadGrades.Location = new System.Drawing.Point(460, 10);
            this.btnBatchLoadGrades.Name = "btnBatchLoadGrades";
            this.btnBatchLoadGrades.Size = new System.Drawing.Size(110, 32);
            this.btnBatchLoadGrades.TabIndex = 2;
            this.btnBatchLoadGrades.Text = "Tải bảng điểm";
            this.btnBatchLoadGrades.UseVisualStyleBackColor = true;
            // 
            // btnBatchSaveCommit
            // 
            this.btnBatchSaveCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnBatchSaveCommit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchSaveCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchSaveCommit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBatchSaveCommit.ForeColor = System.Drawing.Color.White;
            this.btnBatchSaveCommit.Location = new System.Drawing.Point(10, 50);
            this.btnBatchSaveCommit.Name = "btnBatchSaveCommit";
            this.btnBatchSaveCommit.Size = new System.Drawing.Size(250, 32);
            this.btnBatchSaveCommit.TabIndex = 3;
            this.btnBatchSaveCommit.Text = "Lưu điểm hàng loạt (Commit)";
            this.btnBatchSaveCommit.UseVisualStyleBackColor = false;
            // 
            // btnBatchTestInvalidRollback
            // 
            this.btnBatchTestInvalidRollback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnBatchTestInvalidRollback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchTestInvalidRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchTestInvalidRollback.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBatchTestInvalidRollback.ForeColor = System.Drawing.Color.White;
            this.btnBatchTestInvalidRollback.Location = new System.Drawing.Point(270, 50);
            this.btnBatchTestInvalidRollback.Name = "btnBatchTestInvalidRollback";
            this.btnBatchTestInvalidRollback.Size = new System.Drawing.Size(300, 32);
            this.btnBatchTestInvalidRollback.TabIndex = 4;
            this.btnBatchTestInvalidRollback.Text = "Test Nhập điểm 12.5 -> Rollback toàn bộ";
            this.btnBatchTestInvalidRollback.UseVisualStyleBackColor = false;
            // 
            // dgvBatchGrades
            // 
            this.dgvBatchGrades.AllowUserToAddRows = false;
            this.dgvBatchGrades.AllowUserToDeleteRows = false;
            this.dgvBatchGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatchGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvBatchGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatchGrades.Location = new System.Drawing.Point(6, 118);
            this.dgvBatchGrades.Name = "dgvBatchGrades";
            this.dgvBatchGrades.RowHeadersWidth = 51;
            this.dgvBatchGrades.RowTemplate.Height = 28;
            this.dgvBatchGrades.Size = new System.Drawing.Size(738, 557);
            this.dgvBatchGrades.TabIndex = 1;
            // 
            // grpConcurrency
            // 
            this.grpConcurrency.Controls.Add(this.btnOccSimulateConflict);
            this.grpConcurrency.Controls.Add(this.btnOccSaveNormal);
            this.grpConcurrency.Controls.Add(this.txtOccRowVer);
            this.grpConcurrency.Controls.Add(this.lblOccRowVer);
            this.grpConcurrency.Controls.Add(this.nudOccDiemTB);
            this.grpConcurrency.Controls.Add(this.lblOccDiemTB);
            this.grpConcurrency.Controls.Add(this.txtOccHoTen);
            this.grpConcurrency.Controls.Add(this.lblOccHoTen);
            this.grpConcurrency.Controls.Add(this.cboOccSV);
            this.grpConcurrency.Controls.Add(this.lblOccSV);
            this.grpConcurrency.Controls.Add(this.lblOccNotice);
            this.grpConcurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConcurrency.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpConcurrency.Location = new System.Drawing.Point(0, 0);
            this.grpConcurrency.Name = "grpConcurrency";
            this.grpConcurrency.Size = new System.Drawing.Size(488, 681);
            this.grpConcurrency.TabIndex = 0;
            this.grpConcurrency.TabStop = false;
            this.grpConcurrency.Text = "Kiểm soát xung đột cập nhật đồng thời (Bài 9: RowVersion)";
            // 
            // lblOccNotice
            // 
            this.lblOccNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.lblOccNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOccNotice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOccNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOccNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.lblOccNotice.Location = new System.Drawing.Point(3, 25);
            this.lblOccNotice.Name = "lblOccNotice";
            this.lblOccNotice.Padding = new System.Windows.Forms.Padding(6);
            this.lblOccNotice.Size = new System.Drawing.Size(482, 80);
            this.lblOccNotice.TabIndex = 0;
            this.lblOccNotice.Text = "Cơ chế Optimistic Concurrency:\r\nKhi thực hiện UPDATE, so sánh RowVersion ban đầu." +
    " Nếu người khác đã cập nhật trước đó, RowVersion đã đổi và hệ thống sẽ ném lỗi 5" +
    "0010 ngăn chặn ghi đè mất dữ liệu.";
            // 
            // lblOccSV
            // 
            this.lblOccSV.AutoSize = true;
            this.lblOccSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOccSV.Location = new System.Drawing.Point(15, 125);
            this.lblOccSV.Name = "lblOccSV";
            this.lblOccSV.Size = new System.Drawing.Size(117, 21);
            this.lblOccSV.TabIndex = 1;
            this.lblOccSV.Text = "Chọn sinh viên:";
            // 
            // cboOccSV
            // 
            this.cboOccSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOccSV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboOccSV.FormattingEnabled = true;
            this.cboOccSV.Location = new System.Drawing.Point(145, 122);
            this.cboOccSV.Name = "cboOccSV";
            this.cboOccSV.Size = new System.Drawing.Size(325, 29);
            this.cboOccSV.TabIndex = 2;
            // 
            // lblOccHoTen
            // 
            this.lblOccHoTen.AutoSize = true;
            this.lblOccHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOccHoTen.Location = new System.Drawing.Point(15, 170);
            this.lblOccHoTen.Name = "lblOccHoTen";
            this.lblOccHoTen.Size = new System.Drawing.Size(59, 21);
            this.lblOccHoTen.TabIndex = 3;
            this.lblOccHoTen.Text = "Họ tên:";
            // 
            // txtOccHoTen
            // 
            this.txtOccHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOccHoTen.Location = new System.Drawing.Point(145, 167);
            this.txtOccHoTen.Name = "txtOccHoTen";
            this.txtOccHoTen.Size = new System.Drawing.Size(325, 29);
            this.txtOccHoTen.TabIndex = 4;
            // 
            // lblOccDiemTB
            // 
            this.lblOccDiemTB.AutoSize = true;
            this.lblOccDiemTB.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOccDiemTB.Location = new System.Drawing.Point(15, 215);
            this.lblOccDiemTB.Name = "lblOccDiemTB";
            this.lblOccDiemTB.Size = new System.Drawing.Size(71, 21);
            this.lblOccDiemTB.TabIndex = 5;
            this.lblOccDiemTB.Text = "Điểm TB:";
            // 
            // nudOccDiemTB
            // 
            this.nudOccDiemTB.DecimalPlaces = 2;
            this.nudOccDiemTB.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudOccDiemTB.Location = new System.Drawing.Point(145, 213);
            this.nudOccDiemTB.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudOccDiemTB.Name = "nudOccDiemTB";
            this.nudOccDiemTB.Size = new System.Drawing.Size(120, 29);
            this.nudOccDiemTB.TabIndex = 6;
            // 
            // lblOccRowVer
            // 
            this.lblOccRowVer.AutoSize = true;
            this.lblOccRowVer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOccRowVer.Location = new System.Drawing.Point(15, 260);
            this.lblOccRowVer.Name = "lblOccRowVer";
            this.lblOccRowVer.Size = new System.Drawing.Size(95, 21);
            this.lblOccRowVer.TabIndex = 7;
            this.lblOccRowVer.Text = "RowVersion:";
            // 
            // txtOccRowVer
            // 
            this.txtOccRowVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtOccRowVer.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOccRowVer.Location = new System.Drawing.Point(145, 257);
            this.txtOccRowVer.Name = "txtOccRowVer";
            this.txtOccRowVer.ReadOnly = true;
            this.txtOccRowVer.Size = new System.Drawing.Size(325, 26);
            this.txtOccRowVer.TabIndex = 8;
            // 
            // btnOccSaveNormal
            // 
            this.btnOccSaveNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnOccSaveNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOccSaveNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOccSaveNormal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOccSaveNormal.ForeColor = System.Drawing.Color.White;
            this.btnOccSaveNormal.Location = new System.Drawing.Point(15, 310);
            this.btnOccSaveNormal.Name = "btnOccSaveNormal";
            this.btnOccSaveNormal.Size = new System.Drawing.Size(455, 40);
            this.btnOccSaveNormal.TabIndex = 9;
            this.btnOccSaveNormal.Text = "Lưu cập nhật bình thường (Hợp lệ)";
            this.btnOccSaveNormal.UseVisualStyleBackColor = false;
            // 
            // btnOccSimulateConflict
            // 
            this.btnOccSimulateConflict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.btnOccSimulateConflict.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOccSimulateConflict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOccSimulateConflict.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOccSimulateConflict.ForeColor = System.Drawing.Color.White;
            this.btnOccSimulateConflict.Location = new System.Drawing.Point(15, 365);
            this.btnOccSimulateConflict.Name = "btnOccSimulateConflict";
            this.btnOccSimulateConflict.Size = new System.Drawing.Size(455, 42);
            this.btnOccSimulateConflict.TabIndex = 10;
            this.btnOccSimulateConflict.Text = "Mô phỏng Xung đột Concurrency (Giả lập bản ghi đã bị sửa)";
            this.btnOccSimulateConflict.UseVisualStyleBackColor = false;
            // 
            // tabKiemThu
            // 
            this.tabKiemThu.Controls.Add(this.splitContainerKT);
            this.tabKiemThu.Location = new System.Drawing.Point(4, 30);
            this.tabKiemThu.Name = "tabKiemThu";
            this.tabKiemThu.Padding = new System.Windows.Forms.Padding(6);
            this.tabKiemThu.Size = new System.Drawing.Size(1254, 693);
            this.tabKiemThu.TabIndex = 4;
            this.tabKiemThu.Text = "5. Kiểm thử Tự động & Nhật ký Hệ thống (Bài 10)";
            this.tabKiemThu.UseVisualStyleBackColor = true;
            // 
            // splitContainerKT
            // 
            this.splitContainerKT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerKT.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerKT.Location = new System.Drawing.Point(6, 6);
            this.splitContainerKT.Name = "splitContainerKT";
            // 
            // splitContainerKT.Panel1
            // 
            this.splitContainerKT.Panel1.Controls.Add(this.grpTestButtons);
            // 
            // splitContainerKT.Panel2
            // 
            this.splitContainerKT.Panel2.Controls.Add(this.grpAuditLog);
            this.splitContainerKT.Size = new System.Drawing.Size(1242, 681);
            this.splitContainerKT.SplitterDistance = 420;
            this.splitContainerKT.TabIndex = 0;
            // 
            // grpTestButtons
            // 
            this.grpTestButtons.Controls.Add(this.btnClearLog);
            this.grpTestButtons.Controls.Add(this.btnTest7_Concurrency);
            this.grpTestButtons.Controls.Add(this.btnTest6_BatchGrades);
            this.grpTestButtons.Controls.Add(this.btnTest5_SafeDeleteDept);
            this.grpTestButtons.Controls.Add(this.btnTest4_TransferDept);
            this.grpTestButtons.Controls.Add(this.btnTest3_TxRollback);
            this.grpTestButtons.Controls.Add(this.btnTest2_TxCommit);
            this.grpTestButtons.Controls.Add(this.btnTest1_MasterDetail);
            this.grpTestButtons.Controls.Add(this.btnRunAllTests);
            this.grpTestButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTestButtons.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpTestButtons.Location = new System.Drawing.Point(0, 0);
            this.grpTestButtons.Name = "grpTestButtons";
            this.grpTestButtons.Size = new System.Drawing.Size(420, 681);
            this.grpTestButtons.TabIndex = 0;
            this.grpTestButtons.TabStop = false;
            this.grpTestButtons.Text = "Bộ kịch bản kiểm thử tự động (Lab 12)";
            // 
            // btnRunAllTests
            // 
            this.btnRunAllTests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnRunAllTests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunAllTests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAllTests.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRunAllTests.ForeColor = System.Drawing.Color.White;
            this.btnRunAllTests.Location = new System.Drawing.Point(15, 30);
            this.btnRunAllTests.Name = "btnRunAllTests";
            this.btnRunAllTests.Size = new System.Drawing.Size(385, 45);
            this.btnRunAllTests.TabIndex = 0;
            this.btnRunAllTests.Text = "CHẠY TOÀN BỘ KIỂM THỬ (10 BÀI)";
            this.btnRunAllTests.UseVisualStyleBackColor = false;
            // 
            // btnTest1_MasterDetail
            // 
            this.btnTest1_MasterDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTest1_MasterDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest1_MasterDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest1_MasterDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest1_MasterDetail.Location = new System.Drawing.Point(15, 85);
            this.btnTest1_MasterDetail.Name = "btnTest1_MasterDetail";
            this.btnTest1_MasterDetail.Size = new System.Drawing.Size(385, 40);
            this.btnTest1_MasterDetail.TabIndex = 1;
            this.btnTest1_MasterDetail.Text = "1. Test Master-Detail 2 cấp (Khoa - SV - ĐK)";
            this.btnTest1_MasterDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest1_MasterDetail.UseVisualStyleBackColor = true;
            // 
            // btnTest2_TxCommit
            // 
            this.btnTest2_TxCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.btnTest2_TxCommit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest2_TxCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest2_TxCommit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest2_TxCommit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnTest2_TxCommit.Location = new System.Drawing.Point(15, 135);
            this.btnTest2_TxCommit.Name = "btnTest2_TxCommit";
            this.btnTest2_TxCommit.Size = new System.Drawing.Size(385, 40);
            this.btnTest2_TxCommit.TabIndex = 2;
            this.btnTest2_TxCommit.Text = "2. Test Transaction Thêm SV + ĐK (Commit)";
            this.btnTest2_TxCommit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest2_TxCommit.UseVisualStyleBackColor = false;
            // 
            // btnTest3_TxRollback
            // 
            this.btnTest3_TxRollback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnTest3_TxRollback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest3_TxRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest3_TxRollback.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest3_TxRollback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnTest3_TxRollback.Location = new System.Drawing.Point(15, 185);
            this.btnTest3_TxRollback.Name = "btnTest3_TxRollback";
            this.btnTest3_TxRollback.Size = new System.Drawing.Size(385, 40);
            this.btnTest3_TxRollback.TabIndex = 3;
            this.btnTest3_TxRollback.Text = "3. Test Mô phỏng vi phạm FK -> Rollback sạch";
            this.btnTest3_TxRollback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest3_TxRollback.UseVisualStyleBackColor = false;
            // 
            // btnTest4_TransferDept
            // 
            this.btnTest4_TransferDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTest4_TransferDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest4_TransferDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest4_TransferDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest4_TransferDept.Location = new System.Drawing.Point(15, 235);
            this.btnTest4_TransferDept.Name = "btnTest4_TransferDept";
            this.btnTest4_TransferDept.Size = new System.Drawing.Size(385, 40);
            this.btnTest4_TransferDept.TabIndex = 4;
            this.btnTest4_TransferDept.Text = "4. Test Chuyển khoa trong Transaction & Ghi log";
            this.btnTest4_TransferDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest4_TransferDept.UseVisualStyleBackColor = true;
            // 
            // btnTest5_SafeDeleteDept
            // 
            this.btnTest5_SafeDeleteDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTest5_SafeDeleteDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest5_SafeDeleteDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest5_SafeDeleteDept.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest5_SafeDeleteDept.Location = new System.Drawing.Point(15, 285);
            this.btnTest5_SafeDeleteDept.Name = "btnTest5_SafeDeleteDept";
            this.btnTest5_SafeDeleteDept.Size = new System.Drawing.Size(385, 40);
            this.btnTest5_SafeDeleteDept.TabIndex = 5;
            this.btnTest5_SafeDeleteDept.Text = "5. Test Xóa khoa an toàn (Di dời SV trước)";
            this.btnTest5_SafeDeleteDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest5_SafeDeleteDept.UseVisualStyleBackColor = true;
            // 
            // btnTest6_BatchGrades
            // 
            this.btnTest6_BatchGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTest6_BatchGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest6_BatchGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest6_BatchGrades.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest6_BatchGrades.Location = new System.Drawing.Point(15, 335);
            this.btnTest6_BatchGrades.Name = "btnTest6_BatchGrades";
            this.btnTest6_BatchGrades.Size = new System.Drawing.Size(385, 40);
            this.btnTest6_BatchGrades.TabIndex = 6;
            this.btnTest6_BatchGrades.Text = "6. Test Cập nhật điểm & Rollback khi điểm sai";
            this.btnTest6_BatchGrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest6_BatchGrades.UseVisualStyleBackColor = true;
            // 
            // btnTest7_Concurrency
            // 
            this.btnTest7_Concurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.btnTest7_Concurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest7_Concurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest7_Concurrency.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest7_Concurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.btnTest7_Concurrency.Location = new System.Drawing.Point(15, 385);
            this.btnTest7_Concurrency.Name = "btnTest7_Concurrency";
            this.btnTest7_Concurrency.Size = new System.Drawing.Size(385, 40);
            this.btnTest7_Concurrency.TabIndex = 7;
            this.btnTest7_Concurrency.Text = "7. Test Xung đột đồng thời (RowVersion / OCC)";
            this.btnTest7_Concurrency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest7_Concurrency.UseVisualStyleBackColor = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearLog.Location = new System.Drawing.Point(15, 440);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(385, 35);
            this.btnClearLog.TabIndex = 8;
            this.btnClearLog.Text = "Xóa nhật ký màn hình";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // grpAuditLog
            // 
            this.grpAuditLog.Controls.Add(this.txtAuditLog);
            this.grpAuditLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAuditLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpAuditLog.Location = new System.Drawing.Point(0, 0);
            this.grpAuditLog.Name = "grpAuditLog";
            this.grpAuditLog.Padding = new System.Windows.Forms.Padding(6);
            this.grpAuditLog.Size = new System.Drawing.Size(818, 681);
            this.grpAuditLog.TabIndex = 0;
            this.grpAuditLog.TabStop = false;
            this.grpAuditLog.Text = "Nhật ký kiểm thử toàn diện giải pháp 3 lớp (Bài 10)";
            // 
            // txtAuditLog
            // 
            this.txtAuditLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAuditLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAuditLog.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAuditLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtAuditLog.Location = new System.Drawing.Point(6, 28);
            this.txtAuditLog.Multiline = true;
            this.txtAuditLog.Name = "txtAuditLog";
            this.txtAuditLog.ReadOnly = true;
            this.txtAuditLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditLog.Size = new System.Drawing.Size(806, 647);
            this.txtAuditLog.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStudentInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1262, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(161, 20);
            this.lblStatus.Text = "Sẵn sàng hoạt động.";
            // 
            // lblStudentInfo
            // 
            this.lblStudentInfo.Name = "lblStudentInfo";
            this.lblStudentInfo.Size = new System.Drawing.Size(1086, 20);
            this.lblStudentInfo.Spring = true;
            this.lblStudentInfo.Text = "Học phần: IT3212 - EAUT | SV: Phan Văn Thắng - MSSV: 24002545 | Lab 12";
            this.lblStudentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(1150, 720);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT3212 - Lab 12: Master-Detail, SqlTransaction & Hoàn Thiện Mô Hình 3 Lớp - Phan Văn Thắng (24002545)";
            this.tabControl.ResumeLayout(false);
            this.tabMasterDetail.ResumeLayout(false);
            this.splitContainerMaster.Panel1.ResumeLayout(false);
            this.splitContainerMaster.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaster)).EndInit();
            this.splitContainerMaster.ResumeLayout(false);
            this.grpKhoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.splitContainerDetail.Panel1.ResumeLayout(false);
            this.splitContainerDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetail)).EndInit();
            this.splitContainerDetail.ResumeLayout(false);
            this.grpSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.grpDangKy.ResumeLayout(false);
            this.pnlThemDangKy.ResumeLayout(false);
            this.pnlThemDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.tabTransaction.ResumeLayout(false);
            this.splitContainerTx.Panel1.ResumeLayout(false);
            this.splitContainerTx.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTx)).EndInit();
            this.splitContainerTx.ResumeLayout(false);
            this.grpTxForm.ResumeLayout(false);
            this.grpTxForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTxDiemTB)).EndInit();
            this.grpTxLog.ResumeLayout(false);
            this.grpTxLog.PerformLayout();
            this.tabChuyenKhoa.ResumeLayout(false);
            this.splitContainerCK.Panel1.ResumeLayout(false);
            this.splitContainerCK.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCK)).EndInit();
            this.splitContainerCK.ResumeLayout(false);
            this.grpChuyenKhoaAction.ResumeLayout(false);
            this.grpChuyenKhoaAction.PerformLayout();
            this.grpLichSuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.tabDiemConcurrency.ResumeLayout(false);
            this.splitContainerDC.Panel1.ResumeLayout(false);
            this.splitContainerDC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDC)).EndInit();
            this.splitContainerDC.ResumeLayout(false);
            this.grpBatchGrade.ResumeLayout(false);
            this.pnlBatchGradeHeader.ResumeLayout(false);
            this.pnlBatchGradeHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchGrades)).EndInit();
            this.grpConcurrency.ResumeLayout(false);
            this.grpConcurrency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOccDiemTB)).EndInit();
            this.tabKiemThu.ResumeLayout(false);
            this.splitContainerKT.Panel1.ResumeLayout(false);
            this.splitContainerKT.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKT)).EndInit();
            this.splitContainerKT.ResumeLayout(false);
            this.grpTestButtons.ResumeLayout(false);
            this.grpAuditLog.ResumeLayout(false);
            this.grpAuditLog.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMasterDetail;
        private System.Windows.Forms.SplitContainer splitContainerMaster;
        private System.Windows.Forms.GroupBox grpKhoa;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.SplitContainer splitContainerDetail;
        private System.Windows.Forms.GroupBox grpSinhVien;
        private System.Windows.Forms.Label lblChiTietKhoa;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.GroupBox grpDangKy;
        private System.Windows.Forms.Label lblChiTietSV;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Panel pnlThemDangKy;
        private System.Windows.Forms.Label lblChonHP;
        private System.Windows.Forms.ComboBox cboHocPhan;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.NumericUpDown nudHocKy;
        private System.Windows.Forms.Button btnThemDangKy;
        private System.Windows.Forms.TabPage tabTransaction;
        private System.Windows.Forms.SplitContainer splitContainerTx;
        private System.Windows.Forms.GroupBox grpTxForm;
        private System.Windows.Forms.Label lblTxMaSV;
        private System.Windows.Forms.TextBox txtTxMaSV;
        private System.Windows.Forms.Label lblTxHoTen;
        private System.Windows.Forms.TextBox txtTxHoTen;
        private System.Windows.Forms.Label lblTxNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpTxNgaySinh;
        private System.Windows.Forms.Label lblTxDiem;
        private System.Windows.Forms.NumericUpDown nudTxDiemTB;
        private System.Windows.Forms.Label lblTxKhoa;
        private System.Windows.Forms.ComboBox cboTxKhoa;
        private System.Windows.Forms.Label lblTxEmail;
        private System.Windows.Forms.TextBox txtTxEmail;
        private System.Windows.Forms.Label lblTxCourses;
        private System.Windows.Forms.CheckedListBox chkListCourses;
        private System.Windows.Forms.Button btnCommitTx;
        private System.Windows.Forms.Button btnSimulateRollback;
        private System.Windows.Forms.GroupBox grpTxLog;
        private System.Windows.Forms.TextBox txtTxLog;
        private System.Windows.Forms.TabPage tabChuyenKhoa;
        private System.Windows.Forms.SplitContainer splitContainerCK;
        private System.Windows.Forms.GroupBox grpChuyenKhoaAction;
        private System.Windows.Forms.Label lblCkTitle1;
        private System.Windows.Forms.Label lblCkSV;
        private System.Windows.Forms.ComboBox cboCkSinhVien;
        private System.Windows.Forms.Label lblCkKhoaMoi;
        private System.Windows.Forms.ComboBox cboCkKhoaMoi;
        private System.Windows.Forms.Label lblCkLyDo;
        private System.Windows.Forms.TextBox txtCkLyDo;
        private System.Windows.Forms.Button btnThucHienChuyenKhoa;
        private System.Windows.Forms.Label lblCkDivider;
        private System.Windows.Forms.Label lblCkTitle2;
        private System.Windows.Forms.Label lblXkKhoaXoa;
        private System.Windows.Forms.ComboBox cboXkKhoaXoa;
        private System.Windows.Forms.Label lblXkKhoaDen;
        private System.Windows.Forms.ComboBox cboXkKhoaDen;
        private System.Windows.Forms.Button btnThucHienXoaKhoaAnToan;
        private System.Windows.Forms.GroupBox grpLichSuGrid;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.TabPage tabDiemConcurrency;
        private System.Windows.Forms.SplitContainer splitContainerDC;
        private System.Windows.Forms.GroupBox grpBatchGrade;
        private System.Windows.Forms.Panel pnlBatchGradeHeader;
        private System.Windows.Forms.Label lblBatchFilterSV;
        private System.Windows.Forms.ComboBox cboBatchSV;
        private System.Windows.Forms.Button btnBatchLoadGrades;
        private System.Windows.Forms.Button btnBatchSaveCommit;
        private System.Windows.Forms.Button btnBatchTestInvalidRollback;
        private System.Windows.Forms.DataGridView dgvBatchGrades;
        private System.Windows.Forms.GroupBox grpConcurrency;
        private System.Windows.Forms.Label lblOccNotice;
        private System.Windows.Forms.Label lblOccSV;
        private System.Windows.Forms.ComboBox cboOccSV;
        private System.Windows.Forms.Label lblOccHoTen;
        private System.Windows.Forms.TextBox txtOccHoTen;
        private System.Windows.Forms.Label lblOccDiemTB;
        private System.Windows.Forms.NumericUpDown nudOccDiemTB;
        private System.Windows.Forms.Label lblOccRowVer;
        private System.Windows.Forms.TextBox txtOccRowVer;
        private System.Windows.Forms.Button btnOccSaveNormal;
        private System.Windows.Forms.Button btnOccSimulateConflict;
        private System.Windows.Forms.TabPage tabKiemThu;
        private System.Windows.Forms.SplitContainer splitContainerKT;
        private System.Windows.Forms.GroupBox grpTestButtons;
        private System.Windows.Forms.Button btnRunAllTests;
        private System.Windows.Forms.Button btnTest1_MasterDetail;
        private System.Windows.Forms.Button btnTest2_TxCommit;
        private System.Windows.Forms.Button btnTest3_TxRollback;
        private System.Windows.Forms.Button btnTest4_TransferDept;
        private System.Windows.Forms.Button btnTest5_SafeDeleteDept;
        private System.Windows.Forms.Button btnTest6_BatchGrades;
        private System.Windows.Forms.Button btnTest7_Concurrency;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox grpAuditLog;
        private System.Windows.Forms.TextBox txtAuditLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStudentInfo;
    }
}
