
function getUsername() {

  var usuario;
  
  $.ajax({
    type: 'POST',
    url: "includes/ABM.php",
    data: {'type' : 'getUsernameCookie'},
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

		var username = getUsername();

	    var idata;
	    $.ajax({
	      type: 'POST',
	      url: "includes/ABM.php",
	      data: {'type' : 'checkTipoUsuario','username' : username},
	      dataType: 'json',
	      async: false,
	      success: function(result){idata = result;}
	    });

	    var tipo_usuario = idata["message"];

	    var contenido = "<h1><center>Bienvenido "+ tipo_usuario + " " + username + " a la administracion</center></h1>";

	    $("#contenido").html(contenido);
	
	} 

}

function limpiarFormProductos() {
    $("input[name='nombre_producto']").val("");
	$("textarea[name='descripcion']").val("");
	$("input[name='precio']").val("");
	$("select[name='proveedor']").val("1");
	$("div[name='form-group-nombre']").removeClass('has-success');
	$("div[name='form-group-descripcion']").removeClass('has-success');
	$("div[name='form-group-precio']").removeClass('has-success');
	$("div[name='form-group-proveedor']").removeClass('has-success');
	$("div[name='form-group-nombre']").removeClass('has-error');
	$("div[name='form-group-descripcion']").removeClass('has-error');
	$("div[name='form-group-precio']").removeClass('has-error');
	$("div[name='form-group-proveedor']").removeClass('has-error'); 
	$.get("includes/BuscadorProductos.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("includes/BusquedaProductos.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function limpiarFormProveedores() {
    $("input[name='nombre_empresa']").val("");
	$("input[name='direccion']").val("");
	$("input[name='telefono']").val("");
    $("div[name='form-group-nombre']").removeClass('has-success');
    $("div[name='form-group-direccion']").removeClass('has-success');
    $("div[name='form-group-telefono']").removeClass('has-success');
    $("div[name='form-group-nombre']").removeClass('has-error');
    $("div[name='form-group-direccion']").removeClass('has-error');
    $("div[name='form-group-telefono']").removeClass('has-error');
	$.get( "includes/BuscadorProveedores.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("includes/BusquedaProveedores.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function limpiarFormUsuarios() {
    $("input[name='nombre_usuario']").val("");
	$("input[name='password']").val("");
	$("select[name='tipo']").val("1");
    $("div[name='form-group-nombre']").removeClass('has-success');
    $("div[name='form-group-password']").removeClass('has-success');
    $("div[name='form-group-tipo']").removeClass('has-success');
    $("div[name='form-group-nombre']").removeClass('has-error');
    $("div[name='form-group-password']").removeClass('has-error');
    $("div[name='form-group-tipo']").removeClass('has-error');
	$.get( "includes/BuscadorUsuarios.php", function(data1) {
		$("#busqueda").html(data1);
	}); 
	$.post("includes/BusquedaUsuarios.php",{nombre_buscar:""}, function(data2) {
		$("#tabla").html(data2);
	}); 
}

function recargarFormProductos() {
	$.get( "includes/FormAgregarProducto.php", function(data) {
		$("#contenido").html(data);
	}); 	
}

function recargarFormProveedores() {
	$.get( "includes/FormAgregarProveedor.php", function(data) {
		$("#contenido").html(data);
	}); 	
}

function recargarFormUsuarios() {
	$.get( "includes/FormAgregarUsuario.php", function(data) {
		$("#contenido").html(data);
	}); 	
}

$(document).ready(function(){
  $("a[name='logout']").click(function(e) {  
   	e.preventDefault();

    var idata;
    $.ajax({
      type: 'POST',
      url: "includes/ABM.php",
      data: {'type' : 'cerrarSesion'},
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

$(document).ready(function(){


  $("form[name='form_login']").submit(function(e) {

    var username = $("input[name='username']").val();
	var password = $("input[name='password']").val();

    var form_ready = true;

    if(username=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
      form_ready = false;  
    } else {
     $("div[name='form-group-username']").removeClass('has-error');
	 $("div[name='form-group-username']").addClass('has-success');
     $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
	  }
		
    if(password=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
	    $("input[name='password']").focus();
      form_ready = false;  
    } else {
      $("div[name='form-group-password']").removeClass('has-error');
	  $("div[name='form-group-password']").addClass('has-success');
      $("input[name='password']").attr("placeholder", "Ingrese password");
	}

    if(form_ready==true) {

      var idata;
      
      $.ajax({
        type: 'POST',
        url: "includes/ABM.php",
        data: {'type' : 'ingresoUsuario','username' : username,'password' : password},
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
          data: {'type' : 'checkTipoUsuario','username' : username},
          dataType: 'json',
          async: false,
          success: function(result){idata2 = result;}
        });

        var tipo_usuario = idata2["message"];
        
		swal({
				title: "Iniciar sesion",
				text: "Bienvenido "+ tipo_usuario + " " + username + " a la administracion",
				type:"success",
				html:true,
				animation: false
		 },function() {
			window.location.href = "administracion.php";  
		 });

      } else {

          swal({
            title: 'Iniciar sesion',
            text: "Login incorrecto",
            type:'warning',
            html:true,
            animation: false
          });

      }

      $("div[name='form-group-username']").removeClass('has-success');
      $("div[name='form-group-password']").removeClass('has-success');

      $("input[name='username']").val("");
      $("input[name='password']").val("");

      e.preventDefault();
      return false; 

    } else {
      e.preventDefault();
      return false;       
    }
	
  });	
	
});

$(document).ready(function(){
    
  $("a[name='inicio']").click(function(e) {  
   	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");
	generarBienvenida();
  });
  
  $("a[name='productos']").click(function(e) {  
   	e.preventDefault();
	$.get( "includes/BuscadorProductos.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$("#tabla").html("");
	$.get( "includes/FormAgregarProducto.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });
  		  
  $("a[name='proveedores']").click(function(e) {  
  	e.preventDefault();
	$.get( "includes/BuscadorProveedores.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$("#tabla").html("");
	$.get( "includes/FormAgregarProveedor.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });
  
  $("a[name='usuarios']").click(function(e) {  
  	e.preventDefault();
	$.get( "includes/BuscadorUsuarios.php", function(mensaje) {
		$("#busqueda").html(mensaje);
	}); 
	$("#tabla").html("");
	$.get( "includes/FormAgregarUsuario.php", function(mensaje) {
		$("#contenido").html(mensaje);
	});
  });
  
  $("a[name='cambiar_usuario']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");
	$.get( "includes/FormCambiarUsuario.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });
  
  $("a[name='cambiar_password']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");
	$.get( "includes/FormCambiarPassword.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 
  });

  $("a[name='estadisticas']").click(function(e) {  
  	e.preventDefault();
	$("#contenido").html("");
	$("#busqueda").html("");
	$("#tabla").html("");
	$("#respuesta").html("");

	$.get( "includes/Estadisticas.php", function(mensaje) {
		$("#contenido").html(mensaje);
	}); 

  });
  		  
  $(document).on('click', '#buscar_productos', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("includes/BusquedaProductos.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 	
  });
  
  $(document).on('click', '#buscar_proveedores', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("includes/BusquedaProveedores.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 
  });
  
  $(document).on('click', '#buscar_usuarios', function(e){ 
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
	  $.post("includes/BusquedaUsuarios.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#tabla").html(mensaje);
	  }); 
  });

  $(document).on('click', '#cancelar_producto', function(e){ 
   	e.preventDefault();
	limpiarFormProductos();
	recargarFormProductos(); 
  });	

  $(document).on('click', '#cancelar_proveedor', function(e){ 
   	e.preventDefault();
	limpiarFormProveedores();
	recargarFormProveedores();
  });

  $(document).on('click', '#cancelar_usuario', function(e){ 
   	e.preventDefault();
	limpiarFormUsuarios();
	recargarFormUsuarios();
  });	  
  
  $(document).on('click', 'a', function(e){ 
	e.preventDefault();
	var url = this.href;
	var split_string = url.indexOf('='); 
	var id = url.substring(split_string + 1); 
	if (url.toLowerCase().indexOf("editar_producto") >= 0) {
	  $.post("includes/FormEditarProducto.php",{editar_producto:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_producto") >= 0) {
	  $.post("includes/ABM.php",{borrar_producto:id}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProductos();
		  recargarFormProductos();
	  });
	}
	if (url.toLowerCase().indexOf("editar_proveedor") >= 0) {
	  $.post("includes/FormEditarProveedor.php",{editar_proveedor:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_proveedor") >= 0) {
	  $.post("includes/ABM.php",{borrar_proveedor:id}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProveedores();
		  recargarFormProveedores();
	  }); 
	}
	if (url.toLowerCase().indexOf("editar_usuario") >= 0) {
	  $.post("includes/FormEditarUsuario.php",{editar_usuario:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
	  }); 
	} 
	if (url.toLowerCase().indexOf("borrar_usuario") >= 0) {
	  $.post("includes/ABM.php",{borrar_usuario:id}, function(mensaje) {
		  $("#respuesta").html(mensaje);
	      limpiarFormUsuarios();
	      recargarFormUsuarios();
	  });  
	} 
 
  });
  
  $(document).on('click', '#agregar_producto', function(e){ 

	var nombre_check = $("input[name='nombre_producto']").val();
	var descripcion_check = $("textarea[name='descripcion']").val();
	var precio_check = $("input[name='precio']").val();
	var proveedor_check = $("select[name='proveedor']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
	  $("div[name='form-group-nombre']").removeClass('has-success');
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_producto']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-nombre']").removeClass('has-error');
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("input[name='nombre_producto']").attr("placeholder", "Ingrese nombre de producto");
	}

	if(descripcion_check=="") {
	  $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
	  $("div[name='form-group-descripcion']").removeClass('has-success');
	  $("div[name='form-group-descripcion']").addClass('has-error');
	  $("textarea[name='descripcion']").focus(); 
	  form_ready = false;	
	} else {
	  $("div[name='form-group-descripcion']").removeClass('has-error');
	  $("div[name='form-group-descripcion']").addClass('has-success');
	  $("textarea[name='descripcion']").attr("placeholder", "Ingrese descripcion");
	}

	if(precio_check=="") {
	  $("input[name='precio']").attr("placeholder", "Falta precio");
	  $("div[name='form-group-precio']").removeClass('has-success');
	  $("div[name='form-group-precio']").addClass('has-error');
	  $("input[name='precio']").focus();  
	  form_ready = false;
	} else {
	  $("div[name='form-group-precio']").removeClass('has-error');
	  $("div[name='form-group-precio']").addClass('has-success');
	  $("input[name='precio']").attr("placeholder", "Ingrese precio");
	}

	if(proveedor_check=="0") {
	  $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
	  $("div[name='form-group-proveedor']").removeClass('has-success');
	  $("div[name='form-group-proveedor']").addClass('has-error');
	  $("select[name='proveedor']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-proveedor']").removeClass('has-error');
	  $("div[name='form-group-proveedor']").addClass('has-success');
	}

	if(form_ready==true) {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-descripcion']").addClass('has-success');
	  $("div[name='form-group-precio']").addClass('has-success');
	  $("div[name='form-group-proveedor']").addClass('has-success');
	  $.post("includes/ABM.php",{agregar_producto:"",nombre_producto:nombre_check,descripcion:descripcion_check,precio:precio_check,proveedor:proveedor_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProductos();
	  });
	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false;   
	}
  });
  
  $(document).on('click', '#agregar_proveedor', function(e){ 

	var nombre_check = $("input[name='nombre_empresa']").val();
	var direccion_check = $("input[name='direccion']").val();
	var telefono_check = $("input[name='telefono']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_empresa']").focus(); 
	  form_ready = false;
	}  else {
	  $("div[name='form-group-nombre']").removeClass('has-error');	
	  $("div[name='form-group-nombre']").addClass('has-success');
	}
	if(direccion_check=="") {
	  $("input[name='direccion']").attr("placeholder", "Falta direccion");
	  $("div[name='form-group-direccion']").addClass('has-error');
	  $("input[name='direccion']").focus(); 
	  form_ready = false;
	} else {
	  $("div[name='form-group-direccion']").removeClass('has-error');
	  $("div[name='form-group-direccion']").addClass('has-success');
	  $("input[name='direccion']").attr("placeholder", "Ingrese direccion");
	}
	if(telefono_check=="") {
	  $("input[name='telefono']").attr("placeholder", "Falta telefono");
	  $("div[name='form-group-telefono']").addClass('has-error');
	  $("input[name='telefono']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-telefono']").removeClass('has-error');
	  $("div[name='form-group-telefono']").addClass('has-success');
	  $("input[name='telefono']").attr("placeholder", "Ingrese telefono");
	}

	if(form_ready==true) {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-direccion']").addClass('has-success');
	  $("div[name='form-group-telefono']").addClass('has-success');
	  $.post("includes/ABM.php",{agregar_proveedor:"",nombre_empresa:nombre_check,direccion:direccion_check,telefono:telefono_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProveedores();
	  });
	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false; 				
	}
  });
  
  $(document).on('click', '#agregar_usuario', function(e){ 

	var nombre_check = $("input[name='nombre_usuario']").val();
	var password_check = $("input[name='password']").val();
	var tipo_check = $("select[name='tipo']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_usuario']").focus(); 
	  form_ready = false;
	} else {
	  $("div[name='form-group-nombre']").removeClass('has-error');
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("input[name='nombre_usuario']").attr("placeholder", "Ingrese nombre de usuario");
	}
	if(password_check=="") {
	  $("input[name='password']").attr("placeholder", "Falta password");
	  $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus(); 
	  form_ready = false;
	} else {
	  $("div[name='form-group-password']").removeClass('has-error');
	  $("div[name='form-group-password']").addClass('has-success');
	  $("input[name='password']").attr("placeholder", "Ingrese password");
	}
	if(tipo_check=="0") {
	  $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
	  $("div[name='form-group-tipo']").addClass('has-error');
	  $("select[name='tipo']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-tipo']").removeClass('has-error');
	  $("div[name='form-group-tipo']").addClass('has-success');				
	}

	if(form_ready==true) {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-password']").addClass('has-success');
	  $("div[name='form-group-tipo']").addClass('has-success');
	  $.post("includes/ABM.php",{agregar_usuario:"",nombre_usuario:nombre_check,password:password_check,tipo:tipo_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormUsuarios();
	  });
	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false; 
	}
  });
  
  $(document).on('click', '#editar_producto', function(e){ 

	var id_producto_check = $("input[name='id_producto']").val();
	var nombre_check = $("input[name='nombre_producto']").val();
	var descripcion_check = $("textarea[name='descripcion']").val();
	var precio_check = $("input[name='precio']").val();
	var proveedor_check = $("select[name='proveedor']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
	  $("div[name='form-group-nombre']").removeClass('has-success');
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_producto']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-nombre']").removeClass('has-error');
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("input[name='nombre_producto']").attr("placeholder", "Ingrese nombre de producto");
	}

	if(descripcion_check=="") {
	  $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
	  $("div[name='form-group-descripcion']").removeClass('has-success');
	  $("div[name='form-group-descripcion']").addClass('has-error');
	  $("textarea[name='descripcion']").focus(); 
	  form_ready = false;	
	} else {
	  $("div[name='form-group-descripcion']").removeClass('has-error');
	  $("div[name='form-group-descripcion']").addClass('has-success');
	  $("textarea[name='descripcion']").attr("placeholder", "Ingrese descripcion");
	}

	if(precio_check=="") {
	  $("input[name='precio']").attr("placeholder", "Falta precio");
	  $("div[name='form-group-precio']").removeClass('has-success');
	  $("div[name='form-group-precio']").addClass('has-error');
	  $("input[name='precio']").focus();  
	  form_ready = false;
	} else {
	  $("div[name='form-group-precio']").removeClass('has-error');
	  $("div[name='form-group-precio']").addClass('has-success');
	  $("input[name='precio']").attr("placeholder", "Ingrese precio");
	}

	if(proveedor_check=="0") {
	  $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
	  $("div[name='form-group-proveedor']").removeClass('has-success');
	  $("div[name='form-group-proveedor']").addClass('has-error');
	  $("select[name='proveedor']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-proveedor']").removeClass('has-error');
	  $("div[name='form-group-proveedor']").addClass('has-success');
	}

	if(form_ready==true) {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-descripcion']").addClass('has-success');
	  $("div[name='form-group-precio']").addClass('has-success');
	  $("div[name='form-group-proveedor']").addClass('has-success');
	  $.post("includes/ABM.php",{grabar_edicion_producto:"",id_producto:id_producto_check,nombre_producto:nombre_check,descripcion:descripcion_check,precio:precio_check,proveedor:proveedor_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProductos();
		  recargarFormProductos();
	  });
	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false; 
	}
  });
  
  $(document).on('click', '#editar_proveedor', function(e){ 
		
	var id_proveedor_check = $("input[name='id_proveedor']").val();
	var nombre_check = $("input[name='nombre_empresa']").val();
	var direccion_check = $("input[name='direccion']").val();
	var telefono_check = $("input[name='telefono']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_empresa']").focus(); 
	  form_ready = false;
	}  else {
	  $("div[name='form-group-nombre']").removeClass('has-error');	
	  $("div[name='form-group-nombre']").addClass('has-success');
	}
	if(direccion_check=="") {
	  $("input[name='direccion']").attr("placeholder", "Falta direccion");
	  $("div[name='form-group-direccion']").addClass('has-error');
	  $("input[name='direccion']").focus(); 
	  form_ready = false;
	} else {
	  $("div[name='form-group-direccion']").removeClass('has-error');
	  $("div[name='form-group-direccion']").addClass('has-success');
	  $("input[name='direccion']").attr("placeholder", "Ingrese direccion");
	}
	if(telefono_check=="") {
	  $("input[name='telefono']").attr("placeholder", "Falta telefono");
	  $("div[name='form-group-telefono']").addClass('has-error');
	  $("input[name='telefono']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-telefono']").removeClass('has-error');
	  $("div[name='form-group-telefono']").addClass('has-success');
	  $("input[name='telefono']").attr("placeholder", "Ingrese telefono");
	}

	if(form_ready==true) {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-direccion']").addClass('has-success');
	  $("div[name='form-group-telefono']").addClass('has-success');
	  $.post("includes/ABM.php",{grabar_edicion_proveedor:"",id_proveedor:id_proveedor_check,nombre_empresa:nombre_check,direccion:direccion_check,telefono:telefono_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormProveedores();
		  recargarFormProveedores();
	  });
	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false; 				
	}
  });	
  
  $(document).on('click', '#editar_usuario', function(e){ 

	var id_usuario_check = $("input[name='id_usuario']").val();
	var nombre_check = $("input[name='nombre_usuario']").val();
	var tipo_check = $("select[name='tipo']").val();

	var form_ready = true;

	if(nombre_check=="") {
	  $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
	  $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_usuario']").focus(); 
	  form_ready = false;
	} else {
	  $("div[name='form-group-nombre']").removeClass('has-error');
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("input[name='nombre_usuario']").attr("placeholder", "Ingrese nombre de usuario");
	}
	if(tipo_check=="0") {
	  $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
	  $("div[name='form-group-tipo']").addClass('has-error');
	  $("select[name='tipo']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-tipo']").removeClass('has-error');
	  $("div[name='form-group-tipo']").addClass('has-success');				
	}

	if(form_ready==true) {

	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-tipo']").addClass('has-success');

	  $.post("includes/ABM.php",{grabar_edicion_usuario:"",id_usuario:id_usuario_check,tipo:tipo_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
		  limpiarFormUsuarios();
		  recargarFormUsuarios();
	  });

	  e.preventDefault();
	  return false; 
	} else {
	  e.preventDefault();
	  return false; 				
	}
  });
  
  $(document).on('click', '#cambiar_pass', function(e){ 

	var username_check = $("input[name='username']").val();
	var anterior_password_check = $("input[name='anterior_password']").val();
	var new_password_check = $("input[name='new_password']").val();
	
	var form_ready = true;

	if(username_check=="") {
	  $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
	  $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
	  form_ready = false;
	} else {
	    $("div[name='form-group-username']").removeClass('has-error');
		$("div[name='form-group-username']").addClass('has-success');	
	    $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
	}
	
	if(anterior_password_check=="") {
	  $("input[name='anterior_password']").attr("placeholder", "Falta contraseña actual");
	  $("div[name='form-group-anterior-password']").addClass('has-error');
	  $("input[name='anterior_password']").focus();
	  form_ready = false;  
	} else {
	    $("div[name='form-group-anterior-password']").removeClass('has-error');
		$("div[name='form-group-anterior-password']").addClass('has-success');
	    $("input[name='anterior_password']").attr("placeholder", "Ingrese contraseña actual");
	}
	
	if(new_password_check=="") {
	  $("input[name='new_password']").attr("placeholder", "Falta nueva contraseña");
	  $("div[name='form-group-new-password']").addClass('has-error');
	  $("input[name='new-password']").focus();
	  form_ready = false;
	} else {
	    $("div[name='form-group-new-password']").removeClass('has-error');
		$("div[name='form-group-new-password']").addClass('has-success');
	    $("input[name='new_password']").attr("placeholder", "Ingrese nueva contraseña");
	}

	if(form_ready==true) {

		$("div[name='form-group-username']").addClass('has-success');	
		$("div[name='form-group-anterior-password']").addClass('has-success');
		$("div[name='form-group-new-password']").addClass('has-success');

		$.post("includes/ABM.php",{cambiar_pass:"",username:username_check,anterior_password:anterior_password_check,new_password:new_password_check}, function(mensaje) {
		
			$("div[name='form-group-username']").removeClass('has-success');	
			$("div[name='form-group-anterior-password']").removeClass('has-success');
			$("div[name='form-group-new-password']").removeClass('has-success');

		    $("input[name='username']").val("");
		    $("input[name='anterior_password']").val("");
			$("input[name='new-password']").val("");

		    var idata;
		    $.ajax({
		      type: 'POST',
		      url: "includes/ABM.php",
		      data: {'type' : 'cerrarSesion'},
		      dataType: 'json',
		      async: false,
		      success: function(result){idata = result;}
		    });

			 $("#respuesta").html(mensaje);
		});

		e.preventDefault();
		return false; 			
	} else {
		 e.preventDefault();
		 return false; 					
	}
	
  });
  
  $(document).on('click', '#cambiar_user', function(e){ 

	var username_check = $("input[name='username']").val();
	var new_username_check = $("input[name='new_username']").val();
	var password_check = $("input[name='password']").val();

	var form_ready = true;

	if(username_check=="") {
	  $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
	  $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-username']").removeClass('has-error');
	  $("div[name='form-group-username']").addClass('has-success');
	  $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
	}

	if(new_username_check=="") {
	  $("input[name='new_username']").attr("placeholder", "Falta nuevo usuario");
	  $("div[name='form-group-new-username']").addClass('has-error');
	  $("input[name='new_username']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-new-username']").removeClass('has-error');
	  $("div[name='form-group-new-username']").addClass('has-success');	
	  $("input[name='new_username']").attr("placeholder", "Ingrese nuevo usuario");
	}

	if(password_check=="") {
	  $("input[name='password']").attr("placeholder", "Falta password");
	  $("div[name='form-group-password']").removeClass('has-success');	
	  $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus();
	  form_ready = false;
	} else {
	  $("div[name='form-group-password']").removeClass('has-error');
	  $("div[name='form-group-password']").addClass('has-success');	
	  $("input[name='password']").attr("placeholder", "Ingrese password");
	}

	if(form_ready==true) {
		$("div[name='form-group-username']").addClass('has-success');
		$("div[name='form-group-new-username']").addClass('has-success');		
		$("div[name='form-group-password']").addClass('has-success');	

		$.post("includes/ABM.php",{cambiar_user:"",username:username_check,new_username:new_username_check,password:password_check}, function(mensaje) {
			
			$("div[name='form-group-username']").removeClass('has-success');
			$("div[name='form-group-new-username']").removeClass('has-success');		
			$("div[name='form-group-password']").removeClass('has-success');	

		    $("input[name='username']").val("");
		    $("input[name='new_username']").val("");
			$("input[name='password']").val("");

		    var idata;
		    $.ajax({
		      type: 'POST',
		      url: "includes/ABM.php",
		      data: {'type' : 'cerrarSesion'},
		      dataType: 'json',
		      async: false,
		      success: function(result){idata = result;}
		    });

			$("#respuesta").html(mensaje);
		});

		e.preventDefault();
		return false; 		
	} else {
		e.preventDefault();
		return false; 		
	}
		
  });	  
  
});