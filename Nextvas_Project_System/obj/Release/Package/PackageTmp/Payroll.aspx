<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="Nextvas_Project_System.Payroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <di>
        <div>

        </div>

        <div>
            <div>
                <asp:GridView ID="payroll_GridView" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="payroll_GridView_RowCommand" OnLoad="payroll_GridView_Load">
                    <Columns>
                        <%--<asp:BoundField DataField="emp_id" HeaderText="Employee ID"/>--%>
                        <asp:HyperLinkField DataNavigateUrlFields="emp_id" HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <asp:BoundField DataField="total_hr" HeaderText="Total Hour" />
                        <asp:BoundField DataField="total_ot" HeaderText="Total Overtime" />
                        <asp:BoundField DataField="salary_rate" HeaderText="Normal Salary" />
                        <asp:BoundField DataField="salary_ot_rate" HeaderText="Overtime Salary" />
                        <asp:BoundField DataField="total_sal" HeaderText="Total Salary" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:ButtonField ButtonType="Button" CommandName="statusBtn" DataTextField="status" HeaderText="Status"/>
                        <asp:BoundField DataField="claimed_date" HeaderText="Claimed Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </di>
</asp:Content>
