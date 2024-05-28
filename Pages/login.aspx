<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Veterinaria.Pages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-6">
                <div class="card vet-card">
                    <div class="card-header vet-header">
                        <h3 class="card-title">Iniciar sesión</h3>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label ID="lblUsername" runat="server" AssociatedControlID="username" Text="Nombre de usuario:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="username" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" ErrorMessage="Nombre de usuario requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="password" Text="Contraseña:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" Required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Contraseña requerida" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn btn-vet" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
