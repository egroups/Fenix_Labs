<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Sistema.Forms.Usuarios.Agregar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel contenedor panel-default">
        <div class="panel-heading">Agregar Usuario</div>
        <div class="panel-body">
            <fieldset>
                <div class="form-horizontal" role="form">
                    <legend>Datos</legend>
                    <div class="form-group" name="form-group-nombre">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese nombre" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-clave">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Clave" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Ingrese clave" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" name="form-group-tipo">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="col-lg-2 control-label"></asp:Label>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="ddlTipo" runat="server" DataTextField="nombre" DataValueField="id" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block" OnClick="btnAgregar_Click"/>
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
