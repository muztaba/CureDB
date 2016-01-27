using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace Pharma.Utility
{
    public class DbUtility
    {
        public static SqlConnection GetSqlConnection()
        {
            string conString = ConfigurationUtility.GetConnectionString();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = conString;

            return con;
        }

        public static DataTable GetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();

            SqlConnection con = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }


        public static bool GetFileSize(string filePath)
        {
            bool fileBig = false;
            string filesize = "";
            long length = new System.IO.FileInfo(filePath).Length;
            double kb = length/1024f;

            filesize = kb.ToString("##.");
            if (filesize == "")
                filesize = "0";
            if (Convert.ToInt64(filesize) > 10250)
                fileBig = true;
            return fileBig;
        }

        /// <summary>
        /// Execute query.
        /// </summary>
        /// <param name="Qry"></param>
        public static void ExecuteQuery(string Qry)
        {
            SqlConnection con = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                con.Open();

                SqlCommand cmd = new SqlCommand(Qry, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// Execute multiple query under a transaction.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void ExecuteQuery(object obj, string type)
        {
            SqlConnection con = null;
            SqlTransaction txn = null;
            SqlCommand cmd = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                con.Open();
                txn = con.BeginTransaction();
                cmd = new SqlCommand();
                SortedList sl = new SortedList();
                sl = (SortedList) obj;
                foreach (string strQry in sl.Values)
                {
                    cmd = new SqlCommand(strQry, con, txn);
                    cmd.ExecuteNonQuery();
                }
                txn.Commit();
            }
            catch (Exception ex)
            {
                txn.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataSet GetDataSet(string strSQL, DataSet ds)
        {
            //DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static void LoadMasterDataset(string strSQL, ref DataSet ds)
        {
            //DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                da.Fill(ds);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object GetColValue(string table, string valCol, string condCol, string code)
        {
            string strSQL = "select " + valCol + " from " + table + " where " + condCol + "='" + code + "'";
            DataTable dt = DbUtility.GetDataTable(strSQL);
            object obj = null;
            if (dt.Rows.Count > 0)
            {
                obj = dt.Rows[0][0];
            }
            else
                obj = "";
            return obj;
        }


        //public static void GetDataSetByProcedureForMember(ref DataSet dsInfo, string memberId, int type)
        //{
        //    SqlConnection con = null;
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        con = DbUtility.GetSqlConnection();
        //        con.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "spGetMemberInformation";
        //        cmd.Parameters.Add("@memberId", SqlDbType.VarChar, 10).Value = memberId;
        //        cmd.Parameters.Add("@type", SqlDbType.VarChar, 10).Value = type;
        //        var adapt = new SqlDataAdapter();
        //        adapt.SelectCommand = cmd;
        //        var dataset = new DataSet();
        //        adapt.Fill(dsInfo);
        //        dsInfo.Tables[0].TableName = "MemberInfo";
        //        dsInfo.Tables[1].TableName = "MemberImage";
        //        dsInfo.Tables[2].TableName = "NomineeInfo";
        //        dsInfo.Tables[3].TableName = "NomineeImage";

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        public static object GetColValue(string table, string valCol, string condCol, int code)
        {
            string strSQL = "select " + valCol + " from " + table + " where " + condCol + "=" + code + "";
            DataTable dt = DbUtility.GetDataTable(strSQL);
            object obj = null;
            if (dt.Rows.Count > 0)
            {
                obj = dt.Rows[0][0];
            }
            return obj;
        }


        /// <summary>
        /// Get Data for grid.
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="WhereColumnName"></param>
        /// <param name="WhereColumnValue"></param>
        /// <returns></returns>
        public static DataTable GetDataForGrid(string TableName, string WhereColumnName, string WhereColumnValue)
        {
            DataTable dt = new DataTable();

            SqlConnection con = null;
            string strSQL = "select * from " + TableName + " Where " + WhereColumnName + " ='" + WhereColumnValue + "'";
            try
            {
                con = DbUtility.GetSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// Get data for combo.
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ValueColumn"></param>
        /// <param name="DisplayColumn"></param>
        /// <returns></returns>
        public static DataTable GetDataForCombo(string TableName, string ValueColumn, string DisplayColumn)
        {
            DataTable dt = new DataTable();

            SqlConnection con = null;
            string strSQL = "select " + ValueColumn + " as value ," + DisplayColumn + " as display from " + TableName;
            try
            {
                con = DbUtility.GetSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }


        
        /// <summary>
        /// Check Existing Value.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsExists(string table, string column, string code)
        {
            string strcheckPrimary = "select * from " + table + " where " + column + "='" + code + "'";
            DataTable dt = DbUtility.GetDataTable(strcheckPrimary);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static decimal DbObjecttoDecimal(Object obj)
        {
            if (obj == null)
                return 0;
            else if (obj == DBNull.Value)
                return 0;
            else if (obj.Equals(""))
                return 0;
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                throw new Exception("Input Is not Valid");

            }

        }

        public static int DbObjecttoInteger(Object obj)
        {
            if (obj == null)
                return 0;
            else if (obj == DBNull.Value)
                return 0;
            else if (obj.Equals(""))
                return 0;
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                throw new Exception("Input is not valid");
            }

        }

        public static long getMaxColValue(SqlConnection con, string table, string col)
        {
            string strSQL = "select max(" + col + ")+ 1 from " + table + "";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.CommandType = System.Data.CommandType.Text;
            object value = cmd.ExecuteScalar();
            value = (value is DBNull) ? 10001 : value;
            return Convert.ToInt64(value);

        }

        public static long getMaxColValue(SqlConnection con, SqlTransaction tran, string table, string col)
        {
            string strSQL = "select max(" + col + ")+ 1 from " + table + "";
            SqlCommand cmd = new SqlCommand(strSQL, con, tran);
            cmd.CommandType = System.Data.CommandType.Text;
            object value = cmd.ExecuteScalar();
            value = (value is DBNull) ? 10001 : value;
            return Convert.ToInt64(value);

        }

        public static string getSequencerValue(string sequencerName)
        {
            string strSQL = "select seq_value from app_sequencer where seq_name='" + sequencerName + "'";
            SqlConnection con = null;
            SqlCommand cmd = null;
            object value = null;
            long longObj = -1;
            try
            {
                con = DbUtility.GetSqlConnection();
                con.Open();
                cmd = new SqlCommand(strSQL, con);
                value = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            if (value == null)
            {
                throw new ApplicationException("No entry found in sequencer for key" + sequencerName);
            }
            longObj = Convert.ToInt64(value);
            longObj++;
            return longObj.ToString();

        }

        public static void UpdateSequencer(SqlConnection con, SqlTransaction txn, string sequenceName, string value)
        {
            string strSQL = " update app_sequencer set seq_value='" + value + "' where seq_name='" + sequenceName + "'";
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(strSQL, con, txn);
                int effectedRow = cmd.ExecuteNonQuery();
                if (effectedRow != 1)
                {
                    throw new ApplicationException("Unable to update sequencer value");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string DbObjecttoString(Object objStr)
        {
            if (objStr == null)
                return "";
            else if (objStr == DBNull.Value)
                return "";
            else if (objStr.Equals(""))
                return "";
            try
            {
                return Convert.ToString(objStr);
            }
            catch
            {
                throw new Exception("Input is not valid");
            }
        }

        public static string GetFloorInBangla(string floorNo)
        {
            string floorNameBangla = "";
            if (floorNo == "0")
                floorNameBangla = "wbP Zjv";
            else if (floorNo == "1")
                floorNameBangla = "2q Zjv";
            else if (floorNo == "2")
                floorNameBangla = "3q Zjv";
            else if (floorNo == "3")
                floorNameBangla = "4_© Zjv";
            else if (floorNo == "4")
                floorNameBangla = "5g Zjv";
            else if (floorNo == "5")
                floorNameBangla = "6ô Zjv";
            else if (floorNo == "6")
                floorNameBangla = "7g Zjv";
            else if (floorNo == "7")
                floorNameBangla = "8g Zjv";
            else if (floorNo == "8")
                floorNameBangla = "Aóg Zjv";
            else if (floorNo == "9")
                floorNameBangla = "9g Zjv";

            return floorNameBangla;
        }

        /// <summary>
        /// check key validation.
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Code"></param>
        /// <param name="strComp"></param>
        /// <returns></returns>
        public static char getKeyCode(string Type, int Code, string strComp)
        {
            int i = 0;
            switch (Type.ToUpper())
            {
                case "NAME":
                    if (Code >= 48 && Code <= 58) return (char) 0;
                    if (strComp.Length == 0 && (Code == 32 || Code == 46 || Code == 8))
                        return (char) i; //|| (Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char)46)
                    if (strComp.Length == 0 && (Code >= 97 && Code <= 122))
                    {
                        i = Code - 32;
                    }
                    else if (strComp.Length == 0 && (Code >= 65 && Code <= 90))
                    {
                        i = Code;
                    }
                    else if (((Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 46) ||
                              (Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 32)) && Code != 8 &&
                             (Code == 46))
                    {
                        i = 0;
                    }
                    else if ((Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 32) && Code != 8 &&
                             ((Code >= 97 && Code <= 122) || Code == 32))
                    {
                        i = Code - 32;
                    }
                    else if ((Code >= 65 && Code <= 90) || (Code >= 97 && Code <= 122) ||
                             (Code == 8 || Code == 32 || Code == 46))
                    {
                        i = Code;
                    }
                    break;

                case "N":
                    if ((Code >= 65 && Code <= 90) || (Code >= 97 && Code <= 122) ||
                        (Code == 8 || Code == 32 || Code == 46) || (Code >= 48 && Code <= 58) ||
                        (Code >= 38 && Code <= 39) || Code == 45)
                    {

                        if (strComp.Length == 0 && (Code == 32 || Code == 46 || Code == 8 || Code == 45 || Code == 39))
                            return (char) i;

                        if (strComp.Length == 0 && (Code >= 97 && Code <= 122))
                        {
                            i = Code - 32;
                            break;
                        }

                        if (Code == 32 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 32)
                        {
                            i = 0;
                            break;
                        }

                        if (Code == 46 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 46)
                        {
                            i = 0;
                            break;
                        }

                        if (Code == 45 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 45)
                        {
                            i = 0;
                            break;
                        }
                        if (Code == 39 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 39)
                        {
                            i = 0;
                            break;
                        }
                        i = Code;
                    }
                    break;

                case "NUMBER":
                    if (strComp.Length == 0 && Code == 43) return (char) 43;
                    if ((Code >= 48 && Code <= 58) || (Code == 8))
                    {
                        i = Code;
                    }
                    break;
                case "CHECK":
                    if (strComp.Length == 0 && Code == 43) return (char) 43;
                    if (strComp.Length == 0 && Code == 45) return (char) 45;

                    if ((Code >= 48 && Code <= 58) || (Code == 8) || (Code == 45))
                    {
                        i = Code;
                        if (Code == 45 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 45)
                        {
                            i = Code - 45;
                        }
                    }
                    break;

                case "DECIMAL":
                    if (strComp.Length == 0 && Code == 43) return (char) 43;


                    if ((Code >= 48 && Code <= 58) || (Code == 8) || (Code == 46))
                    {
                        if (strComp.Length == 0 && Code == 46)
                            i = Code - 46;

                        else if (strComp.Length > 0 && Code == 46)
                        {
                            i = Code;
                            if (Code == 46 && Convert.ToChar(strComp.Substring(strComp.Length - 1, 1)) == (char) 46)
                            {
                                i = Code - 46;
                            }

                            for (int k = 1; k < strComp.Length; ++k)
                            {
                                if (Convert.ToChar(strComp.Substring(strComp.Length - k, 1)) == (char) 46)
                                    i = Code - 46;
                            }

                        }
                        else
                            i = Code;


                    }

                    break;

            }
            return (char) i;
        }


        public static string GetSystemGeneratedIDByMaxCode(string tablename, string columnName, string prefix)
        {
            string IdNumber = "";
            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull( max(cast(SUBSTRING(" +
                         columnName + ",10,len(" + columnName + ")) as integer)),0)+1 as varchar) as ID from " +
                         tablename + "";
            //string Qry = "select '" + prefix + "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(" + columnName + "),0)+1 as varchar) as ID from " + tablename + " ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();
            return IdNumber;
        }

        public static string GetSystemGeneratedIDByMaxCodeUserInfo(string tablename, string columnName, string prefix)
        {
            string IdNumber = "";
            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull( max(cast(SUBSTRING(" +
                         columnName + ",11,len(" + columnName + ")) as integer)),0)+1 as varchar) as ID from " +
                         tablename + "";
            //string Qry = "select '" + prefix + "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(" + columnName + "),0)+1 as varchar) as ID from " + tablename + " ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();
            return IdNumber;
        }

        public static string GetSystemGeneratedID(string tablename, string columnName, string prefix)
        {
            string IdNumber = "";

            string Qry = "select '" + prefix + "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(" +
                         columnName + "),0)+1 as varchar) as ID from " + tablename + " ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();
            return IdNumber;
        }

        public static string GetSystemGeneratedIDForRequisition(string tablename, string columnName, string prefix)
        {
            string IdNumber = "";

            //string Qry = "select '" + prefix + "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(" + columnName + "),0)+1 as varchar) as ID from " + tablename + " ";
            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(max(cast(substring(" + columnName +
                         ",10,len(" + columnName + ")) as int))+1 as varchar) as ID from " + tablename + "";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();
            return IdNumber;
        }

        public static string GetSystemGeneratedID(string tablename, string columnName, string prefix,
            string distinctValue)
        {
            string IdNumber = "";

            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(distinct(" + columnName +
                         ")),0)+1 as varchar) as ID from " + tablename + " where isvalid=1 ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();
            return IdNumber;
        }

        public static string GetSystemGeneratedID(string tablename, string columnName, string prefix,
            string distinctValue, string po)
        {
            string IdNumber = "";

            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(distinct(" + columnName +
                         ")),0)+1 as varchar) as ID from " + tablename + " where isvalid=1 ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();

            string[] strSpl = IdNumber.Split('-');
            string poNumber = strSpl[2];
            if (Convert.ToInt32(poNumber) > 9999)
            {
                poNumber = poNumber.PadLeft(5, '0');
            }
            else if (Convert.ToInt32(poNumber) > 99999)
            {
                poNumber = poNumber.PadLeft(6, '0');
            }
            else if (Convert.ToInt32(poNumber) > 999999)
            {
                poNumber = poNumber.PadLeft(6, '0');
            }
            else
                poNumber = poNumber.PadLeft(4, '0');


            IdNumber = strSpl[0] + "-" + strSpl[1] + "-" + poNumber;

            return IdNumber;
        }

        public static string GetSystemGeneratedIDForPO(string tablename, string columnName, string prefix,
            string distinctValue, string po)
        {
            string IdNumber = "";

            // string Qry = "select '" + prefix + "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(distinct(" + columnName + ")),0)+1 as varchar) as ID from " + tablename + " where isvalid=1 ";
            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(max(cast(substring(" + columnName +
                         ",10,len(" + columnName + ")) as int))+1 as varchar) as ID from " + tablename +
                         " where isvalid=1 ";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();

            string[] strSpl = IdNumber.Split('-');
            string poNumber = strSpl[2];
            if (Convert.ToInt32(poNumber) > 9999)
            {
                poNumber = poNumber.PadLeft(5, '0');
            }
            else if (Convert.ToInt32(poNumber) > 99999)
            {
                poNumber = poNumber.PadLeft(6, '0');
            }
            else if (Convert.ToInt32(poNumber) > 999999)
            {
                poNumber = poNumber.PadLeft(6, '0');
            }
            else
                poNumber = poNumber.PadLeft(4, '0');


            IdNumber = strSpl[0] + "-" + strSpl[1] + "-" + poNumber;

            return IdNumber;
        }

        public static string GetSystemGeneratedLoginID(string tablename, string columnName, string prefix,
            string distinctValue, string po)
        {
            string IdNumber = "";

            string Qry = "select '" + prefix +
                         "'+'-'+cast(datepart(year,getdate()) as varchar)+'-'+cast(isnull(count(distinct(" + columnName +
                         ")),0)+1 as varchar) as ID from " + tablename + "";
            DataTable dtInfo = DbUtility.GetDataTable(Qry);
            IdNumber = dtInfo.Rows[0]["ID"].ToString();

            //string[] strSpl = IdNumber.Split('-');
            //string poNumber = strSpl[2];
            //if (Convert.ToInt32(poNumber) > 9999)
            //{
            //    poNumber = poNumber.PadLeft(5, '0');
            //}
            //else if (Convert.ToInt32(poNumber) > 99999)
            //{
            //    poNumber = poNumber.PadLeft(6, '0');
            //}
            //else if (Convert.ToInt32(poNumber) > 999999)
            //{
            //    poNumber = poNumber.PadLeft(6, '0');
            //}
            //else
            //    poNumber = poNumber.PadLeft(4, '0');


            // IdNumber = strSpl[0] + "-" + strSpl[1] + "-" + poNumber;

            return IdNumber;
        }


        public static string GetMaxVoucher(string prefix, int prefixNumber, int yearno)
        {
            string voucherNo = string.Empty;

            string Qry = "select COUNT(distinct(VoucherNo))+1 MaxVoucher from dbo.TransactionRecord where " +
                         " substring(VoucherNo,1," + prefixNumber + ")='" + prefix + "' AND DatePart(Year,TrDate)='" +
                         yearno + "'";

            DataTable dt = DbUtility.GetDataTable(Qry);

            if (dt.Rows.Count > 0)
            {
                voucherNo = prefix + "-" + dt.Rows[0]["MaxVoucher"].ToString().PadLeft(5, '0');

            }
            return voucherNo;
        }


        /// <summary>
        /// Get ItemSales Account for transaction.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static string GetItemSalesAccount(string ItemCode)
        {
            string SalesAccount = string.Empty;
            string Qry = " select SalesAccount from ItemInformation where ItemID='" + ItemCode + "'";
            DataTable dt = DbUtility.GetDataTable(Qry);

            if (dt.Rows.Count > 0)
            {
                SalesAccount = dt.Rows[0]["SalesAccount"].ToString();

            }
            return SalesAccount;

        }

        /// <summary>
        /// Partywise dues.
        /// </summary>
        /// <param name="PartyCode"></param>
        /// <param name="trDate"></param>
        /// <returns></returns>
        public static decimal GetPartyDues(string PartyCode, DateTime trDate)
        {
            decimal duesamount = 0.0M;
            string Qry = "select t.AccountNo,c.ContactName,c.ContactPerson,c.AreaName,c.BeatName,c.District,c.Phone," +
                         " SUM(isnull(t.debit,0))-SUM(isnull(t.credit,0)) as Dues from TransactionRecord t  join " +
                         " vwContactInfo c on t.AccountNo=c.ContactId and t.IsValid=1 and t.TrDate<='" +
                         trDate.ToString("MM/dd/yyyy") + "' " +
                         " where t.AccountNo in ( select ContactId from ContactInfo) and t.AccountNo='" + PartyCode +
                         "' group by t.AccountNo," +
                         " c.ContactName,c.ContactPerson, c.AreaName,c.BeatName,c.District,c.Phone order by c.ContactName";
            DataTable dt = DbUtility.GetDataTable(Qry);

            if (dt.Rows.Count > 0)
            {
                duesamount = Convert.ToDecimal(dt.Rows[0]["Dues"]);

            }
            return duesamount;

        }

        /// <summary>
        /// Get Item Purchase Account for transaction.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static string GetItemPurchaseAccount(string ItemCode)
        {
            string SalesAccount = string.Empty;
            string Qry = " select PurchaseAccount from ItemInformation where ItemID='" + ItemCode + "'";
            DataTable dt = DbUtility.GetDataTable(Qry);

            if (dt.Rows.Count > 0)
            {
                SalesAccount = dt.Rows[0]["PurchaseAccount"].ToString();

            }
            return SalesAccount;

        }


        public static string GetMaxReceiptNo(string receiptType)
        {
            string receiptNo = string.Empty;
            string Qry =
                "select isnull(MAX(cast(ReceiptNo as int))+1,1) MaxReceipt from TransactionRecord where SUBSTRING(VoucherNo,1,3)='" +
                receiptType + "'";
            DataTable dt = DbUtility.GetDataTable(Qry);

            if (dt.Rows.Count > 0)
            {
                receiptNo = dt.Rows[0]["MaxReceipt"].ToString();

            }
            return receiptNo;
        }


        public String changeNumericToWords(double numb)
        {
            String num = numb.ToString();
            return changeToWords(num, false);
        }

        public String changeCurrencyToWords(String numb)
        {
            return changeToWords(numb, true);
        }

        public String changeNumericToWords(String numb)
        {
            return changeToWords(numb, false);
        }

        public String changeCurrencyToWords(double numb)
        {
            return changeToWords(numb.ToString(), true);
        }

        //2
        private String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point"); // just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                        pointStr = translateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }

        //3
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false; //tests for 0XX
                bool isDone = false; //test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {
//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;
                    int pos = 0; //store digit grouping
                    String place = ""; //digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1: //ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2: //tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3: //hundreds' range
                            pos = (numDigits%3) + 1;
                            if (number.ToString().Substring(0, 1) == "0")
                            {
                                place = "";
                            }
                            else
                                place = " Hundred ";
                            break;
                        case 4: //thousands' range
                        case 5:
                            pos = (numDigits%4) + 1;
                            place = " Thousand ";
                            break;
                        case 6:
                        case 7: //Lac' range
                            pos = (numDigits%6) + 1;
                            place = " LAC ";
                            break;
                        case 8:
                        case 9:
                        case 10: //Core' range
                            pos = (numDigits%8) + 1;
                            place = " CORE ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place +
                               translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Forty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        //3
        private String translateCents(String cents)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }


        public static string getMonthName(string monthNumber)
        {
            string monthName = "";
            if (monthNumber == "1")
            {
                monthName = "January";
            }
            else if (monthNumber == "2")
            {
                monthName = "February";
            }
            else if (monthNumber == "3")
            {
                monthName = "March";
            }
            else if (monthNumber == "4")
            {
                monthName = "April";
            }
            else if (monthNumber == "5")
            {
                monthName = "May";
            }
            else if (monthNumber == "6")
            {
                monthName = "June";
            }
            else if (monthNumber == "7")
            {
                monthName = "July";

            }
            else if (monthNumber == "8")
            {
                monthName = "August";
            }
            else if (monthNumber == "9")
            {
                monthName = "September";
            }
            else if (monthNumber == "10")
            {
                monthName = "October";
            }
            else if (monthNumber == "11")
            {
                monthName = "November";
            }
            else if (monthNumber == "12")
            {
                monthName = "December";
            }

            return monthName;
            ;
        }

        /// <summary>
        ///  check stock validity
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="qty"></param>
        /// <param name="uom"></param>
        /// <returns></returns>
        public static decimal StockEntryQty(decimal qty, string uom)
        {
            decimal entryQty = 0.0M;
            string Qry = "select dbo.fnGetBaseQty('" + uom + "'," + qty + ") Total";
            DataTable dt = DbUtility.GetDataTable(Qry);
            if (dt.Rows.Count > 0)
                entryQty = Convert.ToDecimal(dt.Rows[0]["Total"]);
            return entryQty;
        }


        public static string StockItemBaseUOM(string ItemCode)
        {
            string Qry = "select UOM from InvItemInformation  where ItemCode='" + ItemCode + "'";

            DataTable dtbaseQty = DbUtility.GetDataTable(Qry);
            string UOM = dtbaseQty.Rows[0]["UOM"].ToString();
            return UOM;
        }

        /// <summary>
        ///  check stock validity
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="qty"></param>
        /// <param name="uom"></param>
        /// <returns></returns>
        public static decimal StationaryStockItemSummery(string ItemCode)
        {

            decimal stockQty = 0.0M;

            DataTable dtbaseQty = new DataTable();

            string Qry = @"select iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity)) as Quantity,
                     isnull(sum(dbo.fnGetBaseQty(ds.UOM,ds.Qty)),0) DisvQty,
                     sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity))-isnull(sum(dbo.fnGetBaseQty(ds.UOM,ds.Qty)),0) Inhand, 
                     dbo.fnGetBaseUOM(iv.UOM) UOM  from InventoryStore iv
	                    left join vwItemInformation i on iv.ItemCode=i.ItemCode 
	                    left join DisbursementInfo ds on iv.ItemCode=ds.ItemCode and ds.IsValid=1
	                    where iv.IsValid=1 and i.AssetTypeName='Others'
	                    and iv.ItemCode='" + ItemCode + "'" +
                         " group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM)";

            stockQty = Convert.ToDecimal(dtbaseQty.Rows[0]["Quantity"]);

            return stockQty;
        }

        /// <summary>
        ///  check stock validity
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="qty"></param>
        /// <param name="uom"></param>
        /// <returns></returns>
        public static decimal AssetStockItemSummery(string ItemCode)
        {

            decimal stockQty = 0.0M;

            DataTable dtbaseQty = new DataTable();

            string Qry = @"select iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity)) as Quantity,
                     isnull(sum(dbo.fnGetBaseQty(ds.UOM,ds.Qty)),0) DisvQty,
                     sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity))-isnull(sum(dbo.fnGetBaseQty(ds.UOM,ds.Qty)),0) Inhand, 
                     dbo.fnGetBaseUOM(iv.UOM) UOM  from InventoryStore iv
	                    left join vwItemInformation i on iv.ItemCode=i.ItemCode 
	                    left join DisbursementInfo ds on iv.ItemCode=ds.ItemCode and ds.IsValid=1
	                    where iv.IsValid=1 and i.AssetTypeName='Others'
	                    and iv.ItemCode='" + ItemCode + "'" +
                         " group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM)";

            stockQty = Convert.ToDecimal(dtbaseQty.Rows[0]["Quantity"]);

            return stockQty;
        }


        public static DataTable StockSummeryExisting()
        {
            DataTable dtInfo = new DataTable();
            string Qry =
                @"SELECT     a.ItemCode, a.ItemName, a.ItemCategory AS [ItemCategoryCode], a.ItemCategoryName[Item Category], a.Quantity[Total Received], isnull(b.Quantity, 0) 
                        AS [Total Issued], a.Quantity - isnull(b.Quantity, 0) AS [Total Balance Qty], a.Quantity - isnull(b.Quantity, 0) AS Inhand, a.UOM
                        FROM         (SELECT     i.[Asset Group ID], i.[Asset Group Name], i.ItemCategory, i.ItemCategoryName, iv.ItemCode, i.ItemName, sum(dbo.fnGetBaseQty(iv.UOM, iv.Quantity)) 
                          Quantity, dbo.fnGetBaseUOM(iv.UOM) UOM
                        FROM          InventoryStore iv LEFT JOIN
                          vwItemInformation i ON iv.ItemCode = i.ItemCode
                        WHERE      i.Inventoriable = 0 AND iv.IsValid = 1 and RECEIVETYPE='EXISTING'
                        GROUP BY iv.ItemCode, i.ItemName, dbo.fnGetBaseUOM(iv.UOM), i.[Asset Group ID], i.[Asset Group Name], i.ItemCategory, i.ItemCategoryName
                        ) a LEFT JOIN
                        (SELECT     i.[Asset Group ID], i.[Asset Group Name], i.ItemCategory, i.ItemCategoryName, iv.ItemCode, i.ItemName, sum(dbo.fnGetBaseQty(iv.UOM, iv.Qty)) Quantity, 
                               dbo.fnGetBaseUOM(iv.UOM) UOM
                        FROM          DisbursementInfo iv LEFT JOIN
                               vwItemInformation i ON iv.ItemCode = i.ItemCode
                        WHERE      i.Inventoriable = 0 AND iv.IsValid = 1 and  RequisitionID='N/A'
                        GROUP BY iv.ItemCode, i.ItemCategory, i.ItemName, dbo.fnGetBaseUOM(iv.UOM), i.[Asset Group ID], i.[Asset Group Name], i.ItemCategory, i.ItemCategoryName) 
                        b ON a.ItemCode = b.ItemCode
                        UNION ALL
                        SELECT     ItemCode, ItemName, x.[ItemCategoryCode] AS [ItemCategoryCode], [Item Category], [Total Received], [Total Issued], 
                        x.[Total Received] - x.[Total Issued] AS [Total Balance Qty], x.[Total Received] - x.[Total Issued] AS Inhand, x.UOM
                        FROM         (SELECT     iv.ItemCode, i.ItemName, i.ItemCategory AS [ItemCategoryCode], i.ItemCategoryName[Item Category], sum(dbo.fnGetBaseQty(iv.UOM, iv.Quantity)) 
                          [Total Received], isnull(sum(dbo.fnGetBaseQty(d .UOM, d .Qty)), 0) [Total Issued], dbo.fnGetBaseUOM(iv.UOM) UOM
                        FROM          InventoryStore iv LEFT JOIN
                          vwItemInformation i ON iv.ItemCode = i.ItemCode LEFT JOIN
                          DisbursementInfo d ON iv.ItemCode = d .ItemCode AND iv.AssetNo = d .AssetNo AND 
                          d .UsingStatus IN ('IN USE', 'OBSOLETE', 'AUCTIONED', 'WRITE OFF') and d.RequisitionID='N/A'
                        WHERE      i.Inventoriable = 1 and iv.RECEIVETYPE='EXISTING'
                        GROUP BY iv.ItemCode, i.ItemName, i.ItemCategory, i.ItemCategoryName, dbo.fnGetBaseQty(iv.UOM, iv.Quantity), dbo.fnGetBaseUOM(iv.UOM)) x";
            // string Qry = " select Date,ItemCode,ItemName,Description, Supplier,Received,Disburse,Balance,UOM,IssueTo from (  " +
            //" select iv.InventoryDate Date,iv.ItemCode,i.ItemName,iv.ItemPurchaseDesc Description,v.VendorName Supplier, " +
            //" dbo.fnGetBaseQty(iv.UOM,iv.Quantity) as Received,0 as Disburse,0 as Balance,  dbo.fnGetBaseUOM(iv.UOM) as UOM,'' IssueTo, 0 as  " +
            //" Store from InventoryStore iv   left join vwItemInformation i on iv.ItemCode=i.ItemCode " +
            //" left join VendorInformation v on iv.Supplier=v.VendorId  where  IsValid=1   " +
            //" union all   " +
            //" select DisbDate Date,d.ItemCode,i.ItemName, '' Description,'' Supplier,0 as Received,dbo.fnGetBaseQty(d.UOM,d.Qty) as Disburse,   " +
            //" 0 as Balance,dbo.fnGetBaseUOM(d.UOM) as UOM, " +
            //" case ForRoomOrIndv when 'INDIVIDUAL' then dbo.fnGetRoomEmployeeName(EmployeeID,'INDIVIDUAL')  " +
            //" when 'ROOM' then   dbo.fnGetRoomEmployeeName(RoomID,'ROOM')  else RoomID end IssueTo,1 as Store  " +
            //" from DisbursementInfo d   left join vwItemInformation i on d.ItemCode=i.ItemCode   " +
            //" where  isvalid=1 ) x order by Date,Store";
            dtInfo = DbUtility.GetDataTable(Qry);
            return dtInfo;
        }

        public static DataTable StockSummery()
        {
            DataTable dtInfo = new DataTable();
            string Qry = @"select * from vwstocksummery";
//            string Qry = @"select a.AssetType,a.AssetTypeName,a.ItemCategory,a.ItemCategoryName,a.ItemCode,a.ItemName,a.Quantity,isnull(b.Quantity,0) as DisvQty, 
//                            a.Quantity-isnull(b.Quantity,0) as Inhand,a.UOM from (
//                            select i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName,iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity)) Quantity,
//                            dbo.fnGetBaseUOM(iv.UOM) UOM from InventoryStore  iv
//                            left  join vwItemInformation i on iv.ItemCode=i.ItemCode
//                            where i.AssetTypeName='Others' and iv.IsValid=1 group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM),
//                            i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName
//                            ) a left join (
//                            select i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName,iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Qty)) Quantity,
//                            dbo.fnGetBaseUOM(iv.UOM) UOM from DisbursementInfo  iv
//                            left  join vwItemInformation i on iv.ItemCode=i.ItemCode
//                            where i.AssetTypeName='Others' and iv.IsValid=1 group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM),
//                            i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName
//                            ) b on a.ItemCode=b.ItemCode
//                        union all
//                        select a.AssetType,a.AssetTypeName,a.ItemCategory,a.ItemCategoryName,a.ItemCode,a.ItemName,a.Quantity,isnull(b.Quantity,0) as DisvQty, 
//                        a.Quantity-isnull(b.Quantity,0) as Inhand,a.UOM from (
//                        select i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName,iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Quantity)) Quantity,
//                        dbo.fnGetBaseUOM(iv.UOM) UOM from InventoryStore  iv
//                        left  join vwItemInformation i on iv.ItemCode=i.ItemCode
//                        where i.AssetTypeName!='Others' and iv.IsValid=1 group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM),
//                        i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName
//                        ) a left join (
//                        select i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName,iv.ItemCode,i.ItemName,sum(dbo.fnGetBaseQty(iv.UOM,iv.Qty)) Quantity,
//                        dbo.fnGetBaseUOM(iv.UOM) UOM from DisbursementInfo  iv
//                        left  join vwItemInformation i on iv.ItemCode=i.ItemCode and iv.IsValid=1 and iv.UsingStatus!='FREE'
//                        where i.AssetTypeName!='Others' and iv.IsValid=1 group by iv.ItemCode,i.ItemName,dbo.fnGetBaseUOM(iv.UOM),
//                        i.AssetType,i.AssetTypeName,i.ItemCategory,i.ItemCategoryName
//                        ) b on a.ItemCode=b.ItemCode";
            dtInfo = DbUtility.GetDataTable(Qry);
            return dtInfo;
        }

        /// <summary>
        /// get login user employeecode.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetUserEmployeeCode(string username)
        {
            string empID = "";
            string qry = "select EmployeeID from USERINFO where USERNAME='" + username + "'";
            DataTable dtEmp = DbUtility.GetDataTable(qry);
            if (dtEmp.Rows.Count > 0)
            {
                empID = dtEmp.Rows[0]["EmployeeID"].ToString();
            }
            return empID;
        }

        public static string GetLoginPCMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }

        public static decimal GetDollerRate(DateTime dtp, string Cur)
        {
            decimal rate = 0.0M;

            string Qry = "select isnull(Rate,0) Rate from dollerrate where   CUR='" + Cur + "' and " +
                         " SL=(select MAX(SL) from  dollerrate where RateDate<='" + dtp.ToString("MM/dd/yyyy") +
                         "' and CUR='" + Cur + "') ";

            DataTable dt = DbUtility.GetDataTable(Qry);
            if (dt.Rows.Count > 0)
                rate = Convert.ToDecimal(dt.Rows[0]["Rate"]);
            else
                rate = 0.0M;
            return rate;
        }
    }
}

