<?php

// Written By Ismael Heredia in the year 2016

include_once("Autos.php");
include_once("Cocheras.php");
include_once("Edificios.php");
include_once("Casas.php");

echo "<pre>";

//$proveedor = new Proveedor();

//echo $proveedor->setNombre_empresa("test");
//echo $proveedor->getNombre_empresa();

$auto = Auto::CreateAuto("Bora 2009", "EJS748");
//echo $auto->DatosAuto();

echo "\n\n";

$cochera = Cochera::CreateCochera(1, "2.60 x 3.35", $auto);
//$cochera = Cochera::CreateCochera(1, "2.60 x 3.35",null);
//echo $cochera->DatosCocheraCompleto();

echo "\n\n";

//$edificio = Edificio::CreateEdificio("40x40",3);
//echo $edificio->DatosEdificio();

$casa = Casa::CreateCasa("40x40",3,"Felipe Olmos", 4876972, "Test 2047", $cochera);
//$casa = Casa::CreateCasa("40x40",3,"Felipe Olmos", 4876972, "Test 2047",null);
//echo $casa->DatosCasa();
echo $casa->DatosCasaCompleto();

echo "\n\n";

echo "</pre>";

?>