<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LuckWiev.aspx.cs" Inherits="RollPlayGame3._0.LuckWiev" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
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

            .button2:hover{
                 transform: translateY(5px);
            }

            .label1{
                color:white;
                font-family:'Monotype Corsiva';
                font-size:xx-large;             
            }
               h1 {
            font-size: 50px;
            color: white
        }
         .auto-style1 {
            color: white;
            font-family: 'Monotype Corsiva';
            font-size: xx-large;
            margin-left: 13px;
        }
        .auto-style2 {
            color: white;
            font-family: 'Monotype Corsiva';
            font-size: xx-large;
            margin-left: 0px;
            text-align:center;
        }
         </style>
</head>
<body style="background-image: url(Images/Backgrounds/LuckRoll.jpg)">
    <form id="form1" runat="server">
        <div>
            <br />
            <h1>You need to try your luck! Your character's luck value is:&nbsp; <asp:Label ID="LabelPlayerLuckValue" runat="server" Text="Label"></asp:Label></h1>
            
            <br />
            <br />
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
 <asp:ImageButton CssClass="button2" ID="ImageButtonLuckRoll1" runat="server" ImageUrl="Images/Dice%20pictures/LuckDice2.jpg" Width="85px" Height="85px" OnClick="ImageButtonLuckRoll1_Click" />" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:ImageButton CssClass="button2" ID="ImageButtonLuckRoll2" runat="server" ImageUrl="~/Images/Dice pictures/LuckDice2.jpg" Height="85px"  Width="85px" OnClick="ImageButtonLuckRoll2_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox CssClass="auto-style2" ID="LabelLuckRoll1" runat="server" Text="TextBox" ReadOnly="true" Width="167px" Rows="2" Font-Bold="True" Font-Size="Large" ForeColor="Red" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox CssClass="auto-style2" ID="LabelLuckRoll2" runat="server" Text="TextBox" ReadOnly="true" Width="168px" Rows="2" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label CssClass="label1" ID="LabelResult3" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button CssClass="button1" ID="ButtonContinueGame" runat="server" Text="Continue Game" OnClick="ButtonContinueGame_Click"/>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
