//creamos nuestro modulo llamado app
var app = angular.module("app", []);

//hacemos el ruteo de nuestra aplicación
app.config(function($routeProvider){
	$routeProvider.when("/login", {
		templateUrl : "Content/templates/FormLogin.html",
		controller : "LoginController"
	})
	.when("/administracion/", {
		title: 'Administracion',
		templateUrl: "Content/templates/Administracion.html",
		controller : "AdministracionController"
	})
	.when("/productos/", {
		title: 'Productos',
		templateUrl: "Content/templates/FormAgregarProducto.html",
		controller : "AgregarProductoController"
	})
 	.when("/productos/:id/borrar", {
 		title: 'Eliminar producto',
 		templateUrl: "Content/templates/FormBorrarProducto.html",
 		controller : "BorrarProductoController"
 	})
 	.when("/productos/:id/editar", {
 		title: 'Editar producto',
 		templateUrl: "Content/templates/FormEditarProducto.html",
 		controller : "EditarProductoController"
 	})
	.when("/proveedores", {
		title: 'Proveedores',
		templateUrl: "Content/templates/FormAgregarProveedor.html",
		controller : "AgregarProveedorController"
	})
 	.when("/proveedores/:id/borrar", {
 		title: 'Eliminar proveedor',
 		templateUrl: "Content/templates/FormBorrarProveedor.html",
 		controller : "BorrarProveedorController"
 	})
 	.when("/proveedores/:id/editar", {
 		title: 'Editar proveedor',
 		templateUrl: "Content/templates/FormEditarProveedor.html",
 		controller : "EditarProveedorController"
 	})
	.when("/usuarios", {
		title: 'Usuarios',
		templateUrl: "Content/templates/FormAgregarUsuario.html",
		controller : "AgregarUsuarioController"
	})
 	.when("/usuarios/:id/borrar", {
 		title: 'Eliminar usuario',
 		templateUrl: "Content/templates/FormBorrarUsuario.html",
 		controller : "BorrarUsuarioController"
 	})
 	.when("/usuarios/:id/editar", {
 		title: 'Editar usuario',
 		templateUrl: "Content/templates/FormEditarUsuario.html",
 		controller : "EditarUsuarioController"
 	})
	.when("/cambiar_usuario", {
		title: 'Cambiar Usuario',
		templateUrl: "Content/templates/FormCambiarUsuario.html",
		controller : "CambiarUsuarioController"
	})
	.when("/cambiar_password", {
		title: 'Cambiar Password',
		templateUrl: "Content/templates/FormCambiarPassword.html",
		controller : "CambiarPasswordController"
	})
	.when("/estadisticas", {
		title: 'Estadisticas',
		templateUrl: "Content/templates/FormEstadisticas.html",
		controller : "EstadisticasController"
	})
 	.otherwise({ redirectTo : "/login"})
})

app.run(function($rootScope, $location, loginService){
	var routespermission=['/administracion','/productos','/productos/','/usuarios','/cambiar_usuario','/cambiar_password','/includes'];  //route that require login
	$rootScope.$on('$routeChangeStart', function(){
		routespermission.forEach(function(route) {
			var re = new RegExp(route);
			if (re.test($location.path())) {
				var connected=loginService.islogged();
				if(connected==false) {
					$location.path('/login');
				}
			}
		});
	});
});