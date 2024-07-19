using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using MySql.Data.MySqlClient;
using IronBarCode;

namespace Nextvas_Project_System
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InsertDDL_Data();
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            password_area.Visible = false;


        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            RangeValidator1.MinimumValue = DateTime.Today.AddDays(-25550).ToString("dd-MM-yyyy");
            RangeValidator1.MaximumValue = DateTime.Now.Date.AddDays(-6574).ToString("dd-MM-yyyy");
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            //Get info

            string fname = fname_TextBox.Text;
            string lname = lname_TextBox.Text;
            string mname = mname_TextBox.Text;
            string sex = gender_TextBox.SelectedValue;
            string bday = bday_TextBox.Text;
            string home_add = home_add_Textbox.Text;
            string email_add = email_add_Textbox.Text;
            string cont_num = cont_num_Textbox.Text;
            string accessibility = accessibility_drpbox.SelectedValue;
            string t_leader = team_drpbox.SelectedValue;
            string shift = shift_dropbox.SelectedValue;
            string time_in_sched = time_in_TextBox.Text;
            string time_out_sched = time_out_TextBox.Text;
            string salaryRate = salary_Textbox.Text;


            //Create a folder to place generated QR code
            var folder = Server.MapPath(@"\App_Data\GeneratedQRcodeImage");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string qrCodePath = Server.MapPath(@"\App_Data\GeneratedQRcodeImage\QRCode.png");

            string profilePicPath = "";

            try
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                    //fileUpload.PostedFile.SaveAs(Server.MapPath("~/Images/" + fileName));
                    //profilePicPath = Server.MapPath("~/Images/" + fileName);
                    fileUpload.PostedFile.SaveAs(Server.MapPath("~/App_Data/" + fileName));
                    profilePicPath = Server.MapPath("~/App_Data/" + fileName);
                }

                var generateID = EmployeeInfos.GenerateEmployeeID();
                //Save Employee Information
                EmployeeInfos.InsertEmployee(generateID, fname, lname, mname, sex, bday, home_add,
                    email_add, cont_num, EmployeeInfos.SaveProfilePic(profilePicPath), EmployeeInfos.GenerateQRCode(qrCodePath),
                    accessibility, t_leader, shift, time_in_sched, time_out_sched, salaryRate);

                //Save Accessibility
                if (accessibility_drpbox.SelectedValue != "Employee")
                {
                    Access.InsertAccess(generateID);
                }

                PayrollInfos.NewPayroll(generateID);

                Response.Write("<script>alert('Account is successfully created')</script>");
                Response.Redirect(Request.Url.AbsoluteUri);

            }
            catch (Exception err)
            {
                //Response.Write("<script>alert('Save Data Unsuccessful')</script>");
                //Response.Write(err.Message);
            }

        }

        protected void clear_btn_Click(object sender, EventArgs e)
        {
            //Clear input fields
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        public void InsertDDL_Data()
        {

            var connectionString = "server=localhost; user=root;database=dbconn;password=";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT f_name, l_name FROM employee_info_tbl WHERE accessibility = 'Team Leader' ";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            //Get values from database
                            string val_f_name = reader.GetString("f_name");
                            string val_l_name = reader.GetString("l_name");
                            string tl_name = val_f_name + " " + val_l_name;
                            team_drpbox.Items.Add(tl_name);
                        }
                    }
                }
            }
        }

        protected void accessibility_drpbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            password_area.Visible = accessibility_drpbox.SelectedValue == "Error";

        }

        protected void shift_dropbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shift_dropbox.SelectedValue == "Openers")
            {
                time_in_TextBox.Text = DateTime.Parse("7:00 pm").ToString("HH\\:mm");
                time_out_TextBox.Text = DateTime.Parse("4:00 am").ToString("HH\\:mm");
            }
            else if (shift_dropbox.SelectedValue == "Mid Shifters")
            {
                time_in_TextBox.Text = DateTime.Parse("10:00 pm").ToString("HH\\:mm");
                time_out_TextBox.Text = DateTime.Parse("7:00 am").ToString("HH\\:mm");
            }
            else if (shift_dropbox.SelectedValue == "Closers")
            {
                time_in_TextBox.Text = DateTime.Parse("1:00 am").ToString("HH\\:mm");
                time_out_TextBox.Text = DateTime.Parse("10:00 am").ToString("HH\\:mm");
            }
            else
            {
                time_in_TextBox.Text = DateTime.Parse("7:00 am").ToString("HH\\:mm");
                time_out_TextBox.Text = DateTime.Parse("4:00 pm").ToString("HH\\:mm");
            }
        }
    }
}