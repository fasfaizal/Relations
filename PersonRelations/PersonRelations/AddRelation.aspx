<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRelation.aspx.cs" Inherits="PersonRelations.AddRelation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/AddRelation.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:Label ID="Relationship" Text="Relation" runat="server"></asp:Label>                    
                    <asp:DropDownList ID="Relation" runat="server" CssClass="relClass" AutoPostBack="true">
                        <asp:ListItem Value="0">select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ValidateRelation" runat="server" ControlToValidate="Relation" Font-Italic="true" ForeColor="Green" ErrorMessage="*Select Relation" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Spouse" />
                </Triggers>
            </asp:UpdatePanel>
            
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <ContentTemplate>                    
            <asp:Label ID="LabelSpouse" Text="Spouse" runat="server"></asp:Label>
                    <asp:DropDownList ID="Spouse" runat="server">
                        <asp:ListItem Value="0">select</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Spouse" />
                </Triggers>
            </asp:UpdatePanel>
            <%--<asp:RequiredFieldValidator ID="ValidateSpouse" runat="server" ControlToValidate="Spouse" Font-Italic="true" ForeColor="Green" ErrorMessage="*Select Spouse" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>--%>
            <br />
            <br />

            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:Label ID="LabelParent" Text="Parent" runat="server"></asp:Label>
                    <asp:DropDownList ID="Parent" runat="server">
                        <asp:ListItem Value="0">select</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="ValidateParent" runat="server" ControlToValidate="Parent" Font-Italic="true" ForeColor="Green" ErrorMessage="*Select Parent" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>--%>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Parent" />
                </Triggers>
            </asp:UpdatePanel>
            
            <br />
            <br />
            <asp:FileUpload ID="ImageUpload" runat="server" Style="margin-left: 150px; width: 50%;" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:BoundField DataField="Text" />
                    <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="submit" Text="submit" runat="server" OnClick="submit_Click" Style="margin-left: 438px" />
            <a href="ViewDetails.aspx" target="_top">Close</a>  
        </div>
    </form>
</body>
</html>
