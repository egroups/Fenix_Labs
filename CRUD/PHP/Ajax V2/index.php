<!-- Written By Ismael Heredia in the year 2016 -->

<?php  

include_once("includes/ABM.php");

if(verificar_cookie()) {
  header('Location: administracion.php');
}

?>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <!-- Bootstrap -->
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
	<link href="css/style.css" rel="stylesheet" type="text/css">
	<script src="js/jquery2.2.0.js"></script>
  <script src="js/app.js"></script>
    
  <script src="dist/sweetalert-dev.js"></script>
  <link rel="stylesheet" href="dist/sweetalert.css">
    
	<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
	<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
	<!--[if lt IE 9]>
		  <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
		  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
		<![endif]-->
  </head>
  <body>

	<div class="container-fluid">
	  <div class="panel login panel-default">
  		<div class="panel-heading">Login</div>
  			<div class="panel-body">
                <form action="" method="POST" class="form-horizontal" name="form_login">
                  <fieldset>
                    <legend>Datos</legend>
                    <div class="form-group" name="form-group-username">
                      <label for="inputTexto1" class="col-lg-2 control-label">Username</label>
                      <div class="col-lg-10">
                        <input class="form-control" id="inputUsername" name="username" placeholder="Ingrese usuario" type="text">
                      </div>
                    </div>
                    <div class="form-group" name="form-group-password">
                      <label for="inputTexto2" class="col-lg-2 control-label">Password</label>
                      <div class="col-lg-10">
                        <input class="form-control" id="inputPassword" name="password" placeholder="Ingrese password" type="password">
                      </div>
                    </div>
                    <div class="form-group">
                      <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" name="login" class="btn btn-primary">Ingresar</button>
                      </div>
                    </div>
                  </fieldset>
                </form>
        	</div>
	   </div>
    </div>
            
	<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
	<script src="bootstrap/js/jquery-1.11.2.min.js"></script>

	<!-- Include all compiled plugins (below), or include individual files as needed --> 
	<script src="bootstrap/js/bootstrap.js"></script>
  </body>
</html>