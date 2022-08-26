namespace TestbedDAQ.Forms
{
    partial class frmMCManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdx = new System.Windows.Forms.TextBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.btnCodeCopy = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPlcMaker = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPlcModel = new System.Windows.Forms.TextBox();
            this.txtPlcVersion = new System.Windows.Forms.TextBox();
            this.cbFac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMotorCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMakerDateTime = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.txtPlcPort = new System.Windows.Forms.TextBox();
            this.txtPlcIp = new System.Windows.Forms.TextBox();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc_idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plc_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auto_start_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volt_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_load_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peak_load_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machining_time_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_code_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_size_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_size_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machining_count_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_gubun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reg_worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reg_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPlcDataRemove = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPlcDataAdd = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.idx2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc_idx2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origin_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.new_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_save2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_gubun2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reg_worker2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reg_datetime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_worker2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_datetime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_datetime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFileRemove = new System.Windows.Forms.Button();
            this.btnFileUpload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCode
            // 
            this.cbCode.BackColor = System.Drawing.SystemColors.Window;
            this.cbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cbCode.FormattingEnabled = true;
            this.cbCode.IntegralHeight = false;
            this.cbCode.ItemHeight = 25;
            this.cbCode.Location = new System.Drawing.Point(183, 33);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(508, 33);
            this.cbCode.TabIndex = 185;
            this.cbCode.SelectedIndexChanged += new System.EventHandler(this.cbCode_SelectedIndexChanged);
            this.cbCode.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(394, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 50);
            this.label4.TabIndex = 184;
            this.label4.Text = "idx";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdx
            // 
            this.txtIdx.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdx.Enabled = false;
            this.txtIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtIdx.Location = new System.Drawing.Point(511, 351);
            this.txtIdx.Name = "txtIdx";
            this.txtIdx.Size = new System.Drawing.Size(180, 32);
            this.txtIdx.TabIndex = 183;
            // 
            // txtMaker
            // 
            this.txtMaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtMaker.Location = new System.Drawing.Point(183, 245);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(180, 32);
            this.txtMaker.TabIndex = 167;
            this.txtMaker.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // btnCodeCopy
            // 
            this.btnCodeCopy.Location = new System.Drawing.Point(697, 33);
            this.btnCodeCopy.Name = "btnCodeCopy";
            this.btnCodeCopy.Size = new System.Drawing.Size(129, 33);
            this.btnCodeCopy.TabIndex = 182;
            this.btnCodeCopy.Text = "다른 코드로 저장";
            this.btnCodeCopy.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(945, 245);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(508, 139);
            this.txtRemark.TabIndex = 181;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(828, 236);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 50);
            this.label17.TabIndex = 176;
            this.label17.Text = "비고";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(828, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 50);
            this.label14.TabIndex = 175;
            this.label14.Text = "PLC 모델";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlcMaker
            // 
            this.txtPlcMaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlcMaker.Location = new System.Drawing.Point(945, 139);
            this.txtPlcMaker.Name = "txtPlcMaker";
            this.txtPlcMaker.Size = new System.Drawing.Size(508, 32);
            this.txtPlcMaker.TabIndex = 179;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(828, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 50);
            this.label15.TabIndex = 174;
            this.label15.Text = "PLC 제조사";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(828, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 50);
            this.label13.TabIndex = 173;
            this.label13.Text = "PLC 버전";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlcModel
            // 
            this.txtPlcModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlcModel.Location = new System.Drawing.Point(945, 192);
            this.txtPlcModel.Name = "txtPlcModel";
            this.txtPlcModel.Size = new System.Drawing.Size(508, 32);
            this.txtPlcModel.TabIndex = 180;
            // 
            // txtPlcVersion
            // 
            this.txtPlcVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlcVersion.Location = new System.Drawing.Point(945, 86);
            this.txtPlcVersion.Name = "txtPlcVersion";
            this.txtPlcVersion.Size = new System.Drawing.Size(508, 32);
            this.txtPlcVersion.TabIndex = 178;
            // 
            // cbFac
            // 
            this.cbFac.BackColor = System.Drawing.SystemColors.Window;
            this.cbFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cbFac.FormattingEnabled = true;
            this.cbFac.IntegralHeight = false;
            this.cbFac.ItemHeight = 25;
            this.cbFac.Location = new System.Drawing.Point(945, 33);
            this.cbFac.Name = "cbFac";
            this.cbFac.Size = new System.Drawing.Size(508, 33);
            this.cbFac.TabIndex = 177;
            this.cbFac.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(828, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 50);
            this.label1.TabIndex = 172;
            this.label1.Text = "사업장";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDept
            // 
            this.txtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtDept.Location = new System.Drawing.Point(183, 192);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(180, 32);
            this.txtDept.TabIndex = 165;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(67, 236);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 50);
            this.label18.TabIndex = 161;
            this.label18.Text = "설비 제조사";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(67, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 50);
            this.label6.TabIndex = 160;
            this.label6.Text = "설비 상태";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(67, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 50);
            this.label10.TabIndex = 159;
            this.label10.Text = "PLC IP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbLocation
            // 
            this.cbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.cbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.ItemHeight = 25;
            this.cbLocation.Location = new System.Drawing.Point(511, 192);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(180, 33);
            this.cbLocation.TabIndex = 166;
            this.cbLocation.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(394, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 50);
            this.label9.TabIndex = 158;
            this.label9.Text = "설비 위치";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(67, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 50);
            this.label8.TabIndex = 157;
            this.label8.Text = "설비 작업 부서";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMotorCount
            // 
            this.txtMotorCount.BackColor = System.Drawing.SystemColors.Window;
            this.txtMotorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtMotorCount.Location = new System.Drawing.Point(511, 139);
            this.txtMotorCount.Name = "txtMotorCount";
            this.txtMotorCount.Size = new System.Drawing.Size(180, 32);
            this.txtMotorCount.TabIndex = 164;
            this.txtMotorCount.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(394, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 50);
            this.label12.TabIndex = 156;
            this.label12.Text = "설비 모터 수";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(67, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 50);
            this.label7.TabIndex = 155;
            this.label7.Text = "설비규격";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMakerDateTime
            // 
            this.txtMakerDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtMakerDateTime.Location = new System.Drawing.Point(511, 245);
            this.txtMakerDateTime.Name = "txtMakerDateTime";
            this.txtMakerDateTime.Size = new System.Drawing.Size(180, 32);
            this.txtMakerDateTime.TabIndex = 168;
            // 
            // cbState
            // 
            this.cbState.BackColor = System.Drawing.SystemColors.Window;
            this.cbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.cbState.FormattingEnabled = true;
            this.cbState.IntegralHeight = false;
            this.cbState.ItemHeight = 25;
            this.cbState.Location = new System.Drawing.Point(183, 351);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(180, 33);
            this.cbState.TabIndex = 171;
            this.cbState.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // txtPlcPort
            // 
            this.txtPlcPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlcPort.Location = new System.Drawing.Point(511, 298);
            this.txtPlcPort.Name = "txtPlcPort";
            this.txtPlcPort.Size = new System.Drawing.Size(180, 32);
            this.txtPlcPort.TabIndex = 170;
            // 
            // txtPlcIp
            // 
            this.txtPlcIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPlcIp.Location = new System.Drawing.Point(183, 298);
            this.txtPlcIp.Name = "txtPlcIp";
            this.txtPlcIp.Size = new System.Drawing.Size(180, 32);
            this.txtPlcIp.TabIndex = 169;
            // 
            // txtSpec
            // 
            this.txtSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtSpec.Location = new System.Drawing.Point(183, 139);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(180, 32);
            this.txtSpec.TabIndex = 163;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtName.Location = new System.Drawing.Point(183, 86);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(508, 32);
            this.txtName.TabIndex = 162;
            this.txtName.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(394, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 50);
            this.label11.TabIndex = 154;
            this.label11.Text = "PLC port";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(394, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 50);
            this.label5.TabIndex = 153;
            this.label5.Text = "설비 제조일자";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(67, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 50);
            this.label3.TabIndex = 152;
            this.label3.Text = "설비명";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(67, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 50);
            this.label2.TabIndex = 151;
            this.label2.Text = "설비코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("굴림", 9F);
            this.tabControl1.Location = new System.Drawing.Point(58, 417);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1395, 411);
            this.tabControl1.TabIndex = 186;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv1);
            this.tabPage1.Controls.Add(this.btnPlcDataRemove);
            this.tabPage1.Controls.Add(this.btnExcel);
            this.tabPage1.Controls.Add(this.btnPlcDataAdd);
            this.tabPage1.Font = new System.Drawing.Font("굴림", 9F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1387, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PLC 데이터 주소";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idx,
            this.mc_idx,
            this.plc_version,
            this.auto_start_address,
            this.speed_address,
            this.volt_address,
            this.current_address,
            this.current_load_address,
            this.peak_load_address,
            this.machining_time_address,
            this.alarm_code_address,
            this.product_size_address,
            this.current_size_address,
            this.machining_count_address,
            this.remark,
            this.del_gubun,
            this.reg_worker,
            this.reg_datetime,
            this.mod_worker,
            this.mod_datetime,
            this.del_datetime});
            this.dgv1.Location = new System.Drawing.Point(3, 43);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1381, 306);
            this.dgv1.TabIndex = 193;
            // 
            // idx
            // 
            this.idx.DataPropertyName = "idx";
            this.idx.HeaderText = "idx";
            this.idx.Name = "idx";
            // 
            // mc_idx
            // 
            this.mc_idx.DataPropertyName = "mc_idx";
            this.mc_idx.HeaderText = "mc_idx";
            this.mc_idx.Name = "mc_idx";
            // 
            // plc_version
            // 
            this.plc_version.DataPropertyName = "plc_version";
            this.plc_version.HeaderText = "plc_version";
            this.plc_version.Name = "plc_version";
            // 
            // auto_start_address
            // 
            this.auto_start_address.DataPropertyName = "auto_start_address";
            this.auto_start_address.HeaderText = "auto_start_address";
            this.auto_start_address.Name = "auto_start_address";
            // 
            // speed_address
            // 
            this.speed_address.DataPropertyName = "speed_address";
            this.speed_address.HeaderText = "speed_address";
            this.speed_address.Name = "speed_address";
            // 
            // volt_address
            // 
            this.volt_address.DataPropertyName = "volt_address";
            this.volt_address.HeaderText = "volt_address";
            this.volt_address.Name = "volt_address";
            // 
            // current_address
            // 
            this.current_address.DataPropertyName = "current_address";
            this.current_address.HeaderText = "current_address";
            this.current_address.Name = "current_address";
            // 
            // current_load_address
            // 
            this.current_load_address.DataPropertyName = "current_load_address";
            this.current_load_address.HeaderText = "current_load_address";
            this.current_load_address.Name = "current_load_address";
            // 
            // peak_load_address
            // 
            this.peak_load_address.DataPropertyName = "peak_load_address";
            this.peak_load_address.HeaderText = "peak_load_address";
            this.peak_load_address.Name = "peak_load_address";
            // 
            // machining_time_address
            // 
            this.machining_time_address.DataPropertyName = "machining_time_address";
            this.machining_time_address.HeaderText = "machining_time_address";
            this.machining_time_address.Name = "machining_time_address";
            // 
            // alarm_code_address
            // 
            this.alarm_code_address.DataPropertyName = "alarm_code_address";
            this.alarm_code_address.HeaderText = "alarm_code_address";
            this.alarm_code_address.Name = "alarm_code_address";
            // 
            // product_size_address
            // 
            this.product_size_address.DataPropertyName = "product_size_address";
            this.product_size_address.HeaderText = "product_size_address";
            this.product_size_address.Name = "product_size_address";
            // 
            // current_size_address
            // 
            this.current_size_address.DataPropertyName = "current_size_address";
            this.current_size_address.HeaderText = "current_size_address";
            this.current_size_address.Name = "current_size_address";
            // 
            // machining_count_address
            // 
            this.machining_count_address.DataPropertyName = "machining_count_address";
            this.machining_count_address.HeaderText = "machining_count_address";
            this.machining_count_address.Name = "machining_count_address";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "remark";
            this.remark.Name = "remark";
            // 
            // del_gubun
            // 
            this.del_gubun.DataPropertyName = "del_gubun";
            this.del_gubun.HeaderText = "del_gubun";
            this.del_gubun.Name = "del_gubun";
            // 
            // reg_worker
            // 
            this.reg_worker.DataPropertyName = "reg_worker";
            this.reg_worker.HeaderText = "reg_worker";
            this.reg_worker.Name = "reg_worker";
            // 
            // reg_datetime
            // 
            this.reg_datetime.DataPropertyName = "reg_datetime";
            this.reg_datetime.HeaderText = "reg_datetime";
            this.reg_datetime.Name = "reg_datetime";
            // 
            // mod_worker
            // 
            this.mod_worker.DataPropertyName = "mod_worker";
            this.mod_worker.HeaderText = "mod_worker";
            this.mod_worker.Name = "mod_worker";
            // 
            // mod_datetime
            // 
            this.mod_datetime.DataPropertyName = "mod_datetime";
            this.mod_datetime.HeaderText = "mod_datetime";
            this.mod_datetime.Name = "mod_datetime";
            // 
            // del_datetime
            // 
            this.del_datetime.DataPropertyName = "del_datetime";
            this.del_datetime.HeaderText = "del_datetime";
            this.del_datetime.Name = "del_datetime";
            // 
            // btnPlcDataRemove
            // 
            this.btnPlcDataRemove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlcDataRemove.FlatAppearance.BorderSize = 0;
            this.btnPlcDataRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcDataRemove.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnPlcDataRemove.Location = new System.Drawing.Point(1219, 3);
            this.btnPlcDataRemove.Name = "btnPlcDataRemove";
            this.btnPlcDataRemove.Size = new System.Drawing.Size(164, 37);
            this.btnPlcDataRemove.TabIndex = 192;
            this.btnPlcDataRemove.Text = "행 삭제";
            this.btnPlcDataRemove.UseVisualStyleBackColor = false;
            this.btnPlcDataRemove.Click += new System.EventHandler(this.btnPlcDataRemove_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnExcel.Location = new System.Drawing.Point(885, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(164, 37);
            this.btnExcel.TabIndex = 191;
            this.btnExcel.Text = "엑셀 업로드";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPlcDataAdd
            // 
            this.btnPlcDataAdd.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlcDataAdd.FlatAppearance.BorderSize = 0;
            this.btnPlcDataAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlcDataAdd.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnPlcDataAdd.Location = new System.Drawing.Point(1052, 3);
            this.btnPlcDataAdd.Name = "btnPlcDataAdd";
            this.btnPlcDataAdd.Size = new System.Drawing.Size(164, 37);
            this.btnPlcDataAdd.TabIndex = 190;
            this.btnPlcDataAdd.Text = "행 추가";
            this.btnPlcDataAdd.UseVisualStyleBackColor = false;
            this.btnPlcDataAdd.Click += new System.EventHandler(this.btnPlcDataAdd_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv2);
            this.tabPage2.Controls.Add(this.btnFileRemove);
            this.tabPage2.Controls.Add(this.btnFileUpload);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1387, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "이미지 첨부";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idx2,
            this.mc_idx2,
            this.path2,
            this.origin_name2,
            this.new_name2,
            this.file_save2,
            this.del_gubun2,
            this.reg_worker2,
            this.reg_datetime2,
            this.mod_worker2,
            this.mod_datetime2,
            this.del_datetime2});
            this.dgv2.Location = new System.Drawing.Point(3, 43);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowTemplate.Height = 23;
            this.dgv2.Size = new System.Drawing.Size(1381, 306);
            this.dgv2.TabIndex = 195;
            this.dgv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellClick);
            // 
            // idx2
            // 
            this.idx2.DataPropertyName = "idx";
            this.idx2.HeaderText = "idx";
            this.idx2.Name = "idx2";
            // 
            // mc_idx2
            // 
            this.mc_idx2.DataPropertyName = "mc_idx";
            this.mc_idx2.HeaderText = "mc_idx";
            this.mc_idx2.Name = "mc_idx2";
            // 
            // path2
            // 
            this.path2.DataPropertyName = "path";
            this.path2.HeaderText = "path";
            this.path2.Name = "path2";
            // 
            // origin_name2
            // 
            this.origin_name2.DataPropertyName = "origin_name";
            this.origin_name2.HeaderText = "origin_name";
            this.origin_name2.Name = "origin_name2";
            // 
            // new_name2
            // 
            this.new_name2.DataPropertyName = "new_name";
            this.new_name2.HeaderText = "new_name";
            this.new_name2.Name = "new_name2";
            // 
            // file_save2
            // 
            this.file_save2.DataPropertyName = "file_save";
            this.file_save2.HeaderText = "file_save";
            this.file_save2.Name = "file_save2";
            // 
            // del_gubun2
            // 
            this.del_gubun2.DataPropertyName = "del_gubun";
            this.del_gubun2.HeaderText = "del_gubun";
            this.del_gubun2.Name = "del_gubun2";
            // 
            // reg_worker2
            // 
            this.reg_worker2.DataPropertyName = "reg_worker";
            this.reg_worker2.HeaderText = "reg_worker";
            this.reg_worker2.Name = "reg_worker2";
            // 
            // reg_datetime2
            // 
            this.reg_datetime2.DataPropertyName = "reg_datetime";
            this.reg_datetime2.HeaderText = "reg_datetime";
            this.reg_datetime2.Name = "reg_datetime2";
            // 
            // mod_worker2
            // 
            this.mod_worker2.DataPropertyName = "mod_worker";
            this.mod_worker2.HeaderText = "mod_worker";
            this.mod_worker2.Name = "mod_worker2";
            // 
            // mod_datetime2
            // 
            this.mod_datetime2.DataPropertyName = "mod_datetime";
            this.mod_datetime2.HeaderText = "mod_datetime";
            this.mod_datetime2.Name = "mod_datetime2";
            // 
            // del_datetime2
            // 
            this.del_datetime2.DataPropertyName = "del_datetime";
            this.del_datetime2.HeaderText = "del_datetime";
            this.del_datetime2.Name = "del_datetime2";
            // 
            // btnFileRemove
            // 
            this.btnFileRemove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFileRemove.FlatAppearance.BorderSize = 0;
            this.btnFileRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileRemove.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnFileRemove.Location = new System.Drawing.Point(1219, 3);
            this.btnFileRemove.Name = "btnFileRemove";
            this.btnFileRemove.Size = new System.Drawing.Size(164, 37);
            this.btnFileRemove.TabIndex = 194;
            this.btnFileRemove.Text = "이미지 삭제";
            this.btnFileRemove.UseVisualStyleBackColor = false;
            this.btnFileRemove.Click += new System.EventHandler(this.btnFileRemove_Click);
            // 
            // btnFileUpload
            // 
            this.btnFileUpload.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFileUpload.FlatAppearance.BorderSize = 0;
            this.btnFileUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileUpload.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnFileUpload.Location = new System.Drawing.Point(1052, 3);
            this.btnFileUpload.Name = "btnFileUpload";
            this.btnFileUpload.Size = new System.Drawing.Size(164, 37);
            this.btnFileUpload.TabIndex = 193;
            this.btnFileUpload.Text = "이미지 첨부";
            this.btnFileUpload.UseVisualStyleBackColor = false;
            this.btnFileUpload.Click += new System.EventHandler(this.btnFileUpload_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnClose.Location = new System.Drawing.Point(1282, 834);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 62);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "삭제";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnNew.Location = new System.Drawing.Point(948, 834);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(164, 62);
            this.btnNew.TabIndex = 188;
            this.btnNew.Text = "신규";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.btnSave.Location = new System.Drawing.Point(1115, 834);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 62);
            this.btnSave.TabIndex = 187;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1484, 33);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(383, 863);
            this.listView1.TabIndex = 194;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // frmMCManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TestbedDAQ.Properties.Resources.body_bottom02;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1920, 928);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdx);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.btnCodeCopy);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPlcMaker);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPlcModel);
            this.Controls.Add(this.txtPlcVersion);
            this.Controls.Add(this.cbFac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMotorCount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMakerDateTime);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.txtPlcPort);
            this.Controls.Add(this.txtPlcIp);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMCManager";
            this.Text = "frmMCManager";
            this.Load += new System.EventHandler(this.frmMCManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdx;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Button btnCodeCopy;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPlcMaker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPlcModel;
        private System.Windows.Forms.TextBox txtPlcVersion;
        private System.Windows.Forms.ComboBox cbFac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMotorCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMakerDateTime;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.TextBox txtPlcPort;
        private System.Windows.Forms.TextBox txtPlcIp;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnPlcDataRemove;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPlcDataAdd;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc_idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn plc_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn auto_start_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn volt_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_load_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn peak_load_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn machining_time_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_code_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_size_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_size_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn machining_count_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_gubun;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_datetime;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc_idx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn path2;
        private System.Windows.Forms.DataGridViewTextBoxColumn origin_name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn new_name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_save2;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_gubun2;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_worker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_datetime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_worker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_datetime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_datetime2;
        private System.Windows.Forms.Button btnFileRemove;
        private System.Windows.Forms.Button btnFileUpload;
        private System.Windows.Forms.ListView listView1;
    }
}