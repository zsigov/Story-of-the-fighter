<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LevelUpp.aspx.cs" Inherits="RollPlayGame3._0.LevelUpp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            color: white;
            background-repeat: no-repeat;
            background-size: cover;
        }

        h1 {
            position: relative;
            left: 300px;
            top: 20px;
            color: royalblue;
        }

        .divLevelUpp {
            position: relative;
            left: 300px;
            top: 100px;
            width: 800px;
            height: 600px;
        }

        .divLevelUppCenter {
            position: absolute;
            left: 250px;
            top: 0px;
        }

        .TextBoxCharacterAtributes {
            width: 40px;
        }

        .ImageButtonPlus {
            width: 30px;
            height: 30px;
            outline: none;
        }

        .ImageButtonMinus {
            width: 30px;
            height: 30px;
            outline: none;
        }

        .divRemainingPoints {
            position: absolute;
            left: 600px;
            top: 80px;
        }

        p {
            font-size: larger;
            font-family: Arial;
        }

        .divContinueGame {
            position: absolute;
            left: 270px;
            top: 250px;
            width: 200px;
            height: 200px;
        }

        .ButtonContinueGame {
            display: inline-block;
            border-radius: 50%;
            width: 200px;
            height: 99px;
            background-color: azure;
            text-align: center;
            outline: none;
        }

            .ButtonContinueGame:hover {
                background-color: #00b3b3;
                transform: translateY(5px);
            }
    </style>
</head>
<body style="background-image:url('Images/Backgrounds/LevelUppBackgroung.jpg'); width: 1587px;"; >
  <!--  <audio src="Music/LevelUpp.mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.05;
    </script>-->
    <form id="form1" runat="server">
        <h1>You have levelled upp. Distribute your skillpoints carefully.</h1>
        <br />
        <div class="divLevelUpp">
            <img src="Images/CharacterPictures/Fighter.jpg" />
            <div class="divLevelUppCenter" >
                <table>
                        <tr>
                           <td>
                             Name:
                           </td>
                           <td>
                            <asp:Label ID="LabelCharacterName" runat="server" Text="Label"></asp:Label>
                           </td>
                        </tr>
                        <tr>
                           <td>
                            New level:
                           </td>
                           <td>
                            <asp:Label ID="LabelCharacterLevel" runat="server" Text="Label"></asp:Label>
                           </td>
                        </tr>
                </table>
                <table>        
                    <tr>
                        <td>
                            AP:
                        </td>
                        <td>
                            <asp:ImageButton class="ImageButtonMinus" ID="ImageButtonMinusAP" runat="server" src="Images/Icons/BlueWhiteMinus.png" OnClick="ImageButtonMinusAP_Click"/>
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBoxCharacterAtributes" ID="TextBoxAP" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton CssClass="ImageButtonPlus" ID="ImageButtonPlusAp" runat="server" src="Images/Icons/BlueWhitePlus.png" OnClick="ImageButtonPlusAp_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            DP:
                        </td>
                        <td>
                            <asp:ImageButton CssClass="ImageButtonMinus" ID="ImageButtonMinusDP" runat="server" src="Images/Icons/BlueWhiteMinus.png" OnClick="ImageButtonMinusDP_Click"/>
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBoxCharacterAtributes" ID="TextBoxDP" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton CssClass="ImageButtonPlus" ID="ImageButtonPlusDP" runat="server" src="Images/Icons/BlueWhitePlus.png" OnClick="ImageButtonPlusDP_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           HP:
                        </td>
                        <td>
                             <asp:ImageButton CssClass="ImageButtonMinus" ID="ImageButtonMinusHP" runat="server" src="Images/Icons/BlueWhiteMinus.png" OnClick="ImageButtonMinusHP_Click" />
                        </td>
                        <td>
                            <asp:TextBox CssClass="TextBoxCharacterAtributes" ID="TextBoxHP" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <asp:ImageButton CssClass="ImageButtonPlus" ID="ImageButtonPlusHP" runat="server" src="Images/Icons/BlueWhitePlus.png" OnClick="ImageButtonPlusHP_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Luck:
                        </td>
                        <td>
                            <asp:ImageButton CssClass="ImageButtonMinus" ID="ImageButtonMinusLuck" runat="server"  src="Images/Icons/BlueWhiteMinus.png" OnClick="ImageButtonMinusLuck_Click"/>
                        </td>
                        <td>
                             <asp:TextBox CssClass="TextBoxCharacterAtributes" ID="TextBoxLuck" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton CssClass="ImageButtonPlus" ID="ImageButtonPlusLuck" runat="server" src="Images/Icons/BlueWhitePlus.png" OnClick="ImageButtonPlusLuck_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="divRemainingPoints">
                <p>Remaining points:<asp:TextBox Width="20px" ID="TextBoxRemainingPoints" runat="server" Font-Bold="true"></asp:TextBox></p>
                
            </div>

            <div class="divContinueGame">
            <asp:Button cssclass="ButtonContinueGame" ID="ButtonContinueGame" runat="server" Text="Confirm and Continue Game" Font-Bold="true" OnClick="Button1_Click" visible="false"/>
                </div>
        </div>
    </form>
</body>
</html>
