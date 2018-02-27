<?php

// Written by Ismael Heredia in the year 2017

error_reporting(1);

include_once("AccesoDatos.php");
include_once("Funciones.php");
include_once("../entities/Producto.php");
include_once("../entities/Proveedor.php");
include_once("../entities/Usuario.php");
include_once("../entities/TipoUsuario.php");

if( isset($_POST['tipo']) && !empty( isset($_POST['tipo']) ) ){
	$tipo = $_POST['tipo'];
	
	switch ($tipo) {
		case "comprobarTipoUsuario":
			comprobarTipoUsuario();
			break;
		case "ingresoUsuario":
			ingresoUsuario();
			break;
		case "recibirUsuarioCookie":
			recibirUsuarioCookie();
			break;
		case "cerrarSesion":
			cerrarSesion();
			break;
		case "agregarProducto":
			agregarProducto();
			break;
		case "editarProducto":
			editarProducto();
			break;
		case "borrarProducto":
			borrarProducto();
			break;
		case "agregarProveedor":
			agregarProveedor();
			break;
		case "editarProveedor":
			editarProveedor();
			break;
		case "borrarProveedor":
			borrarProveedor();
			break;
		case "agregarUsuario":
			agregarUsuario();
			break;
		case "editarUsuario":
			editarUsuario();
			break;
		case "borrarUsuario":
			borrarUsuario();
			break;
		case "cambiarUsuario":
			cambiarUsuario();
			break;
		case "cambiarClave":
			cambiarClave();
			break;
	}
}

function comprobarTipoUsuario() {

	$usuario = $_POST["usuario"];

	$data = array();
	$response = false;
	
	$datos = new AccesoDatos(); 

	if($datos->es_admin($usuario)) {
		$data['success'] = true;
		$data['message'] = 'Administrador';
	} else {
		$data['success'] = true;
		$data['message'] = 'Usuario';
	}
					
	echo json_encode($data);
	exit;
}

function ingresoUsuario() {

	$usuario = $_POST["usuario"];
	$clave = md5($_POST["clave"]);

	$data = array();
	$response = false;

	$datos = new AccesoDatos(); 

	if($datos->ingreso_usuario($usuario,$clave)) {
		$data['success'] = true;
		$data['message'] = '1';

		session_start();
		$_SESSION["uid"]= base64_encode($usuario."@".$clave);

	} else {
		$data['success'] = true;
		$data['message'] = '0';
	}
	
	echo json_encode($data);
	exit;
}

function recibirUsuarioCookie() {

	session_start();
	
	$contenido = $_SESSION["uid"];
	$contenido = base64_decode($contenido);

	$split = explode("@", $contenido);

	$usuario = $split[0];
	$clave = $split[1];

	$data = array();

	$data['success'] = true;
	$data['message'] = $usuario;
	
	echo json_encode($data);
	exit;
}

function cerrarSesion() {
	session_id('uid');
	session_start();
	session_destroy();
	session_commit();
}

function agregarProducto() {
	
	if(verificarCookie()) {

		$nombre = $_POST["nombre"];
		$descripcion = $_POST["descripcion"];
		$precio = $_POST["precio"];
		$id_proveedor = $_POST["id_proveedor"];
				
		if($nombre=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) 	{
			mensaje("Productos","Faltan datos para registrar el producto","warning");
		} else {
			$fecha_registro = fecha_actual();

			$datos = new AccesoDatos();

			$producto = new Producto();
			$producto->setNombre($nombre);
			$producto->setDescripcion($descripcion);
			$producto->setPrecio($precio);
			$producto->setId_proveedor($id_proveedor);
			$producto->setFecha_registro($fecha_registro);	

			if($datos->comprobarExistenciaProductoCrear($nombre)) {
				mensaje("Productos","El producto $nombre ya existe","warning");
			} else {
				if($datos->agregarProducto($producto)) {
					mensaje("Productos","Producto registrado","success");
				} else {
					mensaje("Productos","Error registrando producto","error");
				}
			}
			
			unset($datos);
		}
	}
}

