<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/TipoUsuario.php");

if(!verificarCookie() || !verificarCookieAdmin()) {
  exit;
}
  
$datos = new AccesoDatos();

?>

<div id="modal_agregar_usuario" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Agregar Usuario</h4>
      </div>
      <div class="modal-body">
		<form action="?usuarios" method="POST" name="form_usuarios" id="usuarioForm" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-nombre">
			  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre">
			  </div>
			</div>
			<div class="form-group" name="form-group-password">
			  <label for="inputPrecio" class="col-lg-2 control-label">Clave</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputPassword" placeholder="Ingrese clave" type="password" name="clave">
			  </div>
			</div>
			<div class="form-group" name="form-group-tipo">
			  <label for="select" class="col-lg-2 control-label">Tipo</label>
			  <div class="col-lg-10">
				<select class="form-control" id="select" name="tipo">
				<?php	
				$tipos          = $datos->listarTiposUsuarios("");
				$cantidad_tipos = count($tipos);
				
				if ($cantidad_tipos == 0) {
					echo '<option value="null">No se encontraron tipos</option>';
				} else {
					foreach ($tipos as $tipo) {
						$id   = $tipo->getId();
						$nombre = $tipo->getNombre();
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
	    <button type="button" class="btn btn-primary button_class center-block" id="agregar_usuario" name="agregar_usuario"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</button>
      </div>
    </div>
  </div>
</div>  


		           