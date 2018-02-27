// App V2

$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();
});

$(document).ready(function(){

	$("form[name='form_login']").submit(function(e) {

	var usuario = $("input[name='usuario']").val();
	var clave = $("input[name='clave']").val();

	if(usuario != "" && clave != "") {

		var idata;

		$.ajax({
		type: 'POST',
		url: "includes/ABM.php",
		data: {'tipo' : 'ingresoUsuario','usuario' : usuario,'clave' : clave},
		dataType: 'json',
		async: false,
		success: function(result){idata = result;}
		});

		var respuesta = idata["message"];

		if(respuesta=="1") {

		var idata2;
		$.ajax({
		  type: 'POST',
		  url: "includes/ABM.php",
		  data: {'tipo' : 'comprobarTipoUsuario','usuario' : usuario},
		  dataType: 'json',
		  async: false,
		  success: function(result){idata2 = result;}
		});

		var tipo_usuario = idata2["message"];

		swal({
				title: "Iniciar sesión",
				text: "Bienvenido "+ tipo_usuario + " " + usuario + " a la administración",
				type:"success",
				html:true,
				animation: false
		 },function() {
			window.location.href = "administracion.php";  
		 });

		} else {

		  swal({
		    title: 'Iniciar sesión',
		    text: "Login incorrecto",
		    type:'warning',
		    html:true,
		    animation: false
		  });

		}

	} else {

		swal({
			title: 'Iniciar sesión',
			text: "Faltan datos",
			type:'warning',
			html:true,
			animation: false
		});
	}

	$("input[name='usuario']").val("");
	$("input[name='clave']").val("");

	e.preventDefault();
	return false; 
	
  });	
	  
  $(document).on('click', '#agregar_producto', function(e){ 

	var nombre = $("input[name='nombre']").val();
	var descripcion = $("textarea[name='descripcion']").val();
	var precio = $("input[name='precio']").val();
	var id_proveedor = $("select[name='proveedor']").val();

	$.post('includes/ABM.php',{tipo:'agregarProducto',nombre:nombre,descripcion:descripcion,precio:precio,id_proveedor:id_proveedor}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_agregar_producto').modal('hide'); 
	  recargarListaProductos();
	});

	e.preventDefault();
	return false; 

  });

  $(document).on('click', '#editar_producto', function(e){ 

	var id = $("input[name='id']").val();
	var nombre = $("input[name='nombre']").val();
	var descripcion = $("textarea[name='descripcion']").val();
	var precio = $("input[name='precio']").val();
	var id_proveedor = $("select[name='proveedor']").val();

	$.post('includes/ABM.php',{tipo:'editarProducto',id:id,nombre:nombre,descripcion:descripcion,precio:precio,id_proveedor:id_proveedor}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_editar_producto').modal('hide'); 
	  recargarListaProductos();
	});

	e.preventDefault();
	return false; 

  });
  
  $(document).on('click', '#agregar_proveedor', function(e){ 

	var nombre = $("input[name='nombre']").val();
	var direccion = $("input[name='direccion']").val();
	var telefono = $("input[name='telefono']").val();

	$.post('includes/ABM.php',{tipo:'agregarProveedor',nombre:nombre,direccion:direccion,telefono:telefono}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_agregar_proveedor').modal('hide'); 
	  recargarListaProveedores();
	});

	e.preventDefault();
	return false; 

  });

  $(document).on('click', '#editar_proveedor', function(e){ 
		
	var id = $("input[name='id']").val();
	var nombre = $("input[name='nombre']").val();
	var direccion = $("input[name='direccion']").val();
	var telefono = $("input[name='telefono']").val();

	$.post("includes/ABM.php",{tipo:"editarProveedor",id:id,nombre:nombre,direccion:direccion,telefono:telefono}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_editar_proveedor').modal('hide'); 
	  recargarListaProveedores();
	});

	e.preventDefault();
	return false; 

  });
  
  $(document).on('click', '#agregar_usuario', function(e){ 

	var nombre = $("input[name='nombre']").val();
	var clave = $("input[name='clave']").val();
	var id_tipo = $("select[name='tipo']").val();

	$.post("includes/ABM.php",{tipo:"agregarUsuario",nombre:nombre,clave:clave,id_tipo:id_tipo}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_agregar_usuario').modal('hide'); 
	  recargarListaUsuarios();
	});

	e.preventDefault();
	return false; 

  });
    
  $(document).on('click', '#editar_usuario', function(e){ 

	var id = $("input[name='id']").val();
	var nombre_ = $("input[name='nombre']").val();
	var id_tipo = $("select[name='tipo']").val();

	$.post("includes/ABM.php",{tipo:"editarUsuario",id:id,id_tipo:id_tipo}, function(mensaje) {
	  $("#respuesta").html(mensaje);
	  $('#modal_editar_usuario').modal('hide'); 
	  recargarListaUsuarios();
	});

	e.preventDefault();
	return false; 

  });

  $(document).on('click', '#cambiar_usuario', function(e){ 

	var usuario = $("input[name='usuario']").val();
	var nuevo_usuario = $("input[name='nuevo_usuario']").val();
	var clave = $("input[name='clave']").val();

	$.post("includes/ABM.php",{tipo:"cambiarUsuario",usuario:usuario,nuevo_usuario:nuevo_usuario,clave:clave}, function(mensaje) {
		
		$("#respuesta").html(mensaje);

		$("input[name='nuevo_usuario']").val('');
		$("input[name='clave']").val('');

	});

	e.preventDefault();
	return false; 		
		
  });
  
  $(document).on('click', '#cambiar_clave', function(e){ 

	var usuario = $("input[name='usuario']").val();
	var clave = $("input[name='clave']").val();
	var nueva_clave = $("input[name='nueva_clave']").val();
	
	$.post("includes/ABM.php",{tipo:"cambiarClave",usuario:usuario,clave:clave,nueva_clave:nueva_clave}, function(mensaje) {
		 
		 $("#respuesta").html(mensaje);

		 $("input[name='clave']").val('');
		 $("input[name='nueva_clave']").val('');
		 
	});

	e.preventDefault();
	return false; 			
	
  });
    
});