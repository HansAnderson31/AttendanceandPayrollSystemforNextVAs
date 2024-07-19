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
    public static class EmployeeInfos
    {
        private static string EmployeeID = "";
        //public static string conn = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        public static string conn = "server=localhost; user=root; password=;database=dbconn;";

        public static string GenerateEmployeeID()
        {
            /* Employee ID format
             * Year + Month + Day + 4 random digits
             * 
             * Example:
             * 2023 0216 5486
             */

            string final_ID = "";

            do
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString("d2");
                string day = DateTime.Now.Day.ToString("d2");
                string rand_num = new Random().Next(0, 9999).ToString("d4");
                string generated_ID = $"{year}{month}{day}{rand_num}";

                final_ID = generated_ID;
            } while (EmployeeIDExist(final_ID));

            EmployeeID = final_ID;
            return final_ID;
        }
        public static byte[] GenerateQRCode(string filePath)
        {
            //Generate Qr code
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(EmployeeID, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);

            Bitmap bitmap = code.GetGraphic(20); //QrCode and size

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    byte[] qrpic = memory.ToArray();
                    memory.Position = 0;
                    fs.Write(qrpic, 0, qrpic.Length); //QRCode Destination

                    //Save QRCode to Database
                    return qrpic;
                }
            }
        }
        public static byte[] SaveProfilePic(string filePath)
        {
            try
            {
                Image img = Image.FromFile(filePath);

                using (MemoryStream memory = new MemoryStream())
                {
                    img.Save(memory, ImageFormat.Jpeg);
                    byte[] imgByte = memory.ToArray();
                    memory.Position = 0;

                    //Save QRCode to Database
                    return imgByte;
                }
            }
            catch { return null; }
            
        }
        public static void InsertEmployee(string id, string fname, string lname, string mname, string sex, string bday, string home_add, string email_add, string cont_num, byte[] profile_pic, byte[] qrCode_Pic, string accessibility, string t_leader,
            string shift, string time_in, string time_out, string salaryRate)
        {
            double overtimeRate = Int32.Parse(salaryRate)*.25;
            string registered_date = DateTime.Now.ToString("MMM dd yyyy");

            string queryRegister = $"insert into employee_info_tbl values ('{id}', '{fname}', '{lname}', '{mname}', '{sex}', '{bday}', " +
                $" '{home_add}', '{email_add}', '{cont_num}', @profile_pic, @qr_code, '{accessibility}', '{t_leader}', '{shift}', '{registered_date}' ,'{time_in}', '{time_out}', '{salaryRate}', '{overtimeRate}')";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Parameters.AddWithValue("@qr_code", qrCode_Pic);
                command.Parameters.AddWithValue("@profile_pic", profile_pic);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
        public static bool EmployeeIDExist(string emp_id)
        {
            //Verify if id already exists.
            string id_Exist = "";
            string queryRegister = $"select emp_id from employee_info_tbl where emp_id='{emp_id}'";

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
                    return true;
                }
            }
        }

        public static void UpdateEmployee(string emp_id, string fname, string lname, string mname, string sex, string bday, string home_add, string email_add, string cont_num, string accessibility, string t_leader, string shift, string time_in, string time_out, string salaryRate, string salaryOTRate)
        {
            string queryRegister = $"update employee_info_tbl " +
                $"set f_name='{fname}', l_name='{lname}', m_name='{mname}', " +
                $"sex='{sex}', bday='{bday}'," +
                $"home_add='{home_add}', email_add='{email_add}', cont_num='{cont_num}', " +
                $"accessibility='{accessibility}', t_leader='{t_leader}', shift='{shift}', time_in_sched='{time_in}', " +
                $"time_out_sched='{time_out}', salary_rate='{salaryRate}', salary_ot_rate='{salaryOTRate}'" +
                $"where emp_id ='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command1 = new MySqlCommand(queryRegister, connection);
                command1.Connection.Open();
                command1.ExecuteNonQuery();
                command1.Connection.Close();
            }
        }

        public static void DeleteAccount(string emp_id)
        {
            string queryRegister = $"delete from employee_info_tbl where emp_id='{emp_id}'";
            string queryRegister2 = $"delete from time_sheet_tbl where emp_id='{emp_id}'";
            string queryRegister3 = $"delete from accessibility_tbl where emp_id='{emp_id}'";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                MySqlCommand command2 = new MySqlCommand(queryRegister2, connection);
                MySqlCommand command3 = new MySqlCommand(queryRegister3, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                command2.Connection.Open();
                command2.ExecuteNonQuery();
                command2.Connection.Close();
                command3.Connection.Open();
                command3.ExecuteNonQuery();
                command3.Connection.Close();
            }
        }

        public static string GetProfilePic(string emp_id)
        {
            string profilePicString = "";

            string queryRegister = $"select profile_pic from employee_info_tbl where emp_id={emp_id}";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Connection.Open();

                byte[] img = ((byte[])command.ExecuteScalar());
                string strBase64 = Convert.ToBase64String(img);

                profilePicString = "data:Image/png;base64," + strBase64;
            }
            return profilePicString;
        }
        public static string GetQRCode(string emp_id)
        {
            string qr_code_string = "";

            string queryRegister = $"select qr_code from employee_info_tbl where emp_id={emp_id}";

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                MySqlCommand command = new MySqlCommand(queryRegister, connection);
                command.Connection.Open();
                
                byte[] img = ((byte[])command.ExecuteScalar());
                string strBase64 = Convert.ToBase64String(img);

                qr_code_string = "data:Image/png;base64," + strBase64; 
            }
            return qr_code_string;
        }
        public static Dictionary<string, string> GetAllInfo(string emp_id)
        {
            Dictionary<string, string> dataInfo = new Dictionary<string, string>();

            string queryRegister = $"select * from employee_info_tbl where emp_id='{emp_id}'";
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
                    dataInfo.Add("m_name", row["m_name"].ToString());
                    dataInfo.Add("sex", row["sex"].ToString());
                    dataInfo.Add("bday", row["bday"].ToString());
                    dataInfo.Add("home_add", row["home_add"].ToString());
                    dataInfo.Add("email_add", row["email_add"].ToString());
                    dataInfo.Add("cont_num", row["cont_num"].ToString());
                    dataInfo.Add("accessibility", row["accessibility"].ToString());
                    dataInfo.Add("t_leader", row["t_leader"].ToString());
                    dataInfo.Add("shift", row["shift"].ToString());
                    dataInfo.Add("employed_date", row["employed_date"].ToString());
                    dataInfo.Add("time_in_sched", row["time_in_sched"].ToString());
                    dataInfo.Add("time_out_sched", row["time_out_sched"].ToString());
                    dataInfo.Add("salary_rate", row["salary_rate"].ToString());
                    dataInfo.Add("salary_ot_rate", row["salary_ot_rate"].ToString());
                    dataInfo.Add("profile_pic", GetProfilePic(emp_id));
                    dataInfo.Add("qr_code", GetQRCode(emp_id));
                }
            }

            return dataInfo;
        }
    }
}