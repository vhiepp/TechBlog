<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="TechBlog.Pages.PostDetail" MasterPageFile="~/Pages/Default.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/assets/css/posts-detail.css">
    <link rel="stylesheet" href="/assets/css/ck-style.css">
    <title runat="server" id="pageTitle"></title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <h1 class="post-title" runat="server" style="margin-bottom: 0" id="title"></h1>
    <span class="post-author" runat="server" id="author">
    </span>
    <span class="post-tag">
        <b>Tag: </b>
        <span runat="server" id="category">
        </span>
    </span>
    
    <div runat="server" id="content" class="ck-content mb-5"></div>
    

    <h3 id="comments" class="post-comment-title">Bình luận</h3>
    <div class="input-group">
        <asp:TextBox type="text" CssClass="form-control input-comment" ID="txtComment" runat="server" required></asp:TextBox>
        <button class="btn btn-primary" type="submit" runat="server" id="btnComment">Bình luận</button>
    </div>
    <div class="comment-list" runat="server" id="commentList">

    </div>
</asp:Content>