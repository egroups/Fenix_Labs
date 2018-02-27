<?php

// Written By Ismael Heredia in the year 2017

include_once("Proveedores.php");
include_once("Productos.php");
include_once("Usuarios.php");
include_once("Funciones.php");

class Conexion {

   private $conexion;
  
   public function __construct(){
    	$this->conexion = "";
   }

   public function abrir_conexion() {
		$this->conexion = new mysqli("localhost","root","","sistema");   
   }
   
   public function cargarConsulta($sql) {
   		$rows = "";
   		$this->abrir_conexion();
		$consulta = mysqli_query($this->conexion,$sql);
		$rows = mysqli_num_rows($consulta);
		if($rows > 0) {
			return $rows;
		} else {
			return 0;
		}
   		$this->cerrar_conexion();
   }
   
   public function ejecutarConsulta($sql) {
   		$this->abrir_conexion();
		$consulta = mysqli_query($this->conexion,$sql);
		if($consulta) {
			return true;
		} else {
			return false;
		}
   		$this->cerrar_conexion();
   }
      
   public function cargarNombreProveedor($id_proveedor) {
   		$data = array(); 
   		$nombre_empresa = "";
		$this->abrir_conexion();
		$sql = "select nombre_empresa from proveedores where id_proveedor='" . $id_proveedor . "'";
		$consulta = mysqli_query($this->conexion,$sql);
		$row = mysqli_fetch_row($consulta);
		$nombre_empresa = $row[0];
		$this->cerrar_conexion();
		$data["success"] = true;
		$data["nombre_empresa"] = $nombre_empresa;
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }
   
   public function listarProveedores() {
   		$this->abrir_conexion();
   		$proveedores = array();
		$sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($row = mysqli_fetch_array($consulta)) {
			$id_proveedor = $row[0];
			$nombre_empresa = $row[1];
			$direccion = $row[2];
			$telefono = $row[3];
			$fecha_registro = $row[4];
			
			$data["data"][] = $row;
		}
		$data["success"] = true;
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit;
   }

   public function cargarProveedor($id_to_load) {
   		$this->abrir_conexion();
   		$proveedores = array();
		$sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores where id_proveedor=".$id_to_load;
		$consulta = mysqli_query($this->conexion,$sql);
		if ($row = mysqli_fetch_array($consulta)) {
			$id_proveedor = $row[0];
			$nombre_empresa = $row[1];
			$direccion = $row[2];
			$telefono = $row[3];
			$fecha_registro = $row[4];
			
			$data["data"] = $row;
		}
		$data["success"] = true;
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit;
   }

