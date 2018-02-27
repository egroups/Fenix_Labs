<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpKernel\Exception\NotFoundHttpException;
use Sistema\Bundle\Form\FormAgregarProveedor;
use Sistema\Bundle\Form\FormEditarProveedor;
use Sistema\Bundle\Form\FormBorrarProveedor;
use Sistema\Bundle\Form\FormBuscador;

class ProveedoresController extends Controller
{

    public function listarAction(Request $request)
    {
        if($this->get("sistema.seguridad")->validar_session()) {

            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

            $conexion = $this->get("sistema.conexion");
            $proveedores = $conexion->listarProveedores("");
            $cantidad_proveedores = count($proveedores);

            if($request->getMethod()=="POST") {
                $form = $this->createForm(FormBuscador::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();
                $patron = $campos["nombreBuscar"];
                $conexion = $this->get("sistema.conexion");
                $cantidad_proveedores = count($proveedores);
                $proveedores_encontrados = $conexion->listarProveedores($patron);
                $cantidad_proveedores_encontrados = count($proveedores_encontrados);
                return $this->render("SistemaBundle:Proveedores:listar.html.twig",
                                        array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"proveedores_encontrados"=>$proveedores_encontrados,
                                              "cantidad_proveedores_encontrados"=>$cantidad_proveedores_encontrados,"cantidad_proveedores"=>$cantidad_proveedores));
            } else {
                $form = $this->createForm(FormBuscador::class,array());
                return $this->render("SistemaBundle:Proveedores:listar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"proveedores_encontrados"=>$proveedores,"cantidad_proveedores_encontrados"=>$cantidad_proveedores,"cantidad_proveedores"=>$cantidad_proveedores));
            }

        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarEdicionProveedorAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
            $conexion = $this->get("sistema.conexion");

            $proveedor = $conexion->cargarProveedor($id);

            if($proveedor == null) {
                throw new NotFoundHttpException("Proveedor no encontrado");
            }

            $proveedores = $conexion->listarProveedores("");
            $cantidad_proveedores = count($proveedores);
            $form = $this->createForm(FormEditarProveedor::class,array("proveedor"=>$proveedor));
            $form_buscador = $this->createForm(FormBuscador::class,array());
            return $this->render("SistemaBundle:Proveedores:editar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"form_buscador"=>$form_buscador->createView(),"proveedores"=>$proveedores,"cantidad_proveedores"=>$cantidad_proveedores,"proveedor"=>$proveedor));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarBorradoProveedorAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
            $conexion = $this->get("sistema.conexion");

            $proveedor = $conexion->cargarProveedor($id);

            if($proveedor == null) {
                throw new NotFoundHttpException("Proveedor no encontrado");
            }

            $form = $this->createForm(FormBorrarProveedor::class,array("proveedor"=>$proveedor));
            return $this->render("SistemaBundle:Proveedores:borrar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"proveedor"=>$proveedor));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function agregarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {

            $conexion = $this->get("sistema.conexion");

            if($request->getMethod()=="POST") {

                $form = $this->createForm(FormAgregarProveedor::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();

                $nombre = $campos["nombre"];
                $direccion = $campos["direccion"];
                $telefono = $campos["telefono"];
                $fecha_registro = $this->get("sistema.funciones")->fecha_actual();

                $mensaje = "";
                $tipo = "";

                if($nombre!="" && $direccion!="" && is_numeric($telefono) && fecha_registro!="") {
                    if($conexion->comprobar_existencia_proveedor_crear($nombre)) {
                        $mensaje = "El proveedor $nombre ya existe";
                        $tipo = "warning"; 
                    } else {
                        if($conexion->agregarProveedor($nombre,$direccion,$telefono,$fecha_registro)) {
                            $mensaje = "Proveedor agregado";
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

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo == "success") {
                    return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_agregar_proveedor"));
                }

            } else {
                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
                $form = $this->createForm(FormAgregarProveedor::class,array());
                return $this->render("SistemaBundle:Proveedores:agregar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView()));

            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function editarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $form = $this->createForm(FormEditarProveedor::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();

                $id = $campos["id"];
                $nombre = $campos["nombre"];
                $direccion = $campos["direccion"];
                $telefono = $campos["telefono"];

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id) && $nombre!="" && $direccion!="" && is_numeric($telefono)) {
                    if($conexion->comprobar_existencia_proveedor_editar($id,$nombre)) {
                        $mensaje = "El proveedor $nombre ya existe";
                        $tipo = "warning"; 
                    } else {
                        if($conexion->editarProveedor($id,$nombre,$direccion,$telefono)) {
                            $mensaje = "Proveedor editado";
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

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo == "success") {
                    return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_cargar_editar_proveedor",array("id"=>$id)));
                }

            } else {
                return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function borrarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $form = $this->createForm(FormBorrarProveedor::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();

                if ($form->get('borrarProveedor')->isClicked()) {

                    $conexion = $this->get("sistema.conexion");

                    $id = $campos["id"];

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id)) {
                        if($conexion->borrarProveedor($id)) {
                            $mensaje = "Proveedor borrado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "ID Inválido";
                        $tipo = "warning";
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                    if($tipo == "success") {
                        return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_cargar_borrar_proveedor",array("id"=>$id)));
                    }

                }
                elseif ($form->get('volverLista')->isClicked()) {
                    return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_listar_proveedores")); 
                }
            } else {
                return $this->redirect($this->generateUrl("sistema_listar_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
