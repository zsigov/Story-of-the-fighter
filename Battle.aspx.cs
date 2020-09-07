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


namespace RollPlayGame3._0
{
    public partial class Battle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character Enemy = (Character)Session["Enemy"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
          
                if (!IsPostBack)
                {
                    DisplayEnemyAtributes(GetEnemyAtributes());
                    Enemy = (Character)Session["Enemy"];
                }

            if (!(Enemy == null))
            {
                DisplayEnemyAtributes(Enemy);
            }
            if (!(player1 == null))
            {
                DisplayCharactersAttributes(player1);
            }
        }

        private void DisplayCharactersAttributes(PlayerCharacter player1)
        {
            LabelCharctersName.Text = player1.Name;
            LabelCharactersLevel.Text = "Level: " + player1.Level.ToString();
            LabelCharacterXP.Text = "XP: " + player1.XP.ToString();
            LabelCharacterAP.Text = player1.AttackPoint.ToString();
            LabelCharacterDP.Text = player1.DefensePoint.ToString();
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

        protected void ButtonInitiation_Click(object sender, EventArgs e)
        {
            ButtonInitiation.Visible = false;
            Random InitiativeRoll = new Random();

            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            player1.Initiation = InitiativeRoll.Next(1, 7);
            LabelLineFirst.Visible = true;
            LabelLineFirst.Text = "Your initiative: " + player1.Initiation.ToString();

            Character enemy = (Character)Session["Enemy"];
            enemy.Initiation = InitiativeRoll.Next(1, 7);
            LabelLineSecound.Visible = true;
            LabelLineSecound.Text = "Enemy's initiative: " + enemy.Initiation.ToString();

            if (player1.Initiation >= enemy.Initiation)
            {
                LabelLineThird.Visible = true;
                LabelLineThird.Text = "You start to attack!";
            }
            else
            {
                LabelLineThird.Visible = true;
                LabelLineThird.Text = "Your enemy starts to attack!";
            }
            ButtonFight.Visible = true;
            Session["player1"] = player1;
            Session["Enemy"] = enemy;
        }

        protected void ButtonFight_Click(object sender, EventArgs e)
        {
            ButtonFight.Visible = false;
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            Character enemy = (Character)Session["Enemy"];
            FightRoundBetweenCharacters(enemy, player1);
        }

        private void FightRoundBetweenCharacters(Character enemy, PlayerCharacter player1)
        {
            Random attackRoll = new Random();
            int player1AttackPoint = player1.AttackPoint + player1.MyWeapon.AttackPoint + attackRoll.Next(1, 7);
            int player1Defensepoint = player1.DefensePoint + player1.MyShield.DefensePoint;
            int enemyAttackpoint = enemy.AttackPoint + enemy.MyWeapon.AttackPoint + attackRoll.Next(1, 7);

            if (player1.Initiation >= enemy.Initiation)
            {
                if (player1AttackPoint >= enemy.DefensePoint)
                {
                    try
                    {
                        enemy.Damage(player1.MyWeapon.WeaponDamage - enemy.MyArmour.DamageReduction);
                    }
                    catch
                    {
                        enemy.Damage(player1.MyWeapon.WeaponDamage);
                    }
                    PlayerOrEnemyDied(enemy, player1);
                    LabelLineFirst.Visible = true;
                    LabelLineFirst.Text = "Your attackpoint: " + player1AttackPoint.ToString() + "&nbsp&nbsp&nbsp SUCCESFULL HIT!!!";
                    LabelLineSecound.Visible = true;
                    LabelLineSecound.Text = "Damage on enemy: " + player1.MyWeapon.WeaponDamage.ToString();

                    
                    if(player1.MyWeapon.Poisoned==true)
                    {
                        enemy.Poisoned = true;
                        enemy.PoisonDMGPerRound = player1.MyWeapon.PoisonDMG;
                        player1.MyWeapon.Poisoned = false;
                    }
                    if(enemy.Poisoned==true)
                    {
                        enemy.Damage(enemy.PoisonDMGPerRound);
                        LabelLineThird.Visible = true;
                        LabelLineSecound.Text = "Damage on enemy: " + player1.MyWeapon.WeaponDamage.ToString()+" + Poison Damage: " + enemy.PoisonDMGPerRound.ToString();
                    }
                }
                else
                {
                    LabelLineFirst.Visible = true;
                    LabelLineFirst.Text = "Your attackpoint: " + player1AttackPoint.ToString() + "<br/>MISS!!!";
                    LabelLineSecound.Visible = true;
                    LabelLineSecound.Text = "Damage on enemy: 0";

                    if (enemy.Poisoned == true)
                    {
                        enemy.Damage(enemy.PoisonDMGPerRound);
                        LabelLineThird.Visible = true;
                        LabelLineSecound.Text = "Damage on enemy: 0" + " + Poison Damage: " + enemy.PoisonDMGPerRound.ToString();
                    }
                }

                if (enemyAttackpoint > player1Defensepoint)
                {
                    player1.Damage(enemy.MyWeapon.WeaponDamage - player1.MyArmour.DamageReduction);
                    PlayerOrEnemyDied(enemy, player1);
                    LabelLineThird.Visible = true;
                    LabelLineThird.Text = "Enemy's attackpoint: " + enemyAttackpoint.ToString() + " SUCCESFULL HIT!!!";
                    LabelLineFourth.Visible = true;
                    LabelLineFourth.Text = "Damage on you: " + (enemy.MyWeapon.WeaponDamage - player1.MyArmour.DamageReduction).ToString();
                }
                else
                {
                    LabelLineThird.Visible = true;
                    LabelLineThird.Text = "Enemy's attackpoint: " + enemyAttackpoint.ToString() + "<br/>MISS!!!";
                    LabelLineFourth.Visible = true;
                    LabelLineFourth.Text = "Damage on you: 0";
                }
            }
            else
            {
                if (enemyAttackpoint > player1Defensepoint)
                {
                    player1.Damage(enemy.MyWeapon.WeaponDamage - player1.MyArmour.DamageReduction);
                    PlayerOrEnemyDied(enemy, player1);
                    LabelLineFirst.Visible = true;
                    LabelLineFirst.Text = "Enemy's attackpoint: " + enemyAttackpoint.ToString() + " SUCCESFULL HIT!!!";
                    LabelLineSecound.Visible = true;
                    LabelLineSecound.Text = "Damage on you: " + (enemy.MyWeapon.WeaponDamage - player1.MyArmour.DamageReduction).ToString();
                }
                else
                {
                    LabelLineFirst.Visible = true;
                    LabelLineFirst.Text = "Enemy's attackpoint: " + enemyAttackpoint.ToString() + "<br/>MISS!!!";
                    LabelLineSecound.Visible = true;
                    LabelLineSecound.Text = "Damage on you: 0";
                }
                if (player1AttackPoint >= enemy.DefensePoint)
                {
                    try
                    {
                        enemy.Damage(player1.MyWeapon.WeaponDamage - enemy.MyArmour.DamageReduction);
                    }
                    catch
                    {
                        enemy.Damage(player1.MyWeapon.WeaponDamage);
                    }
                    PlayerOrEnemyDied(enemy, player1);
                    LabelLineThird.Visible = true;
                    LabelLineThird.Text = "Your attackpoint: " + player1AttackPoint.ToString() + "&nbsp&nbsp&nbsp SUCCESFULL HIT!!!";
                    LabelLineFourth.Visible = true;
                    LabelLineFourth.Text = "Damage on enemy: " + player1.MyWeapon.WeaponDamage.ToString();

                    if (player1.MyWeapon.Poisoned == true)
                    {
                        enemy.Poisoned = true;
                        enemy.PoisonDMGPerRound = player1.MyWeapon.PoisonDMG;
                        player1.MyWeapon.Poisoned = false;
                    }
                    if (enemy.Poisoned == true)
                    {
                        enemy.Damage(enemy.PoisonDMGPerRound);
                        LabelLineThird.Visible = true;
                        LabelLineFourth.Text = "Damage on enemy: " + player1.MyWeapon.WeaponDamage.ToString() + " + Poison Damage: " + enemy.PoisonDMGPerRound.ToString();
                    }
                }
                else
                {
                    LabelLineThird.Visible = true;
                    LabelLineThird.Text = "Your attackpoint: " + player1AttackPoint.ToString() + "<br/>MISS!!!";
                    LabelLineFourth.Visible = true;
                    LabelLineFourth.Text = "Damage on enemy: 0";
                    if (enemy.Poisoned == true)
                    {
                        enemy.Damage(enemy.PoisonDMGPerRound);
                        LabelLineThird.Visible = true;   
                        LabelLineFourth.Text = "Damage on enemy: 0" + " + Poison Damage: " + enemy.PoisonDMGPerRound.ToString();
                    }
                }
            }
            ButtonStartNewRound.Visible = true;
            Session["player1"] = player1;
            Session["Enemy"] = enemy;
        }

        protected void StartNewRound(object sender, EventArgs e)
        {
            ButtonInitiation.Visible = true;
            ButtonStartNewRound.Visible = false;

            LabelLineFirst.Visible = false;
            LabelLineSecound.Visible = false;
            LabelLineThird.Visible = false;
            LabelLineFourth.Visible = false;
        }

        private void PlayerOrEnemyDied(Character enemy, PlayerCharacter player1)
        {
            if (!player1.Alive)
            {
                Session["BattleWon"] = false;
                Response.Redirect("~/BattleFinished.aspx");
            }
            if (!enemy.Alive)
            {
                Session["BattleWon"] = true;
                Response.Redirect("~/BattleFinished.aspx");
            }
        }
    }
}