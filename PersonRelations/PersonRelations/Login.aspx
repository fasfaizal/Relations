<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PersonRelations.Login" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/Login.css" />
</head>
<body>
    <div class="col-xs-3"></div>
    <div class="col-xs-6">
        <form id="form1" runat="server">
            <div class="imgcontainer">
                <img src="img_avatar2.png" alt="Avatar" class="avatar" />
            </div>

            <div class="text-center">
                <label><b>Username</b></label>
                <asp:TextBox runat="server" placeholder="Enter Username" ID="uname" CssClass="inputclass"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="runame" runat="server" ControlToValidate="uname" ErrorMessage="*Please enter a username" Font-Italic="true" ForeColor="Green"></asp:RequiredFieldValidator>
                <br />
                <label><b>Password</b></label>
                <asp:TextBox runat="server" placeholder="Enter Password" ID="password" CssClass="inputclass" TextMode="Password"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rpassword" runat="server" ControlToValidate="password" ErrorMessage="*Please enter a password" Font-Italic="true" ForeColor="Green"></asp:RequiredFieldValidator><br />
                <asp:Label runat="server" ID="invalidUser" Font-Italic="true" ForeColor="Green"></asp:Label><br />
                <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" Text="Login" CssClass="btnclass" />
            </div>
        </form>
        <div class="text-center" style="background-color: #f1f1f1; height: 50px; padding-top: 20px">
            <a href="SignUp.aspx">Sign Up</a>
        </div>
    </div>
</body>
</html>
