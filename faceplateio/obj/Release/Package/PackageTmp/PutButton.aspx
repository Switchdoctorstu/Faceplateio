<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PutButton.aspx.cs" Inherits="faceplateio.Put_Button" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Table ID="Table1" runat="server" Height="199px" Width="704px">
            <asp:TableRow>
            <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Request"></asp:Label></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Response"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:Button ID="Button1" runat="server" Text="test" OnClick="Button1_Click" /></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
        </asp:Table>    
        
        
        
    
        <asp:Label ID="Label4" runat="server" Text="URL:"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        
        
        
        </form>
    
</body>
</html>
