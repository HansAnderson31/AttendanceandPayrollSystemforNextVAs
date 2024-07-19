<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="Nextvas_Project_System.Payroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .input_row {
            display: flex;
            justify-content: flex-start;
        }
* {
    margin: 0px;
    padding: 0px;
    list-style: none;
    text-decoration: none;
}
.button {
  position: relative;
  background-color: #237C7C;
  border: none;
  font-size: 14px;
  color: #FFFFFF;
  padding: 5px;
  width: 70px;
  text-align: center;
  transition-duration: 0.4s;
  text-decoration: none;
  overflow: hidden;
  cursor: pointer;
}

.button:after {
  content: "";
  background: #f1f1f1;
  display: block;
  position: absolute;
  padding-top: 300%;
  padding-left: 350%;
  margin-left: -20px !important;
  margin-top: -120%;
  opacity: 0;
  transition: all 0.8s
}

.button:active:after {
  padding: 0;
  margin: 0;
  opacity: 1;
  transition: 0s
}

        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            position: relative;
            background-color: #237C7C;
            font-size: 14px;
            color: #FFFFFF;
            padding: 5px;
            width: 70px;
            text-align: center;
            transition-duration: 0.4s;
            text-decoration: none;
            overflow: hidden;
            cursor: pointer;
            left: 0px;
            top: 0px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <di>
        <div>
          <div class="option_area">
            <div ID="date_range" class="in_sched" runat="server">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Start Date: " Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="start_date_TextBox" runat="server" CssClass="info_textbox" format="hh:mm" TextMode="Date" Visible="False"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="End Date:" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="end_date_TextBox" runat="server" CssClass="info_textbox" format="hh:mm" Height="16px" TextMode="Date" Visible="False"></asp:TextBox>
                </div>

            </div>
        </div>
            <div>
                <br />
                <asp:GridView ID="payslip_GridView" runat="server" AutoGenerateColumns="False" Width="100%" OnLoad="payroll_GridView_Load">
                    <Columns>
                        <%--<asp:BoundField DataField="emp_id" HeaderText="Employee ID"/>--%>
                        <asp:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <asp:BoundField DataField="total_hr" HeaderText="Total Hour" />
                        <asp:BoundField DataField="total_ot" HeaderText="Total Overtime" />
                        <asp:BoundField DataField="salary_rate" HeaderText="Normal Salary" />
                        <asp:BoundField DataField="salary_ot_rate" HeaderText="Overtime Salary" />
                        <asp:BoundField DataField="total_sal" HeaderText="Total Salary" />
                        <asp:BoundField DataField="total_tax" HeaderText="Tax Deduct" />
                        <asp:BoundField DataField="computed_sal" HeaderText="Computed Salary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>

        <asp:Button ID="submit_btn" runat="server" Text="Submit" OnClick="submit_Click" CssClass="auto-style1" Visible="False" />

        </div>
    </di>
</asp:Content>
