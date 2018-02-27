<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Personal.Forms.Empleados.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
      <h1>Empleados</h1>
      <br />
      <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron empleados">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                <asp:TemplateField HeaderText="Profesión">
                    <Itemtemplate>
                        <p><%# DataBinder.Eval(Container.DataItem, "profesion.nombre") %>
                        </p>
                    </Itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Opción">
                    <ItemTemplate>
                        <a href="/Forms/Empleados/Editar.aspx?id=<%# Eval("id")  %>">Editar</a>
                        <asp:LinkButton ID="lbBorrar" runat="server" OnClick="lbBorrar_Click" OnClientClick="return confirm('¿ Esta seguro de borrar el registro ?')">Borrar</asp:LinkButton>
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("id")  %>' />
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
      <asp:HyperLink ID="hlAgregarEmpleado" runat="server" NavigateUrl="~/Forms/Empleados/Agregar.aspx">Agregar Empleado</asp:HyperLink>
      <br />
      <br />
      <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 80px;
        }

        #Text1 {
            width: 188px;
            margin-left: 0px;
        }

        .auto-style2 {
            width: 230px;
        }

        #txtBuscar {
            margin-left: 0px;
        }

        #btnBuscar {
        }
    </style>
</asp:Content>

