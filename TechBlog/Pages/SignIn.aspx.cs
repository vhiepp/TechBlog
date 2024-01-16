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
    public partial class SignIn : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;
        public SignIn()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                HandleSignIn();
            }
        }

        void HandleSignIn()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string sql = $"SELECT TOP 1 * FROM users WHERE email='{username}';";
            DataTable dt = connectDatabase.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow data = dt.Rows[0];
                bool check = BCrypt.Net.BCrypt.Verify(password, data["password"].ToString());
                if (check)
                {
                    User user = new User();
                    user.Id = int.Parse(data["id"].ToString());
                    user.FullName = data["fullname"].ToString();
                    user.FirstName = data["firstname"].ToString();
                    user.LastName = data["lastname"].ToString();
                    user.Gender = data["gender"].ToString();
                    user.Role = data["role"].ToString();
                    user.Email = data["email"].ToString();
                    user.Avatar = data["avatar"].ToString();
                    Session["user"] = user;

                    if (Request.QueryString["continue"] != null)
                    {
                        string backUrl = Request.QueryString["continue"];
                        if (Request.QueryString["tag"] != null)
                        {
                            backUrl += $"#{Request.QueryString["tag"]}";
                        }
                        Response.Redirect(backUrl);
                    } else
                    {
                        Response.Redirect("/");
                    }

                } else
                {
                    Session["wrong-username-or-password"] = true;
                }
            } else
            {
                Session["wrong-username-or-password"] = true;
            }
        }
    }
}