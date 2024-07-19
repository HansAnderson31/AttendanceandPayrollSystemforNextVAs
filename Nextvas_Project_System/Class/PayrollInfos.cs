using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Nextvas_Project_System
{
    public static class PayrollInfos
    {
        //public static string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        public static string conn = "server=localhost; user=root; password=;database=dbconn;";

        public static void NewPayroll(string emp_id)
        {
            var infos = EmployeeInfos.GetAllInfo(emp_id);
            try
            {
                //string queryRegister = $"insert into payroll_tbl (emp_id, total_hr, total_ot, total_sal, total_tax, computed_sal, status) " +
                //$"values ('{emp_id}', '0', '0', '0', '0', '0', 'unclaimed')";
                string queryRegister = $"INSERT INTO payroll_tbl(emp_id, total_hr, total_ot, total_sal, total_tax, computed_sal) values('{emp_id}', '0', '0', '0', '0', '0')";

                using (MySqlConnection connection = new MySqlConnection(conn))
                {
                    MySqlCommand command = new MySqlCommand(queryRegister, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
        public static void ClaimedPayroll(string emp_id)
        {
            var time_now = DateTime.Parse(DateTime.Now.ToString("g"));
            string queryRegister = $"update payslip_tbl " +
                $"set status='claimed', date_claimed = '{time_now}'" +
                $"where emp_id ='{emp_id}'";


            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }

        }


        public static void UpdatePayroll(string emp_id)
        {
            double computedHr = Attendance.ComputeLatestTime(emp_id).TotalHours;
            double computedOTHr = Attendance.ComputeLatestOTTime(emp_id).TotalHours;

            double newHour = computedHr - computedOTHr;

            UpdateTotal_Hr(emp_id, newHour);
            UpdateTotal_OTHr(emp_id, computedOTHr);
            UpdateSalary(emp_id, newHour, computedOTHr);
        }
        public static void UpdateTotal_Hr(string emp_id, double timeHr)
        {
            var payrollInfo = GetAllPayrollInfo(emp_id);

            var currentHR = Convert.ToDouble(payrollInfo["total_hr"]);

            double newHR = currentHR + timeHr;


            string queryRegister = $"update payroll_tbl set total_hr='{newHR}' " +
                $"where emp_id ='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }
        public static void UpdateTotal_OTHr(string emp_id, double timeOT)
        {
            var payrollInfo = GetAllPayrollInfo(emp_id);

            var currentOT = Convert.ToInt32(payrollInfo["total_ot"]);
            //var addOTHour = (int)Math.Round(Attendance.ComputeLatestOTTime(emp_id).TotalHours);
            //var addOTHour = Attendance.ComputeLatestOTTime(emp_id).Hours;

            double newOT = currentOT + timeOT;

            string queryRegister = $"update payroll_tbl set total_ot='{newOT}' " +
                $"where emp_id ='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }
        public static void UpdateSalary(string emp_id, double timeHr, double timeOT)
        {
            var empInfo = EmployeeInfos.GetAllInfo(emp_id);
            var payrollInfo = GetAllPayrollInfo(emp_id);

            var newCurrentSal = Math.Round(Convert.ToDouble(payrollInfo["total_sal"]), 2);

            var currentRate = Convert.ToDouble(empInfo["salary_rate"]);
            var currentOTRate = Convert.ToDouble(empInfo["salary_ot_rate"]);

            var addSal = (timeHr * currentRate) + (timeOT * currentOTRate);

            newCurrentSal += addSal;

            var taxDeduct = newCurrentSal * 0.05;

            var computedSal = newCurrentSal - taxDeduct;


            string queryRegister = $"update payroll_tbl " +
                $"set total_sal='{newCurrentSal}', total_tax='{taxDeduct}', computed_sal='{computedSal}'" +
                $"where emp_id ='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }


        public static Dictionary<string, string> GetAllPayrollInfo(string emp_id)
        {
            Dictionary<string, string> dataInfo = new Dictionary<string, string>();

            //string queryRegister = $"select * from payroll_tbl " +
            //    $"where emp_id='{emp_id}' and status='unclaim'";
            string queryRegister = $"SELECT p.*, e.f_name, e.l_name, e.salary_rate, e.salary_ot_rate FROM `payroll_tbl` p LEFT JOIN employee_info_tbl e ON p.emp_id=e.emp_id " +
                $"where p.emp_id='{emp_id}'";

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
                    dataInfo.Add("total_hr", row["total_hr"].ToString());
                    dataInfo.Add("total_ot", row["total_ot"].ToString());
                    dataInfo.Add("salary_rate", row["salary_rate"].ToString());
                    dataInfo.Add("salary_ot_rate", row["salary_ot_rate"].ToString());
                    dataInfo.Add("total_sal", row["total_sal"].ToString());
                    dataInfo.Add("total_tax", row["total_tax"].ToString());
                    dataInfo.Add("computed_sal", row["computed_sal"].ToString());
                }
            }

            return dataInfo;
        }

    }
}