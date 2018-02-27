<?php

// Written By Ismael Heredia in the year 2017

include_once("includes/Funciones.php");
include_once("includes/Cliente.php");

if(isset($_POST["agregar_producto"])) {

	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];

	$ruta = "?productos=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->agregarProducto($nombre_producto,$descripcion,$precio,$id_proveedor);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Productos",$mensaje,"success",$ruta);
	} else {
		mensaje("Productos",$mensaje,"warning",$ruta);
	}

}

if(isset($_POST["editar_producto"])) {

	$id_producto = $_POST["id_producto"];
	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];

	$ruta = "?productos=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->editarProducto($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Productos",$mensaje,"success",$ruta);
	} else {
		mensaje("Productos",$mensaje,"warning",$ruta);
	}

}

if(isset($_GET["borrar_producto"])) {
	$id_producto = $_GET["borrar_producto"];
	$ruta = "?productos=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->borrarProducto($id_producto);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Productos",$mensaje,"success",$ruta);
	} else {
		mensaje("Productos",$mensaje,"warning",$ruta);
	}
}

if(isset($_POST["agregar_proveedor"])) {

	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
				
	$ruta = "?proveedores=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->agregarProveedor($nombre_empresa,$direccion,$telefono);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Proveedores",$mensaje,"success",$ruta);
	} else {
		mensaje("Proveedores",$mensaje,"warning",$ruta);
	}

}

if(isset($_POST["editar_proveedor"])) {

	$id_proveedor = $_POST["id_proveedor"];
	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
	
	$ruta = "?proveedores=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->editarProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Proveedores",$mensaje,"success",$ruta);
	} else {
		mensaje("Proveedores",$mensaje,"warning",$ruta);
	}
}

if(isset($_GET["borrar_proveedor"])) {
	$id_proveedor = $_GET["borrar_proveedor"];
	$ruta = "?proveedores=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->borrarProveedor($id_proveedor);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Proveedores",$mensaje,"success",$ruta);
	} else {
		mensaje("Proveedores",$mensaje,"warning",$ruta);
	}
}

if(isset($_POST["agregar_usuario"])) {

	$nombre_usuario = $_POST["nombre_usuario"];
	$clave = $_POST["password"];
	$tipo = $_POST["tipo"];
	
	$ruta = "?usuarios=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->agregarUsuario($nombre_usuario,$clave,$tipo);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Usuarios",$mensaje,"success",$ruta);
	} else {
		mensaje("Usuarios",$mensaje,"warning",$ruta);
	}

}

if(isset($_POST["editar_usuario"])) {

	$id_usuario = $_POST["id_usuario"];
	$tipo = $_POST["tipo"];
	
	$ruta = "?usuarios=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->editarUsuario($id_usuario,$tipo);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Usuarios",$mensaje,"success",$ruta);
	} else {
		mensaje("Usuarios",$mensaje,"warning",$ruta);
	}

}

if(isset($_GET["borrar_usuario"])) {
	$id_usuario = $_GET["borrar_usuario"];
	$ruta = "?usuarios=";
	
	$cliente_now = new Cliente();
	$datos = $cliente_now->borrarUsuario($id_usuario);
	$mensaje = $datos->message;
	$success = $datos->success;

	if($success==true) {
		mensaje("Usuarios",$mensaje,"success",$ruta);
	} else {
		mensaje("Usuarios",$mensaje,"warning",$ruta);
	}
}

?>