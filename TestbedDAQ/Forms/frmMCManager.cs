using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using TestbedDAQ.UseClass;

namespace TestbedDAQ.Forms
{
    public partial class frmMCManager : Form
    {
        private TestbedFTP _Ftp;
        private TestbedDB _DB;
        private StringBuilder _Query;
        private SqlParameter[] _SqlParams;

        //이미지를 한번에 여러개 첨부하는게 아닌
        //하나 첨부, 하나 첨부, 하나 첨부했을경우 때문에 전역으로 선언
        private ImageList _ImageList;  //이미지를 Search 메서드에서 View할때 이미지 목록 담는 역할
        private List<string> _StringList = new List<string>(); //이미지 첨부할때 파일 경로들 담는 역할

        public static string _GlobalMcCode = string.Empty;
        private string sUser = "KMG";

        public frmMCManager()
        {
            InitializeComponent();
        }

        private void frmMCManager_Load(object sender, EventArgs e)
        {
            try
            {
                CreateInstance();
                CtrInit();
                ComboSetting();
                Search(_GlobalMcCode);
                CtrColor();
                DataGridViewVisible();
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

        private void CreateInstance()
        {
            try
            {
                _DB = new TestbedDB();
                _Ftp = new TestbedFTP();
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

        private void CtrInit()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                #region 설비정보 초기화 및 셋팅

                txtMcIdx.Text = string.Empty;
                cbMcCode.Text = string.Empty;
                txtMcName.Text = string.Empty;
                cbMcFac.Text = string.Empty;
                txtMcLocation.Text = string.Empty;
                cbMcType.Text = string.Empty;
                txtMcVersion.Text = string.Empty;
                txtMcStandard.Text = string.Empty;
                txtMotorCount.Text = string.Empty;
                txtMcSpec.Text = string.Empty;
                txtMcDept.Text = string.Empty;
                cbMcState.Text = string.Empty;
                txtMcMaker.Text = string.Empty;
                txtMcMakerDate.Text = string.Empty;
                txtRemark.Text = string.Empty;

                txtPlcIdx.Text = string.Empty;
                txtPlcVersion.Text = string.Empty;
                txtPlcName.Text = string.Empty;
                txtPlcMaker.Text = string.Empty;
                txtPlcMakerDate.Text = string.Empty;
                txtPlcIp.Text = string.Empty;
                txtPlcPort.Text = string.Empty;
                txtPlcType.Text = string.Empty;
                txtPlcToolVersion.Text = string.Empty;

                cbMcCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cbMcFac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cbMcState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cbMcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                #endregion

                #region TAB1 PLC 그리드1 초기화
                int dgvCount1 = dgv1.Rows.Count;
                for (int i = 0; i < dgvCount1; i++)
                {
                    int max = dgv1.Rows.Count - 1;
                    dgv1.Rows.Remove(dgv1.Rows[max]);
                }

                //Grid 데이터프로퍼티네임 기준으로 지정해야함
                dt1.Columns.Add("idx", typeof(decimal));
                dt1.Columns.Add("mc_idx", typeof(decimal));
                dt1.Columns.Add("plc_idx", typeof(string));
                dt1.Columns.Add("plc_programversion", typeof(string));
                dt1.Columns.Add("autostart", typeof(string));
                dt1.Columns.Add("spindleX_speed", typeof(string));
                dt1.Columns.Add("spindleX_current", typeof(string));
                dt1.Columns.Add("spindleX_currentload", typeof(string));
                dt1.Columns.Add("spindleY_speed", typeof(string));
                dt1.Columns.Add("spindleY_current", typeof(string));

                dt1.Columns.Add("spindleY_currentload", typeof(string));
                dt1.Columns.Add("spindleservoX_position", typeof(string));
                dt1.Columns.Add("spindleservoX_speed", typeof(string));
                dt1.Columns.Add("spindleservoX_currentload", typeof(string));
                dt1.Columns.Add("spindleservoX_peakload", typeof(string));
                dt1.Columns.Add("spindleservoX_errernumber", typeof(string));
                dt1.Columns.Add("spindleservoY_position", typeof(string));
                dt1.Columns.Add("spindleservoY_speed", typeof(string));
                dt1.Columns.Add("spindleservoY_currentload", typeof(string));
                dt1.Columns.Add("spindleservoY_peakload", typeof(string));

                dt1.Columns.Add("spindleservoY_errernumber", typeof(string));
                dt1.Columns.Add("bedservo_position", typeof(string));
                dt1.Columns.Add("bedservo_speed", typeof(string));
                dt1.Columns.Add("bedservo_currentload", typeof(string));
                dt1.Columns.Add("bedservo_peakload", typeof(string));
                dt1.Columns.Add("bedservo_errernumber", typeof(string));
                dt1.Columns.Add("guideservo_position", typeof(string));
                dt1.Columns.Add("guideservo_speed", typeof(string));
                dt1.Columns.Add("guideservo_currentload", typeof(string));
                dt1.Columns.Add("guideservo_peakload", typeof(string));

                dt1.Columns.Add("guideservo_errernumber", typeof(string));
                dt1.Columns.Add("alarmcode", typeof(string));
                dt1.Columns.Add("productsize", typeof(string));
                dt1.Columns.Add("currentsize", typeof(string));
                dt1.Columns.Add("machiningcount", typeof(string));
                dt1.Columns.Add("machiningtime", typeof(string));
                dt1.Columns.Add("remark", typeof(string));
                dt1.Columns.Add("del_gubun", typeof(string));
                dt1.Columns.Add("reg_worker", typeof(string));
                dt1.Columns.Add("reg_datetime", typeof(string));

                dt1.Columns.Add("mod_worker", typeof(string));
                dt1.Columns.Add("mod_datetime", typeof(string));
                dt1.Columns.Add("del_datetime", typeof(string));

                dt1.Rows.Add(0              ,0              ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty
                            ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty
                            ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty
                            ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty   ,string.Empty
                            ,string.Empty   ,string.Empty   ,string.Empty);
                dgv1.DataSource = dt1;
                dgv1.Rows.Remove(dgv1.Rows[0]);
                #endregion

                #region TAB2 이미지 파일 그리드 초기화
                int dgvCount2 = dgv2.Rows.Count;
                for (int i = 0; i < dgvCount2; i++)
                {
                    int max = dgv2.Rows.Count - 1;
                    dgv2.Rows.Remove(dgv2.Rows[max]);
                }

                //Grid 데이터프로퍼티네임 기준으로 지정해야함
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
                dt2.Rows.Add(0, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                dgv2.DataSource = dt2;
                dgv2.Rows.Remove(dgv2.Rows[0]);
                #endregion

                #region 리스트 뷰 초기화
                lvwImage.Items.Clear();
                #endregion

                #region 각 생성자 초기화
                _ImageList = null;
                _StringList = new List<string>();
                _SqlParams = null;
                _Query = null;
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

        private void ComboSetting()
        {
            DataTable dt = new DataTable();
            _DB.ConnectDB();
            try
            {
                _Query = new StringBuilder();
                _Query.Append("	select	a.code  as code                     ");
                _Query.Append("	from	tb_machine_info a with(nolock)      ");
                _Query.Append("	where  1 = 1                                ");
                _Query.Append("	    and del_gubun = 'N'                     ");
                _SqlParams = new SqlParameter[] { };

                dt = _DB.GetDataView("search_code", _Query, _SqlParams).Table;

                cbMcCode.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbMcCode.Items.Add(dt.DataSet.Tables["search_code"].Rows[i]["code"].ToString());
                }

                cbMcState.Items.Clear();
                cbMcState.Items.Add("정상");
                cbMcState.Items.Add("비정상");

                cbMcFac.Items.Clear();
                cbMcFac.Items.Add("정남사업장");
                cbMcFac.Items.Add("장수사업장");

                cbMcType.Items.Clear();
                cbMcType.Items.Add("절단");
                cbMcType.Items.Add("평면가공");
                cbMcType.Items.Add("측면가공");
                cbMcType.Items.Add("사면가공");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (dt != null) dt.Dispose();
                if (_Query != null) _Query.Clear();
                if (_SqlParams != null) _SqlParams = null;
                _DB.CloseDB();
            }
        }

        private void Search(string sMcCode)
        {
            _DB.ConnectDB();
            DataTable dt = new DataTable();

            this.lvwImage.Items.Clear();
            _ImageList = new ImageList();

            string sMcIdx = string.Empty;
            string sPlcIdx = string.Empty;

            try
            {
                #region 설비정보, PLC 정보 SELECT 쿼리
                _Query = new StringBuilder();
                _Query.Append("		select												");
                _Query.Append("			 a.idx				as 	aIdx					");
                _Query.Append("		    ,a.code				as 	aCode					");
                _Query.Append("		    ,a.name				as 	aName					");
                _Query.Append("		    ,a.location			as 	aLocation				");
                _Query.Append("		    ,a.type				as 	aType					");
                _Query.Append("		    ,a.version			as 	aVersion				");
                _Query.Append("		    ,a.standard			as 	aStandard				");
                _Query.Append("		    ,a.motor_count		as 	aMotor_count			");
                _Query.Append("		    ,a.spec				as 	aSpec					");
                _Query.Append("		    ,a.dept				as 	aDept					");
                _Query.Append("		    ,a.maker			as 	aMaker					");
                _Query.Append("		    ,a.makerdate		as 	aMakerdate				");
                _Query.Append("		    ,a.state			as 	aState					");
                _Query.Append("		    ,a.fac				as 	aFac					");
                _Query.Append("		    ,a.remark			as 	aRemark					");
                _Query.Append("		    ,a.del_gubun		as 	aDel_gubun				");
                _Query.Append("		    ,a.reg_worker		as 	aReg_worker				");
                _Query.Append("		    ,a.reg_datetime		as 	aReg_datetime			");
                _Query.Append("		    ,a.mod_worker		as 	aMod_worker				");
                _Query.Append("		    ,a.mod_datetime		as 	aMod_datetime			");
                _Query.Append("		    ,a.del_datetime		as 	aDel_datetime			");
                _Query.Append("			,b.idx				as	bIdx					");
                _Query.Append("			,b.mc_idx			as	bMc_idx					");
                _Query.Append("			,b.programversion	as	bProgramversion			");
                _Query.Append("			,b.name				as	bName					");
                _Query.Append("			,b.type				as	bType					");
                _Query.Append("			,b.maker			as	bMaker					");
                _Query.Append("			,b.makerdate		as	bMakerdate				");
                _Query.Append("			,b.ip				as	bIp						");
                _Query.Append("			,b.port				as	bPort					");
                _Query.Append("			,b.toolversion		as	bToolversion			");
                _Query.Append("			,b.del_gubun		as	bDel_gubun				");
                _Query.Append("			,b.reg_worker		as	bReg_worker				");
                _Query.Append("			,b.reg_datetime		as	bReg_datetime			");
                _Query.Append("			,b.mod_worker		as	bMod_worker				");
                _Query.Append("			,b.mod_datetime		as	bMod_datetime			");
                _Query.Append("			,b.del_datetime		as	bDel_datetime			");
                _Query.Append("		from tb_machine_info a with(nolock)					");
                _Query.Append("		left outer join tb_plc_info b with(nolock)			");
                _Query.Append("		on	    a.idx = b.mc_idx							");
                _Query.Append("			and b.del_gubun = 'N'							");
                _Query.Append("		where 1 = 1											");
                _Query.Append("			and a.code = @pCode								");
                _Query.Append("			and a.del_gubun = 'N'							");

                _SqlParams = new SqlParameter[]
                {
                    new SqlParameter("@pCode", sMcCode)
                };

                dt = _DB.GetDataView("Search", _Query, _SqlParams).Table;
                #endregion

                #region  설비 정보, PLC, 이미지 View
                if (dt.Rows.Count > 0)
                {
                    #region 설비정보 컨트롤에 매칭
                    sMcIdx = dt.DataSet.Tables["Search"].Rows[0]["aidx"].ToString();
                    txtMcIdx.Text = dt.DataSet.Tables["Search"].Rows[0]["aidx"].ToString();
                    cbMcCode.Text = dt.DataSet.Tables["Search"].Rows[0]["aCode"].ToString();
                    txtMcName.Text = dt.DataSet.Tables["Search"].Rows[0]["aName"].ToString();
                    cbMcFac.Text = dt.DataSet.Tables["Search"].Rows[0]["aFac"].ToString();
                    txtMcLocation.Text = dt.DataSet.Tables["Search"].Rows[0]["aLocation"].ToString();
                    cbMcType.Text = dt.DataSet.Tables["Search"].Rows[0]["aType"].ToString();
                    txtMcVersion.Text = dt.DataSet.Tables["Search"].Rows[0]["aVersion"].ToString();
                    txtMcStandard.Text = dt.DataSet.Tables["Search"].Rows[0]["aStandard"].ToString();
                    txtMotorCount.Text = dt.DataSet.Tables["Search"].Rows[0]["aMotor_count"].ToString();
                    txtMcSpec.Text = dt.DataSet.Tables["Search"].Rows[0]["aSpec"].ToString();
                    txtMcDept.Text = dt.DataSet.Tables["Search"].Rows[0]["aDept"].ToString();
                    cbMcState.Text = dt.DataSet.Tables["Search"].Rows[0]["aState"].ToString();
                    txtMcMaker.Text = dt.DataSet.Tables["Search"].Rows[0]["aMaker"].ToString();
                    txtMcMakerDate.Text = dt.DataSet.Tables["Search"].Rows[0]["aMakerdate"].ToString();
                    txtRemark.Text = dt.DataSet.Tables["Search"].Rows[0]["aRemark"].ToString();
                    #endregion

                    #region PLC 정보 컨트롤에 매칭
                    sPlcIdx = dt.DataSet.Tables["Search"].Rows[0]["bIdx"].ToString();
                    if (sPlcIdx == string.Empty) sPlcIdx = "0";

                    txtPlcIdx.Text = dt.DataSet.Tables["Search"].Rows[0]["bIdx"].ToString();
                    txtPlcVersion.Text = dt.DataSet.Tables["Search"].Rows[0]["bProgramversion"].ToString();
                    txtPlcName.Text = dt.DataSet.Tables["Search"].Rows[0]["bName"].ToString();
                    txtPlcMaker.Text = dt.DataSet.Tables["Search"].Rows[0]["bMaker"].ToString();
                    txtPlcMakerDate.Text = dt.DataSet.Tables["Search"].Rows[0]["bMakerdate"].ToString();
                    txtPlcIp.Text = dt.DataSet.Tables["Search"].Rows[0]["bIp"].ToString();
                    txtPlcPort.Text = dt.DataSet.Tables["Search"].Rows[0]["bPort"].ToString();
                    txtPlcType.Text = dt.DataSet.Tables["Search"].Rows[0]["bType"].ToString();
                    txtPlcToolVersion.Text = dt.DataSet.Tables["Search"].Rows[0]["bToolversion"].ToString();
                    #endregion

                    #region PLC 데이터 주소 SELECT
                    _Query = new StringBuilder();
                    _Query.Append("	select * from tb_plc_address_info with(nolock)	");
                    _Query.Append("	where 1 = 1											");
                    _Query.Append("		and	mc_idx = @pMc_Idx							");
                    _Query.Append("		and	plc_idx = @pPlc_Idx							");
                    _Query.Append("		and plc_programversion = @pPlcVersion			");
                    _Query.Append("		and del_gubun = 'N'								");
                    _SqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pMc_Idx",           Convert.ToDecimal(sMcIdx.ToString()))
                        ,new SqlParameter("@pPlc_Idx",          Convert.ToDecimal(sPlcIdx.ToString()))
                        ,new SqlParameter("@pPlcVersion",       txtPlcVersion.Text)
                    };
                    dt = _DB.GetDataView("Search_plc", _Query, _SqlParams).Table;
                    dgv1.DataSource = dt;
                    #endregion

                    #region 이미지 DATA SELECT
                    _Query = new StringBuilder();
                    _Query.Append("	select	a.* from tb_file_info a with(nolock)	");
                    _Query.Append("	where 1 = 1					                    ");
                    _Query.Append("	    and mc_idx = @pMc_idx                       ");
                    _Query.Append("	    and del_gubun = 'N'                         ");
                    _SqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@pMc_idx",    Convert.ToDecimal(sMcIdx.ToString()))
                    };
                    dt = _DB.GetDataView("Search_file", _Query, _SqlParams).Table;
                    dgv2.DataSource = dt;
                    #endregion

                    #region 이미지 VIEW
                    this.lvwImage.Items.Clear();
                    _ImageList = new ImageList();
                    if (dgv2.Rows.Count > 0)
                    {
                        WebClient ftpClient = new WebClient();
                        ftpClient.Credentials = new NetworkCredential(_Ftp._UserId, _Ftp._Password);

                        for (int i = 0; i < dgv2.Rows.Count; i++)
                        {
                            if (dgv2.Rows[i].Cells["file_save2"].Value.ToString() == "Y" && dgv2.Rows[i].Cells["del_gubun2"].Value.ToString() == "Y")
                            {
                                continue;
                            }

                            byte[] imageByte = ftpClient.DownloadData(dgv2.Rows[i].Cells["path2"].Value.ToString() + "/" +
                                                        dgv2.Rows[i].Cells["new_name2"].Value.ToString());

                            MemoryStream mStream = new MemoryStream();
                            byte[] pData = imageByte;
                            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                            Bitmap bm = new Bitmap(mStream, false);
                            mStream.Dispose();
                            this._ImageList.Images.Add(bm);
                        }
                        ftpClient.Dispose();

                        //기존
                        //this.lvwImage.View = View.LargeIcon;
                        this._ImageList.ImageSize = new Size(255, 256);
                        this.lvwImage.LargeImageList = this._ImageList;
                        //lvwImage.CheckBoxes = true;

                        for (int i = 0; i < _ImageList.Images.Count; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = i;
                            this.lvwImage.Items.Add(item);
                            //this.lvwImage.Items.Add(i.ToString() + "_1", i);



                            //Button btn = new Button();
                            //btn.Text = "Click Me";
                            //Point p = this.lvwImage.Items[0].Position;
                            //p.X -= 21;
                            //p.Y += 51;
                            //btn.Location = p;
                            //btn.Size = this.lvwImage.Items[0].Bounds.Size;
                            //this.lvwImage.Controls.Add(btn);
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
                if (_Query != null) _Query.Clear();
                if (_SqlParams != null) _SqlParams = null;
                _DB.CloseDB();
                //this.cbMcCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        private void CtrColor()
        {
            try
            {
                TestbedLeave.GetCtrLeaveColor(cbMcCode);
                TestbedLeave.GetCtrLeaveColor(txtMcName);
                TestbedLeave.GetCtrLeaveColor(cbMcFac);
                TestbedLeave.GetCtrLeaveColor(txtMcLocation);
                TestbedLeave.GetCtrLeaveColor(cbMcState);
                TestbedLeave.GetCtrLeaveColor(txtPlcVersion);
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

        private void DataGridViewVisible()
        {
            try
            {
                //grid col name으로 지정해야함
                this.dgv1.Columns["idx1"].Visible = false;
                this.dgv1.Columns["mc_idx1"].Visible = false;
                this.dgv1.Columns["plc_idx1"].Visible = false;
                this.dgv1.Columns["del_gubun1"].Visible = false;
                this.dgv1.Columns["mod_worker1"].Visible = false;
                this.dgv1.Columns["mod_datetime1"].Visible = false;
                this.dgv1.Columns["del_datetime1"].Visible = false;

                //grid col name으로 지정해야함
                //this.dgv2.Columns["idx2"].Visible = false;
                //this.dgv2.Columns["mc_idx2"].Visible = false;
                //this.dgv2.Columns["new_name2"].Visible = false;
                //this.dgv2.Columns["file_save2"].Visible = false;
                //this.dgv2.Columns["del_gubun2"].Visible = false;
                //this.dgv2.Columns["mod_worker2"].Visible = false;
                //this.dgv2.Columns["mod_datetime2"].Visible = false;
                //this.dgv2.Columns["del_datetime2"].Visible = false;
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
            string sMcIdx = string.Empty;
            string sPlcVersion = string.Empty;
            string sPlcIdx = string.Empty;

            decimal dIdx = 0;
            decimal dMcIdx;
            decimal dPlcIdx;

            DataTable dt = new DataTable();

            try
            {
                sMcIdx = txtMcIdx.Text == string.Empty ? "0" : txtMcIdx.Text;
                sPlcIdx = txtPlcIdx.Text == string.Empty ? "0" : txtPlcIdx.Text;
                sPlcVersion = txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;

                dMcIdx = Convert.ToDecimal(sMcIdx);
                dPlcIdx = Convert.ToDecimal(sPlcIdx);

                dt = dgv1.DataSource as DataTable;
                dt.Rows.Add(dIdx,           sMcIdx,         sPlcIdx,        sPlcVersion,    string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
                           ,string.Empty,   string.Empty,   string.Empty,   string.Empty,   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
                           ,string.Empty,   string.Empty,   string.Empty,   string.Empty,   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
                           ,string.Empty,   string.Empty,   string.Empty,   string.Empty,   string.Empty, string.Empty, string.Empty, "N",          string.Empty, string.Empty
                           ,string.Empty,   string.Empty,   string.Empty);

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
            string[] sFiles;
            string[] sName;

            try
            {
                OpenFileDialog _Dialog = new OpenFileDialog();
                _Dialog.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png|jpeg (*.jpeg)|*.jpeg";

                _Dialog.Multiselect = true;

                DialogResult dr = _Dialog.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    sFiles = _Dialog.FileNames;
                    sName = _Dialog.SafeFileNames;

                    dt = dgv2.DataSource as DataTable;

                    foreach (string sImg in sName)
                    {
                        dt.Rows.Add(0, 0, "", sImg, "", "N", "N", "", "", "", "", "");
                    }
                    dgv2.DataSource = dt;

                    foreach (string sImg in sFiles)
                    {
                        //_listImage.Add(Image.FromFile(img));
                        _StringList.Add(sImg);
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

                //콤보박스 텍스트 초기화 시키는거 에러있음... 고쳐야함



                CtrInit();

                this.cbMcFac.Text = string.Empty;
                this.cbMcState.Text = string.Empty;
                this.cbMcType.Text = string.Empty;

                //콤보박스 텍스트 내용을 초기화 시킬려면 스타일을 드롭다운으로 변경후
                //콤보박스 텍스트 값을 공백으로 변경한다.

                cbMcCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cbMcFac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cbMcState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cbMcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cbMcCode.Text = string.Empty;
                cbMcFac.Text = string.Empty;
                cbMcState.Text = string.Empty;
                cbMcType.Text = string.Empty;


                cbMcCode.Focus();
                cbMcCode.Select();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _DB.ConnectDB();
            SqlTransaction sTran = null;
            DataTable dt = new DataTable();

            try
            {
                bool isCheck;

                #region 변수 선언 설비 정보
                string sMcIdx           =   txtMcIdx.Text == null ? string.Empty : txtMcIdx.Text;
                string sMcCode          =   cbMcCode.Text == null ? string.Empty : cbMcCode.Text;
                string sMcName          =   txtMcName.Text == null ? string.Empty : txtMcName.Text;
                string sMcFac           =   cbMcFac.Text == null ? string.Empty : cbMcFac.Text;
                string sMcLocation      =   txtMcLocation.Text == null ? string.Empty : txtMcLocation.Text;
                string sMcType          =   cbMcType.Text == null ? string.Empty : cbMcType.Text;
                string sMcVersion       =   txtMcVersion.Text == null ? string.Empty : txtMcVersion.Text;
                string sMcStandard      =   txtMcStandard.Text == null ? string.Empty : txtMcStandard.Text;
                string sMotorCount      =   txtMotorCount.Text == null ? string.Empty : txtMotorCount.Text;
                string sMcSpec          =   txtMcSpec.Text == null ? string.Empty : txtMcSpec.Text;
                string sMcDept          =   txtMcDept.Text == null ? string.Empty : txtMcDept.Text;
                string sMcState         =   cbMcState.Text == null ? string.Empty : cbMcState.Text;
                string sMcMaker         =   txtMcMaker.Text == null ? string.Empty : txtMcMaker.Text;
                string sMcMakerDate     =   txtMcMakerDate.Text == null ? string.Empty : txtMcMakerDate.Text;
                string sMcRemark        =   txtRemark.Text == null ? string.Empty : txtRemark.Text;
                #endregion

                #region 변수 선언 PLC 정보
                string sPlcIdx              =   txtPlcIdx.Text == null ? string.Empty : txtPlcIdx.Text;
                string sPlcVersion          =   txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;
                string sPlcName             =   txtPlcName.Text == null ? string.Empty : txtPlcName.Text;
                string sPlcMaker            =   txtPlcMaker.Text == null ? string.Empty : txtPlcMaker.Text;
                string sPlcMakerDate        =   txtPlcMakerDate.Text == null ? string.Empty : txtPlcMakerDate.Text;
                string sPlcIp               =   txtPlcIp.Text == null ? string.Empty : txtPlcIp.Text;
                string sPlcPort             =   txtPlcPort.Text == null ? string.Empty : txtPlcPort.Text;
                string sPlcType             =   txtPlcType.Text == null ? string.Empty : txtPlcType.Text;
                string sPlcToolVersion      =   txtPlcToolVersion.Text == null ? string.Empty : txtPlcToolVersion.Text;
                #endregion

                #region 변수 선언 PLC 데이터 주소(TAB1)
                string sAutoStart                    = string.Empty;
                string sSpindleX_Speed               = string.Empty;
                string sSpindleX_Current             = string.Empty;
                string sSpindleX_CurrentLoad         = string.Empty;
                string sSpindleY_Speed               = string.Empty;
                string sSpindleY_Current             = string.Empty;
                string sSpindleY_CurrentLoad         = string.Empty;
                string sSpindleServoX_Position       = string.Empty;
                string sSpindleServoX_Speed          = string.Empty;
                string sSpindleServoX_CurrentLoad    = string.Empty;
                string sSpindleServoX_PeakLoad       = string.Empty;
                string sSpindleServoX_ErrerNumber    = string.Empty;
                string sSpindleServoY_Position       = string.Empty;
                string sSpindleServoY_Speed          = string.Empty;
                string sSpindleServoY_CurrentLoad    = string.Empty;
                string sSpindleServoY_PeakLoad       = string.Empty;
                string sSpindleServoY_ErrerNumber    = string.Empty;
                string sBedServo_Position            = string.Empty;
                string sBedServo_Speed               = string.Empty;
                string sBedServo_Currentload         = string.Empty;
                string sBedServo_Peakload            = string.Empty;
                string sBedServo_Errernumber         = string.Empty;
                string sGuideServo_Position          = string.Empty;
                string sGuideServo_Speed             = string.Empty;
                string sGuideServo_CurrentLoad       = string.Empty;
                string sGuideServo_PeakLoad          = string.Empty;
                string sGuideServo_ErrerNumber       = string.Empty;
                string sAlarmCode                    = string.Empty;
                string sProductSize                  = string.Empty;
                string sCurrentSize                  = string.Empty;
                string sMachiningCount               = string.Empty;
                string sMachiningTime                = string.Empty;
                string sRemark1                      = string.Empty;
                string sDel_gubun                    = string.Empty;
                string sReg_worker                   = string.Empty;
                string sReg_datetime                 = string.Empty;
                string sMod_worker                   = string.Empty;
                string sMod_datetime                 = string.Empty;
                string sDel_datetime                 = string.Empty;
                #endregion

                #region 변수 선언 이미지 관리(TAB2) 주석
                //string sPath = string.Empty;
                //string sFullPath = string.Empty;
                //int iImageIdx = 0;

                //string sOriginName = string.Empty;
                //string sNewName = string.Empty;
                #endregion

                #region 기존 주석
                //string sMcCode = cbMcCode.Text == null ? string.Empty : cbMcCode.Text;
                //string sMcName = txtMcName.Text == null ? string.Empty : txtMcName.Text;
                //string sMcSpec = txtSpec.Text == null ? string.Empty : txtSpec.Text;
                //string sMcMaker = txtMaker.Text == null ? string.Empty : txtMaker.Text;
                //string sMotorCount = txtMotorCount.Text == null ? string.Empty : txtMotorCount.Text;
                //string sPlcIp = txtPlcIp.Text == null ? string.Empty : txtPlcIp.Text;
                //string sPlcPort = txtPlcPort.Text == null ? string.Empty : txtPlcPort.Text;
                //string sPlcVersion = txtPlcVersion.Text == null ? string.Empty : txtPlcVersion.Text;
                //string sPlcMaker = txtPlcMaker.Text == null ? string.Empty : txtPlcMaker.Text;
                //string sPlcModel = txtPlcType.Text == null ? string.Empty : txtPlcType.Text;
                //string sMakerDate = txtMakerDate.Text == null ? string.Empty : txtMakerDate.Text;
                //string sRemark = txtRemark.Text == null ? string.Empty : txtRemark.Text;
                //string sDept = txtDept.Text == null ? string.Empty : txtDept.Text;

                //string sFac = cbFac.Text == null ? string.Empty : cbFac.Text;
                //string sLocation = cbMcLocation.Text == null ? string.Empty : cbMcLocation.Text;
                //string sState = cbState.Text == null ? string.Empty : cbState.Text;

                //string sIdx = txtMcIdx.Text == null ? string.Empty : txtMcIdx.Text;


                //#region 변수 선언 PLC 주소(TAB1)
                //string sMcIdx2 = string.Empty;
                //string sPlcVersion2 = string.Empty;
                //string sAuto_start_address = string.Empty;
                //string sSpeed_address = string.Empty;
                //string sVolt_address = string.Empty;

                //string sCurrent_address = string.Empty;
                //string sCurrent_load_address = string.Empty;
                //string sPeak_load_address = string.Empty;
                //string sMachining_time_address = string.Empty;
                //string sAlarm_code_address = string.Empty;


                //string sProduct_size_address = string.Empty;
                //string sCurrent_size_address = string.Empty;
                //string sMachining_count_address = string.Empty;
                //string sRemark1 = string.Empty;
                //string sDel_gubun1 = string.Empty;
                //#endregion

                //#region 변수 선언 파일(TAB2)
                //string sPath = string.Empty;
                //string sFullPath = string.Empty;
                //int iImageIdx = 0;

                //string sOriginName = string.Empty;
                //string sNewName = string.Empty;
                //#endregion
                #endregion

                #region 유효성 검사
                if (cbMcCode.Text.Length < 1)
                {
                    MessageBox.Show("설비코드를 입력하십시오.");
                    cbMcCode.Focus();
                    cbMcCode.SelectAll();
                    return;
                }

                if (txtMcName.Text.Length < 1)
                {
                    MessageBox.Show("설비명을 입력하십시오.");
                    txtMcName.Focus();
                    txtMcName.SelectAll();
                    return;
                }

                if (cbMcFac.Text.Length < 1)
                {
                    MessageBox.Show("사업장을 입력하십시오.");
                    cbMcFac.Focus();
                    cbMcFac.SelectAll();
                    return;
                }


                if (txtMcLocation.Text.Length < 1)
                {
                    MessageBox.Show("설비 위치를 입력하십시오.");
                    txtMcLocation.Focus();
                    txtMcLocation.SelectAll();
                    return;
                }

                if (cbMcState.Text.Length < 1)
                {
                    MessageBox.Show("설비 상태를 입력하십시오.");
                    cbMcState.Focus();
                    cbMcState.SelectAll();
                    return;
                }

                if (txtPlcVersion.Text.Length < 1)
                {
                    MessageBox.Show("PLC 버전을 입력하십시오.");
                    txtPlcVersion.Focus();
                    txtPlcVersion.SelectAll();
                    return;
                }
                #endregion

                #region  저장 로직
                if (MessageBox.Show("저장 하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sTran = TestbedDB.sqlConn.BeginTransaction();

                    #region 설비 key 자동채번
                    if (sMcIdx.ToString().Length < 1)
                    {
                        _Query = new StringBuilder();
                        _Query.Append("	select	isnull(max(a.idx), 0) + 1  as idx   ");
                        _Query.Append("	from	tb_machine_info a with(nolock)      ");
                        _Query.Append("	where  1 = 1                                ");
                        _SqlParams = new SqlParameter[] { };

                        dt = _DB.GetDataView_Tran("Key_idx", _Query, _SqlParams, sTran).Table;

                        sMcIdx = dt.DataSet.Tables["Key_idx"].Rows[0]["idx"].ToString();
                    }
                    #endregion

                    #region     설비 정보 저장
                    _Query = new StringBuilder();
                    _Query.Append("	merge into tb_machine_info as a																												");
                    _Query.Append("	using(select count(a.idx) as cnt from tb_machine_info a with(nolock) where a.idx = @pIdx) as b												");
                    _Query.Append("	on (b.cnt > 0)																																");
                    _Query.Append("	when matched and a.idx = @pIdx then																											");
                    _Query.Append("	update set                                                                        															");
                    _Query.Append("	       a.code			= @pCode			,a.name         = @pName																		");
                    _Query.Append("		  ,a.location		= @pLocation        ,a.type         = @pType																		");
                    _Query.Append("		  ,a.version		= @pVersion         ,a.standard     = @pStandard																	");
                    _Query.Append("		  ,a.motor_count	= @pMotorCount      ,a.spec         = @pSpec																		");
                    _Query.Append("		  ,a.dept			= @pDept            ,a.maker        = @pMaker																		");
                    _Query.Append("		  ,a.makerdate		= @pMakerdate       ,a.state		= @pState																		");
                    _Query.Append("		  ,a.fac			= @pFac				,a.remark		= @pRemark																		");
                    _Query.Append("		  ,a.mod_worker	    = @pUser																	                                        ");
                    _Query.Append("		  ,a.mod_datetime   = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))						");
                    _Query.Append("	when not matched then																														");
                    _Query.Append("		insert																																	");
                    _Query.Append("		(																																		");
                    _Query.Append("			 idx			,code		,name			,location		,type		,version		,standard		,motor_count	,spec		");
                    _Query.Append("			,dept			,maker		,makerdate		,state			,fac		,remark			,del_gubun		,reg_worker					");
                    _Query.Append("			,reg_datetime																														");
                    _Query.Append("			,mod_worker		,mod_datetime																										");
                    _Query.Append("		)																																		");
                    _Query.Append("		values																																	");
                    _Query.Append("		(																																		");
                    _Query.Append("			 @pIdx			,@pCode		,@pName			,@pLocation		,@pType		,@pVersion		,@pStandard		,@pMotorCount	,@pSpec		");
                    _Query.Append("			,@pDept			,@pMaker	,@pMakerdate	,@pState		,@pFac		,@pRemark		,'N'			,@pUser						");
                    _Query.Append("			,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))										");
                    _Query.Append("			,@pUser			,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))						");
                    _Query.Append("		);																																		");

                    _SqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pIdx",              Convert.ToDecimal(sMcIdx.ToString()))
                        ,new SqlParameter("@pCode",             sMcCode.ToString())
                        ,new SqlParameter("@pName",             sMcName.ToString())
                        ,new SqlParameter("@pLocation",         sMcLocation.ToString())
                        ,new SqlParameter("@pType",             sMcType.ToString())
                        ,new SqlParameter("@pVersion",          sMcVersion.ToString())
                        ,new SqlParameter("@pStandard",         sMcStandard.ToString())
                        ,new SqlParameter("@pMotorCount",       sMotorCount.ToString())
                        ,new SqlParameter("@pSpec",             sMcSpec.ToString())
                        ,new SqlParameter("@pDept",             sMcDept.ToString())
                        ,new SqlParameter("@pMaker",            sMcMaker.ToString())
                        ,new SqlParameter("@pMakerdate",        sMcMakerDate.ToString())
                        ,new SqlParameter("@pState",            sMcState.ToString())
                        ,new SqlParameter("@pFac",              sMcFac.ToString())
                        ,new SqlParameter("@pRemark",           sMcRemark.ToString())
                        ,new SqlParameter("@pUser",             sUser.ToString())
                    };

                    isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    #endregion

                    #region PLC 정보 key 자동채번
                    _Query = new StringBuilder();
                    _Query.Append("	select	isnull(max(a.idx), 0) + 1  as idx   ");
                    _Query.Append("	from	tb_plc_info a with(nolock)          ");
                    _Query.Append("	where   1 = 1                               ");
                    _SqlParams = new SqlParameter[] { };

                    dt = _DB.GetDataView_Tran("Key_Plc_idx", _Query, _SqlParams, sTran).Table;

                    sPlcIdx = dt.DataSet.Tables["Key_Plc_idx"].Rows[0]["idx"].ToString();
                    #endregion

                    #region 기존 PLC 정보 데이터 숨김 처리 + PLC 정보 INSERT
                    _Query = new StringBuilder();
                    _Query.Append("	update tb_plc_info set	                                                                                                                ");
                    _Query.Append("		 del_gubun = 'Y'		                                                                                                            ");
                    _Query.Append("		,mod_worker = @pUser                                                                                                                ");
                    _Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	                    ");
                    _Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	                    ");
                    _Query.Append("	where 1 = 1				                                                                                                                ");
                    _Query.Append("		and mc_idx = @pMc_Idx	                                                                                                            ");
                    _Query.Append("		and del_gubun = 'N'	                                                                                                                ");
                    _Query.Append("	insert into tb_plc_info																													");
                    _Query.Append("	(																																		");
                    _Query.Append("	  idx               ,mc_idx			    ,programversion		    ,name				,type												");
                    _Query.Append("	 ,maker				,makerdate			,ip						,port				,toolversion										");
                    _Query.Append("	 ,del_gubun			,reg_worker			,reg_datetime																					");
                    _Query.Append("	 ,mod_worker		,mod_datetime																										");
                    _Query.Append("	)																																		");
                    _Query.Append("	values																																	");
                    _Query.Append("	(																																		");
                    _Query.Append("	  @pPlc_Idx         ,@pMc_Idx			,@pProgramversion	    ,@pName			    ,@pType												");
                    _Query.Append("	 ,@pMaker			,@pMakerdate		,@pIp					,@pPort				,@pToolversion										");
                    _Query.Append("	 ,'N'		        ,@pUser				,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    _Query.Append("	 ,@pUser			,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))						");
                    _Query.Append("	)																																		");
                    _SqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pMc_Idx",           Convert.ToDecimal(sMcIdx.ToString()))
                        ,new SqlParameter("@pPlc_Idx",          Convert.ToDecimal(sPlcIdx.ToString()))
                        ,new SqlParameter("@pProgramversion",   sPlcVersion.ToString())
                        ,new SqlParameter("@pName",             sPlcName.ToString())
                        ,new SqlParameter("@pType",             sPlcType.ToString())

                        ,new SqlParameter("@pMaker",            sPlcMaker.ToString())
                        ,new SqlParameter("@pMakerdate",        sPlcMakerDate.ToString())
                        ,new SqlParameter("@pIp",               sPlcIp.ToString())
                        ,new SqlParameter("@pPort",             sPlcPort.ToString())
                        ,new SqlParameter("@pToolversion",      sPlcToolVersion.ToString())

                        ,new SqlParameter("@pUser",             sUser.ToString())
                    };

                    isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    #endregion

                    #region 기존 PLC 데이터 숨김처리
                    _Query = new StringBuilder();
                    _Query.Append("	update tb_plc_address_info set	                                                                                    ");
                    _Query.Append("		 del_gubun = 'Y'		                                                                                        ");
                    _Query.Append("		,mod_worker = @pUser                                                                                            ");
                    _Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    _Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    _Query.Append("	where   1 = 1   	                                                                                                ");
                    _Query.Append("		and mc_idx = @pMc_Idx	                                                                                        ");
                    _Query.Append("		and plc_idx = @pPlc_idx	                                                                                        ");
                    _Query.Append("		and plc_programversion = @pPlcVersion                                                                           ");
                    _Query.Append("		and del_gubun = 'N'	                                                                                            ");
                    _SqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pMc_Idx",               Convert.ToDecimal(sMcIdx.ToString()))
                        ,new SqlParameter("@pPlc_idx",              Convert.ToDecimal(sPlcIdx.ToString()))
                        ,new SqlParameter("@pPlcVersion",           sPlcVersion.ToString())
                        ,new SqlParameter("@pUser",                 sUser.ToString())
                    };

                    isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    #endregion

                    #region plc 데이터 주소 저장
                    if (dgv1.Rows.Count > 0)
                    {
                        #region 신규 데이터 INSERT
                        _Query = new StringBuilder();
                        _Query.Append("	insert into tb_plc_address_info																																				");
                        _Query.Append("	(																																											");
                        _Query.Append("		 mc_idx					    ,plc_idx				,plc_programversion				,autostart																			");
                        _Query.Append("		,spindleX_speed			    ,spindleX_current		,spindleX_currentLoad																								");
                        _Query.Append("		,spindleY_speed			    ,spindleY_current		,spindleY_currentload																								");
                        _Query.Append("		,spindleservoX_position	    ,spindleservoX_speed	,spindleservoX_currentload		,spindleservoX_peakload			,spindleservoX_errernumber							");
                        _Query.Append("		,spindleservoY_position	    ,spindleservoY_speed	,spindleservoY_currentload		,spindleservoY_peakload			,spindleServoY_errernumber							");
                        _Query.Append("		,bedservo_position		    ,bedservo_speed			,bedservo_currentload			,bedservo_peakload				,bedservo_errernumber								");
                        _Query.Append("		,guideservo_position	    ,guideservo_speed		,guideservo_currentload			,guideservo_peakload			,guideservo_errernumber								");
                        _Query.Append("		,alarmcode				    ,productsize			,currentsize					,machiningcount					,machiningtime					,remark				");
                        _Query.Append("		,del_gubun				    ,reg_worker				,reg_datetime					,mod_worker						,mod_datetime					,del_datetime		");
                        _Query.Append("	)																																											");
                        _Query.Append("	values																																										");
                        _Query.Append("	(																																											");
                        _Query.Append("		 @pMc_idx					,@pPlc_idx				,@pPlc_programversion			,@pAutostart																		");
                        _Query.Append("		,@pSpindleX_speed			,@pSpindleX_current		,@pSpindleX_currentLoad																								");
                        _Query.Append("		,@pSpindleY_speed			,@pSpindleY_current		,@pSpindleY_currentload																								");
                        _Query.Append("		,@pSpindleservoX_position	,@pSpindleservoX_speed	,@pSpindleservoX_currentload	,@pSpindleservoX_peakload		,@pSpindleservoX_errernumber						");
                        _Query.Append("		,@pSpindleservoY_position	,@pSpindleservoY_speed	,@pSpindleservoY_currentload	,@pSpindleservoY_peakload		,@pSpindleServoY_errernumber						");
                        _Query.Append("		,@pBedservo_position		,@pBedservo_speed		,@pBedservo_currentload			,@pBedservo_peakload			,@pBedservo_errernumber								");
                        _Query.Append("		,@pGuideservo_position		,@pGuideservo_speed		,@pGuideservo_currentload		,@pGuideservo_peakload			,@pGuideservo_errernumber							");
                        _Query.Append("		,@pAlarmcode				,@pProductsize			,@pCurrentsize					,@pMachiningcount				,@pMachiningtime				,@pRemark			");
                        _Query.Append("		,'N'						,@pReg_worker			,@pReg_datetime					,@pMod_worker					,@pMod_datetime					,''		            ");
                        _Query.Append("	)																																											");

                        for (int i = 0; i < dgv1.RowCount; i++)
                        {
                            #region 변수 값 할당
                            sAutoStart                  = dgv1.Rows[i].Cells["AutoStart1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["AutoStart1"].Value.ToString();
                            sSpindleX_Speed             = dgv1.Rows[i].Cells["SpindleX_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleX_Speed1"].Value.ToString();
                            sSpindleX_Current           = dgv1.Rows[i].Cells["SpindleX_Current1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleX_Current1"].Value.ToString();
                            sSpindleX_CurrentLoad       = dgv1.Rows[i].Cells["SpindleX_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleX_CurrentLoad1"].Value.ToString();
                            sSpindleY_Speed             = dgv1.Rows[i].Cells["SpindleY_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleY_Speed1"].Value.ToString();
                            sSpindleY_Current           = dgv1.Rows[i].Cells["SpindleY_Current1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleY_Current1"].Value.ToString();
                            sSpindleY_CurrentLoad       = dgv1.Rows[i].Cells["SpindleY_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleY_CurrentLoad1"].Value.ToString();
                            sSpindleServoX_Position     = dgv1.Rows[i].Cells["SpindleServoX_Position1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoX_Position1"].Value.ToString();
                            sSpindleServoX_Speed        = dgv1.Rows[i].Cells["SpindleServoX_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoX_Speed1"].Value.ToString();
                            sSpindleServoX_CurrentLoad  = dgv1.Rows[i].Cells["SpindleServoX_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoX_CurrentLoad1"].Value.ToString();
                            sSpindleServoX_PeakLoad     = dgv1.Rows[i].Cells["SpindleServoX_PeakLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoX_PeakLoad1"].Value.ToString();
                            sSpindleServoX_ErrerNumber  = dgv1.Rows[i].Cells["SpindleServoX_ErrerNumber1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoX_ErrerNumber1"].Value.ToString();
                            sSpindleServoY_Position     = dgv1.Rows[i].Cells["SpindleServoY_Position1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoY_Position1"].Value.ToString();
                            sSpindleServoY_Speed        = dgv1.Rows[i].Cells["SpindleServoY_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoY_Speed1"].Value.ToString();
                            sSpindleServoY_CurrentLoad  = dgv1.Rows[i].Cells["SpindleServoY_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoY_CurrentLoad1"].Value.ToString();
                            sSpindleServoY_PeakLoad     = dgv1.Rows[i].Cells["SpindleServoY_PeakLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoY_PeakLoad1"].Value.ToString();
                            sSpindleServoY_ErrerNumber  = dgv1.Rows[i].Cells["SpindleServoY_ErrerNumber1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["SpindleServoY_ErrerNumber1"].Value.ToString();
                            sBedServo_Position          = dgv1.Rows[i].Cells["BedServo_Position1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["BedServo_Position1"].Value.ToString();
                            sBedServo_Speed             = dgv1.Rows[i].Cells["BedServo_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["BedServo_Speed1"].Value.ToString();
                            sBedServo_Currentload       = dgv1.Rows[i].Cells["BedServo_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["BedServo_CurrentLoad1"].Value.ToString();
                            sBedServo_Peakload          = dgv1.Rows[i].Cells["BedServo_PeakLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["BedServo_PeakLoad1"].Value.ToString();
                            sBedServo_Errernumber       = dgv1.Rows[i].Cells["BedServo_ErrerNumber1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["BedServo_ErrerNumber1"].Value.ToString();
                            
                            sGuideServo_Position        = dgv1.Rows[i].Cells["GuideServo_Position1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["GuideServo_Position1"].Value.ToString();
                            sGuideServo_Speed           = dgv1.Rows[i].Cells["GuideServo_Speed1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["GuideServo_Speed1"].Value.ToString();
                            sGuideServo_CurrentLoad     = dgv1.Rows[i].Cells["GuideServo_CurrentLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["GuideServo_CurrentLoad1"].Value.ToString();
                            sGuideServo_PeakLoad        = dgv1.Rows[i].Cells["GuideServo_PeakLoad1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["GuideServo_PeakLoad1"].Value.ToString();
                            sGuideServo_ErrerNumber     = dgv1.Rows[i].Cells["GuideServo_ErrerNumber1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["GuideServo_ErrerNumber1"].Value.ToString();
                            sAlarmCode                  = dgv1.Rows[i].Cells["AlarmCode1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["AlarmCode1"].Value.ToString();
                            sProductSize                = dgv1.Rows[i].Cells["ProductSize1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["ProductSize1"].Value.ToString();
                            sCurrentSize                = dgv1.Rows[i].Cells["CurrentSize1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["CurrentSize1"].Value.ToString();
                            sMachiningCount             = dgv1.Rows[i].Cells["MachiningCount1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["MachiningCount1"].Value.ToString();
                            sMachiningTime              = dgv1.Rows[i].Cells["MachiningTime1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["MachiningTime1"].Value.ToString();
                            sRemark1                    = dgv1.Rows[i].Cells["remark1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["remark1"].Value.ToString();
                            
                            sDel_gubun                  = dgv1.Rows[i].Cells["del_gubun1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["del_gubun1"].Value.ToString();
                            sReg_worker                 = dgv1.Rows[i].Cells["reg_worker1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["reg_worker1"].Value.ToString();
                            sReg_datetime               = dgv1.Rows[i].Cells["reg_datetime1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["reg_datetime1"].Value.ToString();
                            sMod_worker                 = dgv1.Rows[i].Cells["mod_worker1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["mod_worker1"].Value.ToString();
                            sMod_datetime               = dgv1.Rows[i].Cells["mod_datetime1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["mod_datetime1"].Value.ToString();
                            sDel_datetime               = dgv1.Rows[i].Cells["del_datetime1"].Value.ToString() == null ? string.Empty : dgv1.Rows[i].Cells["del_datetime1"].Value.ToString();
                            #endregion

                            //신규 등록
                            if (sReg_worker == string.Empty)
                            {
                                sReg_worker = sUser;
                                sReg_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                sMod_worker = string.Empty;
                                sMod_datetime = string.Empty;
                            }
                            else//수정 등록
                            {
                                sMod_worker = sUser;
                                sMod_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            }

                            _SqlParams = new SqlParameter[]
                            {
                                 new SqlParameter("@pMc_idx",                   Convert.ToDecimal(sMcIdx.ToString()))
                                ,new SqlParameter("@pPlc_idx",                  Convert.ToDecimal(sPlcIdx.ToString()))
                                ,new SqlParameter("@pPlc_programversion",       sPlcVersion.ToString())
                                ,new SqlParameter("@pAutostart",                sAutoStart.ToString())

                                ,new SqlParameter("@pSpindleX_speed",           sSpindleX_Speed.ToString())
                                ,new SqlParameter("@pSpindleX_current",         sSpindleX_Current.ToString())
                                ,new SqlParameter("@pSpindleX_currentLoad",     sSpindleX_CurrentLoad.ToString())

                                ,new SqlParameter("@pSpindleY_speed",           sSpindleY_Speed.ToString())
                                ,new SqlParameter("@pSpindleY_current",         sSpindleY_Current.ToString())
                                ,new SqlParameter("@pSpindleY_currentload",     sSpindleY_CurrentLoad.ToString())

                                ,new SqlParameter("@pSpindleservoX_position",       sSpindleServoX_Position.ToString())
                                ,new SqlParameter("@pSpindleservoX_speed",          sSpindleServoX_Speed.ToString())
                                ,new SqlParameter("@pSpindleservoX_currentload",    sSpindleServoX_CurrentLoad.ToString())
                                ,new SqlParameter("@pSpindleservoX_peakload",       sSpindleServoX_PeakLoad.ToString())
                                ,new SqlParameter("@pSpindleservoX_errernumber",    sSpindleServoX_ErrerNumber.ToString())

                                ,new SqlParameter("@pSpindleservoY_position",       sSpindleServoY_Position.ToString())
                                ,new SqlParameter("@pSpindleservoY_speed",          sSpindleServoY_Speed.ToString())
                                ,new SqlParameter("@pSpindleservoY_currentload",    sSpindleServoY_CurrentLoad.ToString())
                                ,new SqlParameter("@pSpindleservoY_peakload",       sSpindleServoY_PeakLoad.ToString())
                                ,new SqlParameter("@pSpindleServoY_errernumber",    sSpindleServoY_ErrerNumber.ToString())

                                ,new SqlParameter("@pBedservo_position",            sBedServo_Position.ToString())
                                ,new SqlParameter("@pBedservo_speed",               sBedServo_Speed.ToString())
                                ,new SqlParameter("@pBedservo_currentload",         sBedServo_Currentload.ToString())
                                ,new SqlParameter("@pBedservo_peakload",            sBedServo_Peakload.ToString())
                                ,new SqlParameter("@pBedservo_errernumber",         sBedServo_Errernumber.ToString())

                                ,new SqlParameter("@pGuideservo_position",          sGuideServo_Position.ToString())
                                ,new SqlParameter("@pGuideservo_speed",             sGuideServo_Speed.ToString())
                                ,new SqlParameter("@pGuideservo_currentload",       sGuideServo_CurrentLoad.ToString())
                                ,new SqlParameter("@pGuideservo_peakload",          sGuideServo_PeakLoad.ToString())
                                ,new SqlParameter("@pGuideservo_errernumber",       sGuideServo_ErrerNumber.ToString())

                                ,new SqlParameter("@pAlarmcode",                    sAlarmCode.ToString())
                                ,new SqlParameter("@pProductsize",                  sProductSize.ToString())
                                ,new SqlParameter("@pCurrentsize",                  sCurrentSize.ToString())
                                ,new SqlParameter("@pMachiningcount",               sMachiningCount.ToString())
                                ,new SqlParameter("@pMachiningtime",                sMachiningTime.ToString())
                                ,new SqlParameter("@pRemark",                       sRemark1.ToString())

                                ,new SqlParameter("@pReg_worker",                   sReg_worker.ToString())
                                ,new SqlParameter("@pReg_datetime",                 sReg_datetime.ToString())
                                ,new SqlParameter("@pMod_worker",                   sMod_worker.ToString())
                                ,new SqlParameter("@pMod_datetime",                 sMod_datetime.ToString())
                            };

                            isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                            if (!isCheck)
                            {
                                sTran.Rollback();
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region 이미지 관련 주석
                    #region 기존 이미지 데이터 숨김처리
                    //_Query = new StringBuilder();
                    //_Query.Append("	update tb_file_info set	                                                                                            ");
                    //_Query.Append("		 del_gubun = 'Y'		                                                                                        ");
                    //_Query.Append("		,mod_worker = @pUser	                                                                                        ");
                    //_Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    //_Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    //_Query.Append("	where 1 = 1				                                                                                            ");
                    //_Query.Append("		and mc_idx = @pMc_idx	                                                                                        ");
                    //_Query.Append("		and del_gubun = 'N'	                                                                                            ");
                    //_SqlParams = new SqlParameter[]
                    //{
                    //     new SqlParameter("@pMc_idx",    Convert.ToDecimal(sMcIdx.ToString()))
                    //    ,new SqlParameter("@pUser",      sUser.ToString())
                    //};

                    //isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    //if (!isCheck)
                    //{
                    //    sTran.Rollback();
                    //    return;
                    //}
                    #endregion

                    //#region 이미지 데이터 및 이미지 저장
                    //if (dgv2.Rows.Count > 0)
                    //{
                    //    #region 신규 데이터 INSERT
                    //    _Query = new StringBuilder();
                    //    _Query.Append("	insert into tb_file_info					                                            ");
                    //    _Query.Append("	(										                                                ");
                    //    _Query.Append("		 mc_idx         ,path           ,origin_name        ,new_name       ,file_save	    ");
                    //    _Query.Append("		,del_gubun      ,reg_worker     ,reg_datetime       ,mod_worker     ,mod_datetime   ");
                    //    _Query.Append("		,del_datetime                                                                       ");
                    //    _Query.Append("	)										                                                ");
                    //    _Query.Append("	values									                                                ");
                    //    _Query.Append("	(										                                                ");
                    //    _Query.Append("		 @pMc_idx       ,@pPath         ,@pOrigin_name      ,@pNew_name     ,@pFile_save    ");
                    //    _Query.Append("		,@pDel_gubun    ,@pReg_worker   ,@pReg_datetime     ,@pMod_worker   ,@pMod_datetime ");
                    //    _Query.Append("		,@pdel_datetime                                                                     ");
                    //    _Query.Append("	)										                                                ");

                    //    for (int i = 0; i < dgv2.Rows.Count; i++)
                    //    {
                    //        sOriginName = dgv2.Rows[i].Cells["origin_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["origin_name2"].Value.ToString();

                    //        sDel_gubun = dgv2.Rows[i].Cells["del_gubun2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_gubun2"].Value.ToString();
                    //        sReg_worker = dgv2.Rows[i].Cells["reg_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_worker2"].Value.ToString();
                    //        sReg_datetime = dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString();
                    //        sMod_worker = dgv2.Rows[i].Cells["mod_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_worker2"].Value.ToString();
                    //        sMod_datetime = dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString();
                    //        sDel_datetime = dgv2.Rows[i].Cells["del_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_datetime2"].Value.ToString();


                    //        if (dgv2["file_save2", i].Value.ToString() == "Y")
                    //        {
                    //            sNewName = dgv2.Rows[i].Cells["new_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["new_name2"].Value.ToString();
                    //        }
                    //        else
                    //        {
                    //            sNewName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + dgv2["origin_name2", i].Value.ToString();
                    //        }


                    //        //신규 등록
                    //        if (sReg_worker == string.Empty)
                    //        {
                    //            sReg_worker = sUser;
                    //            sReg_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //            sMod_worker = string.Empty;
                    //            sMod_datetime = string.Empty;
                    //        }
                    //        else//수정 등록
                    //        {
                    //            sMod_worker = sUser;
                    //            sMod_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //        }


                    //        sPath = _Ftp._Path + sMcIdx + "/";
                    //        sFullPath = sPath + sNewName;

                    //        _SqlParams = new SqlParameter[]
                    //        {
                    //             new SqlParameter("@pMc_idx",           Convert.ToDecimal(sMcIdx.ToString()))
                    //            ,new SqlParameter("@pPath",             sPath.ToString())
                    //            ,new SqlParameter("@pOrigin_name",      sOriginName.ToString())
                    //            ,new SqlParameter("@pNew_name",         sNewName.ToString())
                    //            ,new SqlParameter("@pFile_save",        "Y")
                    //            ,new SqlParameter("@pDel_gubun",        "N")
                    //            ,new SqlParameter("@pReg_worker",       sReg_worker)
                    //            ,new SqlParameter("@pReg_datetime",     sReg_datetime)
                    //            ,new SqlParameter("@pMod_worker",       sMod_worker)
                    //            ,new SqlParameter("@pMod_datetime",     sMod_datetime)
                    //            ,new SqlParameter("@pDel_datetime",     sDel_datetime)
                    //        };

                    //        isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    //        if (dgv2["file_save2", i].Value.ToString() == "Y")
                    //        {
                    //            iImageIdx = 0;
                    //            continue;
                    //        }


                    //        #region     IMAGE 저장
                    //        bool chkDir;

                    //        //트루반환 : 폴더 존재
                    //        //펄스반환 : 폴더 미존재
                    //        chkDir = _Ftp.DoesFtpDirectoryExist(sPath);

                    //        if (!chkDir)
                    //        {
                    //            _Ftp.CreateFolder(sPath);
                    //        }

                    //        _Ftp.UploadFile(_StringList[iImageIdx], sFullPath);
                    //        iImageIdx++;

                    //        if (!isCheck)
                    //        {
                    //            sTran.Rollback();
                    //            return;
                    //        }
                    //        #endregion
                    //    }
                    //    #endregion
                    //}
                    //#endregion
                    #endregion

                    #region 커밋
                    if (isCheck)
                    {
                        sTran.Commit();
                        MessageBox.Show("저장되었습니다.");
                        _ImageList = new ImageList();
                        _StringList = new List<string>();
                        ComboSetting();
                        Search(sMcCode);
                        CtrColor();
                        DataGridViewVisible();
                    }
                    #endregion
                }
                #endregion

                #region 재조회
                //_ImageList = new ImageList();
                //_StringList = new List<string>();
                //ComboSetting();
                //Search(sMcCode);
                //CtrColor();
                //DataGridViewVisible();
                #endregion
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
                _DB.CloseDB();
            }
        }

        private void cbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Search(cbMcCode.Text);
                CtrColor();
                //DataGridViewVisible();
                this.cbMcCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
                if (lvwImage.Items.Count < 1) return;

                int iIndex = dgv2.CurrentRow.Index;

                for (int i = 0; i < lvwImage.Items.Count; i++)
                {
                    lvwImage.Items[i].Focused = false;
                    lvwImage.Items[i].Selected = false;
                }
                lvwImage.Items[iIndex].Focused = true;
                lvwImage.Items[iIndex].Selected = true;
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
                if (cbMcCode.Text.Length < 1)
                {
                    MessageBox.Show("설비 코드를 입력하십시오.");
                    cbMcCode.Focus();
                    cbMcCode.SelectAll();
                    return;
                }

                frmMcCodeCopy frm = new frmMcCodeCopy(cbMcCode, cbMcCode.Text);

                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    if (_GlobalMcCode.Length > 0)
                    {
                        CtrInit();
                        ComboSetting();
                        Search(_GlobalMcCode);
                        CtrColor();
                        DataGridViewVisible();
                        _GlobalMcCode = string.Empty;
                    }
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _DB.ConnectDB();
            SqlTransaction sTran = null;
            DataTable dt = new DataTable();
            bool isCheck;
            string sUser = "KMG";

            try
            {
                #region 변수 선언 설비
                 string sIdx = txtMcIdx.Text == null ? string.Empty : txtMcIdx.Text;
                #endregion

                #region 유효성 검사
                if (cbMcCode.Text.Length < 1)
                {
                    MessageBox.Show("설비코드를 입력하십시오.");
                    cbMcCode.Focus();
                    cbMcCode.SelectAll();
                    return;
                }

                if (txtMcIdx.Text.Length < 1)
                {
                    MessageBox.Show("저장되지 않은 데이터입니다.");
                    cbMcCode.Focus();
                    cbMcCode.SelectAll();
                    return;
                }
                #endregion

                #region  저장 로직
                if (MessageBox.Show("설비 정보를 삭제 하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sTran = TestbedDB.sqlConn.BeginTransaction();

                    #region 기존 데이터 숨김처리
                    _Query = new StringBuilder();
                    _Query.Append("	update tb_machine_info set	                                                                                        ");
                    _Query.Append("		 del_gubun = 'Y'		                                                                                        ");
                    _Query.Append("		,mod_worker = @pUser                                                                                            ");
                    _Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))    ");
                    _Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))    ");
                    _Query.Append("	where 1 = 1 			                                                                                            ");
                    _Query.Append("		and idx = @pIdx	                                                                                                ");
                    _Query.Append("		and del_gubun = 'N'                                                                                             ");
                    _SqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pIdx",   Convert.ToDecimal(sIdx.ToString()))
                        ,new SqlParameter("@pUser",  sUser.ToString())
                    };

                    isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    else
                    {
                        sTran.Commit();
                        CtrInit();
                        ComboSetting();
                        Search(_GlobalMcCode);
                        CtrColor();
                        DataGridViewVisible();
                        MessageBox.Show("삭제되었습니다.");
                    }
                    #endregion
                }
                #endregion

                #region 초기화
                _ImageList = new ImageList();
                _StringList = new List<string>();
                #endregion
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
                _DB.CloseDB();
            }
        }

        private void lvwImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgv2.CurrentCell = null;

                if (dgv2.Rows.Count < 1) return;
                if (lvwImage.Items.Count < 1) return;

                if (lvwImage.SelectedItems.Count != 0)
                {
                    int SelectRow = lvwImage.SelectedItems[0].Index;

                    dgv2.Rows[SelectRow].Selected = true;
                    dgv2.CurrentCell = dgv2.Rows[SelectRow].Cells["path2"];
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

        private void btnImgSave_Click(object sender, EventArgs e)
        {
            #region 변수, 생성자, 인스턴스 선언
            _DB.ConnectDB();

            DataTable dt = new DataTable();
            SqlTransaction sTran = null;

            string[] sFiles;
            string[] sName;

            string sMcIdx = string.Empty;
            string sMcCode = string.Empty;
            string sPath = string.Empty;
            string sFullPath = string.Empty;
            int iImageIdx = 0;

            string sOriginName = string.Empty;
            string sNewName = string.Empty;

            string sDel_gubun = string.Empty;
            string sReg_worker = string.Empty;
            string sReg_datetime = string.Empty;
            string sMod_worker = string.Empty;
            string sMod_datetime = string.Empty;
            string sDel_datetime = string.Empty;
            bool isCheck;
            #endregion

            try
            {
                #region 변수에 값 할당
                sMcIdx = txtMcIdx.Text == null ? string.Empty : txtMcIdx.Text;
                sMcCode = cbMcCode.Text == null ? string.Empty : cbMcCode.Text;
                #endregion

                #region 유효성 검사
                if (sMcIdx.Length < 1 || sMcIdx == "0")
                {
                    MessageBox.Show("설비 정보 등록 후 이미지를 등록하여 주십시오.");
                    return;
                }
                #endregion

                if (MessageBox.Show("이미지를 등록 하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OpenFileDialog _Dialog = new OpenFileDialog();
                    _Dialog.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png|jpeg (*.jpeg)|*.jpeg";
                    _Dialog.Multiselect = true;

                    DialogResult dr = _Dialog.ShowDialog();

                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        #region 파일첨부 로직
                        sFiles = _Dialog.FileNames;
                        sName = _Dialog.SafeFileNames;

                        dt = dgv2.DataSource as DataTable;

                        foreach (string sImg in sName)
                        {
                            dt.Rows.Add(0, 0, "", sImg, "", "N", "N", "", "", "", "", "");
                        }
                        dgv2.DataSource = dt;

                        foreach (string sImg in sFiles)
                        {
                            _StringList.Add(sImg);
                        }
                        #endregion

                        sTran = TestbedDB.sqlConn.BeginTransaction();

                        #region 기존 이미지 데이터 숨김처리
                        //file_info의 idx도 조건에 넣어야함
                        _Query = new StringBuilder();
                        _Query.Append("	update tb_file_info set	                                                                                            ");
                        _Query.Append("		 del_gubun = 'Y'		                                                                                        ");
                        _Query.Append("		,mod_worker = @pUser	                                                                                        ");
                        _Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                        _Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                        _Query.Append("	where 1 = 1				                                                                                            ");
                        _Query.Append("		and mc_idx = @pMc_idx	                                                                                        ");
                        _Query.Append("		and del_gubun = 'N'	                                                                                            ");
                        _SqlParams = new SqlParameter[]
                        {
                             new SqlParameter("@pMc_idx",    Convert.ToDecimal(sMcIdx.ToString()))
                            ,new SqlParameter("@pUser",      sUser.ToString())
                        };

                        isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                        if (!isCheck)
                        {
                            sTran.Rollback();
                            return;
                        }
                        #endregion

                        #region 이미지 데이터 및 이미지 저장
                        if (dgv2.Rows.Count > 0)
                        {
                            #region 신규 이미지 데이터 INSERT 및 이미지 파일 저장
                            _Query = new StringBuilder();
                            _Query.Append("	insert into tb_file_info					                                            ");
                            _Query.Append("	(										                                                ");
                            _Query.Append("		 mc_idx         ,path           ,origin_name        ,new_name       ,file_save	    ");
                            _Query.Append("		,del_gubun      ,reg_worker     ,reg_datetime       ,mod_worker     ,mod_datetime   ");
                            _Query.Append("		,del_datetime                                                                       ");
                            _Query.Append("	)										                                                ");
                            _Query.Append("	values									                                                ");
                            _Query.Append("	(										                                                ");
                            _Query.Append("		 @pMc_idx       ,@pPath         ,@pOrigin_name      ,@pNew_name     ,@pFile_save    ");
                            _Query.Append("		,@pDel_gubun    ,@pReg_worker   ,@pReg_datetime     ,@pMod_worker   ,@pMod_datetime ");
                            _Query.Append("		,@pdel_datetime                                                                     ");
                            _Query.Append("	)										                                                ");

                            for (int i = 0; i < dgv2.Rows.Count; i++)
                            {
                                #region 이미지 DATA 저장
                                sOriginName = dgv2.Rows[i].Cells["origin_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["origin_name2"].Value.ToString();
                                sDel_gubun = dgv2.Rows[i].Cells["del_gubun2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_gubun2"].Value.ToString();
                                sReg_worker = dgv2.Rows[i].Cells["reg_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_worker2"].Value.ToString();
                                sReg_datetime = dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString();
                                sMod_worker = dgv2.Rows[i].Cells["mod_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_worker2"].Value.ToString();
                                sMod_datetime = dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString();
                                sDel_datetime = dgv2.Rows[i].Cells["del_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_datetime2"].Value.ToString();


                                if (dgv2["file_save2", i].Value.ToString() == "Y")
                                {
                                    sNewName = dgv2.Rows[i].Cells["new_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["new_name2"].Value.ToString();
                                }
                                else
                                {
                                    sNewName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + dgv2["origin_name2", i].Value.ToString();
                                }


                                //신규 등록
                                if (sReg_worker == string.Empty)
                                {
                                    sReg_worker = sUser;
                                    sReg_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    sMod_worker = string.Empty;
                                    sMod_datetime = string.Empty;
                                }
                                else//수정 등록
                                {
                                    sMod_worker = sUser;
                                    sMod_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                }


                                sPath = _Ftp._Path + sMcIdx + "/";
                                sFullPath = sPath + sNewName;

                                _SqlParams = new SqlParameter[]
                                {
                                     new SqlParameter("@pMc_idx",           Convert.ToDecimal(sMcIdx.ToString()))
                                    ,new SqlParameter("@pPath",             sPath.ToString())
                                    ,new SqlParameter("@pOrigin_name",      sOriginName.ToString())
                                    ,new SqlParameter("@pNew_name",         sNewName.ToString())
                                    ,new SqlParameter("@pFile_save",        "Y")
                                    ,new SqlParameter("@pDel_gubun",        "N")
                                    ,new SqlParameter("@pReg_worker",       sReg_worker)
                                    ,new SqlParameter("@pReg_datetime",     sReg_datetime)
                                    ,new SqlParameter("@pMod_worker",       sMod_worker)
                                    ,new SqlParameter("@pMod_datetime",     sMod_datetime)
                                    ,new SqlParameter("@pDel_datetime",     sDel_datetime)
                                };

                                isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                                if (dgv2["file_save2", i].Value.ToString() == "Y")
                                {
                                    iImageIdx = 0;
                                    continue;
                                }
                                #endregion

                                #region     IMAGE 저장
                                bool chkDir;

                                //트루반환 : 폴더 존재
                                //펄스반환 : 폴더 미존재
                                chkDir = _Ftp.DoesFtpDirectoryExist(sPath);

                                if (!chkDir)
                                {
                                    _Ftp.CreateFolder(sPath);
                                }

                                _Ftp.UploadFile(_StringList[iImageIdx], sFullPath);
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
                        #endregion

                        #region 커밋
                        if (isCheck)
                        {
                            sTran.Commit();
                            _ImageList = new ImageList();
                            _StringList = new List<string>();
                            //ComboSetting();
                            Search(sMcCode);
                            MessageBox.Show("이미지가 등록되었습니다.");
                            //CtrColor();
                            //DataGridViewVisible();
                        }
                        #endregion
                    }
                }

            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
                _DB.CloseDB();
            }
        }

        private void btnImgDel_Click(object sender, EventArgs e)
        {
            #region  변수, 생성자, 인스턴스 선언
            _DB.ConnectDB();

            DataTable dt = new DataTable();
            SqlTransaction sTran = null;

            bool isCheck;

            string sMcIdx = string.Empty;
            string sMcCode = string.Empty;

            string sFullPath = string.Empty;

            string sOriginName = string.Empty;
            string sNewName = string.Empty;
            string sFileSave = string.Empty;

            string sDel_gubun = string.Empty;
            string sReg_worker = string.Empty;
            string sReg_datetime = string.Empty;
            string sMod_worker = string.Empty;
            string sMod_datetime = string.Empty;
            string sDel_datetime = string.Empty;

            //int _lvwCount = 0;
            #endregion

            try
            {
                #region 변수에 값 할당
                sMcIdx = txtMcIdx.Text == null ? string.Empty : txtMcIdx.Text;
                sMcCode = cbMcCode.Text == null ? string.Empty : cbMcCode.Text;
                #endregion

                #region 유효성 검사
                if (sMcIdx.Length < 1 || sMcIdx == "0")
                {
                    MessageBox.Show("설비 정보 등록 후 이미지를 등록하여 주십시오.");
                    return;
                }

                if (dgv2.Rows.Count < 1)
                {
                    MessageBox.Show("등록된 이미지가 없습니다. 확인하십시오.");
                    return;
                }

                //for (int row = lvwImage.Items.Count - 1; row >= 0; row--)
                //{
                //    if (lvwImage.Items[row].Checked)
                //    {
                //        _lvwCount++;
                //    }
                //}

                //if (_lvwCount < 1)
                //{
                //    MessageBox.Show("삭제할 이미지를 체크하여주십시오.");
                //    return;
                //}
                #endregion

                if (MessageBox.Show("이미지를 삭제 하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    int iIndex = dgv2.CurrentRow.Index;
                    string sfileIdx = dgv2.Rows[iIndex].Cells["idx2"].Value.ToString();

                    #region 그리드에서 데이터 숨기기
                    dgv2.Rows.RemoveAt(iIndex);
                    for (int row = lvwImage.Items.Count - 1; row >= 0; row--)
                    {
                        if (lvwImage.Items[row].Checked)
                        {
                            dgv2.Rows.RemoveAt(row);
                        }
                    }
                    #endregion

                    sTran = TestbedDB.sqlConn.BeginTransaction();

                    #region 기존 이미지 데이터 숨김처리
                    _Query = new StringBuilder();
                    _Query.Append("	update tb_file_info set	                                                                                            ");
                    _Query.Append("		 del_gubun = 'Y'		                                                                                        ");
                    _Query.Append("		,mod_worker = @pUser	                                                                                        ");
                    _Query.Append("		,mod_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    _Query.Append("		,del_datetime = (select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	");
                    _Query.Append("	where 1 = 1				                                                                                            ");
                    _Query.Append("		and mc_idx = @pMc_idx	                                                                                        ");
                    _Query.Append("		and del_gubun = 'N'	                                                                                            ");
                    _SqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@pMc_idx",    Convert.ToDecimal(sMcIdx.ToString()))
                        ,new SqlParameter("@pUser",      sUser.ToString())
                    };

                    isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    #endregion

                    #region 이미지 데이터 처리 로직
                    if (dgv2.Rows.Count > 0)
                    {
                        #region 신규 이미지 데이터 INSERT 및 이미지 파일 저장
                        _Query = new StringBuilder();
                        _Query.Append("	insert into tb_file_info					                                            ");
                        _Query.Append("	(										                                                ");
                        _Query.Append("		 mc_idx         ,path           ,origin_name        ,new_name       ,file_save	    ");
                        _Query.Append("		,del_gubun      ,reg_worker     ,reg_datetime       ,mod_worker     ,mod_datetime   ");
                        _Query.Append("		,del_datetime                                                                       ");
                        _Query.Append("	)										                                                ");
                        _Query.Append("	values									                                                ");
                        _Query.Append("	(										                                                ");
                        _Query.Append("		 @pMc_idx       ,@pPath         ,@pOrigin_name      ,@pNew_name     ,@pFile_save    ");
                        _Query.Append("		,@pDel_gubun    ,@pReg_worker   ,@pReg_datetime     ,@pMod_worker   ,@pMod_datetime ");
                        _Query.Append("		,@pdel_datetime                                                                     ");
                        _Query.Append("	)										                                                ");

                        for (int i = 0; i < dgv2.Rows.Count; i++)
                        {
                            #region 이미지 DATA 저장
                            sFullPath = dgv2.Rows[i].Cells["path2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["path2"].Value.ToString();
                            sOriginName = dgv2.Rows[i].Cells["origin_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["origin_name2"].Value.ToString();
                            sNewName = dgv2.Rows[i].Cells["new_name2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["new_name2"].Value.ToString();
                            sFileSave = dgv2.Rows[i].Cells["file_save2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["file_save2"].Value.ToString();
                            sDel_gubun = dgv2.Rows[i].Cells["del_gubun2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_gubun2"].Value.ToString();
                            sReg_worker = dgv2.Rows[i].Cells["reg_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_worker2"].Value.ToString();
                            sReg_datetime = dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["reg_datetime2"].Value.ToString();
                            sMod_worker = dgv2.Rows[i].Cells["mod_worker2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_worker2"].Value.ToString();
                            sMod_datetime = dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["mod_datetime2"].Value.ToString();
                            sDel_datetime = dgv2.Rows[i].Cells["del_datetime2"].Value.ToString() == null ? string.Empty : dgv2.Rows[i].Cells["del_datetime2"].Value.ToString();


                            //신규 등록
                            if (sReg_worker == string.Empty)
                            {
                                sReg_worker = sUser;
                                sReg_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                sMod_worker = string.Empty;
                                sMod_datetime = string.Empty;
                            }
                            else//수정 등록
                            {
                                sMod_worker = sUser;
                                sMod_datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            }

                            _SqlParams = new SqlParameter[]
                            {
                                 new SqlParameter("@pMc_idx",           Convert.ToDecimal(sMcIdx.ToString()))
                                ,new SqlParameter("@pPath",             sFullPath.ToString())
                                ,new SqlParameter("@pOrigin_name",      sOriginName.ToString())
                                ,new SqlParameter("@pNew_name",         sNewName.ToString())
                                ,new SqlParameter("@pFile_save",        sFileSave.ToString())
                                ,new SqlParameter("@pDel_gubun",        sDel_gubun.ToString())
                                ,new SqlParameter("@pReg_worker",       sReg_worker.ToString())
                                ,new SqlParameter("@pReg_datetime",     sReg_datetime.ToString())
                                ,new SqlParameter("@pMod_worker",       sMod_worker.ToString())
                                ,new SqlParameter("@pMod_datetime",     sMod_datetime.ToString())
                                ,new SqlParameter("@pDel_datetime",     sDel_datetime.ToString())
                            };

                            isCheck = _DB.ExecuteQuery_Tran(_Query, _SqlParams, sTran);

                            if (!isCheck)
                            {
                                sTran.Rollback();
                                return;
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                    #region 커밋
                    if (isCheck)
                    {
                        sTran.Commit();
                        //ComboSetting();
                        Search(sMcCode);
                        MessageBox.Show("이미지가 삭제되었습니다.");
                        //CtrColor();
                        //DataGridViewVisible();
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
                _DB.CloseDB();
            }
        }

        private void lvwImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sPath = string.Empty;
            string sName = string.Empty;

            try
            {
                if (lvwImage.Items.Count < 1) return;



                //더블클릭하면 자동으로 체크되는 현상.... 임시 조치
                var firstSelectedItem = lvwImage.SelectedItems[0];
                firstSelectedItem.Checked = false;

                if (e.Button == MouseButtons.Left)
                {
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

        private void lvwImage_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvwImage.FocusedItem;

                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    //contextMenuStrip1.ShowImageMargin = true;
                    //contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);

                    //var bmp = new Bitmap(Properties.Resources.setting_bt_minus1);

                    //ToolStripMenuItem1.Image = System.Drawing.Image.FromFile(bmp.ToString());

                    //contextMenuStrip1.Show(lvwImage, new Point(e.X, e.Y));

                    //오른쪽 메뉴를 만듭니다
                    ContextMenu m = new ContextMenu();

                    //메뉴에 들어갈 아이템을 만듭니다
                    MenuItem m1 = new MenuItem();

                    m1.Text = "삭제하기";

                    // 각 메뉴를 선택했을 때의 이벤트 핸들러를 작성합니다. 람다식을 이용해 작성하는것이 해법입니다.
                    //검색 넣어줌
                    m1.Click += (senders, es) =>
                    {
                        btnImgDel_Click(null, null);
                    };

                    m.MenuItems.Add(m1);

                    //현재 마우스가 위치한 장소에 메뉴를 띄워줍니다
                    m.Show(lvwImage, new Point(e.X, e.Y));

                    //GetRecommendFriends();
                }
            }



            //if (e.Button.Equals(MouseButtons.Right))
            //{
            //    string selectedNickname = lvwImage.GetItemAt(e.X, e.Y).Text;

            //    //ListView.SelectedListViewItemCollection items = lvwImage.SelectedItems;
            //    //ListViewItem lvItem = items[0];
            //    //string add = lvItem.SubItems[0].Text;
            //    //string lat = lvItem.SubItems[1].Text;
            //    //string lng = lvItem.SubItems[2].Text;



            //    int iIndex = dgv2.CurrentRow.Index == null ? -1 : dgv2.CurrentRow.Index;

            //    if (iIndex == -1) return;

            //    string sPath = dgv2.Rows[iIndex].Cells["path2"].Value.ToString();
            //    string sName = dgv2.Rows[iIndex].Cells["new_name2"].Value.ToString();
            //    //MessageBox.Show(sPath + "\n" + sName);

            //    //오른쪽 메뉴를 만듭니다
            //    ContextMenu m = new ContextMenu();

            //    //메뉴에 들어갈 아이템을 만듭니다
            //    MenuItem m1 = new MenuItem();

            //    m1.Text = "삭제하기";

            //    // 각 메뉴를 선택했을 때의 이벤트 핸들러를 작성합니다. 람다식을 이용해 작성하는것이 해법입니다.
            //    //검색 넣어줌
            //    m1.Click += (senders, es) =>
            //    {
            //        btnImgDel_Click(null, null);
            //        //외부 함수에 아까 선택했던 아이템의 정보를 넘겨줍니다.
            //        //friendFeedSearch(selectedNickname);
            //        //MessageBox.Show(sPath + "\n" + sName);
            //    };

            //    m.MenuItems.Add(m1);

            //    //현재 마우스가 위치한 장소에 메뉴를 띄워줍니다
            //    m.Show(lvwImage, new Point(e.X, e.Y));

            //    //GetRecommendFriends();
            //}
        }

        private void ComboTextCenter(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }
    }
}
