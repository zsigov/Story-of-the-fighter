using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class LevelUpp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            LabelCharacterName.Text = player1.Name;
            LabelCharacterLevel.Text = player1.Level.ToString();
            TextBoxAP.Text = player1.AttackPoint.ToString();
            TextBoxDP.Text = player1.DefensePoint.ToString();
            TextBoxHP.Text = player1.MaxHealthPoint.ToString();
            TextBoxLuck.Text = player1.Luck.ToString();
            
            if (!IsPostBack)
            {
                if ((int)Session["FirstLoadCheck"] == 0)
                {
                    int remainingPoints = 3;
                    Session["remainingPoints"] = remainingPoints;
                    Session["CharacterMinAP"] = player1.AttackPoint;
                    Session["CharacterMinDP"] = player1.DefensePoint;
                    Session["CharacterMinMaxHP"] = player1.MaxHealthPoint;
                    Session["CharacterMinLuck"] = player1.Luck;
                }
            }
            TextBoxRemainingPoints.Text = Session["remainingPoints"].ToString();

            if ((int)Session["CharacterMinAP"]!=player1.AttackPoint)
            {
                TextBoxAP.ForeColor = System.Drawing.Color.Red;
            }
            if ((int)Session["CharacterMinDP"] != player1.DefensePoint)
            {
                TextBoxDP.ForeColor = System.Drawing.Color.Red;
            }
            if ((int)Session["CharacterMinMaxHP"] != player1.MaxHealthPoint)
            {
                TextBoxHP.ForeColor = System.Drawing.Color.Red;
            }
            if ((int)Session["CharacterMinLuck"] != player1.Luck)
            {
                TextBoxLuck.ForeColor = System.Drawing.Color.Red;
            }
            if((int)Session["remainingPoints"]==0)
            {
                ButtonContinueGame.Visible = true;  
            }
        }

        protected void ImageButtonPlusAp_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if((int)Session["remainingPoints"]>0)
            {
                player1.AttackPoint += 1;
                remainingPoints -= 1;
                Session["remainingPoints"] = remainingPoints;
                Session["player1"] = player1;
                Session["FirstLoadCheck"] = 1;
                Response.Redirect("~/LevelUpp.aspx");
            }    
        }

        protected void ImageButtonMinusAP_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] < 3)
            {
                if ((int)Session["CharacterMinAP"] < player1.AttackPoint)
                {
                    player1.AttackPoint -= 1;
                    remainingPoints += 1;
                    Session["remainingPoints"] = remainingPoints;
                    Session["player1"] = player1;
                    Session["FirstLoadCheck"] = 1;
                    Response.Redirect("~/LevelUpp.aspx");
                }
            }
        }

        protected void ImageButtonPlusDP_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] > 0)
            {
                player1.DefensePoint += 1;
                remainingPoints -= 1;
                Session["remainingPoints"] = remainingPoints;
                Session["player1"] = player1;
                Session["FirstLoadCheck"] = 1;
                Response.Redirect("~/LevelUpp.aspx");
            }
        }

        protected void ImageButtonMinusDP_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] < 3)
            {
                if ((int)Session["CharacterMinDP"] < player1.DefensePoint)
                {
                    player1.DefensePoint -= 1;
                    remainingPoints += 1;
                    Session["remainingPoints"] = remainingPoints;
                    Session["player1"] = player1;
                    Session["FirstLoadCheck"] = 1;
                    Response.Redirect("~/LevelUpp.aspx");
                }
            }
        }

        protected void ImageButtonPlusHP_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] > 0)
            {
                    player1.MaxHealthPoint += 2;
                    remainingPoints -= 1;
                    Session["remainingPoints"] = remainingPoints;
                    Session["player1"] = player1;
                    Session["FirstLoadCheck"] = 1;
                    Response.Redirect("~/LevelUpp.aspx");
            }
        }

        protected void ImageButtonMinusHP_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] < 3)
            {
                if ((int)Session["CharacterMinMaxHP"] < player1.MaxHealthPoint)
                {
                    player1.MaxHealthPoint -= 2;
                    remainingPoints += 1;
                    Session["remainingPoints"] = remainingPoints;
                    Session["player1"] = player1;
                    Session["FirstLoadCheck"] = 1;
                    Response.Redirect("~/LevelUpp.aspx");
                }
            }
        }

        protected void ImageButtonPlusLuck_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] > 0)
            {
                player1.Luck += 1;
                remainingPoints -= 1;
                Session["remainingPoints"] = remainingPoints;
                Session["player1"] = player1;
                Session["FirstLoadCheck"] = 1;
                Response.Redirect("~/LevelUpp.aspx");
            }
        }

        protected void ImageButtonMinusLuck_Click(object sender, ImageClickEventArgs e)
        {
            int remainingPoints = (int)Session["remainingPoints"];
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            if ((int)Session["remainingPoints"] < 3)
            {
                if ((int)Session["CharacterMinLuck"] < player1.Luck)
                {
                    player1.Luck -= 1;
                    remainingPoints += 1;
                    Session["remainingPoints"] = remainingPoints;
                    Session["player1"] = player1;
                    Session["FirstLoadCheck"] = 1;
                    Response.Redirect("~/LevelUpp.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            player1.ActualHealthPoint = player1.MaxHealthPoint;
            Session["player1"] = player1;
            Response.Redirect("~/StartStoryOfTheFighter.aspx");
        }
    }
}
