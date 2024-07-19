using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nextvas_Project_System
{
    public partial class ViewEmployees : System.Web.UI.Page
    {
        private string conn = "server=localhost; user=root;database=dbconn;password=";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InsertDDL_Data();
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string date = string.IsNullOrEmpty(dateFilter.Text) ? "" : DateTime.Parse(dateFilter.Text).ToString("MMM dd yyyy");
            FindData(empIDFilter.Text, date);

            //Load_Data();
            if (!IsPostBack)
            {
                HttpCookie cookie = new HttpCookie("isEditing");
                cookie["toggle"] = "false";
                Response.Cookies.Add(cookie);

                HttpCookie cookie2 = new HttpCookie("selected");
                cookie2["selectedID"] = "";
                Response.AppendCookie(cookie2);

                ToggleInputs(false);
                Load_Data();
            }
        }

        private void Load_Data()
        {
            //string conn = "server=127.0.0.1; user=root; password=;database=nextvas_system_db;";
            string queryRegister = $"select emp_id, f_name, l_name, sex, bday, accessibility, t_leader, employed_date from employee_info_tbl";

            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            employeeGrid.DataSource = dt;
            employeeGrid.DataBind();
        }
        private void FindData(string findID, string findDate)
        {
            //string conn = "server=127.0.0.1; user=root; password=;database=nextvas_system_db;";
            string queryRegister = $"select emp_id, f_name, l_name, sex, bday, accessibility, t_leader, employed_date from employee_info_tbl " +
                $"where emp_id like '{findID}%' and employed_date like '{findDate}%' ";

            //Run the SQL Query
            MySqlConnection connect = new MySqlConnection(conn);
            MySqlCommand cmd = new MySqlCommand(queryRegister, connect);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            employeeGrid.DataSource = dt;
            employeeGrid.DataBind();
        }

        //Enabled or Disabled inputs
        private void ToggleInputs(bool toggle)
        {
            fname_Textbox.Enabled = toggle;
            lname_Textbox.Enabled = toggle;
            mname_Textbox.Enabled = toggle;
            sex_Textbox.Enabled = toggle;
            bday_Textbox.Enabled = toggle;

            home_add_Textbox.Enabled = toggle;
            email_add_Textbox.Enabled = toggle;
            cont_num_Textbox.Enabled = toggle;

            accessibility_drpbox.Enabled = toggle;
            team_drpbox.Enabled = toggle;
            shift_dropbox.Enabled = toggle;
            password_TextBox.Enabled = toggle;
            timeIn_Textbox.Enabled = toggle;
            timeOut_Textbox.Enabled = toggle;
            salRate_TextBox.Enabled = toggle;
            salOTRate_TextBox.Enabled = toggle;
        }

        protected void employeeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(employeeGrid, "select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click me";
            }
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

        protected void employeeGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            qrcode_ID_ImgDisplay.Visible = true;

            foreach (GridViewRow row in employeeGrid.Rows)
            {
                if (row.RowIndex == employeeGrid.SelectedIndex)
                {

                    try
                    {
                        row.BackColor = System.Drawing.Color.Gray;
                        row.ToolTip = string.Empty;

                        var cookie = Request.Cookies["selected"];
                        cookie["selectedID"] = row.Cells[0].Text;
                        Response.AppendCookie(cookie);

                        var id = Request.Cookies["selected"]["selectedID"];

                        var empInfo = EmployeeInfos.GetAllInfo(id);
                        var accessInfo = Access.GetAllAccessInfo(id);

                        emp_ID_LabelDisplay.Text = empInfo["emp_id"];
                        employed_date_LabelDisplay.Text = empInfo["employed_date"];

                        fname_Textbox.Text = empInfo["f_name"];
                        lname_Textbox.Text = empInfo["l_name"];
                        mname_Textbox.Text = empInfo["m_name"];
                        sex_Textbox.Text = empInfo["sex"];
                        bday_Textbox.Text = empInfo["bday"];

                        home_add_Textbox.Text = empInfo["home_add"];
                        email_add_Textbox.Text = empInfo["email_add"];
                        cont_num_Textbox.Text = empInfo["cont_num"];

                        accessibility_drpbox.Text = empInfo["accessibility"];
                        team_drpbox.Text = empInfo["t_leader"];
                        shift_dropbox.Text = empInfo["shift"];
                        timeIn_Textbox.Text = empInfo["time_in_sched"];
                        timeOut_Textbox.Text = empInfo["time_out_sched"];
                        salRate_TextBox.Text = empInfo["salary_rate"];
                        salOTRate_TextBox.Text = empInfo["salary_ot_rate"];

                        profile_pic_ImgDisplay.ImageUrl = empInfo["profile_pic"];
                        qrcode_ID_ImgDisplay.ImageUrl = empInfo["qr_code"];

                        if (accessibility_drpbox.SelectedValue != "Employee")
                        {
                            password_TextBox.Attributes["value"] = accessInfo["pass"];
                        }
                        password_area.Visible = accessibility_drpbox.SelectedValue != "Employee";
                    
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                    
            }
        }

        protected void update_Info_Click(object sender, EventArgs e)
        {
            var id = Request.Cookies["selected"]["selectedID"];

            var empInfo = EmployeeInfos.GetAllInfo(id);
            HttpCookie cookie = Request.Cookies["isEditing"];
            bool isEditing;
            bool.TryParse(cookie["toggle"], out isEditing);

            cookie["toggle"] = (!isEditing).ToString();
            Response.AppendCookie(cookie);


            string fname = fname_Textbox.Text;
            string lname = lname_Textbox.Text;
            string mname = mname_Textbox.Text;
            string gender = sex_Textbox.Text;
            string bday = bday_Textbox.Text;
            string home_add = home_add_Textbox.Text;
            string email_add = email_add_Textbox.Text;
            string cont_num = cont_num_Textbox.Text;

            string access = accessibility_drpbox.SelectedValue;
            string t_leader = team_drpbox.SelectedValue;
            string shift = shift_dropbox.SelectedValue;
            string password = password_TextBox.Text;
            string timein = timeIn_Textbox.Text;
            string timeout = timeOut_Textbox.Text;
            string salRate = salRate_TextBox.Text;
            string salOTRate = salOTRate_TextBox.Text;

            //Update Employee Information
            if (bool.Parse(cookie["toggle"]))
            {
                update_Info.Text = "Save Information";
                update_Info.BackColor = System.Drawing.Color.LightGreen;
                ToggleInputs(true);
            }
            else
            {
                update_Info.Text = "Edit Information";
                update_Info.BackColor = System.Drawing.Color.White;
                ToggleInputs(false);

                //Update SQL
                EmployeeInfos.UpdateEmployee(id, fname, lname, mname, gender, bday, home_add, email_add, cont_num, access, t_leader, shift, timein, timeout, salRate, salOTRate);
                Access.UpdatePassword(id, password);

                Response.Write("<script>alert('Update info successfully')</script>");
            }

            employeeGrid.DataBind();
        }


        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string date = string.IsNullOrEmpty(dateFilter.Text) ? "" : DateTime.Parse(dateFilter.Text).ToString("MMM dd yyyy");
            FindData(empIDFilter.Text, date);
        }
        protected void clearBtn_Click(object sender, EventArgs e)
        {
            //Clear input fields
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void accessibility_drpbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            password_area.Visible = accessibility_drpbox.SelectedValue != "Employee";
        }

        protected void print_ID_Click(object sender, EventArgs e)
        {
            var id = Request.Cookies["selected"]["selectedID"];

            EmployeeInfos.DeleteAccount(id);

            //Refresh the page
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }
        protected void shift_dropbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shift_dropbox.SelectedValue == "Openers")
            {
                timeIn_Textbox.Text = DateTime.Parse("7:00 pm").ToString("HH\\:mm");
                timeOut_Textbox.Text = DateTime.Parse("4:00 am").ToString("HH\\:mm");
            }
            else if (shift_dropbox.SelectedValue == "Mid Shifters")
            {
                timeIn_Textbox.Text = DateTime.Parse("10:00 pm").ToString("HH\\:mm");
                timeOut_Textbox.Text = DateTime.Parse("7:00 am").ToString("HH\\:mm");
            }
            else if (shift_dropbox.SelectedValue == "Closers")
            {
                timeIn_Textbox.Text = DateTime.Parse("1:00 am").ToString("HH\\:mm");
                timeOut_Textbox.Text = DateTime.Parse("10:00 am").ToString("HH\\:mm");
            }
            else
            {
                timeIn_Textbox.Text = DateTime.Parse("7:00 am").ToString("HH\\:mm");
                timeOut_Textbox.Text = DateTime.Parse("4:00 pm").ToString("HH\\:mm");
            }
        }
    }
}