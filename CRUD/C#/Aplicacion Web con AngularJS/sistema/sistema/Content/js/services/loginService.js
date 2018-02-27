
app.factory('loginService',function($http, $location){
	return{
		login:function(scope){

			$http({
			  method: 'post',
			  url: "Cuenta/IngresoUsuario",
			  data: $.param({'username' : scope.usuario["nombre"], 'password' : scope.usuario["clave"] }),
			  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
			}).
			success(function(data, status, headers, config) {

				if(data.message=="1"){
					
					$http({
					  method: 'post',
					  url: "Cuenta/GenerarCookie",
					  data: $.param({'username' : scope.usuario["nombre"], 'password' : scope.usuario["clave"] }),
					  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
					}).
					success(function(data, status, headers, config) {

						sessionStorage.setItem("uid",data.message);

						$http({
						  method: 'post',
						  url: "Cuenta/CheckTipoUsuario",
						  data: $.param({'username' : scope.usuario["nombre"] }),
						  headers: {'Content-Type': 'application/x-www-form-urlencoded'}
						}).
						success(function(data, status, headers, config) {
							var tipo_usuario = data.message;
												
							swal({
								title: 'Iniciar sesion',
								text: "Bienvenido "+ tipo_usuario + " " + scope.usuario["nombre"] + " a la administracion",
								type:'success',
								html:true,
								animation: false
							});
							
							$location.path('/administracion');
						});

					});	

				} else {
					swal({
						title: 'Iniciar sesion',
						text: "Login incorrecto",
						type:'warning',
						html:true,
						animation: false
					});
					$location.path('/login');
				}
				
			});

		},
		logout:function(){
			sessionStorage.removeItem("uid");
			swal({
				title: 'Cerrar sesion',
				text: "La sesion ha sido cerrada",
				type:'success',
				html:true,
				animation: false
			});
			$location.path('/login');
		},
		logout_silent:function(){
			sessionStorage.removeItem("uid");
		},
		islogged:function(){

			if (sessionStorage.getItem("uid") != null) {

		      var contenido = sessionStorage.getItem("uid");
		      var idata;
		      
		      $.ajax({
		        type: 'POST',	
		        async : true,
		        url: "Cuenta/VerificarCookie",
		        data: {'contenido' : contenido},
		        dataType: 'json',
		        async: false,
		        success: function(result){idata = result;}
		      });

		      var respuesta = idata["message"];

		      if(respuesta=="1") {
		      	return true;
		      } else {
		      	return false;
		      }

			} else {
				return false;
			}

		},
		getUsername:function(){
			if (sessionStorage.getItem("uid") != null) {

		      var contenido = sessionStorage.getItem("uid");
		      var idata;
		      
		      $.ajax({
		        type: 'POST',	
		        async : true,
		        url: "Cuenta/GetUsernameInCookie",
		        data: {'contenido' : contenido},
		        dataType: 'json',
		        async: false,
		        success: function(result){idata = result;}
		      });

		      var username = idata["message"];

		      return username;

			} 
		}
	}

});