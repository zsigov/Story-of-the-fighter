<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="RollPlayGame3._0.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>
        body{
            background: url(Images/Backgrounds/Wallpaper-Nick-Deligaris-Ultimate-Fighter.jpg);
            padding: 0px;
            background-repeat: no-repeat;
            background-size: cover;
            height: 100%;
            width: 100%; 
        }
        .button1 {
            display: inline-block;
            border-radius: 50%;
            width: 160px;
            height: 79px;
            background-color: azure;
            outline:none;
        }

            .button1:hover {
                background-color: #00b3b3;
                transform: translateY(5px);
            }

            .button1:active {
            }
    </style>

    <title></title>

</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <form id="form1" runat="server">
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="button1" ID="Button1" runat="server" Text="START GAME" Height="100" Width="200"
                Style="font-family: 'Monotype Corsiva'; font-size: large; color: Black"
                BorderStyle="Double" Font-Bold="True" Font-Italic="False" Font-Size="Larger" Font-Strikeout="False" OnClick="StartGame" />
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button class="button1" ID="Button3" runat="server" Text="LOAD GAME" Height="100" Width="200"
                Style="font-family: 'Monotype Corsiva'; font-size: large; color: Black"
                BorderStyle="Double" Font-Bold="True" Font-Italic="False" Font-Size="Larger" Font-Strikeout="False" OnClick="LoadGame" />
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button class="button1" ID="Button2" runat="server" Text="QUIT" Height="100" Width="200"
                Style="font-family: 'Monotype Corsiva'; font-size: large; color: Black"
                BorderStyle="Double" Font-Bold="True" Font-Italic="False" Font-Size="Larger" Font-Strikeout="False" OnClick="QuitGame" />
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>   
        <div>
        </div>
    </form>
</body>
</html>
