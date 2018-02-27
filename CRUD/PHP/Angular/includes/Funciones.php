<?php

function mensaje($titulo,$contenido,$tipo,$ruta) {
	echo "
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

function mensaje_con_redireccion($titulo,$contenido,$tipo,$ruta) {
	echo "
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

function cambiar_password_y_cerrar_sesion() {
	$ruta = "?logout";
	mensaje_con_redireccion("Cambiar Password","La contraseña ha sido cambiada exitosamente , reinicie la aplicacion","success",$ruta);
}

function cambiar_usuario_y_cerrar_sesion() {
	$ruta = "?logout";
	mensaje_con_redireccion("Cambiar Usuario","El nombre de usuario ha sido cambiado exitosamente , reinicie la aplicacion","success",$ruta);
}

function redireccion($pagina) {
	echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($pagina) . '" />'; 
}


function fecha_actual() {
	date_default_timezone_set("America/Argentina/Cordoba");
	$fecha = date("d/m/Y", time());
	return $fecha;
}

?>