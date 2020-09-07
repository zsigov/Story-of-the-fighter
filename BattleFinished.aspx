<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BattleFinished.aspx.cs" Inherits="RollPlayGame3._0.BattleFinished" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-repeat: no-repeat;
            background-size: cover;
        }

        h1 {
            position: fixed;
            left: 550px;
            color: navajowhite;
            font-size: xx-large;
            font-family: 'Times New Roman', Times, serif;
            outline: none;
        }

        .PlayerCharacter {
            position: fixed;
            left: 150px;
            top: 110px;
        }

        .Message {
            position: fixed;
            left: 550px;
            top: 110px;
        }

        .Enemi {
            position: fixed;
            left: 1200px;
            top: 110px;
        }

        .button2 {
            display: inline-block;
            border-radius: 50%;
            width: 200px;
            height: 99px;
            background-color: black;
            color: white;
            font-size: large;
            font-family: Arial;
            outline: none;
        }

            .button2:hover {
                background-color: #ffffff;
                color: black;
                transform: translateY(5px);
            }

        .LabelInitiation {
            font-size: x-large;
            font-family: 'Monotype Corsiva';
            color: white;
            position: center;
        }
    </style>
</head>


<body style="background-image:url('Images/Backgrounds/BattleCave.jpg'); height: 968px;";>
    <audio src="Music/Pirate_Dance_David_Fesliyan.mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.05;
    </script>
    <form id="form1" runat="server">

        <h1>The battle has ended</h1>

        <!---------------------------------------Player Charcter Display DIV---------------------------->
        <div  class="PlayerCharacter">
            <asp:Image ID="ImagePlayer" runat="server" Height="230px" Width="155px"/>
        </div>

        <!---------------------------------Div Initiation and Attack------------------------------------------>

        <div class="Message">
                <asp:Label CssClass="LabelInitiation" ID="LabelLineFirst" runat="server" Text="Label" Visible="false"></asp:Label>
                <br/>
                <br/>
                <br/>
                <asp:Label CssClass="LabelInitiation" ID="LabelLineSecound" runat="server" Text="Label" Visible="false"></asp:Label>
                <br/>
                <br/>
                <br/>
            <div class="Center">      
                <asp:Button Class="button2" ID="ButtonContinueGame" runat="server" Text="Continue Game" OnClick="ButtonContinueGame_Click" visible="false"/>
            </div>
        </div>



        <!---------------------------------Enemy 1 Display Div----------------------------------->
   <div class="Enemi">
       <asp:Image ID="ImageEnemy1" runat="server" Height="200px" Width="184px"  />
   </div>

        </form>
</body>
</html>
