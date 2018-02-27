<!-- Written By Ismael Heredia in the year 2016 -->

<?php

if (!isset($_COOKIE['cookie_login'])) {
    $archivo = "index.php";
    echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />';
} else {	
	if (isset($_GET["logout"])) {
		if(setcookie("cookie_login", "",time()-3600,"")) {
			echo '
			<script src="dist/sweetalert-dev.js"></script>
			<link rel="stylesheet" href="dist/sweetalert.css">
			<body>
				<script>
				swal({
						title: "Cerrrar sesion",
						text: "Las cookies han sido borradas",
						type:"success",
						html:true,
						animation: false
				 },function() {
					window.location.href = "index.php";  
				 });
				</script>
			</body>
			';
		}
	}
}
?>

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
	function validar_formulario_productos() {
		if (document.form_productos.nombre_producto.value.length == 0) {
			document.getElementsByName("nombre_producto")[0].placeholder="Falta el nombre de producto";
			document.form_productos.nombre_producto.focus();
			return false;
		}
		else if (document.form_productos.descripcion.value.length == 0) {
			document.getElementsByName("descripcion")[0].placeholder="Falta la descripcion";
			document.form_productos.descripcion.focus();
			return false;
		}
		else if (document.form_productos.precio.value.length == 0) {
			document.getElementsByName("precio")[0].placeholder="Falta el precio";
			document.form_productos.precio.focus();
			return false;
		}
		else if (document.form_productos.proveedor.value.selectedIndex == -1) {
			document.form_productos.proveedor.focus();
			return false;
		} else {
			return true;
		}
	}
	
	function validar_formulario_proveedores() {
		if (document.form_proveedores.nombre_empresa.value.length == 0) {
			document.getElementsByName("nombre_empresa")[0].placeholder="Falta el nombre de empresa";
			document.form_proveedores.nombre_empresa.focus();
			return false;
		}
		else if (document.form_proveedores.direccion.value.length == 0) {
			document.getElementsByName("direccion")[0].placeholder="Falta la direccion";
			document.form_proveedores.direccion.focus();
			return false;
		}
		else if (document.form_proveedores.telefono.value.length == 0) {
			document.getElementsByName("telefono")[0].placeholder="Falta el telefono";
			document.form_proveedores.telefono.focus();
			return false;
		} else {
			return true;
		}
	}
	
	function validar_formulario_usuarios() {
		if (document.form_usuarios.nombre_usuario.value.length == 0) {
			document.getElementsByName("nombre_usuario")[0].placeholder="Falta el nombre de usuario";
			document.form_usuarios.nombre_usuario.focus();
			return false;
		}
		else if (document.form_usuarios.password.value.length == 0) {
			document.getElementsByName("password")[0].placeholder="Falta el password";
			document.form_usuarios.password.focus();
			return false;
		}
		else if (document.form_usuarios.tipo.value.selectedIndex == -1) {
			document.form_usuarios.tipo.focus();
			return false;
		} else {
			return true;
		}
	}
	
	function validar_formulario_cambiar_usuario() {
		if (document.form_cambiar_usuario.username.value.length == 0) {
			document.getElementsByName("username")[0].placeholder="Falta el usuario";
			document.form_cambiar_usuario.username.focus();
			return false;
		}
		else if (document.form_cambiar_usuario.new_username.value.length == 0) {
			document.getElementsByName("new_username")[0].placeholder="Falta el nuevo usuario";
			document.form_cambiar_usuario.new_username.focus();
			return false;
		}
		else if (document.form_cambiar_usuario.password.value.length == 0) {
			document.getElementsByName("password")[0].placeholder="Falta el password";
			document.form_cambiar_usuario.password.focus();
			return false;
		} else {
			return true;
		}
	}

	function validar_formulario_cambiar_password() {
		if (document.form_cambiar_password.username.value.length == 0) {
			document.getElementsByName("username")[0].placeholder="Falta el usuario";
			document.form_cambiar_password.username.focus();
			return false;
		}
		else if (document.form_cambiar_password.anterior_password.value.length == 0) {
			document.getElementsByName("anterior_password")[0].placeholder="Falta el password";
			document.form_cambiar_password.anterior_password.focus();
			return false;
		}
		else if (document.form_cambiar_password.new_password.value.length == 0) {
			document.getElementsByName("new_password")[0].placeholder="Falta el nuevo password";
			document.form_cambiar_password.new_password.focus();
			return false;
		} else {
			return true;
		}
	}	
	
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

$conexion_now = new Conexion();

$cortar = base64_decode($_COOKIE['cookie_login']);

$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];

