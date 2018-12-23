<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebUI.aspx.cs" Inherits="faceplateio.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>faceplateIO</title>
</head>
<body style="height: 387px" background="cbpurple2.jpg">
   
    <form id="form1" runat="server">
     
    
        <asp:Table ID="Table1" runat="server" Height="107px">
        <asp:TableRow>
            
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Top 10:" BackColor="#9966FF" ForeColor="Black"></asp:Label>
       <asp:GridView ID="GridView3"  AutoGenerateColumns="False" runat="server" BackColor="#CC99FF">
            <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                        <asp:BoundField DataField="ID" HeaderText="Index" />
                        <asp:BoundField DataField="From" HeaderText="From" />
                        <asp:BoundField DataField="To" HeaderText="To" />
                        <asp:BoundField DataField="Message" HeaderText="Message" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <input name="MyRadioButton" type="radio" value='<%# Eval("To") %>' />
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                   
                    </Columns>
        </asp:GridView>
               
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="faceplateio.MyDataClassesDataContext" EntityTypeName="" Select="new (From, To, Msg, Time)" TableName="Messages">
                </asp:LinqDataSource>
            </asp:TableCell>
            <asp:TableCell>
     <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Copy" />
                <asp:Label ID="Label2" runat="server" Text="To:" BackColor="#9966FF"></asp:Label>
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label4" runat="server" Text="My Grid:"></asp:Label>

                <asp:GridView AutoGenerateColumns="False" ID="GridView2" runat="server" BackColor="#CC99FF">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                        <asp:BoundField DataField="ID" HeaderText="Index" />
                        <asp:BoundField DataField="From" HeaderText="From" />
                       <asp:BoundField DataField="To" HeaderText="To" />
                        <asp:BoundField DataField="Message" HeaderText="Message" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:RadioButton ID="Select" runat="server"></asp:RadioButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                   
                    </Columns>
                </asp:GridView>
            </asp:TableCell>


        </asp:TableRow>
        </asp:Table>

        

     

        

        <p>
            &nbsp;</p>
        <asp:Label ID="Label3" runat="server" Text="Client Messages:"></asp:Label>
<ul id="messages" />

         
        <p>
            &nbsp;</p>
     
            <br />
        <asp:Label ID="Label5" runat="server" Text="My List:"></asp:Label>
        
        <asp:ListBox ID="ListBox1" runat="server" Width="657px"></asp:ListBox>


    </form> 
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </body>
</html>
