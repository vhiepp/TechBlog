using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages.Admin.Posts
{
    public partial class PostList : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public PostList()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderPostAwaitList();
            RenderPostList();
        }

        void RenderPostAwaitList()
        {
            string sql = "SELECT posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.created_at, 'H:mm dd/MM/yyyy') AS created_date FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.status=0 ORDER BY posts.created_at DESC;";
            DataTable dt = connectDatabase.GetData(sql);
            string html = "";
            totalPostAwait.InnerHtml = dt.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                html += $"<tr><td style='min-width: 400px; max-width: 400px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;'>" +
                    $"<img src=\"{dr["thumbnail_url"]}\" style='height: 60px; width: 90px; object-fit: cover;' alt=\"{dr["title"]}\" />" +
                    $"<span class=\"fw-medium ms-2\">{dr["title"]}</span>" +
                    "</td>" +
                    $"<td>{dr["category_name"]}</td>" +
                    $"<td>{dr["created_date"]}</td>" +
                    "<td>" +
                    "<ul class=\"list-unstyled users-list m-0 avatar-group d-flex align-items-center\">" +
                    "<li " +
                    "data-bs-toggle=\"tooltip\"" +
                    "data-popup=\"tooltip-custom\"" +
                    "data-bs-placement=\"top\"" +
                    "class=\"avatar avatar-xs pull-up\"" +
                    $"title=\"{dr["fullname"]}\">" +
                    $"<img src=\"{dr["avatar"]}\" alt=\"{dr["fullname"]}\" class=\"rounded-circle\" />" +
                    $"<span class=\"fw-medium\">{dr["fullname"]}</span>" +
                    "</li>" +
                    "</ul>" +
                    "</td>" +
                    "<td><span class=\"badge bg-label-warning me-1\">Await</span></td>" +
                    "<td>" +
                    "<div class=\"dropdown\">" +
                    "<button type=\"button\" class=\"btn p-0 dropdown-toggle hide-arrow\" data-bs-toggle=\"dropdown\">" +
                    "<i class=\"bx bx-dots-vertical-rounded\"></i></button>" +
                    $"<div class=\"dropdown-menu\"><a class=\"dropdown-item\" href=\"/quan-tri/bai-viet/{dr["slug"]}/edit\"" +
                    $"><i class=\"bx bx-edit-alt me-1\"></i> Edit</a><a class=\"dropdown-item\" style='cursor: pointer;' data-bs-toggle=\"modal\" data-bs-target=\"#deletePostModal\" onclick='handleDeletePostClick(\"{dr["slug"]}\")'><i class=\"bx bx-trash me-1\"></i> Xóa</a>" +
                    $"<a class=\"dropdown-item\" style='cursor: pointer;' data-bs-toggle=\"modal\" data-bs-target=\"#approvePostModal\" onclick='handleApprovePostClick(\"{dr["slug"]}\")'><i class=\"bx bx-check me-1\"></i> Duyệt</a>" +
                    "</div></div>" +
                    "</td></tr>";
            }
            tbPostAwait.InnerHtml = html;
        }

        void RenderPostList()
        {
            string sql = "SELECT posts.*, users.fullname, users.avatar, categories.name AS category_name, FORMAT(posts.created_at, 'H:mm dd/MM/yyyy') AS created_date FROM posts JOIN users ON posts.author_id = users.id JOIN categories ON categories.id = posts.category_id WHERE posts.status=1 ORDER BY posts.created_at DESC;";
            DataTable dt = connectDatabase.GetData(sql);
            string html = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                html += $"<tr><td style='min-width: 400px; max-width: 400px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;'>" +
                    $"<img src=\"{dr["thumbnail_url"]}\" style='height: 60px; width: 90px; object-fit: cover;' alt=\"{dr["title"]}\" />" +
                    $"<span class=\"fw-medium ms-2\">{dr["title"]}</span>" +
                    "</td>" +
                    $"<td>{dr["category_name"]}</td>" +
                    $"<td>{dr["created_date"]}</td>" +
                    "<td>" +
                    "<ul class=\"list-unstyled users-list m-0 avatar-group d-flex align-items-center\">" +
                    "<li " +
                    "data-bs-toggle=\"tooltip\"" +
                    "data-popup=\"tooltip-custom\"" +
                    "data-bs-placement=\"top\"" +
                    "class=\"avatar avatar-xs pull-up\"" +
                    $"title=\"{dr["fullname"]}\">" +
                    $"<img src=\"{dr["avatar"]}\" alt=\"{dr["fullname"]}\" class=\"rounded-circle\" />" +
                    $"<span class=\"fw-medium\">{dr["fullname"]}</span>" +
                    "</li>" +
                    "</ul>" +
                    "</td>" +
                    "<td><span class=\"badge bg-label-success me-1\">Show</span></td>" +
                    "<td>" +
                    "<div class=\"dropdown\">" +
                    "<button type=\"button\" class=\"btn p-0 dropdown-toggle hide-arrow\" data-bs-toggle=\"dropdown\">" +
                    "<i class=\"bx bx-dots-vertical-rounded\"></i></button>" +
                    $"<div class=\"dropdown-menu\"><a class=\"dropdown-item\" href=\"/quan-tri/bai-viet/{dr["slug"]}/edit\"" +
                    $"><i class=\"bx bx-edit-alt me-1\"></i> Edit</a><a class=\"dropdown-item\" style='cursor: pointer;' data-bs-toggle=\"modal\" data-bs-target=\"#deletePostModal\" onclick='handleDeletePostClick(\"{dr["slug"]}\")'><i class=\"bx bx-trash me-1\"></i> Xóa</a>" +
                    "</div></div>" +
                    "</td></tr>";
            }
            tbPostList.InnerHtml = html;
        }
    }
}