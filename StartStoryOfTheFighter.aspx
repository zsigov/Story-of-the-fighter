
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartStoryOfTheFighter.aspx.cs" Inherits="RollPlayGame3._0.StartStoryOfTheFighter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StartStoryOfTheFighter.css" />
    <script src="Jquery/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="StartStoryOfTheFighter.js" ></script>
</head>

<body><!--
    <audio src="Music/In_The_Clouds_David_Fesliyan.mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.05;
    </script>-->
    
    <form id="form1" runat="server" visible="True">

        <img src="Images/CharacterPictures/Fighter.jpg" />
        <div id="divPlayerAttributes">
            <table>
                <tr>
                    <td>Name: 
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblCharacterName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>AP:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblAttackPoint" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>DP: 
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblDefensePoint" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>HP:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblHealthPoint" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Luck: 
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblLuck" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divLevelXPEquipments">
            <table>
                <tr>
                    <td>Level:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblLevel" runat="server"></asp:Label>
                    </td>
                    <td rowspan="2">
                        <asp:ImageButton ID="BackPackButton" runat="server" OnClick="BackPack_Click" ImageUrl="~/Images/EquipmentPictures/BackPack.jpg" />
                    </td>
                </tr>
                <tr>
                    <td>XP:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblXP" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div id="divPlayerWeapons">
            <table>
                <tr>
                    <td>Weapon: 
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblWeaponName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblWeaponAttackPoint" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblWeaponDMG" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Shield:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblShieldName" runat="server"></asp:Label>
                    </td>
                    <td></td>
                    <td>
                        <asp:Label Class="label" ID="lblShieldDefense" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Armour:
                    </td>
                    <td>
                        <asp:Label Class="label" ID="lblArmourName" runat="server"></asp:Label>
                    </td>
                    <td></td>
                    <td>
                        <asp:Label Class="label" ID="lblDamageReduction" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>

        <div id="DivStoryDisplay">
            <asp:TextBox Class="label" ID="StoryText" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

            <asp:RadioButtonList ID="StoryCoiceList" runat="server" OnSelectedIndexChanged="StoryCoiceList_SelectedIndexChanged">
            </asp:RadioButtonList>


            <div id="divFunctionButtons">
                <asp:Button ID="ButtonBeginFight" runat="server" OnClick="ButtonBeginFight_Click" Text="BEGIN FIGHT" Visible="false" class="buttonBaseControll" />
                <asp:Button ID="DoIt" runat="server" OnClick="DoIt_Click" Text="--DO IT--" class="buttonBaseControll" />
                <asp:Button ID="SaveGame" runat="server" OnClick="SaveGame_click" Text="--SAVE GAME--" class="buttonBaseControll" />
                <asp:Button ID="QuitGame" runat="server" OnClick="QuitGame_click" Text="--QUIT GAME--" class="buttonBaseControll" />
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="False" bold="true" Font-Underline="true"></asp:Label>
            </div>

            <br />
           <!-- <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox> -->
        </div>



    </form>

</body>
</html>
