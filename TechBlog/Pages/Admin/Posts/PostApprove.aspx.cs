using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages.Admin.Posts
{
    public partial class PostApprove : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public PostApprove()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HandleApprovePostWithSlug(RouteData.Values["slug"].ToString());
            Response.Redirect("/quan-tri/bai-viet");
        }

        bool HandleApprovePostWithSlug(string slug)
        {
            string sql = $"UPDATE posts SET status=1 WHERE slug='{slug}';";
            return connectDatabase.SetData(sql);
        }
    }
}