<%@ Page Title="Login" Language="C#" MasterPageFile="~/Layouts/Login.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema.Forms.Login.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel login panel-default">
        <div class="panel-heading">Login</div>
        <div class="panel-body">
            <fieldset>
                <div class="form-horizontal" role="form">
                    <legend>Datos</legend>
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese usuario"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Clave" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtClave" TextMode="Password" runat="server" CssClass="form-control" placeholder="Ingrese clave"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-block" OnClick="btnIngresar_Click" />
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
