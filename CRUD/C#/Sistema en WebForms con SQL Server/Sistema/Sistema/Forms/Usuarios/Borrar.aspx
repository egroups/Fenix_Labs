<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Borrar.aspx.cs" Inherits="Sistema.Forms.Usuarios.Borrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <fieldset>
            <div class="col-md-4 col-md-offset-4">
                <asp:HiddenField ID="hfID" runat="server" />
                <h1 class="text-center">Eliminacíon</h1>
                <p class="text-center">
                    <asp:Label ID="lblBorrar" runat="server" Text="¿ Estás seguro que deseas eliminar al usuario ?"></asp:Label>
                </p>
                <div class="col-xs-6 text-left">
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger btn-block" OnClick="btnBorrar_Click"/>
                </div>
                <div class="col-xs-6 text-right">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary btn-block" OnClick="btnVolver_Click"/>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
