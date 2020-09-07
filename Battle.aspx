<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Battle.aspx.cs" Inherits="RollPlayGame3._0.Battle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h1 {
            position:fixed;
            left:400px;
            color: navajowhite;   
            font-size: xx-large;
            font-family: 'Times New Roman', Times, serif;
            outline: none;
        }

        .auto-style1 {
            height: 1024px;
            width: 1625px;
        }

        h5 {
            color: white
        }

        p {
            color: white
        }
        td{
            color:white
        }

        .label1 {
            color: white;      
        }
        .label2{
            color:white;
            text-align:center;
        }

        .PlayerCharacter {
            position: fixed;
            top: 100px;
            left: 20px;
            float: left;
            width: 500px;
            margin-top: 0px
        }

        .Enemies {
            position: fixed;
            top: 100px;
            left: 1020px;
            width: 400px;
            height: 220px;
            margin-top: 0px
        }

        .Enemies2 {
            position: fixed;
            top: 330px;
            left: 1020px;
            width: 400px;
            height: 220px;    
            margin-top: 0px
        }

        .Enemies3 {
            position: fixed;
            top: 560px;
            left: 1020px;
            width: 400px;
            height: 220px;
            margin-top: 0px
        }

        .Initiation {
            position: relative;
            top: 70px;
            left: 550px;
            width: 20%;
            height: 20%;           
            margin-top: 0px       
        }
        .Center{
            position: absolute;
            left: 0;
            top: 30%;
            width: 70%;
            text-align: center;
            font-size: 18px;
        }
        .Attack{
            position: relative;
            top: 50px;
            left: 550px;
            width: 20%;
            height: 20%;           
            margin-top: 0px
        }
        .NewRound{
            position: relative;
            top: 50px;
            left: 550px;
            width: 20%;
            height: 20%;           
            margin-top: 0px
        }
        .button1{
            display: inline-block;
            border-radius: 50%;
            width: 160px;
            height: 79px;
            background-color: azure;
            font-size:x-large;
            font-family:Arial;
                
        }
        .button1:hover{
            background-color: #00b3b3;
            transform: translateY(5px);
        }

        .button2{
                display: inline-block;
            border-radius: 50%;
            width: 200px;
            height: 99px;
            background-color: black;
            color:white;
            font-size:large;
            font-family:Arial;
        }
        .button2:hover{
            background-color: #ffffff;
            color:black;
            transform: translateY(5px);
        }

        .LabelInitiation{
            font-size:x-large;
            font-family:'Monotype Corsiva';
            color:white; 
            position:center;
        }
        .auto-style2 {
            position: relative;
            top: 50px;
            left: 550px;
            width: 20%;
            height: 20%;
        }
    </style>
</head>


<body style="background-image:url(Images/Backgrounds/BattleCave.jpg)";>
    <audio src="Music/Aggression_David_Fesliyan.mp3" id="StartMusic" controls="controls" autoplay="autoplay" hidden="hidden"></audio>
    <script>
        var audio = document.getElementById("StartMusic");
        audio.volume = 0.05;
    </script>
    <form id="form1" runat="server" class="auto-style1">

        <h1>You was attacked! Defend yourselve</h1>
        <!---------------------------------------Player Charcter Display DIV---------------------------->
        <div  class="PlayerCharacter">
        <asp:Image ID="Image1" runat="server" Height="230px" ImageUrl="~/Images/CharacterPictures/Fighter.jpg" Width="155px" align="left"/>
        <Table >
            <tr>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharctersName" runat="server" Text="Label"></asp:Label>
                </td>
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
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterDP" runat="server" Text="Label"></asp:Label>
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
                   HP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelCharacterHP" runat="server" Text="Label"></asp:Label>
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
        </Table>
            </div>

        <!---------------------------------Div Initiation and Attack------------------------------------------>

        <div class="Initiation">
                <asp:Label CssClass="LabelInitiation" ID="LabelLineFirst" runat="server" Text="Label" Visible="false"></asp:Label>
                <br/>
                <br/>
                <br/>
                <asp:Label CssClass="LabelInitiation" ID="LabelLineSecound" runat="server" Text="Label" Visible="false"></asp:Label>
                <br/>
                <br/>
                <br/>
                <asp:Label CssClass="LabelInitiation" ID="LabelLineThird" runat="server" Text="Label" Visible="false"></asp:Label>
                <br/>
                <br/>
                <br/>
                <asp:Label CssClass="LabelInitiation" ID="LabelLineFourth" runat="server" Text="LabelAttackSecoundResult" Visible="false"></asp:Label>
            <div class="Center">
                <asp:Button Class="button1" ID="ButtonInitiation" runat="server" Text="Initiation" OnClick="ButtonInitiation_Click" visible="true"/>           
            </div>
        </div>

        <!--------------------------------------Div Attack------------------------------------------------------>

        <div class="auto-style2">
            <div class="Center">
                <asp:Button Class="button1" ID="ButtonFight" runat="server" Text="Fight" visible="false" OnClick="ButtonFight_Click"/>
            </div>
        </div>
        <!---------------------------------------Div Start New Round----------------------------------------------->

        <div class="NewRound">
            <div class="Center">
                <asp:Button Class="button1" ID="ButtonStartNewRound" runat="server" Text="New Round" visible="false" OnClick="StartNewRound"/>
            </div>
        </div>

        <!---------------------------------Enemy 1 Display Div----------------------------------->
   <div class="Enemies">
   <Table align="left">
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
                <td>
                    HP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="LabelEnemy1HP" runat="server" Text="Label"></asp:Label>
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
            </Table> 
       <asp:Image ID="ImageEnemy1" runat="server" Height="200px" Width="184px" />
        <br />
       <br />
       <br />
        </div>

        <!--------------------------------------------------Enemy 2 Display Div------------------------------------->
        
         <div class="Enemies2" hidden="hidden" >
   <Table align="left">
            <tr>
                <td colspan="2">
                    <asp:Label CssClass="label1" ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>   
            </tr>
                 <tr>
                <td>
                   AP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                    DP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                    HP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                  DMG:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </Table> 
       <asp:Image ID="Image2" runat="server" Height="200px" Width="184px" />
        <br />
       <br />
       <br />
        </div>

      <!---------------------------------Enemy 3 Display Div------------------------------------------------->
         <div class="Enemies3" hidden="hidden">
   <Table align="left" >
            <tr>
                <td colspan="2">
                    <asp:Label CssClass="label1" ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>   
            </tr>
                 <tr>
                <td>
                    AP: 
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                    DP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label8" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                  <tr>
                <td>
                     HP:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label9" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                   DMG:
                </td>
                <td>
                    <asp:Label CssClass="label1" ID="Label10" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </Table> 
       <asp:Image ID="Image3" runat="server" Height="200px" Width="184px" />
        <br />
       <br />
       <br />
        </div>
     
        </form>
</body>
</html>
