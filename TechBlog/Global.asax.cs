using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TechBlog
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // trang nguoi dung
            RouteTable.Routes.MapPageRoute(
                "Home1",
                "",
                "~/Pages/Home.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Home2",
                "trang-chu",
                "~/Pages/Home.aspx"
            );

            RouteTable.Routes.MapPageRoute(
                "SignIn",
                "dang-nhap",
                "~/Pages/SignIn.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "SignUp",
                "dang-ky",
                "~/Pages/SignUp.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "SignOut",
                "dang-xuat",
                "~/Pages/SignOut.aspx"
            );

            RouteTable.Routes.MapPageRoute(
                "Post-Add",
                "viet-bai",
                "~/Pages/PostAdd.aspx"
            );

            RouteTable.Routes.MapPageRoute(
                "Profile",
                "ho-so-ca-nhan",
                "~/Pages/Profile.aspx"
            );

            RouteTable.Routes.MapPageRoute(
                "Post-Detail",
                "bai-viet/{slug}",
                "~/Pages/PostDetail.aspx"
            );

            /* trang quan tri */
            RouteTable.Routes.MapPageRoute(
                "Admin-Dashboard",
                "quan-tri",
                "~/Pages/Admin/Dashboard.aspx"
            );

            // quản lý danh mục
            RouteTable.Routes.MapPageRoute(
                "Admin-Categories",
                "quan-tri/danh-muc",
                "~/Pages/Admin/Categories/CategoryList.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Categories-Delete",
                "quan-tri/danh-muc/{id}/delete",
                "~/Pages/Admin/Categories/CategoryDelete.aspx"
            );

            // quản lý bài viết
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-List",
                "quan-tri/bai-viet",
                "~/Pages/Admin/Posts/PostList.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-Add",
                "quan-tri/bai-viet/them-moi",
                "~/Pages/Admin/Posts/PostAdd.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-Approve",
                "quan-tri/bai-viet/{slug}/approve",
                "~/Pages/Admin/Posts/PostApprove.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-Edit",
                "quan-tri/bai-viet/{slug}/edit",
                "~/Pages/Admin/Posts/PostEdit.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-Detail",
                "quan-tri/bai-viet/{slug}",
                "~/Pages/Admin/Posts/PostDetail.aspx"
            );
            RouteTable.Routes.MapPageRoute(
                "Admin-Post-Delete",
                "quan-tri/bai-viet/{slug}/delete",
                "~/Pages/Admin/Posts/PostDelete.aspx"
            );

            RouteTable.Routes.MapPageRoute(
                "HomeWithCategory",
                "{category}",
                "~/Pages/Home.aspx"
            );
        }
    }
}