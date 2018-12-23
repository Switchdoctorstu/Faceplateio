<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="faceplateio.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 387px">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Bound Grid:"></asp:Label>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
            <Columns>
                <asp:BoundField DataField="From" HeaderText="From" ReadOnly="True" SortExpression="From" />
                <asp:BoundField DataField="To" HeaderText="To" ReadOnly="True" SortExpression="To" />
                <asp:BoundField DataField="Msg" HeaderText="Msg" ReadOnly="True" SortExpression="Msg" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="faceplateio.MyDataClassesDataContext" EntityTypeName="" Select="new (From, To, Msg)" TableName="Messages">
        </asp:LinqDataSource>


        <asp:Table ID="Table1" runat="server">
        </asp:Table>

            
        <p>
            &nbsp;</p>
     <asp:Label ID="Label2" runat="server" Text="Buttons:"></asp:Label>

        <input id="Button2" type="button" value="Client" onclick="trythis();"/>
   
        
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Server" />
        <p>
            &nbsp;</p>
        <asp:Label ID="Label3" runat="server" Text="Client Messages:"></asp:Label>
<ul id="messages" />

         
        <p>
            &nbsp;</p>
     
        <asp:Label ID="Label4" runat="server" Text="My Grid:"></asp:Label>

            <asp:GridView AutoGenerateColumns="False" ID="GridView2" runat="server">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                    <asp:BoundField DataField="From" HeaderText="From" />
                   <asp:BoundField DataField="To" HeaderText="To" />
                    <asp:BoundField DataField="Message" HeaderText="Message" />
                     
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:RadioButton ID="Select" runat="server"></asp:RadioButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>
            </asp:GridView>
            <br />
        <asp:Label ID="Label5" runat="server" Text="My List:"></asp:Label>
        
        <asp:ListBox ID="ListBox1" runat="server" Width="657px"></asp:ListBox>

             <script>
        $('#Label1').Text('Hello');
        $('#GridView1').Columns.Add();

        var uri = 'api/io';

        $(document).ready(function () {
            // Send an AJAX request
            $.getJSON(uri)
                .done(function (data) {
                    // On success, 'data' contains a list of messages
                    $.each(data, function (message) {
                        // Add a list item for the product.
                        $('<li>', { text: formatItem(message) }).appendTo($('#messages'));
                    });
                });
        });

        function trythis() {
            $.getJSON('api/io')
              .done(function (data) {
                  // On success, 'data' contains a list of messages
                  $.each(data, function (message) {
                      // Add a list item for the product.
                      $('<li>', { text: formatItem(message) }).appendTo($('#messages'));
                  });
              });
        }

    </script>

    </form> 
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </body>
</html>
