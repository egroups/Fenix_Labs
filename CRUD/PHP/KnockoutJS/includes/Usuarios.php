<?php

class Usuario {

  private $id_usuario;
  private $nombre;
  private $password;
  private $tipo;
  private $fecha_registro;

  public function __construct(){
    	$this->id_usuario = "";
		$this->nombre = "";
		$this->password = "";
		$this->tipo = "";
		$this->fecha_registro = "";
   }

  public static function CreateUsuario($id_usuario,$nombre,$password,$tipo,$fecha_registro) {
   		$instance = new self();
    	$instance->id_usuario = $id_usuario;
		$instance->nombre = $nombre;
		$instance->password = $password;
		$instance->tipo = $tipo;
		$instance->fecha_registro = $fecha_registro;
    	return $instance;
  }

  public function getId_usuario() {
    	return $this->id_usuario;
  }

  public function setId_usuario($id_usuario) {
    	$this->id_usuario = $id_usuario;
  }
  
  public function getNombre() {
   	 	return $this->nombre;
  }

  public function setNombre($nombre) {
    	$this->nombre = $nombre;
  }
  
  public function getPassword() {
    	return $this->password;
  }

  public function setPassword($password) {
    	$this->password = $password;
  }

  public function getTipo() {
   	 	return $this->tipo;
  }

  public function setTipo($tipo) {
   	 	$this->tipo = $tipo;
  }
  
  public function getFecha_registro() {
    	return $this->fecha_registro;
  }

  public function setFecha_registro($fecha_registro) {
    	$this->fecha_registro = $fecha_registro;
  }
  
  public function __destruct(){
    	$this->id_usuario = "";
		$this->nombre = "";
		$this->password = "";
		$this->tipo = "";
		$this->fecha_registro = "";
   }  
   
   public function toString() {
		return "Usuario{" . "id_usuario=" . $this->id_usuario . ", nombre=" . $this->nombre . ", password=" . $this->password . ", tipo=" . $this->tipo . ", fecha_registro=" . $this->fecha_registro . '}';
   }
  
}

?>