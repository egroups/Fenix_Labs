<?php

// Written By Ismael Heredia in the year 2017

include_once("Funciones.php");

error_reporting(1);

$api_url = "http://localhost/sistemas/RestApi/api/v1";

class Cliente {

   private $cliente;
  
   public function __construct(){
    	$this->cliente = "";
   }

   public function listarProductos() {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/productos/");
		$json_decoded = json_decode(clean_json($json_encoded));
		$productos = $json_decoded->data;
		return $productos;
   }

   public function listarProveedores() {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/proveedores/");
		$json_decoded = json_decode(clean_json($json_encoded));
		$proveedores = $json_decoded->data;
		return $proveedores;
   }

   public function listarUsuarios() {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/usuarios/");
		$json_decoded = json_decode(clean_json($json_encoded));
		$usuarios = $json_decoded->data;
		return $usuarios;
   }

   public function cargarProducto($id_to_load) {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/productos/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$producto = $json_decoded->data;
		return $producto;
   }

   public function cargarProveedor($id_to_load) {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/proveedores/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$producto = $json_decoded->data;
		return $producto;
   }

   public function cargarUsuario($id_to_load) {
		$json_encoded = $this->ComandoGET($GLOBALS['api_url']."/usuarios/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$usuario = $json_decoded->data;
		return $usuario;
   }

   public function agregarProducto($nombre_producto,$descripcion,$precio,$id_proveedor) {
   		$data = array("nombre_producto" => $nombre_producto , "descripcion" => $descripcion , "precio" => $precio , "id_proveedor" => $id_proveedor);
		$json_encoded = $this->ComandoPOST($GLOBALS['api_url']."/productos/",$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function editarProducto($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor) {
   		$data = array("id_producto" => $id_producto , "nombre_producto" => $nombre_producto , "descripcion" => $descripcion , "precio" => $precio , "id_proveedor" => $id_proveedor);
		$json_encoded = $this->ComandoPUT($GLOBALS['api_url']."/productos/".$id_producto,$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function borrarProducto($id_to_load) {
		$json_encoded = $this->ComandoDELETE($GLOBALS['api_url']."/productos/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$producto = $json_decoded;
		return $producto;
   }

   public function agregarProveedor($nombre_empresa,$direccion,$telefono) {
   		$data = array("nombre_empresa" => $nombre_empresa , "direccion" => $direccion , "telefono" => $telefono);
		$json_encoded = $this->ComandoPOST($GLOBALS['api_url']."/proveedores/",$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function editarProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono) {
   		$data = array("id_proveedor" => $id_proveedor , "nombre_empresa" => $nombre_empresa , "direccion" => $direccion , "telefono" => $telefono);
		$json_encoded = $this->ComandoPUT($GLOBALS['api_url']."/proveedores/".$id_producto,$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function borrarProveedor($id_to_load) {
		$json_encoded = $this->ComandoDELETE($GLOBALS['api_url']."/proveedores/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$producto = $json_decoded;
		return $producto;
   }

   public function agregarUsuario($nombre_usuario,$clave,$tipo) {
   		$data = array("nombre_usuario" => $nombre_usuario , "password" => $clave , "tipo" => $tipo);
		$json_encoded = $this->ComandoPOST($GLOBALS['api_url']."/usuarios/",$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function editarUsuario($id_usuario,$tipo) {
   		$data = array("id_usuario" => $id_usuario , "tipo" => $tipo);
		$json_encoded = $this->ComandoPUT($GLOBALS['api_url']."/usuarios/".$id_producto,$data);
		$json_decoded = json_decode(clean_json($json_encoded));
		$respuesta = $json_decoded;
		return $respuesta;
   }

   public function borrarUsuario($id_to_load) {
		$json_encoded = $this->ComandoDELETE($GLOBALS['api_url']."/usuarios/".$id_to_load);
		$json_decoded = json_decode(clean_json($json_encoded));
		$producto = $json_decoded;
		return $producto;
   }

   private function ComandoGET($url)
   {
		$web_client = curl_init($url);
		curl_setopt($web_client, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($web_client, CURLOPT_CUSTOMREQUEST, "GET");
		$response = curl_exec($web_client);
		curl_close($web_client);
		if(!$response) {
		    return false;
		}else{
			return $response;
		}
    }

	public function ComandoPOST($url,$data)
	{
		$web_client = curl_init($url);
		curl_setopt($web_client, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($web_client, CURLOPT_CUSTOMREQUEST, "POST");
		curl_setopt($web_client, CURLOPT_POSTFIELDS,http_build_query($data));
		$response = curl_exec($web_client);
		curl_close($web_client);
		if(!$response) {
		    return false;
		}else{
			return $response;
		}
	}

	public function ComandoPUT($url,$data)
	{
		$web_client = curl_init($url);
		curl_setopt($web_client, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($web_client, CURLOPT_CUSTOMREQUEST, "PUT");
		curl_setopt($web_client, CURLOPT_POSTFIELDS,http_build_query($data));
		$response = curl_exec($web_client);
		curl_close($web_client);
		if(!$response) {
		    return false;
		}else{
			return $response;
		}
	}

	public function ComandoDELETE($url,$data)
	{
		$web_client = curl_init($url);
		curl_setopt($web_client, CURLOPT_RETURNTRANSFER, true);
		curl_setopt($web_client, CURLOPT_CUSTOMREQUEST, "DELETE");
		curl_setopt($web_client, CURLOPT_POSTFIELDS,http_build_query($data));
		$response = curl_exec($web_client);
		curl_close($web_client);
		if(!$response) {
		    return false;
		}else{
			return $response;
		}
	}

    public function __destruct(){
    	$this->cliente = "";
    } 

}

?>