using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages
{
    public partial class Default : System.Web.UI.MasterPage
    {
        ConnectDatabase connectDatabase;

        public Default()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderCategoryList();
        }

        void RenderCategoryList()
        {
            string sql = "SELECT categories.id, categories.name, COUNT(posts.id) AS post_count FROM categories LEFT JOIN posts ON categories.id = posts.category_id AND posts.status=1  GROUP BY categories.id, categories.name;";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null )
            {
                int total = 0;
                string html = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    html += $"<a href=\"/{dr["name"]}\">{dr["name"]} ({dr["post_count"]})</a>";
                    total += int.Parse(dr["post_count"].ToString());
                }
                html = $"<a href=\"/\">Tất cả ({total})</a>" + html;
                categoryList.InnerHtml = html;
            }
        }

    }
}