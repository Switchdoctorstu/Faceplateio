<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="faceplateio.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 444px">
    <form id="form1" runat="server">
        <h1>Create New Account</h1><br />
    <div>

        <asp:label runat="server" text="User ID - email address"></asp:label><br />
        <asp:textbox ID="UserID1" runat="server" Width="438px"></asp:textbox><br />
        <asp:label runat="server" text="Password"></asp:label><br />
        <asp:textbox ID="Password1" runat="server"></asp:textbox><br />
        </div>
        <div>
        <asp:label runat="server" text="Confirm UserID  "></asp:label><br />
        <asp:textbox ID="UserID2" runat="server" Width="435px"></asp:textbox><br />
        <asp:label runat="server" text="Password"></asp:label><br />
        <asp:textbox ID="Password2" runat="server"></asp:textbox><br />
            </div>
        <div>
        <asp:label runat="server" text="Friendly Name "></asp:label><br />
        <asp:textbox ID="FriendlyName" runat="server"></asp:textbox><br />
            <asp:label runat="server" text="Desciption  "></asp:label><br />
        <asp:textbox ID="Description" runat="server" Width="434px"></asp:textbox><br />
        </div><div>
             <asp:Button ID="Create_Button" runat="server" Text="Create ID" OnClick="Create_Button_Click" />
             <asp:Button ID="Done_Button" runat="server" Text="Done" Width="92px" />
        </div>
        <asp:Label ID="LoginMessage" runat="server" Text="Enter New Credentials - Be Carefull"></asp:Label>

    </form>
</body>
</html>
