using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RollPlayGame3._0
{
    public partial class CharacterGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void GoToGenerator2(object sender, EventArgs e)
        {
            Random RandomGenerator = new Random();

            PlayerCharacter player1 = new PlayerCharacter
            (
                lblGetName.Text,
                0,
                6,
                10,
                3,
                RandomGenerator.Next(3, 7),
                RandomGenerator.Next(1, 7),
                RandomGenerator.Next(1, 7) + RandomGenerator.Next(1, 7),
                RandomGenerator.Next(1, 7)
            );    
            
            

            bool IsCharacterExsist = false;
            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select name from tblPlayers", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string name = rdr["name"].ToString();
                        if (name == player1.Name)
                        {
                            IsCharacterExsist = true;
                        }
                    }
                }
            }

            if (lblGetName.Text == "" || lblGetName.Text == "Please give a name to your character")
            {
                lblFalseCharacterName.ForeColor = System.Drawing.Color.Red;
                lblFalseCharacterName.Text = "Please give a name to your character";
                lblFalseCharacterName.Visible = true;
            }
            else if (IsCharacterExsist == true)
            {
                lblFalseCharacterName.ForeColor = System.Drawing.Color.Red;
                lblFalseCharacterName.Text = "Character name is already exist";
                lblFalseCharacterName.Visible = true;

            }
            else
            {
                player1.Name = lblGetName.Text;
                Session["player1"] = player1;

                lblCharacterName.Text = player1.Name;
                lblAttackPoint.Text = player1.AttackPoint.ToString();
                lblDefensePoint.Text = player1.DefensePoint.ToString();
                lblHealthPoint.Text = player1.MaxHealthPoint.ToString();
                lblLuck.Text = player1.Luck.ToString();

                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void SaveAndStartGame(object sender, EventArgs e)
        {

            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];

            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InsertPlayer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", player1.Name);
                cmd.Parameters.AddWithValue("@Attack", player1.AttackPoint);
                cmd.Parameters.AddWithValue("@Defense", player1.DefensePoint);
                cmd.Parameters.AddWithValue("@MaxHP", player1.MaxHealthPoint);
                cmd.Parameters.AddWithValue("@ActualHP", player1.MaxHealthPoint);
                cmd.Parameters.AddWithValue("@Luck", player1.Luck);
                cmd.Parameters.AddWithValue("@XP", player1.XP);
                cmd.Parameters.AddWithValue("@Gold", player1.Gold);
                cmd.Parameters.AddWithValue("@Level", player1.Level);
                cmd.Parameters.AddWithValue("@StoryCheckpoints", 1);
                cmd.Parameters.AddWithValue("@EqupiedWeapon", player1.MyWeapon.Name);           
                cmd.Parameters.AddWithValue("@EquipedShield", player1.MyShield.Name);
                cmd.Parameters.AddWithValue("@EquipedArmour", player1.MyArmour.Name);


                SqlParameter IDParameter = new SqlParameter();
                IDParameter.ParameterName = "@ID";
                IDParameter.SqlDbType = System.Data.SqlDbType.Int;
                IDParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(IDParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                Session["PlayerID"] = IDParameter.Value;
                Session["StoryCheckPointID"] = 1;
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("AddPlayerBasicEquipment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", (int)Session["PlayerID"]);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            //We need to think it carefully. Ajax or Iframe.
            // M usic is handeld in iframe with javascript.
            Response.Redirect("~/IframeStartGame.aspx");
            //Response.Redirect("~/StartStoryOfTheFighter.aspx");
        }
    }
}

