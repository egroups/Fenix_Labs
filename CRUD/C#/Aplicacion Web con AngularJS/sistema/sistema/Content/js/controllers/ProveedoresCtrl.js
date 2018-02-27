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
				
		var form_ready = true;
		
		if(angular.isDefined($scope.proveedor["nombre_empresa"])) {
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
			$scope.nombre_empresa_placeholder = "Ingrese nombre empresa";
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_empresa_placeholder = "Falta nombre empresa";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.proveedor["direccion"])) {
			$scope.form_group_direccion.pop('has-error');
			$scope.form_group_direccion.push('has-success');
			$scope.direccion_placeholder = "Ingrese descripcion";
		} else {
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_direccion.push('has-error');
			$scope.direccion_placeholder = "Falta descripcion";
			angular.element('#inputDireccion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.proveedor["telefono"])) {
			$scope.form_group_telefono.pop('has-error');
			$scope.form_group_telefono.push('has-success');
			$scope.telefono_placeholder = "Ingrese telefono";
		} else {
			$scope.form_group_telefono.pop('has-success');
			$scope.form_group_telefono.push('has-error');
			$scope.telefono_placeholder = "Falta telefono";
			angular.element('#inputTelefono').trigger('focus');
			form_ready = false;
		}	
								
		if(form_ready==true) {

			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_telefono.pop('has-success');

			$scope.proveedor["fecha_registro_proveedor"] = fecha_actual();
			
			$http({
			  method: 'post',
			  url: 'Administracion/Proveedores/Agregar',
			  data: $.param({'nombre_empresa' : $scope.proveedor["nombre_empresa"], 'direccion' : $scope.proveedor["direccion"] , 'telefono': $scope.proveedor["telefono"], 'fecha_registro' : $scope.proveedor["fecha_registro_proveedor"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){

					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "success",
						html:true,
						animation: false
					});

					$scope.proveedores.push($scope.proveedor);

				} else {
					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "warning",
						html:true,
						animation: false
					});
				}

				$scope.proveedores = AppService.listProveedores().data;
	
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Proveedores",
					   text: data.message,
						type: "error",
						html:true,
						animation: false
					});
			});

			$scope.proveedor = undefined;

			$location.url("/proveedores");

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
				
		var form_ready = true;
		
		if(angular.isDefined($scope.proveedor["nombre_empresa"])) {
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
			$scope.nombre_empresa_placeholder = "Ingrese nombre empresa";
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_empresa_placeholder = "Falta nombre empresa";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.proveedor["direccion"])) {
			$scope.form_group_direccion.pop('has-error');
			$scope.form_group_direccion.push('has-success');
			$scope.direccion_placeholder = "Ingrese descripcion";
		} else {
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_direccion.push('has-error');
			$scope.direccion_placeholder = "Falta descripcion";
			angular.element('#inputDireccion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.proveedor["telefono"])) {
			$scope.form_group_telefono.pop('has-error');
			$scope.form_group_telefono.push('has-success');
			$scope.telefono_placeholder = "Ingrese telefono";
		} else {
			$scope.form_group_telefono.pop('has-success');
			$scope.form_group_telefono.push('has-error');
			$scope.telefono_placeholder = "Falta telefono";
			angular.element('#inputTelefono').trigger('focus');
			form_ready = false;
		}	
				
		if(form_ready==true) {

			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_direccion.pop('has-success');
			$scope.form_group_telefono.pop('has-success');
										
			$scope.proveedores.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
																				
					$http({
					  method: 'post',
					  url: 'Administracion/Proveedores/Editar',
					  data: $.param({'nombre_empresa' : $scope.proveedor["nombre_empresa"], 'direccion' : $scope.proveedor["direccion"] , 'telefono': $scope.proveedor["telefono"], 'id_proveedor' : $scope.proveedor["id"] }),
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

			$scope.proveedor = undefined;

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
				  url: 'Administracion/Proveedores/Borrar',
				  data: $.param({'id_proveedor' : $routeParams.id}),
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

		$scope.proveedor = undefined;
				
		$location.url("/proveedores");
					
	}
			
})