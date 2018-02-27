<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Administración</title>

        <!-- Bootstrap -->

        <c:set var="context" value="${pageContext.request.contextPath}" />

        <link href="${context}/resources/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="${context}/resources/css/style.css" rel="stylesheet"/>
        <link href="${context}/resources/css/bootstrapValidator.css" rel="stylesheet"/>
        <link href="${context}/resources/dist/sweetalert.css" rel="stylesheet"/>

        <script src="${context}/resources/js/jquery-3.2.1.js"></script> 
        <script src="${context}/resources/bootstrap/js/bootstrap.js"></script>
        <script src="${context}/resources/js/bootstrapValidator.js"></script>
        <script src="${context}/resources/dist/sweetalert-dev.js"></script>
        <script src="${context}/resources/js/app.js"></script>

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->
    </head>
    <body>
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#defaultNavbar1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand" href="#">Administración</a>
                </div>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="defaultNavbar1">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="${context}/administracion/" name="inicio"><span class="glyphicon glyphicon-home right_space"></span>Inicio<span class="sr-only">(current)</span></a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><span class="glyphicon glyphicon-th right_space"></span>Gestionar <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="${context}/administracion/productos" name="productos">Productos</a></li>
                                <li><a href="${context}/administracion/proveedores" name="proveedores">Proveedores</a></li>
                                <li><a href="${context}/administracion/usuarios" name="usuarios">Usuarios</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><span class="glyphicon glyphicon-stats right_space"></span>Estadísticas <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="${context}/administracion/estadisticas" name="reporte">Visualizar reporte</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown user-dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-user right_space"></span>${usuario_logeado}<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="${context}/administracion/cuenta/cambiar_usuario" name="cambiar_usuario">Cambiar Usuario</a></li>
                                <li><a href="${context}/administracion/cuenta/cambiar_clave" name="cambiar_clave">Cambiar Clave</a></li>
                                <li class="divider"></li>
                                <li><a href="${context}/Login/LogOut">Salir</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <h1 class="text-center">Administración</h1>
                </div>
            </div>
            <hr>
            <br><br>