<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="Nextvas_Project_System.ViewEmployees" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ViewEmployees.css" rel="stylesheet" />
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="info_area">
        <div class="header">
            <Header>Employee Information</Header>
        </div>
        <div class="row">
            <div class="row1">
                <div>
                    <asp:Image CssClass="profile_pic" ID="profile_pic_ImgDisplay" runat="server" ImageUrl="~/Assets/Icons/Profile Icon.png" />
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Font-Size="15px" Text="Employee ID number"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="emp_ID_LabelDisplay" runat="server" style="font-weight:bold" Text="0000-0000-0000"></asp:Label>
                </div>
                <div>
                    <p><em style="font-size: 7pt">Employed Since </em> <span><asp:Label ID="employed_date_LabelDisplay" Font-Size="7pt" runat="server" Text="Label" style="font-weight: 700"></asp:Label></span></p> 
                </div>
                
            </div>

            <div class="row2" style="font-size: 5pt">
                <div class="input_row">
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label2" CssClass="labelInput"  runat="server" Text="First Name"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="fname_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label3" CssClass="labelInput" runat="server" Text="Last Name"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="lname_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label4" CssClass="labelInput" runat="server" Text="Middle Name"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="mname_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="input_row">
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label5" CssClass="labelInput" runat="server" Text="Gender"></asp:Label>
                        </div>
                        <div>
                            <%--<asp:TextBox ID="gender_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList CssClass="textBoxInput" ID="sex_Textbox" runat="server">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem Value="Null">Prefer not to say</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label6" CssClass="labelInput" runat="server" Text="Birthday"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="bday_Textbox" CssClass="textBoxInput" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
                <div class="input_row">
                    <div class="cell">
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
                <div class="home_add">
                    <div>
                        <asp:Label ID="Label14" CssClass="labelInput" runat="server" Text="Home Address"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="home_add_Textbox" runat="server" style="width:530px; font-size:14pt;"></asp:TextBox>
                    </div>
                </div>

                <div class="input_row">
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label11" CssClass="labelInput" runat="server" Text="Email Address"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="email_add_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                            <asp:Label ID="Label12" CssClass="labelInput" runat="server" Text="Contact Number"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="cont_num_Textbox" CssClass="textBoxInput" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cell">
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="row2_extend">
                <div class="job_sched">
                    <div class="input_row">
                        <div class="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label17" runat="server" Text="Accessibility"></asp:Label>
                            </div>
                            <div>
                                <asp:DropDownList CssClass="input_sched" ID="accessibility_drpbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="accessibility_drpbox_SelectedIndexChanged">
                                    <asp:ListItem>Accountant</asp:ListItem>
                                    <asp:ListItem>Hr</asp:ListItem>
                                    <asp:ListItem>Team Leader</asp:ListItem>
                                    <asp:ListItem>Employee</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label CssClass="label_sched" ID="Label23" runat="server" Text="Team Leader" AutoPostBack="False"></asp:Label>
                                <br />
                                <asp:DropDownList ID="team_drpbox" runat="server" AutoPostBack="False" Height="31px" Width="120px">
                        <asp:ListItem>N/A</asp:ListItem>
                    </asp:DropDownList>
                            </div>
                            
                        </div>
                        <div class ="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label7" runat="server" Text="Shift"></asp:Label>
                            </div>
                            <div>
                                <asp:DropDownList CssClass="input_sched" ID="shift_dropbox" runat="server" OnSelectedIndexChanged="shift_dropbox_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Openers</asp:ListItem>
                        <asp:ListItem>Mid Shifters</asp:ListItem>
                        <asp:ListItem>Closers</asp:ListItem>
                        <asp:ListItem>Sweepers</asp:ListItem>
                    </asp:DropDownList>
                            </div>
                        <div id="password_area" runat="server">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label18" runat="server" Text="Password"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox CssClass="input_sched" Height="27px" ID="password_TextBox" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                            </div>

                    </div>
                    
                    
                    <div class="input_row">
                        <div class="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label20" runat="server" Text="Time In"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox CssClass="input_sched" ID="timeIn_Textbox" runat="server" TextMode="Time"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label22" runat="server" Text="Time Out"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox CssClass="input_sched" ID="timeOut_Textbox" runat="server" TextMode="Time"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="input_row">
                        <div class="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label19" runat="server" Text="Salary Rate"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox CssClass="input_sched" ID="salRate_TextBox" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="cell">
                            <div>
                                <asp:Label CssClass="label_sched" ID="Label21" runat="server" Text="OT Salary Rate"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox CssClass="input_sched" ID="salOTRate_TextBox" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    
                </div>
            </div>

            <div class="row3">
                <div>
                    <asp:Image CssClass="qrcode_ID" ID="qrcode_ID_ImgDisplay" ImageUrl="~/App_Data/GeneratedQRcodeImage/QRCode.png" runat="server" visible="false"/>
                </div>
            </div>

            <div class="row4">
                <div class="row_option">
                    <div>
                        <asp:Button ID="update_Info" runat="server" Text="Edit Information" OnClick="update_Info_Click" />
                    </div>
                    <div>
                        <asp:Button ID="print_ID" runat="server" Text="Delete Account" OnClick="print_ID_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="filter_area">
        <div class="row">
            <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>
            <asp:TextBox CssClass="input_row" ID="dateFilter" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Label ID="Label16" runat="server" Text="Employee ID"></asp:Label>
            <asp:TextBox CssClass="input_row" ID="empIDFilter" runat="server" TextMode="Phone"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
            <asp:Button ID="clearBtn" runat="server" Text="Clear" OnClick="clearBtn_Click" />
        </div>
    </div >
    <div class="data_area">
        <div class="header">
            <Header>Employee List</Header>
        </div>
        <div class="data">
            <asp:GridView ID="employeeGrid" runat="server" AutoGenerateColumns="False" OnRowDataBound="employeeGrid_RowDataBound" OnSelectedIndexChanged="employeeGrid_SelectedIndexChanged" Width="100%" >
                <Columns>
                    <asp:BoundField DataField="emp_id" HeaderText="Employee ID"/>
                    <asp:BoundField DataField="f_name" HeaderText="First Name" />
                    <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="sex" HeaderText="Gender" />
                    <asp:BoundField DataField="bday" HeaderText="Birthday" />
                    <asp:BoundField DataField="accessibility" HeaderText="Accessibility" />
                    <asp:BoundField DataField="t_leader" HeaderText="Team Leader" />
                    <asp:BoundField DataField="employed_date" HeaderText="Employed Date" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
