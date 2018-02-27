<%@ Page Title="Cambiar Usuario" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="CambiarUsuario.aspx.cs" Inherits="Sistema.Forms.Cuenta.CambiarUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblTitulo" runat="server" Text="Cambiar Usuario" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNuevoUsuario" runat="server" Text="Nuevo usuario : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNuevoUsuario" runat="server" style="margin-left: 2px" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblClave" runat="server" Text="Clave : "></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnCambiarUsuario" runat="server" Text="Cambiar" Width="162px" OnClick="btnCambiarUsuario_Click"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            width: 138px;
        }
        .auto-style3 {
            height: 26px;
            width: 138px;
        }
        .auto-style4 {
            height: 26px;
            width: 195px;
        }
        .auto-style5 {
            height: 26px;
            width: 195px;
        }
    </style>
</asp:Content>

