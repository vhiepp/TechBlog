using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Models;
using TechBlog.Pages.Admin.Posts;

namespace TechBlog.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public Profile()
        {

            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/dang-nhap?continue=/ho-so-ca-nhan");
            }
            RenderPostList();
        }

        void RenderPostList()
        {
            string sql = $"SELECT posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.updated_at, 'dd') AS updated_D, FORMAT(posts.updated_at, 'MM, yyyy') AS updated_MY FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.author_id={((User)Session["user"]).Id} ORDER BY posts.created_at DESC";
            DataTable dt = connectDatabase.GetData(sql);
            string htmlShow = "";
            string htmlAwait = "";
            int total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string html = $"<a href=\"/bai-viet/{dr["slug"]}\" class=\"posts\">" +
                    "<div class=\"posts_left\">" +
                    "<div class=\"thumbnail-frame\">" +
                    $"<img src=\"{dr["thumbnail_url"]}\" alt=\"\" style='object-fit: cover;' srcset=\"\">" +
                    "</div></div><div class=\"posts_right\">" +
                    $"<h4 class=\"title\" style='margin-bottom: 0'>{dr["title"]}</h4>" +
                    $"<p style='margin-bottom: 0'>{dr["description"]}</p>" +
                    "<div class=\"tags\">" +
                    $"<span>#{dr["category_name"]}</span>" +
                    "</div>" +
                    "<div class=\"contact\">" +
                    $"<span class=\"author\">{dr["fullname"]}</span> | <span class=\"time\">{dr["updated_D"]} tháng {dr["updated_MY"]}</span>" +
                    "</div></div></a>";
                if (dr["status"].ToString() == "1")
                {
                    htmlShow += html;
                } else
                {
                    htmlAwait += html;
                    total++;
                }
            }
            if (htmlShow.Length > 0)
            {
                postListShow.InnerHtml = htmlShow;
            }
            if (htmlAwait.Length > 0)
            {
                postListAwait.InnerHtml = htmlAwait;
            }
            totalPostAwait.InnerText = total.ToString();
        }
    }
}