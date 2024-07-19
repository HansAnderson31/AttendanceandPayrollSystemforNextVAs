using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Nextvas_Project_System
{
    public static class Access
    {
        //public static string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        public static string conn = "server=localhost; user=root;database=dbconn;password=";

        public static bool CheckAccount(string inputEmpId, string inputPassword)
        {
            //Employee ID doesn't exist
            if (!EmployeeInfos.EmployeeIDExist(inputEmpId))
            {
                return false;
            }

            //Employee ID exist
            var accessInfo = GetAllAccessInfo(inputEmpId);

            try
            {
                if (accessInfo["pass"] == inputPassword)
                {
                    //Correct password
                    return true;
                }
                else
                {
                    //Incorrect password
                    return false;
                }
            }
            catch{ return false; }
        }
        public static void InsertAccess(string newEmpID)
        {
            string queryRegister = $"insert into accessibility_tbl values('{newEmpID}', 'changeme')";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }
        public static void UpdatePassword(string emp_id, string newPassword)
        {
            string queryRegister = $"update accessibility_tbl set pass='{newPassword}' " +
                $"where emp_id ='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }

        public static Dictionary<string, string> GetAllAccessInfo(string emp_id)
        {
            Dictionary<string, string> dataInfo = new Dictionary<string, string>();

            string queryRegister = $"SELECT a.*, e.accessibility FROM `accessibility_tbl` a LEFT JOIN employee_info_tbl e ON a.emp_id=e.emp_id " +
                $"where a.emp_id='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                //Run the SQL Query
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    dataInfo.Add("emp_id", row["emp_id"].ToString());
                    dataInfo.Add("pass", row["pass"].ToString());
                    dataInfo.Add("accessibility", row["accessibility"].ToString());
                }
            }

            return dataInfo;
        }
    }
}