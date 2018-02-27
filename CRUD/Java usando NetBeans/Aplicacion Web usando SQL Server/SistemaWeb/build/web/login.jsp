<%-- Written by Ismael Heredia in the year 2016 --%>

<%@page import="Funciones.Funciones"%>
<%@page import="Controlador.Conexion"%>
<%
    Conexion conexion_now = new Conexion();
    Funciones funcion = new Funciones();
    Cookie[] cookies = request.getCookies();
    if (cookies != null) {
        if (funcion.validar_cookie(cookies)) {
            response.sendRedirect("administracion.jsp");
        }
    }
%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang="en"><!--<![endif]--><head>
        <meta http-equiv="content-type" content="text/html; charset=UTF-8">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <title>Login</title>
        <link rel="stylesheet" href="css/style.css">
        <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    </head>
    <body>
        <script>
            function validar_formulario() {
                if (document.form_login.username.value.length == 0) {
                    alert("Falta el nombre de usuario");
                    document.form_login.username.focus();
                    return false;
                }
                else if (document.form_login.password.value.length == 0) {
                    alert("Falta la contraseña del usuario");
                    document.form_login.password.focus();
                    return false;
                } else {
                    return true;
                }
            }
        </script>
        <form method="post" action="Login" name="form_login" class="login">
            <p>
                <label for="username">Usuario :</label>
                <input name="username" id="username" type="text">
            </p>

            <p>
                <label for="password">Password :</label>
                <input name="password" id="password" type="password">
            </p>

            <p class="login-submit">
                <button type="submit" name="LogOn" class="login-button" onclick="return validar_formulario();">Login</button>
            </p>

        </form>


    </body></html>

<%    String mensaje = "";
    if (request.getAttribute("mensaje") != null) {
        mensaje = request.getAttribute("mensaje").toString();
        out.println("<script>alert('" + mensaje + "');</script>");
    } else {
        //out.println("fuck");
    }
%>
