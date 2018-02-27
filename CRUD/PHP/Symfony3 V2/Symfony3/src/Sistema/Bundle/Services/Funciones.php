<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Services;

class Funciones
{

	public function mensaje($titulo,$contenido,$tipo) {
		return "
		<script>
		swal({
				title: '".$titulo."',
				text: '".$contenido."',
				type:'".$tipo."',
				html:true,
				animation: false
	     });
		</script>
		";
	}

	public function mensaje_con_redireccion($titulo,$contenido,$tipo,$ruta) {
		return "
		<script>
		swal({
				title: '".$titulo."',
				text: '".$contenido."',
				type:'".$tipo."',
				html:true,
				animation: false
	     },function() {
	        window.location.href = '".$ruta."';  
	     });
		</script>
		";
	}

	function is_float($number) {
	    return is_float($number) || is_numeric($number) && ((float) $number != (int) $number);
	}

	public function fecha_actual() {
		date_default_timezone_set("America/Argentina/Cordoba");
		$fecha = date("d/m/Y", time());
		return $fecha;
	}

}