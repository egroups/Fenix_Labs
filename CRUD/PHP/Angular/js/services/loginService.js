
app.factory('loginService',function($http, $location, sessionService){
	return{
		login:function(data,scope){
			var $promise=$http.post('includes/user.php',data); //send data to user.php
			$promise.then(function(msg){
				var uid=msg.data;
				if(uid){
					sessionService.set('uid',uid);

				    var idata;
					$.ajax({
					  type: 'POST',
					  url: "includes/ABM.php",
					  data: {'type' : 'checkTipoUsuario','username' : sessionService.getUsername("uid")},
					  dataType: 'json',
					  async: false,
					  success: function(result){idata = result;}
					});

					var tipo_usuario = idata["message"];
										
					swal({
						title: 'Iniciar sesion',
						text: "Bienvenido "+ tipo_usuario + " " + sessionService.getUsername("uid") + " a la administracion",
						type:'success',
						html:true,
						animation: false
					});
					
					$location.path('/administracion');
				}	       
				else  {
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
			sessionService.destroy('uid');
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
			sessionService.destroy('uid');
			$location.path('/login');
		},
		islogged:function(){
			var $checkSessionServer=$http.post('includes/check_session.php');
			return $checkSessionServer;
			/*
			if(sessionService.get('user')) return true;
			else return false;
			*/
		}
	}

});