<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TechBlog.Pages.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Đăng ký | TechBLog</title>
    <link rel="stylesheet" href="/assets/css/sign-up.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="sign-up-container">
                <div class="content">
                    <div class="head">
                        <h3>Đăng ký</h3>
                        <h2>TECH BLOG</h2>
                    </div>
                    <div class="body">
                        <input type="text" placeholder="Tên đầy đủ"/>
                        <input type="email" placeholder="Email"/>
                        <input type="password" placeholder="Mật khẩu"/>
                        <select name="sex">
                            <option value="male">Nam</option>
                            <option value="female">Nữ</option>
                            <option value="other">Khác</option>
                        </select>
                        <button type="button">Đăng ký</button>
                    </div>
                    <div class="foot">
                        <a href="/dang-nhap">Đăng nhập</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
