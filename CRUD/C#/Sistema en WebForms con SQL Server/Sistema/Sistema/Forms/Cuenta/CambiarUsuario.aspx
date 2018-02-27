<%@ Page Title="Cambiar Usuario" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="CambiarUsuario.aspx.cs" Inherits="Sistema.Forms.Cuenta.CambiarUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel contenedor panel-default">
        <div class="panel-heading">Cambiar Usuario</div>
        <div class="panel-body">
            <fieldset>
                <div class="form-horizontal" role="form">
                    <legend>Datos</legend>
                    <div class="form-group" name="form-group-usuario">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese usuario" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-nuevo-usuario">
                        <asp:Label ID="lblNuevoUsuario" runat="server" Text="Nuevo usuario" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtNuevoUsuario" runat="server" CssClass="form-control" placeholder="Ingrese nuevo usuario"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-clave">
                        <asp:Label ID="lblActualClave" runat="server" Text="Actual Clave" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese clave"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" CssClass="btn btn-primary button_class center-block" OnClick="btnCambiar_Click"></asp:Button>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
