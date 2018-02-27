<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProductosController extends Controller
{
    public function indexAction()
    {
    	if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
    		$productos = $conexion->buscar_productos("");
            $proveedores = $conexion->buscar_proveedores("");
    		$cantidad_productos = count($productos);
        	return $this->render("SistemaBundle:Productos:agregar.html.twig",array("productos"=>$productos,"cantidad_productos"=>$cantidad_productos,"proveedores"=>$proveedores));
    	} else {
    		return $this->redirect($this->generateUrl("sistema_login"));
    	}
    }

    public function buscarProductosAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {
                $patron = $request->get("nombre_buscar");
                $conexion = $this->get("sistema.conexion");
                $productos = $conexion->buscar_productos("");
                $cantidad_productos = count($productos);
                $productos_encontrados = $conexion->buscar_productos($patron);
                $cantidad_productos_encontrados = count($productos_encontrados);
                $proveedores = $conexion->buscar_proveedores("");
                return $this->render("SistemaBundle:Productos:agregar.html.twig",
                                        array("buscador_activo"=>true,"productos_encontrados"=>$productos_encontrados,
                                              "cantidad_productos_encontrados"=>$cantidad_productos_encontrados,"productos"=>$productos,
                                              "cantidad_productos"=>$cantidad_productos,"proveedores"=>$proveedores));
            } else {
               return $this->redirect($this->generateUrl("sistema_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function cargarEdicionProductoAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
            $producto = $conexion->cargarProducto($id);
            $productos = $conexion->buscar_productos("");
            $proveedores = $conexion->buscar_proveedores("");
            $cantidad_productos = count($productos);
            return $this->render("SistemaBundle:Productos:editar.html.twig",array("productos"=>$productos,"cantidad_productos"=>$cantidad_productos,"proveedores"=>$proveedores,"producto"=>$producto));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarBorradoProductoAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {
            $conexion = $this->get("sistema.conexion");
            $producto = $conexion->cargarProducto($id);
            return $this->render("SistemaBundle:Productos:borrar.html.twig",array("producto"=>$producto));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function agregarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $nombre_producto = $request->get("nombre_producto");
                $descripcion = $request->get("descripcion");
                $precio = $request->get("precio");
                $proveedor = $request->get("proveedor");
                $fecha_registro = $this->get("sistema.funciones")->fecha_actual();

                $mensaje = "";
                $tipo = "";

                if($nombre_producto!="" && $descripcion!="" && is_numeric($precio) && is_numeric($proveedor) && fecha_registro!="") {
                    if($conexion->agregarProducto($nombre_producto,$descripcion,$precio,$proveedor,$fecha_registro)) {
                        $mensaje = "Producto agregado";
                        $tipo = "success";
                    } else {
                        $mensaje = "Ha ocurrido un error en la base de datos";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                return $this->redirect($this->generateUrl("sistema_productos"));
            } else {
                return $this->redirect($this->generateUrl("sistema_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function editarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");

                $id_producto = $request->get("id_producto");
                $nombre_producto = $request->get("nombre_producto");
                $descripcion = $request->get("descripcion");
                $precio = $request->get("precio");
                $proveedor = $request->get("proveedor");

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id_producto) && $nombre_producto!="" && $descripcion!="" && is_numeric($precio) && is_numeric($proveedor)) {
                    if($conexion->editarProducto($id_producto,$nombre_producto,$descripcion,$precio,$proveedor)) {
                        $mensaje = "Producto editado";
                        $tipo = "success";
                    } else {
                        $mensaje = "Ha ocurrido un error en la base de datos";
                        $tipo = "error";
                    }
                } else {
                    $mensaje = "Faltan datos";
                    $tipo = "warning"; 
                }

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                return $this->redirect($this->generateUrl("sistema_productos"));
            } else {
                return $this->redirect($this->generateUrl("sistema_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function borrarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {
                if ($request->request->has("borrar_producto")) {

                    $conexion = $this->get("sistema.conexion");

                    $id_producto = $request->get("id_producto");

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id_producto)) {
                        if($conexion->borrarProducto($id_producto)) {
                            $mensaje = "Producto borrado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "ID Invalido";
                        $tipo = "warning";
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);
                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);
                    return $this->redirect($this->generateUrl("sistema_productos"));
                }
                elseif ($request->request->has("volver_producto")) {
                    return $this->redirect($this->generateUrl("sistema_productos"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_productos")); 
                }
            } else {
                return $this->redirect($this->generateUrl("sistema_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
