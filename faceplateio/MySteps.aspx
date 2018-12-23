<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySteps.aspx.cs" Inherits="faceplateio.MySteps" %>

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
    <div>
     <asp:GridView ID="StepGridView" runat="server">
        </asp:GridView>
        <br />
    </div>
        <div>
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         <asp:TextBox ID="LabelBox" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Operand"></asp:Label>  
        <asp:DropDownList ID="OperandList" runat="server">
         </asp:DropDownList>
        
        <asp:Label ID="Label3" runat="server" Text="Operator"></asp:Label>  
        <asp:DropDownList ID="OperatorList" runat="server">
         </asp:DropDownList>
        
        <asp:Label ID="Label4" runat="server" Text="Operant"></asp:Label>  
        <asp:DropDownList ID="OperantList" runat="server">
         </asp:DropDownList>
        <br />
             <asp:Label ID="Label10" runat="server" Text="Mode"></asp:Label>  
        <asp:DropDownList ID="ModeList" runat="server">
         </asp:DropDownList>
         <asp:Label ID="Label5" runat="server" Text="Message"></asp:Label>
         <asp:TextBox ID="Message" runat="server"></asp:TextBox>
        <br />
        Exits:
         <asp:Label ID="Label6" runat="server" Text="Equals"></asp:Label>
         <asp:TextBox ID="EQBox" runat="server"></asp:TextBox> 
        <asp:Label ID="Label7" runat="server" Text="Greater"></asp:Label>
         <asp:TextBox ID="GTBox" runat="server"></asp:TextBox> 
        <asp:Label ID="Label8" runat="server" Text="Less"></asp:Label>
         <asp:TextBox ID="LTBox" runat="server"></asp:TextBox> 
        <asp:Label ID="Label9" runat="server" Text="Null"></asp:Label>
         <asp:TextBox ID="NULLBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Add_Step" runat="server" Text="Add Step" OnClick="Add_Step_Click" />
            <br />
        <asp:Label ID="AddStepMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
