<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="Payslip.aspx.cs" Inherits="Nextvas_Project_System.Payslip" %>
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <di>
        <div>

        </div>

        <div>
            <div>
                <asp:GridView ID="payslip_GridView" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <%--<asp:BoundField DataField="emp_id" HeaderText="Employee ID"/>--%>
                        <asp:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <asp:BoundField DataField="total_hr" HeaderText="Total Hour" />
                        <asp:BoundField DataField="total_ot" HeaderText="Total Overtime" />
                        <asp:BoundField DataField="total_sal" HeaderText="Total Salary" />
                        <asp:BoundField DataField="total_tax" HeaderText="Tax Deduct" />
                        <asp:BoundField DataField="computed_sal" HeaderText="Computed Salary" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:BoundField DataField="date_claimed" HeaderText="Date Claimed" />
                        <asp:BoundField DataField="start_date" HeaderText="Start Date" />
                        <asp:BoundField DataField="end_date" HeaderText="End Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>

            <asp:TextBox ID="empIDFilter" runat="server" TextMode="Phone"></asp:TextBox>

        <asp:Button ID="submit_btn" runat="server" Text="Claim" OnClick="submit_Click" CssClass="button" />

        </div>
    </di>
</asp:Content>
