<?php 
	$user=json_decode(file_get_contents('php://input'));  //get user from 

	$sql = "select id_usuario from usuarios where usuario='" . $user->name . "' and clave='" . md5($user->password) . "'";
	$conexion = new mysqli("localhost","root","","sistema"); 
	$consulta = mysqli_query($conexion,$sql);
	$rows = mysqli_num_rows($consulta);
	if($rows > 0) {
		session_start();
		$_SESSION['uid']=uniqid('ang_').":".$user->name;
		print $_SESSION['uid'];
	}
	mysqli_close($conexion);
?>