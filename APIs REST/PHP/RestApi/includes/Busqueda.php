<?php

// Written By Ismael Heredia in the year 2017

function cargarBuscadorProductos()
{
    
    $cliente_now = new Cliente();
    
    $cantidad_real = "0";
    
    $productos = $cliente_now->listarProductos();
    
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
			  <th class="fila_producto">Nombre</th>
			  <th class="fila_producto">Descripcion</th>
			  <th class="fila_producto">Precio</th>
			  <th class="fila_producto">Proveedor</th>
			  <th class="fila_producto">Registro</th>
			  <th class="fila_producto">Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  		';
			            
            foreach ($productos as $producto) {
                $id_producto      = $producto->id_producto;
                $nombre_producto  = $producto->nombre_producto;
                $descripcion      = $producto->descripcion;
                $descripcion      = substr($descripcion, 0, 18);
                $precio           = $producto->precio;
                $fecha_registro   = $producto->fecha_registro;
                $id_proveedor     = $producto->id_proveedor;
                $nombre_proveedor = $producto->nombre_empresa;
                if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_producto)) {
					echo '
					  <tr>
						<td class="filterable-cell fila_producto">'.htmlentities($nombre_producto).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($descripcion).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($precio).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($nombre_proveedor).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($fecha_registro).'</td>
						<td class="filterable-cell fila_producto"><a href="?editar_producto=' . htmlentities($id_producto) . '"><img src="images/edit.png" title="Editar"></a> <a href="?borrar_producto=' . htmlentities($id_producto) . '"><img src="images/delete.png" title="Borrar"></a></td>
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
			  <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputBuscar" placeholder="Nombre" name="nombre_buscar" type="text">
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
    
    $cliente_now = new Cliente();
    
    $cantidad_real = "0";
    
    $proveedores = $cliente_now->listarProveedores();
    
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
			  <th class="fila_proveedor">Nombre</th>
			  <th class="fila_proveedor">Direccion</th>
			  <th class="fila_proveedor">Telefono</th>
			  <th class="fila_proveedor">Registro</th>
			  <th class="fila_proveedor">Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  		';
	  
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->id_proveedor;
				$nombre_empresa = $proveedor->nombre_empresa;
				$direccion      = $proveedor->direccion;
				$telefono       = $proveedor->telefono;
				$fecha_registro = $proveedor->fecha_registro_proveedor;
				if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_empresa)) {
					echo '
					  <tr>
						<td class="filterable-cell fila_proveedor">'.htmlentities($nombre_empresa).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($direccion).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($telefono).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($fecha_registro).'</td>
						<td class="filterable-cell fila_proveedor"><a href=?editar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/delete.png" title="Borrar"></a></td>
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
			  <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputBuscar" placeholder="Nombre" name="nombre_buscar" type="text">
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
    
    $cliente_now = new Cliente();
    
    $cantidad_real = "0";
    
    $usuarios = $cliente_now->listarUsuarios();
    
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
			  <th class="fila_usuario">Nombre</th>
			  <th class="fila_usuario">Tipo</th>
			  <th class="fila_usuario">Registro</th>
			  <th class="fila_usuario">Opción</th>
			</tr>
		  </thead>
		  <tbody>
	  			';
			
                
                foreach ($usuarios as $usuario) {
                    $id_usuario     = $usuario->id_usuario;
                    $nombre_usuario = $usuario->usuario;
                    $clave          = $usuario->clave;
                    $tipo           = $usuario->tipo;
                    $fecha_registro = $usuario->fecha_registro;
                    $tipo_usuario   = "";
                    if ($tipo == "1") {
                        $tipo_usuario = "Administrador";
                    } else {
                        $tipo_usuario = "Usuario";
                    }
					if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_usuario)) {
						
						echo '
						  <tr>
							<td class="filterable-cell fila_usuario">'.htmlentities($nombre_usuario).'</td>
							<td class="filterable-cell fila_usuario">'.htmlentities($tipo_usuario).'</td>
							<td class="filterable-cell fila_usuario">'.htmlentities($fecha_registro).'</td>
							<td class="filterable-cell fila_usuario"><a href=?editar_usuario=' . htmlentities($id_usuario) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_usuario=' . htmlentities($id_usuario) . '><img src="images/delete.png" title="Borrar"></a></td>
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