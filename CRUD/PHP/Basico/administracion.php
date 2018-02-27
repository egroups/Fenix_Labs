<!-- Written By Ismael Heredia in the year 2016 -->

<?php
if (!isset($_COOKIE['login'])) {
    $archivo = "index.php";
    echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />';
}
?>

<!DOCTYPE html>
<html><head>
      <meta content="initial-scale=1" name="viewport"><meta content="user-scalable=yes,width=device-width,initial-scale=1" name="viewport"><title>Administración</title>
      <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
      <link rel="shortcut icon" href="img/favicon.ico" type="image/ico">
      <link href="css/Site.css" rel="stylesheet" type="text/css">
      <link href="css/main.css" type="text/css" rel="stylesheet">
      <link href="css/more_style.css" rel="stylesheet" type="text/css">
      <link rel="stylesheet" href="css/style2.css">

   </head>
    <body>
      <div id="header-wrapper">
         <div class="container">
            <header id="header">
               <div class="inner">
                  <h1 id="logo"><a href="#">Administración</a></h1>
                  <nav id="nav">
                     <ul>
                        <li style="white-space: nowrap;" class="current_page_item"><a href="administracion.php?">Inicio</a></li>
                        <li class="opener" style="-moz-user-select: none; cursor: pointer; white-space: nowrap;">
                           <a href="#">Cuenta</a>
                           <ul class="dropotron level-0" style="-moz-user-select: none; display: none; position: absolute; z-index: 1000;">
                                 <li style="white-space: nowrap;"><a style="display: block;" href="administracion.php?cambiar_usuario">Cambiar usuario</a></li>
                              <li style="white-space: nowrap;"><a style="display: block;" href="administracion.php?cambiar_password">Cambiar contraseña</a></li>
                           </ul>
                        </li>                        
                        <li class="opener" style="-moz-user-select: none; cursor: pointer; white-space: nowrap;">
                           <a href="#">Gestionar</a>
                           <ul class="dropotron level-0" style="-moz-user-select: none; display: none; position: absolute; z-index: 1000;">
                              <li style="white-space: nowrap;"><a style="display: block;" href="administracion.php?productos">Productos</a></li>
                              <li style="white-space: nowrap;"><a style="display: block;" href="administracion.php?proveedores">Proveedores</a></li>
                              <li style="white-space: nowrap;"><a style="display: block;" href="administracion.php?usuarios">Usuarios</a></li>
                           </ul>
                        </li>
                        <li style="white-space: nowrap;"><a href="administracion.php?estadisticas">Estadísticas</a></li>
                        <li style="white-space: nowrap;"><a href="administracion.php?logout">Salir</a></li>
                     </ul>
                  </nav>
               </div>
               </header>              
            <br><br>
            <header class="major"></header>
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

$cortar = base64_decode($_COOKIE['login']);

$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];

