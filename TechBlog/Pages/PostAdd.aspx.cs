using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Models;

namespace TechBlog.Pages
{
    public partial class PostAdd : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public PostAdd()
        {
            
            connectDatabase = new ConnectDatabase();
        }

        public string GenerateSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            string slug = input.ToLower();

            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            slug = slug.Replace(" ", "-");

            slug = Regex.Replace(slug, @"-{2,}", "-");

            return slug + '-' + new Random().Next(1000, 9999).ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/dang-nhap?continue=/viet-bai");
            }
            if (IsPostBack && HandleCreateNewPost())
            {
                Session["create_post_success"] = true;
                Response.Redirect("/ho-so-ca-nhan");
            }
            RenderDDLCategoryList();
        }

        void RenderDDLCategoryList()
        {
            string sql = "SELECT * FROM categories ORDER BY id DESC;";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null)
            {
                ddlCategoryList.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListItem item = new ListItem();
                    item.Text = dr["name"].ToString();
                    item.Value = dr["id"].ToString();
                    ddlCategoryList.Items.Add(item);
                }
                ddlCategoryList.SelectedIndex = 0;
            }
        }

        bool HandleCreateNewPost()
        {
            try
            {
                string title = txtTitle.Text.Replace("'", "`");
                string content = editor.Text.Replace("'", "`");
                int categoryId = int.Parse(ddlCategoryList.SelectedItem.Value.ToString());
                string fileExtension = Path.GetExtension(fThumnail.FileName).ToLower();
                string description = txtDescription.Text.Replace("'", "`");
                string path = "";

                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                {
                    string fileName = new Random().Next(1000, 9999).ToString() + Path.GetFileName(fThumnail.FileName);
                    fileName = fileName.Replace("'", "");
                    path = $"/Images/";
                    fThumnail.SaveAs(Server.MapPath($"~{path}") + fileName);
                    path += fileName;
                }
                else
                {
                    return false;
                }
                string slug = GenerateSlug(title);
                int id = 1;
                int authorId = ((User)Session["user"]).Id;
                string sql = "SELECT TOP 1 id FROM posts ORDER BY id DESC";
                DataTable dt = connectDatabase.GetData(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    id = int.Parse(dt.Rows[0]["id"].ToString()) + 1;
                }

                sql = $"INSERT INTO posts (id, title, content, thumbnail_url, author_id, category_id, slug, created_at, updated_at, status, description) VALUES" +
                    $"({id}, N'{title}', N'{content}', N'{path}', {authorId}, {categoryId}, '{slug}', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 0, N'{description}');";

                connectDatabase.SetData(sql);

                return true;
            }
            catch (Exception ex) { }
            return false;
        }
    }
}