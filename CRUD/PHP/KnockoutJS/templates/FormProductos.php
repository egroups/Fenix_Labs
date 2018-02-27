<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormProductos">
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Productos encontrados : <span data-bind="text: Productos().length"></span></div>
	  <div class="panel-body">
	    <fieldset>
	      <div class="form-group">
	        <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
	        <div class="col-lg-10">
	          <input class="form-control" id="buscador_productos" type="search" name="buscador_productos" placeholder="Ingrese nombre" data-bind="value: nombre_buscar_producto, valueUpdate: 'keyup'" autocomplete="off"/>
	        </div>
	      </div>
	    </fieldset>
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="visible: ProductosEncontrados().length > 0">
	  <div class="panel-heading">Productos encontrados : <span data-bind="text: ProductosEncontrados().length"></span></div>
	  <div class="panel-body">
	  <div class="table-responsive">
	    <table class="table table-striped table-hover" data-bind="visible: ProductosEncontrados().length > 0">
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
	      <tbody data-bind="foreach: ProductosEncontrados">
	      <tr>
	        <td class="filterable-cell fila_producto" data-bind="text: nombre_producto"></td>
	        <td class="filterable-cell fila_producto" data-bind="text: descripcion"></td>
	        <td class="filterable-cell fila_producto" data-bind="text: precio"></td>
	        <td class="filterable-cell fila_producto" data-bind="text: nombre_empresa"></td>
	        <td class="filterable-cell fila_producto" data-bind="text: fecha_registro"></td>
			<td class="filterable-cell fila_producto"><a data-bind="click: $root.editarProducto"><img src="images/edit.png" title="Editar"></a> <a data-bind="click: $root.borrarProducto"><img src="images/delete.png" title="Borrar"></a></td>
	      </tr>
	      </tbody>
	    </table> 
	    </div>
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="ifnot: Producto()">
	<div class="panel-heading">Agregar Producto</div>
	<div class="panel-body">
	<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto" data-bind="value: $root.nombre_producto">
		  </div>
		</div>
		<div class="form-group" name="form-group-descripcion">
		  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
		  <div class="col-lg-10">
			<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion" data-bind="value: $root.descripcion"></textarea>
		  </div>
		</div>
		<div class="form-group" name="form-group-precio">
		  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio" data-bind="value: $root.precio">
		  </div>
		</div>
		<div class="form-group" name="form-group-proveedor">
		  <label for="select" class="col-lg-2 control-label">Proveedor</label>
		  <div class="col-lg-10">
	        <select class="form-control" id="inputProveedor" id="proveedor" data-bind="options: Proveedores, optionsText: 'nombre_empresa', optionsValue: 'id_proveedor', value: $root.id_proveedor"></select>
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_producto" id="agregar_producto" data-bind="click: AgregarProducto">Agregar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>

	<div class="panel contenedor panel-default" data-bind="if: Producto">
	<div class="panel-heading">Editando al producto <span data-bind="text: Producto().nombre_producto"></div>
	<div class="panel-body">
	<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<input type="hidden" name="id_producto" data-bind="value: Producto().id_producto"> 
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto" data-bind="value: Producto().nombre_producto">
		  </div>
		</div>
		<div class="form-group" name="form-group-descripcion">
		  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
		  <div class="col-lg-10">
			<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion" data-bind="value: Producto().descripcion"></textarea>
		  </div>
		</div>
		<div class="form-group" name="form-group-precio">
		  <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text" name="precio" data-bind="value: Producto().precio">
		  </div>
		</div>
		<div class="form-group" name="form-group-proveedor">
		  <label for="select" class="col-lg-2 control-label">Proveedor</label>
		  <div class="col-lg-10">
	        <select class="form-control" id="inputProveedor" id="proveedor" data-bind="options: Proveedores, optionsText: 'nombre_empresa', optionsValue: 'id_proveedor', value: Producto().id_proveedor"></select>
		  </div>
		</div>
		<div class="text-center">
			<div class="form-group">
				<button type="submit" class="btn btn-default" name="agregar_producto" id="agregar_producto" data-bind="click: GrabarEdicionProducto">Editar</button>
				<button type="submit" class="btn btn-primary" name="cancelar_producto" id="cancelar_producto" data-bind="click: CancelarEdicionProducto">Cancelar</button>
			</div>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
</div>