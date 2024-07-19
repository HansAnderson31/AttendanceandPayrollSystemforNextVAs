<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="Nextvas_Project_System.Timesheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
            .canvas {
	        background-color: white;
	        border: 2px solid black;
	        margin: auto;
	        padding: 20px;
            }
            .row{
                display:flex;
                justify-content:flex-start;
                margin-left:20px;
                margin-right:10px;
                margin-top:10px;
                margin-bottom:0px;
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
                left: 11px;
                top: 0px;
            }
            .auto-style2 {
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
                left: 1px;
                top: 0px;
            }
            </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="canvas" ID="canvas_above" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <asp:BoundField DataField="time_in_sched" HeaderText="Time In" />
                        <asp:BoundField DataField="time_out_sched" HeaderText="Time Out" />
                        <asp:BoundField DataField="late_count" HeaderText="Late" />
                        <asp:BoundField DataField="absent_count" HeaderText="Absent" />
                        <asp:BoundField DataField="attend_status" HeaderText="Attendance Status" />
                        
                    </Columns>
                </asp:GridView>
            <div class="row">
            <asp:TextBox CssClass="input_row" ID="empID" runat="server" TextMode="Phone"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Absent" CssClass="auto-style2" OnClick="Button1_Click" />
            </div>
        </div>


                <br />
                <br />
        <div align="left" class ="canvas" style="height:350px;width:auto;overflow:scroll;">
            <div>
                    Date between:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="time_in_TextBox" runat="server" CssClass="info_textbox" format="hh:mm" TextMode="Date"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    and&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="time_out_TextBox" runat="server" CssClass="info_textbox" format="hh:mm" Height="16px" TextMode="Date"></asp:TextBox>
                </div>
            <div>
                <br />
                <asp:GridView ID="timeSheet_GridView" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:HyperLinkField HeaderText="Employee ID" DataNavigateUrlFormatString="FullInformation.aspx?viewID={0}" DataTextField="emp_id" />
                        <asp:BoundField DataField="f_name" HeaderText="First Name" />
                        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                        <%--<asp:BoundField DataField="date" HeaderText="Date" />--%>
                        <asp:BoundField DataField="time_in" HeaderText="Time In" />
                        <asp:BoundField DataField="time_out" HeaderText="Time Out" />
                        <asp:BoundField DataField="attend_status" HeaderText="Attendance Status" />
                        
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
            <asp:Label ID="Label16" runat="server" Text="Employee ID"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox CssClass="input_row" ID="searchEmp" runat="server" TextMode="Phone"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" CssClass="button" />
            <asp:Button ID="clearBtn" runat="server" Text="Clear" CssClass="auto-style1" OnClick="clearBtn_Click" />
        </div>
        </div>
    
</asp:Content>
