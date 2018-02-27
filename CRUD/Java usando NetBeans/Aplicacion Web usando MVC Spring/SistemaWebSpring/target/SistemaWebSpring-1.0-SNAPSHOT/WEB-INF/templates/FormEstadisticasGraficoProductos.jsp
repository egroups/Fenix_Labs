<%-- Written by Ismael Heredia in the year 2016 --%>

<%@page import="sistema.functions.Conexion"%>
<%@page import="net.sf.jasperreports.engine.JasperExportManager"%>
<%@page import="net.sf.jasperreports.engine.JasperPrint"%>
<%@page import="net.sf.jasperreports.engine.JasperFillManager"%>
<%@page import="net.sf.jasperreports.engine.JasperReport"%>
<%@page import="net.sf.jasperreports.engine.JasperCompileManager"%>
<%@page import="net.sf.jasperreports.engine.JasperRunManager"%>

<%@ page contentType="application/pdf" %>
<%@ page trimDirectiveWhitespaces="true"%>

<%

    String ruta_reporte = "C:\\Users\\Test\\Documents\\NetBeansProjects\\SistemaWebSpring\\src\\main\\java\\sistema\\reportes\\ReporteGrafico_GraficoProveedores.jrxml";

    if (ruta_reporte != "") {

        Conexion reporte_conexion = new Conexion();
        reporte_conexion.abrir();

        JasperReport jasperReport = JasperCompileManager.compileReport(ruta_reporte);
        JasperPrint jasperPrint = JasperFillManager.fillReport(jasperReport, null, reporte_conexion.retornar());

        JasperExportManager.exportReportToPdfStream(jasperPrint, response.getOutputStream());

        reporte_conexion.cerrar();
    }
%>