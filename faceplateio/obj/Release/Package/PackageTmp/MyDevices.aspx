<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDevices.aspx.cs" Inherits="faceplateio.HomeCtl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<script runat="server">
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int imageWidth = Convert.ToInt32(RedBox2.Text);
        // Image1.Width = 1 * imageWidth;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int imageWidth = Convert.ToInt32(GreenBox4.Text);
        // Image1.Width = 1 * imageWidth;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int imageWidth = Convert.ToInt32(BlueBox6.Text);
        // Image1.Width = 1 * imageWidth;
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Device Console</title>
   
</head>
<body>
    
    <form id="form1" runat="server">

    
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
 

         SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF">
         </asp:TreeView>
         <h2>Device Manager</h2>


  Welcome to your devices 

    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />

  
         <br />

  
    <br />

    <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <div>
                       
            Device Map</div>
        <div>
            <asp:TreeView ID="TreeView1" runat="server" Height="174px" Width="378px"></asp:TreeView>
            <asp:Label ID="TreeMessage" runat="server" Text=""></asp:Label>
        </div>
         <div>
           
             <input id="AddControllerButton" type="button" value ="Add Device" onclick="window.open('AddDevice.aspx', 'Devices');" />
 
             <br />

         </div>
        <div>

            <asp:GridView ID="ControllerGridView" runat="server"  
                AutoGenerateEditButton="True" 
                AllowPaging="true"
                OnRowEditing="ControllerGridView_RowEditing"         
                OnRowCancelingEdit="ControllerGridView_RowCancelingEdit" 
                OnRowUpdating="ControllerGridView_RowUpdating"
                OnPageIndexChanging="ControllerGridView_PageIndexChanging"
                OnSelectedIndexChanged="CGV_SelectedIndexChanged"
                  datakeynames="ID"
                >
                
                 <Columns>
                      <asp:TemplateField HeaderText="From">
                     <ItemTemplate>
                         <asp:CheckBox ID="SelectFrom" runat="server" 
                             Text='<%# Eval("ID") %>' Checked="False" />
                         </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="To">
                     <ItemTemplate>
                         <asp:CheckBox ID="SelectTo" runat="server" 
                             Text='<%# Eval("ID") %>' Checked="False" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     
                    </Columns>
                 <HeaderStyle BackColor="#CC99FF" />
            </asp:GridView>
            <br />
            <asp:Label ID="CGVMessage" runat="server" Text=""></asp:Label>

        </div>
          <div>
            <asp:panel runat="server">
                 <asp:Label ID="Label2" runat="server" Text="Lights"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="Select Lighting Channel"></asp:Label>
                <asp:CheckBox ID="LightChan0" runat="server" />
                <asp:CheckBox ID="LightChan1" runat="server" />
                <asp:CheckBox ID="LightChan2" runat="server" />
                <asp:CheckBox ID="LightChan3" runat="server" />
                <asp:CheckBox ID="LightChan4" runat="server" />
                <asp:CheckBox ID="LightChan5" runat="server" />
                <asp:CheckBox ID="LightChan6" runat="server" />
                <asp:CheckBox ID="LightChan7" runat="server" />
            </asp:panel>
        </div>
        <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
        
          <table>
            <tr>
                <td>
                    <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" Minimum="000"
                                Maximum="255"
                                TargetControlID="RedBox1"
                                BoundControlID="RedBox2"
                                />
                </td>
                <td>
                    <asp:TextBox 
                        ID="RedBox1"
                        runat="server"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="RedBox2" 
                        runat="server"
                        ForeColor="Crimson"
                        Width="25"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:LinkButton 
                        ID="LinkButton1"
                        runat="server"
                        Text="Set Red"
                        ForeColor="#FF3300"
                        Font-Bold="true"
                        BorderColor="#FF3300"
                        BorderWidth="1"
                        OnClick="LinkButton1_Click"
                        ></asp:LinkButton>
                
                </td>
            </tr>
                <tr>
                <td>
                    <ajaxToolkit:SliderExtender ID="SliderExtender2" runat="server" Minimum="000"
                                Maximum="255"
                                TargetControlID="GreenBox3"
                                BoundControlID="GreenBox4"
                                />
                </td>
                <td>
                    <asp:TextBox 
                        ID="GreenBox3"
                        runat="server"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="GreenBox4" 
                        runat="server"
                        ForeColor="Crimson"
                        Width="25"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:LinkButton 
                        ID="LinkButton2"
                        runat="server"
                        Text="Set Green"
                        ForeColor="#66FF66"
                        Font-Bold="true"
                        BorderColor="#99FF33"
                        BorderWidth="1"
                        OnClick="LinkButton1_Click"
                        ></asp:LinkButton>
                
                </td>
            </tr>  <tr>
                <td>
                    <ajaxToolkit:SliderExtender ID="SliderExtender3" runat="server" Minimum="000"
                                Maximum="255"
                                TargetControlID="BlueBox5"
                                BoundControlID="BlueBox6"
                                />
                </td>
                <td>
                    <asp:TextBox 
                        ID="BlueBox5"
                        runat="server"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="BlueBox6" 
                        runat="server"
                        ForeColor="Crimson"
                        Width="25"
                        >
                    </asp:TextBox>
                </td>
                <td>                    
                    <asp:LinkButton 
                        ID="LinkButton3"
                        runat="server"
                        Text="Set Blue"
                        ForeColor="DodgerBlue"
                        Font-Bold="true"
                        BorderColor="CornflowerBlue"
                        BorderWidth="1"
                        OnClick="LinkButton1_Click"
                        >
                    </asp:LinkButton>
                
                </td>
            </tr>
        </table>

    </div>
      
        <div>
    
     
            <asp:Button ID="LightButton" runat="server" Text="Send Lights" OnClick="LightButton_Click" />
       
            <asp:Label ID="LightMessage" runat="server" Text=""></asp:Label>
        <br />
     
    </div>
        <div>
            
           <br />
   <asp:CheckBox ID="Relay0" runat="server" />
            <asp:CheckBox ID="Relay1" runat="server" />
            <asp:CheckBox ID="Relay2" runat="server" />
            <asp:CheckBox ID="Relay3" runat="server" />
            <asp:CheckBox ID="Relay4" runat="server" />
            <asp:CheckBox ID="Relay5" runat="server" />
            <asp:CheckBox ID="Relay6" runat="server" />
            <asp:CheckBox ID="Relay7" runat="server" />
                 <br />
 
        </div>
        <div>
            <asp:Button ID="RelayButton" runat="server" Text="Send Relays" OnClick="RelayButton_Click" />
             <asp:Label ID="RelayMessage" runat="server" Text=""></asp:Label>
        </div>


        <div>
            <asp:Button ID="SendAll" runat="server" Text="Send All" OnClick="SendAll_Click" />
        
 <asp:Label ID="AllMsg" runat="server" Text=""></asp:Label>
 
        </div>

        <div>
       
        </div>


    </form>
</body>
</html>
