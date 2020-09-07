<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadGame1.aspx.cs" Inherits="RollPlayGame3._0.LoadGame1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
         body {
            background-repeat: no-repeat;
            background-size: cover;
        }
       .button1 {
            display: inline-block;                   
            border-radius: 50%;
            width: 160px;
            height: 79px;
            background-color: azure;
            outline: none;
        }

            .button1:hover {
                background-color: #00b3b3;
                 transform: translateY(5px);
                  
            }
    </style>

    <title></title>
</head>
<body style="background-image:url(Images/Backgrounds/LoadGame.jpg)"; >
    <form id="form1" runat="server">
        <div>

          &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="233px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" align="left" Width="161px"></asp:ListBox>

            <br />

           &nbsp;&nbsp;

         <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" style="margin-right: 2px">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
          </asp:GridView>   

            &nbsp;

            <br />
           
            <br />
          &nbsp&nbsp&nbsp&nbsp&nbsp  <asp:Button   class="button1" ID="LoadCharacter" runat="server" text="LOAD GAME" Height="50" Width="200"
                      style="font-family:'Monotype Corsiva'; font-size:large; color:black" Font-Bold="true" OnClick="LoadGame_Click" />
             <br />     
            &nbsp&nbsp&nbsp&nbsp&nbsp <asp:Label ID="label1" runat="server" Enabled="false"></asp:Label>
           

        </div>
    </form>
</body>
</html>
