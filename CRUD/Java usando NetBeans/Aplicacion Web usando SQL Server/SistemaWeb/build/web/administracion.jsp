<%-- Written by Ismael Heredia in the year 2016 --%>

<%@page import="net.sf.jasperreports.engine.JasperExportManager"%>
<%@page import="net.sf.jasperreports.engine.JasperPrint"%>
<%@page import="net.sf.jasperreports.engine.JasperFillManager"%>
<%@page import="net.sf.jasperreports.engine.JasperReport"%>
<%@page import="net.sf.jasperreports.engine.JasperCompileManager"%>
<%@page import="java.util.Map"%>
<%@page import="java.util.HashMap"%>
<%@page import="net.sf.jasperreports.engine.JasperRunManager"%>
<%@page import="Funciones.Funciones"%>
<%@page import="Controlador.Conexion"%>
<%
    Conexion conexion_now = new Conexion();
    Funciones funcion = new Funciones();
    Cookie[] cookies = request.getCookies();

    if (request.getAttribute("ok") == null) {
        if (cookies != null) {
            if (!funcion.validar_cookie(cookies)) {
                response.sendRedirect("login.jsp");
            }
        } else {
            response.sendRedirect("login.jsp");
        }
    }

    String usuario = funcion.get_username_cookie(cookies);
    String tipo_usuario = "";
    if (conexion_now.es_admin(usuario)) {
        tipo_usuario = "administrador";
    } else {
        tipo_usuario = "usuario";
    }

