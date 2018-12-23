<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="faceplateio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/HomeCtl.aspx" OnAuthenticate="Login1_Authenticate" CreateUserText="Create Account" CreateUserUrl="~/CreateAccount.aspx">
        </asp:Login>
    
    </div>
        <asp:Label ID="LoginMessage" runat="server" Text="Messages"></asp:Label>
    </form>
</body>
</html>
