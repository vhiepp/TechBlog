using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Models;

namespace TechBlog.Pages.Admin.Posts
{
    public partial class PostEdit : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;
        public PostEdit()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && HandleCreateNewPost(RouteData.Values["slug"].ToString()))
            {
                Response.Redirect("/quan-tri/bai-viet");
            }
            LoadDataWithPost(RouteData.Values["slug"].ToString());
        }

        void RenderDDLCategoryList(string id = "0")
        {
            string sql = "SELECT * FROM categories ORDER BY id DESC;";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null)
            {
                int select = 0;
                ddlCategoryList.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListItem item = new ListItem();
                    item.Text = dr["name"].ToString();
                    item.Value = dr["id"].ToString();
                    if (id == dr["id"].ToString())
                    {
                        select = i;
                    }
                    ddlCategoryList.Items.Add(item);
                }
                ddlCategoryList.SelectedIndex = select;
            }
        }
        void LoadDataWithPost(string slug)
        {
            string sql = $"SELECT TOP 1 * FROM posts WHERE slug='{slug}'";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txtTitle.Text = dr["title"].ToString();
                txtDescription.Text = dr["description"].ToString();
                editor.Text = dr["content"].ToString();
                RenderDDLCategoryList(dr["category_id"].ToString());
            }
        }

        bool HandleCreateNewPost(string slug)
        {
            try
            {
                string title = txtTitle.Text.Replace("'", "`");
                string content = editor.Text.Replace("'", "`");
                int categoryId = int.Parse(ddlCategoryList.SelectedItem.Value.ToString());
                string fileExtension = Path.GetExtension(fThumnail.FileName).ToLower();
                string description = txtDescription.Text.Replace("'", "`");
                string path = "";
                if (Path.GetFileName(fThumnail.FileName).Length > 0 && (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif"))
                {
                    string fileName = new Random().Next(1000, 9999).ToString() + Path.GetFileName(fThumnail.FileName);
                    fileName = fileName.Replace("'", "");
                    path = $"/Images/";
                    fThumnail.SaveAs(Server.MapPath($"~{path}") + fileName);
                    path += fileName;
                }

                string sql = $"UPDATE posts SET title=N'{title}', content=N'{content}', category_id={categoryId}, description=N'{description}'";
                if (path.Length > 0)
                {
                    sql += $", thumbnail_url=N'{path}'";
                }

                sql += $" WHERE slug='{slug}'";
                connectDatabase.SetData(sql);
                return true;
            }
            catch (Exception ex) { }
            return false;
        }
    }
}