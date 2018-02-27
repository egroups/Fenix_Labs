$(document).ready(function(){
	
  $("form[name='form_login']").submit(function(e) {

    var username = $("input[name='username']").val();
	var password = $("input[name='password']").val();

    if(username=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } else {
	  $("div[name='form-group-username']").addClass('has-success');
	}
		
    if(password=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } else {
		$("div[name='form-group-password']").addClass('has-success');
	}
	
  });	

  $("form[name='form_proveedores']").submit(function(e) {

    var nombre = $("input[name='nombre_empresa']").val();
  var direccion = $("input[name='direccion']").val();
  var telefono = $("input[name='telefono']").val();

    if(nombre=="") {
      $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
      $("div[name='form-group-nombre']").addClass('has-error');
    $("input[name='nombre_empresa']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-nombre']").addClass('has-success');
  }
  
    if(direccion=="") {
      $("input[name='direccion']").attr("placeholder", "Falta direccion");
      $("div[name='form-group-direccion']").addClass('has-error');
    $("input[name='direccion']").focus();
      e.preventDefault();
      return false;   
    } else {
      $("div[name='form-group-direccion']").addClass('has-success');    
  }
  
    if(telefono=="") {
      $("input[name='telefono']").attr("placeholder", "Falta telefono");
      $("div[name='form-group-telefono']").addClass('has-error');
    $("input[name='telefono']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-telefono']").addClass('has-success');
  }
  
  });
  
  $("form[name='form_productos']").submit(function(e) {

    var nombre = $("input[name='nombre_producto']").val();
  var descripcion = $("textarea[name='descripcion']").val();
  var precio = $("input[name='precio']").val();
  var proveedor = $("select[name='proveedor']").val();

    if(nombre=="") {
      $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
      $("div[name='form-group-nombre']").addClass('has-error');
    $("input[name='nombre_producto']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-nombre']").addClass('has-success');
  }
  
    if(descripcion=="") {
      $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
      $("div[name='form-group-descripcion']").addClass('has-error');
    $("textarea[name='descripcion']").focus();
      e.preventDefault();
      return false;   
    } else {
      $("div[name='form-group-descripcion']").addClass('has-success');    
  }
  
    if(precio=="") {
      $("input[name='precio']").attr("placeholder", "Falta precio");
      $("div[name='form-group-precio']").addClass('has-error');
    $("input[name='precio']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-precio']").addClass('has-success');
  }
  
    if(proveedor=="0") {
      $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
      $("div[name='form-group-proveedor']").addClass('has-error');
    $("select[name='proveedor']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-proveedor']").addClass('has-success');
  }

  });
  
  $("form[name='form_usuarios']").submit(function(e) {

    var nombre = $("input[name='nombre_usuario']").val();
  var password = $("input[name='password']").val();
  var tipo = $("select[name='tipo']").val();

    if(nombre=="") {
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
    $("input[name='nombre_usuario']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-nombre']").addClass('has-success');
  }
    
    if(password=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
    $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-password']").addClass('has-success');
  }
  
    if(tipo=="0") {
      $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
      $("div[name='form-group-tipo']").addClass('has-error');
    $("select[name='tipo']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-tipo']").addClass('has-success');
  }

  });
  
  $("form[name='form_usuarios_editar']").submit(function(e) {

    var nombre = $("input[name='nombre_usuario']").val();
  var tipo = $("select[name='tipo']").val();

    if(nombre=="") {
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
    $("input[name='nombre_usuario']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-nombre']").addClass('has-success');
  }
      
    if(tipo=="0") {
      $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
      $("div[name='form-group-tipo']").addClass('has-error');
    $("select[name='tipo']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-tipo']").addClass('has-success');
  }

  });
  
  $("form[name='form_cambiar_usuario']").submit(function(e) {

    var username = $("input[name='username']").val();
  var new_username = $("input[name='new_username']").val();
  var password = $("input[name='password']").val();

    if(username=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
    $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-username']").addClass('has-success');
  }
  
    if(new_username=="") {
      $("input[name='new_username']").attr("placeholder", "Falta nuevo usuario");
      $("div[name='form-group-new-username']").addClass('has-error');
    $("input[name='new_username']").focus();
      e.preventDefault();
      return false;   
    } else {
      $("div[name='form-group-new-username']").addClass('has-success');   
  }
  
    if(password=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
    $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-password']").addClass('has-success');
  }
  
  });
  
  $("form[name='form_cambiar_password']").submit(function(e) {

    var username = $("input[name='username']").val();
  var anterior_password = $("input[name='anterior_password']").val();
  var new_password = $("input[name='new_password']").val();

    if(username=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
    $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-username']").addClass('has-success');
  }
  
    if(anterior_password=="") {
      $("input[name='anterior_password']").attr("placeholder", "Falta contraseña actual");
      $("div[name='form-group-anterior-password']").addClass('has-error');
    $("input[name='anterior_password']").focus();
      e.preventDefault();
      return false;   
    } else {
      $("div[name='form-group-anterior-password']").addClass('has-success');    
  }
  
    if(new_password=="") {
      $("input[name='new_password']").attr("placeholder", "Falta nueva contraseña");
      $("div[name='form-group-new-password']").addClass('has-error');
    $("input[name='new-password']").focus();
      e.preventDefault();
      return false;   
    } else {
    $("div[name='form-group-new-password']").addClass('has-success');
  }
  
  });
	
});