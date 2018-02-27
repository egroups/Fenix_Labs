<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Services;

use Doctrine\ORM\EntityManager;
use Symfony\Component\HttpFoundation\Session\Session;

class Seguridad
{

	private $em;
    private $session;

    public function __construct(EntityManager $em,Session $session)
    {
    	$this->em = $em;
    	$this->session = $session;
    }

    public function validar_session(){
        $contenido = base64_decode($this->session->get('login'));
        if($contenido!="") {
			$split = explode(":", $contenido);
			$username = $split[0];
			$password = $split[1];
	    	$check = $this->em->getRepository("SistemaBundle:Usuarios")->findOneBy(array("usuario"=>$username,"clave"=>$password));
	    	if($check) {
	    		return true;
	    	} else {
	    		return false;
	    	}
    	} else {
    		return false;
    	}
    }

    public function validar_session_admin(){
        $contenido = base64_decode($this->session->get('login'));
        if($contenido!="") {
            $split = explode(":", $contenido);
            $username = $split[0];
            $password = $split[1];
            $check = $this->em->getRepository("SistemaBundle:Usuarios")->findOneBy(array("usuario"=>$username,"clave"=>$password));
            if($check) {
                $query = $this->em->createQuery("SELECT u.id,u.tipo FROM SistemaBundle:Usuarios u WHERE u.usuario = :username"); 
                $query->setParameter('username',$username);
                $data = $query->getResult(); 
                $tipo = $data[0]["tipo"];
                $nombre_tipo = "";
                if($tipo=="1") {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public function recibirUsuarioEnSession(){
        $contenido = base64_decode($this->session->get('login'));
		$split = explode(":", $contenido);
		$username = $split[0];
		$password = $split[1];
		return $username;
    }

}