<?php

error_reporting(1);

function abrir_conexion() {
	return new mysqli("localhost","root","","sistema");
}

?>