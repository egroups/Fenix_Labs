<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Personal.Forms.Profesiones.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" role="form">
        <fieldset>
            <legend>Datos</legend>
            <asp:HiddenField ID="hfID" runat="server" />
            <div class="form-group">
                <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <center>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click"></asp:Button>
            </center>
        </fieldset>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
