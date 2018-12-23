<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyButtons.aspx.cs" Inherits="faceplateio.MyButtons" %>
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
    <title>My Buttons</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
          SiteMap: <asp:TreeView ID="TreeView2" runat="server" DataSourceID="SiteMapDataSource1" ExpandDepth="0" BackColor="#CC99FF" HoverNodeStyle-BackColor="#CC99FF">
         </asp:TreeView>
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
        
        <table><tr><td>
            <table><tr><td>
            <asp:Button ID="Configure" runat="server" Text="Configure" align="right" OnClick="Configure_Click"/></td></tr>
                <tr><td>
          <asp:Button ID="Send" runat="server" Height="113px" Text="Do !" Width="165px" OnClick="Send_Click" />
            </td></tr><tr><td>
                    <asp:Label ID="ButtonMessage" runat="server" ></asp:Label>
            </td></tr></table>
        </td>
        <td>
            <table><tr><td><asp:CheckBox ID="EN_relayBox" runat="server" OnCheckedChanged="EN_relayBox_CheckedChanged" />
                <asp:Button ID="RelayButton" runat="server" Text="Relays" OnClick="RelayButton_Click" />
                </td></tr>
                <br />
                <tr><td>
                    <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
                    <asp:DropDownList ID="FromList" runat="server"></asp:DropDownList></td></tr>
                <tr><td><asp:DropDownList ID="ToList" runat="server"></asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                    </td></tr>
     <br />           
                <tr><td><asp:CheckBox ID="EN_LightsBox" runat="server" OnCheckedChanged="EN_LightsBox_CheckedChanged"/>
                    <asp:Button ID="LightButton" runat="server" Text="Lights" OnClick="LightButton_Click" />
                    </td></tr>
            </table>
        </td>
            <td>
<asp:Label ID="Label22" runat="server" Text="EN     DATA"></asp:Label><br />
        <asp:CheckBox ID="RelayEn1" runat="server" Text="R0" />
        <asp:CheckBox ID="RelayBox1" runat="server" Text="R0" /><br />
        <asp:CheckBox ID="RelayEn2" runat="server" Text="R0" />
        <asp:CheckBox ID="RelayBox2" runat="server" Text="R1" /><br />
        <asp:CheckBox ID="RelayEn3" runat="server" Text="R0" />
        <asp:CheckBox ID="RelayBox3" runat="server" Text="R2" /><br />
        <asp:CheckBox ID="RelayEn4" runat="server" Text="R0" />

                <asp:CheckBox ID="RelayBox4" runat="server" Text="R3" /><br />
                <asp:CheckBox ID="RelayEn5" runat="server" Text="R3" />
                <asp:CheckBox ID="RelayBox5" runat="server" Text="R4" /><br />
                <asp:CheckBox ID="RelayEn6" runat="server" Text="R3" />

                <asp:CheckBox ID="RelayBox6" runat="server" Text="R5" /><br />
                <asp:CheckBox ID="RelayEn7" runat="server" Text="R3" />

                <asp:CheckBox ID="RelayBox7" runat="server" Text="R6" /><br />
                <asp:CheckBox ID="RelayEn8" runat="server" Text="R3" />
                <asp:CheckBox ID="RelayBox8" runat="server" Text="R7" /><br />
            </td>
                <td>
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
        </td></tr></table>

    </div>
    </form>
</body>
</html>
