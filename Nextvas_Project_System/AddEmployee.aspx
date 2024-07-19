<%@ Page Title="" Language="C#" MasterPageFile="~/WebBase.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Nextvas_Project_System.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddEmployee.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 1400px;
        }
        .auto-style2 {
            width: 517px;
           
        }
        .auto-style3 {
            width: 423px;
        }
        .auto-style4 {
            font-size: 23px;
        }
        .auto-style6 {
    font-size: small;
}
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="info_box">
        <div class="header">
            <Header>Personal Information</Header>
        </div>

        <div class="image_area">
            <div>
                <div>
                    <asp:Image ID="profile_img" class="image_display" runat="server" ImageUrl="~/Assets/Icons/Profile Icon.png"/>
                </div>
                <div>
                    <asp:FileUpload ID="fileUpload" runat="server" accept="image/png, image/jpeg" />
                    
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ControlToValidate="fileUpload" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                    
                </div>
            </div>
            
        </div>

        <div class="info_input">
            <table>
                <tr>
                    <td>
                        <div class="first_name">
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="fname_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="fname_TextBox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="last_name">
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="lname_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="lname_TextBox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="middle_name">
                            <div>
                                <asp:Label ID="Label3" runat="server" Text="Middle Name"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="mname_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="mname_TextBox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="gender">
                            <div>
                                <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
                            </div>
                            <div>
                                <asp:DropDownList CssClass="info_dropbox" ID="gender_TextBox" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem Value="Null">Prefer not to say</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="bday">
                            <div>
                                <asp:Label ID="Label5" runat="server" Text="Birthday"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="bday_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="bday_TextBox" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="bday_TextBox" CssClass="auto-style6" ErrorMessage="Must be 18 years or older" ForeColor="Red" Type="Date"></asp:RangeValidator>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <div class="contact_info_box">
        <div class="header">
            <Header>Contact Information</Header>
        </div>

        <div class="contact_info_input">
            <table>
                <tr>
                    <td class="auto-style2" colspan="3">
                        <div class="home_address">
                            <div>
                                <asp:Label ID="Label10" runat="server" Text="Home Address"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="home_add_Textbox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div class="auto-style1">
                                <asp:TextBox CssClass="auto-style4" ID="home_add_Textbox" runat="server" Height="67px" TextMode="MultiLine" Width="1301px"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <div class="email_address">
                            <div>
                                <asp:Label ID="Label13" runat="server" Text="Email Address"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="email_add_Textbox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="email_add_Textbox" runat="server" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td class="auto-style3">
                        <div class="contact_num">
                            <div>
                                <asp:Label ID="Label14" runat="server" Text="Contact/Telephone Number"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="cont_num_Textbox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox CssClass="info_textbox" ID="cont_num_Textbox" runat="server" TextMode="Phone" MaxLength="11"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="tele_num">
                            <div>
                            </div>
                            <div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="business_info_box">
        <div class="header">
            <Header>Schedule Information</Header>
        </div>

        <div class="business_info_input">
            <div class="accessibility">
                <div>
                    <asp:Label ID="Label20" runat="server" Text="Accessibility"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList CssClass="info_dropbox" ID="accessibility_drpbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="accessibility_drpbox_SelectedIndexChanged">
                        <asp:ListItem>Accountant</asp:ListItem>
                        <asp:ListItem>Hr</asp:ListItem>
                        <asp:ListItem>Team Leader</asp:ListItem>
                        <asp:ListItem>Employee</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Team Leader"></asp:Label>
                    <br />
                    <asp:DropDownList CssClass="info_dropbox" ID="team_drpbox" runat="server" AutoPostBack="False" Height="17px" Width="127px">
                        <asp:ListItem>N/A</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label24" runat="server" Text="Time Shift"></asp:Label>
                    <br />
                    <asp:DropDownList ID="shift_dropbox" runat="server" Height="17px" Width="127px" OnSelectedIndexChanged="shift_dropbox_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Openers</asp:ListItem>
                        <asp:ListItem>Mid Shifters</asp:ListItem>
                        <asp:ListItem>Closers</asp:ListItem>
                        <asp:ListItem>Sweepers</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                   
                </div>
            </div>
            <div ID="password_area" runat="server">
                <div id="password_input1" runat="server" class="password" style="height:70px;">
                    <div>
                        <asp:Label ID="Label21" runat="server" Text="Password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox CssClass="info_textbox" ID="password_Textbox" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div id="password_input2" runat="server" class="re-password" style="height:70px;">
                    <div>
                        <asp:Label ID="Label22" runat="server" Text="Re-password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox CssClass="info_textbox" ID="password2_Textbox" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="in_sched">
                <div>
                    <asp:Label ID="Label11" runat="server" Text="Time in schedule"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="time_in_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox CssClass="info_textbox" ID="time_in_TextBox" runat="server" TextMode="Time" format="hh:mm"></asp:TextBox>
                </div>
            </div>
            <div class="out_sched">
                <div>
                    <asp:Label ID="Label16" runat="server" Text="Time out schedule"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="time_out_TextBox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox CssClass="info_textbox" ID="time_out_TextBox" runat="server" TextMode="Time" format="hh:mm"></asp:TextBox>
                </div>
            </div>
            <div class="salary" style="height:70px;">
                <div>
                    <asp:Label ID="Label18" runat="server" Text="Salary Rate/Hr"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="salary_Textbox" SetFocusOnError="True" style="color: #FF0000"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox CssClass="info_textbox" ID="salary_Textbox" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>

        </div>
    </div>




    <div class="buttons">
        <asp:Button CssClass="clear_btn" ID="clear_btn" runat="server" Text="Clear" OnClick="clear_btn_Click" CausesValidation="False"  />
        <asp:Button CssClass="submit_btn" ID="submit_btn" runat="server" Text="Submit" OnClick="submit_Click" />
    </div>
</asp:Content>
