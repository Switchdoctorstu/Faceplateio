<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyScripts.aspx.cs" Inherits="faceplateio.MyScripts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Script Administration</title>
</head>
<body>
    <form id="form1" runat="server">
         
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
          SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
        <div>
            <input id="AddScriptButton" type="button" value ="Add Script" onclick="window.open('AddScript.aspx', 'Scripts');" />
        </div>
    <div>
    
        <asp:GridView ID="ScriptGridView" runat="server"
             AutoGenerateEditButton="True" 
                AllowPaging="true"
                OnRowEditing="SGV_RowEditing"         
                OnRowCancelingEdit="SGV_RowCancelingEdit" 
                OnRowUpdating="SGV_RowUpdating"
                OnSelectedIndexChanged="SGV_SelectedIndexChanged"
                  datakeynames="ID" >
        </asp:GridView>
    
    </div>
         <asp:Label ID="SGVMessage" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
