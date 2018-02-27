<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class LoginController extends Controller
{
    public function indexAction()
    {
    	if($this->get("sistema.seguridad")->validar_session()) {
    		return $this->redirect($this->generateUrl("sistema_administracion"));
    	} else {
    		return $this->render("SistemaBundle:Login:index.html.twig");
    	}
    }

    public function ingresoUsuarioAction(Request $request) {
    	if($this->get("sistema.seguridad")->validar_session()) {
    		return $this->redirect($this->generateUrl("sistema_administracion"));
    	} else {
	    	if($request->getMethod()=="POST") {
	    		$mensaje = "";
	    		$tipo = "";
	    		$url = $this->generateUrl("sistema_login");
	    		$username = $request->get("username");
	    		$password = md5($request->get("password"));
	    		$conexion = $this->get("sistema.conexion");
	    		if($conexion->ingreso_usuario($username,$password)) {
	    			$nombre_tipo = $conexion->detectar_tipo_usuario($username);
	    			$content = base64_encode($username.":".$password);
	    			$session = $request->getSession();
	    			$session->set("login",$content);
	    			$mensaje = "Bienvenido a la administracion $nombre_tipo $username";
	    			$tipo = "success";
	    		} else {
	    			$mensaje = "Login fallido";
	    			$tipo = "error";
	    		}
	    		$mensaje_listo = $this->get("sistema.funciones")->mensaje("Login",$mensaje,$tipo);
	    		$this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
	    		if($tipo=="success") {
	    			return $this->redirect($this->generateUrl("sistema_administracion"));
	    		} else {
	    			return $this->redirect($this->generateUrl("sistema_login"));
	    		}
	    	} else {
	    		return $this->render("SistemaBundle:Login:index.html.twig");
	    	}
    	}
    }

    public function logOutAction(Request $request) {
    	if($request->getMethod()=="GET") {
			$session = $request->getSession();
			$session->set("login","");
			$mensaje_listo = $this->get("sistema.funciones")->mensaje("Cerrar Sesión","La sesión ha sido cerrada","success");
			$this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
    		return $this->redirect($this->generateUrl("sistema_login"));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_administracion"));
    	}
    }

}
