<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class AdministracionController extends Controller
{
    public function indexAction()
    {
    	if($this->get('sistema.seguridad')->validar_session()) {
	    	$nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
	        $conexion = $this->get('sistema.conexion');
	        $nombre_tipo = $conexion->detectar_tipo_usuario($nombre_usuario);
	        return $this->render('SistemaBundle:Administracion:index.html.twig',array("nombre_usuario"=>$nombre_usuario,"tipo"=>$nombre_tipo));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }
}
