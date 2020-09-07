<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IframeStartGame.aspx.cs" Inherits="RollPlayGame3._0.IframeStartGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            height: 100%;
            width: 100%;
        }

        #divInnerPage {
            position: absolute;
            height: 100%;
            width: 100%;    
        }
    </style>
    <script type="text/javascript" src="Jquery/jquery-3.4.1.js"></script>
</head>
<body >
    <audio id="StartMusic" src="" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.2;
    </script>
    <div id="divInnerPage">
        <iframe id="iframeMain" src="StartStoryOfTheFighter.aspx" style="height: 100%; width: 100%;" scrolling="no" onload="SetMusic();"></iframe>
    </div>
</body>
     <script type="text/javascript" src="IframeStartGameMusic.js"></script>
</html>
