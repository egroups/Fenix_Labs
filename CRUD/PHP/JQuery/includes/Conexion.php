<?php

include_once("Proveedores.php");
include_once("Productos.php");
include_once("Usuarios.php");

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
   
   public function ingreso_usuario($username,$password) {
   		$response = false;
		$sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . $password . "'";
		$cantidad = $this->cargarConsulta($sql);
		if($cantidad >= 1) {
			$response = true;
		} else {
			$response = false;
		}
		return $response;
   }
   
   public function es_admin($username) {
   		$response = false;
		$this->abrir_conexion();
		$sql = "select tipo from usuarios where usuario='" . $username . "'";
		$consulta = mysqli_query($this->conexion,$sql);
		$row = mysqli_fetch_row($consulta);
		$check_tipo = $row[0];
		if($check_tipo=="1") {
			$response = true;
		} else {
			$response = false;
		}
		$this->cerrar_conexion();
		return $response;
   }
   
   public function cargarNombreProveedor($id_proveedor) {
   		$nombre_empresa = "";
		$this->abrir_conexion();
		$sql = "select nombre_empresa from proveedores where id_proveedor='" . $id_proveedor . "'";
		$consulta = mysqli_query($this->conexion,$sql);
		$row = mysqli_fetch_row($consulta);
		$nombre_empresa = $row[0];
		$this->cerrar_conexion();
		return $nombre_empresa;
   }
   
   public function listarProveedores() {
   		$this->abrir_conexion();
   		$proveedores = array();
		$sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($fila = mysqli_fetch_array($consulta)) {
			$id_proveedor = $fila[0];
			$nombre_empresa = $fila[1];
			$direccion = $fila[2];
			$telefono = $fila[3];
			$fecha_registro = $fila[4];
			$proveedor = Proveedor::CreateProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono,$fecha_registro);
			array_push($proveedores,$proveedor);
		}
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		return $proveedores;
   }
   
   public function listarProductos() {
   		$this->abrir_conexion();
   		$productos = array();
		$sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($fila = mysqli_fetch_array($consulta)) {
			$id_producto = $fila[0];
			$nombre_producto = $fila[1];
			$descripcion = $fila[2];
			$precio = $fila[3];
			$id_proveedor = $fila[4];
			$fecha_registro = $fila[5];
			$producto = Producto::CreateProducto($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor,$fecha_registro);
			array_push($productos,$producto);
		}
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		return $productos;   
   }

   public function listarUsuarios() {
   		$this->abrir_conexion();
   		$usuarios = array();
		$sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios";
		$consulta = mysqli_query($this->conexion,$sql);
		while ($fila = mysqli_fetch_array($consulta)) {
			$id_usuario = $fila[0];
			$nombre_usuario = $fila[1];
			$clave = $fila[2];
			$tipo = $fila[3];
			$fecha_registro = $fila[4];
			$usuario = Usuario::CreateUsuario($id_usuario,$nombre_usuario,$clave,$tipo,$fecha_registro);
			array_push($usuarios,$usuario);
		}
		mysqli_free_result($consulta);
		$this->cerrar_conexion();
		return $usuarios;   
   }   
   
   public function cerrar_conexion() {
   		mysqli_close($this->conexion);
   }

   public function __destruct(){
    	$this->conexion = "";
   }  
   
}

?>