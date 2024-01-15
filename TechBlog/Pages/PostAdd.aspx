<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="PostAdd.aspx.cs" Inherits="TechBlog.Pages.PostAdd" MasterPageFile="~/Pages/WithOutCategory.Master" %>

<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="/assets/css/posts-add.css">
    <script src="/assets/ckeditor5/ckeditor.js"></script>
    <title>Viết bài | Tech Blog</title>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Content">
    <div class="row">
        <div class="col-xl">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="mb-0 text-primary">Viết bài</h5>
                    <small class="text-muted float-end">...</small>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-fullname">Tiêu đề</label>
                        <asp:TextBox type="text" runat="server" CssClass="form-control" ID="txtTitle" Placeholder="Nhập tiêu đề bài viết" required/>
                    </div>
                    <div class="mb-3">
                        <label for="formFile" class="form-label">Chọn ảnh nền</label>
                        <asp:FileUpload ID="fThumnail" CssClass="form-control" runat="server" accept="image/*" required/>
                     </div>
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-fullname">Mô tả</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" ID="txtDescription" Placeholder="Nhập mô tả/ tóm tắt" required/>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-company">Nội dung</label>
                        <asp:TextBox runat="server" ID="editor" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-message">Danh mục</label>
                        <asp:DropDownList CssClass="form-select" ID="ddlCategoryList" runat="server">
                        </asp:DropDownList>
                    </div>
                    <button type="submit" class="btn btn-primary">Đăng</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        ClassicEditor
            .create(document.querySelector('#<%=editor.ClientID%>'), {
                placeholder: "Soạn nội dung...",
                ckfinder: {
                    uploadUrl: "https://sv5t-api.vhiep.com/api/upload",
                    options: {
                        resourceType: "Images",
                    },
                }
            })
            .catch( error => {
                console.error( error );
            } );
    </script>
</asp:Content>