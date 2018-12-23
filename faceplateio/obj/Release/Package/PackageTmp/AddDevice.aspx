<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDevice.aspx.cs" Inherits="faceplateio.AddDevice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Device</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:SiteMapPath ID="SiteMapPath1" Runat="server">
  </asp:SiteMapPath>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
          SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
         <div>
         <asp:Label ID="TMessage" runat="server" Text="Enter Device Details"></asp:Label>
            <table>
              <tr><td><asp:Label ID="Label9" runat="server" Text="Name"></asp:Label></td>
                  <td><asp:TextBox ID="CNameBox" runat="server"></asp:TextBox>  </td>    
              </tr>
             <tr><td><asp:Label ID="Label10" runat="server" Text="Description"></asp:Label></td>
                 <td><asp:TextBox ID="CDescBox" runat="server"></asp:TextBox><br /></td></tr>
             <tr><td><asp:Label ID="Label8" runat="server" Text="IPV6"></asp:Label></td>
                 <td><asp:TextBox ID="CIPBox" runat="server"></asp:TextBox><br /></td></tr>
            <tr><td><asp:Label ID="Label11" runat="server" Text="Key"></asp:Label></td>
                <td><asp:TextBox ID="CKeyBox" runat="server"></asp:TextBox><br /></td></tr>
</table>
         <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" /><br />
             <asp:Label ID="CMessage" runat="server" Text=""></asp:Label>
             

         </div>
    <div>
    
    </div>
    </form>
</body>
</html>
