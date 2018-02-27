app.controller("EstadisticasController", function addController($scope,$http,$location,$route,$window,AppService,loginService){
	
  var idata;
  
  $.ajax({
    type: 'GET',
    url: "includes/Estadisticas.php",
    async: false,
    success: function(result){idata = result;}
  });

  $scope.contenido = idata;
		
})