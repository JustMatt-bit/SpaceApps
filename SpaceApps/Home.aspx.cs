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
        bool isDone = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Awaiting request";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string prompt = inputBoxPrompt.Value;
            if (prompt != null || !prompt.Equals(""))
            {
                Label1.Text = "Loading";
                isDone = APIcontroller.GenerateImageByPrompt(prompt, "https://replicate.com/api/models/stability-ai/stable-diffusion/files/45e440af-26fb-4c2a-a9b4-f4ed784066ff/out-0.png", Server.MapPath("~/App_Data/") + prompt.Replace(' ', '_') +".png");
                if (isDone)
                {
                    GoToNextPage();
                }
            }
        }

        protected void GoToNextPage()
        {
            Label1.Text = "Image generated";
        }
    }
}