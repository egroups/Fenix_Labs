<!-- Written By Ismael Heredia in the year 2017 -->

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Administracion</title>

<!-- Bootstrap -->
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link href="css/style.css" rel="stylesheet">
<script src="scripts/jquery-1.5.1.js"></script>

<script src="dist/sweetalert-dev.js"></script>
<link rel="stylesheet" href="dist/sweetalert.css">

<script>
$(document).ready(function(){

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
</script>

<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
<nav class="navbar navbar-default">
  <div class="container-fluid"> 
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#defaultNavbar1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
      <a class="navbar-brand" href="#">Administracion</a></div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="defaultNavbar1">
      <ul class="nav navbar-nav">
        <li class="active"><a href="administracion.php">Inicio<span class="sr-only">(current)</span></a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Cuenta <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
            <li><a href="?cambiar_usuario">Cambiar Usuario</a></li>
            <li><a href="?cambiar_password">Cambiar Password</a></li>
          </ul>
        </li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestionar <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
            <li><a href="?productos">Productos</a></li>
            <li><a href="?proveedores">Proveedores</a></li>
            <li><a href="?usuarios">Usuarios</a></li>
          </ul>
        </li>
        <li class="dropdown">
          <a href="?estadisticas" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Estadisticas <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
            <li><a href="#">Action</a></li>
            <li><a href="#">Another action</a></li>
          </ul>
        </li>
      </ul>
	  <ul class="nav navbar-nav navbar-right">
        <li><a href="?logout">Salir</a></li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>
<div class="container-fluid">
  <div class="row">
    <div class="col-md-6 col-md-offset-3">
      <h1 class="text-center">Administracion</h1>
    </div>
  </div>
  <hr>
<?php

error_reporting(1);
	
include_once("includes/Proveedores.php");
include_once("includes/Productos.php");
include_once("includes/Usuarios.php");
include_once("includes/Conexion.php");
include_once("includes/Funciones.php");
include_once("includes/Busqueda.php");
include_once("includes/ABM.php");
include_once("includes/Cliente.php");

$conexion_now = new Conexion();
$cliente_now = new Cliente();
    
if (isset($_GET["proveedores"])) {
    
    cargarBuscadorProveedores();
	
	echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Agregar Proveedor</div>
  <div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_proveedor">Agregar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
	';
		
} else if(isset($_GET["editar_proveedor"])) {

    cargarBuscadorProveedores();
    
	$id_proveedor = $_GET["editar_proveedor"];
	
	if(!is_numeric($id_proveedor)) {
		mensaje("Proveedores","ID invalido","warning","?proveedores");
	} else {
	
    $proveedor = $cliente_now->cargarProveedor($id_proveedor);
		
		$id_proveedor = $proveedor->id_proveedor;
		$nombre_proveedor = $proveedor->nombre_empresa;
		$direccion = $proveedor->direccion;
		$telefono = $proveedor->telefono;
		
		echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Editando al proveedor '.htmlentities($nombre_proveedor).'</div>
  <div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	<input type="hidden" name="id_proveedor" value="' . htmlentities($id_proveedor) . '"> 
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa" value="'.htmlentities($nombre_proveedor).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion" value="'.htmlentities($direccion).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono" value="'.htmlentities($telefono).'">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="editar_proveedor" onclick="return validar_formulario_proveedores();">Editar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
		';
			
	}
    
} else if (isset($_GET["productos"])) {
    
    cargarBuscadorProductos();
	
	
	echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Agregar Producto</div>
  <div class="panel-body">
	<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto">
		  </div>
		</div>
		<div class="form-group" name="form-group-descripcion">
		  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
		  <div class="col-lg-10">
			<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion"></textarea>
		  </div>
		</div>
		<div class="form-group" name="form-group-precio">
		  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio">
		  </div>
		</div>
		<div class="form-group" name="form-group-proveedor">
		  <label for="select" class="col-lg-2 control-label">Proveedor</label>
		  <div class="col-lg-10">
			<select class="form-control" id="select" name="proveedor">
		';
			
		$proveedores = $cliente_now->listarProveedores();
    $cantidad_proveedores = count($proveedores);
		
		if ($cantidad_proveedores == 0) {
			echo '<option value="null">No se encontraron proveedores</option>';
		} else {
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->id_proveedor;
				$nombre_empresa = $proveedor->nombre_empresa;
				echo '<option value="' . htmlentities($id_proveedor) . '">' . htmlentities($nombre_empresa) . '</option>';
			}
		}

		echo '</select>
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_producto" onclick="return validar_formulario_productos();">Agregar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
		';
	        
} else if(isset($_GET["editar_producto"])) {

  cargarBuscadorProductos();

	$id_producto = $_GET["editar_producto"];
	
	if(!is_numeric($id_producto)) {
		mensaje("Productos","ID invalido","warning","?productos");
	} else {
	
		$producto = $cliente_now->cargarProducto($id_producto);
		
		$id_producto = $producto->id_producto;
		$nombre_producto = $producto->nombre_producto;
		$descripcion = $producto->descripcion;
		$precio = $producto->precio;
		$id_proveedor_real = $producto->id_proveedor;

		echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Editando al producto '.htmlentities($nombre_producto).'</div>
  <div class="panel-body">
	<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
	<input type="hidden" name="id_producto" value="' . htmlentities($id_producto) . '">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto" value="'.htmlentities($nombre_producto).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-descripcion">
		  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
		  <div class="col-lg-10">
			<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion">'.htmlentities($descripcion).'</textarea>
		  </div>
		</div>
		<div class="form-group" name="form-group-precio">
		  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio" value="'.htmlentities($precio).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-proveedor">
		  <label for="select" class="col-lg-2 control-label">Proveedor</label>
		  <div class="col-lg-10">
			<select class="form-control" id="select" name="proveedor">
		';
			
    $proveedores = $cliente_now->listarProveedores();
    $cantidad_proveedores = count($proveedores);
		
		if ($cantidad_proveedores == 0) {
			echo '<option value="null">No se encontraron proveedores</option>';
		} else {
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->id_proveedor;
				$nombre_empresa = $proveedor->nombre_empresa;
				if($id_proveedor_real==$id_proveedor) {
					echo '<option value="' . htmlentities($id_proveedor) . '" selected="true">' . htmlentities($nombre_empresa) . '</option>';
				} else {
					echo '<option value="' . htmlentities($id_proveedor) . '">' . htmlentities($nombre_empresa) . '</option>';
				}
			}
		}

		echo '</select>
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="editar_producto" onclick="return validar_formulario_productos();">Editar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
		';
			
	}

} else if (isset($_GET["usuarios"])) {
        
	cargarBuscadorUsuarios();
	
	echo '
<div class="panel contenedor panel-default">
<div class="panel-heading">Agregar usuario</div>
<div class="panel-body">
<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
  <fieldset>
	<legend>Datos</legend>
	<div class="form-group" name="form-group-nombre">
	  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
	  <div class="col-lg-10">
		<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario">
	  </div>
	</div>
	<div class="form-group" name="form-group-password">
	  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
	  <div class="col-lg-10">
		<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password">
	  </div>
	</div>
	<div class="form-group" name="form-group-tipo">
	  <label for="select" class="col-lg-2 control-label">Tipo</label>
	  <div class="col-lg-10">
		<select class="form-control" id="select" name="tipo">
			<option value="2">Usuario</option>
			<option value="1">Administrador</option>
		</select>
	  </div>
	</div>
	<div class="form-group">
		<button type="submit" class="btn btn-primary center-block" name="agregar_usuario" onclick="return validar_formulario_usuarios();">Agregar</button>
	</div>
  </fieldset>
</form>        
</div>
</div>
	';
					                        
} else if (isset($_GET["editar_usuario"])) {

	cargarBuscadorUsuarios();
	
	$id_usuario = $_GET["editar_usuario"];

	if(!is_numeric($id_usuario)) {
		mensaje("Usuarios","ID invalido","warning","?usuarios");
	} else {

		$usuario = $cliente_now->cargarUsuario($id_usuario);
		
		$id_usuario = $usuario->id_usuario;
		$nombre_usuario = $usuario->usuario;
		$clave = $usuario->clave;
		$tipo = $usuario->tipo;
		
		echo '
<div class="panel contenedor panel-default">
<div class="panel-heading">Editar al usuario '.htmlentities($nombre_usuario).'</div>
<div class="panel-body">
<form action="?usuarios" method="POST" name="form_usuarios_editar" class="form-horizontal">
<input type="hidden" name="id_usuario" value="' . htmlentities($id_usuario) . '">
  <fieldset>
	<legend>Datos</legend>
	<div class="form-group" name="form-group-nombre">
	  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
	  <div class="col-lg-10">
		<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario" value="'.htmlentities($nombre_usuario).'" readonly="readonly">
	  </div>
	</div>
	<div class="form-group" name="form-group-password">
	  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
	  <div class="col-lg-10">
		<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" readonly="readonly">
	  </div>
	</div>
	<div class="form-group" name="form-group-tipo">
	  <label for="select" class="col-lg-2 control-label">Tipo</label>
	  <div class="col-lg-10">
		<select class="form-control" id="select" name="tipo">
	';
	if($tipo=="2") {
		echo '<option value="2" selected="true">Usuario</option>';
	} else {
		echo '<option value="2">Usuario</option>';
	}
	
	if($tipo=="1") {
		echo '<option value="1" selected="true">Administrador</option>';
	} else {
		echo '<option value="1">Administrador</option>';
	}
		echo '</select>
	  </div>
	</div>
	<div class="form-group">
		<button type="submit" class="btn btn-primary center-block" name="editar_usuario" onclick="return validar_formulario_usuarios();">Editar</button>
	</div>
  </fieldset>
</form>        
</div>
</div>
		';
            			
	}
        
} elseif (isset($_POST["cambiar_user"])) {
    
    $username     = $_POST["username"];
    $new_username = $_POST["new_username"];
    $password     = $_POST["password"];
    
    $ruta = "administracion.php?cambiar_usuario";
    
    if ($username == "" || $new_username == "" || $password == "") {
		mensaje("Cambiar Usuario","Faltan datos para cambiar el nombre de usuario","warning",$ruta);
    } else {
        $password_encoded = md5($password);
        if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
            
            if ($conexion_now->EjecutarConsulta("update usuarios set usuario='" . $new_username . "' where usuario='" . $username . "'")) {
                cambiar_usuario_y_cerrar_sesion();
            } else {
				mensaje("Cambiar Usuario","Ha ocurrido un error cambiando el nombre de usuario","error",$ruta);
            }
        } else {
			mensaje("Cambiar Usuario","La contraseña no coincide","warning",$ruta);
        }
    }
    
} else if (isset($_GET["cambiar_usuario"])) {
     
		echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Cambiar Usuario</div>
  <div class="panel-body">
	<form action="?cambiar_usuario" method="POST" name="form_cambiar_usuario" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-username">
		  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-new-username">
		  <label for="inputNuevo" class="col-lg-2 control-label">Nuevo usuario</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNuevoUsuario" placeholder="Ingrese nuevo usuario" type="text" name="new_username">
		  </div>
		</div>
		<div class="form-group" name="form-group-password">
		  <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="cambiar_user" onclick="return validar_formulario_cambiar_usuario();">Cambiar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
		';
	                
} else if (isset($_POST["cambiar_pass"])) {
    
    $username = $_POST["username"];
    $old_pass = $_POST["anterior_password"];
    $new_pass = $_POST["new_password"];
    
    $ruta = "administracion.php?cambiar_password";
    
    if ($username == "" || $old_pass == "" || $new_pass == "") {
		mensaje("Cambiar Password","Faltan datos para cambiar la contraseña","warning",$ruta);
    } else {
        $password_encoded = md5($old_pass);
        $new_pass_encoded = md5($new_pass);
        if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
            
            if ($conexion_now->EjecutarConsulta("update usuarios set clave='" . $new_pass_encoded . "' where usuario='" . $username . "'")) {
                cambiar_password_y_cerrar_sesion();
            } else {
				mensaje("Cambiar Password","Ha ocurrido un error cambiando la contraseña","error",$ruta);
            }
        } else {
			mensaje("Cambiar Password","La contraseña antigua no coincide","warning",$ruta);
        }
    }
    
} else if (isset($_GET["cambiar_password"])) {

	echo '
<div class="panel contenedor panel-default">
  <div class="panel-heading">Cambiar Contraseña</div>
  <div class="panel-body">
	<form action="?cambiar_password" method="POST" name="form_cambiar_password" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-username">
		  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-anterior-password">
		  <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputAnterior" placeholder="Ingrese password" type="password" name="anterior_password">
		  </div>
		</div>
		<div class="form-group" name="form-group-new-password">
		  <label for="inputActual" class="col-lg-2 control-label">Nueva contraseña</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNuevo" placeholder="Ingrese nuevo password" type="password" name="new_password">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="cambiar_pass" onclick="return validar_formulario_cambiar_password();">Cambiar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
	';
                    
} else if (isset($_GET["estadisticas"])) {
    //
} else {
    echo "<center><h1><font color='white'>Bienvenido a la administración</font></h1></center><br>";
}
    
unset($conexion_now);

?>
  <br>
  <hr>
</div>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
<script src="bootstrap/js/jquery-1.11.2.min.js"></script>

<!-- Include all compiled plugins (below), or include individual files as needed --> 
<script src="bootstrap/js/bootstrap.js"></script>

<div class="row">
  <div class="text-center col-md-6 col-md-offset-3">
    <h4>Footer </h4>
    <p>Copyright &copy; 2015 &middot; All Rights Reserved &middot; <a href="http://yourwebsite.com/" >My Website</a></p>
  </div>
</div>
</body>
</html>
