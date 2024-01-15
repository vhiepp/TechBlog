using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Models;

namespace TechBlog.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (Session["user"] == null)
            {
                Response.Redirect("/dang-nhap");
            }
            if (user.Role == "user")
            {
                Response.Redirect("/");
            }
        }
    }
}