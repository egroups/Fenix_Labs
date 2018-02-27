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
		
		var form_ready = true;
		
		if(angular.isDefined($scope.producto["nombre_producto"])) {
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
			$scope.nombre_producto_placeholder = "Ingrese nombre producto";
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_producto_placeholder = "Falta nombre producto";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.producto["descripcion"])) {
			$scope.form_group_descripcion.pop('has-error');
			$scope.form_group_descripcion.push('has-success');
			$scope.descripcion_placeholder = "Ingrese descripcion";
		} else {
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_descripcion.push('has-error');
			$scope.descripcion_placeholder = "Falta descripcion";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["precio"])) {
			$scope.form_group_precio.pop('has-error');
			$scope.form_group_precio.push('has-success');
			$scope.precio_placeholder = "Ingrese precio";
		} else {
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_precio.push('has-error');
			$scope.precio_placeholder = "Falta precio";
			angular.element('#inputPrecio').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["proveedor"])) {
			$scope.form_group_proveedor.pop('has-error');
			$scope.form_group_proveedor.push('has-success');
		} else {
			$scope.form_group_proveedor.pop('has-success');
			$scope.form_group_proveedor.push('has-error');
			angular.element('#inputProveedor').trigger('focus');
			form_ready = false;
		}	
				
		if(form_ready==true) {

			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_proveedor.pop('has-success');

			var datos_proveedor = JSON.parse($scope.producto["proveedor"]);
			$scope.producto["fecha_registro"] = fecha_actual();
			$scope.producto["nombre_empresa"] = datos_proveedor["nombre_empresa"];
			$http({
			  method: 'post',
			  url: 'Administracion/Productos/Agregar',
			  data: $.param({'nombre_producto' : $scope.producto["nombre_producto"], 'descripcion' : $scope.producto["descripcion"] , 'precio': $scope.producto["precio"], 'id_proveedor' : datos_proveedor["id"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "success",
						html:true,
						animation: false 
					});

					$scope.productos.push($scope.producto);

				} else {
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "warning",
						html:true,
						animation: false 
					});
				}
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Productos",
					   text: data.message,
						type: "error",
						html:true,
						animation: false
					});
			});

			$scope.productos = AppService.listProductos().data;

			$scope.producto = undefined;

			$location.url("/productos");
															
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
		
		var form_ready = true;
		
		if(angular.isDefined($scope.producto["nombre_producto"])) {
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
			$scope.nombre_producto_placeholder = "Ingrese nombre producto";
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_producto_placeholder = "Falta nombre producto";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.producto["descripcion"])) {
			$scope.form_group_descripcion.pop('has-error');
			$scope.form_group_descripcion.push('has-success');
			$scope.descripcion_placeholder = "Ingrese descripcion";
		} else {
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_descripcion.push('has-error');
			$scope.descripcion_placeholder = "Falta descripcion";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["precio"])) {
			$scope.form_group_precio.pop('has-error');
			$scope.form_group_precio.push('has-success');
			$scope.precio_placeholder = "Ingrese precio";
		} else {
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_precio.push('has-error');
			$scope.precio_placeholder = "Falta precio";
			angular.element('#inputPrecio').trigger('focus');
			form_ready = false;
		}	
		
		if(angular.isDefined($scope.producto["proveedor"])) {
			$scope.form_group_proveedor.pop('has-error');
			$scope.form_group_proveedor.push('has-success');
		} else {
			$scope.form_group_proveedor.pop('has-success');
			$scope.form_group_proveedor.push('has-error');
			angular.element('#inputProveedor').trigger('focus');
			form_ready = false;
		}	
			
		if(form_ready==true) {

			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_descripcion.pop('has-success');
			$scope.form_group_precio.pop('has-success');
			$scope.form_group_proveedor.pop('has-success');

			$scope.productos.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
											
					var datos_proveedor = JSON.parse($scope.producto["proveedor"]);
					
					$scope.producto["nombre_empresa"] = datos_proveedor["nombre_empresa"];
									
					$http({
					  method: 'post',
					  url: 'Administracion/Productos/Editar',
					  data: $.param({'id_producto':$scope.producto["id"],'nombre_producto' : $scope.producto["nombre_producto"], 'descripcion' : $scope.producto["descripcion"] , 'precio': $scope.producto["precio"], 'id_proveedor' : datos_proveedor["id"] }),
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

			$scope.producto = undefined;
			
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
				  url: 'Administracion/Productos/Borrar',
				  data: $.param({'id_producto' : $routeParams.id}),
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

		$scope.producto = undefined;
				
		$location.url("/productos");
				
	}
			
})