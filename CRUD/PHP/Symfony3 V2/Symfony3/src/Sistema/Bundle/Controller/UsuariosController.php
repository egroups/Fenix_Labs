<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpKernel\Exception\NotFoundHttpException;
use Sistema\Bundle\Form\FormAgregarUsuario;
use Sistema\Bundle\Form\FormEditarUsuario;
use Sistema\Bundle\Form\FormBorrarUsuario;
use Sistema\Bundle\Form\FormBuscador;

class UsuariosController extends Controller
{

    public function listarAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($this->get("sistema.seguridad")->validar_session_admin()) {

                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

                $conexion = $this->get("sistema.conexion");
                $usuarios = $conexion->listarUsuarios("");
                $cantidad_usuarios = count($usuarios);

                if($request->getMethod()=="POST") {
                    $form = $this->createForm(FormBuscador::class,array());
                    $form->handleRequest($request);
                    $campos = $form->getData();
                    $patron = $campos["nombreBuscar"];
                    $usuarios_encontrados = $conexion->listarUsuarios($patron);
                    $cantidad_usuarios_encontrados = count($usuarios_encontrados);
                    return $this->render("SistemaBundle:Usuarios:listar.html.twig",
                                            array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuarios_encontrados"=>$usuarios_encontrados,
                                                  "cantidad_usuarios_encontrados"=>$cantidad_usuarios_encontrados,"cantidad_usuarios"=>$cantidad_usuarios));
                } else {
                    $form = $this->createForm(FormBuscador::class,array());
                    return $this->render("SistemaBundle:Usuarios:listar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuarios_encontrados"=>$usuarios,"cantidad_usuarios_encontrados"=>$cantidad_usuarios,"cantidad_usuarios"=>$cantidad_usuarios));
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

                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

                $conexion = $this->get("sistema.conexion");

                $usuario = $conexion->cargarUsuario($id);

                if($usuario == null) {
                    throw new NotFoundHttpException("Usuario no encontrado");
                }

                $usuarios = $conexion->listarUsuarios("");
                $cantidad_usuarios = count($usuarios);
                $combo_tipos = $conexion->cargarComboTipoUsuario();
                $form = $this->createForm(FormEditarUsuario::class,array("combo_tipos"=>$combo_tipos,"usuario"=>$usuario));
                return $this->render("SistemaBundle:Usuarios:editar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuarios"=>$usuarios,"cantidad_usuarios"=>$cantidad_usuarios,"usuario"=>$usuario));
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
                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
                $conexion = $this->get("sistema.conexion");

                $usuario = $conexion->cargarUsuario($id);

                if($usuario == null) {
                    throw new NotFoundHttpException("Usuario no encontrado");
                }

                $form = $this->createForm(FormBorrarUsuario::class,array("usuario"=>$usuario));
                return $this->render("SistemaBundle:Usuarios:borrar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"usuario"=>$usuario));
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

                    $combo_tipos = $conexion->cargarComboTipoUsuario();

                    $form = $this->createForm(FormAgregarUsuario::class,array("combo_tipos"=>$combo_tipos));
                    $form->handleRequest($request);
                    $campos = $form->getData();

                    $nombre = $campos["nombre"];
                    $password = $campos["clave"];
                    $tipo_usuario = $campos["tipo"];

                    $fecha_registro = $this->get("sistema.funciones")->fecha_actual();

                    $mensaje = "";
                    $tipo = "";

                    if($nombre!="" && $password!="" && is_numeric($tipo_usuario) && fecha_registro!="") {
                        if($conexion->comprobar_existencia_usuario_crear($nombre)) {
                            $mensaje = "El usuario $nombre ya existe";
                            $tipo = "warning"; 
                        } else {
                            $password = md5($password);
                            if($conexion->agregarUsuario($nombre,$password,$tipo_usuario,$fecha_registro)) {
                                $mensaje = "Usuario agregado";
                                $tipo = "success";
                            } else {
                                $mensaje = "Ha ocurrido un error en la base de datos";
                                $tipo = "error";
                            }
                        }
                    } else {
                        $mensaje = "Faltan datos";
                        $tipo = "warning"; 
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                    if($tipo == "success") {
                        return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_agregar_usuario"));
                    }

                } else {
                    $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
                    $conexion = $this->get("sistema.conexion");
                    $combo_tipos = $conexion->cargarComboTipoUsuario();
                    $form = $this->createForm(FormAgregarUsuario::class,array("combo_tipos"=>$combo_tipos));
                    return $this->render("SistemaBundle:Usuarios:agregar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView()));
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

                    $combo_tipos = $conexion->cargarComboTipoUsuario();

                    $form = $this->createForm(FormEditarUsuario::class,array("combo_tipos"=>$combo_tipos));
                    $form->handleRequest($request);
                    $campos = $form->getData();

                    $id = $campos["id"];
                    $tipo_usuario = $campos["tipo"];

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id) && is_numeric($tipo_usuario)) {
                        if($conexion->asignarUsuario($id,$tipo_usuario)) {
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

                    if($tipo == "success") {
                        return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_cargar_editar_usuario",array("id"=>$id)));
                    }

                } else {
                    return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
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

                    $form = $this->createForm(FormBorrarUsuario::class,array());
                    $form->handleRequest($request);
                    $campos = $form->getData();

                    if ($form->get('borrarUsuario')->isClicked()) {

                        $conexion = $this->get("sistema.conexion");

                        $id = $campos["id"];

                        $mensaje = "";
                        $tipo = "";

                        if(is_numeric($id)) {
                            if($conexion->borrarUsuario($id)) {
                                $mensaje = "Usuario borrado";
                                $tipo = "success";
                            } else {
                                $mensaje = "Ha ocurrido un error en la base de datos";
                                $tipo = "error";
                            }
                        } else {
                            $mensaje = "ID Inválido";
                            $tipo = "warning";
                        }

                        $mensaje_listo = $this->get("sistema.funciones")->mensaje("Usuarios",$mensaje,$tipo);
                        $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                        if($tipo == "success") {
                            return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
                        } else {
                            return $this->redirect($this->generateUrl("sistema_cargar_borrar_usuario",array("id"=>$id)));
                        }

                    }
                    elseif ($form->get('volverLista')->isClicked()) {
                        return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_listar_usuarios")); 
                    }
                } else {
                    return $this->redirect($this->generateUrl("sistema_listar_usuarios"));
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
