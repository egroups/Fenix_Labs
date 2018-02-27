<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormEstadisticas">

<?php

echo "<center><h1>Reporte Estadístico</h1></center></br>";

include_once("ListadoProductos.php");
include_once("Grafico1.php");
include_once("Grafico2.php");
			    
?>

</div>