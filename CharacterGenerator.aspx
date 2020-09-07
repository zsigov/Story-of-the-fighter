<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharacterGenerator.aspx.cs" Inherits="RollPlayGame3._0.CharacterGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>

        #lblGetName {
            padding-left:7px;
            letter-spacing: 0.1em;
        }
        .button1 {
            display: inline-block;
            border-radius: 50%;
            width: 160px;
            height: 79px;
            background-color: azure;
            outline: none;
        }

            .button1:hover {
                background-color: #00b3b3;
                transform: translateY(5px);
            }
        p {
            font-size: 30px;
            color: ghostwhite
        }

        h1 {
            font-size: 50px;
            color: ghostwhite
        }

        .second {
            text-align: right;
        }
    </style>

    <title></title>
</head>
<body style="background-image: url(Images/Backgrounds/Legends-Of-Troy-Wallpaper.jpg);">
    <form id="form1" runat="server">
        <div>

            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="MVGenerator1" runat="server">
                    <h1 style="color: white">Character Generator</h1>
                    <p style="color: white;">Enter character's name:<asp:TextBox ID="lblGetName" runat="server" MaxLength="12"  Height="25px" Width="200px" Font-Bold="true" BorderStyle="Double" ForeColor="#003300"></asp:TextBox>
                    </p>
                    <asp:Button class="button1" ID="Generate" runat="server" Text="Generate" Height="50" Width="200"
                        Style="font-family: 'Monotype Corsiva'; font-size: large; color: black" Font-Bold="true" OnClick="GoToGenerator2" />
                    <br />
                    <asp:Label ID="lblFalseCharacterName" runat="server" Visible="false" Height="25px" Font-Size="Large"></asp:Label>
                </asp:View>
                <asp:View ID="MVGenerator2" runat="server">

                    <h1>Your Characters Attributes:</h1>
                    <table>
                        <tr>
                            <td>
                                <p>Name:</p>
                            </td>
                            <td class="second">
                                <p>
                                    <asp:Label ID="lblCharacterName" runat="server"></asp:Label>
                                    <p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Attack Point:</p>
                            </td>
                            <td class="second">
                                <p>
                                    <asp:Label ID="lblAttackPoint" runat="server"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Defense Point:</p>
                            </td>
                            <td class="second">
                                <p>
                                    <asp:Label ID="lblDefensePoint" runat="server"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Health Point:</p>
                            </td>
                            <td class="second">
                                <p>
                                    <asp:Label ID="lblHealthPoint" runat="server"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Luck: </p>
                            </td>
                            <td class="second">
                                <p>
                                    <asp:Label ID="lblLuck" runat="server"></asp:Label>
                                </p>
                            </td>
                        </tr>
                    </table>

                    <br />
                    <br />

                    <asp:Button CssClass="button1" ID="RETRY" Text="RETRY" runat="server" Height="50" Width="200"
                        Style="font-family: 'Monotype Corsiva'; font-size: large; color: black" Font-Bold="true" OnClick="GoToGenerator2" />
                    &nbsp&nbsp&nbsp&nbsp
                      <asp:Button CssClass="button1" ID="SaveAndStart" runat="server" Font-Bold="true" Height="50" Width="200" OnClick="SaveAndStartGame"
                          Style="font-family: 'Monotype Corsiva'; font-size: large; color: black" Text="Save &amp; Start Game" />
                </asp:View>
            </asp:MultiView>
        </div>
        <p>
            &nbsp;
        </p>
    </form>
</body>
</html>
