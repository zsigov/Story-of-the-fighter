using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StartGame(object sender, EventArgs e)
        {
            Response.Redirect("CharacterGenerator.aspx");
        }

        protected void QuitGame(object sender, EventArgs e)
        {
            Response.Redirect("QuitGame.aspx");
        }

        protected void LoadGame(object sender, EventArgs e)
        {
            Response.Redirect("LoadGame1.aspx");
        }

        //protected void Game_Editor(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ReadStoryFiles.aspx");
        //}
    }
}