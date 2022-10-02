using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceApps
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            string index = Request.QueryString["index"].ToString();

            Label1.Text = Request.QueryString["name"].ToString();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "media/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename=generatedImage.png");
            Response.TransmitFile(Server.MapPath("~/images/") + "generatedImage.png");
            Response.End();
        }
    }
}