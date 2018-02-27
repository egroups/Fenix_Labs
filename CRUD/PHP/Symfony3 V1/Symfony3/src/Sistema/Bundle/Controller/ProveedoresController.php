<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProveedoresController extends Controller
{
    public function indexAction()
    {
    	if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
            $proveedores = $conexion->buscar_proveedores("");
    		$cantidad_proveedores = count($proveedores);
        	return $this->render("SistemaBundle:Proveedores:agregar.html.twig",array("proveedores"=>$proveedores,"cantidad_proveedores"=>$cantidad_proveedores));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }

    public function buscarProveedoresAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {
                $patron = $request->get("nombre_buscar");
                $conexion = $this->get("sistema.conexion");
                $proveedores = $conexion->buscar_proveedores("");
                $cantidad_proveedores = count($proveedores);
                $proveedores_encontrados = $conexion->buscar_proveedores($patron);
                $cantidad_proveedores_encontrados = count($proveedores_encontrados);
                return $this->render("SistemaBundle:Proveedores:agregar.html.twig",
                                        array("buscador_activo"=>true,"proveedores_encontrados"=>$proveedores_encontrados,
                                              "cantidad_proveedores_encontrados"=>$cantidad_proveedores_encontrados,"proveedores"=>$proveedores,"cantidad_proveedores"=>$cantidad_proveedores));
            } else {
               return $this->redirect($this->generateUrl("sistema_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function cargarEdicionProveedorAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
            $proveedor = $conexion->cargarProveedor($id);
            $proveedores = $conexion->buscar_proveedores("");
            $cantidad_proveedores = count($proveedores);
            return $this->render("SistemaBundle:Proveedores:editar.html.twig",array("proveedores"=>$proveedores,"cantidad_proveedores"=>$cantidad_proveedores,"proveedor"=>$proveedor));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarBorradoProveedorAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
            $proveedor = $conexion->cargarProveedor($id);
            return $this->render("SistemaBundle:Proveedores:borrar.html.twig",array("proveedor"=>$proveedor));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function agregarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $nombre_empresa = $request->get("nombre_empresa");
                $direccion = $request->get("direccion");
                $telefono = $request->get("telefono");
                $fecha_registro = $this->get("sistema.funciones")->fecha_actual();

                $mensaje = "";
                $tipo = "";

                if($nombre_empresa!="" && $direccion!="" && is_numeric($telefono) && fecha_registro!="") {
                    if($conexion->agregarProveedor($nombre_empresa,$direccion,$telefono,$fecha_registro)) {
                        $mensaje = "Proveedor agregado";
                        $tipo = "success";
                    } else {
                        $mensaje = "Ha ocurrido un error en la base de datos";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                return $this->redirect($this->generateUrl("sistema_proveedores"));
            } else {
                return $this->redirect($this->generateUrl("sistema_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function editarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $id_proveedor = $request->get("id_proveedor");
                $nombre_empresa = $request->get("nombre_empresa");
                $direccion = $request->get("direccion");
                $telefono = $request->get("telefono");

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_proveedor) && $nombre_empresa!="" && $direccion!="" && is_numeric($telefono)) {
                    if($conexion->editarProveedor($id_proveedor,$nombre_empresa,$direccion,$telefono)) {
                        $mensaje = "Proveedor editado";
                        $tipo = "success";
                    } else {
                        $mensaje = "Ha ocurrido un error en la base de datos";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                return $this->redirect($this->generateUrl("sistema_proveedores"));
            } else {
                return $this->redirect($this->generateUrl("sistema_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function borrarProveedorAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {
                if ($request->request->has("borrar_proveedor")) {

                    $conexion = $this->get("sistema.conexion");

                    $id_proveedor = $request->get("id_proveedor");

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id_proveedor)) {
                        if($conexion->borrarProveedor($id_proveedor)) {
                            $mensaje = "Proveedor borrado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "ID Invalido";
                        $tipo = "warning";
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Proveedores",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                    return $this->redirect($this->generateUrl("sistema_proveedores"));
                }
                elseif ($request->request->has("volver_proveedor")) {
                    return $this->redirect($this->generateUrl("sistema_proveedores"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_proveedores")); 
                }
            } else {
                return $this->redirect($this->generateUrl("sistema_proveedores"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
