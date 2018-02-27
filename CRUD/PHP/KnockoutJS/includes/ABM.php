<?php

error_reporting(1);

if( isset($_POST['type']) && !empty( isset($_POST['type']) ) ){
	$type = $_POST['type'];
	
	switch ($type) {
		case "checkTipoUsuario":
			check_tipo_usuario();
			break;
		case "ingresoUsuario":
			ingreso_usuario();
			break;
		case "getUsernameCookie":
			get_username_cookie();
			break;
		case "cerrarSesion":
			cerrar_sesion();
			break;
	}
}

function ingreso_usuario() {
	$username = $_POST["username"];
	$password = $_POST["password"];
	$data = array();
	$response = false;
	$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . md5($password) . "'";
	$conexion = abrir_conexion(); 
	$consulta = mysqli_query($conexion,$sql);
	$rows = mysqli_num_rows($consulta);
	if($rows > 0) {
		$data['success'] = true;
		$data['message'] = '1';

		session_start();
		$_SESSION["uid"]= base64_encode($username."@".md5($password));

	} else {
		$data['success'] = true;
		$data['message'] = '0';
	}
	
	echo json_encode($data);
	exit;
}

function verificar_cookie() {

	session_start();

	if(isset($_SESSION["uid"])) {
		$contenido = $_SESSION["uid"];
		$contenido = base64_decode($contenido);

		$split = explode("@", $contenido);

		$username = $split[0];
		$password = $split[1];

		$data = array();

		$response = false;
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . $password . "'";
		$conexion = abrir_conexion(); 
		$consulta = mysqli_query($conexion,$sql);
		$rows = mysqli_num_rows($consulta);
		if($rows > 0) {
			return true;
		} else {
			return false;
		}
	} else {
		return false;
	}

}

