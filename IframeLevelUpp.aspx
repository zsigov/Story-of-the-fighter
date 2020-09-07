<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IframeLevelUpp.aspx.cs" Inherits="RollPlayGame3._0.LevelUppFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <audio src="Music/LevelUpp.mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.5;
    </script>
    <form id="form1" runat="server">
        <div style="position: absolute; height: 100%; width: 100%;">        
            <iframe src="LevelUpp.aspx" style="height: 100%; width: 100%;"></iframe>
        </div>
    </form>
</body>
</html>
