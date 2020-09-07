using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class BattleFinished : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            bool BattleWon = player1.Alive;

            if (BattleWon == false)
            {
                ImagePlayer.ImageUrl = "~/Images/EnemyPictueres/halalfej.jpg";
                ImageEnemy1.ImageUrl = (string)Session["EnemyImageURL"];
                LabelLineFirst.Visible = true;
                LabelLineFirst.Text = "Your enemy has defated you. You died!";
                LabelLineSecound.Visible = true;
                LabelLineSecound.Text = "Your journey has ended here.";

                Session["StoryCheckPointID"] = Session["StoryCheckPointIDIfBattleLoose"];
                ButtonContinueGame.Visible = true;
                ButtonContinueGame.Text = "Back to main menu";
            }
            else
            {
                ImagePlayer.ImageUrl = "~/Images/CharacterPictures/Fighter.jpg";
                ImageEnemy1.ImageUrl = "~/Images/EnemyPictueres/halalfej.jpg";
                LabelLineFirst.Visible = true;
                LabelLineFirst.Text = "Congratulations! You defated your enemy.";
                LabelLineSecound.Visible = true;
                LabelLineSecound.Text = "You can continue your journey.";

                Session["StoryCheckPointID"] = Session["StoryCheckPointIDIfBattleWon"];
                ButtonContinueGame.Visible = true;
                ButtonContinueGame.Text = "Continue game";
            }
        }

        protected void ButtonContinueGame_Click(object sender, EventArgs e)
        {
            if (Session["StoryCheckPointID"] == Session["StoryCheckPointIDIfBattleLoose"])
            {
                Response.Redirect("~/StartPage.aspx");
            }
            else
            {
                Response.Redirect("~/StartStoryOfTheFighter.aspx");
            }
        }
    }
}