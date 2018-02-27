<?php

// Written by Ismael Heredia in the year 2017

class Conexion {

   private $conexion;
  
   public function __construct(){
    	$this->conexion = "";
   }

   public function abrir_conexion() {
		  $this->conexion = new PDO('mysql:host=localhost;dbname=sistemav2;charset=utf8', 'root', '');
	    $this->conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);   
   }

   public function retornar_conexion() {
   		return $this->conexion;
   }
               	   
   public function cerrar_conexion() {
   		$this->conexion = null;
   }

   public function __destruct(){
    	$this->conexion = "";
   }  
   
}

?>