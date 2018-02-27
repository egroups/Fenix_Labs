<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Borrar.aspx.cs" Inherits="Sistema.Forms.Productos.Borrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblBorrar" runat="server" Text="Borrar Producto" Font-Size="XX-Large"></asp:Label>
        <br />
        <asp:HiddenField ID="hfID" runat="server"></asp:HiddenField>
        <table>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Button ID="btnBorrar" runat="server" Text="Borrar" Width="100px" OnClick="btnBorrar_Click"></asp:Button></td>
                <td class="auto-style2"><asp:Button ID="btnVolver" runat="server" Text="Volver" Width="103px" OnClick="btnVolver_Click"></asp:Button></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
        <br />  
    </center>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 113px;
        }
        .auto-style2 {
            width: 113px;
        }
    </style>
</asp:Content>
