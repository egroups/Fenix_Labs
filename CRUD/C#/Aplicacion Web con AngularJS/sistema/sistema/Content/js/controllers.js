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
		  url: "/CRUD/ListarProductos",
		  data: {},
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
		  url: "/CRUD/ListarProveedores",
		  data: {},
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
		  url: "/CRUD/ListarUsuarios",
		  data: {},
		  dataType: 'json',
		  async: false,
		  success: function(result){idata = result;}
		});
		return idata;
    }
  };
});

app.controller("appController", function appController($scope,$http,$location,AppService,loginService){
				
	$scope.productos = [];
	$scope.proveedores = [];
	$scope.usuarios = [];

	$scope.productos = AppService.listProductos().data;
	$scope.proveedores = AppService.listProveedores().data;
	$scope.usuarios = AppService.listUsuarios().data;

	$scope.logout=function(){
		loginService.logout();
	}

	$scope.cancelarEdicionProducto = function() {
		$location.url("/productos");
	}

	$scope.cancelarEdicionProveedor = function() {
		$location.url("/proveedores");
	}

	$scope.cancelarEdicionUsuario = function() {
		$location.url("/usuarios");
	}
					
})

app.controller('LoginController',function addController($scope,$location,loginService) {
	
	$scope.usuario = {};

	var connected=loginService.islogged();
	
	if(connected==true) {
		$location.path('/administracion');
	}

	$scope.iniciarSesion = function(){
		loginService.login($scope);
	};
})

app.controller("AdministracionController", function addController($scope,$http,$filter,$routeParams,$location,AppService,loginService){

	$scope.user_login = loginService.getUsername();

	var contenido = "";

    var idata;
	$.ajax({
	  type: 'POST',
	  url: "Cuenta/CheckTipoUsuario",
	  data: {'username' : $scope.user_login},
	  dataType: 'json',
	  async: false,
	  success: function(result){idata = result;}
	});

	var tipo_usuario = idata["message"];

	contenido = "Bienvenido "+tipo_usuario+" "+$scope.user_login+" a la administracion";

	$scope.welcome = contenido;

})