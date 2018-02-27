// Functions

function recibirUsuario() {

  var usuario;
  
  $.ajax({
    type: 'POST',
    url: "includes/ABM.php",
    data: {'tipo' : 'recibirUsuarioCookie'},
    dataType: 'json',
    async: false,
    success: function(result){idata = result;}
  });

  usuario = idata["message"];

  return usuario;

}

function generarBienvenida() {

	var url = window.location.pathname;
	var filename = url.substring(url.lastIndexOf('/')+1);

    if(filename=="administracion.php") {

		var usuario = recibirUsuario();

	    var idata;
	    $.ajax({
	      type: 'POST',
	      url: "includes/ABM.php",
	      data: {'tipo' : 'comprobarTipoUsuario','usuario' : usuario},
	      dataType: 'json',
	      async: false,
	      success: function(result){idata = result;}
	    });

	    var tipo_usuario = idata["message"];

	    var contenido = "<h1><center>Bienvenido "+ tipo_usuario + " " + usuario + " a la administración</center></h1>";

	    $("#contenido").html(contenido);
	
	} 

}

function limpiar() {
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#contenido").html("");
	$("#respuesta").html("");
}

function recargarListaProductos() {
	$.get("templates/productos/buscador.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("templates/productos/listar.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function recargarListaProveedores() {
	$.get("templates/proveedores/buscador.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("templates/proveedores/listar.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function recargarListaUsuarios() {
	$.get("templates/usuarios/buscador.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("templates/usuarios/listar.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function recargarFormProductos() {
	$.get("templates/productos/agregar.php", function(data) {
		$("#contenido").html(data);
	}); 	
}

function recargarFormProveedores() {
	$.get("templates/proveedores/agregar.php", function(data) {
		$("#contenido").html(data);
	}); 	
}

function recargarFormUsuarios() {
	$.get("templates/usuarios/agregar.php", function(data) {
		$("#contenido").html(data);
	}); 	
}