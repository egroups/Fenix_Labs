// Navigator

$(document).ready(function(){
    
  $("a[name='inicio']").click(function(e) {  
   	e.preventDefault();
   	limpiar();
	generarBienvenida();
  });
  
  $("a[name='productos']").click(function(e) {  
   	e.preventDefault();
   	limpiar();
	$.get( "templates/productos/buscador.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$.post("templates/productos/listar.php",{nombre_buscar:''}, function(mensaje) {
		$("#tabla").html(mensaje);
	}); 	
  });
  		  
  $("a[name='proveedores']").click(function(e) {  
  	e.preventDefault();
  	limpiar();
	$.get( "templates/proveedores/buscador.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$.post("templates/proveedores/listar.php",{nombre_buscar:''}, function(mensaje) {
		$("#tabla").html(mensaje);
	}); 
  });
  
  $("a[name='usuarios']").click(function(e) {  
  	e.preventDefault();
  	limpiar();
	$.get( "templates/usuarios/buscador.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$.post("templates/usuarios/listar.php",{nombre_buscar:''}, function(mensaje) {
		$("#tabla").html(mensaje);
	}); 
  });
    		  
  $(document).on('click', '#buscar_productos', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("templates/productos/listar.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 	
  });
  
  $(document).on('click', '#buscar_proveedores', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("templates/proveedores/listar.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 
  });
  
  $(document).on('click', '#buscar_usuarios', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("templates/usuarios/listar.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 
  });

  $(document).on('click', '#cargar_agregar_producto', function(e){ 
  	e.preventDefault();
	$.get( "templates/productos/agregar.php", function(mensaje) {
		$("#contenido").html(mensaje);
		$('#modal_agregar_producto').modal('show');
	}); 
  });

  $(document).on('click', '#cargar_agregar_proveedor', function(e){ 
  	e.preventDefault();
	$.get( "templates/proveedores/agregar.php", function(mensaje) {
		$("#contenido").html(mensaje);
		$('#modal_agregar_proveedor').modal('show');
	}); 
  });

  $(document).on('click', '#volver_lista_proveedores', function(e){ 
   	e.preventDefault();
	volverListaProveedores();
  });

  $(document).on('click', '#cargar_agregar_usuario', function(e){ 
  	e.preventDefault();
	$.get( "templates/usuarios/agregar.php", function(mensaje) {
		$("#contenido").html(mensaje);
		$('#modal_agregar_usuario').modal('show'); 
	}); 
  });

  $(document).on('click', '#volver_lista_usuarios', function(e){ 
   	e.preventDefault();
	volverListaUsuarios();
  });	  
  
  $(document).on('click', 'a', function(e){ 
	e.preventDefault();
	var url = this.href;
	var split_string = url.indexOf('='); 
	var id = url.substring(split_string + 1); 
	if (url.toLowerCase().indexOf("editar_producto") >= 0) {
	  $.post("templates/productos/editar.php",{editar_producto:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
		  $('#modal_editar_producto').modal('show'); 
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_producto") >= 0) {
	    swal({
	      title: "Productos",
	      text: "¿ Esta seguro de borrar el producto ?",
	      type: "warning",
	      showCancelButton: true,
	      confirmButtonColor: "#DD6B55",
	      confirmButtonText: "Borrar",
	      cancelButtonText: "Cancelar",
	      closeOnConfirm: false,
	      closeOnCancel: false
	    },
	    function(isConfirm){
			if (isConfirm) {
			  $.post("includes/ABM.php",{tipo:'borrarProducto',id:id}, function(mensaje) {
				  $("#respuesta").html(mensaje);
				  recargarListaProductos();
			  });
      		} else {
          		swal("Productos", "Borrado cancelado", "success");
			}
	    });
	}
	if (url.toLowerCase().indexOf("editar_proveedor") >= 0) {	
	  $.post("templates/proveedores/editar.php",{editar_proveedor:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
		  $('#modal_editar_proveedor').modal('show'); 
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_proveedor") >= 0) {
	    swal({
	      title: "Proveedores",
	      text: "¿ Esta seguro de borrar el proveedor ?",
	      type: "warning",
	      showCancelButton: true,
	      confirmButtonColor: "#DD6B55",
	      confirmButtonText: "Borrar",
	      cancelButtonText: "Cancelar",
	      closeOnConfirm: false,
	      closeOnCancel: false
	    },
	    function(isConfirm){
			if (isConfirm) {
			  $.post("includes/ABM.php",{tipo:'borrarProveedor',id:id}, function(mensaje) {
				  $("#respuesta").html(mensaje);
				  recargarListaProveedores();
			  });
      		} else {
          		swal("Proveedores", "Borrado cancelado", "success");
			}
	    });
	}
	if (url.toLowerCase().indexOf("editar_usuario") >= 0) {
	  $.post("templates/usuarios/editar.php",{editar_usuario:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
		  $('#modal_editar_usuario').modal('show'); 
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_usuario") >= 0) {
	    swal({
	      title: "Usuarios",
	      text: "¿ Esta seguro de borrar el usuario ?",
	      type: "warning",
	      showCancelButton: true,
	      confirmButtonColor: "#DD6B55",
	      confirmButtonText: "Borrar",
	      cancelButtonText: "Cancelar",
	      closeOnConfirm: false,
	      closeOnCancel: false
	    },
	    function(isConfirm){
			if (isConfirm) {
			  $.post("includes/ABM.php",{tipo:'borrarUsuario',id:id}, function(mensaje) {
				  $("#respuesta").html(mensaje);
				  recargarListaUsuarios();
			  });
      		} else {
          		swal("Usuarios", "Borrado cancelado", "success");
			}
	    });
	} 
  });

  $("a[name='cambiar_usuario']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");
	$.get( "templates/cuenta/cambiar_usuario.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });
  
  $("a[name='cambiar_clave']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");
	$.get( "templates/cuenta/cambiar_clave.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });

  $("a[name='estadisticas']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");

	$.get( "templates/estadisticas/reporte.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 

  });

  $("a[name='logout']").click(function(e) {  
   	e.preventDefault();

    var idata;
    $.ajax({
      type: 'POST',
      url: "includes/ABM.php",
      data: {'tipo' : 'cerrarSesion'},
      dataType: 'json',
      async: false,
      success: function(result){idata = result;}
    });

	swal({
			title: "Cerrrar sesion",
			text: "Las cookies han sido borradas",
			type:"success",
			html:true,
			animation: false
	 },function() {
		window.location.href = "index.php";  
	 });
	
  });

});