%>    

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html><head>
        <meta content="initial-scale=1" name="viewport"><meta content="user-scalable=yes,width=device-width,initial-scale=1" name="viewport"><title>Administración</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link rel="shortcut icon" href="img/favicon.ico" type="image/ico">
        <link href="css/Site.css" rel="stylesheet" type="text/css">
        <link href="css/main.css" type="text/css" rel="stylesheet">
        <link href="css/more_style.css" rel="stylesheet" type="text/css">
        <link rel="stylesheet" href="css/style2.css">

    </head>
    <body>
        <div id="header-wrapper">
            <div class="container">
                <header id="header">
                    <div class="inner">
                        <h1 id="logo"><a href="#">Administración</a></h1>
                        <nav id="nav">
                            <ul>
                                <li style="white-space: nowrap;" class="current_page_item"><a href="administracion.jsp?">Inicio</a></li>
                                <li class="opener" style="-moz-user-select: none; cursor: pointer; white-space: nowrap;">
                                    <a href="#">Cuenta</a>
                                    <ul class="dropotron level-0" style="-moz-user-select: none; display: none; position: absolute; z-index: 1000;">
                                        <li style="white-space: nowrap;"><a style="display: block;" href="administracion.jsp?cambiar_usuario">Cambiar usuario</a></li>
                                        <li style="white-space: nowrap;"><a style="display: block;" href="administracion.jsp?cambiar_password">Cambiar contraseña</a></li>
                                    </ul>
                                </li>                        
                                <li class="opener" style="-moz-user-select: none; cursor: pointer; white-space: nowrap;">
                                    <a href="#">Gestionar</a>
                                    <ul class="dropotron level-0" style="-moz-user-select: none; display: none; position: absolute; z-index: 1000;">
                                        <li style="white-space: nowrap;"><a style="display: block;" href="administracion.jsp?productos">Productos</a></li>
                                        <li style="white-space: nowrap;"><a style="display: block;" href="administracion.jsp?proveedores">Proveedores</a></li>
                                        <li style="white-space: nowrap;"><a style="display: block;" href="administracion.jsp?usuarios">Usuarios</a></li>
                                    </ul>
                                </li>
                                <li class="opener" style="-moz-user-select: none; cursor: pointer; white-space: nowrap;">
                                    <a href="#">Estadisticas</a>
                                    <ul class="dropotron level-0" style="-moz-user-select: none; display: none; position: absolute; z-index: 1000;">
                                        <li style="white-space: nowrap;"><a style="display: block;" href="estadisticas.jsp?listar_productos">Listar productos</a></li>
                                        <li style="white-space: nowrap;"><a style="display: block;" href="estadisticas.jsp?generar_reportes">Generar graficos</a></li>
                                    </ul>
                                </li>                                 
                                <li style="white-space: nowrap;"><a href="Login?LogOut">Salir</a></li>
                            </ul>
                        </nav>
                    </div>
                </header>              
                <br><br>
                <header class="major"></header>

                <%  if (request.getParameter(
                            "logout") != null) {

                        Cookie cookie = new Cookie("user_login", "");
                        cookie.setMaxAge(0);
                        response.addCookie(cookie);

                        out.println("<script>alert('Las cookies han sido borradas');</script>");

                        response.sendRedirect("login.jsp");
                    } else if (request.getParameter(
                            "estadisticas") != null) {

                        out.println("soy estadistica");

                        Conexion reporte_conexion = new Conexion();
                        reporte_conexion.abrirConexion();

                        String archivo = "C:\\Users\\test\\Documents\\NetBeansProjects\\sistema\\src\\Reportes\\ReporteListaProductos.jrxml";

                        JasperReport jasperReport = JasperCompileManager.compileReport(archivo);
                        JasperPrint jasperPrint = JasperFillManager.fillReport(jasperReport, null, reporte_conexion.retornarConexion());

                        JasperExportManager.exportReportToPdfStream(jasperPrint, response.getOutputStream());

                        reporte_conexion.cerrarConexion();

                    } else if (request.getParameter(
                            "cambiar_usuario") != null) {

                        out.println("<center>");
                        out.println("<div class='login'>");
                        out.println("<h1>Cambiar usuario</h1>");
                        out.println("<form action='PerfilUsuario' method='POST'>");
                        out.println("<b>Usuario : </b><input type='text' name='username' readonly='readonly' value='" + usuario + "'><br>");
                        out.println("<b>Nuevo usuario : </b><input type='text' name='new_username' value=''><br><br>");
                        out.println("<b>Actual contraseña : </b><input type='password' name='password'><br><br>");
                        out.println("<button class='small button' name='cambiar_user' type='submit'>Cambiar</button>");
                        out.println("<br></div></center><br>");

                    } else if (request.getParameter(
                            "cambiar_password") != null) {

                        out.println("<center>");
                        out.println("<div class='login'>");
                        out.println("<h1>Cambiar contraseña</h1>");
                        out.println("<form action='PerfilUsuario' method='POST'>");
                        out.println("<b>Usuario : </b><input type='text' name='username' readonly='readonly' value='" + usuario + "'><br><br>");
                        out.println("<b>Actual contraseña : </b><input type='password' name='anterior_password'><br>");
                        out.println("<b>Nueva contraseña : </b><input type='password' name='new_password'><br><br>");
                        out.println("<button class='small button' name='cambiar_pass' type='submit'>Cambiar</button>");
                        out.println("<br></div></center><br>");

                    } else if (request.getParameter(
                            "proveedores") != null) {

                %> <%@include file="includes/proveedores.jsp" %>
                <%} else if (request.getParameter(
                        "productos") != null) {
                %> <%@include file="includes/productos.jsp" %>
                <%} else if (request.getParameter(
                        "usuarios") != null) {
                %> <%@include file="includes/usuarios.jsp" %>
                <%} else {
                        out.println("<center><h1><font color='white'>Bienvenido a la administración " + tipo_usuario + " " + usuario + "</font></h1></center><br><br>");
                    }%>

                <header class="major">
                </header>

            </div>
        </div>
        <div class="row">
            <div class="12u">
                <div id="copyright">
                    <ul class="menu">
                        <li>Creditos</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Scripts -->
        <script src="js/jquery.js"></script>
        <script src="js/jquery_002.js"></script>
        <script src="js/skel.js"></script>
        <script src="js/skel-viewport.js"></script>
        <script src="js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="js/main.js"></script>

    </body></html>

<%
    String mensaje = "";
    if (request.getAttribute("mensaje") != null) {
        mensaje = request.getAttribute("mensaje").toString();
        out.println("<script>alert('" + mensaje + "');</script>");
    }
%>