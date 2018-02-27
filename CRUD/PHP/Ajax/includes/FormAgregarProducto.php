<script>
$(document).ready(function(){
		  
  $("form[name='form_productos']").submit(function(e) {

    var nombre_check = $("input[name='nombre_producto']").val();
	var descripcion_check = $("textarea[name='descripcion']").val();
	var precio_check = $("input[name='precio']").val();
	var proveedor_check = $("select[name='proveedor']").val();

    if(nombre_check=="") {
      $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
      $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_producto']").focus();
      e.preventDefault();
      return false;   
	} else if(descripcion_check=="") {
      $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
      $("div[name='form-group-descripcion']").addClass('has-error');
	  $("textarea[name='descripcion']").focus();
      e.preventDefault();
      return false;   	
	} else if(precio_check=="") {
      $("input[name='precio']").attr("placeholder", "Falta precio");
      $("div[name='form-group-precio']").addClass('has-error');
	  $("input[name='precio']").focus();
      e.preventDefault();
      return false;   
	} else if(proveedor_check=="0") {
      $("select[name='proveedor']").attr("placeholder", "Seleccione proveedor");
      $("div[name='form-group-proveedor']").addClass('has-error');
	  $("select[name='proveedor']").focus();
      e.preventDefault();
      return false;   
    } else {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-descripcion']").addClass('has-success');
	  $("div[name='form-group-precio']").addClass('has-success');
	  $("div[name='form-group-proveedor']").addClass('has-success');
      $.post("includes/ABM.php",{agregar_producto:"",nombre_producto:nombre_check,descripcion:descripcion_check,precio:precio_check,proveedor:proveedor_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
      });
      e.preventDefault();
      return false; 
	}
  });
  
});
</script>

<?php
     
include_once("Productos.php");
include_once("Proveedores.php");
include_once("Conexion.php");
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_COOKIE['cookie_login']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {
	 
	$resultado = "";
	
	$cantidad_real = "0";
	
	$productos = $conexion_now->listarProductos();
	
	if (isset($_POST["busqueda"])) {
		$cantidad_real = contar_productos($_POST["nombre_buscar"]);
	} else {
		$cantidad_real = count($productos);
	}
	
	$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	<div class="panel-heading">Agregar Producto</div>
	<div class="panel-body">
	<form action="?productos" method="POST" name="form_productos" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text" name="nombre_producto">
		  </div>
		</div>
		<div class="form-group" name="form-group-descripcion">
		  <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
		  <div class="col-lg-10">
			<textarea class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" name="descripcion"></textarea>
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
		';
			
		$proveedores          = $conexion_now->listarProveedores();
		$cantidad_proveedores = count($proveedores);
		
		if ($cantidad_proveedores == 0) {
			$resultado = $resultado . '<option value="null">No se encontraron proveedores</option>';
		} else {
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->getId_proveedor();
				$nombre_empresa = $proveedor->getNombre_empresa();
				$resultado = $resultado . '<option value="' . htmlentities($id_proveedor) . '">' . htmlentities($nombre_empresa) . '</option>';
			}
		}
	
		$resultado = $resultado . '</select>
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_producto" onclick="return validar_formulario_productos();">Agregar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
		';
		
	echo $resultado;

}
		            
?>