<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASPRepeaterSample.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="display: flex; flex-direction: row; width: 100%">
            <asp:Label runat="server" ID="lblmsg" Visible="false"
                Style="padding: 4px; margin: 0px auto; background-color: #ccf3cd; color: #095a53; border-radius: 5px; width: 200px; margin-bottom: 10px; text-align: center; border: 1px solid #17a91b;"></asp:Label>
        </div>
        <div style="display: flex; justify-content: space-evenly;">

            <div style="display: flex; flex-direction: column; align-items: baseline; background-color: azure; border: 1px solid #0094ff; padding: 10px">


                <asp:Repeater runat="server" ID="repeater">
                    <ItemTemplate>

                        <label>
                            Name :
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox></label>

                        <label>
                            Status :
                    <asp:CheckBox runat="server" ID="chkIsActive" Checked="false" />
                        </label>

                    </ItemTemplate>
                </asp:Repeater>

                <asp:Button runat="server" ID="btnSave" Text="Save One" OnClick="btnSave_Click" Style="padding: 5px; width: 100%; background-color: #22668b; color: aliceblue; border: 0; margin-top: 20px; margin-right: 10px;" />
            </div>

            <div style="display: flex; flex-direction: column; align-items: baseline; background-color: #e4f9e4; border: 1px solid #009688; padding: 10px">
                <asp:Repeater runat="server" ID="repeater1">
                    <ItemTemplate>

                        <label>
                            Name :
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox></label>

                        <label>
                            Status :
                    <asp:CheckBox runat="server" ID="chkIsActive" Checked="false" />
                        </label>

                    </ItemTemplate>
                </asp:Repeater>

                <asp:Button runat="server" ID="btnSave2" Text="Save multiple" OnClick="btnSave2_Click" Style="padding: 5px; width: 100%; background-color: forestgreen; color: aliceblue; border: 0; margin-top: 20px" />
            </div>



            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
        </div>


    </form>
</body>
</html>
