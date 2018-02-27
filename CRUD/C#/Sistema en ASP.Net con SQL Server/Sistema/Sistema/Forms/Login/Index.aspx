<%@ Page Title="Login" Language="C#" MasterPageFile="~/Layouts/Login.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema.Forms.Login.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblLogin" runat="server" Text="Login" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario : "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="271px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblClave" runat="server" Text="Clave : "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtClave" runat="server" Width="271px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" Width="274px" OnClick="btnIngresar_Click" />
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
            width: 334px;
        }
        .auto-style2 {
            width: 70px;
        }
    </style>
</asp:Content>

