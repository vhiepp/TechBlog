using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages.Admin.Posts
{
    public partial class PostDelete : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public PostDelete()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HandleDeletePostWithSlug(RouteData.Values["slug"].ToString());
            Response.Redirect("/quan-tri/bai-viet");
        }

        bool HandleDeletePostWithSlug(string slug)
        {
            string sql = $"DELETE FROM posts WHERE slug='{slug}';";
            return connectDatabase.SetData(sql);
        }
    }
}