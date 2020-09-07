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
    public partial class StartStoryOfTheFighter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //When load page at firs time StoryCoiceList.SelectedIndex will be -1.
            if (StoryCoiceList.SelectedIndex != -1)
            {
                //RestPage uses the ability that StoryCoiceList.SelectedValue == Session["StoryCheckPointID"] 
                //and goes back to the point where it comes from.
                if (StoryCoiceList.SelectedValue == Session["StoryCheckPointID"].ToString())
                {
                    Response.Redirect("~/RestPage.aspx");
                }

                Session["StoryCheckPointID"] = StoryCoiceList.SelectedValue;       
            }
            else
            {
                DisplayWarningMsg();
            }
            if (!IsPostBack || StoryCoiceList.SelectedIndex != -1)
            {
                lblMessage.Visible = false;
            }

            VerifySpecialCheckpoints((PlayerCharacter)Session["player1"], Session["StoryCheckPointID"].ToString());

            GetStoryCheckPointAndStoryChoices();
            GetCheckpointIncidents();
            FillPlayerAttributes();

            // Set autoselection on StoryCoiceList if only one item is on the list.
            if (StoryCoiceList.Items.Count == 1)
            {
                StoryCoiceList.SelectedIndex = 0;
            }
        }

        public void FillPlayerAttributes()
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            lblCharacterName.Text = player1.Name;
            lblLuck.Text = player1.Luck.ToString();
            lblHealthPoint.Text = player1.MaxHealthPoint.ToString() + "/" + player1.ActualHealthPoint.ToString();
            lblLevel.Text = player1.Level.ToString();
            lblXP.Text = player1.XP.ToString();

            SetPlayerWeaponAndAttackPoint(player1);
            SetPlayerShieldAndDefensePoint(player1);
            SetPlayerArmourAndDR(player1);

            Session["player1"] = player1;
        }

        protected void SetPlayerWeaponAndAttackPoint(PlayerCharacter player)
        {
            if (player.MyWeapon == null)
            {
                player.MyWeapon = new Weapon("Fist", 1, 1);
                lblWeaponName.Text = player.MyWeapon.Name;
                lblWeaponDMG.Text = "DAMAGE: " + player.MyWeapon.WeaponDamage.ToString();
                lblWeaponAttackPoint.Text = "AP: " + player.MyWeapon.AttackPoint.ToString();
                lblAttackPoint.Text = (player.AttackPoint + player.MyWeapon.AttackPoint).ToString();
            }
            else
            {
                lblWeaponName.Text = player.MyWeapon.Name;
                lblWeaponDMG.Text = "DAMAGE: " + player.MyWeapon.WeaponDamage.ToString();
                lblWeaponAttackPoint.Text = "AP: " + player.MyWeapon.AttackPoint.ToString();
                lblAttackPoint.Text = (player.AttackPoint + player.MyWeapon.AttackPoint).ToString();
            }

        }

        protected void SetPlayerShieldAndDefensePoint(PlayerCharacter player)
        {
            if (player.MyShield != null)
            {
                lblShieldName.Text = player.MyShield.Name;
                lblShieldDefense.Text = "DP: " + player.MyShield.DefensePoint.ToString();
                lblDefensePoint.Text = (player.DefensePoint + player.MyShield.DefensePoint).ToString();
            }
            else
            {
                player.MyShield = new Shield("Emty", 0);
                lblShieldName.Text = player.MyShield.Name;
                lblShieldDefense.Text = "DP: " + player.MyShield.DefensePoint.ToString();
                lblDefensePoint.Text = (player.DefensePoint + player.MyShield.DefensePoint).ToString();
            }
        }

        protected void SetPlayerArmourAndDR(PlayerCharacter player)
        {
            if (player.MyArmour != null)
            {
                lblArmourName.Text = player.MyArmour.Name;
                lblDamageReduction.Text = "DR: " + player.MyArmour.DamageReduction.ToString();
            }
            else
            {
                player.MyArmour = new Armour("Clothes", 0);
                lblArmourName.Text = player.MyArmour.Name;
                lblDamageReduction.Text = "DR: " + player.MyArmour.DamageReduction.ToString();
            }
        }

        protected void BackPack_Click(object sender, ImageClickEventArgs e)
        {
            Session["BackPackOpenStartIndex"] = 0;
            Response.Redirect("~/BackPack.aspx");
        }

        protected void DoIt_Click(object sender, EventArgs e)
        {
            UpdatePlayerInDataBase();
        }

        protected void StoryCoiceList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SaveGame_click(object sender, EventArgs e)
        {
            UpdatePlayerInDataBase();
            lblMessage.ForeColor = System.Drawing.Color.White;
            lblMessage.Text = "Game saved succesfully.";
            lblMessage.Visible = true;
        }

        protected void GetStoryCheckPointAndStoryChoices()
        {
            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetStoryCheckPoint", con);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@StoryCheckPointID", Session["StoryCheckPointID"]);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    StoryText.Text = row["Description"].ToString();
                }

                SqlDataAdapter dataAdapter1 = new SqlDataAdapter("GetStoryChoises", con);
                dataAdapter1.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter1.SelectCommand.Parameters.AddWithValue("@StoryCheckPointID", Session["StoryCheckPointID"]);

                DataSet dataSet1 = new DataSet();
                dataAdapter1.Fill(dataSet1);

                StoryCoiceList.DataSource = dataSet1;
                StoryCoiceList.DataTextField = "Description";
                StoryCoiceList.DataValueField = "DestinationStoryCheckPoints_ID";
                StoryCoiceList.DataBind();
            }
        }

        protected void QuitGame_click(object sender, EventArgs e)
        {
            UpdatePlayerInDataBase();
            Response.Redirect("QuitGame.aspx");
        }

        protected void GetCheckpointIncidents()
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];

            string ConnString = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            SqlConnection con = new SqlConnection(ConnString);

            SqlDataAdapter da = new SqlDataAdapter("GetCheckPointIncidents", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@StoryCheckpoint", Session["StoryCheckPointID"]);
          
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if ((string)row["Type"] == "Get XP")
                {
                    int rowID = (int)row["ID"];

                    List<string> StoryCheckPointChangedXP = new List<string>();
                    if (Session["StoryCheckPointChangedXP"] != null)
                    {
                        StoryCheckPointChangedXP = (List<string>)Session["StoryCheckPointChangedXP"];
                    }
                    if (!(StoryCheckPointChangedXP.Contains(Session["StoryCheckPointID"].ToString())))
                    {
                        string ConnString_1 = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
                        SqlConnection connection = new SqlConnection(ConnString_1);

                        connection.Open();

                        SqlCommand command = new SqlCommand("select [dbo].[FuncGetStoryCheckpointIncidentXP](@id) id", connection);
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@id", rowID));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                player1.AddXP(Convert.ToInt32(reader["id"]));
                            }
                        }

                        connection.Close();

                        StoryCheckPointChangedXP.Add(Session["StoryCheckPointID"].ToString());
                        Session["StoryCheckPointChangedXP"] = StoryCheckPointChangedXP;
                        LevelUpp(player1);                      
                    }
                }

                if ((string)row["Type"] == "Damage")
                {
                    if (Session["StoryCheckPointChangedDMG"] != Session["StoryCheckPointID"])
                    {
                        int rowID = (int)row["ID"];
                        string ConnString_1 = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
                        SqlConnection conection = new SqlConnection(ConnString_1);

                        SqlDataAdapter adapter = new SqlDataAdapter("GetStoryCheckpointIncidentDamage", conection);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@ID", rowID);

                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        foreach (DataRow Row in dataset.Tables[0].Rows)
                        {
                            int damage = (int)Row["Damage"];
                            player1.Damage(damage);
                        }
                        lblHealthPoint.Text = player1.MaxHealthPoint.ToString() + "/" + player1.ActualHealthPoint.ToString();
                        Session["StoryCheckPointChangedDMG"] = Session["StoryCheckPointID"];
                    }
                }

                if ((string)row["Type"] == "Luck")
                {
                    // We made a choice from now on the first will be the success and the second will be the fail.
                    StoryCoiceList.SelectedIndex = 0;
                    Session["StoryCheckPointIDIfLuckSucced"] = StoryCoiceList.SelectedValue;
                    StoryCoiceList.SelectedIndex = 1;
                    Session["StoryCheckPointIDIfLuckFail"] = StoryCoiceList.SelectedValue;
                    Response.Redirect("~/LuckWiev.aspx");
                }

                // This decision Change Equipment also contains the incidents when equipment requirements are met with the Current checkpoint expectations or not.
                if ((string)row["Type"] == "Change Equipment")
                {
                    // These are change equipment actions what can happen only once.
                    if (Session["StoryCheckPointChangedChangeEquipment"] != Session["StoryCheckPointID"])
                    {
                        var checkpointID = Session["StoryCheckPointID"];
                        int checkpointID1 = Convert.ToInt32(checkpointID);
                        switch (checkpointID1)
                        {
                            case 8:
                                player1.MyArmour = new Armour();
                                player1.MyShield = new Shield();
                                Session["player1"] = player1;
                                break;
                            case 15:
                                AddEquipment(8, 1);
                                AddEquipment(1, 1);
                                player1.MyArmour = new Armour("Golden Armour", 5);
                                player1.MyShield = new Shield("Golden Shield", 5);
                                Session["player1"] = player1;
                                break;
                            case 19:
                                player1.MyArmour = new Armour();
                                player1.MyShield = new Shield();
                                Session["player1"] = player1;
                                break;
                            case 44:
                                AddEquipment(24, 1);
                                UpdateEquipmentQuantity(12, 3);
                                break;                            
                            case 79:
                                AddEquipment(24, 1);
                                player1.MyWeapon = new Weapon("Mighty Weapon of the Elders", 10, 15);
                                break;
                            case 89:
                                AddEquipment(24, 1);
                                player1.MyWeapon = new Weapon("Mighty Weapon of the Elders", 10, 15);
                                break;
                            case 102:
                                AddEquipment(28, 5);
                                break;
                            case 134:
                                AddEquipment(25, 1);
                                break;
                            case 135:
                                AddEquipment(26, 1);
                                break;
                            case 136:
                                player1.DefensePoint += 3;
                                break;
                            case 137:
                                player1.Gold += 100;
                                break;
                            case 138:
                                AddEquipment(25, 1);
                                break;
                            case 139:
                                AddEquipment(26, 1);
                                break;
                            case 140:
                                player1.DefensePoint += 3;
                                break;
                            case 141:
                                player1.Gold += 100;
                                break;
                            case 142:
                                AddEquipment(25, 1);
                                AddEquipment(26, 1);
                                player1.DefensePoint += 3;
                                player1.Gold += 100;
                                break;
                        }
                        Session["StoryCheckPointChangedChangeEquipment"] = Session["StoryCheckPointID"];                       
                    }
                }

                if ((string)row["Type"] == "Fight")
                {
                    //We made a choice from now on the first will be the wining and the second will be the losing fo the battle.
                    ButtonBeginFight.Visible = true;
                    StoryCoiceList.Enabled = false;
                    DoIt.Visible = false;
                }

                //This is just to try if I can see the incidents on the page.
                ListBox1.DataSource = ds;
                ListBox1.DataTextField = "Type";
                ListBox1.DataValueField = "StoryCheckPoint_ID";
                ListBox1.DataBind();
            }
        }

        protected void ButtonBeginFight_Click(object sender, EventArgs e)
        {
            StoryCoiceList.SelectedIndex = 0;
            Session["StoryCheckPointIDIfBattleWon"] = StoryCoiceList.SelectedValue;
            StoryCoiceList.SelectedIndex = 1;
            Session["StoryCheckPointIDIfBattleLoose"] = StoryCoiceList.SelectedValue;

            //Try new site.
            Response.Redirect("~/BattleWithAjax.aspx");
            //Response.Redirect("~/Battle.aspx");
        }

        protected void AddEquipment(int eqipmentID, int quantity)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand("AddplayerEquipment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", Session["PlayerID"]);
                cmd.Parameters.AddWithValue("@EquipmentID", eqipmentID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void UpdateEquipmentQuantity(int eqipmentID, int quantity)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand("UpdatePlayerEquipmentQuantity", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", Session["PlayerID"]);
                cmd.Parameters.AddWithValue("@EquipmentID", eqipmentID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void LevelUppCases(PlayerCharacter player, int maxXP)
        {
            if (player.XP >= maxXP)
            {
                player.XP = 0;
                player.Level = maxXP/10
;
                Session["player1"] = player;
                Response.Redirect("LevelUpp.aspx");
            }
        }

        // At the moment I make 5 levels. Maybe later add more.
        private void LevelUpp(PlayerCharacter player1)
        {
            Session["FirstLoadCheck"] = 0;
            switch (player1.Level)
            {
                case 1:
                    LevelUppCases(player1, 20);
                    break;
                case 2:
                    LevelUppCases(player1, 30);
                    break;
                case 3:
                    LevelUppCases(player1, 40);
                    break;
                case 4:
                    LevelUppCases(player1, 50);
                    break;
                case 5:
                    LevelUppCases(player1, 60);
                    break;
                case 6:
                    LevelUppCases(player1, 70);
                    break;
            }
        }

        private void DisplayWarningMsg()
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please make a choice before continue";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

        public static void UpdatePlayerInDataBase()
        {
            PlayerCharacter player1 = (PlayerCharacter)HttpContext.Current.Session["player1"];

            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UpdatePlayer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Attack", player1.AttackPoint);
                cmd.Parameters.AddWithValue("@Defense", player1.DefensePoint);
                cmd.Parameters.AddWithValue("@MaxHP", player1.MaxHealthPoint);
                cmd.Parameters.AddWithValue("@ActualHP", player1.MaxHealthPoint);
                cmd.Parameters.AddWithValue("@Luck", player1.Luck);
                cmd.Parameters.AddWithValue("@XP", player1.XP);
                cmd.Parameters.AddWithValue("@Gold", player1.Gold);
                cmd.Parameters.AddWithValue("@Level", player1.Level);
                cmd.Parameters.AddWithValue("@StoryCheckpoints", HttpContext.Current.Session["StoryCheckPointID"]);
                cmd.Parameters.AddWithValue("@MyWeapon", player1.MyWeapon.Name);
                cmd.Parameters.AddWithValue("@Myshield", player1.MyShield.Name);
                cmd.Parameters.AddWithValue("@Myarmour", player1.MyArmour.Name);
                cmd.Parameters.AddWithValue("@ID", HttpContext.Current.Session["PlayerID"]);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Create a separated condition for situations where having an item decides the next StoryCheckpoint.
        protected void VerifySpecialCheckpoints(PlayerCharacter player1, string checkpointID)
        {
            List<string> CheckpointIDToVerify = new List<string>() {"13", "51", "162", "163"};
            if (CheckpointIDToVerify.Contains(checkpointID))
            {
                string checkpointIDForOftencheck = Session["StoryCheckPointID"].ToString();
                switch (checkpointIDForOftencheck)
                {
                    case "13":
                        if (player1.MyArmour.DamageReduction != 0 || player1.MyShield.DefensePoint != 0)
                        {
                            Session["StoryCheckPointID"] = "51";
                        }
                        break;
                    case "51":
                        if (player1.MyArmour.DamageReduction == 0 && player1.MyShield.DefensePoint == 0)
                        {
                            Session["StoryCheckPointID"] = "13";
                        }
                        break;
                    case "162":
                        if (player1.MyArmour.Name != "Golden Armour")
                        {
                            Session["StoryCheckPointID"] = "163";
                        }
                        break;
                    case "163":
                        if (player1.MyArmour.Name == "Golden Armour")
                        {
                            Session["StoryCheckPointID"] = "162";                    
                        }
                        break;
                }
            }
        }
    }
}