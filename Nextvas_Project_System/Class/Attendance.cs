using MySql.Data.MySqlClient;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;


namespace Nextvas_Project_System
{
    public static class Attendance
    {
        //public static string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        public static string conn = "server=localhost; user=root; password=;database=dbconn;";

        public static void RegisterAttendance(string emp_id, string scanBy)
        {
            var infos = EmployeeInfos.GetAllInfo(emp_id);

            string queryRegister = $"insert into time_sheet_tbl (emp_id, attend_status, late) values ('{emp_id}', 'new', 'hello')";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
        public static void UpdateTimeIn(string emp_id)
        {

            string time1 = DateTime.Now.ToString("d");
            string time2 = DateTime.Now.ToString("HH:mm");
            string time_in = time1 + " " + time2;
            string late = "";
            string absent = "0";

            var time_now = DateTime.Parse(DateTime.Now.ToString("g"));
            var getTimeinSched = DateTime.Parse(EmployeeInfos.GetAllInfo(emp_id)["time_in_sched"]).ToString("g");

            var emp_timein_sched = DateTime.Parse(getTimeinSched);

            if(time_now > emp_timein_sched)
            {
                late = "1";
            }
            else
            {
                late = "0";
            }
            string queryRegister = $"update time_sheet_tbl set time_in='{time_in}'" +
                $"where emp_id ='{emp_id}' and attend_status = 'new'";

            string queryRegister2 = $"update time_sheet_tbl set attend_status='in', late = '{late}', absent ='{absent}'" +
                $"where emp_id ='{emp_id}' and time_in='{time_in}'";


            try
            {
                using (MySqlConnection connection = new MySqlConnection(conn))
                {
                    MySqlCommand command = new MySqlCommand(queryRegister, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    MySqlCommand command1 = new MySqlCommand(queryRegister2, connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public static void UpdateAbsent(string emp_id)
        {
            string time1 = DateTime.Now.ToString("d");
            string time2 = DateTime.Now.ToString("HH:mm");
            string time_now = time1 + " " + time2;

            string queryRegister = $"insert into time_sheet_tbl (emp_id, time_in, time_out, attend_status,late, absent) " +
                $"values ('{emp_id}', '{time_now}', '{time_now}', 'absent', '0', '1')";


            try
            {
                using (MySqlConnection connection = new MySqlConnection(conn))
                {
                    MySqlCommand command = new MySqlCommand(queryRegister, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void UpdateTimeOut(string emp_id)
        {
            string time1 = DateTime.Now.ToString("d");
            string time2 = DateTime.Now.ToString("HH:mm");
            string time_out = time1 + " " + time2;

            string queryRegister = $"update time_sheet_tbl set time_out='{time_out}' " +
                $"where emp_id ='{emp_id}' and attend_status='in'";

            string queryRegister2 = $"update time_sheet_tbl set attend_status='out' " +
                $"where emp_id ='{emp_id}' and time_out='{time_out}'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conn))
                {
                    MySqlCommand command = new MySqlCommand(queryRegister, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    MySqlCommand command1 = new MySqlCommand(queryRegister2, connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }


        public static TimeSpan ComputeLatestTime(string emp_id)
        {
            var info = GetAllLatestAttendanceInfo(emp_id);

            DateTime ti = DateTime.Parse(info["time_in"]);
            DateTime to = DateTime.Parse(info["time_out"]);

            return to.Subtract(ti);
        }
        public static TimeSpan ComputeLatestOTTime(string emp_id)
        {
            //string time_in = DateTime.Now.ToString("g");
            //DateTime time = DateTime.Parse(time_in);
            //var time_now = Convert.ToDateTime(time.ToString("MM/dd/yyyy HH:mm tt"));

            var time_now = DateTime.Parse(DateTime.Now.ToString("g"));
            var getTimeoutSched = DateTime.Parse(EmployeeInfos.GetAllInfo(emp_id)["time_out_sched"]).ToString("g");

            var emp_timeout_sched = DateTime.Parse(getTimeoutSched);
            var emp_timein = DateTime.Parse(GetAllLatestAttendanceInfo(emp_id)["time_in"]);
            var emp_timeout = DateTime.Parse(GetAllLatestAttendanceInfo(emp_id)["time_out"]);

            if ((time_now >= emp_timeout_sched) && (emp_timein < emp_timeout_sched))
            {
                //overtime
                //var computeOTTime = TimeSpan.FromHours(1);
                var computeOTTime = emp_timeout.Subtract(emp_timeout_sched);
                return computeOTTime;
            }
            else
            {
                //not yet overtime
                return TimeSpan.Zero;
            }
        }


        public static bool IsEmployeeTimedIn(string emp_id)
        {
            //Verify if id already exists.
            string id_Exist = "";
            string queryRegister = $"select emp_id from time_sheet_tbl " +
                $"where emp_id='{emp_id}' and attend_status='in'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                //Run the SQL Query
                try
                {
                    MySqlCommand command = new MySqlCommand(queryRegister, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id_Exist = reader.GetString(0);
                    }
                    reader.Close();

                    return !String.IsNullOrEmpty(id_Exist);
                }
                catch
                {
                    return false;
                }
            }
        }
        public static Dictionary<string, string> GetAllLatestAttendanceInfo(string emp_id)
        {
            Dictionary<string, string> dataInfo = new Dictionary<string, string>();

            string queryRegister = $"SELECT t.*, e.f_name, e.l_name FROM `time_sheet_tbl` t LEFT JOIN employee_info_tbl e ON t.emp_id = e.emp_id " +
                $"WHERE ('{emp_id}', time_in) IN (SELECT emp_id, MAX(time_in) FROM time_sheet_tbl GROUP BY emp_id);";

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
                    dataInfo.Add("f_name", row["f_name"].ToString());
                    dataInfo.Add("l_name", row["l_name"].ToString());
                    dataInfo.Add("time_in", row["time_in"].ToString());
                    dataInfo.Add("time_out", row["time_out"].ToString());
                    dataInfo.Add("attend_status", row["attend_status"].ToString());
                }
            }

            return dataInfo;
        }


    }
}