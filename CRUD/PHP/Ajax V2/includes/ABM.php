<?php

error_reporting(1);

include_once("Conexion.php");
include_once("Funciones.php");

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
		case "cerrarSesion":
			cerrar_sesion();
	}
}

function check_tipo_usuario() {
	$username = $_POST["username"];
	$data = array();
	$response = false;
	
	$conexion_now = new Conexion(); 
	$conexion_now->abrir_conexion();
	$conexion = $conexion_now->retornar_conexion();

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
	$conexion_now->cerrar_conexion();
					
	echo json_encode($data);
	exit;
}

function ingreso_usuario() {
	$username = $_POST["username"];
	$password = $_POST["password"];
	$data = array();
	$response = false;
	$conexion_now = new Conexion();
	$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . md5($password) . "'";
	$rows = $conexion_now->cargarConsulta($sql);
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
		$conexion_now = new Conexion();
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . $password . "'";
		$rows = $conexion_now->cargarConsulta($sql);
		if($rows > 0) {
			return true;
		} else {
			return false;
		}
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

function cerrar_sesion() {
	session_id('uid');
	session_start();
	session_destroy();
	session_commit();
}

if(verificar_cookie()) {

	if(isset($_POST["agregar_producto"])) {

		$nombre_producto = $_POST["nombre_producto"];
		$descripcion = $_POST["descripcion"];
		$precio = $_POST["precio"];
		$id_proveedor = $_POST["proveedor"];
		
		$ruta = "administracion.php?productos=";
		
		if($nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) 	{
			mensaje("Productos","Faltan datos para registrar el producto","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$fecha_registro = fecha_actual();
			$sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" . $nombre_producto . "','" . $descripcion . "'," . $precio . "," . $id_proveedor . ",'" . $fecha_registro . "')";
			
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Productos","Producto registrado","success",$ruta);
			} else {
				mensaje("Productos","Error registrando producto","error",$ruta);
			}
			unset($conexion_now);
		}
	}

	if(isset($_POST["grabar_edicion_producto"])) {

		$id_producto = $_POST["id_producto"];
		$nombre_producto = $_POST["nombre_producto"];
		$descripcion = $_POST["descripcion"];
		$precio = $_POST["precio"];
		$id_proveedor = $_POST["proveedor"];
		
		$ruta = "administracion.php?productos=";	
		if($id_producto=="" or !is_numeric($id_producto) or $nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) {
			mensaje("Productos","Faltan datos para editar el producto","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$sql = $sql = "update productos set nombre_producto='" . $nombre_producto . "',descripcion='".$descripcion."',precio=".$precio.",id_proveedor=".$id_proveedor." where id_producto=" . $id_producto;
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Productos","Producto editado","success",$ruta);
			} else {
				mensaje("Productos","Error editando producto","error",$ruta);
			}
			unset($conexion_now);
		}

	}

	if(isset($_POST["borrar_producto"])) {
		$id_producto = $_POST["borrar_producto"];
		$ruta = "administracion.php?productos=";
		if($id_producto=="" or !is_numeric($id_producto)) {
			echo "<script>alert('ID Invalido');</script>";
		} else {
			$sql = "delete from productos where id_producto=" . $id_producto;
			$conexion_now = new Conexion();
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Productos","Producto borrado","success",$ruta);
			} else {
				mensaje("Productos","Error borrando producto","error",$ruta);
			}
			unset($conexion_now);
		}
	}

	if(isset($_POST["agregar_proveedor"])) {

		$nombre_empresa = $_POST["nombre_empresa"];
		$direccion = $_POST["direccion"];
		$telefono = $_POST["telefono"];
		
		$ruta = "administracion.php?proveedores=";
				
		if($nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
			mensaje("Proveedores","Faltan datos para registrar el proveedor","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$fecha_registro = fecha_actual();
			$sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" . $nombre_empresa . "','" . $direccion . "'," . $telefono . ",'" . $fecha_registro . "')";
			
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Proveedores","Proveedor registrado","success",$ruta);
			} else {
				mensaje("Proveedores","Error registrando proveedor","error",$ruta);
			}
			unset($conexion_now);
		}

	}

	if(isset($_POST["grabar_edicion_proveedor"])) {

		$id_proveedor = $_POST["id_proveedor"];
		$nombre_empresa = $_POST["nombre_empresa"];
		$direccion = $_POST["direccion"];
		$telefono = $_POST["telefono"];
		
		$ruta = "administracion.php?proveedores=";
		
		if($id_proveedor=="" or !is_numeric($id_proveedor) or $nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
			mensaje("Proveedores","Faltan datos para editar el proveedor","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$sql = "update proveedores set nombre_empresa='" . $nombre_empresa . "',direccion='".$direccion."',telefono=".$telefono." where id_proveedor=" . $id_proveedor;
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Proveedores","Proveedor editado","success",$ruta);
			} else {
				mensaje("Proveedores","Error editando proveedor","error",$ruta);
			}
			unset($conexion_now);		
		}
	}

	if(isset($_POST["borrar_proveedor"])) {
		$id_proveedor = $_POST["borrar_proveedor"];
		$ruta = "administracion.php?proveedores=";
		if($id_proveedor=="" or !is_numeric($id_proveedor)) {
			echo "<script>alert('ID Invalido');</script>";
		} else {
			$sql = "delete from proveedores where id_proveedor=" . $id_proveedor;
			$conexion_now = new Conexion();
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Proveedores","Proveedor borrado","success",$ruta);
			} else {
				mensaje("Proveedores","Error borrando proveedor","error",$ruta);
			}
			unset($conexion_now);
		}
	}

	if(isset($_POST["agregar_usuario"])) {

		$nombre_usuario = $_POST["nombre_usuario"];
		$clave = $_POST["password"];
		$tipo = $_POST["tipo"];
		
		$ruta = "administracion.php?usuarios=";
		
		if($nombre_usuario=="" or $clave=="" or $tipo=="" or !is_numeric($tipo)) {
			mensaje("Usuarios","Faltan datos para agregar el usuario","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$fecha_registro = fecha_actual();
			$password_encoded = md5($clave);
			$sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" . $nombre_usuario . "','" . $password_encoded . "'," . $tipo . ",'" . $fecha_registro . "')";
			
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Usuarios","Usuario registrado","success",$ruta);
			} else {
				mensaje("Usuarios","Error registrando usuario","error",$ruta);
			}
			unset($conexion_now);
		}

	}

	if(isset($_POST["grabar_edicion_usuario"])) {

		$id_usuario = $_POST["id_usuario"];
		$tipo = $_POST["tipo"];
		
		$ruta = "administracion.php?usuarios=";	
		if($id_usuario=="" or !is_numeric($id_usuario) or $tipo=="" or !is_numeric($tipo)) {
			mensaje("Usuarios","Faltan datos para editar el usuario","warning",$ruta);
		} else {
			$conexion_now = new Conexion();
			$sql = "update usuarios set tipo=".$tipo." where id_usuario='".$id_usuario."'";
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Usuarios","Usuario editado","success",$ruta);
			} else {
				mensaje("Usuarios","Error editando usuario","error",$ruta);
			}
			unset($conexion_now);
		}

	}

	if(isset($_POST["borrar_usuario"])) {
		$id_usuario = $_POST["borrar_usuario"];
		$ruta = "administracion.php?usuarios=";
		if($id_usuario=="" or !is_numeric($id_usuario)) {
			mensaje("Usuarios","ID Invalido","warning",$ruta);
		} else {
			$sql = "delete from usuarios where id_usuario=" . $id_usuario;
			$conexion_now = new Conexion();
			if($conexion_now->ejecutarConsulta($sql)) {
				mensaje("Usuarios","Usuario borrado","success",$ruta);
			} else {
				mensaje("Usuarios","Error borrando usuario","error",$ruta);
			}
			unset($conexion_now);
		}
	}

	if (isset($_POST["cambiar_user"])) {
		  
		$username     = $_POST["username"];
		$new_username = $_POST["new_username"];
		$password     = $_POST["password"];
		
		$ruta = "administracion.php?cambiar_usuario";
		
		$conexion_now = new Conexion();
				
		if ($username == "" || $new_username == "" || $password == "") {
			mensaje("Cambiar Usuario","Faltan datos para cambiar el nombre de usuario","warning",$ruta);
		} else {
			$password_encoded = md5($password);
			if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
				
				if ($conexion_now->EjecutarConsulta("update usuarios set usuario='" . $new_username . "' where usuario='" . $username . "'")) {
					cambiar_usuario_y_cerrar_sesion();
				} else {
					mensaje("Cambiar Usuario","Ha ocurrido un error cambiando el nombre de usuario","error",$ruta);
				}
			} else {
				mensaje("Cambiar Usuario","La contraseña no coincide","warning",$ruta);
			}
		}
		
		unset($conexion_now);
		  
	} 

	if (isset($_POST["cambiar_pass"])) {
	        
		$username = $_POST["username"];
		$old_pass = $_POST["anterior_password"];
		$new_pass = $_POST["new_password"];
		
		$ruta = "administracion.php?cambiar_password";
		
		$conexion_now = new Conexion();
		
		if ($username == "" || $old_pass == "" || $new_pass == "") {
			mensaje("Cambiar Password","Faltan datos para cambiar la contraseña","warning",$ruta);
		} else {
			$password_encoded = md5($old_pass);
			$new_pass_encoded = md5($new_pass);
			if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
				
				if ($conexion_now->EjecutarConsulta("update usuarios set clave='" . $new_pass_encoded . "' where usuario='" . $username . "'")) {
					cambiar_password_y_cerrar_sesion();
				} else {
					mensaje("Cambiar Password","Ha ocurrido un error cambiando la contraseña","error",$ruta);
				}
			} else {
				mensaje("Cambiar Password","La contraseña antigua no coincide","warning",$ruta);
			}
		}
		
		unset($conexion_now);
	        
	}

}

?>