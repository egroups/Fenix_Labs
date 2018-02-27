<%@ Page Title="Profesiones" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Personal.Forms.Profesiones.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1>Profesiones</h1>
        <br />
        <asp:GridView ID="gvProfesiones" runat="server" AutoGenerateColumns="False" CssClass="table" CellSpacing="-1" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron profesiones">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Opción">
                    <ItemTemplate>
                        <a href="/Forms/Profesiones/Editar.aspx?id=<%# Eval("id")  %>">Editar</a>
                        <asp:LinkButton ID="lbBorrar" runat="server" OnClick="lbBorrar_Click" OnClientClick="return confirm('¿ Esta seguro de borrar el registro ?')">Borrar</asp:LinkButton>
                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("id")  %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <a href="/Forms/Profesiones/Agregar.aspx" class="btn btn-primary" role="button">Agregar</a>
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </center>
</asp:Content>
