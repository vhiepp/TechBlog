using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;
        public Home()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["category"] != null)
            {
                System.Diagnostics.Debug.WriteLine(RouteData.Values["category"]);
                string sql = $"SELECT TOP 1 id FROM categories WHERE name=N'{RouteData.Values["category"].ToString()}'";
                DataTable dt = connectDatabase.GetData(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    RenderPostList(int.Parse(dt.Rows[0]["id"].ToString()));
                } else
                {
                    RenderPostList();
                }
                
            } else
            {
                RenderPostList();
            }
        }

        void RenderPostList(int categoryId = -1)
        {
            int page = 0;
            int itemInPage = 6;
            if (Request.QueryString["page"] != null)
            {
                page = int.Parse(Request.QueryString["page"]) - 1;
            }
            string sql = "";
            if (categoryId != -1)
            {
                sql = $"SELECT posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.updated_at, 'dd') AS updated_D, FORMAT(posts.updated_at, 'MM, yyyy') AS updated_MY FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.status=1 AND posts.category_id={categoryId} ORDER BY posts.created_at DESC";
            } else
            {
                sql = "SELECT posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.updated_at, 'dd') AS updated_D, FORMAT(posts.updated_at, 'MM, yyyy') AS updated_MY FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.status=1 ORDER BY posts.created_at DESC";
            }
            int total = connectDatabase.GetData(sql).Rows.Count;
            sql += $" OFFSET {itemInPage * page} ROWS FETCH FIRST {itemInPage} ROWS ONLY;";
            string category = (RouteData.Values["category"] != null) ? RouteData.Values["category"].ToString() : "";
            if (itemInPage * (page + 1) < total)
            {
                nextPage.NavigateUrl = $"/{category}?page={page + 2}";
                nextPage.CssClass = "btn-paginate";
            }
            if (page > 0)
            {
                prePage.NavigateUrl = $"/{category}?page={page}";
                prePage.CssClass = "btn-paginate";
            }

            DataTable dt = connectDatabase.GetData(sql);
            string html = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                html += $"<a href=\"/bai-viet/{dr["slug"]}\" class=\"posts\">" +
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
            }
            postList.InnerHtml = html;
        }
    }
}