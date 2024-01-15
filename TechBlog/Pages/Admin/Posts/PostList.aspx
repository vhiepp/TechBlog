<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostList.aspx.cs" Inherits="TechBlog.Pages.Admin.Posts.PostList" MasterPageFile="~/Pages/Admin/Admin.Master" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <title>Bài viết | TechBlog</title>
</asp:Content>

<asp:Content ID="AdminPostListContent" ContentPlaceHolderID="Content" runat="server">
    <div class="card">
        <h5 class="card-header">
            Bài viết chờ duyệt
            <div class="badge bg-success rounded-pill ms-auto" runat="server" id="totalPostAwait">0</div>
        </h5>
        <div class="table-responsive text-nowrap">
            <table class="table">
            <thead>
                <tr>
                    <th>Tên bài viết</th>
                    <th>Danh mục</th>
                    <th>Ngày tạo</th>
                    <th>Người đăng</th>
                    <th>Trạng thái</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody class="table-border-bottom-0" runat="server" id="tbPostAwait">
            </tbody>
            </table>
        </div>
     </div>

     <div class="card mt-5">
        <h5 class="card-header">
            Bài viết đang hiển thị
        </h5>
        <div class="table-responsive text-nowrap">
            <table class="table">
            <thead>
                <tr>
                    <th>Tên bài viết</th>
                    <th>Danh mục</th>
                    <th>Ngày tạo</th>
                    <th>Người đăng</th>
                    <th>Trạng thái</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody class="table-border-bottom-0" runat="server" id="tbPostList">
            </tbody>
            </table>
        </div>
     </div>

    <div class="modal fade" id="approvePostModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Thông báo</h5>
                    <button
                    type="button"
                    class="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p class="text-xl-start" id="txtMsgApprovePostModal">Bạn chắc chắn muốn duyệt bài viết này?</p>
                </div>
                <div class="modal-footer">
                    <a href="/" id="urlApprovePost">
                        <button type="button" class="btn btn-primary">Duyệt</button>
                    </a>
                    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="deletePostModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Thông báo</h5>
                    <button
                    type="button"
                    class="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p class="text-danger text-xl-start" id="txtMsgDeletePostModal">Bạn chắc chắn muốn XÓA bài viết này?</p>
                </div>
                <div class="modal-footer">
                    <a href="/" id="urlDeletePost">
                        <button type="button" class="btn btn-primary">Xóa</button>
                    </a>
                    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>

    <script>
        function handleApprovePostClick(slug) {
            document.getElementById("urlApprovePost").href = `/quan-tri/bai-viet/${slug}/approve`;
        }
        function handleDeletePostClick(slug) {
            document.getElementById("urlDeletePost").href = `/quan-tri/bai-viet/${slug}/delete`;
        }
    </script>

</asp:Content>
