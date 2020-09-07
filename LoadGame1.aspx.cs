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
    public partial class LoadGame1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand com = new SqlCommand("select * from tblPlayers", con);
                    con.Open();
                    ListBox1.DataSource = com.ExecuteReader();
                    ListBox1.DataTextField = "Name";
                    ListBox1.DataValueField = "ID";
                    ListBox1.DataBind();
                }
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "";

            string Character = ListBox1.SelectedItem.Text;

            PlayerCharacter player1 = new PlayerCharacter();
            Session["PlayerID"] = null;

            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Get_Player", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@PlayerName", Character);

                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();



                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    player1.Name = row["Name"].ToString();
                    player1.AttackPoint = (int)row["Attack"];
                    player1.DefensePoint = (int)row["Defense"];
                    player1.Luck = (int)row["Luck"];
                    player1.MaxHealthPoint = (int)row["Max_HP"];
                    player1.ActualHealthPoint = (int)row["Actual_HP"];
                    player1.Level = (int)row["Level"];
                    player1.XP = (int)row["Xp"];
                    player1.Gold = (int)row["Gold"];
                    Session["PlayerID"] = (int)row["ID"];
                    Session["StoryCheckPointID"] = (int)row["StoryCheckPoints_ID"];
                 
                    if (!row.IsNull("Equiped_Weapon"))
                    {
                        player1.MyWeapon = new Weapon((string)row["Equiped_Weapon"], GetEquipmentAtribute((string)row["Equiped_Weapon"], "HpModifier"), GetEquipmentAtribute((string)row["Equiped_Weapon"], "AP"));
                    }
                    if (!row.IsNull("Equiped_Shield"))
                    {
                        player1.MyShield = new Shield((string)row["Equiped_Shield"], GetEquipmentAtribute((string)row["Equiped_Shield"], "DP"));
                    }
                    if (!row.IsNull("Equiped_Armour"))
                    {
                        player1.MyArmour = new Armour((string)row["Equiped_Armour"], GetEquipmentAtribute((string)row["Equiped_Armour"], "DMGReduction"));
                    }
                }
            }
            Session["player1"] = player1;
        }

        protected void LoadGame_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex == -1)
            {
                label1.Enabled = true;
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Please select a character from the list.";
            }
            else
            {
                Response.Redirect("~/IframeStartGame.aspx");
                //Response.Redirect("~/StartStoryOfTheFighter.aspx");
            }
        }

        protected int GetEquipmentAtribute(string equipmentName, string atribute)
        {
            int getAtribute = -1;

            string ConnectionSTR = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionSTR))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("GetEquipmentPorperties", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand.Parameters.AddWithValue("@EquipmentName", equipmentName);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    getAtribute = (int)row[atribute];
                }
            }
            return getAtribute;
        }
    }
}