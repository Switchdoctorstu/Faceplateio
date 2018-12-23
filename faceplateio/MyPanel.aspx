<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPanel.aspx.cs" Inherits="faceplateio.MyPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quick Accss Panel</title>
    <style type="text/css">
        #Button3 {
            width: 308px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
         SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
         <br />
         <h2>Control Panel</h2>
         Welcome <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />

        <br />
        <br />
        <input id="Button3" type="button" value="Add Button" onclick="window.open('AddButton.aspx', 'Buttons');" />

    </div>

<div>
      <asp:GridView ID="ButtonGridView" runat="server"
              
                AutoGenerateEditButton="True" 
                AllowPaging="True"
                OnRowEditing="BGV_RowEditing"         
                OnRowCancelingEdit="BGV_RowCancelingEdit" 
                OnRowUpdating="BGV_RowUpdating"
                OnPageIndexChanging="BGV_PageIndexChanging"
                OnSelectedIndexChanged="BGV_SelectedIndexChanged"
          onrowcommand="BGV_RowCommand"
             
                  datakeynames="ID"
                >
                 <Columns>
                      <asp:TemplateField HeaderText="DoIt" ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button ID="GridButton" 
                             runat="server" 
                             CausesValidation="false" 
                             width="100%"
                             Height="100%"
                             CommandName="Select" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"

                             Text="Do"></asp:Button>
                         </ItemTemplate>
                     </asp:TemplateField>
                      
                    </Columns>
                 <HeaderStyle BackColor="#CC99FF" />
            </asp:GridView>
</div>
        <asp:Label ID="Bmessage" runat="server" Text=""></asp:Label>
        <div>
            <asp:ListBox ID="ScriptOut" runat="server" Width="266px"></asp:ListBox>
            <br />
            <asp:Button ID="CLS" runat="server" Text="Clear" />
            <asp:Button ID="Stop" runat="server" Text="Stop" />
        </div>
    </form>
</body>
</html>
