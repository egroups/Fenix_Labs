<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sistema.Forms.Usuarios.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel contenedor panel-default">
        <div class="panel-heading">
            <asp:Label ID="lblUsuarios" runat="server" Text=""></asp:Label>
        </div>
        <div class="panel-body">
            <fieldset>
                <div class="form-group">
                    <div class="col-lg-2">
                        <a href="/Forms/Usuarios/Agregar.aspx" class="btn btn-primary btn-block" role="button"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</a>
                    </div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="txtBuscar" placeholder="Ingrese nombre a buscar" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block" OnClick="btnBuscar_Click"/>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <div class="panel contenedor panel-default">
        <div class="panel-heading">
            <asp:Label ID="lblUsuariosEncontrados" runat="server" Text=""></asp:Label>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" CellSpacing="-1" EnableTheming="True" GridLines="None" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron productos">
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>
                                <p>
                                    <%# DataBinder.Eval(Container.DataItem, "tipo.nombre") %>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fecha_registro" HeaderText="Registro" />
                        <asp:TemplateField HeaderText="Opción">
                            <ItemTemplate>
                                <a href="/Forms/Usuarios/Editar.aspx?id=<%# Eval("id")  %>">Editar</a>
                                <a href="/Forms/Usuarios/Borrar.aspx?id=<%# Eval("id")  %>">Borrar</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
