<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");

if(!verificarCookie()) {
  exit;
}
	
echo "<center><h1>Reporte Estadístico</h1></center></br>";

include_once("listado.php");
include_once("grafico1.php");
include_once("grafico2.php");
		    
?>