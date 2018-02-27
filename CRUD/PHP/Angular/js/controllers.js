function fecha_actual() {
	var currentdate = new Date(); 	
	var fecha = currentdate.getDate() + "/" + (currentdate.getMonth()+1) + "/" + currentdate.getFullYear();
	return fecha;
}

app.factory("AppService", function() {
  return {
    listProductos: function() {
		var idata;
		$.ajax({
		  type: 'POST',
		  url: "includes/ABM.php",
		  data: {'type' : 'getProductos'},
		  dataType: 'json',
		  async: false,
		  success: function(result){idata = result;}
		});
		return idata;
    },
    listProveedores: function() {
    var idata;
		$.ajax({
		  type: 'POST',
		  url: "includes/ABM.php",
		  data: {'type' : 'getProveedores'},
		  dataType: 'json',
		  async: false,
		  success: function(result){idata = result;}
		});
		return idata;
    },
    listUsuarios: function() {
    var idata;
		$.ajax({
		  type: 'POST',
		  url: "includes/ABM.php",
		  data: {'type' : 'getUsuarios'},
		  dataType: 'json',
		  async: false,
		  success: function(result){idata = result;}
		});
		return idata;
    }
  };
});

app.controller("appController", function appController($scope,$http,AppService,loginService){
				
	$scope.productos = [];
	$scope.proveedores = [];
	$scope.usuarios = [];
			
	$scope.productos = AppService.listProductos().data;
	$scope.proveedores = AppService.listProveedores().data;
	$scope.usuarios = AppService.listUsuarios().data;
	
	$scope.logout=function(){
		loginService.logout();
	}
					
})

app.controller('loginCtrl', ['$scope','$location','loginService', function ($scope,$location,loginService) {
	$scope.msgtxt='';

	var connected=loginService.islogged();
	connected.then(function(msg){
	if(msg.data) $location.path('/administracion');
	});

	$scope.login=function(data){
		loginService.login(data,$scope);
	};
}]);

app.controller("AdministracionController", function addController($scope,$http,$filter,$routeParams,$location,AppService,sessionService){

	$scope.user_login = sessionService.getUsername("uid");

	var contenido = "";

    var idata;
	$.ajax({
	  type: 'POST',
	  url: "includes/ABM.php",
	  data: {'type' : 'checkTipoUsuario','username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	contenido = "Bienvenido "+tipo_usuario+" "+$scope.user_login+" a la administracion";

	$scope.welcome = contenido;

})

app.controller("AgregarProductoController", function addController($scope,$http,$location,$route,AppService,$window){
	
	$scope.textButton = "Añadir un nuevo producto";
	$scope.producto = {};
	
	$scope.nombre_producto_placeholder = "Ingrese nombre producto";
	$scope.descripcion_placeholder = "Ingrese descripcion";
	$scope.precio_placeholder = "Ingrese precio";
	
	$scope.form_group_nombre = [];
	$scope.form_group_descripcion = [];
	$scope.form_group_precio = [];
	$scope.form_group_proveedor = [];
	
	$scope.productos = AppService.listProductos().data;
		
	$scope.newProducto = function(){
		
		var form_ready = false;
		
		if(angular.isDefined($scope.producto["nombre_producto"])) {
			form_ready = true;
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_producto_placeholder = "Falta nombre producto";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.producto["descripcion"])) {
			form_ready = true;
			$scope.form_group_descripcion.pop('has-error');
			$scope.form_group_descripcion.push('has-success');
		} else {
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_descripcion.push('has-error');
			$scope.descripcion_placeholder = "Falta descripcion";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["precio"])) {
			form_ready = true;
			$scope.form_group_precio.pop('has-error');
			$scope.form_group_precio.push('has-success');
		} else {
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_precio.push('has-error');
			$scope.precio_placeholder = "Falta precio";
			angular.element('#inputPrecio').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["proveedor"])) {
			form_ready = true;
			$scope.form_group_proveedor.pop('has-error');
			$scope.form_group_proveedor.push('has-success');
		} else {
			$scope.form_group_proveedor.pop('has-success');
			$scope.form_group_proveedor.push('has-error');
			angular.element('#inputProveedor').trigger('focus');
			form_ready = false;
		}	
				
		if(form_ready==true) {
		
			var datos_proveedor = JSON.parse($scope.producto["proveedor"]);
			$scope.producto["fecha_registro"] = fecha_actual();
			$scope.producto["nombre_empresa"] = datos_proveedor["nombre_empresa"];
			$http({
			  method: 'post',
			  url: "includes/ABM.php",
			  data: $.param({'type' : 'addProducto','nombre_producto' : $scope.producto["nombre_producto"], 'descripcion' : $scope.producto["descripcion"] , 'precio': $scope.producto["precio"], 'proveedor' : datos_proveedor["id"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "success" 
					  },
					  function(){
						$window.location.reload(); 
					});
				} else {
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "warning" 
					  },
					  function(){
						$window.location.reload(); 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "error" 
					  },
					  function(){
						$window.location.reload(); 
					});
			});
															
		}		
	}
})

