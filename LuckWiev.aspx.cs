using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class LuckWiev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            LabelPlayerLuckValue.Text = player1.Luck.ToString();


            if (!IsPostBack)
            {
                LabelLuckRoll1.Text = "Click the dice to roll.";
                LabelLuckRoll2.Text = "Click the dice to roll.";
                ButtonContinueGame.Visible = false;
                LabelResult3.Visible = false;
            }

            if (ImageButtonLuckRoll1.Visible == false && ImageButtonLuckRoll2.Visible == false)
            {

            }
        }

        protected void ImageButtonLuckRoll1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButtonLuckRoll1.Enabled = false;
            Random Roll1 = new Random();
            int luckRoll1 = Roll1.Next(1, 7);
            LabelLuckRoll1.Text = luckRoll1.ToString();
            if (ImageButtonLuckRoll2.Enabled == false)
            {
                LuckRollsResult((PlayerCharacter)Session["player1"]);
            }
            ImageButtonLuckRoll1.ImageUrl = "~/Images/Dice pictures/NOT.png";
        }

        protected void ImageButtonLuckRoll2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButtonLuckRoll2.Enabled = false;
            Random Roll2 = new Random();
            int luckRoll2 = Roll2.Next(1, 7);
            LabelLuckRoll2.Text = luckRoll2.ToString();
            if (ImageButtonLuckRoll1.Enabled == false)
            {
                LuckRollsResult((PlayerCharacter)Session["player1"]);
            }
            ImageButtonLuckRoll2.ImageUrl = "~/Images/Dice pictures/NOT.png";
        }

        protected void ButtonContinueGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StartStoryOfTheFighter.aspx");
        }

        private void LuckRollsResult(PlayerCharacter player1)
        {
            int luckRollSumm = Convert.ToInt32(LabelLuckRoll1.Text) + Convert.ToInt32(LabelLuckRoll2.Text);
            if (player1.Luck >= luckRollSumm) //Luck succed.
            {
                LabelResult3.Text = "Your luck result is: " + luckRollSumm.ToString() + " , SUCCESS!!!";
                LabelResult3.Visible = true;
                Session["StoryCheckPointID"] = Session["StoryCheckPointIDIfLuckSucced"];
                ButtonContinueGame.Visible = true;
            }
            else //Luck fail.
            {
                LabelResult3.Text = "Your luck result is: " + luckRollSumm.ToString() + " , FAIL!!!";
                LabelResult3.Visible = true;
                Session["StoryCheckPointID"] = Session["StoryCheckPointIDIfLuckFail"];
                ButtonContinueGame.Visible = true;
            }
        }
    }
}