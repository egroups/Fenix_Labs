<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Sistema\Bundle\Form\FormCambiarUsuario;
use Sistema\Bundle\Form\FormCambiarclave;

class CuentaController extends Controller
{

    public function cambiarUsuarioAction(Request $request) {

        if($this->get("sistema.seguridad")->validar_session()) {

            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $form = $this->createForm(FormCambiarUsuario::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();

                $id_usuario = $campos["id"];
                $username = $campos["usuario"];
                $new_username = $campos["nuevo_usuario"];
                $clave = $campos["actual_clave"];

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_usuario) && $username!="" && $new_username!="" && $clave!="") {
                    $clave = md5($clave);
                    if($conexion->ingreso_usuario($username,$clave)) {
                        if($conexion->cambiarNombreUsuario($id_usuario,$new_username)) {
                            $mensaje = "El usuario ha sido cambiado, reinicie la aplicación";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "warning";
                        }
                    } else {
                        $mensaje = "Login Inválido";
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
                    return $this->redirect($this->generateUrl("sistema_cuenta_cambiar_usuario"));
                }
            } else {

                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
                $conexion = $this->get('sistema.conexion');
                $id = $conexion->cargarIdUsuario($nombre_usuario);
                $usuario = $conexion->cargarUsuario($id);
                $form = $this->createForm(FormCambiarUsuario::class,array("usuario"=>$usuario));
                return $this->render('SistemaBundle:Cuenta:cambiar_usuario.html.twig',array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuario"=>$usuario));

            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cambiarClaveAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $form = $this->createForm(FormCambiarClave::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();

                $id_usuario = $campos["id"];
                $username = $campos["usuario"];
                $anterior_clave = $campos["actual_clave"];
                $new_clave = $campos["nueva_clave"];
                
                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_usuario) && $username!="" && $anterior_clave!="" && $new_clave!="") {
                    $clave = md5($anterior_clave);
                    $new_clave = md5($new_clave);
                    if($conexion->ingreso_usuario($username,$clave)) {
                        if($conexion->cambiarClaveUsuario($id_usuario,$new_clave)) {
                            $mensaje = "La clave ha sido cambiada, reinicie la aplicación";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "warning";
                        }
                    } else {
                        $mensaje = "Login Inválido";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Cambiar Clave",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo=="success") {
                    $session = $request->getSession();
                    $session->set("login","");
                    return $this->redirect($this->generateUrl("sistema_login"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_cuenta_cambiar_clave"));
                }

                return $this->redirect($this->generateUrl("sistema_login"));
            } else {

                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
                $conexion = $this->get('sistema.conexion');
                $id = $conexion->cargarIdUsuario($nombre_usuario);
                $usuario = $conexion->cargarUsuario($id);
                $form = $this->createForm(FormCambiarClave::class,array("usuario"=>$usuario));
                return $this->render('SistemaBundle:Cuenta:cambiar_clave.html.twig',array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuario"=>$usuario));

            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
