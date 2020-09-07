using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RollPlayGame3._0
{
    public partial class BackPack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("GetPlayerEquipments", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@PlayerID", (int)Session["PlayerID"]);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    BackpackItems.DataSource = ds;
                    BackpackItems.DataTextField = "Name";
                    BackpackItems.DataValueField = "ID";
                    BackpackItems.DataBind();

                    BackpackItems.SelectedIndex = (int)Session["BackPackOpenStartIndex"];
                    BackpackItems_SelectedIndexChanged(sender, e);
                    if (Session["DrunkHealingPotion"] != null)
                    {
                        UsedEquipment.Visible = true;
                        UsedEquipment.Text = "You were healed 3HP";
                        Session["DrunkHealingPotion"] = null;
                    }
                    if(Session["PoisonWeapon"]!=null)
                    {
                        UsedEquipment.Visible = true;
                        UsedEquipment.Text = "Your weapon has been poisoned";
                        Session["PoisonWeapon"] = null;
                    }
                }
            }
        }

        protected void BackpackItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsedEquipment.Visible = false;

            string SelectedItemName = BackpackItems.SelectedItem.ToString();

            //Load datas ito the Gridwiev.
            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand GetEquipmentAtributes = new SqlCommand("GetEquipmentAtributes", con);
                GetEquipmentAtributes.CommandType = System.Data.CommandType.StoredProcedure;
                GetEquipmentAtributes.Parameters.AddWithValue("@PlayerID", (int)Session["PlayerID"]);
                GetEquipmentAtributes.Parameters.AddWithValue("@EquipmentID", BackpackItems.SelectedValue);

                con.Open();
                ItemPropertyies.DataSource = GetEquipmentAtributes.ExecuteReader();
                ItemPropertyies.DataBind();
            }

            //Put datas into Session variables.
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand GetEquipmentAtributes = new SqlCommand("GetEquipmentAtributes", con);
                GetEquipmentAtributes.CommandType = System.Data.CommandType.StoredProcedure;
                GetEquipmentAtributes.Parameters.AddWithValue("@PlayerID", (int)Session["PlayerID"]);
                GetEquipmentAtributes.Parameters.AddWithValue("@EquipmentID", BackpackItems.SelectedValue);

                con.Open();
                SqlDataReader reader = GetEquipmentAtributes.ExecuteReader();
                while (reader.Read())
                {
                    Session["EquipmentName"] = reader["Name"];
                    Session["AP"] = reader["AP"];
                    Session["DP"] = reader["DP"];
                    Session["DRP"] = reader["DMGReduction"];
                    Session["HPModifier"] = reader["HPModifier"];
                    Session["Quantity"] = reader["Quantity"];
                    Session["weight"] = reader["Weight"];
                    Session["goldvalue"] = reader["GoldValue"];
                }
            }
        }

        protected void UseEquipment(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];

            string CS = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand GetEquipmentAtributes = new SqlCommand("GetEquipmentTypeID", con);
                GetEquipmentAtributes.CommandType = System.Data.CommandType.StoredProcedure;
                GetEquipmentAtributes.Parameters.AddWithValue("@ID", BackpackItems.SelectedValue);

                con.Open();
                SqlDataReader reader = GetEquipmentAtributes.ExecuteReader();
                while (reader.Read())
                {
                    Session["TypeID"] = reader["TypeID"];
                }

                switch ((int)Session["TypeID"])
                {
                    case 1:
                        player1.MyWeapon = new Weapon((string)Session["EquipmentName"], (int)Session["HPModifier"], (int)Session["AP"]);
                        UsedEquipment.Visible = true;
                        UsedEquipment.Text = "Weapon equiped.";
                        break;
                    case 2:
                        player1.MyShield = new Shield((string)Session["EquipmentName"], (int)Session["DP"]);
                        UsedEquipment.Visible = true;
                        UsedEquipment.Text = "Shield equiped.";
                        break;
                    case 3:
                        player1.MyArmour = new Armour((string)Session["EquipmentName"], (int)Session["DRP"]);
                        UsedEquipment.Visible = true;
                        UsedEquipment.Text = "Armour equiped.";
                        break;
                    case 4:
                        if ((int)Session["Quantity"] > 0)
                        {
                            if (player1.ActualHealthPoint < player1.MaxHealthPoint)
                            {
                                int quantity = (int)Session["Quantity"];
                                player1.Heal((int)Session["HPModifier"]);
                                quantity -= 1;
                                Session["Quantity"] = quantity;
                                UpdateItemQuantityInSQL((int)Session["PlayerID"], Convert.ToInt32(BackpackItems.SelectedValue), quantity);
                                Session["BackPackOpenStartIndex"] = BackpackItems.SelectedIndex;
                                Session["DrunkHealingPotion"] = 1;
                                Response.Redirect("~/BackPack.aspx");
                            }
                        }
                        break;
                    case 5:
                        if ((int)Session["Quantity"] > 0)
                        {
                            int quantity = (int)Session["Quantity"];
                            Poison crrentPoison = new Poison((int)Session["HPModifier"], (string)Session["EquipmentName"], Convert.ToDouble(Session["goldvalue"]), Convert.ToDouble(Session["weight"]));
                            Poison.PoisonWeapon(player1, crrentPoison);
                            quantity -= 1;
                            Session["Quantity"] = quantity;
                            UpdateItemQuantityInSQL((int)Session["PlayerID"], Convert.ToInt32(BackpackItems.SelectedValue), quantity);
                            Session["BackPackOpenStartIndex"] = BackpackItems.SelectedIndex;
                            Session["PoisonWeapon"] = 1;
                            Response.Redirect("~/BackPack.aspx");
                        }
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
                Session["player1"] = player1;
            }
        }

        protected void UpdateItemQuantityInSQL(int playerID, int equipmentID, int quantity)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["RPG3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                SqlCommand cmd = new SqlCommand("UpdateItemQuantity", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PlayerID", playerID);     // Session["PlayerID"]
                cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }




        protected void BackToGame(object sender, EventArgs e)
        {
            Response.Redirect("~/StartStoryOfTheFighter.aspx");
        }
    }
}