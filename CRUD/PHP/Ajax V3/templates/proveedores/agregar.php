<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");

if(!verificarCookie()) {
  exit;
}

?>

<div id="modal_agregar_proveedor" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Agregar Proveedor</h4>
      </div>
      <div class="modal-body">
		<form action="?proveedores" method="POST" name="form_proveedores" id="proveedorForm" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre">
			  </div>
			</div>
			<div class="form-group" name="form-group-direccion">
			  <label for="inputDireccion" class="col-lg-2 control-label">Dirección</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputDireccion" placeholder="Ingrese dirección" type="text" name="direccion">
			  </div>
			</div>
			<div class="form-group" name="form-group-telefono">
			  <label for="inputTelefono" class="col-lg-2 control-label">Teléfono</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputTelefono" placeholder="Ingrese teléfono" type="text" name="telefono">
			  </div>
			</div>
		  </fieldset>
		</form>   
      </div>
      <div class="modal-footer">
	    <button type="button" class="btn btn-primary button_class center-block" id="agregar_proveedor" name="agregar_proveedor"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</button>
      </div>
    </div>
  </div>
</div>