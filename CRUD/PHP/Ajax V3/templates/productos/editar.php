<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Producto.php");
include_once("../../entities/Proveedor.php");

if(!verificarCookie()) {
  exit;
}
  
$datos = new AccesoDatos();
		 			
$id_producto = $_POST["editar_producto"];

if(!is_numeric($id_producto)) {
	mensaje("Productos","ID invalido","warning","?productos");
} else {

	$producto = $datos->cargarProducto($id_producto);
	
	$id = $producto->getId();
	$nombre = $producto->getNombre();
	$descripcion = $producto->getDescripcion();
	$precio = $producto->getPrecio();
	$id_proveedor_real = $producto->getId_proveedor();
	
	?>

<div id="modal_editar_producto" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Editando al producto <?php echo htmlentities($nombre) ?></h4>
      </div>
      <div class="modal-body">
		<form action="?productos" method="POST" name="form_productos" id="productoForm" class="form-horizontal">
		<input type="hidden" name="id" value="<?php echo htmlentities($id) ?>">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre" value="<?php echo htmlentities($nombre) ?>">
			  </div>
			</div>
			<div class="form-group" name="form-group-descripcion">
			  <label for="textArea" class="col-lg-2 control-label">Descripción</label>
			  <div class="col-lg-10">
				<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripción" name="descripcion"><?php echo htmlentities($descripcion) ?></textarea>
			  </div>
			</div>
			<div class="form-group" name="form-group-precio">
			  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio" value="<?php echo htmlentities($precio) ?>">
			  </div>
			</div>
			<div class="form-group" name="form-group-proveedor">
			  <label for="select" class="col-lg-2 control-label">Proveedor</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="proveedor">
				<?php
				$proveedores          = $datos->listarProveedores();
				$cantidad_proveedores = count($proveedores);
				
				if ($cantidad_proveedores == 0) {
					echo '<option value="null">No se encontraron proveedores</option>';
				} else {
					foreach ($proveedores as $proveedor) {
						$id   = $proveedor->getId();
						$nombre = $proveedor->getNombre();
						if($id_proveedor_real==$id) {
							echo '<option value="' . htmlentities($id) . '" selected="true">' . htmlentities($nombre) . '</option>';
						} else {
							echo '<option value="' . htmlentities($id) . '">' . htmlentities($nombre) . '</option>';
						}
					}
				}
				?>
			</select>
			  </div>
			</div>
		  </fieldset>
		</form> 
      </div>
      <div class="modal-footer">
		<button type="submit" class="btn btn-primary button_class center-block" id="editar_producto" name="editar_producto"><span class="glyphicon glyphicon-pencil right_space"></span>Editar</button>
      </div>
    </div>
  </div>
</div>       

<?php
		
}
	    
?>