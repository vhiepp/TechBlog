using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Pages.Admin.Posts;

namespace TechBlog.Pages.Admin.Categories
{
    public partial class CategoryList : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public CategoryList()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryExist.Visible = false;
            if (IsPostBack)
            {
                AddCategory();
            }
            RenderCategoryList();
        }

        void AddCategory()
        {
            if (txtCategoryName.Text.Length > 0)
            {
                string categoryName = txtCategoryName.Text;
                categoryName = categoryName.Trim();
                categoryName = categoryName.Replace('/', '-');
                categoryName = categoryName.Replace("#", "-Sharp");
                string sql = $"SELECT * FROM categories WHERE name=N'{categoryName}';";
                DataTable dt = connectDatabase.GetData(sql);
                if (dt != null && dt.Rows.Count == 0)
                {
                    int id = 1;
                    sql = "SELECT TOP 1 id FROM categories ORDER BY id DESC";
                    dt = connectDatabase.GetData(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        id = int.Parse(dt.Rows[0]["id"].ToString()) + 1;
                    }
                    sql = $"INSERT INTO categories (id, name) VALUES ({id}, N'{categoryName}');";
                    if (connectDatabase.SetData(sql))
                    {
                        txtCategoryName.Text = "";
                        Session["category-create-success"] = true;
                    }    
                } else
                {
                    categoryExist.Visible = true;
                }
            }
            txtCategoryName.Focus();
        }

        void RenderCategoryList()
        {
            string sql = "SELECT * FROM categories ORDER BY id DESC";
            DataTable dt = connectDatabase.GetData(sql);
            string html = "";
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    html += "<tr>" +
                        $"<td>{i + 1}</td>" +
                        $"<td>{dr["name"]}</td>" +
                        "<td style='width: 150px'>" +
                        "<div class=\"dropdown\">" +
                        "<button type=\"button\" class=\"btn p-0 dropdown-toggle hide-arrow\" data-bs-toggle=\"dropdown\">" +
                        "<i class=\"bx bx-dots-vertical-rounded\"></i></button>" +
                        "<div class=\"dropdown-menu\">" +
                        $"<a style='cursor: pointer;' class=\"dropdown-item\" onclick='handleDeleteCategoryClick({dr["id"]}, \"{dr["name"]}\")' data-bs-toggle=\"modal\" data-bs-target=\"#smallModal\"><i class=\"bx bx-trash me-1\"></i> Xóa</a>" +
                        "</div></div>" +
                        "</td></tr>";
                }
                tbCategoryList.InnerHtml = html;
            }    
        }
    }
}