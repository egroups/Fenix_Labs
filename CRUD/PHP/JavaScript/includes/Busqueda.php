<?php

function cargarBuscadorProductos()
{
    
    $conexion_now = new Conexion();
    
    $cantidad_real = "0";
    
    $productos = $conexion_now->listarProductos();
    
    if (isset($_POST["busqueda"])) {
        $cantidad_real = contar_productos($_POST["nombre_buscar"]);
    } else {
        $cantidad_real = count($productos);
    }
    
    echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Productos encontrados : '.htmlentities($cantidad_real).'</div>
	  <div class="panel-body">
            ';
    
    if (isset($_POST["busqueda"])) {
        
        if ($cantidad_real == "0") {
            echo "<center><b>No se encontraron productos</b></center>";
        } else {
			
			echo '
		<table class="table table-striped table-hover ">
		  <thead>
			<tr>
			  <th>Nombre producto</th>
			  <th>Descripcion</th>
			  <th>Precio</th>
			  <th>Proveedor</th>
			  <th>Fecha registro</th>
			  <th>Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  		';
			            
            foreach ($productos as $producto) {
                $id_producto      = $producto->getId_producto();
                $nombre_producto  = $producto->getNombre_producto();
                $descripcion      = $producto->getDescripcion();
                $descripcion      = substr($descripcion, 0, 18);
                $precio           = $producto->getPrecio();
                $fecha_registro   = $producto->getFecha_registro();
                $id_proveedor     = $producto->getId_proveedor();
                $nombre_proveedor = $conexion_now->cargarNombreProveedor($id_proveedor);
                if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_producto)) {
					echo '
					  <tr>
						<td>'.htmlentities($nombre_producto).'</td>
						<td>'.htmlentities($descripcion).'</td>
						<td>'.htmlentities($precio).'</td>
						<td>'.htmlentities($nombre_proveedor).'</td>
						<td>'.htmlentities($fecha_registro).'</td>
						<td><a href=?editar_producto=' . htmlentities($id_producto) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_producto=' . htmlentities($id_producto) . '><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
					';
                }
            }
            
			echo '
				</tbody>
			  </table> 
		  ';
            
        }
    } else {
        echo '
		<form action="?productos" method="POST" class="form-horizontal">
		  <fieldset>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Nombre" name="nombre_buscar" type="text">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" name="busqueda" class="btn btn-primary center-block">Buscar</button>
			</div>
		  </fieldset>
		</form>
		';
        
    }
    
    echo '
	  </div>
	</div>
	';
    
    unset($conexion_now);
    
}

function cargarBuscadorProveedores()
{
    
    $conexion_now = new Conexion();
    
    $cantidad_real = "0";
    
    $proveedores = $conexion_now->listarProveedores();
    
    if (isset($_POST["busqueda"])) {
        $cantidad_real = contar_proveedores($_POST["nombre_buscar"]);
    } else {
        $cantidad_real = count($proveedores);
    }
    
    echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Proveedores encontrados : '.htmlentities($cantidad_real).'</div>
	  <div class="panel-body">
            ';
    
    if (isset($_POST["busqueda"])) {
        
        if ($cantidad_real == "0") {
            echo "<center><b>No se encontraron proveedores</b></center>";
        } else {
			
			echo '
		<table class="table table-striped table-hover ">
		  <thead>
			<tr>
			  <th>Nombre Empresa</th>
			  <th>Direccion</th>
			  <th>Telefono</th>
			  <th>Fecha Registro</th>
			  <th>Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  		';
	  
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->getId_proveedor();
				$nombre_empresa = $proveedor->getNombre_empresa();
				$direccion      = $proveedor->getDireccion();
				$telefono       = $proveedor->getTelefono();
				$fecha_registro = $proveedor->getFecha_registro();
				if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_empresa)) {
					echo '
					  <tr>
						<td>'.htmlentities($nombre_empresa).'</td>
						<td>'.htmlentities($direccion).'</td>
						<td>'.htmlentities($telefono).'</td>
						<td>'.htmlentities($fecha_registro).'</td>
						<td><a href=?editar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
					';
				}
			}
		   
			echo '
				</tbody>
			  </table> 
		  ';
			
        }
        
        echo '
			</div>
		';
        
        
    } else {
        echo '
		<form action="?proveedores" method="POST" class="form-horizontal">
		  <fieldset>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Nombre" name="nombre_buscar" type="text">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" name="busqueda" class="btn btn-primary center-block">Buscar</button>
			</div>
		  </fieldset>
		</form>
		';
        
    }
    
    echo '
	  </div>
	</div>
	';
    
    unset($conexion_now);
    
}

function cargarBuscadorUsuarios()
{
    
    $conexion_now = new Conexion();
    
    $cantidad_real = "0";
    
    $usuarios = $conexion_now->listarUsuarios();
    
    if (isset($_POST["busqueda"])) {
        $cantidad_real = contar_usuarios($_POST["nombre_buscar"]);
    } else {
        $cantidad_real = count($usuarios);
    }
    
    echo '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Usuarios encontrados : '.htmlentities($cantidad_real).'</div>
	  <div class="panel-body">
            ';
    
    if (isset($_POST["busqueda"])) {
        
        if ($cantidad_real == "0") {
            echo "<center><b>No se encontraron usuarios</b></center>";
        } else {
			
				echo '
		<table class="table table-striped table-hover ">
		  <thead>
			<tr>
			  <th>Nombre</th>
			  <th>Tipo</th>
			  <th>Fecha Registro</th>
			  <th>Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  			';
			
                
                foreach ($usuarios as $usuario) {
                    $id_usuario     = $usuario->getId_usuario();
                    $nombre_usuario = $usuario->getNombre();
                    $clave          = $usuario->getPassword();
                    $tipo           = $usuario->getTipo();
                    $fecha_registro = $usuario->getFecha_registro();
                    $tipo_usuario   = "";
                    if ($tipo == "1") {
                        $tipo_usuario = "Administrador";
                    } else {
                        $tipo_usuario = "Usuario";
                    }
					if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_usuario)) {
						
						echo '
					  <tr>
						<td>'.htmlentities($nombre_usuario).'</td>
						<td>'.htmlentities($tipo_usuario).'</td>
						<td>'.htmlentities($fecha_registro).'</td>
						<td><a href=?editar_usuario=' . htmlentities($id_usuario) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_usuario=' . htmlentities($id_usuario) . '><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
						';
						
					}
                }
                
			echo '
				</tbody>
			  </table> 
		  ';
		  
        }
        
        echo '
			</div>
		';
        
        
    } else {
        echo '
		<form action="?usuarios" method="POST" class="form-horizontal">
		  <fieldset>
			<div class="form-group">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Nombre" name="nombre_buscar" type="text">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" name="busqueda" class="btn btn-primary center-block">Buscar</button>
			</div>
		  </fieldset>
		</form>
		';
        
    }
    
    echo '
	  </div>
	</div>
	';
    
    unset($conexion_now);
    
}

?>