<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="Nextvas_Project_System.Timesheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="option_area">
            <%--<div>
                <div class="date_filter">
                    <div>
                        <asp:Label ID="dateFilter" runat="server" Text="Date Filter"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="dateTime_AttendanceFilter" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="emp_id_filter">
                    <div>
                        <asp:Label ID="employeeIdFilter" runat="server" Text="Employee ID Filter"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="emp_ID_AttendanceFilter" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>--%>
        </div>
        <div>
            <div>
                <asp:GridView ID="timeSheet_GridView" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <%--<asp:BoundField DataField="emp_id" HeaderText="Employee ID"/>--%>
                        <asp:HyperLinkField DataNavigateUrlFields="emp_id" HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <asp:BoundField DataField="time_in" HeaderText="Time In" />
                        <asp:BoundField DataField="time_out" HeaderText="Time Out" />
                        <%--<asp:BoundField DataField="scan_by" HeaderText="Scan By" />--%>
                        <asp:HyperLinkField DataNavigateUrlFields="scan_by" HeaderText="Scan By" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="scan_by" />
                        <asp:BoundField DataField="attend_status" HeaderText="Attendance Status" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
