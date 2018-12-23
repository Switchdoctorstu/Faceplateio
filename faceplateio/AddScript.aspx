<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddScript.aspx.cs" Inherits="faceplateio.AddScript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
         <form id="form1" runat="server">
              <asp:SiteMapPath ID="SiteMapPath1" Runat="server">
  </asp:SiteMapPath>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
          SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
             <br />
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:Label ID="IDLabel" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="Description"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Description" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="From"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="From" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="To"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="To" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Message"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Msg" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Wait"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Wait" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Time"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Time" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="Next"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Next" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label8" runat="server" Text="Key"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Key" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="Confirmation"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Confirm" runat="server"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    
    <p>
        &nbsp;</p>
   
        <p>
            <asp:Button ID="AddButton" runat="server" Text="Add Script" OnClick="AddButton_Click" />
            <asp:HyperLink ID="HyperLink1" onclick="HyperLink_Click" href="Myscripts.aspx" runat="server">Back to Scripts</asp:HyperLink>
        </p>
    <div>
    
        <asp:Label ID="SMessage" runat="server" Text="Messages"></asp:Label>
    
    </div>
    </form>
</body>
</html>
