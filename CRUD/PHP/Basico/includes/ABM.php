<?php

if(isset($_POST["agregar_producto"])) {

	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];
	
	if($nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) {
		echo "<script>alert('Faltan datos para registrar el producto');</script>";
	} else {
		$conexion_now = new Conexion();
		$fecha_registro = fecha_actual();
		$ruta = "administracion.php?productos=";
		$sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" . $nombre_producto . "','" . $descripcion . "'," . $precio . "," . $id_proveedor . ",'" . $fecha_registro . "')";
		
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Producto registrado');</script>";
		} else {
			echo "<script>alert('Error registrando producto');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);
	}
}

if(isset($_POST["editar_producto"])) {

	$id_producto = $_POST["id_producto"];
	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];
	
	if($id_producto=="" or !is_numeric($id_producto) or $nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) {
		echo "<script>alert('Faltan datos para editar el producto');</script>";
	} else {
		$conexion_now = new Conexion();
		$ruta = "administracion.php?productos=";
		$sql = $sql = "update productos set nombre_producto='" . $nombre_producto . "',descripcion='".$descripcion."',precio=".$precio.",id_proveedor=".$id_proveedor." where id_producto=" . $id_producto;
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Producto editado');</script>";
		} else {
			echo "<script>alert('Error editando producto');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);	
	}

}

if(isset($_GET["borrar_producto"])) {
	$id_producto = $_GET["borrar_producto"];
	if($id_producto=="" or !is_numeric($id_producto)) {
		echo "<script>alert('ID Invalido');</script>";
	} else {
		$sql = "delete from productos where id_producto=" . $id_producto;
		$conexion_now = new Conexion();
		$ruta = "administracion.php?productos=";
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Producto borrado');</script>";
		} else {
			echo "<script>alert('Error borrando producto');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);
	}
}

if(isset($_POST["agregar_proveedor"])) {

	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
	
	if($nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
		echo "<script>alert('Faltan datos para registrar el proveedor');</script>";
	} else {
		$conexion_now = new Conexion();
		$fecha_registro = fecha_actual();
		$ruta = "administracion.php?proveedores=";
		$sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" . $nombre_empresa . "','" . $direccion . "'," . $telefono . ",'" . $fecha_registro . "')";
		
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Proveedor registrado');</script>";
		} else {
			echo "<script>alert('Error registrando proveedor');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);		
	}

}

if(isset($_POST["editar_proveedor"])) {

	$id_proveedor = $_POST["id_proveedor"];
	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
	if($id_proveedor=="" or !is_numeric($id_proveedor) or $nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
		echo "<script>alert('Faltan datos para editar el proveedor');</script>";
	} else {
		$conexion_now = new Conexion();
		$ruta = "administracion.php?proveedores=";
		$sql = "update proveedores set nombre_empresa='" . $nombre_empresa . "',direccion='".$direccion."',telefono=".$telefono." where id_proveedor=" . $id_proveedor;
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Proveedor editado');</script>";
		} else {
			echo "<script>alert('Error editando proveedor');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);			
	}
}

if(isset($_GET["borrar_proveedor"])) {
	$id_proveedor = $_GET["borrar_proveedor"];
	if($id_proveedor=="" or !is_numeric($id_proveedor)) {
		echo "<script>alert('ID Invalido');</script>";
	} else {
		$sql = "delete from proveedores where id_proveedor=" . $id_proveedor;
		$conexion_now = new Conexion();
		$ruta = "administracion.php?proveedores=";
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Proveedor borrado');</script>";
		} else {
			echo "<script>alert('Error borrando proveedor');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);
	}
}

if(isset($_POST["agregar_usuario"])) {

	$nombre_usuario = $_POST["nombre_usuario"];
	$clave = $_POST["password"];
	$tipo = $_POST["tipo"];
	
	if($nombre_usuario=="" or $clave=="" or $tipo=="" or !is_numeric($tipo)) {
		echo "<script>alert('Faltan datos para agregar el usuario');</script>";
	} else {
		$conexion_now = new Conexion();
		$fecha_registro = fecha_actual();
		$ruta = "administracion.php?usuarios=";
		$password_encoded = md5($clave);
		$sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" . $nombre_usuario . "','" . $password_encoded . "'," . $tipo . ",'" . $fecha_registro . "')";
		
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Usuario registrado');</script>";
		} else {
			echo "<script>alert('Error registrando usuario');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);	
	}

}

if(isset($_POST["editar_usuario"])) {

	$id_usuario = $_POST["id_usuario"];
	$tipo = $_POST["tipo"];
	
	if($id_usuario=="" or !is_numeric($id_usuario) or $tipo=="" or !is_numeric($tipo)) {
		echo "<script>alert('Faltan datos para editar el usuario');</script>";
	} else {
		$conexion_now = new Conexion();
		$ruta = "administracion.php?usuarios=";
		$sql = "update usuarios set tipo=".$tipo." where id_usuario='".$id_usuario."'";
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Usuario editado');</script>";
		} else {
			echo "<script>alert('Error editando usuario');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);
	}

}

if(isset($_GET["borrar_usuario"])) {
	$id_usuario = $_GET["borrar_usuario"];
	if($id_usuario=="" or !is_numeric($id_usuario)) {
		echo "<script>alert('ID Invalido');</script>";
	} else {
		$sql = "delete from usuarios where id_usuario=" . $id_usuario;
		$conexion_now = new Conexion();
		$ruta = "administracion.php?usuarios=";
		if($conexion_now->ejecutarConsulta($sql)) {
			echo "<script>alert('Usuario borrado');</script>";
		} else {
			echo "<script>alert('Error borrando usuario');</script>";
		}
		unset($conexion_now);
		redireccion($ruta);
	}
}

?>