using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpaceApps.App_Code;

namespace SpaceApps
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string prompt = inputBoxPrompt.Value;
            if (prompt != null || !prompt.Equals(""))
            {
                APIcontroller.GenerateImageByPrompt("dog", "", Server.MapPath("~/App_Data/") + "dog.png");
            }
        }
    }
}