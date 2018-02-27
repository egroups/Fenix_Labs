<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Sistema.Forms.Proveedores.Agregar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblAgregar" runat="server" Text="Agregar Proveedor" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección : "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtDireccion" runat="server" style="margin-left: 2px" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono : "></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="162px" OnClick="btnAgregar_Click"/>
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
