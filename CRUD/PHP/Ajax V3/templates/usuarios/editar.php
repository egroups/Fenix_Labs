<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Usuario.php");
include_once("../../entities/TipoUsuario.php");

if(!verificarCookie() || !verificarCookieAdmin()) {
  exit;
}

$datos = new AccesoDatos();
			
$id_usuario = $_POST["editar_usuario"];

if(!is_numeric($id_usuario)) {
	mensaje("Usuarios","ID invalido","warning","?usuarios");
} else {

	$usuario = $datos->cargarUsuario($id_usuario);
	
	$id = $usuario->getId();
	$nombre = $usuario->getNombre();
	$clave = $usuario->getClave();
	$id_tipo = $usuario->getId_Tipo();
	
	?>

<div id="modal_editar_usuario" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Editar al usuario <?php echo htmlentities($nombre) ?></h4>
      </div>
      <div class="modal-body">
		<form action="?usuarios" method="POST" name="form_usuarios_editar" id="asignarUsuarioForm" class="form-horizontal">
		<input type="hidden" name="id" value="<?php echo htmlentities($id) ?>">
		<fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" name="nombre" value="<?php echo htmlentities($nombre) ?>" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-password">
		  <label for="inputPrecio" class="col-lg-2 control-label">Clave</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputClave" placeholder="Ingrese clave" type="password" name="clave" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-tipo">
		  <label for="select" class="col-lg-2 control-label">Tipo</label>
		  <div class="col-lg-10">
			<select class="form-control" id="select" name="tipo">
			<?php
			$tipos          = $datos->listarTiposUsuarios();
			$cantidad_tipos = count($tipos);
			
			if ($cantidad_tipos == 0) {
				echo '<option value="null">No se encontraron tipos</option>';
			} else {
				foreach ($tipos as $tipo) {
					$id   = $tipo->getId();
					$nombre = $tipo->getNombre();
					if($id==$id_tipo) {
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
		<button type="submit" class="btn btn-primary button_class center-block" id="editar_usuario" name="editar_usuario"><span class="glyphicon glyphicon-pencil right_space"></span>Editar</button>
      </div>
    </div>
  </div>
</div>  

<?php					
}
?>
				          