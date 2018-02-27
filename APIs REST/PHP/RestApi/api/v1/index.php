<?php

// Written By Ismael Heredia in the year 2017

include_once("../../includes/Conexion.php");

if(isset($_GET["PATH_INFO"])) {

	http_response_code(200);
	header('Content-Type: application/json; charset=utf8');

	$conexion_now = new Conexion();
	
	$peticion = explode('/', $_GET['PATH_INFO']);
	$carpeta = $peticion[0];
	$id = $peticion[1];

	$metodo = strtolower($_SERVER['REQUEST_METHOD']);
	
	if($metodo=="post") {

		parse_str(file_get_contents('php://input'), $post_vars);  

		if($carpeta=="productos") {

			$nombre_producto = $post_vars["nombre_producto"];
			$descripcion = $post_vars["descripcion"];
			$precio = $post_vars["precio"];
			$id_proveedor = $post_vars["id_proveedor"];

			$respuesta = $conexion_now->agregarProducto($nombre_producto,$descripcion,$precio,$id_proveedor);
			echo $respuesta;
		}

		if($carpeta=="proveedores") {

			$nombre_empresa = $post_vars["nombre_empresa"];
			$direccion = $post_vars["direccion"];
			$telefono = $post_vars["telefono"];

			$respuesta = $conexion_now->agregarProveedor($nombre_empresa,$direccion,$telefono);
			echo $respuesta;
		}

		if($carpeta=="usuarios") {

			$nombre_usuario = $post_vars["nombre_usuario"];
			$clave = $post_vars["password"];
			$tipo = $post_vars["tipo"];

			$respuesta = $conexion_now->agregarUsuario($nombre_usuario,$clave,$tipo);
			echo $respuesta;
		}

	}

	if($metodo=="put") {

		parse_str(file_get_contents('php://input'), $put_vars);  

		if($carpeta=="productos") {

			$id_producto = $put_vars["id_producto"];
			$nombre_producto = $put_vars["nombre_producto"];
			$descripcion = $put_vars["descripcion"];
			$precio = $put_vars["precio"];
			$id_proveedor = $put_vars["id_proveedor"];

			$respuesta = $conexion_now->editarProducto($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor);
			echo $respuesta;
		}

		if($carpeta=="proveedores") {

			$id_proveedor = $put_vars["id_proveedor"];
			$nombre_empresa = $put_vars["nombre_empresa"];
			$direccion = $put_vars["direccion"];
			$telefono = $put_vars["telefono"];

			$respuesta = $conexion_now->editarProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono);
			echo $respuesta;
		}

		if($carpeta=="usuarios") {

			$id_usuario = $put_vars["id_usuario"];
			$tipo = $put_vars["tipo"];

			$respuesta = $conexion_now->editarUsuario($id_usuario,$tipo);
			echo $respuesta;
		}

	}

	if($metodo=="get") {

		if($carpeta=="productos") {
			if(is_numeric($id)) {
				$producto = $conexion_now->cargarProducto($id);
				echo $producto;
			} else {
				$productos = $conexion_now->listarProductos();
				echo $productos;
			}
		}

		if($carpeta=="proveedores") {
			if(is_numeric($id)) {
				$proveedor = $conexion_now->cargarProveedor($id);
				echo $proveedor;
			} else {
				$proveedores = $conexion_now->listarProveedores();
				echo $proveedores;
			}
		}

		if($carpeta=="usuarios") {
			if(is_numeric($id)) {
				$usuario = $conexion_now->cargarUsuario($id);
				echo $usuario;
			} else {
				$usuarios = $conexion_now->listarUsuarios();
				echo $usuarios;
			}
		}

	}

	if($metodo=="delete") {

		if($carpeta=="productos") {
			if(is_numeric($id)) {
				$respuesta = $conexion_now->borrarProducto($id);
				echo $respuesta;
			}
		}

		if($carpeta=="proveedores") {
			if(is_numeric($id)) {
				$respuesta = $conexion_now->borrarProveedor($id);
				echo $respuesta;
			}
		}

		if($carpeta=="usuarios") {
			if(is_numeric($id)) {
				$respuesta = $conexion_now->borrarUsuario($id);
				echo $respuesta;
			}
		}

	}

	unset($conexion_now);

}

?>