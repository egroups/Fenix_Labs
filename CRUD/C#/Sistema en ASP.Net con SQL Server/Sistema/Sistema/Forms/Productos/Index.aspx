<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema.Forms.Productos.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Label ID="lblProductos" runat="server" Text="Productos" Font-Size="Larger"></asp:Label>
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
        <asp:Label ID="lblProductosEncontrados" runat="server" Text="Productos encontrados" Font-Size="Larger"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Proveedor">
                    <Itemtemplate>
                        <p><%# DataBinder.Eval(Container.DataItem, "proveedor.nombre") %>
                        </p>
                    </Itemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="fecha_registro" HeaderText="Registro" />
                <asp:TemplateField HeaderText="Opción">
                    <ItemTemplate>
                        <a href="/Forms/Productos/Editar.aspx?id=<%# Eval("id")  %>">Editar</a>
                        <a href="/Forms/Productos/Borrar.aspx?id=<%# Eval("id")  %>">Borrar</a>
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
        <asp:HyperLink ID="hlAgregarProducto" runat="server" NavigateUrl="~/Forms/Productos/Agregar.aspx">Agregar Producto</asp:HyperLink>
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