if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {
    
    if (isset($_GET["proveedores"])) {
        
        cargarBuscadorProveedores();
        
        echo '
            <div class="login">
        <center>
            <h1>Agregar proveedor</h1><form action="?proveedores" method="POST">
            
            <b>Nombre empresa : </b><input type="text" name="nombre_empresa"><br>
            <b>Direccion : </b><input type="text" name="direccion"><br>
            <b>Telefono : </b><input type="text" name="telefono"><br><br>
            
            <button class="small button" name="agregar_proveedor" type="submit">Agregar</button>
            
            </div></form></center><br>';
			
	} else if(isset($_GET["editar_proveedor"])) {
	
        cargarBuscadorProveedores();
        
		$id_proveedor = $_GET["editar_proveedor"];
		
		if(!is_numeric($id_proveedor)) {
			echo "<script>alert('ID invalido');</script>";
		} else {
		
			$proveedores = $conexion_now->listarProveedores();
			$posicion = buscar_posicion_proveedor($id_proveedor);
			$proveedor = $proveedores[$posicion];
			
			$id_proveedor = $proveedor->getId_proveedor();
			$nombre_proveedor = $proveedor->getNombre_empresa();
			$direccion = $proveedor->getDireccion();
			$telefono = $proveedor->getTelefono();
				
       	 	echo '
            <div class="login">
        <center>
            <h1>Editando al proveedor '.htmlentities($nombre_proveedor).'</h1><form action="?proveedores" method="POST">
            <input type="hidden" name="id_proveedor" value="' . htmlentities($id_proveedor) . '"> 
            <b>Nombre empresa : </b><input type="text" name="nombre_empresa" value="'.htmlentities($nombre_proveedor).'"><br>
            <b>Direccion : </b><input type="text" name="direccion" value="'.htmlentities($direccion).'"><br>
            <b>Telefono : </b><input type="text" name="telefono" value="'.htmlentities($telefono).'"><br><br>
            
            <button class="small button" name="editar_proveedor" type="submit">Editar</button>
            
            </div></form></center><br>';
		}
        
    } else if (isset($_GET["productos"])) {
        
        cargarBuscadorProductos();
		
        echo '
            <div class="login">
        <center>
            <h1>Agregar producto</h1><form action="?productos" method="POST">
            
            <b>Nombre producto : </b><input type="text" name="nombre_producto"><br><br>
            <b>Descripción : </b><br><br><textarea cols=50 rows=10 name="descripcion" style="border-style: inset;;border-width: 1px;border-color:black;"></textarea><br><br>
            <b>Precio : &nbsp;$</b><input type="text" name="precio" style="width: 80px;"><br><br>';
        
        $proveedores          = $conexion_now->listarProveedores();
        $cantidad_proveedores = count($proveedores);
        
        if ($cantidad_proveedores == 0) {
            echo '<b>Proveedor : </b><select name="proveedor" style="border-style: inset;;border-width: 1px;border-color:black;">';
            echo '<option value="null">No se encontraron proveedores</option>';
            echo '</select><br><br>';
        } else {
            echo '
            <b>Proveedor : </b><select name="proveedor" style="border-style: inset;;border-width: 1px;border-color:black;">';
            foreach ($proveedores as $proveedor) {
                $id_proveedor   = $proveedor->getId_proveedor();
                $nombre_empresa = $proveedor->getNombre_empresa();
                echo '<option value="' . htmlentities($id_proveedor) . '">' . htmlentities($nombre_empresa) . '</option>';
            }
            echo '</select><br><br>';
        }
        
        echo '<button class="small button" name="agregar_producto" type="submit">Agregar</button>
            
            </div></form></center><br>';
        
    } else if(isset($_GET["editar_producto"])) {
	
        cargarBuscadorProductos();

		$id_producto = $_GET["editar_producto"];
		
		if(!is_numeric($id_producto)) {
			echo "<script>alert('ID invalido');</script>";
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
            <div class="login">
        <center>
            <h1>Editando al producto '.htmlentities($nombre_producto).'</h1><form action="?productos" method="POST">
            <input type="hidden" name="id_producto" value="' . htmlentities($id_producto) . '">
            <b>Nombre producto : </b><input type="text" name="nombre_producto" value="'.htmlentities($nombre_producto).'"><br><br>
            <b>Descripción : </b><br><br><textarea cols=50 rows=10 name="descripcion" style="border-style: inset;;border-width: 1px;border-color:black;">'.$descripcion.'</textarea><br><br>
            <b>Precio : &nbsp;$</b><input type="text" name="precio" style="width: 80px;" value="'.htmlentities($precio).'"><br><br>';
        
       	 $proveedores          = $conexion_now->listarProveedores();
       	 $cantidad_proveedores = count($proveedores);
        
         if ($cantidad_proveedores == 0) {
         	echo '<b>Proveedor : </b><select name="proveedor" style="border-style: inset;;border-width: 1px;border-color:black;">';
            echo '<option value="null">No se encontraron proveedores</option>';
            echo '</select><br><br>';
         } else {
            echo '
            <b>Proveedor : </b><select name="proveedor" style="border-style: inset;;border-width: 1px;border-color:black;">';
            foreach ($proveedores as $proveedor) {
                $id_proveedor   = $proveedor->getId_proveedor();
                $nombre_empresa = $proveedor->getNombre_empresa();
				if($id_proveedor_real==$id_proveedor) {
                	echo '<option value="' . htmlentities($id_proveedor) . '" selected="true">' . htmlentities($nombre_empresa) . '</option>';
				} else {
					echo '<option value="' . htmlentities($id_proveedor) . '">' . htmlentities($nombre_empresa) . '</option>';
				}
            }
            echo '</select><br><br>';
         }
        
         echo '<button class="small button" name="editar_producto" type="submit">Editar</button>
            
            </div></form></center><br>';
		}
	
	} else if (isset($_GET["usuarios"])) {
        if ($conexion_now->es_admin($user_login)) {
            
			cargarBuscadorUsuarios();
						            
            echo '
            <div class="login">
        <center>
            <h1>Agregar usuario</h1><form action="?usuarios" method="POST">
            
            <b>Nombre usuario : </b><input type="text" name="nombre_usuario"><br>
            <b>Password : </b><input type="password" name="password"><br><br>';
            
            echo '
            <b>Tipo : </b><select name="tipo">
            <option value="2">Usuario</option>
            <option value="1">Administrador</option>
            </select><br><br>
            ';
            
            echo '<button class="small button" name="agregar_usuario" type="submit">Agregar</button>
            
            </div></form></center><br>';
            
        } else {
            echo "<font color='red'><center><h1>Acceso Denegado</h1></center></font><br>";
        }
	} else if (isset($_GET["editar_usuario"])) {
        if ($conexion_now->es_admin($user_login)) {
            
			cargarBuscadorUsuarios();
			
			$id_usuario = $_GET["editar_usuario"];
		
			if(!is_numeric($id_usuario)) {
				echo "<script>alert('ID invalido');</script>";
			} else {
		
				$usuarios = $conexion_now->listarUsuarios();
				$posicion = buscar_posicion_usuario($id_usuario);

				$usuario = $usuarios[$posicion];
				
				$id_usuario = $usuario->getId_usuario();
				$nombre_usuario = $usuario->getNombre();
				$clave = $usuario->getPassword();
				$tipo = $usuario->getTipo();
		            
            	echo '
            <div class="login">
        <center>
            <h1>Agregar usuario</h1><form action="?usuarios" method="POST">
            <input type="hidden" name="id_usuario" value="' . htmlentities($id_usuario) . '"> 
            <b>Nombre usuario : </b><input type="text" name="nombre_usuario" value="'.htmlentities($nombre_usuario).'" readonly="readonly""><br>
            <b>Password : </b><input type="password" name="password" readonly="readonly"><br><br>';
            
            	echo '
            <b>Tipo : </b><select name="tipo">';

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
            
            	echo '</select><br><br>';
            
            	echo '<button class="small button" name="editar_usuario" type="submit">Editar</button>
            
            </div></form></center><br>';
			
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
            echo "<script>alert('Faltan datos para cambiar el nombre de usuario');</script>";
            redireccion($ruta);
        } else {
            $password_encoded = md5($password);
            if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
                
                if ($conexion_now->EjecutarConsulta("update usuarios set usuario='" . $new_username . "' where usuario='" . $username . "'")) {
                    echo "<script>alert('El nombre de usuario ha sido cambiado exitosamente');</script>";
                    cerrar_sesion();
                } else {
                    echo "<script>alert('Ha ocurrido un error cambiando el nombre de usuario');</script>";
                    redireccion($ruta);
                }
            } else {
                echo "<script>alert('La contraseña no coincide');</script>";
                redireccion($ruta);
            }
        }
        
    } else if (isset($_GET["cambiar_usuario"])) {
        
        echo "<center>";
        
        echo '
              <div class="login">
              <h1>Cambiar usuario</h1>
            ';
        echo "<form action='' method='POST'>";
        echo '
            <b>Usuario : </b><input type="text" name="username" readonly="readonly" value="' . htmlentities($user_login) . '"><br>
            <b>Nuevo usuario : </b><input type="text" name="new_username" value=""><br><br>
            <b>Actual contraseña : </b><input type="password" name="password"><br><br>
            <button class="small button" name="cambiar_user" type="submit">Cambiar</button>
            ';
        
        echo '<br></div></center>';
    } else if (isset($_POST["cambiar_pass"])) {
        
        $username = $_POST["username"];
        $old_pass = $_POST["anterior_password"];
        $new_pass = $_POST["new_password"];
        
        $ruta = "administracion.php?cambiar_password";
        
        if ($username == "" || $old_pass == "" || $new_pass == "") {
            echo "<script>alert('Faltan datos para cambiar la contraseña');</script>";
            redireccion($ruta);
        } else {
            $password_encoded = md5($old_pass);
            $new_pass_encoded = md5($new_pass);
            if ($conexion_now->ingreso_usuario($username, $password_encoded)) {
                
                if ($conexion_now->EjecutarConsulta("update usuarios set clave='" . $new_pass_encoded . "' where usuario='" . $username . "'")) {
                    echo "<script>alert('La contraseña ha sido cambiada exitosamente');</script>";
                    cerrar_sesion();
                } else {
                    echo "<script>alert('Ha ocurrido un error cambiando la contraseña');</script>";
                    redireccion($ruta);
                }
            } else {
                echo "<script>alert('La contraseña antigua no coincide');</script>";
                redireccion($ruta);
            }
        }
        
    } else if (isset($_GET["cambiar_password"])) {
        
        echo "<center>";
        
        echo '
              <div class="login">
              <h1>Cambiar contraseña</h1>
            ';
        echo "<form action='' method='POST'>";
        echo '
            <b>Usuario : </b><input type="text" name="username" readonly="readonly" value="' . htmlentities($user_login) . '"><br><br>
            <b>Actual contraseña : </b><input type="password" name="anterior_password"><br>
            <b>Nueva contraseña : </b><input type="password" name="new_password"><br><br>
            <button class="small button" name="cambiar_pass" type="submit">Cambiar</button>
            ';
        
        echo '<br></div></center>';
        
    } else if (isset($_GET["estadisticas"])) {
        
    } else if (isset($_GET["logout"])) {
        cerrar_sesion();
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
            <header class="major">
            </header>
            
         </div>
      </div>
      <div class="row">
         <div class="12u">
            <div id="copyright">
               <ul class="menu">
                  <li>Creditos</li>
               </ul>
            </div>
         </div>
      </div>
      <!-- Scripts -->
      <script src="js/jquery.js"></script>
      <script src="js/jquery_002.js"></script>
      <script src="js/skel.js"></script>
      <script src="js/skel-viewport.js"></script>
      <script src="js/util.js"></script>
      <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
      <script src="js/main.js"></script>

</body></html>