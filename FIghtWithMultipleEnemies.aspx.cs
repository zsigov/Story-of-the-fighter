﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RollPlayGame3._0
{
    public partial class FIghtWithMultipleEnemies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divFightWithMultipleEnemies.InnerHtml = string.Empty;
            DisplayCharacter();
        }

        private void DisplayCharacter()
        {
          
        }
    }
}