<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddButton.aspx.cs" Inherits="faceplateio.AddButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Button</title>
</head>
<body>
    <form id="form1" runat="server">
               
  <asp:SiteMapPath ID="SiteMapPath1" Runat="server">
  </asp:SiteMapPath>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
 

         SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
         <br />
         <h2>Add Button</h2>
         <br />


  Welcome 

    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />

  
         <br />
         <br />

  
        <asp:Label ID="BMessage" runat="server"></asp:Label>

  
    <br />

    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <div>
        <asp:Label ID="Label1" runat="server" Text="Text"></asp:Label><asp:TextBox ID="TextText" runat="server"></asp:TextBox><br />
       
        <asp:ListBox ID="ScriptList" runat="server" OnSelectedIndexChanged="ScriptList_SelectedIndexChanged"></asp:ListBox> <asp:Label ID="ScriptNameLabel" runat="server" Text="Script"></asp:Label>
        <br />
         <asp:Label ID="Label3" runat="server" Text="Timer"></asp:Label><asp:TextBox ID="Timerx" runat="server"></asp:TextBox><br />
         <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label><asp:TextBox ID="Desc" runat="server"></asp:TextBox>
        <br />
        <br />
    </div>
        <asp:Button ID="Add_Button" runat="server" Text="Add" OnClick="Add_Button_Click" /><asp:Button ID="Cancel_Button" runat="server" Text="Cancel" />
    </form>
</body>
</html>