function verificar_cookie_admin() {

	session_start();

	if(isset($_SESSION["uid"])) {
		$contenido = $_SESSION["uid"];
		$contenido = base64_decode($contenido);

		$split = explode("@", $contenido);

		$username = $split[0];
		$password = $split[1];

		$data = array();

		$response = false;
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . $password . "'";
		$conexion = abrir_conexion(); 
		$consulta = mysqli_query($conexion,$sql);
		$rows = mysqli_num_rows($consulta);
		if($rows > 0) {
			$sql = "select tipo from usuarios where usuario='" . $username . "'";
			$consulta = mysqli_query($conexion,$sql);
			$row = mysqli_fetch_row($consulta);
			$check_tipo = $row[0];
			if($check_tipo=="1") {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
		mysqli_close($conexion);
	} else {
		return false;
	}

}

function get_username_cookie() {

	session_start();
	$contenido = $_SESSION["uid"];
	$contenido = base64_decode($contenido);

	$split = explode("@", $contenido);

	$username = $split[0];
	$password = $split[1];

	$data = array();

	$data['success'] = true;
	$data['message'] = $username;
	
	echo json_encode($data);
	exit;
}

function check_tipo_usuario() {
	$username = $_POST["username"];
	$data = array();
	$response = false;
	$conexion = abrir_conexion(); 
	$sql = "select tipo from usuarios where usuario='" . $username . "'";
	$consulta = mysqli_query($conexion,$sql);
	$row = mysqli_fetch_row($consulta);
	$check_tipo = $row[0];
	if($check_tipo=="1") {
		$data['success'] = true;
		$data['message'] = 'Administrador';
	} else {
		$data['success'] = true;
		$data['message'] = 'Usuario';
	}
	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function cerrar_sesion() {
	session_id('uid');
	session_start();
	session_destroy();
	session_commit();
}

if( isset($_POST['type']) && !empty( isset($_POST['type']) ) ){
	$type = $_POST['type'];
	
	switch ($type) {
		case "addProducto":
			agregarProducto();
			break;
		case "updateProducto":
			editarProducto();
			break;
		case "borrarProducto":
			borrarProducto();
			break;
		case "getProductos":
			listarProductos();
			break;
		case "addProveedor":
			agregarProveedor();
			break;
		case "updateProveedor":
			editarProveedor();
			break;
		case "borrarProveedor":
			borrarProveedor();
			break;
		case "getProveedores":
			listarProveedores();
			break;
		case "addUsuario":
			agregarUsuario();
			break;
		case "updateUsuario":
			editarUsuario();
			break;
		case "borrarUsuario":
			borrarUsuario();
			break;
		case "getUsuarios":
			listarUsuarios();
			break;
		case "changeUsername":
			cambiarUsuario();
			break;
		case "changePassword":
			cambiarPassword();
			break;
		case "loadIdProveedorMax":
			cargarIdProveedorMax();
			break;
	}
}

function abrir_conexion() {
	return new mysqli("localhost","root","","sistema");
}

function listarProductos() {
	$data = array(); 
	$conexion = abrir_conexion(); 
	$productos = array();
	$sql = "select id_producto,nombre_producto,descripcion,precio,prov.id_proveedor,nombre_empresa,fecha_registro from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor";
	$consulta = mysqli_query($conexion,$sql);
	while ($row = mysqli_fetch_array($consulta)) {
		$id_producto = $row[0];
		$nombre_producto = $row[1];
		$descripcion = $row[2];
		$precio = $row[3];
		$id_proveedor = $row[4];
		$nombre_empresa = $row[5];
		$fecha_registro = $row[6];
		
		$row["id"] = (int) $row["id_producto"];
		$data["data"][] = $row;
	}
	$data["success"] = true;
	mysqli_free_result($consulta);
	mysqli_close($conexion);
	echo json_encode($data);
	exit;
}

function listarProveedores() {
	$data = array();
	$conexion = abrir_conexion(); 
	$productos = array();
	$sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores";
	$consulta = mysqli_query($conexion,$sql);
	while ($row = mysqli_fetch_array($consulta)) {
		$id_proveedor = $fila[0];
		$nombre_empresa = $fila[1];
		$direccion = $fila[2];
		$telefono = $fila[3];
		$fecha_registro = $fila[4];
		
		$row["id"] = (int) $row["id_proveedor"];
		$data["data"][] = $row;
	}
	$data["success"] = true;
	mysqli_free_result($consulta);
	mysqli_close($conexion);
	echo json_encode($data);
	exit;
}

function cargarIdProveedorMax() {
	$data = array();
	$conexion = abrir_conexion(); 
	$productos = array();
	$sql = "select max(id_proveedor) from proveedores";
	$consulta = mysqli_query($conexion,$sql);
	if ($row = mysqli_fetch_array($consulta)) {
		$id_proveedor = $fila[0] + 1;
		$data["message"] = $id_proveedor;
	}
	$data["success"] = true;
	mysqli_free_result($consulta);
	mysqli_close($conexion);
	echo json_encode($data);
	exit;
}

function listarUsuarios() {
	$data = array();
	$conexion = abrir_conexion(); 
	$productos = array();
	$sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios";
	$consulta = mysqli_query($conexion,$sql);
	while ($row = mysqli_fetch_array($consulta)) {
		$id_usuario = $fila[0];
		$usuario = $fila[1];
		$clave = $fila[2];
		$tipo = $fila[3];
		$fecha_registro = $fila[4];
		
		$row["id"] = (int) $row["id_usuario"];
		
		if($row["tipo"]=="1") {
			$row["nombre_tipo"] = "Administrador"; 
		}
		
		if($row["tipo"]=="2") {
			$row["nombre_tipo"] = "Usuario"; 
		}		
		
		$data["data"][] = $row;
	}
	$data["success"] = true;
	mysqli_free_result($consulta);
	mysqli_close($conexion);
	echo json_encode($data);
	exit;
}

function agregarProducto() {
	
	$data = array();

	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];
	$fecha_registro = fecha_actual();
				
	$conexion = abrir_conexion(); 
	$sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" . $nombre_producto . "','" . $descripcion . "'," . $precio . "," . $id_proveedor . ",'" . $fecha_registro . "')";	
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Producto agregado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error agregando producto';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function editarProducto() {
	
	$data = array();

	$id_producto = $_POST["id_producto"];
	$nombre_producto = $_POST["nombre_producto"];
	$descripcion = $_POST["descripcion"];
	$precio = $_POST["precio"];
	$id_proveedor = $_POST["proveedor"];
				
	$conexion = abrir_conexion(); 
	$sql = "update productos set nombre_producto='" . $nombre_producto . "',descripcion='".$descripcion."',precio=".$precio.",id_proveedor=".$id_proveedor." where id_producto=" . $id_producto;
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Producto editado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error editando producto';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function borrarProducto() {
	$data = array();

	$id_producto = $_POST["id_producto"];
				
	$conexion = abrir_conexion(); 
	$sql = "delete from productos where id_producto='".$id_producto."'";	
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Producto borrado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error borrando producto';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;	
}

function agregarProveedor() {
	
	$data = array();

	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
	$fecha_registro = $_POST["fecha_registro"];
				
	$conexion = abrir_conexion(); 
	$sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" . $nombre_empresa . "','" . $direccion . "'," . $telefono . ",'" . $fecha_registro . "')";	
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Proveedor agregado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error agregando proveedor';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function editarProveedor() {
	
	$data = array();

	$id_proveedor = $_POST["id_proveedor"];
	$nombre_empresa = $_POST["nombre_empresa"];
	$direccion = $_POST["direccion"];
	$telefono = $_POST["telefono"];
				
	$conexion = abrir_conexion(); 
	$sql = "update proveedores set nombre_empresa='" . $nombre_empresa . "',direccion='".$direccion."',telefono=".$telefono." where id_proveedor=" . $id_proveedor;
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Producto editado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error editando producto';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function borrarProveedor() {
	$data = array();

	$id_proveedor = $_POST["id_proveedor"];
				
	$conexion = abrir_conexion(); 
	$sql = "delete from proveedores where id_proveedor=" . $id_proveedor;
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Proveedor borrado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error borrando proveedor';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;	
}

function agregarUsuario() {
	
	$data = array();

	$nombre_usuario = $_POST["nombre_usuario"];
	$clave = $_POST["password"];
	$tipo = $_POST["tipo"];
	$fecha_registro = $_POST["fecha_registro"];
	
	$password_encoded = md5($clave);
				
	$conexion = abrir_conexion(); 
	$sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" . $nombre_usuario . "','" . $password_encoded . "'," . $tipo . ",'" . $fecha_registro . "')";	
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Usuario agregado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error agregando usuario';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function editarUsuario() {
	
	$data = array();

	$id_usuario = $_POST["id_usuario"];
	$tipo = $_POST["tipo"];
				
	$conexion = abrir_conexion(); 
	$sql = "update usuarios set tipo=".$tipo." where id_usuario='".$id_usuario."'";
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Usuario editado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error editando usuario';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
}

function borrarUsuario() {
	$data = array();

	$id_usuario = $_POST["id_usuario"];
				
	$conexion = abrir_conexion(); 
	$sql = "delete from usuarios where id_usuario=" . $id_usuario;
	$consulta = mysqli_query($conexion,$sql);
	
	if($consulta) {
		$data['success'] = true;
		$data['message'] = 'Usuario borrado';
	} else {
		$data['success'] = false;
		$data['message'] = 'Error borrando usuario';		
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;	
}
   
function cambiarUsuario() {

	$data = array();
	  
	$username     = $_POST["username"];
	$new_username = $_POST["new_username"];
	$password     = $_POST["password"];
		
	$conexion = abrir_conexion(); 
			
	if ($username == "" || $new_username == "" || $password == "") {
		$data['success'] = false;
		$data['message'] = "Faltan datos para cambiar el nombre de usuario";
	} else {
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . md5($password) . "'";
		$conexion = abrir_conexion(); 
		$consulta = mysqli_query($conexion,$sql);
		$rows = mysqli_num_rows($consulta);
		if($rows > 0) {
		 	$sql = "update usuarios set usuario='" . $new_username . "' where usuario='" . $username . "'";		 
		 	$consulta = mysqli_query($conexion,$sql);
			if($consulta) {
				$data['success'] = true;
				$data['message'] = "El nombre de usuario ha sido cambiado , reinicie la aplicacion";				
			} else {
				$data['success'] = false;
				$data['message'] = "Ha ocurrido un error cambiando el nombre de usuario";
			}
		} else {
			$data['success'] = false;
			$data['message'] = "La contraseña no coincide";
		}
	}
	
	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
	  
} 

function cambiarPassword() {

	$data = array();
        
	$username = $_POST["username"];
	$old_pass = $_POST["anterior_password"];
	$new_pass = $_POST["new_password"];
	
	$conexion = abrir_conexion(); 
	
	if ($username == "" || $old_pass == "" || $new_pass == "") {
		$data['success'] = false;
		$data['message'] = "Faltan datos para cambiar la contraseña";
	} else {
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . md5($old_pass) . "'";
		$conexion = abrir_conexion(); 
		$consulta = mysqli_query($conexion,$sql);
		$rows = mysqli_num_rows($consulta);
		if($rows > 0) {
		 	$sql = "update usuarios set clave='" . md5($new_pass) . "' where usuario='" . $username . "'";		 
		 	$consulta = mysqli_query($conexion,$sql);
			if($consulta) {
				$data['success'] = true;
				$data['message'] = "El password ha sido cambiado , reinicie la aplicacion";				
			} else {
				$data['success'] = false;
				$data['message'] = "Ha ocurrido un error cambiando el password";
			}
		} else {
			$data['success'] = false;
			$data['message'] = "La contraseña no coincide";
		}
	}

	mysqli_close($conexion);
					
	echo json_encode($data);
	exit;
        
}

function fecha_actual() {
	date_default_timezone_set("America/Argentina/Cordoba");
	$fecha = date("d/m/Y", time());
	return $fecha;
}

?>