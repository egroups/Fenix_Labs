<%@ Page Title="Reporte" Language="C#" MasterPageFile="~/Layouts/Administracion.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Sistema.Forms.Estadisticas.Reporte" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <CR:CrystalReportViewer ID="crvReporte" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="crsReporte" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />

    <CR:CrystalReportSource ID="crsReporte" runat="server">
        <Report FileName="Reports\Reporte.rpt">
        </Report>
    </CR:CrystalReportSource>

</asp:Content>