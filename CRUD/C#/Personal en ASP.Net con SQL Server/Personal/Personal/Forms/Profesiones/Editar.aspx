<%@ Page Title="Editar" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Personal.Forms.Profesiones.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1>Editar Profesión</h1>
        <table>
            <asp:HiddenField ID="hfID" runat="server"></asp:HiddenField>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" Width="119px" OnClick="btnEditar_Click"/>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