function editarProducto() {

	if(verificarCookie()) {

		$id = $_POST["id"];
		$nombre = $_POST["nombre"];
		$descripcion = $_POST["descripcion"];
		$precio = $_POST["precio"];
		$id_proveedor = $_POST["id_proveedor"];
	
		if($id=="" or !is_numeric($id) or $nombre=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) {
			mensaje("Productos","Faltan datos para editar el producto","warning");
		} else {

			$datos = new AccesoDatos();

			$producto = Producto::CreateProducto($id,$nombre,$descripcion,$precio,$id_proveedor,$fecha_registro);

			if($datos->comprobarExistenciaProductoEditar($id,$nombre)) {
				mensaje("Productos","El producto $nombre ya existe","warning");
			} else {
				if($datos->editarProducto($producto)) {
					mensaje("Productos","Producto editado","success");
				} else {
					mensaje("Productos","Error editando producto","error");
				}
			}

			unset($datos);
		}
	}
}

function borrarProducto() {

	if(verificarCookie()) {

		$id = $_POST["id"];

		if($id=="" or !is_numeric($id)) {
			mensaje("Productos","ID inválido","warning");
		} else {

			$producto = new Producto();
			$producto->setId($id);

			$datos = new AccesoDatos();

			if($datos->borrarProducto($producto)) {
				mensaje("Productos","Producto borrado","success");
			} else {
				mensaje("Productos","Error borrando producto","error");
			}

			unset($datos);
		}
	}
}

function agregarProveedor() {

	if(verificarCookie()) {

		$nombre = $_POST["nombre"];
		$direccion = $_POST["direccion"];
		$telefono = $_POST["telefono"];
						
		if($nombre=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
			mensaje("Proveedores","Faltan datos para registrar el proveedor","warning");
		} else {

			$datos = new AccesoDatos();

			$fecha_registro = fecha_actual();

			$proveedor = new Proveedor();
			$proveedor->setNombre($nombre);
			$proveedor->setDireccion($direccion);
			$proveedor->setTelefono($telefono);
			$proveedor->setFecha_registro($fecha_registro);	

			if($datos->comprobarExistenciaProveedorCrear($nombre)) {
				mensaje("Proveedores","El proveedor $nombre ya existe","warning");
			} else {
				if($datos->agregarProveedor($proveedor)) {
					mensaje("Proveedores","Proveedor registrado","success");
				} else {
					mensaje("Proveedores","Error registrando proveedor","error");
				}
			}

			unset($datos);
		}
	}
}

function editarProveedor() {

	if(verificarCookie()) {

		$id = $_POST["id"];
		$nombre = $_POST["nombre"];
		$direccion = $_POST["direccion"];
		$telefono = $_POST["telefono"];
				
		if($id=="" or !is_numeric($id) or $nombre=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
			mensaje("Proveedores","Faltan datos para editar el proveedor","warning");
		} else {

			$datos = new AccesoDatos();

			$proveedor = Proveedor::CreateProveedor($id,$nombre,$direccion,$telefono,$fecha_registro);

			if($datos->comprobarExistenciaProveedorEditar($id,$nombre)) {
				mensaje("Proveedores","El proveedor $nombre ya existe","warning");
			} else {
				if($datos->editarProveedor($proveedor)) {
					mensaje("Proveedores","Proveedor editado","success");
				} else {
					mensaje("Proveedores","Error editando proveedor","error");
				}
			}

			unset($conexion_now);		
		}
	}
}

function borrarProveedor() {

	if(verificarCookie()) {

		$id = $_POST["id"];

		if($id=="" or !is_numeric($id)) {
			mensaje("Proveedores","ID inválido","warning");
		} else {

			$datos = new AccesoDatos();

			$proveedor = new Proveedor();
			$proveedor->setId($id);

			if($datos->borrarProveedor($proveedor)) {
				mensaje("Proveedores","Proveedor borrado","success");
			} else {
				mensaje("Proveedores","Error borrando proveedor","error");
			}

			unset($datos);
		}
	}
}

function agregarUsuario() {

	if(verificarCookie()) {

		if(verificarCookieAdmin()) {

			$nombre = $_POST["nombre"];
			$clave = $_POST["clave"];
			$id_tipo = $_POST["id_tipo"];
					
			if($nombre=="" or $clave=="" or $id_tipo=="" or !is_numeric($id_tipo)) {
				mensaje("Usuarios","Faltan datos para agregar el usuario","warning");
			} else {

				$datos = new AccesoDatos();

				$fecha_registro = fecha_actual();
				$clave_encoded = md5($clave);

				$usuario = new Usuario();
				$usuario->setNombre($nombre);
				$usuario->setClave($clave_encoded);
				$usuario->setId_tipo($id_tipo);
				$usuario->setFecha_registro($fecha_registro);

				if($datos->comprobarExistenciaUsuarioCrear($nombre)) {
					mensaje("Usuarios","El usuario $nombre ya existe","warning");
				} else {
					if($datos->agregarUsuario($usuario)) {
						mensaje("Usuarios","Usuario registrado","success");
					} else {
						mensaje("Usuarios","Error registrando usuario","error");
					}
				}

				unset($datos);
			}
		} else {
			mensaje("Usuarios","Acceso Denegado","error");
		}
	}
}

