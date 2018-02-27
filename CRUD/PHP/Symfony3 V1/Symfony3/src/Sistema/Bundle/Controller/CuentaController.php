<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class CuentaController extends Controller
{
    public function cargarCambiarUsuarioAction()
    {
    	if($this->get('sistema.seguridad')->validar_session()) {
	    	$nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
	        $conexion = $this->get('sistema.conexion');
	        $id = $conexion->cargarIdUsuario($nombre_usuario);
            $usuario = $conexion->cargarUsuario($id);
	        return $this->render('SistemaBundle:Cuenta:cambiar_usuario.html.twig',array("usuario"=>$usuario));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }

    public function cargarCambiarPasswordAction()
    {
        if($this->get('sistema.seguridad')->validar_session()) {
            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
            $conexion = $this->get('sistema.conexion');
            $id = $conexion->cargarIdUsuario($nombre_usuario);
            $usuario = $conexion->cargarUsuario($id);
            return $this->render('SistemaBundle:Cuenta:cambiar_password.html.twig',array("usuario"=>$usuario));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cambiarUsuarioAction(Request $request) {

        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $id_usuario = $request->get("id_usuario");
                $username = $request->get("username");
                $new_username = $request->get("new_username");
                $password = $request->get("password");

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_usuario) && $username!="" && $new_username!="" && $password!="") {
                    $password = md5($password);
                    if($conexion->ingreso_usuario($username,$password)) {
                        if($conexion->cambiarNombreUsuario($id_usuario,$new_username)) {
                            $mensaje = "El usuario ha sido cambiado, reinicie la aplicación";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "warning";
                        }
                    } else {
                        $mensaje = "Login Invalido";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Cambiar Usuario",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo=="success") {
                    $session = $request->getSession();
                    $session->set("login","");
                    return $this->redirect($this->generateUrl("sistema_login"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_cuenta_cargar_cambiar_usuario"));
                }
            } else {
                return $this->redirect($this->generateUrl("sistema_cuenta_cargar_cambiar_usuario"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cambiarPasswordAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $id_usuario = $request->get("id_usuario");
                $username = $request->get("username");
                $anterior_password = $request->get("anterior_password");
                $new_password = $request->get("new_password");
                
                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_usuario) && $username!="" && $anterior_password!="" && $new_password!="") {
                    $password = md5($anterior_password);
                    $new_password = md5($new_password);
                    if($conexion->ingreso_usuario($username,$password)) {
                        if($conexion->cambiarPasswordUsuario($id_usuario,$new_password)) {
                            $mensaje = "El password ha sido cambiado, reinicie la aplicación";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "warning";
                        }
                    } else {
                        $mensaje = "Login Invalido";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Cambiar Password",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo=="success") {
                    $session = $request->getSession();
                    $session->set("login","");
                    return $this->redirect($this->generateUrl("sistema_login"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_cuenta_cargar_cambiar_password"));
                }

                return $this->redirect($this->generateUrl("sistema_login"));
            } else {
                return $this->redirect($this->generateUrl("sistema_cuenta_cargar_cambiar_password"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
