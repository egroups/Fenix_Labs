<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Proveedor.php");

if(!verificarCookie()) {
  exit;
}

$datos = new AccesoDatos();
		
$id_proveedor = $_POST["editar_proveedor"];

if(!is_numeric($id_proveedor)) {
	mensaje("Proveedores","ID invalido","warning","?proveedores");
} else {

	$proveedor = $datos->cargarProveedor($id_proveedor);
	
	$id = $proveedor->getId();
	$nombre = $proveedor->getNombre();
	$direccion = $proveedor->getDireccion();
	$telefono = $proveedor->getTelefono();
	
?>

<div id="modal_editar_proveedor" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Editando al proveedor <?php echo htmlentities($nombre) ?></h4>
      </div>
      <div class="modal-body">
		<form action="?proveedores" method="POST" name="form_proveedores" id="proveedorForm" class="form-horizontal">
		<input type="hidden" name="id" value="<?php echo htmlentities($id) ?>"> 
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre" value="<?php echo htmlentities($nombre) ?>">
			  </div>
			</div>
			<div class="form-group" name="form-group-direccion">
			  <label for="inputDireccion" class="col-lg-2 control-label">Dirección</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputDireccion" placeholder="Ingrese dirección" type="text" name="direccion" value="<?php echo htmlentities($direccion) ?>">
			  </div>
			</div>
			<div class="form-group" name="form-group-telefono">
			  <label for="inputTelefono" class="col-lg-2 control-label">Teléfono</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputTelefono" placeholder="Ingrese teléfono" type="text" name="telefono" value="<?php echo htmlentities($telefono) ?>">
			  </div>
			</div>
		  </fieldset>
		</form> 
      </div>
      <div class="modal-footer">
		<button type="submit" class="btn btn-primary button_class center-block" id="editar_proveedor" name="editar_proveedor"><span class="glyphicon glyphicon-pencil right_space"></span>Editar</button>
      </div>
    </div>
  </div>
</div>  

<?php

}
		    
?>