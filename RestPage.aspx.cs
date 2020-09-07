using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class RestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ButtonContinue.Visible = false;
        }

        protected void ButtonRest_Click(object sender, EventArgs e)
        {
            PlayerCharacter player1 = (PlayerCharacter)Session["player1"];
            player1.ActualHealthPoint = player1.MaxHealthPoint;
            Session["player1"] = player1;  
            Response.Redirect("~/StartStoryOfTheFighter.aspx");
        }
    }
}