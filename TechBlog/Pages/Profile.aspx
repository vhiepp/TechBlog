<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TechBlog.Pages.Profile" MasterPageFile="~/Pages/WithOutCategory.Master" %>

<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="/assets/css/profile.css">
    <title>Hồ sơ cá nhân | Tech Blog</title>
</asp:Content>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="Content">

    <div class="card mb-4">
        <h5 class="card-header">Hồ sơ cá nhân</h5>
        <div class="card-body">
            <div class="d-flex align-items-start align-items-sm-center gap-4">
            <img src="<%=((TechBlog.Models.User)Session["user"]).Avatar %>" alt="user-avatar" class="d-block rounded" height="100" width="100" id="uploadedAvatar">
            <div class="button-wrapper">
                <p class="display-5"><strong><%=((TechBlog.Models.User)Session["user"]).FullName %></strong></p>
                <p class="text-muted mb-0"><%=((TechBlog.Models.User)Session["user"]).Email %></p>
                <p class="text-muted mb-0"><%=((TechBlog.Models.User)Session["user"]).Role %></p>
            </div>
            </div>
        </div>
        <hr class="my-0">
        <h5 class="card-header">Bài viết của bạn</h5>
        <div class="card-body">
            <div class="nav-align-top mb-4">
                <%=(Session["create_post_success"] != null && ((bool)Session["create_post_success"]) && (Session["create_post_success"] = null) == null) ?
                       "<div class=\"alert alert-info alert-dismissible\" role=\"alert\">Bài viết của bạn đã được đưa vào trạng thái chờ duyệt!<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div>" : ""
                %>
                
                <ul class="nav nav-pills mb-3" role="tablist">
                    <li class="nav-item" role="presentation">
                        <button type="button" class="nav-link active" role="tab" data-bs-toggle="tab" data-bs-target="#navs-pills-top-home" aria-controls="navs-pills-top-home" aria-selected="true" tabindex="0">
                            Hiển thị
                        </button>
                    </li>
                    <li class="nav-item" role="presentation">
                        <button type="button" class="nav-link" role="tab" data-bs-toggle="tab" data-bs-target="#navs-pills-top-profile" aria-controls="navs-pills-top-profile" aria-selected="false" tabindex="1">
                            Chờ duyệt
                            <span runat="server" id="totalPostAwait" class="badge rounded-pill badge-center h-px-20 w-px-20 bg-danger ms-1">0</span>
                        </button>
                    </li>
                </ul>
                <div class="tab-content" style="box-shadow: unset">
                    <div class="tab-pane fade active show" id="navs-pills-top-home" role="tabpanel">
                        <div class="post-list" runat="server" id="postListShow">
                            <p class="text-muted text-center" style="font-size: 14px">Chưa có bài viết</p>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="navs-pills-top-profile" role="tabpanel">
                        <div class="post-list" runat="server" id="postListAwait">
                            <p class="text-muted text-center" style="font-size: 14px">Chưa có bài viết</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>