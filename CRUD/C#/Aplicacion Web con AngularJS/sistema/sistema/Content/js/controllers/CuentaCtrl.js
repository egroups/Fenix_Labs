app.controller("CambiarUsuarioController", function addController($scope,$http,$location,$route,$window,AppService,loginService){
	
	$scope.textButton = "Cambiar Usuario";
	$scope.usuario = {};
	
	$scope.username_placeholder = "Ingrese usuario";
	$scope.new_username_placeholder = "Ingrese nuevo usuario";
	$scope.password_placeholder = "Ingrese password";
	
	$scope.form_group_username = [];
	$scope.form_group_new_username = [];
	$scope.form_group_password = [];
		
	$scope.usuario.nombre = loginService.getUsername();

	$scope.changeUsername = function(){

		var form_ready = true;
		
		if(angular.isDefined($scope.usuario["nombre"])) {
			$scope.form_group_username.pop('has-error');
			$scope.form_group_username.push('has-success');
			$scope.username_placeholder = "Ingrese nombre usuario";
		} else {
			$scope.form_group_username.pop('has-success');
			$scope.form_group_username.push('has-error');
			$scope.username_placeholder = "Falta nombre usuario";
			angular.element('#inputUsuario').trigger('focus');
			form_ready = false;
		}
				
		if(angular.isDefined($scope.usuario["nuevo_usuario"])) {
			$scope.form_group_new_username.pop('has-error');
			$scope.form_group_new_username.push('has-success');
			$scope.new_username_placeholder = "Ingrese usuario nuevo";
		} else {
			$scope.form_group_new_username.pop('has-success');
			$scope.form_group_new_username.push('has-error');
			$scope.new_username_placeholder = "Falta usuario nuevo";
			angular.element('#inputNuevoUsuario').trigger('focus');
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
			angular.element('#inputPassword').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$scope.form_group_username.pop('has-success');
			$scope.form_group_new_username.pop('has-success');
			$scope.form_group_password.pop('has-success');

			$http({
			  method: 'post',
			  url: 'Cuenta/CambiarUsuario',
			  data: $.param({'username' : $scope.usuario["nombre"], 'new_username' : $scope.usuario["nuevo_usuario"] , 'password': $scope.usuario["password"] }),
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
						$window.location.reload(); 
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

app.controller("CambiarPasswordController", function addController($scope,$http,$location,$route,$window,AppService,loginService){
	
	$scope.textButton = "Cambiar Password";
	$scope.usuario = {};
	
	$scope.username_placeholder = "Ingrese usuario";
	$scope.anterior_password_placeholder = "Ingrese anterior password";
	$scope.new_password_placeholder = "Ingrese nuevo password";
	
	$scope.form_group_username = [];
	$scope.form_group_anterior_password = [];
	$scope.form_group_new_password = [];

	$scope.usuario.nombre = loginService.getUsername();
			
	$scope.changePassword = function(){
	
		var form_ready = true;
		
		if(angular.isDefined($scope.usuario["nombre"])) {
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
			$scope.form_group_new_password.pop('has-error');
			$scope.form_group_new_password.push('has-success');
			$scope.new_password_placeholder = "Ingrese nuevo password";
		} else {
			$scope.form_group_new_password.pop('has-success');
			$scope.form_group_new_password.push('has-error');
			$scope.new_password_placeholder = "Falta nuevo password";
			angular.element('#inputNuevo').trigger('focus');
			form_ready = false;
		}
		
		if(form_ready==true) {

			$scope.form_group_username.pop('has-success');
			$scope.form_group_anterior_password.pop('has-success');
			$scope.form_group_new_password.pop('has-success');

			$http({
			  method: 'post',
			  url: 'Cuenta/CambiarPassword',
			  data: $.param({'username' : $scope.usuario["nombre"], 'anterior_password' : $scope.usuario["anterior_password"] , 'new_password': $scope.usuario["nuevo_password"] }),
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
						$window.location.reload(); 
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