app.controller("AgregarUsuarioController", function addController($scope,$http,$location,$route,AppService,$window,loginService){
	
	$scope.user_login = loginService.getUsername();

    var idata;
	$.ajax({
	  type: 'POST',
	  url: 'Cuenta/CheckTipoUsuario',
	  data: {'username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="administrador") {
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

		var form_ready = true;
		
		if(angular.isDefined($scope.usuario["nombre_usuario"])) {
			$scope.form_group_nombre.pop('has-error');
			$scope.form_group_nombre.push('has-success');
			$scope.nombre_usuario_placeholder = "Ingrese nombre usuario";
		} else {
			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_nombre.push('has-error');
			$scope.nombre_usuario_placeholder = "Falta nombre usuario";
			angular.element('#inputNombre').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.usuario["password"])) {
			$scope.form_group_password.pop('has-error');
			$scope.form_group_password.push('has-success');
			$scope.password_placeholder = "Ingrese password";
		} else {
			$scope.form_group_password.pop('has-success');
			$scope.form_group_password.push('has-error');
			$scope.password_placeholder = "Falta password";
			angular.element('#inputDescripcion').trigger('focus');
			form_ready = false;
		}	
				
		if(angular.isDefined($scope.usuario["tipo"])) {
			$scope.form_group_tipo.pop('has-error');
			$scope.form_group_tipo.push('has-success');
		} else {
			$scope.form_group_tipo.pop('has-success');
			$scope.form_group_tipo.push('has-error');
			angular.element('#inputTipo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$scope.form_group_nombre.pop('has-success');
			$scope.form_group_password.pop('has-success');
			$scope.form_group_tipo.pop('has-success');

			$scope.usuario["fecha_registro"] = fecha_actual();
						
			$http({
			  method: 'post',
			  url: 'Administracion/Usuarios/Agregar',
			  data: $.param({'nombre_usuario' : $scope.usuario["nombre_usuario"], 'password' : $scope.usuario["password"] , 'tipo': $scope.usuario["tipo"], 'fecha_registro' : $scope.usuario["fecha_registro"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {
				if(data.success){
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "success" 
					});
					$scope.usuarios.push($scope.usuario);
				} else {
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "warning" 
					});
				}

				$scope.usuarios = AppService.listUsuarios().data;	
				
			}).
			error(function(data, status, headers, config) {
					swal({ 
					  title: "Usuarios",
					   text: data.message,
						type: "error" 
					});
			});

			$scope.usuario = undefined;
				
			$location.url("/usuarios");
															
		}		
								
	}
})

app.controller("BorrarUsuarioController", function removeController($scope,$http,$filter,$routeParams,$location,AppService,loginService){

	$scope.user_login = loginService.getUsername();

	var idata;
	$.ajax({
	    type: 'POST',
	    url: 'Cuenta/CheckTipoUsuario',
	    data: { 'username': $scope.user_login },
	    dataType: 'json',
	    async: false,
	    success: function (result) { idata = result; }
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="administrador") {
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
				  url: 'Administracion/Usuarios/Borrar',
				  data: $.param({'id_usuario' : $routeParams.id}),
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

		$scope.usuario = undefined;	
				
		$location.url("/usuarios");
					
	}
			
})

app.controller("EditarUsuarioController", function editController($scope,$http,$routeParams,$filter,$location,AppService,loginService){

	$scope.user_login = loginService.getUsername();

	var idata;
	$.ajax({
	    type: 'POST',
	    url: 'Cuenta/CheckTipoUsuario',
	    data: { 'username': $scope.user_login },
	    dataType: 'json',
	    async: false,
	    success: function (result) { idata = result; }
	});

	var tipo_usuario = idata["message"];

	if(tipo_usuario!="administrador") {
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
		
		var form_ready = true;
						
		if(angular.isDefined($scope.usuario["tipo"])) {
			$scope.form_group_tipo.pop('has-error');
			$scope.form_group_tipo.push('has-success');
		} else {
			$scope.form_group_tipo.pop('has-success');
			$scope.form_group_tipo.push('has-error');
			angular.element('#inputTipo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$scope.form_group_tipo.pop('has-success');
										
			$scope.usuarios.forEach(function(element, index, array){
				
				if(element.id == $routeParams.id){
																				
					$http({
					  method: 'post',
					  url: 'Administracion/Usuarios/Editar',
					  data: $.param({'id_usuario':$scope.usuario["id"],'tipo' : $scope.usuario["tipo"]}),
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

			$scope.usuario = undefined;
			
			$location.url("/usuarios");
					
		}			
			
	}
})