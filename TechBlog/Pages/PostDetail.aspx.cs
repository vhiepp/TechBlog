using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechBlog.Models;

namespace TechBlog.Pages
{
    public partial class PostDetail : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;
        public PostDetail()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    txtComment.Attributes["placeholder"] = "Nhập bình luận của bạn";
                }
                else
                {
                    txtComment.Attributes["placeholder"] = "Đăng nhập để bình luận";
                    txtComment.Attributes["disabled"] = "disabled";
                    btnComment.InnerText = "Đăng nhập";
                    btnComment.Attributes["onclick"] = "window.location.href='/dang-nhap'";
                    btnComment.Attributes["type"] = "button";
                }
            } else
            {
                if (Session["user"] != null)
                {
                    if (HandleCreateCommentForPost())
                    {
                        txtComment.Text = "";
                        Response.Redirect(Request.RawUrl + "#comments");
                    }    
                }
            }
            if (RouteData.Values["slug"] != null)
            {
                RenderPostDetailWithSlug(RouteData.Values["slug"].ToString());
            }    
        }

        void RenderPostDetailWithSlug(string slug)
        {
            string sql = $"SELECT TOP 1 posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.updated_at, 'dd') AS updated_D, FORMAT(posts.updated_at, 'MM, yyyy') AS updated_MY FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.status=1 AND posts.slug='{slug}'";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pageTitle.InnerText = $"{dr["title"]} | Tech Blog";
                title.InnerText = dr["title"].ToString();
                author.InnerText = $"{dr["fullname"]} | {dr["updated_D"]} THG {dr["updated_MY"]}";
                category.InnerText = $"#{dr["category_name"]}";
                content.InnerHtml = dr["content"].ToString();
                RenderCommentListWithPostId(dr["id"].ToString());
                Session["post_id"] = dr["id"].ToString();
            }
        }

        void RenderCommentListWithPostId(string id)
        {
            string sql = $"SELECT comments.*, users.avatar, users.fullname, FORMAT(comments.created_at, 'dd') AS updated_D, FORMAT(comments.created_at, 'MM, yyyy') AS updated_MY FROM comments JOIN users ON comments.author_id = users.id WHERE comments.post_id={id} ORDER BY created_at DESC";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null)
            {
                string html = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    html += "<div class=\"comment-item\">" +
                        "<div class=\"comment-item_left\">" +
                        $"<img src=\"{dr["avatar"]}\" class=\"w-px-40 h-px-40 rounded-circle\" alt=\"\" />\r\n            </div>" +
                        "<div class=\"comment-item_right\"><div>" +
                        $"<span class=\"comment-author\">{dr["fullname"]}</span>" +
                        $"<span class=\"comment-created_date\">| {dr["updated_D"]} Thg {dr["updated_MY"]}</span>" +
                        "</div><div class=\"comment-content\">" +
                        $"<p>{dr["content"]}</p></div></div></div>";
                }
                commentList.InnerHtml = html;
            }
        }

        bool HandleCreateCommentForPost()
        {
            try
            {
                if (Session["post_id"] != null)
                {
                    int id = 1;
                    string postId = Session["post_id"].ToString();
                    string comment = txtComment.Text.Replace("'", "`");
                    int authorId = ((User)Session["user"]).Id;
                    string sql = "SELECT TOP 1 id FROM comments ORDER BY id DESC";
                    DataTable dt = connectDatabase.GetData(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        id = int.Parse(dt.Rows[0]["id"].ToString()) + 1;
                    }

                    sql = $"INSERT INTO comments (id, content, author_id, post_id, created_at, updated_at) VALUES ('{id}', N'{comment}', '{authorId}', '{postId}', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);";
                    connectDatabase.SetData(sql);
                    return true;
                }
            } catch (Exception ex) { }
            return false;
        }
    }
}