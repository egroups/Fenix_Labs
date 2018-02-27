<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Personal.Forms.Empleados.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1>Empleados</h1>
        <br />
        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CssClass="table" CellSpacing="-1" EnableTheming="True" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron empleados">
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
        </asp:GridView>
        <br />
        <a href="/Forms/Empleados/Agregar.aspx" class="btn btn-primary" role="button">Agregar</a>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
