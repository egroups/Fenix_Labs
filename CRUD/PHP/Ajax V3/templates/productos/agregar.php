<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Proveedor.php");

if(!verificarCookie()) {
  exit;
}
       
$datos = new AccesoDatos();
		 
?>
	          
<div id="modal_agregar_producto" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Agregar Producto</h4>
      </div>
      <div class="modal-body">
		<form action="?productos" method="POST" name="form_productos" id="productoForm" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre">
			  </div>
			</div>
			<div class="form-group" name="form-group-descripcion">
			  <label for="textArea" class="col-lg-2 control-label">Descripción</label>
			  <div class="col-lg-10">
				<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripción" name="descripcion"></textarea>
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
				<?php	
				$proveedores          = $datos->listarProveedores();
				$cantidad_proveedores = count($proveedores);
				
				if ($cantidad_proveedores == 0) {
					echo '<option value="null">No se encontraron proveedores</option>';
				} else {
					foreach ($proveedores as $proveedor) {
						$id   = $proveedor->getId();
						$nombre = $proveedor->getNombre();
						echo '<option value="' . htmlentities($id) . '">' . htmlentities($nombre) . '</option>';
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
	    <button type="button" class="btn btn-primary button_class center-block" id="agregar_producto" name="agregar_producto"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</button>
      </div>
    </div>
  </div>
</div>