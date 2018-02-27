<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class DefaultController extends Controller
{
    public function indexAction()
    {
    	if($this->get('sistema.seguridad')->validar_session()) {
    		return $this->redirect($this->generateUrl("sistema_administracion"));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }
}
