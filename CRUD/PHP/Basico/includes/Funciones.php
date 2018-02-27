<?php

function cerrar_sesion() {
	setcookie("login", "", time() - 3600, "");
	unset($_COOKIE['login']);
	echo "<script>alert('Las cookies han sido borradas ');</script>";
	$archivo = "index.php";
	echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />'; 
}

function redireccion($pagina) {
	echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($pagina) . '" />'; 
}

function contar_productos($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$productos = $conexion_now->listarProductos();
	foreach ($productos as $producto) {
		$nombre_producto  = $producto->getNombre_producto();
		if (preg_match('/'.$patron.'/',$nombre_producto)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_producto($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$productos = $conexion_now->listarProductos();
	foreach ($productos as $producto) {
		$contador = $contador + 1;
		$id_producto = $producto->getId_producto();
		if ($id_producto==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function contar_proveedores($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$proveedores = $conexion_now->listarProveedores();
	foreach ($proveedores as $proveedor) {
		$nombre_proveedor  = $proveedor->getNombre_empresa();
		if (preg_match('/'.$patron.'/',$nombre_proveedor)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_proveedor($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$proveedores = $conexion_now->listarProveedores();
	foreach ($proveedores as $proveedor) {
		$contador = $contador + 1;
		$id_proveedor = $proveedor->getId_proveedor();
		if ($id_proveedor==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function contar_usuarios($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$usuarios = $conexion_now->listarUsuarios();
	foreach ($usuarios as $usuario) {
		$nombre_usuario  = $usuario->getNombre();
		if (preg_match('/'.$patron.'/',$nombre_usuario)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_usuario($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$usuarios = $conexion_now->listarUsuarios();
	foreach ($usuarios as $usuario) {
		$contador = $contador + 1;
		$id_usuario  = $usuario->getId_usuario();
		if ($id_usuario==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function fecha_actual() {
	date_default_timezone_set("America/Argentina/Cordoba");
	$fecha = date("d/m/Y", time());
	return $fecha;
}

?>