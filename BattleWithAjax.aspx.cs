using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Text;

namespace RollPlayGame3._0
{
    //This page is the initial page when fight starts.
    public partial class BattleWithAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get player1 and display his data into page.
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            DisplayCharactersAttributes(player1);

            //Get enemy and display his data into page.
            DisplayEnemyAtributes(GetEnemyAtributes());
            Character Enemy = (Character)Session["Enemy"];

            //Display Start Fight button.
            if (!IsPostBack)
            {
                DivDisplayFight.InnerHtml = "<input type='button' id='btnStartFight' value='Start Fight' onClick='javascript: StartFight()' />";
                BuildControlPanelHTML();
            }
            Session["RoundNumber"] = 0;
        }

        private void DisplayCharactersAttributes(PlayerCharacter player1)
        {
            LabelCharctersName.Text = player1.Name;
            LabelCharactersLevel.Text = "Level: " + player1.Level.ToString();
            LabelCharacterXP.Text = "XP: " + player1.XP.ToString();
            LabelCharacterAP.Text = (player1.AttackPoint + player1.MyWeapon.AttackPoint).ToString();
            LabelCharacterDP.Text = (player1.DefensePoint+ player1.MyShield.DefensePoint).ToString();
            LabelCharacterHP.Text = player1.MaxHealthPoint.ToString() + "/" + player1.ActualHealthPoint.ToString();
            LabelCharacterLuck.Text = player1.Luck.ToString();
            LabelWeaponName.Text = player1.MyWeapon.Name;
            LabelWeaponAttackPoint.Text = "AP: " + player1.MyWeapon.AttackPoint.ToString();
            LabelWeaponDamage.Text = "DMG: " + player1.MyWeapon.WeaponDamage.ToString();
            LabelShieldName.Text = player1.MyShield.Name;
            LabelShieldDefensePoint.Text = "DP:" + player1.MyShield.DefensePoint.ToString();
            LabelArmourName.Text = player1.MyArmour.Name;
            LabelArmourDMGReduction.Text = "DMGRed: " + player1.MyArmour.DamageReduction.ToString();
        }

        private void DisplayEnemyAtributes(Character enemy)
        {
            if (enemy.Alive)
            {
                LabelEnemy1Name.Text = enemy.Name;
                LabelEnemy1AP.Text = enemy.AttackPoint.ToString();
                LabelEnemy1DP.Text = enemy.DefensePoint.ToString();
                LabelEnemy1HP.Text = enemy.MaxHealthPoint.ToString() + "/" + enemy.ActualHealthPoint.ToString();
                LabelEnemy1Damage.Text = enemy.MyWeapon.WeaponDamage.ToString();
            }
        }

        private Character GetEnemyAtributes()
        {
            int enemyID = -1;
            Character enemy = new Character();
            string ConnString = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetCheckPointEnemies", con);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@StoryCheckpoint", Session["StoryCheckPointID"]);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    enemyID = (int)row["Enemies_ID"];
                }
            }

            string ConnString1 = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnString1))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetEnemyAtributes", con);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@EnemyID", enemyID);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    enemy.Name = (string)row["Name"];
                    enemy.AttackPoint = (int)row["Attack"] + (int)row["AP"];
                    enemy.DefensePoint = (int)row["Defense"];
                    enemy.MaxHealthPoint = (int)row["HP"];
                    enemy.ActualHealthPoint = enemy.MaxHealthPoint;
                    enemy.MyWeapon = new Weapon((string)row["Name"], (int)row["HPModifier"], (int)row["AP"]);
                    switch ((int)row["ID"])
                    {
                        case 1:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/Goblin.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/Goblin.jpg";
                            break;
                        case 2:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/evil_giant_bat.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/evil_giant_bat.jpg";
                            break;
                        case 3:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/weakgolem.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/evil_giant_bat.jpg";
                            break;
                        case 4:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/stronggolem.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/stronggolem.jpg";
                            break;
                        case 5:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/Goblin Shaman.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/Goblin Shaman.jpg";
                            break;
                        case 6:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/Goblin Guard.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/Goblin Guard.jpg";
                            break;
                        case 7:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/HumanMage.png";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/HumanMage.png";
                            break;
                        case 8:
                            ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/Red Dragon.jpg";
                            Session["EnemyImageURL"] = "~/Images/EnemyPictueres/Red Dragon.jpg";
                            break;
                    }
                }
                Session["Enemy"] = enemy;
                return enemy;
            }
        }

        //Build the full Div of DivDisplayControlPanel on server side.
        public void BuildControlPanelHTML()
        {
            StringBuilder myInnerHtml = new StringBuilder();
            myInnerHtml.Append("<table id='tblControlPanel'><tr><td colspan = '2'>CONTROLPANEL</td ></tr >");
            myInnerHtml.Append("<tr><td colspan = '2'><input type ='button' id ='btnStopFight' value ='Stop Fight' onclick='javascript: ButtonClicked()' disabled /></td></tr>");
            myInnerHtml.Append("<tr><td colspan='2'><label id = 'lblStopButtonMSG'></label></td></tr>");
            myInnerHtml.Append("<tr><td colspan = '2'>FIGHT SPEED</td></tr>");
            myInnerHtml.Append("<tr><td><input type='button' id='btnSpeedUp' onclick='SpeedUpp()' value='+' disabled/></td><td><input type='button' id='btnSlowDown' onclick='SlowDown()' value='-' disabled /></td></tr>");
            myInnerHtml.Append("<tr><td>&nbsp<td></tr></table>");

            DivDisplayControlPanel.Controls.Add(new Literal { Text = myInnerHtml.ToString() });
        }
    }
}