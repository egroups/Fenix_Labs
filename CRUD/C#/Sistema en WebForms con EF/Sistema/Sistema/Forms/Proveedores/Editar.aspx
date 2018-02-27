<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Sistema.Forms.Proveedores.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel contenedor panel-default">
        <div class="panel-heading">
            <asp:Label ID="lblEditar" runat="server" Text="Editar Proveedor"></asp:Label>
        </div>
        <div class="panel-body">
            <fieldset>
                <div class="form-horizontal" role="form">
                    <legend>Datos</legend>
                    <asp:HiddenField ID="hfID" runat="server" />
                    <div class="form-group" name="form-group-nombre">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese nombre" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-direccion">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtDireccion" runat="server" placeholder="Ingrese descripción" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-telefono">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtTelefono" runat="server" placeholder="Ingrese teléfono" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary btn-block" OnClick="btnEditar_Click" />
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
