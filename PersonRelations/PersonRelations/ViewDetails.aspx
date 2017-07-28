<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDetails.aspx.cs" Inherits="PersonRelations.ViewDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/ViewDetails.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="maindiv">
            <asp:Button ID="LogoutBtn" Text="Logout" runat="server" OnClick="LogoutBtn_Click" Style="float: right" CssClass="btn btn-info" CausesValidation="false" />
            <asp:PlaceHolder ID="relationPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:Button ID="BtnAddRelation" runat="server" OnClick="BtnAddRelation_Click" Style="float: right; width: 100%" Text="Add Relation" CssClass="btn btn-info" />
            <div id="iframediv">
                <iframe id="AddRelation" src="AddRelation.aspx" runat="server" visible="false" width="50%" frameborder="0" height="600px" style:"ma"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
