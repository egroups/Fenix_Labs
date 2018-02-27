<%@ Page Title="Editar" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Personal.Forms.Empleados.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1>Editar Producto</h1>
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
                <td class="auto-style2">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección : "></asp:Label>
&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono : "></asp:Label>
&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblSexo" runat="server" Text="Sexo : "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" Checked="True"/>
                    <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblProfesion" runat="server" Text="Profesión : "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProfesiones" runat="server" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
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
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" Width="119px" OnClick="btnEditar_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 73px;
        }
        .auto-style3 {
            height: 23px;
            width: 73px;
        }
    </style>
</asp:Content>