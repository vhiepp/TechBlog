<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="TechBlog.Pages.Admin.Categories.CategoryList" MasterPageFile="~/Pages/Admin/Admin.Master" %>

<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
    <title>Danh mục | TechBlog</title>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="row">
        <div class="col-xl">
            <div class="card mb-4">
                <%=
                    Session["category-create-success"] != null && (bool)Session["category-create-success"] && (Session["category-create-success"] = null) == null ?
                    "<div class='alert alert-success alert-dismissible' role='alert'>" +
                        "Thêm danh mục thành công." +
                        "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                    "</div>" : ""
                %>
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="mb-0">Thêm danh mục</h5>
                    <small class="text-muted float-end">...</small>
                </div>
                <div class="card-body">
                    <form method="post">
                        <div class="mb-3">
                            <label class="form-label" for="basic-default-fullname">Tên danh mục</label>
                            <asp:TextBox CssClass="form-control" ID="txtCategoryName" runat="server" Placeholder="Nhập tên danh mục" required></asp:TextBox>
                            <small class="text-danger ms-2" runat="server" id="categoryExist"><i>Danh mục đã tồn tại</i></small>
                        </div>
                        <button type="submit" class="btn btn-primary">Thêm</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <%=
            Session["category-delete-success"] != null && (bool)Session["category-delete-success"] && (Session["category-delete-success"] = null) == null ?
            "<div class='alert alert-success alert-dismissible' role='alert'>" +
                "Xóa danh mục thành công." +
                "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
            "</div>" : ""
        %>
        <%=
            Session["category-delete-error"] != null && (bool)Session["category-delete-error"] && (Session["category-delete-error"] = null) == null ?
            "<div class='alert alert-danger alert-dismissible' role='alert'>" +
                "Xóa danh mục thất bại, có thể do danh mục này đã tồn tại bài viết." +
                "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
            "</div>" : ""
        %>
        <h5 class="card-header">
            Danh mục
        </h5>
        <div class="table-responsive text-nowrap">
            <table class="table">
                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Tên danh mục</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody class="table-border-bottom-0" runat="server" id="tbCategoryList">
                </tbody>
            </table>
        </div>
     </div>

    <div class="modal fade" id="smallModal" tabindex="-1" aria-hidden="true">
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
                    <p class="text-danger text-xl-start" id="txtMsgDeleteCategoryModal"></p>
                </div>
                <div class="modal-footer">
                    <a href="/" id="urlDeleteCategory">
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
        function handleDeleteCategoryClick(id, name) {
            document.getElementById("txtMsgDeleteCategoryModal").innerHTML = `Bạn chắc chắn muốn xóa danh mục ${name}?`;
            document.getElementById("urlDeleteCategory").href = `/quan-tri/danh-muc/${id}/delete`;
        }
    </script>
</asp:Content>