   public function listarProductos() {
		$data = array(); 
		$this->abrir_conexion();
		$sql = "select id_producto,nombre_producto,descripcion,precio,prov.id_proveedor,nombre_empresa,fecha_registro from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($row = mysqli_fetch_array($consulta)) {
			$id_producto = $row[0];
			$nombre_producto = $row[1];
			$descripcion = $row[2];
			$precio = $row[3];
			$id_proveedor = $row[4];
			$nombre_empresa = $row[5];
			$fecha_registro = $row[6];

			$data["data"][] = $row;
		}
		$data["success"] = true;
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function cargarProducto($id_to_load) {
		$data = array(); 
		$this->abrir_conexion();
		$sql = "select id_producto,nombre_producto,descripcion,precio,prov.id_proveedor,nombre_empresa,fecha_registro from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor and prod.id_producto=".$id_to_load;
		$consulta = mysqli_query($this->conexion,$sql);
		if ($row = mysqli_fetch_array($consulta)) {
			$id_producto = $row[0];
			$nombre_producto = $row[1];
			$descripcion = $row[2];
			$precio = $row[3];
			$id_proveedor = $row[4];
			$nombre_empresa = $row[5];
			$fecha_registro = $row[6];

			$data["data"] = $row;
		}
		$data["success"] = true;
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function agregarProducto($nombre_producto,$descripcion,$precio,$id_proveedor) {

		$data = array(); 

		$success = "";
		$mensaje = "";
		
		if($nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor))
		{
			$success = false;
			$mensaje = "Faltan datos para registrar el producto";
		} else {
			$this->abrir_conexion();
			$fecha_registro = fecha_actual();
			$sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" . $nombre_producto . "','" . $descripcion . "'," . $precio . "," . $id_proveedor . ",'" . $fecha_registro . "')";
			
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Producto registrado";
			} else {
				$success = false;
				$mensaje = "Error registrando producto";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function editarProducto($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor) {

		$data = array(); 

		$success = "";
		$mensaje = "";	

		if($id_producto=="" or !is_numeric($id_producto) or $nombre_producto=="" or $descripcion=="" or $precio=="" or !is_numeric($precio) or $id_proveedor=="" or !is_numeric($id_proveedor)) {
			$success = false;
			$mensaje = "Faltan datos para editar el producto";
		} else {
			$this->abrir_conexion();
			$sql = $sql = "update productos set nombre_producto='" . $nombre_producto . "',descripcion='".$descripcion."',precio=".$precio.",id_proveedor=".$id_proveedor." where id_producto=" . $id_producto;
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Producto editado";
			} else {
				$success = false;
				$mensaje = "Error editando producto";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }

   public function borrarProducto($id_producto) {

		$data = array(); 

		$success = "";
		$mensaje = "";

		if($id_producto=="" or !is_numeric($id_producto)) {
			$success = false;
			$mensaje = "ID Invalido";			
		} else {
			$sql = "delete from productos where id_producto=" . $id_producto;
			$this->abrir_conexion();
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Producto borrado";	
			} else {
				$success = false;
				$mensaje = "Error borrando producto";	
			}
			$this->cerrar_conexion();
		} 

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }

   public function agregarProveedor($nombre_empresa,$direccion,$telefono) {

		$data = array(); 

		$success = "";
		$mensaje = "";
		
		if($nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono))
		{
			$success = false;
			$mensaje = "Faltan datos para registrar el proveedor";
		} else {
			$this->abrir_conexion();
			$fecha_registro = fecha_actual();
			$sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" . $nombre_empresa . "','" . $direccion . "'," . $telefono . ",'" . $fecha_registro . "')";
			
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Proveedor registrado";
			} else {
				$success = false;
				$mensaje = "Error registrando proveedor";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function editarProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono) {

		$data = array(); 

		$success = "";
		$mensaje = "";	

		if($id_proveedor=="" or !is_numeric($id_proveedor) or $nombre_empresa=="" or $direccion=="" or $telefono=="" or !is_numeric($telefono)) {
			$success = false;
			$mensaje = "Faltan datos para editar el proveedor";
		} else {
			$this->abrir_conexion();
			$sql = "update proveedores set nombre_empresa='" . $nombre_empresa . "',direccion='".$direccion."',telefono=".$telefono." where id_proveedor=" . $id_proveedor;
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Proveedor editado";
			} else {
				$success = false;
				$mensaje = "Error editando proveedor";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }

   public function borrarProveedor($id_proveedor) {

		$data = array(); 

		$success = "";
		$mensaje = "";

		if($id_proveedor=="" or !is_numeric($id_proveedor)) {
			$success = false;
			$mensaje = "ID Invalido";			
		} else {
			$sql = "delete from proveedores where id_proveedor=" . $id_proveedor;
			$this->abrir_conexion();
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Proveedor borrado";	
			} else {
				$success = false;
				$mensaje = "Error borrando proveedor";	
			}
			$this->cerrar_conexion();
		} 

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }

   function listarUsuarios() {
		$data = array();
		$this->abrir_conexion();
		$sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($row = mysqli_fetch_array($consulta)) {
			$id_usuario = $row[0];
			$usuario = $row[1];
			$clave = $row[2];
			$tipo = $row[3];
			$fecha_registro = $fila[4];
						
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
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   } 

   function cargarUsuario($id_to_load) {
		$data = array();
		$this->abrir_conexion();
		$sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios where id_usuario=".$id_to_load;
		$consulta = mysqli_query($this->conexion,$sql);
		if ($row = mysqli_fetch_array($consulta)) {
			$id_usuario = $row[0];
			$usuario = $row[1];
			$clave = $row[2];
			$tipo = $row[3];
			$fecha_registro = $fila[4];
						
			if($row["tipo"]=="1") {
				$row["nombre_tipo"] = "Administrador"; 
			}
			
			if($row["tipo"]=="2") {
				$row["nombre_tipo"] = "Usuario"; 
			}		
			
			$data["data"] = $row;
		}
		$data["success"] = true;
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function agregarUsuario($nombre_usuario,$clave,$tipo) {

		$data = array(); 

		$success = "";
		$mensaje = "";
		
		if($nombre_usuario=="" or $clave=="" or $tipo=="" or !is_numeric($tipo))
		{
			$success = false;
			$mensaje = "Faltan datos para registrar al usuario";
		} else {
			$this->abrir_conexion();
			$password_encoded = md5($clave);
			$fecha_registro = fecha_actual();
			$sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" . $nombre_usuario . "','" . $password_encoded . "'," . $tipo . ",'" . $fecha_registro . "')";
			
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Usuario registrado";
			} else {
				$success = false;
				$mensaje = "Error registrando usuario";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 
   }

   public function editarUsuario($id_usuario,$tipo) {

		$data = array(); 

		$success = "";
		$mensaje = "";	

		if($id_usuario=="" or !is_numeric($id_usuario) or $tipo=="" or !is_numeric($tipo)) {
			$success = false;
			$mensaje = "Faltan datos para editar al usuario";
		} else {
			$this->abrir_conexion();
			$sql = "update usuarios set tipo=".$tipo." where id_usuario='".$id_usuario."'";
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Usuario editado";
			} else {
				$success = false;
				$mensaje = "Error editando usuario";
			}
			$this->cerrar_conexion();
		}

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }

   public function borrarUsuario($id_usuario) {

		$data = array(); 

		$success = "";
		$mensaje = "";

		if($id_usuario=="" or !is_numeric($id_usuario)) {
			$success = false;
			$mensaje = "ID Invalido";			
		} else {
			$sql = "delete from usuarios where id_usuario=" . $id_usuario;
			$this->abrir_conexion();
			if($this->ejecutarConsulta($sql)) {
				$success = true;
				$mensaje = "Usuario borrado";	
			} else {
				$success = false;
				$mensaje = "Error borrando usuario";	
			}
			$this->cerrar_conexion();
		} 

		$data["message"] = $mensaje;
		$data["success"] = $success;

		echo json_encode($data,JSON_PRETTY_PRINT);
		exit; 

   }
   
   public function cerrar_conexion() {
   		mysqli_close($this->conexion);
   }

   public function __destruct(){
    	$this->conexion = "";
   }  
   
}

?>