app.controller("EditarProductoController", function editController($scope,$http,$routeParams,$filter,$location,AppService){

	$scope.textButton = "Editar producto";
	
	$scope.producto = {};

	$scope.productos = AppService.listProductos().data;		
	$scope.producto = $filter('filter')($scope.productos, {id:$routeParams.id})[0];
	
	$scope.nombre_producto_placeholder = "Ingrese nombre producto";
	$scope.descripcion_placeholder = "Ingrese descripcion";
	$scope.precio_placeholder = "Ingrese precio";
	
	$scope.form_group_nombre = [];
	$scope.form_group_descripcion = [];
	$scope.form_group_precio = [];
	$scope.form_group_proveedor = [];
	
    $scope.data = {
      'id': 1,
      'id_proveedor': $scope.producto["id_proveedor"]
    }
				
	$scope.updateProducto = function(){
		
		var form_ready = false;
		
		if(angular.isDefined($scope.producto["nombre_producto"])) {
			form_ready = true;
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_producto_placeholder = "Falta nombre producto";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.producto["descripcion"])) {
			form_ready = true;
			$scope.form_group_descripcion.pop('has-error');
			$scope.form_group_descripcion.push('has-success');
		} else {
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_descripcion.push('has-error');
			$scope.descripcion_placeholder = "Falta descripcion";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["precio"])) {
			form_ready = true;
			$scope.form_group_precio.pop('has-error');
			$scope.form_group_precio.push('has-success');
		} else {
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_precio.push('has-error');
			$scope.precio_placeholder = "Falta precio";
			angular.element('#inputPrecio').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["proveedor"])) {
			form_ready = true;
			$scope.form_group_proveedor.pop('has-error');
			$scope.form_group_proveedor.push('has-success');
		} else {
			$scope.form_group_proveedor.pop('has-success');
			$scope.form_group_proveedor.push('has-error');
			angular.element('#inputProveedor').trigger('focus');
			form_ready = false;
		}	
			
		if(form_ready==true) {
										
			$scope.productos.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
											
					var datos_proveedor = JSON.parse($scope.producto["proveedor"]);
					
					$scope.producto["nombre_empresa"] = datos_proveedor["nombre_empresa"];
									
					$http({
					  method: 'post',
					  url: "includes/ABM.php",
					  data: $.param({'type' : 'updateProducto','id_producto':$scope.producto["id"],'nombre_producto' : $scope.producto["nombre_producto"], 'descripcion' : $scope.producto["descripcion"] , 'precio': $scope.producto["precio"], 'proveedor' : datos_proveedor["id"] }),
					  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
					}).
					success(function(data, status, headers, config) {
						if(data.success){
							swal({
									title: 'Productos',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
						} else {
							swal({
									title: 'Productos',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
						}
					}).
					error(function(data, status, headers, config) {
							swal({
									title: 'Productos',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					});
									
					$scope.productos[index] = $scope.producto;
					
				}
			});
			
			$scope.productos = AppService.listProductos().data;
			
			$location.url("/productos");
					
		}
			
	}
})

