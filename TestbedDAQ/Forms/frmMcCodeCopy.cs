using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TestbedDAQ.UseClass;

namespace TestbedDAQ.Forms
{
    public partial class frmMcCodeCopy : Form
    {

        TestbedDB _DB;

        public string _McCode;
        ComboBox _ComboBox;

        private string sUser = "KMG";

        public frmMcCodeCopy(ComboBox comboBox, string sMcCode)
        {
            InitializeComponent();

            _ComboBox = comboBox;
            this._McCode = sMcCode;
        }

        private void frmMcCodeCopy_Load(object sender, EventArgs e)
        {
            try
            {
                var tmpItems = _ComboBox.Items.Cast<Object>().ToArray();
                //var filteredItems = tmpItems;

                cbOfferCode.Items.Clear();
                //cbOfferCode.Items.AddRange(filteredItems);
                cbOfferCode.Items.AddRange(tmpItems);

                txtNewCode.Text = _McCode;

                _DB = new TestbedDB();
                this.cbOfferCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _DB.ConnectDB();
            SqlTransaction sTran = null;
            DataTable dt = new DataTable();
            StringBuilder _sQuery;
            SqlParameter[] _sqlParams;

            bool isCheck;
            string sIdx = string.Empty;

            string sMcNewCode = string.Empty;
            string sMcOfferCode = string.Empty;

            try
            {
                #region 변수에 값 할당
                sMcNewCode = txtNewCode.Text == null ? string.Empty : txtNewCode.Text;
                sMcOfferCode = cbOfferCode.Text == null ? string.Empty : cbOfferCode.Text;
                #endregion

                #region 유효성 검사
                if (txtNewCode.Text.Length < 1)
                {
                    MessageBox.Show("복사대상자를 입력하십시오.");
                    txtNewCode.Focus();
                    txtNewCode.SelectAll();
                    return;
                }

                if (cbOfferCode.Text.Length < 1)
                {
                    MessageBox.Show("복사제공자를 선택하십시오.");
                    cbOfferCode.Focus();
                    cbOfferCode.SelectAll();
                    return;
                }
                #endregion

                #region 복사 로직
                if (MessageBox.Show("설비코드를 복사하시겠습니까?", "YN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sTran = TestbedDB.sqlConn.BeginTransaction();

                    #region     설비 정보 복사
                    _sQuery = new StringBuilder();
                    _sQuery.Append("	insert into tb_machine_info							                                                    ");
                    _sQuery.Append("	(													                                                    ");
                    _sQuery.Append("		 idx											                                                    ");
                    _sQuery.Append("	    ,fac											                                                    ");
                    _sQuery.Append("	    ,code											                                                    ");
                    _sQuery.Append("	    ,name											                                                    ");
                    _sQuery.Append("	    ,spec											                                                    ");
                    _sQuery.Append("	    ,motor_count									                                                    ");
                    _sQuery.Append("	    ,dept											                                                    ");
                    _sQuery.Append("	    ,location										                                                    ");
                    _sQuery.Append("	    ,maker											                                                    ");
                    _sQuery.Append("	    ,makerdate										                                                    ");
                    _sQuery.Append("	    ,state											                                                    ");
                    _sQuery.Append("	    ,type										                                                        ");
                    _sQuery.Append("	    ,version										                                                    ");
                    _sQuery.Append("	    ,standard									                                                        ");
                    _sQuery.Append("	    ,remark											                                                    ");
                    _sQuery.Append("	    ,del_gubun										                                                    ");
                    _sQuery.Append("	    ,reg_worker										                                                    ");
                    _sQuery.Append("	    ,reg_datetime									                                                    ");
                    _sQuery.Append("	    ,mod_worker										                                                    ");
                    _sQuery.Append("	    ,mod_datetime									                                                    ");
                    _sQuery.Append("	)													                                                    ");
                    _sQuery.Append("	select 												                                                    ");
                    _sQuery.Append("		 (	select	isnull(max(a.idx), 0) + 1  as idx	                                                    ");
                    _sQuery.Append("			from	tb_machine_info a with(nolock)    	                                                    ");
                    _sQuery.Append("			where  1 = 1) 								                                                    ");
                    _sQuery.Append("	    ,a.fac											                                                    ");
                    _sQuery.Append("	    ,@pNewCode										                                                    ");
                    _sQuery.Append("	    ,a.name			                                                                                    ");
                    _sQuery.Append("	    ,a.spec			                                                                                    ");
                    _sQuery.Append("	    ,a.motor_count	                                                                                    ");
                    _sQuery.Append("	    ,a.dept			                                                                                    ");
                    _sQuery.Append("	    ,a.location		                                                                                    ");
                    _sQuery.Append("	    ,a.maker		                                                                                    ");
                    _sQuery.Append("	    ,a.makerdate	                                                                                    ");
                    _sQuery.Append("	    ,a.state		                                                                                    ");
                    _sQuery.Append("	    ,a.type			                                                                                    ");
                    _sQuery.Append("	    ,a.version		                                                                                    ");
                    _sQuery.Append("	    ,a.standard		                                                                                    ");
                    _sQuery.Append("	    ,a.remark		                                                                                    ");
                    _sQuery.Append("	    ,a.del_gubun	                                                                                    ");
                    _sQuery.Append("	    ,@pUser	                                                                                            ");
                    _sQuery.Append("	    ,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	    ");
                    _sQuery.Append("	    ,@pUser	                                                                                            ");
                    _sQuery.Append("	    ,(select replace(replace(replace(convert( varchar , getdate()  ,120),'-',''),':',''),' ',''))	    ");
                    _sQuery.Append("	from tb_machine_info a with(nolock)					                                                    ");
                    _sQuery.Append("	where 1 = 1 										                                                    ");
                    _sQuery.Append("		and  code = @pOfferCode							                                                    ");

                    _sqlParams = new SqlParameter[]
                    {
                         new SqlParameter("@pNewCode",    sMcNewCode)
                        ,new SqlParameter("@pOfferCode",  sMcOfferCode)
                        ,new SqlParameter("@pUser",       sUser)
                    };
                    isCheck = _DB.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran);

                    if (!isCheck)
                    {
                        sTran.Rollback();
                        return;
                    }
                    else
                    {
                        sTran.Commit();
                        MessageBox.Show("복사되었습니다.");
                        _DB.CloseDB();

                        frmMCManager._GlobalMcCode = sMcNewCode;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                _DB.CloseDB();
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
                if (sTran != null) sTran.Dispose();
                if (dt != null) dt.Dispose();
            }
        }
    }
}
