using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestbedDAQ.UseClass
{
    public class TestbedDB
    {
        public static string sConn = String.Format("Data Source=218.155.74.35;Initial Catalog=iPlusPOP_SJSM_TEST;Persist Security Info=True;User ID=erpUser;Password=erpPasswd");


        public static SqlConnection sqlConn = new SqlConnection();


        /// <summary>
        /// DB 연결
        /// </summary>
        public void ConnectDB()
        {
            try
            {
                if (sqlConn.State.ToString().Equals("Closed"))
                {
                    sqlConn.ConnectionString = sConn;
                    sqlConn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
        }


        /// <summary>
        /// DB 닫기
        /// </summary>
        public void CloseDB()
        {
            try
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
        }


        /// <summary>
        /// 트랜잭션 미사용 SELECT 전용 메서드
        /// </summary>
        public DataView GetDataView(string tableName, StringBuilder strQuery, SqlParameter[] sqlParams, bool showProgressDialog = false)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter SqlAdapter = null;
            DataView returnView = null;

            try
            {
                //sqlConn.ConnectionString = sConn;
                //sqlConn.Open();

                cmd.Connection = sqlConn;
                cmd.CommandText = strQuery.ToString();

                if (sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }

                SqlAdapter = new SqlDataAdapter(cmd);
                SqlAdapter.Fill(ds, tableName);
                returnView = ds.Tables[tableName].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                ds = new DataSet();
                returnView = null;
            }
            finally
            {
                if (SqlAdapter != null) SqlAdapter.Dispose();
                if (cmd.Parameters != null) cmd.Parameters.Clear();
                if (cmd != null) cmd.Dispose();
                //if (sqlConn != null) sqlConn.Close();
            }
            return returnView;

        }


        /// <summary>
        /// 트랜잭션 미사용 INSERT / UPDATE / DELETE 전용 메서드
        /// </summary>
        public bool ExecuteQuery(StringBuilder strQuery, SqlParameter[] sqlParams, bool showProgressDialog = false)
        {
            SqlCommand cmd = new SqlCommand();
            bool IsRtv = true;
            try
            {
                //sqlConn.ConnectionString = sConn;
                //sqlConn.Open();

                cmd.Connection = sqlConn;

                cmd.CommandText = strQuery.ToString();
                if (sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                IsRtv = false;
            }
            finally
            {
                if (cmd.Parameters != null) cmd.Parameters.Clear();
                if (cmd != null) cmd.Dispose();
                //if (sqlConn != null) sqlConn.Close();
            }
            return IsRtv;
        }


        /// <summary>
        /// 트랜잭션 사용 SELECT 전용 메서드
        /// </summary>
        public DataView GetDataView_Tran(string tableName, StringBuilder strQuery, SqlParameter[] sqlParams, SqlTransaction sTran, bool showProgressDialog = false)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter SqlAdapter = null;
            DataView returnView = null;
            SqlTransaction tran = sTran;

            try
            {
                cmd.Connection = sqlConn;
                cmd.Transaction = tran;

                cmd.CommandText = strQuery.ToString();
                if (sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                SqlAdapter = new SqlDataAdapter(cmd);
                SqlAdapter.Fill(ds, tableName);
                returnView = ds.Tables[tableName].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                ds = new DataSet();
                returnView = null;
            }
            finally
            {
                if (SqlAdapter != null) SqlAdapter.Dispose();
                if (cmd.Parameters != null) cmd.Parameters.Clear();
                if (cmd != null) cmd.Dispose();
            }
            return returnView;
        }


        /// <summary>
        /// 트랜잭션 사용 INSERT / UPDATE / DELETE 전용 메서드
        /// </summary>
        public bool ExecuteQuery_Tran(StringBuilder strQuery, SqlParameter[] sqlParams, SqlTransaction sTran, bool showProgressDialog = false)
        {
            SqlCommand cmd = new SqlCommand();
            bool IsRtv = true;
            try
            {
                cmd.Connection = sqlConn;
                cmd.Transaction = sTran;

                cmd.CommandText = strQuery.ToString();
                if (sqlParams.Length > 0)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return IsRtv = false;
            }
            finally
            {
                if (cmd.Parameters != null) cmd.Parameters.Clear();
                if (cmd != null) cmd.Dispose();
            }
            return IsRtv;
        }



        //테스트


        #region 사용법
        ////인스턴스 생성
        //TestbedDB _db;

        ////SELECT
        //_db.ConnectDB();
        //SqlTransaction sTran = TestbedDB.sqlConn.BeginTransaction();
        //DataTable dt = new DataTable();
        //쿼리문
        //dt = _db.GetDataView_Tran("Key_idx", _sQuery, _sqlParams, sTran).Table;
        
        //파이날리부분
        //if (sTran != null) sTran.Dispose();
        //if (dt != null) dt.Dispose();
        //_db.CloseDB();



        ////INSERT UPDATE DELETE
        //_db.ConnectDB();
        //SqlTransaction sTran = TestbedDB.sqlConn.BeginTransaction();
        //bool isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran); 
        //if (!isCheck)
        //{
        //    sTran.Rollback();
        //    return;
        //}


        //쿼리2
        //bool isCheck = _db.ExecuteQuery_Tran(_sQuery, _sqlParams, sTran); 
        //if (!isCheck)
        //{
        //    sTran.Rollback();
        //    return;
        //}

        //sTran.Commit();

        //if (sTran != null) sTran.Dispose();
        //_db.CloseDB();
        #endregion
    }
}