app.controller("BorrarProductoController", function removeController($scope,$http,$filter,$routeParams,$location,AppService){
	
	$scope.productos = AppService.listProductos().data;	
	$scope.producto = $filter('filter')($scope.productos, {id:$routeParams.id})[0];
		
	$scope.BorrarProducto = function(){
		
		$scope.productos.forEach(function(element, index, array){
			if(element.id == $routeParams.id){
				$scope.productos.splice(index, 1);
				$http({
				  method: 'post',
				  url: "includes/ABM.php",
				  data: $.param({'type' : 'borrarProducto','id_producto' : $routeParams.id}),
				  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
				}).
				success(function(data, status, headers, config) {
					if(data.success){
							swal({
									title: 'Productos',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
					} else {
							swal({
									title: 'Productos',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					}
				}).
				error(function(data, status, headers, config) {
							swal({
									title: 'Productos',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
				});
			}
		});
		
		$scope.productos = AppService.listProductos().data;
				
		$location.url("/productos");
				
	}
			
})


app.controller("AgregarProveedorController", function addController($scope,$http,$location,$route,AppService,$window){
	
	$scope.textButton = "Añadir un nuevo proveedor";
	$scope.proveedor = {};
	
	$scope.nombre_empresa_placeholder = "Ingrese nombre empresa";
	$scope.direccion_placeholder = "Ingrese direccion";
	$scope.telefono_placeholder = "Ingrese telefono";
	
	$scope.form_group_nombre = [];
	$scope.form_group_direccion = [];
	$scope.form_group_telefono = [];
	
	$scope.proveedores = AppService.listProveedores().data;
			
	$scope.newProveedor = function(){
				
		var form_ready = false;
		
		if(angular.isDefined($scope.proveedor["nombre_empresa"])) {
			form_ready = true;
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_empresa_placeholder = "Falta nombre empresa";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.proveedor["direccion"])) {
			form_ready = true;
			$scope.form_group_direccion.pop('has-error');
			$scope.form_group_direccion.push('has-success');
		} else {
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_direccion.push('has-error');
			$scope.direccion_placeholder = "Falta descripcion";
			angular.element('#inputDireccion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.proveedor["telefono"])) {
			form_ready = true;
			$scope.form_group_telefono.pop('has-error');
			$scope.form_group_telefono.push('has-success');
		} else {
			$scope.form_group_telefono.pop('has-success');
			$scope.form_group_telefono.push('has-error');
			$scope.telefono_placeholder = "Falta telefono";
			angular.element('#inputTelefono').trigger('focus');
			form_ready = false;
		}	
								
		if(form_ready==true) {
					
			$scope.proveedor["fecha_registro"] = fecha_actual();
			
			$http({
			  method: 'post',
			  url: "includes/ABM.php",
			  data: $.param({'type' : 'addProveedor','nombre_empresa' : $scope.proveedor["nombre_empresa"], 'direccion' : $scope.proveedor["direccion"] , 'telefono': $scope.proveedor["telefono"], 'fecha_registro' : $scope.proveedor["fecha_registro"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "success" 
					  },
					  function(){
						$window.location.reload(); 
					});
				} else {
					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "warning" 
					  },
					  function(){
						$window.location.reload(); 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "error" 
					  },
					  function(){
						$window.location.reload(); 
					});
			});
																														
		}				
	}
})

app.controller("EditarProveedorController", function editController($scope,$http,$routeParams,$filter,$location,AppService){

	$scope.textButton = "Editar proveedor";
	
	$scope.proveedor = {};

	$scope.proveedores = AppService.listProveedores().data;		
	$scope.proveedor = $filter('filter')($scope.proveedores, {id:$routeParams.id})[0];
	
	$scope.nombre_empresa_placeholder = "Ingrese nombre empresa";
	$scope.direccion_placeholder = "Ingrese direccion";
	$scope.telefono_placeholder = "Ingrese telefono";
	
	$scope.form_group_nombre = [];
	$scope.form_group_direccion = [];
	$scope.form_group_telefono = [];
					
	$scope.updateProveedor = function(){
				
		var form_ready = false;
		
		if(angular.isDefined($scope.proveedor["nombre_empresa"])) {
			form_ready = true;
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_empresa_placeholder = "Falta nombre empresa";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.proveedor["direccion"])) {
			form_ready = true;
			$scope.form_group_direccion.pop('has-error');
			$scope.form_group_direccion.push('has-success');
		} else {
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_direccion.push('has-error');
			$scope.direccion_placeholder = "Falta descripcion";
			angular.element('#inputDireccion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.proveedor["telefono"])) {
			form_ready = true;
			$scope.form_group_telefono.pop('has-error');
			$scope.form_group_telefono.push('has-success');
		} else {
			$scope.form_group_telefono.pop('has-success');
			$scope.form_group_telefono.push('has-error');
			$scope.telefono_placeholder = "Falta telefono";
			angular.element('#inputTelefono').trigger('focus');
			form_ready = false;
		}	
				
		if(form_ready==true) {
										
			$scope.proveedores.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
																				
					$http({
					  method: 'post',
					  url: "includes/ABM.php",
					  data: $.param({'type' : 'updateProveedor','nombre_empresa' : $scope.proveedor["nombre_empresa"], 'direccion' : $scope.proveedor["direccion"] , 'telefono': $scope.proveedor["telefono"], 'id_proveedor' : $scope.proveedor["id"] }),
					  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
					}).
					success(function(data, status, headers, config) {
						if(data.success){
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
						} else {
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
						}
					}).
					error(function(data, status, headers, config) {
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					});
									
					$scope.proveedores[index] = $scope.proveedor;
					
				}
			});
			
			$scope.proveedores = AppService.listProveedores().data;

			
			$location.url("/proveedores");
					
		}
			
	}
})

app.controller("BorrarProveedorController", function removeController($scope,$http,$filter,$routeParams,$location,AppService){
	
	$scope.proveedores = AppService.listProveedores().data;	
	$scope.proveedor = $filter('filter')($scope.proveedores, {id:$routeParams.id})[0];
		
	$scope.BorrarProveedor = function(){
		
		$scope.proveedores.forEach(function(element, index, array){
			if(element.id == $routeParams.id){
				$scope.proveedores.splice(index, 1);
				$http({
				  method: 'post',
				  url: "includes/ABM.php",
				  data: $.param({'type' : 'borrarProveedor','id_proveedor' : $routeParams.id}),
				  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
				}).
				success(function(data, status, headers, config) {
					if(data.success){
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
					} else {
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					}
				}).
				error(function(data, status, headers, config) {
							swal({
									title: 'Proveedores',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
				});
			}
		});
		
		$scope.proveedores = AppService.listProveedores().data;	
				
		$location.url("/proveedores");
					
	}
			
})

app.controller("AgregarUsuarioController", function addController($scope,$http,$location,$route,AppService,$window,sessionService){
	
	$scope.user_login = sessionService.getUsername("uid");

    var idata;
	$.ajax({
	  type: 'POST',
	  url: "includes/ABM.php",
	  data: {'type' : 'checkTipoUsuario','username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="Administrador") {
		swal({
			title: 'Usuarios',
			text: "Acceso Denegado",
			type:'warning',
			html:true,
			animation: false
		});
		$location.url("/administracion");
	} 

	$scope.textButton = "Añadir un nuevo usuario";
	$scope.usuario = {};
	
	$scope.nombre_usuario_placeholder = "Ingrese nombre usuario";
	$scope.password_placeholder = "Ingrese password";
	
	$scope.form_group_nombre = [];
	$scope.form_group_password = [];
	$scope.form_group_tipo = [];
	
	$scope.usuarios = AppService.listUsuarios().data;
	
    $scope.tipos = [
	  {'id': 2,'nombre': 'Usuario'},
      {'id': 1,'nombre': 'Administrador'}
    ]
			
	$scope.newUsuario = function(){

		var form_ready = false;
		
		if(angular.isDefined($scope.usuario["nombre_usuario"])) {
			form_ready = true;
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_usuario_placeholder = "Falta nombre usuario";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.usuario["password"])) {
			form_ready = true;
			$scope.form_group_password.pop('has-error');
			$scope.form_group_password.push('has-success');
		} else {
			$scope.form_group_password.pop('has-success');
			$scope.form_group_password.push('has-error');
			$scope.password_placeholder = "Falta password";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
				
		if(angular.isDefined($scope.usuario["tipo"])) {
			form_ready = true;
			$scope.form_group_tipo.pop('has-error');
			$scope.form_group_tipo.push('has-success');
		} else {
			$scope.form_group_tipo.pop('has-success');
			$scope.form_group_tipo.push('has-error');
			angular.element('#inputTipo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {
		
			$scope.usuario["fecha_registro"] = fecha_actual();
						
			$http({
			  method: 'post',
			  url: "includes/ABM.php",
			  data: $.param({'type' : 'addUsuario','nombre_usuario' : $scope.usuario["nombre_usuario"], 'password' : $scope.usuario["password"] , 'tipo': $scope.usuario["tipo"], 'fecha_registro' : $scope.usuario["fecha_registro"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "success" 
					  },
					  function(){
						$window.location.reload(); 
					});
				} else {
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "warning" 
					  },
					  function(){
						$window.location.reload(); 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "error" 
					  },
					  function(){
						$window.location.reload(); 
					});
			});
															
		}		
								
	}
})

app.controller("BorrarUsuarioController", function removeController($scope,$http,$filter,$routeParams,$location,AppService,sessionService){

	$scope.user_login = sessionService.getUsername("uid");

    var idata;
	$.ajax({
	  type: 'POST',
	  url: "includes/ABM.php",
	  data: {'type' : 'checkTipoUsuario','username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="Administrador") {
		swal({
			title: 'Usuarios',
			text: "Acceso Denegado",
			type:'warning',
			html:true,
			animation: false
		});
		$location.url("/administracion");
	}
	
	$scope.usuarios = AppService.listUsuarios().data;	
	$scope.usuario = $filter('filter')($scope.usuarios, {id:$routeParams.id})[0];
		
	$scope.BorrarUsuario = function(){
		
		$scope.usuarios.forEach(function(element, index, array){
			if(element.id == $routeParams.id){
				$scope.usuarios.splice(index, 1);
				$http({
				  method: 'post',
				  url: "includes/ABM.php",
				  data: $.param({'type' : 'borrarUsuario','id_usuario' : $routeParams.id}),
				  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
				}).
				success(function(data, status, headers, config) {
					if(data.success){
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
					} else {
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					}
				}).
				error(function(data, status, headers, config) {
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
				});
			}
		});
		
		$scope.usuarios = AppService.listUsuarios().data;	
				
		$location.url("/usuarios");
					
	}
			
})

app.controller("EditarUsuarioController", function editController($scope,$http,$routeParams,$filter,$location,AppService,sessionService){

	$scope.user_login = sessionService.getUsername("uid");

    var idata;
	$.ajax({
	  type: 'POST',
	  url: "includes/ABM.php",
	  data: {'type' : 'checkTipoUsuario','username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="Administrador") {
		swal({
			title: 'Usuarios',
			text: "Acceso Denegado",
			type:'warning',
			html:true,
			animation: false
		});
		$location.url("/administracion");
	}

	$scope.textButton = "Editar usuario";
	$scope.usuario = {};
	
	$scope.usuarios = AppService.listUsuarios().data;		
	$scope.usuario = $filter('filter')($scope.usuarios, {id:$routeParams.id})[0];
	$scope.usuario["nombre_usuario"] = $scope.usuario["usuario"];
	
	$scope.nombre_usuario_placeholder = "Ingrese nombre usuario";
	$scope.password_placeholder = "Ingrese password";
	
	$scope.form_group_nombre = [];
	$scope.form_group_password = [];
	$scope.form_group_tipo = [];
		
    $scope.tipos = [
	  {'id': 2,'nombre': 'Usuario'},
      {'id': 1,'nombre': 'Administrador'}
    ]
	
	$scope.updateUsuario = function(){
		
		var form_ready = false;
						
		if(angular.isDefined($scope.usuario["tipo"])) {
			form_ready = true;
			$scope.form_group_tipo.pop('has-error');
			$scope.form_group_tipo.push('has-success');
		} else {
			$scope.form_group_tipo.pop('has-success');
			$scope.form_group_tipo.push('has-error');
			angular.element('#inputTipo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {
										
			$scope.usuarios.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
																				
					$http({
					  method: 'post',
					  url: "includes/ABM.php",
					  data: $.param({'type' : 'updateUsuario','id_usuario':$scope.usuario["id_usuario"],'tipo' : $scope.usuario["tipo"]}),
					  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
					}).
					success(function(data, status, headers, config) {
						if(data.success){
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'success',
									html:true,
									animation: false
							 });
						} else {
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
						}
					}).
					error(function(data, status, headers, config) {
							swal({
									title: 'Usuarios',
									text: data.message,
									type:'error',
									html:true,
									animation: false
							 });
					});
									
					$scope.usuarios[index] = $scope.usuario;
					
				}
			});
			
			$scope.usuarios = AppService.listUsuarios().data;
			
			$location.url("/usuarios");
					
		}			
			
	}
})

app.controller("CambiarUsuarioController", function addController($scope,$http,$location,$route,$window,AppService,loginService,sessionService){
	
	$scope.textButton = "Cambiar Usuario";
	$scope.usuario = {};
	
	$scope.username_placeholder = "Ingrese usuario";
	$scope.new_username_placeholder = "Ingrese nuevo usuario";
	$scope.password_placeholder = "Ingrese password";
	
	$scope.form_group_username = [];
	$scope.form_group_new_username = [];
	$scope.form_group_password = [];
		
	$scope.usuario.nombre = sessionService.getUsername("uid");

	$scope.changeUsername = function(){

		var form_ready = false;
		
		if(angular.isDefined($scope.usuario["nombre"])) {
			form_ready = true;
			$scope.form_group_username.pop('has-error');
			$scope.form_group_username.push('has-success');
		} else {
			$scope.form_group_username.pop('has-success');
			$scope.form_group_username.push('has-error');
			$scope.username_placeholder = "Falta nombre usuario";
			angular.element('#inputUsuario').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.usuario["nuevo_usuario"])) {
			form_ready = true;
			$scope.form_group_new_username.pop('has-error');
			$scope.form_group_new_username.push('has-success');
		} else {
			$scope.form_group_new_username.pop('has-success');
			$scope.form_group_new_username.push('has-error');
			$scope.new_username_placeholder = "Falta usuario nuevo";
			angular.element('#inputNuevoUsuario').trigger('focus');
			form_ready = false;
		}	
				
		if(angular.isDefined($scope.usuario["password"])) {
			form_ready = true;
			$scope.form_group_password.pop('has-error');
			$scope.form_group_password.push('has-success');
		} else {
			$scope.form_group_password.pop('has-success');
			$scope.form_group_password.push('has-error');
			angular.element('#inputPassword').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$http({
			  method: 'post',
			  url: "includes/ABM.php",
			  data: $.param({'type' : 'changeUsername','username' : $scope.usuario["nombre"], 'new_username' : $scope.usuario["nuevo_usuario"] , 'password': $scope.usuario["password"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Cambiar Usuario",
					   text: data.message,
						type: "success" 
					  },
					  function(){
						loginService.logout_silent();
					});
				} else {
					swal({ 
					  title: "Cambiar Usuario",
					   text: data.message,
						type: "warning" 
					  },
					  function(){
						$window.location.reload(); 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Cambiar Usuario",
					   text: data.message,
						type: "error" 
					  },
					  function(){
						$window.location.reload(); 
					});
			});

		}
		
	}
})

app.controller("CambiarPasswordController", function addController($scope,$http,$location,$route,$window,AppService,loginService,sessionService){
	
	$scope.textButton = "Cambiar Password";
	$scope.usuario = {};
	
	$scope.username_placeholder = "Ingrese usuario";
	$scope.anterior_password_placeholder = "Ingrese anterior password";
	$scope.new_password_placeholder = "Ingrese nuevo password";
	
	$scope.form_group_username = [];
	$scope.form_group_anterior_password = [];
	$scope.form_group_new_password = [];

	$scope.usuario.nombre = sessionService.getUsername("uid");
			
	$scope.changePassword = function(){
	
		var form_ready = false;
		
		if(angular.isDefined($scope.usuario["nombre"])) {
			form_ready = true;
			$scope.form_group_username.pop('has-error');
			$scope.form_group_username.push('has-success');
		} else {
			$scope.form_group_username.pop('has-success');
			$scope.form_group_username.push('has-error');
			$scope.username_placeholder = "Falta nombre usuario";
			angular.element('#inputUsuario').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.usuario["anterior_password"])) {
			form_ready = true;
			$scope.form_group_anterior_password.pop('has-error');
			$scope.form_group_anterior_password.push('has-success');
		} else {
			$scope.form_group_anterior_password.pop('has-success');
			$scope.form_group_anterior_password.push('has-error');
			$scope.anterior_password_placeholder = "Falta password";
			angular.element('#inputAnterior').trigger('focus');
			form_ready = false;
		}	
				
		if(angular.isDefined($scope.usuario["nuevo_password"])) {
			form_ready = true;
			$scope.form_group_new_password.pop('has-error');
			$scope.form_group_new_password.push('has-success');
		} else {
			$scope.form_group_new_password.pop('has-success');
			$scope.form_group_new_password.push('has-error');
			angular.element('#inputNuevo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$http({
			  method: 'post',
			  url: "includes/ABM.php",
			  data: $.param({'type' : 'changePassword','username' : $scope.usuario["nombre"], 'anterior_password' : $scope.usuario["anterior_password"] , 'new_password': $scope.usuario["nuevo_password"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Cambiar Password",
					   text: data.message,
						type: "success" 
					  },
					  function(){
						loginService.logout_silent();
					});
				} else {
					swal({ 
					  title: "Cambiar Password",
					   text: data.message,
						type: "warning" 
					  },
					  function(){
						$window.location.reload(); 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Cambiar Password",
					   text: data.message,
						type: "error" 
					  },
					  function(){
						$window.location.reload(); 
					});
			});

		}

	}
})