function editarUsuario() {

	if(verificarCookie()) {

		if(verificarCookieAdmin()) {

			$id = $_POST["id"];
			$id_tipo = $_POST["id_tipo"];

			if($id=="" or !is_numeric($id) or $id_tipo=="" or !is_numeric($id_tipo)) {
				mensaje("Usuarios","Faltan datos para editar el usuario","warning");
			} else {
				
				$datos = new AccesoDatos();

				$usuario = new Usuario();
				$usuario->setId($id);
				$usuario->setId_tipo($id_tipo);

				if($datos->editarUsuario($usuario)) {
					mensaje("Usuarios","Usuario editado","success");
				} else {
					mensaje("Usuarios","Error editando usuario","error");
				}

				unset($datos);
			}

		} else {
			mensaje("Usuarios","Acceso Denegado","error");
		}

	}
}

function borrarUsuario() {

	if(verificarCookie()) {

		if(verificarCookieAdmin()) {

			$id = $_POST["id"];

			if($id=="" or !is_numeric($id)) {
				mensaje("Usuarios","ID Inválido","warning");
			} else {

				$datos = new AccesoDatos();
				
				$usuario = new Usuario();
				$usuario->setId($id);

				if($datos->borrarUsuario($usuario)) {
					mensaje("Usuarios","Usuario borrado","success");
				} else {
					mensaje("Usuarios","Error borrando usuario","error");
				}

				unset($datos);
			}

		} else {
			mensaje("Usuarios","Acceso Denegado","error");
		}
	}
}

function cambiarUsuario() {

	if(verificarCookie()) {
		  
		$usuario     = $_POST["usuario"];
		$nuevo_usuario = $_POST["nuevo_usuario"];
		$clave     = $_POST["clave"];
				
		$datos = new AccesoDatos();
				
		if ($usuario == "" || $nuevo_usuario == "" || $clave == "") {
			mensaje("Cambiar Usuario","Faltan datos para cambiar el nombre de usuario","warning");
		} else {
			$clave_encoded = md5($clave);
			if ($datos->ingreso_usuario($usuario, $clave_encoded)) {
				if($datos->comprobarExistenciaUsuarioCrear($nuevo_usuario)) {
					mensaje("Cambiar Usuario","El usuario $usuario ya existe","warning");
				} else {
					if ($datos->cambiarUsuario($usuario,$nuevo_usuario)) {
						cerrarSesion();
						mensaje_con_redireccion("Cambiar Usuario","El usuario ha sido cambiado exitosamente , reinicie la aplicación","success","index.php");
					} else {
						mensaje("Cambiar Usuario","Ha ocurrido un error cambiando el nombre de usuario","error");
					}
				}
			} else {
				mensaje("Cambiar Usuario","La clave no coincide","warning");
			}
		}
		
		unset($datos);
		  
	} 
}

function cambiarClave() {
	
	if(verificarCookie()) {
	        
		$usuario = $_POST["usuario"];
		$clave = $_POST["clave"];
		$nueva_clave = $_POST["nueva_clave"];
				
		$datos = new AccesoDatos();
		
		if ($usuario == "" || $clave == "" || $nueva_clave == "") {
			mensaje("Cambiar Clave","Faltan datos para cambiar la contraseña","warning");
		} else {
			$clave_encoded = md5($clave);
			$nueva_clave_encoded = md5($nueva_clave);
			if ($datos->ingreso_usuario($usuario, $clave_encoded)) {
				
				if ($datos->cambiarClave($usuario,$nueva_clave_encoded)) {
					cerrarSesion();
					mensaje_con_redireccion("Cambiar Clave","La clave ha sido cambiada exitosamente , reinicie la aplicación","success","index.php");

				} else {
					mensaje("Cambiar Clave","Ha ocurrido un error cambiando la contraseña","error");
				}
			} else {
				mensaje("Cambiar Clave","La clave no coincide","warning");
			}
		}
		
		unset($datos);
	        
	}
}

?>