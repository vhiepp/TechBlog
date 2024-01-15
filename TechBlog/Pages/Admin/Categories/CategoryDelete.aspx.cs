using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechBlog.Pages.Admin.Categories
{
    public partial class CategoryDelete : System.Web.UI.Page
    {
        ConnectDatabase connectDatabase;

        public CategoryDelete()
        {
            connectDatabase = new ConnectDatabase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool ok = HandleDeleteCategoryWithId(int.Parse(RouteData.Values["id"].ToString()));
                if (ok)
                {
                    Session["category-delete-success"] = true;
                } else
                {
                    Session["category-delete-error"] = true;
                }    
            } catch (Exception ex) { }
            Response.Redirect("/quan-tri/danh-muc");    
        }

        bool HandleDeleteCategoryWithId(int id)
        {
            string sql = $"DELETE FROM categories WHERE id='{id}';";
            System.Diagnostics.Debug.WriteLine(sql);
            return connectDatabase.SetData(sql);
        }
    }
}