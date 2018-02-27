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
        <title>Administracion</title>

        <!-- Bootstrap -->

        <c:set var="context" value="${pageContext.request.contextPath}" />

        <link href="${context}/resources/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="${context}/resources/css/style.css" rel="stylesheet"/>
        <link href="${context}/resources/dist/sweetalert.css" rel="stylesheet"/>

        <script src="${context}/resources/bootstrap/js/jquery-1.11.2.min.js"></script>
        <script src="${context}/resources/bootstrap/js/bootstrap.js"></script>
        <script src="${context}/resources/dist/sweetalert-dev.js"></script>

        <script src="${context}/resources/js/jquery2.2.0.js"></script>   

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->
    </head>

    <script>

        $(document).ready(function () {

            $(document).on('click', '#agregar_producto', function (e) {

                var nombre_check = $("input[name='nombre_producto']").val();
                var descripcion_check = $("textarea[name='descripcion']").val();
                var precio_check = $("input[name='precio']").val();
                var proveedor_check = $("select[name='id_proveedor']").val();

                if (nombre_check == "") {
                    $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre_producto']").focus();
                    e.preventDefault();
                    return false;
                } else if (descripcion_check == "") {
                    $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
                    $("div[name='form-group-descripcion']").addClass('has-error');
                    $("textarea[name='descripcion']").focus();
                    e.preventDefault();
                    return false;
                } else if (precio_check == "") {
                    $("input[name='precio']").attr("placeholder", "Falta precio");
                    $("div[name='form-group-precio']").addClass('has-error');
                    $("input[name='precio']").focus();
                    e.preventDefault();
                    return false;
                } else if (proveedor_check == "0") {
                    $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
                    $("div[name='form-group-proveedor']").addClass('has-error');
                    $("select[name='proveedor']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-descripcion']").addClass('has-success');
                    $("div[name='form-group-precio']").addClass('has-success');
                    $("div[name='form-group-proveedor']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#agregar_proveedor', function (e) {

                var nombre_check = $("input[name='nombre_empresa']").val();
                var direccion_check = $("input[name='direccion']").val();
                var telefono_check = $("input[name='telefono']").val();

                if (nombre_check == "") {
                    $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre_empresa']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (direccion_check == "") {
                    $("input[name='direccion']").attr("placeholder", "Falta direccion");
                    $("div[name='form-group-direccion']").addClass('has-error');
                    $("input[name='direccion']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (telefono_check == "") {
                    $("input[name='telefono']").attr("placeholder", "Falta telefono");
                    $("div[name='form-group-telefono']").addClass('has-error');
                    $("input[name='telefono']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-direccion']").addClass('has-success');
                    $("div[name='form-group-telefono']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#agregar_usuario', function (e) {

                var nombre_check = $("input[name='nombre']").val();
                var password_check = $("input[name='password']").val();
                var tipo_check = $("select[name='tipo']").val();

                if (nombre_check == "") {
                    $("input[name='nombre']").attr("placeholder", "Falta nombre de usuario");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (password_check == "") {
                    $("input[name='password']").attr("placeholder", "Falta password");
                    $("div[name='form-group-password']").addClass('has-error');
                    $("input[name='password']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (tipo_check == "0") {
                    $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
                    $("div[name='form-group-tipo']").addClass('has-error');
                    $("select[name='tipo']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-password']").addClass('has-success');
                    $("div[name='form-group-tipo']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#editar_producto', function (e) {

                var id_producto_check = $("input[name='id_producto']").val();
                var nombre_check = $("input[name='nombre_producto']").val();
                var descripcion_check = $("textarea[name='descripcion']").val();
                var precio_check = $("input[name='precio']").val();
                var proveedor_check = $("select[name='id_proveedor']").val();

                if (nombre_check == "") {
                    $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre_producto']").focus();
                    e.preventDefault();
                    return false;
                } else if (descripcion_check == "") {
                    $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
                    $("div[name='form-group-descripcion']").addClass('has-error');
                    $("textarea[name='descripcion']").focus();
                    e.preventDefault();
                    return false;
                } else if (precio_check == "") {
                    $("input[name='precio']").attr("placeholder", "Falta precio");
                    $("div[name='form-group-precio']").addClass('has-error');
                    $("input[name='precio']").focus();
                    e.preventDefault();
                    return false;
                } else if (proveedor_check == "0") {
                    $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
                    $("div[name='form-group-proveedor']").addClass('has-error');
                    $("select[name='proveedor']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-descripcion']").addClass('has-success');
                    $("div[name='form-group-precio']").addClass('has-success');
                    $("div[name='form-group-proveedor']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#editar_proveedor', function (e) {

                var id_proveedor_check = $("input[name='id_proveedor']").val();
                var nombre_check = $("input[name='nombre_empresa']").val();
                var direccion_check = $("input[name='direccion']").val();
                var telefono_check = $("input[name='telefono']").val();

                if (nombre_check == "") {
                    $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre_empresa']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (direccion_check == "") {
                    $("input[name='direccion']").attr("placeholder", "Falta direccion");
                    $("div[name='form-group-direccion']").addClass('has-error');
                    $("input[name='direccion']").focus();
                    e.preventDefault();
                    return false;
                }
                else if (telefono_check == "") {
                    $("input[name='telefono']").attr("placeholder", "Falta telefono");
                    $("div[name='form-group-telefono']").addClass('has-error');
                    $("input[name='telefono']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-direccion']").addClass('has-success');
                    $("div[name='form-group-telefono']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#editar_usuario', function (e) {

                var id_usuario_check = $("input[name='id_usuario']").val();
                var nombre_check = $("input[name='nombre']").val();
                var tipo_check = $("select[name='tipo']").val();

                if (nombre_check == "") {
                    $("input[name='nombre']").attr("placeholder", "Falta nombre de usuario");
                    $("div[name='form-group-nombre']").addClass('has-error');
                    $("input[name='nombre']").focus();
                    e.preventDefault();
                    return false;
                }

                else if (tipo_check == "0") {
                    $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
                    $("div[name='form-group-tipo']").addClass('has-error');
                    $("select[name='tipo']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-nombre']").addClass('has-success');
                    $("div[name='form-group-tipo']").addClass('has-success');
                    return true;
                }
            });

            $(document).on('click', '#cambiar_pass', function (e) {

                var username_check = $("input[name='nombre_usuario']").val();
                var anterior_password_check = $("input[name='password']").val();
                var new_password_check = $("input[name='nuevo_password']").val();

                if (username_check == "") {
                    $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
                    $("div[name='form-group-username']").addClass('has-error');
                    $("input[name='nombre_usuario']").focus();
                    e.preventDefault();
                    return false;
                }

                else if (anterior_password_check == "") {
                    $("input[name='password']").attr("placeholder", "Falta contraseña actual");
                    $("div[name='form-group-anterior-password']").addClass('has-error');
                    $("input[name='password']").focus();
                    e.preventDefault();
                    return false;
                }

                else if (new_password_check == "") {
                    $("input[name='nuevo_password']").attr("placeholder", "Falta nueva contraseña");
                    $("div[name='form-group-new-password']").addClass('has-error');
                    $("input[name='nuevo_password']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-username']").addClass('has-success');
                    $("div[name='form-group-anterior-password']").addClass('has-success');
                    $("div[name='form-group-new-password']").addClass('has-success');
                    return true;
                }

            });

            $(document).on('click', '#cambiar_user', function (e) {

                var username_check = $("input[name='nombre_usuario']").val();
                var new_username_check = $("input[name='nuevo_usuario']").val();
                var password_check = $("input[name='password']").val();

                if (username_check == "") {
                    $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
                    $("div[name='form-group-username']").addClass('has-error');
                    $("input[name='nombre_usuario']").focus();
                    e.preventDefault();
                    return false;
                }

                else if (new_username_check == "") {
                    $("input[name='nuevo_usuario']").attr("placeholder", "Falta nuevo usuario");
                    $("div[name='form-group-new-username']").addClass('has-error');
                    $("input[name='nuevo_usuario']").focus();
                    e.preventDefault();
                    return false;
                }

                else if (password_check == "") {
                    $("input[name='password']").attr("placeholder", "Falta password");
                    $("div[name='form-group-password']").addClass('has-error');
                    $("input[name='password']").focus();
                    e.preventDefault();
                    return false;
                } else {
                    $("div[name='form-group-username']").addClass('has-success');
                    $("div[name='form-group-new-username']").addClass('has-success');
                    $("div[name='form-group-password']").addClass('has-success');
                    return true;
                }

            });

        });
    </script>
    <body>
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#defaultNavbar1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand" href="#">Administracion</a>
                </div>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="defaultNavbar1">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="${context}/administracion/" name="inicio">Inicio<span class="sr-only">(current)</span></a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Cuenta <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="${context}/administracion/cuenta/cambiar_usuario" name="cambiar_usuario">Cambiar Usuario</a></li>
                                <li><a href="${context}/administracion/cuenta/cambiar_password" name="cambiar_password">Cambiar Password</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestionar <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="${context}/administracion/productos" name="productos">Productos</a></li>
                                <li><a href="${context}/administracion/proveedores" name="proveedores">Proveedores</a></li>
                                <li><a href="${context}/administracion/usuarios" name="usuarios">Usuarios</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Estadisticas <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="${context}/administracion/estadisticas/listado_productos" name="productos">Listado de productos</a></li>
                                <li><a href="${context}/administracion/estadisticas/grafico_productos" name="proveedores">Grafico de productos</a></li>
                                <li><a href="${context}/administracion/estadisticas/grafico_proveedores" name="usuarios">Grafico de proveedores</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="${context}/Login/LogOut">Salir</a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <h1 class="text-center">Administracion</h1>
                </div>
            </div>
            <hr>
            <br><br>