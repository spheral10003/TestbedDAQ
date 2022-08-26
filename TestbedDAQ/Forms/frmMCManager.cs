using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using TestbedDAQ.UseClass;

namespace TestbedDAQ.Forms
{
    public partial class frmMCManager : Form
    {

        private TestbedDB _db;
        private StringBuilder _sQuery;
        private SqlParameter[] _sqlParams;

        private OpenFileDialog _diaLog;
        private ImageList _imageList;

        private List<Image> _listImage = new List<Image>();

        //private List<Image> _imageList1;

        public static string _gbMcCode = string.Empty;

        private List<MachineInformation> _MachineInformation;
        private List<PLCAddressMap> _PLCAddressMap;


        public List<MachineInformation> MachineInformationList { get => _MachineInformation; set => _MachineInformation = value; }
        public List<PLCAddressMap> PLCAddressMap { get => _PLCAddressMap; set => _PLCAddressMap = value; }
        

        public frmMCManager()
        {
            InitializeComponent();
        }

        private void frmMCManager_Load(object sender, EventArgs e)
        {
            #region 주석
            //frmMain frm = (frmMain)this.Owner;
            //frm.MachineInformationList = _MachineInformation;
            //frm.label3_Click(null, null);
            #endregion

            try
            {
                CreateDB();
                CtrInit();
                ComboSetting();
                Search(_gbMcCode);
                CtrColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        public void CreateDB()
        {
            try
            {
                _db = new TestbedDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        public void CtrInit()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                #region 설비정보 초기화 및 셋팅
                this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cbCode.Text = string.Empty;
                txtName.Text = string.Empty;
                txtSpec.Text = string.Empty;
                txtMaker.Text = string.Empty;
                txtMotorCount.Text = string.Empty;
                txtPlcIp.Text = string.Empty;
                txtPlcPort.Text = string.Empty;
                txtPlcVersion.Text = string.Empty;
                txtPlcMaker.Text = string.Empty;
                txtPlcModel.Text = string.Empty;
                txtMakerDateTime.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtDept.Text = string.Empty;
                txtIdx.Text = string.Empty;

                cbFac.Text = string.Empty;
                cbLocation.Text = string.Empty;
                cbState.Text = string.Empty;
                #endregion

                #region TAB1 PLC 그리드1 초기화
                int numRows1 = dgv1.Rows.Count;
                for (int i = 0; i < numRows1; i++)
                {
                    int max = dgv1.Rows.Count - 1;
                    dgv1.Rows.Remove(dgv1.Rows[max]);
                }

                dt1.Columns.Add("idx", typeof(decimal));
                dt1.Columns.Add("mc_idx", typeof(decimal));
                dt1.Columns.Add("plc_version", typeof(string));
                dt1.Columns.Add("auto_start_address", typeof(string));
                dt1.Columns.Add("speed_address", typeof(string));
                dt1.Columns.Add("volt_address", typeof(string));
                dt1.Columns.Add("current_address", typeof(string));
                dt1.Columns.Add("current_load_address", typeof(string));
                dt1.Columns.Add("peak_load_address", typeof(string));
                dt1.Columns.Add("machining_time_address", typeof(string));
                dt1.Columns.Add("alarm_code_address", typeof(string));
                dt1.Columns.Add("product_size_address", typeof(string));
                dt1.Columns.Add("current_size_address", typeof(string));
                dt1.Columns.Add("machining_count_address", typeof(string));
                dt1.Columns.Add("remark", typeof(string));
                dt1.Columns.Add("del_gubun", typeof(string));
                dt1.Columns.Add("reg_worker", typeof(string));
                dt1.Columns.Add("reg_datetime", typeof(string));
                dt1.Columns.Add("mod_worker", typeof(string));
                dt1.Columns.Add("mod_datetime", typeof(string));
                dt1.Columns.Add("del_datetime", typeof(string));
                dt1.Rows.Add(0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                dgv1.DataSource = dt1;
                dgv1.Rows.Remove(dgv1.Rows[0]);
                #endregion

                #region TAB2 이미지 파일 그리드 초기화
                int numRows2 = dgv2.Rows.Count;
                for (int i = 0; i < numRows2; i++)
                {
                    int max = dgv2.Rows.Count - 1;
                    dgv2.Rows.Remove(dgv2.Rows[max]);
                }

                dt2.Columns.Add("idx", typeof(decimal));
                dt2.Columns.Add("mc_idx", typeof(decimal));
                dt2.Columns.Add("path", typeof(string));
                dt2.Columns.Add("origin_name", typeof(string));
                dt2.Columns.Add("new_name", typeof(string));
                dt2.Columns.Add("file_save", typeof(string));
                dt2.Columns.Add("del_gubun", typeof(string));
                dt2.Columns.Add("reg_worker", typeof(string));
                dt2.Columns.Add("reg_datetime", typeof(string));
                dt2.Columns.Add("mod_worker", typeof(string));
                dt2.Columns.Add("mod_datetime", typeof(string));
                dt2.Columns.Add("del_datetime", typeof(string));
                dt2.Rows.Add(0, 0, "", "", "", "", "", "", "", "", "", "");
                dgv2.DataSource = dt2;
                dgv2.Rows.Remove(dgv2.Rows[0]);
                #endregion

                #region TAB2 리스트 뷰 초기화
                listView1.Items.Clear();
                #endregion

                #region 각 생성자 초기화
                _imageList = null;
                //_imageList1 = new List<Image>();
                _listImage = new List<Image>();
                _diaLog = null;
                _sqlParams = null;
                _sQuery = null;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (dt1 != null) dt1.Dispose();
                if (dt2 != null) dt2.Dispose();
            }
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            try
            {
                TestbedLeave.GetCtrLeaveColor((Control)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;

            }
            finally
            {

            }
        }

        public void ComboSetting()
        {
            DataTable dt = new DataTable();
            _db.ConnectDB();
            try
            {
                _sQuery = new StringBuilder();
                _sQuery.Append("	SELECT	a.code  as code                     ");
                _sQuery.Append("	FROM	tb_machine_mst a WITH(NOLOCK)       ");
                _sQuery.Append("	WHERE  1 = 1                                ");
                _sqlParams = new SqlParameter[] { };

                dt = _db.GetDataView("search_code", _sQuery, _sqlParams).Table;

                cbCode.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbCode.Items.Add(dt.DataSet.Tables["search_code"].Rows[i]["code"].ToString());
                }

                cbState.Items.Clear();
                cbState.Items.Add("정상");
                cbState.Items.Add("비정상");

                cbFac.Items.Clear();
                cbFac.Items.Add("정남사업장");
                cbFac.Items.Add("장수사업장");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (dt != null) dt.Dispose();
                if (_sQuery != null) _sQuery.Clear();
                if (_sqlParams != null) _sqlParams = null;
                _db.CloseDB();
            }
        }

        public void Search(string sMcCode)
        {
            _db.ConnectDB();
            DataTable dt = new DataTable();
            _imageList = new ImageList();
            //_imageList1 = new List<Image>();

            string sIdx = string.Empty;

            //if (ComDB.testCode.Length > 0)
            //{
            //    cbCode.Text = ComDB.testCode;
            //}

            try
            {
                #region 설비정보 SELECT
                _sQuery = new StringBuilder();
                _sQuery.Append("	SELECT a.idx							");
                _sQuery.Append("	      ,a.fac							");
                _sQuery.Append("	      ,a.code							");
                _sQuery.Append("	      ,a.name							");
                _sQuery.Append("	      ,a.spec							");
                _sQuery.Append("	      ,a.motor_count					");
                _sQuery.Append("	      ,a.dept							");
                _sQuery.Append("	      ,a.location						");
                _sQuery.Append("	      ,a.maker							");
                _sQuery.Append("	      ,a.maker_date						");
                _sQuery.Append("	      ,a.ip								");
                _sQuery.Append("	      ,a.port							");
                _sQuery.Append("	      ,a.state							");
                _sQuery.Append("	      ,a.plc_maker						");
                _sQuery.Append("	      ,a.plc_model						");
                _sQuery.Append("	      ,a.plc_version					");
                _sQuery.Append("	      ,a.remark							");
                _sQuery.Append("	      ,a.del_gubun						");
                _sQuery.Append("	      ,a.reg_worker						");
                _sQuery.Append("		  ,a.reg_datetime					");
                _sQuery.Append("	      ,a.mod_worker						");
                _sQuery.Append("	      ,a.mod_datetime					");
                _sQuery.Append("	      ,a.del_datetime					");
                _sQuery.Append("	  FROM tb_machine_mst a with(nolock)	");
                _sQuery.Append("	  where 1 = 1							");
                _sQuery.Append("	    and a.code = @pCode				    ");
                _sQuery.Append("	    and a.del_gubun = 'N'				");

                _sqlParams = new SqlParameter[]
                {
                    //new SqlParameter("@pCode", cbCode.Text)
                    new SqlParameter("@pCode", sMcCode)
                };

                dt = _db.GetDataView("Search", _sQuery, _sqlParams).Table;

                //int x = 0;
                //int y = 0;
                //int maxheight = 0;
                //int j = 0;

                if (dt.Rows.Count > 0)
                {
                    #region 설비정보 컨트롤에 매칭
                    sIdx = dt.DataSet.Tables["Search"].Rows[0]["idx"].ToString();

                    txtIdx.Text = dt.DataSet.Tables["Search"].Rows[0]["idx"].ToString();
                    cbCode.Text = dt.DataSet.Tables["Search"].Rows[0]["code"].ToString();
                    txtName.Text = dt.DataSet.Tables["Search"].Rows[0]["name"].ToString();
                    txtSpec.Text = dt.DataSet.Tables["Search"].Rows[0]["spec"].ToString();
                    txtMotorCount.Text = dt.DataSet.Tables["Search"].Rows[0]["motor_count"].ToString();
                    txtDept.Text = dt.DataSet.Tables["Search"].Rows[0]["dept"].ToString();
                    cbLocation.Text = dt.DataSet.Tables["Search"].Rows[0]["location"].ToString();
                    txtMaker.Text = dt.DataSet.Tables["Search"].Rows[0]["maker"].ToString();
                    txtMakerDateTime.Text = dt.DataSet.Tables["Search"].Rows[0]["maker_date"].ToString();
                    txtPlcIp.Text = dt.DataSet.Tables["Search"].Rows[0]["ip"].ToString();
                    txtPlcPort.Text = dt.DataSet.Tables["Search"].Rows[0]["port"].ToString();
                    cbState.Text = dt.DataSet.Tables["Search"].Rows[0]["state"].ToString();
                    cbFac.Text = dt.DataSet.Tables["Search"].Rows[0]["fac"].ToString();
                    txtPlcVersion.Text = dt.DataSet.Tables["Search"].Rows[0]["plc_version"].ToString();
                    txtPlcMaker.Text = dt.DataSet.Tables["Search"].Rows[0]["plc_maker"].ToString();
                    txtPlcModel.Text = dt.DataSet.Tables["Search"].Rows[0]["plc_model"].ToString();
                    txtRemark.Text = dt.DataSet.Tables["Search"].Rows[0]["remark"].ToString();
                    #endregion

                    #region PLC 데이터 주소 SELECT
                    _sQuery = new StringBuilder();
                    _sQuery.Append("	select	* from tb_plc_detail with(nolock)		");
                    _sQuery.Append("	where 1 = 1					                    ");
                    _sQuery.Append("	    and mc_idx = @pMc_idx                       ");
                    _sQuery.Append("	    and plc_version = @pPlc_version             ");
                    _sQuery.Append("	    and del_gubun = 'N'                         ");
                    _sqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pMc_idx",          Convert.ToDecimal(sIdx.ToString()))
                        ,new SqlParameter("@pPlc_version",     txtPlcVersion.Text)
                    };
                    dt = _db.GetDataView("Search_plc", _sQuery, _sqlParams).Table;
                    dgv1.DataSource = dt;
                    #endregion

                    #region 이미지 DATA SELECT
                    _sQuery = new StringBuilder();
                    _sQuery.Append("	SELECT	* from tb_file_detail with(nolock)		");
                    _sQuery.Append("	where 1 = 1					                    ");
                    _sQuery.Append("	    and mc_idx = @pMc_idx and del_gubun = 'N'   ");
                    _sqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@pMc_idx",          Convert.ToDecimal(sIdx.ToString()))
                    };
                    dt = _db.GetDataView("Search_file", _sQuery, _sqlParams).Table;
                    dgv2.DataSource = dt;
                    #endregion

                    #region 이미지 VIEW
                    this.listView1.Items.Clear();
                    //flowLayoutPanel1.Controls.Clear();
                    if (dgv2.Rows.Count > 0)
                    {
                        
                        for (int i = 0; i < dgv2.Rows.Count; i++)
                        {
                            if (dgv2.Rows[i].Cells["file_save2"].Value.ToString() == "Y" && dgv2.Rows[i].Cells["del_gubun2"].Value.ToString() == "Y")
                            {
                                continue;
                            }

                            //기존
                            this._imageList.Images.Add(Image.FromFile(dgv2.Rows[i].Cells["path2"].Value.ToString() + "\\" +
                                                        dgv2.Rows[i].Cells["new_name2"].Value.ToString()));

                            #region 신규(플로우 패널)
                            //this._imageList1.Add(Image.FromFile(dgv2.Rows[i].Cells["path2"].Value.ToString() + "\\" +
                            //                           dgv2.Rows[i].Cells["new_name2"].Value.ToString()));


                            ////Size nSize = new Size(_imageList1[j].Width, _imageList1[j].Height);
                            //Size nSize = new Size(350, 425);
                            //Image imgGdi = new Bitmap(nSize.Width, nSize.Height);
                            //Graphics grfx = Graphics.FromImage(imgGdi);
                            //grfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            //grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            //grfx.DrawImage(_imageList1[j], new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), _imageList1[j].Size), GraphicsUnit.Pixel);


                            //Panel pPanel = new Panel();
                            //pPanel.BackColor = Color.White;
                            //pPanel.Size = new Size(350, 425);
                            //pPanel.Padding = new System.Windows.Forms.Padding(4);


                            //PictureBox pBox = new PictureBox();
                            //pBox.Dock = DockStyle.Fill;

                            //pBox.Location = new Point(x, y);
                            //x += pBox.Width + 10;
                            //maxheight = Math.Max(pBox.Height, maxheight);
                            //if (x > this.ClientSize.Width - 100)
                            //{
                            //    //x = 20;
                            //    y += maxheight + 10;
                            //}

                            ////pBox.Image = _imageList1[j].GetThumbnailImage(350, 425, null, IntPtr.Zero);
                            //pBox.Image = imgGdi.GetThumbnailImage(350, 425, null, IntPtr.Zero);


                            //pPanel.Controls.Add(pBox);
                            //this.flowLayoutPanel1.Controls.Add(pPanel);
                            //j++;

                            //grfx.Dispose();
                            //imgGdi.Dispose();
                            #endregion

                        }


                        #region 주석
                        //Size nSize = new Size(_listImage[iImageIdx].Width, _listImage[iImageIdx].Height);
                        //Image imgGdi = new Bitmap(nSize.Width, nSize.Height);
                        //Graphics grfx = Graphics.FromImage(imgGdi);
                        //grfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        //grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        //grfx.DrawImage(_listImage[iImageIdx], new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), _listImage[iImageIdx].Size), GraphicsUnit.Pixel);
                        //grfx.Dispose();
                        //imgGdi.Save(sFullPath);
                        //imgGdi.Dispose();
                        //iImageIdx++;
                        #endregion


                        //기존
                        this.listView1.View = View.LargeIcon;
                        this._imageList.ImageSize = new Size(256, 256);
                        this.listView1.LargeImageList = this._imageList;
                        for (int i = 0; i < _imageList.Images.Count; i++)
                        {
                            ListViewItem item = new ListViewItem();
                              item.ImageIndex = i;
                            this.listView1.Items.Add(item);

                        }
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (dt != null) dt.Dispose();
                if (_sQuery != null) _sQuery.Clear();
                if (_sqlParams != null) _sqlParams = null;
                _db.CloseDB();
                //TestbedDB.testCode = string.Empty;
                this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        public void CtrColor()
        {
            try
            {
                TestbedLeave.GetCtrLeaveColor(cbCode);
                TestbedLeave.GetCtrLeaveColor(txtName);
                TestbedLeave.GetCtrLeaveColor(txtMaker);
                TestbedLeave.GetCtrLeaveColor(txtMotorCount);

                TestbedLeave.GetCtrLeaveColor(cbFac);
                TestbedLeave.GetCtrLeaveColor(cbLocation);
                TestbedLeave.GetCtrLeaveColor(cbState);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                #region 엑셀 업로드 기능 보류
                //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";
                //openFileDialog1.FilterIndex = 3;

                //openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                //openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog

                //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    string pathName = openFileDialog1.FileName;
                //    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                //    DataTable tbContainer = new DataTable();
                //    string strConn = string.Empty;
                //    string sheetName = fileName;

                //    FileInfo file = new FileInfo(pathName);
                //    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                //    string extension = file.Extension;

                //    DataTable dt4 = new DataTable();
                //    dt4 = dgv1.DataSource as DataTable;

                //    string s_idx = "0";
                //    string st_idx = txtIdx.Text == string.Empty ? "0" : txtIdx.Text;

                //    decimal d_idx = Convert.ToDecimal(s_idx);
                //    decimal d_tidx = Convert.ToDecimal(st_idx);

                //    switch (extension)
                //    {
                //        case ".xls":
                //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                //            break;
                //        case ".xlsx":
                //            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                //            break;
                //        default:
                //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                //            break;
                //    }
                //    OleDbConnection cnnxls = new OleDbConnection(strConn);
                //    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                //    oda.Fill(tbContainer);

                //    int a1 = dt4.Rows.Count + 1;
                //    for (int i = 0; i < tbContainer.Rows.Count; i++)
                //    {
                //        dt4.Rows.Add(d_idx, d_tidx, tbContainer.Rows[i]["code"].ToString(), tbContainer.Rows[i]["name"].ToString(), 'N');
                //    }

                //    dgv1.DataSource = dt4;
                //    cnnxls.Close();
                //}
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void btnPlcDataAdd_Click(object sender, EventArgs e)
        {
            string sIdx = "0";
            string sMcIdx = string.Empty;
            string sPlcVersion = string.Empty;
            decimal dIdx;
            decimal dMcIdx;

            DataTable dt = new DataTable();

            try
            {
                sIdx = "0";
                sMcIdx = txtIdx.Text == string.Empty ? "0" : txtIdx.Text;
                sPlcVersion = txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;

                dIdx = Convert.ToDecimal(sIdx);
                dMcIdx = Convert.ToDecimal(sMcIdx);

                dt = dgv1.DataSource as DataTable;
                dt.Rows.Add(dIdx, dMcIdx, sPlcVersion, "", "", "", "", "", "", "", "", "", "", "", "", "N", "", "", "", "", "");
                dgv1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (dt != null) dt.Dispose();
            }
        }

        private void btnPlcDataRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.Rows.Count < 1) return;

                foreach (DataGridViewCell oneCell in dgv1.SelectedCells)
                {
                    if (oneCell.Selected)
                        dgv1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string[] files;
            string[] name;

            try
            {
                _diaLog = new OpenFileDialog();
                _diaLog.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png|jpeg (*.jpeg)|*.jpeg";

                _diaLog.Multiselect = true;

                DialogResult dr = _diaLog.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    files = _diaLog.FileNames;
                    name = _diaLog.SafeFileNames;

                    dt = dgv2.DataSource as DataTable;

                    foreach (string img in name)
                    {
                        dt.Rows.Add(0, 0, "", img, "", "N", "N", "", "", "", "", "");
                    }
                    dgv2.DataSource = dt;

                    foreach (string img in files)
                    {
                        _listImage.Add(Image.FromFile(img));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (dt != null) dt.Dispose();
            }
        }

        private void btnFileRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv2.Rows.Count < 1) return;

                foreach (DataGridViewCell oneCell in dgv2.SelectedCells)
                {
                    if (oneCell.Selected)
                        dgv2.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                CtrInit();
                CtrColor();
                this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                this.cbCode.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _db.ConnectDB();
            SqlTransaction sTran = null;
            DataTable dt = new DataTable();
            bool isCheck;

            try
            {
                #region 변수 선언 설비
                string sMcCode = cbCode.Text == null ? string.Empty : cbCode.Text;
                string sMcName = txtName.Text == null ? string.Empty : txtName.Text;
                string sMcSpec = txtSpec.Text == null ? string.Empty : txtSpec.Text;
                string sMcMaker = txtMaker.Text == null ? string.Empty : txtMaker.Text;
                string sMotorCount = txtMotorCount.Text == null ? string.Empty : txtMotorCount.Text;
                string sPlcIp = txtPlcIp.Text == null ? string.Empty : txtPlcIp.Text;
                string sPlcPort = txtPlcPort.Text == null ? string.Empty : txtPlcPort.Text;
                string sPlcVersion = txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;
                string sPlcMaker = txtPlcMaker.Text == null ? string.Empty : txtPlcMaker.Text;
                string sPlcModel = txtPlcModel.Text == null ? string.Empty : txtPlcModel.Text;
                string sMakerDateTime = txtMakerDateTime.Text == null ? string.Empty : txtMakerDateTime.Text;
                string sRemark = txtRemark.Text == null ? string.Empty : txtRemark.Text;
                string sDept = txtDept.Text == null ? string.Empty : txtDept.Text;

                string sFac = cbFac.Text == null ? string.Empty : cbFac.Text;
                string sLocation = cbLocation.Text == null ? string.Empty : cbLocation.Text;
                string sState = cbState.Text == null ? string.Empty : cbState.Text;

                string sIdx = txtIdx.Text == null ? string.Empty : txtIdx.Text;
                #endregion

                #region 변수 선언 PLC 주소(TAB1)
                string sMcIdx2 = string.Empty;
                string sPlcVersion2 = string.Empty;
                string sAuto_start_address = string.Empty;
                string sSpeed_address = string.Empty;
                string sVolt_address = string.Empty;

                string sCurrent_address = string.Empty;
                string sCurrent_load_address = string.Empty;
                string sPeak_load_address = string.Empty;
                string sMachining_time_address = string.Empty;
                string sAlarm_code_address = string.Empty;


                string sProduct_size_address = string.Empty;
                string sCurrent_size_address = string.Empty;
                string sMachining_count_address = string.Empty;
                string sRemark1 = string.Empty;
                string sDel_gubun1 = string.Empty;
                #endregion

                #region 변수 선언 파일(TAB2)
                string sPath = string.Empty;
                string sFullPath = string.Empty;
                int iImageIdx = 0;

                string sOriginName = string.Empty;
                string sNewName = string.Empty;
                #endregion

                #region 유효성 검사
                if (cbCode.Text.Length < 1)
                {
                    MessageBox.Show("설비코드를 입력하십시오.");
                    cbCode.Focus();
                    cbCode.SelectAll();
                    return;
                }

                if (txtName.Text.Length < 1)
                {
                    MessageBox.Show("설비명을 입력하십시오.");
                    txtName.Focus();
                    txtName.SelectAll();
                    return;
                }

                if (txtMotorCount.Text.Length < 1)
                {
                    MessageBox.Show("설비 모터 수를 입력하십시오.");
                    txtMotorCount.Focus();
                    txtMotorCount.SelectAll();
                    return;
                }

                if (cbLocation.Text.Length < 1)
                {
                    MessageBox.Show("설비 위치를 입력하십시오.");
                    cbLocation.Focus();
                    cbLocation.SelectAll();
                    return;
                }

                if (txtMaker.Text.Length < 1)
                {
                    MessageBox.Show("설비 제조사를 입력하십시오.");
                    txtMaker.Focus();
                    txtMaker.SelectAll();
                    return;
                }

                if (cbState.Text.Length < 1)
                {
                    MessageBox.Show("설비 상태를 입력하십시오.");
                    cbState.Focus();
                    cbState.SelectAll();
                    return;
                }

                if (cbFac.Text.Length < 1)
                {
                    MessageBox.Show("사업장을 입력하십시오.");
                    cbFac.Focus();
                    cbFac.SelectAll();
                    return;
                }
                #endregion

                #region  저장 로직
                if (MessageBox.Show("저장 하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    sTran = TestbedDB.sqlConn.BeginTransaction();

                    #region 설비 key 자동채번
                    if (sIdx.ToString().Length < 1)
                    {
                        _sQuery = new StringBuilder();
                        _sQuery.Append("	select	isnull(max(a.idx), 0) + 1  as idx ");
                        _sQuery.Append("	from	tb_machine_mst a with(nolock)     ");
                        _sQuery.Append("	where  1 = 1                              ");
                        _sqlParams = new SqlParameter[] { };

                        dt = _db.GetDataView_Tran("Key_idx", _sQuery, _sqlParams, sTran).Table;

                        sIdx = dt.DataSet.Tables["Key_idx"].Rows[0]["idx"].ToString();
                    }
                    #endregion

                    #region     설비 정보 저장
                    _sQuery = new StringBuilder();
                    _sQuery.Append("	merge into tb_machine_mst as a					    				                                                                                    ");
                    _sQuery.Append("	using(select count(a.idx) as cnt from tb_machine_mst a with(nolock) where a.idx = @pIdx) as b                                                           ");
                    _sQuery.Append("	on (b.cnt > 0)																		                                                                    ");
                    _sQuery.Append("	when matched and a.idx = @pIdx then													                                                                    ");
                    _sQuery.Append("		update set                                                                                                                                          ");
                    _sQuery.Append("            a.fac           = @pFac             ,a.name         = @pName                                                                                    ");
                    _sQuery.Append("           ,a.spec          = @pSpec      	    ,a.motor_count  = @pMotor_count		                                                                        ");
                    _sQuery.Append("		   ,a.dept          = @pDept            ,a.location     = @pLocation					                                                            ");
                    _sQuery.Append("		   ,a.maker         = @pMaker	        ,a.maker_date   = @pMaker_date	                                                                            ");
                    _sQuery.Append("		   ,a.ip            = @pIp              ,a.port         = @pPort                                                                                    ");
                    _sQuery.Append("           ,a.state         = @pState           ,a.plc_maker    = @pPlc_maker                                                                               ");
                    _sQuery.Append("           ,a.plc_model     = @pPlc_model       ,a.plc_version  = @pPlc_version     			                                                            ");
                    _sQuery.Append("           ,a.remark        = @pRemark     	    ,a.del_gubun    = @pDel_gubun	            	                                                            ");
                    _sQuery.Append("           ,a.reg_worker    = @pReg_worker      ,a.reg_datetime = @pReg_datetime     			                                                            ");
                    _sQuery.Append("           ,a.mod_worker    = @pMod_worker      ,a.mod_datetime = @pMod_datetime     			                                                            ");
                    _sQuery.Append("           ,a.del_datetime  = @pDel_datetime                             			                                                                        ");
                    _sQuery.Append("	when not matched then																	                                                                ");
                    _sQuery.Append("		insert (idx         ,fac            ,code           ,name           ,spec           ,motor_count    ,dept           ,location       ,maker          ");
                    _sQuery.Append("		       ,maker_date  ,ip             ,port           ,state          ,plc_maker      ,plc_model      ,plc_version    ,remark         ,del_gubun      ");
                    _sQuery.Append("		       ,reg_worker  ,reg_datetime   ,mod_worker     ,mod_datetime   ,del_datetime)                                                                  ");
                    _sQuery.Append("		values (@pIdx       ,@pFac          ,@pCode         ,@pName         ,@pSpec         ,@pMotor_count  ,@pDept         ,@pLocation     ,@pMaker        ");
                    _sQuery.Append("		       ,@pMaker_date,@pIp           ,@pPort         ,@pState        ,@pPlc_maker    ,@pPlc_model    ,@pPlc_version  ,@pRemark       ,@pDel_gubun    ");
                    _sQuery.Append("		       ,@pReg_worker,@pReg_datetime ,@pMod_worker   ,@pMod_datetime ,@pDel_datetime);                                                               ");

                    _sqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pIdx",              Convert.ToDecimal(sIdx.ToString()))
                        ,new SqlParameter("@pFac",              sFac.ToString())
                        ,new SqlParameter("@pCode",             sMcCode.ToString())
                        ,new SqlParameter("@pName",             sMcName.ToString())
                        ,new SqlParameter("@pSpec",             sMcSpec.ToString())
                        ,new SqlParameter("@pMotor_count",      sMotorCount.ToString())
                        ,new SqlParameter("@pDept",             sDept.ToString())
                        ,new SqlParameter("@pLocation",         sLocation.ToString())
                        ,new SqlParameter("@pMaker",            sMcMaker.ToString())

                        ,new SqlParameter("@pMaker_date",       sMakerDateTime.ToString())
                        ,new SqlParameter("@pIp",               sPlcIp.ToString())
                        ,new SqlParameter("@pPort",             sPlcPort.ToString())
                        ,new SqlParameter("@pState",            sState.ToString())
                        ,new SqlParameter("@pPlc_maker",        sPlcMaker.ToString())
                        ,new SqlParameter("@pPlc_model",        sPlcModel.ToString())
                        ,new SqlParameter("@pPlc_version",      sPlcVersion.ToString())
                        ,new SqlParameter("@pRemark",           sRemark.ToString())
                        ,new SqlParameter("@pDel_gubun",        'N')

                        ,new SqlParameter("@pReg_worker",       "kmg")
                        ,new SqlParameter("@pReg_datetime",     string.Empty)
                        ,new SqlParameter("@pMod_worker",       "kmg1")
                        ,new SqlParameter("@pMod_datetime",     string.Empty)
                        ,new SqlParameter("@pDel_datetime",     string.Empty)
                    };
                    isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    #endregion

                    #region plc 데이터 주소 저장
                    if (dgv1.Rows.Count > 0)
                    {
                        #region 기존 데이터 숨김처리
                        _sQuery = new StringBuilder();
                        _sQuery.Append("	update tb_plc_detail set	    ");
                        _sQuery.Append("		 del_gubun = 'Y'		    ");
                        _sQuery.Append("		,mod_worker = 'kmg1'        ");
                        _sQuery.Append("		,mod_datetime = ''		    ");
                        _sQuery.Append("		,del_datetime = ''		    ");
                        _sQuery.Append("	where 				            ");
                        _sQuery.Append("		mc_idx = @pMc_Idx	        ");
                        _sqlParams = new SqlParameter[]
                        {
                            new SqlParameter("@pMc_Idx",          Convert.ToDecimal(sIdx.ToString()))
                        };

                        isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                        if (!isCheck)
                        {
                            sTran.Rollback();
                            return;
                        }
                        #endregion

                        #region 신규 데이터 INSERT
                        _sQuery = new StringBuilder();
                        _sQuery.Append("	insert into tb_plc_detail				                                                                                                            ");
                        _sQuery.Append("	(										                                                                                                            ");
                        _sQuery.Append("		 mc_idx                     ,plc_version                ,auto_start_address             ,speed_address                  ,volt_address           ");
                        _sQuery.Append("	    ,current_address            ,current_load_address       ,peak_load_address              ,machining_time_address         ,alarm_code_address     ");
                        _sQuery.Append("	    ,product_size_address       ,current_size_address       ,machining_count_address        ,remark                         ,del_gubun              ");
                        _sQuery.Append("	    ,reg_worker                 ,reg_datetime               ,del_datetime                                                                           ");
                        _sQuery.Append("	)										                                                                                                            ");
                        _sQuery.Append("	values									                                                                                                            ");
                        _sQuery.Append("	(										                                                                                                            ");
                        _sQuery.Append("		 @pMc_idx                   ,@pPlc_version              ,@pAuto_start_address           ,@pSpeed_address                ,@pVolt_address         ");
                        _sQuery.Append("	    ,@pCurrent_address          ,@pCurrent_load_address     ,@pPeak_load_address            ,@pMachining_time_address       ,@pAlarm_code_address   ");
                        _sQuery.Append("	    ,@pProduct_size_address     ,@pCurrent_size_address     ,@pMachining_count_address      ,@pRemark                       ,@pDel_gubun            ");
                        _sQuery.Append("	    ,@pReg_worker               ,@pReg_datetime             ,@pDel_datetime                                                                         ");
                        _sQuery.Append("	)										                                                                                                            ");

                        for (int i = 0; i < dgv1.RowCount; i++)
                        {
                            sMcIdx2 = sIdx.ToString();

                            sPlcVersion2 = txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;
                            //sPlcVersion2 = dgv1.Rows[i].Cells["plc_version"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["plc_version"].Value.ToString();
                            sAuto_start_address = dgv1.Rows[i].Cells["auto_start_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["auto_start_address"].Value.ToString();
                            sSpeed_address = dgv1.Rows[i].Cells["speed_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["speed_address"].Value.ToString();
                            sVolt_address = dgv1.Rows[i].Cells["volt_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["volt_address"].Value.ToString();

                            sCurrent_address = dgv1.Rows[i].Cells["current_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["current_address"].Value.ToString();
                            sCurrent_load_address = dgv1.Rows[i].Cells["current_load_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["current_load_address"].Value.ToString();
                            sPeak_load_address = dgv1.Rows[i].Cells["peak_load_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["peak_load_address"].Value.ToString();
                            sMachining_time_address = dgv1.Rows[i].Cells["machining_time_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["machining_time_address"].Value.ToString();
                            sAlarm_code_address = dgv1.Rows[i].Cells["alarm_code_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["alarm_code_address"].Value.ToString();

                            sProduct_size_address = dgv1.Rows[i].Cells["product_size_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["product_size_address"].Value.ToString();
                            sCurrent_size_address = dgv1.Rows[i].Cells["current_size_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["current_size_address"].Value.ToString();
                            sMachining_count_address = dgv1.Rows[i].Cells["machining_count_address"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["machining_count_address"].Value.ToString();
                            sRemark1 = dgv1.Rows[i].Cells["remark"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["remark"].Value.ToString();
                            sDel_gubun1 = dgv1.Rows[i].Cells["del_gubun"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["del_gubun"].Value.ToString();

                            _sqlParams = new SqlParameter[]
                            {
                                 new SqlParameter("@pMc_idx",                   Convert.ToDecimal(sMcIdx2.ToString()))
                                ,new SqlParameter("@pPlc_version",              sPlcVersion2.ToString())
                                ,new SqlParameter("@pAuto_start_address",       sAuto_start_address.ToString())
                                ,new SqlParameter("@pSpeed_address",            sSpeed_address.ToString())
                                ,new SqlParameter("@pVolt_address",             sVolt_address.ToString())

                                ,new SqlParameter("@pCurrent_address",          sCurrent_address.ToString())
                                ,new SqlParameter("@pCurrent_load_address",     sCurrent_load_address.ToString())
                                ,new SqlParameter("@pPeak_load_address",        sPeak_load_address.ToString())
                                ,new SqlParameter("@pMachining_time_address",   sMachining_time_address.ToString())
                                ,new SqlParameter("@pAlarm_code_address",       sAlarm_code_address.ToString())

                                ,new SqlParameter("@pProduct_size_address",     sProduct_size_address.ToString())
                                ,new SqlParameter("@pCurrent_size_address",     sCurrent_size_address.ToString())
                                ,new SqlParameter("@pMachining_count_address",  sMachining_count_address.ToString())
                                ,new SqlParameter("@pRemark",                   sRemark1.ToString())
                                ,new SqlParameter("@pDel_gubun",                sDel_gubun1.ToString())

                                ,new SqlParameter("@pReg_worker  ",             "kmg")
                                ,new SqlParameter("@pReg_datetime",             string.Empty)
                                ,new SqlParameter("@pDel_datetime",             string.Empty)
                            };

                            isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                            if (!isCheck)
                            {
                                sTran.Rollback();
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region 파일 저장
                    if (dgv2.Rows.Count > 0)
                    {
                        #region 기존 데이터 숨김처리
                        _sQuery = new StringBuilder();
                        _sQuery.Append("	update tb_file_detail set	    ");
                        _sQuery.Append("		 del_gubun = 'Y'		    ");
                        _sQuery.Append("		,mod_worker = 'kmg1'	    ");
                        _sQuery.Append("		,mod_datetime = ''		    ");
                        _sQuery.Append("		,del_datetime = ''		    ");
                        _sQuery.Append("	where 				            ");
                        _sQuery.Append("		mc_idx = @pMc_idx	        ");
                        _sqlParams = new SqlParameter[]
                        {
                            new SqlParameter("@pMc_idx",          Convert.ToDecimal(sIdx.ToString()))
                        };

                        isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                        if (!isCheck)
                        {
                            sTran.Rollback();
                            return;
                        }
                        #endregion

                        #region 신규 데이터 INSERT

                        sPath = @"D:\image1\mc" + "\\" + sIdx;

                        _sQuery = new StringBuilder();
                        _sQuery.Append("	insert into tb_file_detail					                                           ");
                        _sQuery.Append("	(										                                               ");
                        _sQuery.Append("		 mc_idx         ,path           ,origin_name        ,new_name       ,file_save	   ");
                        _sQuery.Append("		,del_gubun      ,reg_worker     ,reg_datetime       ,del_datetime                  ");
                        _sQuery.Append("	)										                                               ");
                        _sQuery.Append("	values									                                               ");
                        _sQuery.Append("	(										                                               ");
                        _sQuery.Append("		 @pMc_idx       ,@pPath         ,@pOrigin_name      ,@pNew_name     ,@pFile_save   ");
                        _sQuery.Append("		,@pDel_gubun    ,@pReg_worker   ,@pReg_datetime     ,@pDel_datetime                ");
                        _sQuery.Append("	)										                                               ");
                        for (int i = 0; i < dgv2.Rows.Count; i++)
                        {
                            sOriginName = dgv2.Rows[i].Cells["origin_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["origin_name2"].Value.ToString();

                            if (dgv2["file_save2", i].Value.ToString() == "Y")
                            {
                                sNewName = dgv2.Rows[i].Cells["new_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["new_name2"].Value.ToString();
                            }
                            else
                            {
                                sNewName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + dgv2["origin_name2", i].Value.ToString();
                            }

                            sFullPath = sPath + "\\" + sNewName;

                            _sqlParams = new SqlParameter[]
                            {
                                 new SqlParameter("@pMc_idx",           Convert.ToDecimal(sIdx.ToString()))
                                ,new SqlParameter("@pPath",             sPath.ToString())
                                ,new SqlParameter("@pOrigin_name",      sOriginName.ToString())
                                ,new SqlParameter("@pNew_name",         sNewName.ToString())
                                ,new SqlParameter("@pFile_save",        "Y")
                                ,new SqlParameter("@pDel_gubun",        "N")
                                ,new SqlParameter("@pReg_worker",       string.Empty)
                                ,new SqlParameter("@pReg_datetime",     string.Empty)
                                ,new SqlParameter("@pDel_datetime",     string.Empty)
                            };

                            isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                            if (dgv2["file_save2", i].Value.ToString() == "Y")
                            {
                                iImageIdx = 0;
                                continue;
                            }

                            #region     IMAGE 저장
                            if (!File.Exists(sPath))
                            {
                                DirectoryInfo di = new DirectoryInfo(sPath);
                                di.Create();
                            }


                            //멀티
                            Size nSize = new Size(_listImage[iImageIdx].Width, _listImage[iImageIdx].Height);
                            Image imgGdi = new Bitmap(nSize.Width, nSize.Height);
                            Graphics grfx = Graphics.FromImage(imgGdi);
                            grfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            grfx.DrawImage(_listImage[iImageIdx], new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), _listImage[iImageIdx].Size), GraphicsUnit.Pixel);
                            grfx.Dispose();
                            imgGdi.Save(sFullPath);
                            imgGdi.Dispose();
                            iImageIdx++;

                            if (!isCheck)
                            {
                                sTran.Rollback();
                                return;
                            }
                            #endregion
                        }
                        #endregion
                    }

                    if (isCheck)
                    {
                        sTran.Commit();
                        MessageBox.Show("저장되었습니다.");
                    }

                    #endregion
                }
                #endregion

                #region 재조회
                _listImage = new List<Image>();
                ComboSetting();
                Search(sMcCode);
                CtrColor();
                #endregion
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.Message, ex.Source);
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
                _db.CloseDB();
                this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            }
        }

        private void cbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Search(cbCode.Text);
                this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                CtrColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv2.Rows.Count < 1) return;
                if (listView1.Items.Count < 1) return;

                if (listView1.SelectedItems.Count != 0)
                {
                    int SelectRow = listView1.SelectedItems[0].Index;

                    dgv2.Rows[SelectRow].Selected = true;
                    dgv2.CurrentCell = dgv2.Rows[SelectRow].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv2.Rows.Count < 1) return;
                if (listView1.Items.Count < 1) return;

                int iIndex = dgv2.CurrentRow.Index;

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Focused = false;
                    listView1.Items[i].Selected = false;
                }
                listView1.Items[iIndex].Focused = true;
                listView1.Items[iIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string sPath = string.Empty;
            string sName = string.Empty;

            try
            {
                if (listView1.Items.Count < 1) return;

                if (MessageBox.Show("이미지를 뷰어하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int iIndex = dgv2.CurrentRow.Index;

                    sPath = dgv2.Rows[iIndex].Cells["path2"].Value.ToString();
                    sName = dgv2.Rows[iIndex].Cells["new_name2"].Value.ToString();

                    frmMcImgView frm = new frmMcImgView(sPath, sName);

                    if (frm.ShowDialog() != DialogResult.OK)
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void btnCodeCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCode.Text.Length < 1)
                {
                    MessageBox.Show("설비 코드를 입력하십시오.");
                    cbCode.Focus();
                    cbCode.SelectAll();
                    return;
                }

                frmMcCodeCopy frm = new frmMcCodeCopy(cbCode, cbCode.Text);

                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                    CtrInit();
                    ComboSetting();
                    Search(_gbMcCode);
                    CtrColor();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

                //this.cbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }
    }
}
