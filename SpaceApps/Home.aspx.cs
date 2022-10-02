using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpaceApps.App_Code;

namespace SpaceApps
{
    public partial class Home : System.Web.UI.Page
    {
        Dictionary<string, string> addresses = new Dictionary<string, string>();
       
        bool isDone = false;
        string prompt = "";
        string index = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            addresses.Add("1", "https://i.ibb.co/J75yYYb/1.jpg");
            addresses.Add("2", "https://i.ibb.co/WpCdHT7/2.jpg");
            addresses.Add("3", "https://i.ibb.co/LpJ53t7/3.jpg");
            addresses.Add("4", "https://i.ibb.co/P6h8TBk/4.jpg");
            addresses.Add("5", "https://i.ibb.co/PYfgVx9/5.jpg");
            addresses.Add("6", "https://i.ibb.co/p3PDnZ7/6.jpg");
            addresses.Add("7", "https://i.ibb.co/107J828/7.jpg");
            addresses.Add("8", "https://i.ibb.co/qgwm518/8.jpg");
            addresses.Add("9", "https://i.ibb.co/1dCf5SX/9.jpg");
            addresses.Add("10", "https://i.ibb.co/2YshJ2c/10.jpg");
            addresses.Add("11", "https://i.ibb.co/RcKMv80/11.jpg");
            addresses.Add("12", "https://i.ibb.co/L02gPT7/12.jpg");
            addresses.Add("13", "https://i.ibb.co/3Fwxgpc/13.jpg");
            addresses.Add("14", "https://i.ibb.co/FWQ4X5j/14.jpg");
            addresses.Add("15", "https://i.ibb.co/cNJRf1K/15.jpg");
            addresses.Add("16", "https://i.ibb.co/7kNcrpp/16.jpg");
            addresses.Add("17", "https://i.ibb.co/6nBnFtx/17.jpg");
            addresses.Add("18", "https://i.ibb.co/gZK2LkN/18.jpg");
            addresses.Add("19", "https://i.ibb.co/SJwyV7J/19.jpg");
            addresses.Add("20", "https://i.ibb.co/yqnJnRj/20.jpg");
            Label1.Text = "Awaiting request";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            index = ValueHiddenField.Value;
            prompt = inputBoxPrompt.Value;
            if (prompt != null || !prompt.Equals(""))
            {
                Label1.Text = "Loading";
                isDone = APIcontroller.GenerateImageByPrompt(prompt, addresses[index], Server.MapPath("~/images/") + "generatedImage.png");
                if (isDone)
                {
                    File.Copy(Server.MapPath("~/images/") + index + ".jpg", Server.MapPath("~/images/") + "usedImage.jpg", true);
                    GoToNextPage();
                }
            }
        }

        protected void GoToNextPage()
        {
            Label1.Text = "Image generated";
            Response.Redirect(String.Format("Results.aspx?name={0}&index={1}", prompt, index));
        }
    }
}