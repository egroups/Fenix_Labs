<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Personal.Forms.Empleados.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" role="form">
        <fieldset>
            <legend>Datos</legend>
            <asp:HiddenField ID="hfID" runat="server" />
            <div class="form-group">
                <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputDireccion" class="col-lg-2 control-label">Dirección</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelefono" class="col-lg-2 control-label">Teléfono</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="radioSexo" class="col-lg-2 control-label">Sexo</label>
                <div class="col-lg-10">
                    <asp:RadioButtonList ID="rbSexo" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem class="radio-inline" Value="Masculino" Text="Masculino" Selected="True"></asp:ListItem>
                        <asp:ListItem class="radio-inline" Value="Femenino" Text="Femenino"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-group">
                <label for="selectProfesion" class="col-lg-2 control-label">Profesión</label>
                <div class="col-lg-10">
                    <asp:DropDownList ID="ddlProfesiones" runat="server" DataTextField="nombre" DataValueField="id" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <center>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click"></asp:Button>
            </center>
        </fieldset>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
