<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema.Forms.Proveedores.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblProveedores" runat="server" Text="Proveedores" Font-Size="Larger"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtBuscar" runat="server" style="margin-left: 0px" Width="305px"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="109px" OnClick="btnBuscar_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblProveedoresEncontrados" runat="server" Text="Proveedores encontrados" Font-Size="Larger"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="fecha_registro" HeaderText="Registro" />
                <asp:TemplateField HeaderText="Opción">
                    <ItemTemplate>
                        <a href="/Forms/Proveedores/Editar.aspx?id=<%# Eval("id")  %>">Editar</a>
                        <a href="/Forms/Proveedores/Borrar.aspx?id=<%# Eval("id")  %>">Borrar</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
        <br />
        <asp:HyperLink ID="hlAgregarProveedor" runat="server" NavigateUrl="~/Forms/Proveedores/Agregar.aspx">Agregar Proveedor</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 60px;
        }
        .auto-style2 {
            width: 70px;
        }
        .auto-style3 {
            width: 70px;
        }
    </style>
</asp:Content>
