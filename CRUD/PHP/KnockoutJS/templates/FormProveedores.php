<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormProveedores">
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Proveedores encontrados : <span data-bind="text: Proveedores().length"></span></div>
	  <div class="panel-body">
	    <fieldset>
	      <div class="form-group">
	        <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
	        <div class="col-lg-10">
	          <input class="form-control" id="buscador_proveedores" type="search" name="buscador_proveedores" placeholder="Ingrese nombre" data-bind="value: nombre_buscar_proveedor, valueUpdate: 'keyup'" autocomplete="off"/>
	        </div>
	      </div>
	    </fieldset>
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="visible: ProveedoresEncontrados().length > 0">
	  <div class="panel-heading">Proveedores encontrados : <span data-bind="text: ProveedoresEncontrados().length"></span></div>
	  <div class="panel-body">
	  <div class="table-responsive">
	    <table class="table table-striped table-hover" data-bind="visible: ProveedoresEncontrados().length > 0">
	      <thead>
	        <tr>
	          <th class="fila_proveedor">Nombre</th>
	          <th class="fila_proveedor">Direccion</th>
	          <th class="fila_proveedor">Telefono</th>
	          <th class="fila_proveedor">Registro</th>
	          <th class="fila_proveedor">Opción</th>
	        </tr>
	      </thead>
	      <tbody data-bind="foreach: ProveedoresEncontrados">
	      <tr>
	        <td class="filterable-cell fila_proveedor" data-bind="text: nombre_empresa"></td>
	        <td class="filterable-cell fila_proveedor" data-bind="text: direccion"></td>
	        <td class="filterable-cell fila_proveedor" data-bind="text: telefono"></td>
	        <td class="filterable-cell fila_proveedor" data-bind="text: fecha_registro_proveedor"></td>
			<td class="filterable-cell fila_proveedor"><a data-bind="click: $root.editarProveedor"><img src="images/edit.png" title="Editar"></a> <a data-bind="click: $root.borrarProveedor"><img src="images/delete.png" title="Borrar"></a></td>
	      </tr>
	      </tbody>
	    </table>
	    </div> 
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="ifnot: Proveedor()">
	<div class="panel-heading">Agregar Proveedor</div>
	<div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa" data-bind="value: $root.nombre_empresa">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion" data-bind="value: $root.direccion">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono" data-bind="value: $root.telefono">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_proveedor" id="agregar_proveedor" data-bind="click: AgregarProveedor">Agregar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>

	<div class="panel contenedor panel-default" data-bind="if: Proveedor">
	<div class="panel-heading">Editando al proveedor <span data-bind="text: Proveedor().nombre_empresa"></div>
	<div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<input type="hidden" name="id_proveedor" data-bind="value: Proveedor().id"> 
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa" data-bind="value: Proveedor().nombre_empresa">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion" data-bind="value: Proveedor().direccion">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono" data-bind="value: Proveedor().telefono">
		  </div>
		</div>
		<div class="text-center">
			<div class="form-group">
				<button type="submit" class="btn btn-default" name="editar_proveedor" id="editar_proveedor" data-bind="click: GrabarEdicionProveedor">Editar</button>
				<button type="submit" class="btn btn-primary" name="cancelar_proveedor" id="cancelar_proveedor" data-bind="click: CancelarEdicionProveedor">Cancelar</button>
			</div>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
</div>