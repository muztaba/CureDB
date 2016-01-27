using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace Pharma.Utility
{
    class ConfigurationUtility
    {
         public static string GetConnectionString()
        {
            //  string branchHeading = ConfigurationManager.AppSettings["appTitle"].ToString();
            string strConString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;
            return strConString;
        }

        /// <summary>
        /// solution name
        /// </summary>
        /// <returns></returns>
        public static string GetSolutionName()
        {
            string solutionname = ConfigurationManager.AppSettings["solutionname"].ToString();
            return solutionname;
        }
        /// <summary>
        /// get company name
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyName()
        {
            string companyname = ConfigurationManager.AppSettings["companyname"].ToString();
            return companyname;
        }


        public static string GetApplicationHeading()
        {
            string branchHeading = ConfigurationManager.AppSettings["appTitle"].ToString();
            return branchHeading;
        }

        /// <summary>
        /// Return application current date
        /// </summary>
        /// <returns>Current date</returns>
        public static DateTime GetApplicationDate()
        {
            string strKey = "CURRENT_DATE";
            string keyValue = ConfigurationUtility.GetConfigurationValue(strKey);
            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy";
            DateTime currDate = Convert.ToDateTime(keyValue, dtf);
            return currDate;
        }

        /// <summary>
        /// Get Maximum Transaction Date/
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMaxTrDate()
        {
            try
            {
                string strQry = "select max(trdate) as TrDate from transactionrecord where isvalid=1";
                DataTable dt = DbUtility.GetDataTable(strQry);
                DateTime dtp = Convert.ToDateTime(dt.Rows[0]["TrDate"]);
                return dtp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return current branch code from configuration
        /// </summary>
        /// <returns>Current branch code</returns>
        public static string GetCurrentBranchCode()
        {
            string strKey = "CURRENT_BRANCH_CODE";
            string keyValue = ConfigurationUtility.GetConfigurationValue(strKey);
            return keyValue;
        }
        /// <summary>
        /// Return application configuration value with the specified key
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <returns>Configuration value</returns>
        public static string GetConfigurationValue(string key)
        {
            string strSQL = "select appvalue from app_configuration where appkey='" + key.Trim() + "'";
            SqlConnection con = null;
            SqlCommand cmd = null;
            object value = null;
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
                throw new ApplicationException("No entry found in configuration for key " + key + "");
            }

            return value.ToString();

        }
        /// <summary>
        /// Return sequencer value and update current value
        /// </summary>
        /// <param name="sequencerName"></param>
        /// <returns></returns>
        public string getSequencerValue(string sequencerName)
        {
            string strSQL = "select seq_value from app_sequencer where seq_name='" + sequencerName.Trim() + "'";
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

        public static void UpdateConfigurationValue(string key, string value)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = DbUtility.GetSqlConnection();
                con.Open();

                string strSQL = " update app_configuration set appvalue='" + value + "' where appkey='" + key + "'";

                cmd = new SqlCommand(strSQL, con);
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
            finally
            {
                con.Close();
            }
        }

    }
    }


