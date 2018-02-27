<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormUsuarios">
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Usuarios encontrados : <span data-bind="text: Usuarios().length"></span></div>
	  <div class="panel-body">
	    <fieldset>
	      <div class="form-group">
	        <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
	        <div class="col-lg-10">
	          <input class="form-control" id="buscador_usuarios" type="search" name="buscador_usuarios" placeholder="Ingrese nombre" data-bind="value: nombre_buscar_usuario, valueUpdate: 'keyup'" autocomplete="off"/>
	        </div>
	      </div>
	    </fieldset>
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="visible: UsuariosEncontrados().length > 0">
	  <div class="panel-heading">Usuarios encontrados : <span data-bind="text: UsuariosEncontrados().length"></span></div>
	  <div class="panel-body">
	  <div class="table-responsive">
	    <table class="table table-striped table-hover" data-bind="visible: UsuariosEncontrados().length > 0">
	      <thead>
	        <tr>
	          <th class="fila_usuario">Nombre</th>
	          <th class="fila_usuario">Tipo</th>
	          <th class="fila_usuario">Registro</th>
	          <th class="fila_usuario">Opción</th>
	        </tr>
	      </thead>
	      <tbody data-bind="foreach: UsuariosEncontrados">
	      <tr>
	        <td class="filterable-cell fila_usuario" data-bind="text: usuario"></td>
	        <td class="filterable-cell fila_usuario" data-bind="text: nombre_tipo"></td>
	        <td class="filterable-cell fila_usuario" data-bind="text: fecha_registro"></td>
			<td class="filterable-cell fila_usuario"><a data-bind="click: $root.editarUsuario"><img src="images/edit.png" title="Editar"></a> <a data-bind="click: $root.borrarUsuario"><img src="images/delete.png" title="Borrar"></a></td>
	      </tr>
	      </tbody>
	    </table>
	    </div> 
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="ifnot: Usuario()">
	  <div class="panel-heading">Agregar usuario</div>
	  <div class="panel-body">
		<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario" data-bind="value: $root.usuario">
			  </div>
			</div>
			<div class="form-group" name="form-group-password">
			  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" data-bind="value: $root.clave">
			  </div>
			</div>
			<div class="form-group" name="form-group-tipo">
			  <label for="select" class="col-lg-2 control-label">Tipo</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="tipo" data-bind="value: $root.tipo">
					<option value="2">Usuario</option>
					<option value="1">Administrador</option>
				</select>
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" class="btn btn-primary center-block" name="agregar_usuario" id="agregar_usuario" data-bind="click: AgregarUsuario">Agregar</button>
			</div>
		  </fieldset>
		</form>        
	  </div>
	</div>

	<div class="panel contenedor panel-default" data-bind="if: Usuario">
	  <div class="panel-heading">Editando al usuario <span data-bind="text: Usuario().usuario"></div>
	  <div class="panel-body">
		<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario" data-bind="value: Usuario().usuario" readonly="readonly">
			  </div>
			</div>
			<div class="form-group" name="form-group-password">
			  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" readonly="readonly">
			  </div>
			</div>
			<div class="form-group" name="form-group-tipo">
			  <label for="select" class="col-lg-2 control-label">Tipo</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="tipo" data-bind="value: Usuario().tipo">
					<option value="2">Usuario</option>
					<option value="1">Administrador</option>
				</select>
			  </div>
			</div>
			<div class="text-center">
				<div class="form-group">
					<button type="submit" class="btn btn-default" name="editar_usuario" id="editar_usuario" data-bind="click: GrabarEdicionUsuario">Editar</button>
					<button type="submit" class="btn btn-primary" name="cancelar_usuario" id="cancelar_usuario" data-bind="click: CancelarEdicionUsuario">Cancelar</button>
				</div>
			</div>
		  </fieldset>
		</form>        
	  </div>
	</div>
</div>