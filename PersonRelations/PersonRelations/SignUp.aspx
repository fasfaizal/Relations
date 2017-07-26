<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PersonRelations.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/bootstrap.js"></script>
    <link rel="stylesheet" type="text/css" href="css/SignUp.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="FirstName" Text="First Name" runat="server"></asp:Label>
            <asp:TextBox ID="FName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="FNameValidator" runat="server" ControlToValidate="FName" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LastName" Text="Last Name" runat="server"></asp:Label>
            <asp:TextBox ID="LName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="LNameValidator" runat="server" ControlToValidate="LName" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LGender" Text="Gender" runat="server"></asp:Label>
            <asp:DropDownList ID="Gender" runat="server">
                <asp:ListItem Value="0">select</asp:ListItem>
                <asp:ListItem Value="male">Male</asp:ListItem>
                <asp:ListItem Value="female">Female</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="GenderValidator" runat="server" ControlToValidate="Gender" Font-Italic="true" ForeColor="Green" ErrorMessage="*Select gender" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LDOB" Text="DOB" runat="server"></asp:Label>
            <asp:TextBox ID="DOB" TextMode="Date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="DOBValidator" runat="server" ControlToValidate="DOB" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <p class="Biodata">
                <asp:Label ID="LBiodata" Text="Biodata" runat="server"></asp:Label>
                <asp:TextBox ID="Biodata" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="BiodataValidator" runat="server" ControlToValidate="Biodata" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            </p>
            <br />
            <asp:Label ID="LUserName" Text="User Name" runat="server"></asp:Label>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Usernamevalidator" runat="server" ControlToValidate="UserName" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LPassword" Text="Password" runat="server"></asp:Label>
            <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="Password" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LConfirmPassword" Text="Confirm Password" runat="server"></asp:Label>
            <asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Confirmpswdvalidator" runat="server" ControlToValidate="ConfirmPassword" Font-Italic="true" ForeColor="Green" ErrorMessage="*Please Enter Value"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator runat="server" ID="cmpPswd" ControlToValidate="Password" ControlToCompare="ConfirmPassword"
                 Operator="Equal" Font-Italic="true" ForeColor="Green" Type="String" ErrorMessage="*Password Mismatch"
                 EnableClientScript="false" Style="margin-left: 134px; width: 50%;" />
            <br />
            <asp:FileUpload ID="ImageUpload" runat="server" Style="margin-left: 150px; width: 50%;"  />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:BoundField DataField="Text"/>
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="submit" Text="submit" runat="server" OnClick="submit_Click" Style="margin-left: 438px" />
        </div>
    </form>
</body>
</html>
