<%-- Written by Ismael Heredia in the year 2016 --%>

<%@page import="Funciones.Funciones"%>
<%@page import="net.sf.jasperreports.engine.JasperExportManager"%>
<%@page import="net.sf.jasperreports.engine.JasperPrint"%>
<%@page import="net.sf.jasperreports.engine.JasperFillManager"%>
<%@page import="net.sf.jasperreports.engine.JasperReport"%>
<%@page import="net.sf.jasperreports.engine.JasperCompileManager"%>
<%@page import="Controlador.Conexion"%>
<%@ page contentType="application/pdf" %>
<%@ page trimDirectiveWhitespaces="true"%>

<%

    Conexion conexion_now = new Conexion();
    Funciones funcion = new Funciones();
    Cookie[] cookies = request.getCookies();

    if (cookies != null) {
        if (!funcion.validar_cookie(cookies)) {
            response.sendRedirect("login.jsp");
        }
    } else {
        response.sendRedirect("login.jsp");
    }

    String ruta_reporte = "";

    if (request.getParameter("listado_productos") != null) {
        ruta_reporte = "C:\\Users\\Test\\Documents\\NetBeansProjects\\SistemaWebBootstrap\\src\\java\\Reportes\\ReporteListaProductos.jrxml";
    } else if (request.getParameter("grafico_productos") != null) {
        ruta_reporte = "C:\\Users\\Test\\Documents\\NetBeansProjects\\SistemaWebBootstrap\\src\\java\\Reportes\\ReporteGrafico_GraficoProductos.jrxml";
    } else if (request.getParameter("grafico_proveedores") != null) {
        ruta_reporte = "C:\\Users\\Test\\Documents\\NetBeansProjects\\SistemaWebBootstrap\\src\\java\\Reportes\\ReporteGrafico_GraficoProveedores.jrxml";
    } else {
        ruta_reporte = "";
    }

    if (ruta_reporte != "") {

        Conexion reporte_conexion = new Conexion();
        reporte_conexion.abrir();

        JasperReport jasperReport = JasperCompileManager.compileReport(ruta_reporte);
        JasperPrint jasperPrint = JasperFillManager.fillReport(jasperReport, null, reporte_conexion.retornar());

        JasperExportManager.exportReportToPdfStream(jasperPrint, response.getOutputStream());

        reporte_conexion.cerrar();
    }
%>