<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="TechBlog.Pages.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Đăng nhập | TechBlog</title>
    <link rel="stylesheet" href="/assets/css/sign-in.css">
</head>
<body>
    <form id="form1" method="post" runat="server">
        <div class="sign-in-container">
            <div class="content">
                <div class="head">
                    <h3>Đăng nhập</h3>
                    <h2>TECH BLOG</h2>
                </div>
                <div class="body">
                    <asp:TextBox type="text" Placeholder="Tên đăng nhập" ID="txtUsername" runat="server" required></asp:TextBox>
                    <asp:TextBox type="password" placeholder="Mật khẩu" ID="txtPassword" runat="server" required></asp:TextBox>
                    <%=
                        Session["wrong-username-or-password"] != null && (bool)Session["wrong-username-or-password"] && (Session["wrong-username-or-password"] = null) == null ?
                        "<span style='color: red;'><small><i>" +
                            "Sai tên đăng nhập hoặc mật khẩu!" +
                        "</i></small></span>" : ""
                    %>
                    <button type="submit">Đăng nhập</button>
                </div>
                <div class="foot">
                    <a href="/dang-ky">Đăng ký</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
