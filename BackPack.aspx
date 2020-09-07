<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackPack.aspx.cs" Inherits="RollPlayGame3._0.BackPack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
            body {
    background-repeat: no-repeat;
    background-size: cover;
}
        .button1 {
            display: inline-block;                   
            border-radius: 50%;
            width: 150px;
            height: 70px;
            background-color: azure;
            outline: none;
        }

            .button1:hover {
                background-color: #00b3b3;
                 transform: translateY(5px);
                  
            }
          </style> 
</head>
<body
   style="background-image:url(Images/Backgrounds/Backpackbeckground.jpg)"; >
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="BackpackItems" AutoPostBack="true" runat="server" 
                OnSelectedIndexChanged="BackpackItems_SelectedIndexChanged" Width="200px" Height="150px"></asp:ListBox>
            <br />
            <br />
            <asp:GridView ID="ItemPropertyies" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" align="left" Height="16px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="button1" ID="ButtonUseEquipment" runat="server" Text="USE EQUIPMENT" OnClick="UseEquipment" />

            <br />
&nbsp;&nbsp;&nbsp
            <asp:Label ID="UsedEquipment" runat="server" Text="UsedEquipment" Visible="false" Font-Bold="true" ForeColor="White"></asp:Label>

        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button CssClass="button1" ID="ButtonBackToGame" runat="server" Text="CLOSE STASH" OnClick="BackToGame"  />
    </form>
</body>
</html>
