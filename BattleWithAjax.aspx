<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BattleWithAjax.aspx.cs" Inherits="RollPlayGame3._0.BattleWithAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Battle</title>
    <link rel="stylesheet" href="BattleWithAjax.css" />
    <script src="Jquery/jquery-3.4.1.js"></script>
    <script src="Jquery/jquery-ui-1.12.1/jquery-ui.js"></script>

    <!--Javasript page to handel the site-->
    <script type="text/javascript" src="BattleWithAjaxResponse1.js"></script>
</head>

<body style="background-image:url(Images/Backgrounds/BattleCave.jpg)";>
    <audio src="Music/Aggression_David_Fesliyan.mp3" id="audMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("audMusic");
        audio.volume = 0.05;
    </script>
    <form id="form1" runat="server">

        <h1>You was attacked! Defend yourselve</h1>
        <!---------------------------------------Player Charcter Display DIV---------------------------->
        <div  class="divPlayerCharacter">
        <asp:Image ID="PlayerImage" runat="server" Height="230px" ImageUrl="~/Images/CharacterPictures/Fighter.jpg" Width="155px" align="left"/>
        <table id="tblPlayer">

            <tr>
                <td colspan="2">
                    <asp:Label CssClass="label1" ID="LabelCharctersName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="label2" ID="LabelCharactersLevel" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label CssClass="label2" ID="LabelCharacterXP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                 <tr>
                <td>
                    AP: 
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterAP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                   DP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterDP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                   HP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterHP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                  <td>
                    Luck
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterLuck" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
                  <tr>
                <td>
                 Weapon:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelWeaponName" runat="server" Text="Label"></asp:Label>
                </td>
                  <td>
                    <asp:Label CssClass="label1" ID="LabelWeaponAttackPoint" runat="server" Text="Label"></asp:Label>
                </td>
                      <td>
                          <asp:Label CssClass="label1" ID="LabelWeaponDamage" runat="server" Text="Label"></asp:Label>
                      </td>
            </tr>
                  <tr>
                <td>
                  Shield: 
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelShieldName" runat="server" Text="Label"></asp:Label>
                </td>
                      <td>
                          <asp:Label CssClass="label1" ID="LabelShieldDefensePoint" runat="server" Text="Label"></asp:Label>
                      </td>
            </tr>
             <tr>
                <td>
                  Armour: 
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelArmourName" runat="server" Text="Label"></asp:Label>
                </td>
                 <td>
                     <asp:Label CssClass="label1" ID="LabelArmourDMGReduction" runat="server" Text="Label"></asp:Label>
                      </td>
            </tr>
        </table>
            </div>
        <!--------------------------------------Divs for display and control fight------------------------------------------------------>

        <div id="DivDisplayFight" class="DivsDisplayedOnFightPage" runat="server"></div>
        <div id="DivDisplayControlPanel" class="DivsDisplayedOnFightPage" runat="server"></div>
        <div id="DivFinishBattle" hidden="hidden"></div>
  
        <!---------------------------------Enemy 1 Display Div----------------------------------->
   <div class="divEnemie">
   <table id="tblEnemey">
            <tr>
                <td colspan="2">
                    <asp:Label CssClass="label1" ID="LabelEnemy1Name" runat="server" Text="Label"></asp:Label>
                </td>   
            </tr>
                 <tr>
                <td>
                    AP: 
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelEnemy1AP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                  DP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelEnemy1DP" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td id="tdEnemyHP">
                    HP:
                </td>
                <td>
                    <asp:Label ID="LabelEnemy1HP" CssClass="label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                   DMG:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelEnemy1Damage" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </table> 
       <asp:Image ID="ImageEnemy1" runat="server" Height="200px" Width="184px"  />
        <br />
       <br />
       <br />
        </div>
    </form>
</body>
</html>
