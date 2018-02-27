<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class UsuariosController extends Controller
{
    public function indexAction()
    {
    	if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                $conexion = $this->get("sistema.conexion");
                $usuarios = $conexion->buscar_usuarios("");
        		$cantidad_usuarios = count($usuarios);
            	return $this->render("SistemaBundle:Usuarios:agregar.html.twig",array("usuarios"=>$usuarios,"cantidad_usuarios"=>$cantidad_usuarios));
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                
            }
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }

    public function buscarUsuariosAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                if($request->getMethod()=="POST") {
                    $patron = $request->get("nombre_buscar");
                    $conexion = $this->get("sistema.conexion");
                    $usuarios = $conexion->buscar_usuarios("");
                    $cantidad_usuarios = count($usuarios);
                    $usuarios_encontrados = $conexion->buscar_usuarios($patron);
                    $cantidad_usuarios_encontrados = count($usuarios_encontrados);
                    return $this->render("SistemaBundle:Usuarios:agregar.html.twig",
                                            array("buscador_activo"=>true,"usuarios_encontrados"=>$usuarios_encontrados,
                                                  "cantidad_usuarios_encontrados"=>$cantidad_usuarios_encontrados,"usuarios"=>$usuarios,"cantidad_usuarios"=>$cantidad_usuarios));
                } else {
                   return $this->redirect($this->generateUrl("sistema_usuarios"));
                }
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                  
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function cargarEdicionUsuarioAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                $conexion = $this->get("sistema.conexion");
                $usuario = $conexion->cargarUsuario($id);
                $usuarios = $conexion->buscar_usuarios("");
                $cantidad_usuarios = count($usuarios);
                return $this->render("SistemaBundle:Usuarios:editar.html.twig",array("usuarios"=>$usuarios,"cantidad_usuarios"=>$cantidad_usuarios,"usuario"=>$usuario));
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                    
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarBorradoUsuarioAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                $conexion = $this->get("sistema.conexion");
                $usuario = $conexion->cargarUsuario($id);
                return $this->render("SistemaBundle:Usuarios:borrar.html.twig",array("usuario"=>$usuario));
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                     
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function agregarUsuarioAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                if($request->getMethod()=="POST") {

                    $conexion = $this->get("sistema.conexion");

                    $nombre_usuario = $request->get("nombre_usuario");
                    $password = $request->get("password");
                    $tipo_usuario = $request->get("tipo");
                    $fecha_registro = $this->get("sistema.funciones")->fecha_actual();

                    $mensaje = "";
                    $tipo = "";

                    if($nombre_usuario!="" && $password!="" && is_numeric($tipo_usuario) && fecha_registro!="") {
                        $password = md5($password);
                        if($conexion->agregarUsuario($nombre_usuario,$password,$tipo,$fecha_registro)) {
                            $mensaje = "Usuario agregado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "Faltan datos";
                        $tipo = "warning"; 
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                    return $this->redirect($this->generateUrl("sistema_usuarios"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_usuarios"));
                }
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                  
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function editarUsuarioAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                if($request->getMethod()=="POST") {

                    $conexion = $this->get("sistema.conexion");

                    $id_usuario = $request->get("id_usuario");
                    $tipo_usuario = $request->get("tipo");

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id_usuario) && is_numeric($tipo_usuario)) {
                        if($conexion->asignarUsuario($id_usuario,$tipo_usuario)) {
                            $mensaje = "Usuario editado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "Faltan datos";
                        $tipo = "warning"; 
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                    return $this->redirect($this->generateUrl("sistema_usuarios"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_usuarios"));
                }
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                  
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function borrarUsuarioAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {
                if($request->getMethod()=="POST") {
                    if ($request->request->has("borrar_usuario")) {

                        $conexion = $this->get("sistema.conexion");

                        $id_usuario = $request->get("id_usuario");

                        $mensaje = "";
                        $tipo = "";

                        if(is_numeric($id_usuario)) {
                            if($conexion->borrarUsuario($id_usuario)) {
                                $mensaje = "Usuario borrado";
                                $tipo = "success";
                            } else {
                                $mensaje = "Ha ocurrido un error en la base de datos";
                                $tipo = "error";
                            }
                        } else {
                            $mensaje = "ID Invalido";
                            $tipo = "warning";
                        }

                        $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios",$mensaje,$tipo);
                        $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                        return $this->redirect($this->generateUrl("sistema_usuarios"));
                    }
                    elseif ($request->request->has("volver_usuario")) {
                        return $this->redirect($this->generateUrl("sistema_usuarios"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_usuarios")); 
                    }
                } else {
                    return $this->redirect($this->generateUrl("sistema_usuarios"));
                }
            } else {
                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios","Acceso Denegado","error");
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                return $this->redirect($this->generateUrl("sistema_administracion"));                  
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