if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {
    
    if (isset($_GET["proveedores"])) {
        
        cargarBuscadorProveedores();
		
    	echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Agregar Proveedor</div>
	  <div class="panel-body">
		<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" class="btn btn-primary center-block" name="agregar_proveedor" onclick="return validar_formulario_proveedores();">Agregar</button>
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
		
			$proveedores = $conexion_now->listarProveedores();
			$posicion = buscar_posicion_proveedor($id_proveedor);
			$proveedor = $proveedores[$posicion];
			
			$id_proveedor = $proveedor->getId_proveedor();
			$nombre_proveedor = $proveedor->getNombre_empresa();
			$direccion = $proveedor->getDireccion();
			$telefono = $proveedor->getTelefono();
			
    		echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Editando al proveedor '.htmlentities($nombre_proveedor).'</div>
	  <div class="panel-body">
		<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
		<input type="hidden" name="id_proveedor" value="' . htmlentities($id_proveedor) . '"> 
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa" value="'.htmlentities($nombre_proveedor).'">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion" value="'.htmlentities($direccion).'">
			  </div>
			</div>
			<div class="form-group">
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
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto">
			  </div>
			</div>
			<div class="form-group">
			  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
			  <div class="col-lg-10">
				<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion"></textarea>
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio">
			  </div>
			</div>
			<div class="form-group">
			  <label for="select" class="col-lg-2 control-label">Proveedor</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="proveedor">
			';
				
			$proveedores          = $conexion_now->listarProveedores();
        	$cantidad_proveedores = count($proveedores);
			
			if ($cantidad_proveedores == 0) {
				echo '<option value="null">No se encontraron proveedores</option>';
			} else {
				foreach ($proveedores as $proveedor) {
					$id_proveedor   = $proveedor->getId_proveedor();
					$nombre_empresa = $proveedor->getNombre_empresa();
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
		
			$productos = $conexion_now->listarProductos();
			$posicion = buscar_posicion_producto($id_producto);
			$producto = $productos[$posicion];
			
			$id_producto = $producto->getId_producto();
			$nombre_producto = $producto->getNombre_producto();
			$descripcion = $producto->getDescripcion();
			$precio = $producto->getPrecio();
			$id_proveedor_real = $producto->getId_proveedor();
			
			
    		echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Editando al producto '.htmlentities($nombre_producto).'</div>
	  <div class="panel-body">
		<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
		<input type="hidden" name="id_producto" value="' . htmlentities($id_producto) . '">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto" value="'.htmlentities($nombre_producto).'">
			  </div>
			</div>
			<div class="form-group">
			  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
			  <div class="col-lg-10">
				<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion">'.htmlentities($descripcion).'</textarea>
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio" value="'.htmlentities($precio).'">
			  </div>
			</div>
			<div class="form-group">
			  <label for="select" class="col-lg-2 control-label">Proveedor</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="proveedor">
			';
				
			$proveedores          = $conexion_now->listarProveedores();
        	$cantidad_proveedores = count($proveedores);
			
			if ($cantidad_proveedores == 0) {
				echo '<option value="null">No se encontraron proveedores</option>';
			} else {
				foreach ($proveedores as $proveedor) {
					$id_proveedor   = $proveedor->getId_proveedor();
					$nombre_empresa = $proveedor->getNombre_empresa();
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
        if ($conexion_now->es_admin($user_login)) {
            
			cargarBuscadorUsuarios();
			
    		echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Agregar usuario</div>
	  <div class="panel-body">
		<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password">
			  </div>
			</div>
			<div class="form-group">
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
						                        
        } else {
            echo "<font color='red'><center><h1>Acceso Denegado</h1></center></font><br>";
        }
	} else if (isset($_GET["editar_usuario"])) {
        if ($conexion_now->es_admin($user_login)) {
            
			cargarBuscadorUsuarios();
			
			$id_usuario = $_GET["editar_usuario"];
		
			if(!is_numeric($id_usuario)) {
				mensaje("Usuarios","ID invalido","warning","?usuarios");
			} else {
		
				$usuarios = $conexion_now->listarUsuarios();
				$posicion = buscar_posicion_usuario($id_usuario);

				$usuario = $usuarios[$posicion];
				
				$id_usuario = $usuario->getId_usuario();
				$nombre_usuario = $usuario->getNombre();
				$clave = $usuario->getPassword();
				$tipo = $usuario->getTipo();
				
    			echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Editar al usuario '.htmlentities($nombre_usuario).'</div>
	  <div class="panel-body">
		<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
		<input type="hidden" name="id_usuario" value="' . htmlentities($id_usuario) . '">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario" value="'.htmlentities($nombre_usuario).'" readonly="readonly">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" readonly="readonly">
			  </div>
			</div>
			<div class="form-group">
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
            
        } else {
            echo "<font color='red'><center><h1>Acceso Denegado</h1></center></font><br>";
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
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputNuevo" class="col-lg-2 control-label">Nuevo usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNuevoUsuario" placeholder="Ingrese nuevo usuario" type="text" name="new_username">
			  </div>
			</div>
			<div class="form-group">
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
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
			  </div>
			</div>
			<div class="form-group">
			  <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputAnterior" placeholder="Ingrese password" type="password" name="anterior_password">
			  </div>
			</div>
			<div class="form-group">
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
		if ($conexion_now->es_admin($user_login)) {
        	echo "<center><h1><font color='white'>Bienvenido a la administración administrador " . htmlentities($user_login) . "</font></h1></center><br>";
		} else {
			echo "<center><h1><font color='white'>Bienvenido a la administración usuario " . htmlentities($user_login) . "</font></h1></center><br>";
		}
    }
    
} else {
    $archivo = "index.php";
    echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />';
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
