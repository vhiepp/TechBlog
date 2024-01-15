<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TechBlog.Pages.Home" MasterPageFile="~/Pages/Default.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/assets/css/home.css">
    <title>Trang chủ | Tech Blog</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <style>
            .btn-paginate {
                color: #0069E4;
                font-size: 16px;
                font-weight: 600;
                text-decoration: none;
            }

            .disable {
                color: #f0f0f0;
            }

            .container-paginate {
                display: flex;
                justify-content: space-between;
            }
        </style>
    
        <div runat="server" class="content_left" id="postList"></div>

        <div class="container-paginate">
            <asp:HyperLink CssClass="btn-paginate disable" runat="server" ID="prePage">TRANG TRƯỚC</asp:HyperLink>
            <asp:HyperLink CssClass="btn-paginate disable" runat="server" ID="nextPage">TRANG KẾ</asp:HyperLink>
        </div>
    
</asp:Content>