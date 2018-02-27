<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Sistema.Forms.Usuarios.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblEditar" runat="server" Text="Editar Usuario" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <asp:HiddenField ID="hfID" runat="server"></asp:HiddenField>
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblClave" runat="server" Text="Clave : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" style="margin-left: 2px" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo : "></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlTipo" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" Width="162px" OnClick="btnEditar_Click"/>
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