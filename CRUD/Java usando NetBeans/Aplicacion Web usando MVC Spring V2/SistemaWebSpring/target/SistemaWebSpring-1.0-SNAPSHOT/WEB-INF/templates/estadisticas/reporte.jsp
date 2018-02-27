<%-- Written by Ismael Heredia in the year 2017 --%>

<%@page import="java.io.File"%>
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

    String directorio = "C:\\Users\\Sin Decidir\\Desktop\\Biblioteca de códigos\\Fenix Labs\\Contenido\\Java\\Aplicacion Web usando MVC Spring\\SistemaWebSpring";
    String ruta_reporte = directorio + "\\" + "src/main/java/sistema/reports/reporte.jrxml";

    if (ruta_reporte != "") {

        Conexion reporte_conexion = new Conexion();
        reporte_conexion.abrir();

        JasperReport jasperReport = JasperCompileManager.compileReport(ruta_reporte);
        JasperPrint jasperPrint = JasperFillManager.fillReport(jasperReport, null, reporte_conexion.retornar());

        JasperExportManager.exportReportToPdfStream(jasperPrint, response.getOutputStream());

        reporte_conexion.cerrar();
    }
%>