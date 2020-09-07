<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuitGame.aspx.cs" Inherits="RollPlayGame3._0.QuitGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-repeat: no-repeat;
            background-size: cover;
        }

        h1, h2 {
            color: white;
        }

        #divCenter {
            position: absolute;
            top: 30%;
            left: 33%;
            width: 55%;
        }
    </style>
</head>
<body style="background-image: url(Images/Backgrounds/QuitGamePicture.jpg)" />
<form id="form1" runat="server">
    <div id="divCenter">
        <h2>Your character and progress have been saved. </h2>
        <h2>You can close the browser window.</h2>
        <h1>GOODBYE!!!</h1>
    </div>
</form>
</body>
</html>
