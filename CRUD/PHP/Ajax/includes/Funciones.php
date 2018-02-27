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

function refrescar_productos() {
	echo "
<script>
	$.post(\"includes/BusquedaProductos.php\",{nombre_buscar:\"\"}, function(mensaje) {
		$(\"#busqueda\").html(mensaje);
	}); 
</script>
	";
}

function refrescar_proveedores() {
	echo "
<script>
	$.post(\"includes/BusquedaProveedores.php\",{nombre_buscar:\"\"}, function(mensaje) {
		$(\"#busqueda\").html(mensaje);
	}); 
</script>
	";
}

function refrescar_usuarios() {
	echo "
<script>
	$.post(\"includes/BusquedaUsuarios.php\",{nombre_buscar:\"\"}, function(mensaje) {
		$(\"#busqueda\").html(mensaje);
	}); 
</script>
	";
}

function recargar_form_productos() {
	echo "
<script>
	$.get(\"includes/FormAgregarProducto.php\", function(mensaje) {
		$(\"#contenido\").html(mensaje);
	}); 
</script>
	";
}

function recargar_form_proveedores() {
	echo "
<script>
	$.get(\"includes/FormAgregarProveedor.php\", function(mensaje) {
		$(\"#contenido\").html(mensaje);
	}); 
</script>
	";
}

function recargar_form_usuarios() {
	echo "
<script>
	$.get(\"includes/FormAgregarUsuario.php\", function(mensaje) {
		$(\"#contenido\").html(mensaje);
	}); 
</script>
	";
}

function limpiar_formulario_productos() {
	echo "
<script>
    $(\"input[name='nombre_producto']\").val(\"\");
	$(\"textarea[name='descripcion']\").val(\"\");
	$(\"input[name='precio']\").val(\"\");
	$(\"select[name='proveedor']\").val(\"1\");
	$(\"div[name='form-group-nombre']\").removeClass('has-success');
	$(\"div[name='form-group-descripcion']\").removeClass('has-success');
	$(\"div[name='form-group-precio']\").removeClass('has-success');
	$(\"div[name='form-group-proveedor']\").removeClass('has-success');
	$(\"div[name='form-group-nombre']\").removeClass('has-error');
	$(\"div[name='form-group-descripcion']\").removeClass('has-error');
	$(\"div[name='form-group-precio']\").removeClass('has-error');
	$(\"div[name='form-group-proveedor']\").removeClass('has-error');
</script>
	";
}

function limpiar_formulario_proveedores() {
	echo "
<script>
    nombre_check = $(\"input[name='nombre_empresa']\").val(\"\");
	direccion_check = $(\"input[name='direccion']\").val(\"\");
	telefono_check = $(\"input[name='telefono']\").val(\"\");
    $(\"div[name='form-group-nombre']\").removeClass('has-success');
    $(\"div[name='form-group-direccion']\").removeClass('has-success');
    $(\"div[name='form-group-telefono']\").removeClass('has-success');
    $(\"div[name='form-group-nombre']\").removeClass('has-error');
    $(\"div[name='form-group-direccion']\").removeClass('has-error');
    $(\"div[name='form-group-telefono']\").removeClass('has-error');
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

function contar_productos($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$productos = $conexion_now->listarProductos();
	foreach ($productos as $producto) {
		$nombre_producto  = $producto->getNombre_producto();
		if (preg_match('/'.$patron.'/',$nombre_producto)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_producto($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$productos = $conexion_now->listarProductos();
	foreach ($productos as $producto) {
		$contador = $contador + 1;
		$id_producto = $producto->getId_producto();
		if ($id_producto==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function contar_proveedores($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$proveedores = $conexion_now->listarProveedores();
	foreach ($proveedores as $proveedor) {
		$nombre_proveedor  = $proveedor->getNombre_empresa();
		if (preg_match('/'.$patron.'/',$nombre_proveedor)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_proveedor($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$proveedores = $conexion_now->listarProveedores();
	foreach ($proveedores as $proveedor) {
		$contador = $contador + 1;
		$id_proveedor = $proveedor->getId_proveedor();
		if ($id_proveedor==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function contar_usuarios($patron) {
	$contador = "0";
	$conexion_now = new Conexion();
	$usuarios = $conexion_now->listarUsuarios();
	foreach ($usuarios as $usuario) {
		$nombre_usuario  = $usuario->getNombre();
		if (preg_match('/'.$patron.'/',$nombre_usuario)) {
			$contador = $contador + 1;
		}
	}
	unset($conexion_now);
	return $contador;
}

function buscar_posicion_usuario($patron) {
	$contador = "-1";
	$posicion = "0";
	$conexion_now = new Conexion();
	$usuarios = $conexion_now->listarUsuarios();
	foreach ($usuarios as $usuario) {
		$contador = $contador + 1;
		$id_usuario  = $usuario->getId_usuario();
		if ($id_usuario==$patron) {
			$posicion = $contador;
			break;
		}
	}
	unset($conexion_now);
	return $posicion;
}

function fecha_actual() {
	date_default_timezone_set("America/Argentina/Cordoba");
	$fecha = date("d/m/Y", time());
	return $fecha;
}

?>