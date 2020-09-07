<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestPage.aspx.cs" Inherits="RollPlayGame3._0.RestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-repeat: no-repeat;
            background-size: cover;
        }

        .RestTitel {
            position: fixed;
            left: 25%;
            color: white;
        }

        .Center {
            position: fixed;
            top: 30%;
            width: 100%;
            height: 400px;
        }

        .Button1 {
            position: absolute;
            left: 40%;
            font-size: large;
            display: inline-block;
            border-radius: 50%;
            width: 200px;
            height: 99px;
            background-color: azure;
            outline: none;
        }

            .Button1:hover {
                background-color: #00b3b3;
                transform: translateY(5px);
            }

        .Label1 {
            color: white;
            font-family: Arial;
            font-size: x-large;
            position: absolute;
            left: 25%;
            top: 30%;
            width: 50%;
        }
    </style>
    <script src="Jquery/jquery-3.4.1.js"></script>
    <script src="Jquery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <script src="RestPage.js" type="text/javascript"></script>
</head>
<body style="background-image:url(Images/Backgrounds/REST.jpg)"; >
    <audio src="Music/Heavens Lullaby (Beautiful Piano Song).mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.05;
    </script>
    <form id="form1" runat="server">
        <div class="RestTitel">
            <h1>You decided to take some rest before you continue your journey.</h1>
        </div>
        <div class="Center">
            <input class="Button1" type="button" id="ButtonRest" value="REST" onclick='javascript: Rest()' />
            <asp:Button CssClass="Button1" ID="ButtonContinue" runat="server" Text="CONTINUE" OnClick="ButtonRest_Click" hidden="hidden" ClientIDMode="Static"/>
            <br/>
            <label  class="Label1" id="LabelRest" hidden="hidden" >label</label>    
        </div>
        
    </form>
</body>
</html>
