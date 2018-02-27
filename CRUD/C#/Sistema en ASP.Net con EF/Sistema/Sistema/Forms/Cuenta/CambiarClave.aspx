<%@ Page Title="Cambiar Clave" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="Sistema.Forms.Cuenta.CambiarClave" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblTitulo" runat="server" Text="Cambiar Clave" Font-Size="XX-Large"></asp:Label>
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
                    <asp:Label ID="lblActualClave" runat="server" Text="Actual Clave : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtActualClave" runat="server" TextMode="Password" style="margin-left: 2px" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblNuevaClave" runat="server" Text="Nueva Clave : "></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNuevaClave" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnCambiarClave" runat="server" Text="Cambiar" Width="162px" OnClick="btnCambiarClave_Click"/>
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
            width: 195px;
        }
        .auto-style5 {
            height: 26px;
            width: 195px;
        }
    </style>
</asp:Content>
