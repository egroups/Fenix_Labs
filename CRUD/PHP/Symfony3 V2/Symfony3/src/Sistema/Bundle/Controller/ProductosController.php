<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpKernel\Exception\NotFoundHttpException;
use Sistema\Bundle\Form\FormAgregarProducto;
use Sistema\Bundle\Form\FormEditarProducto;
use Sistema\Bundle\Form\FormBorrarProducto;
use Sistema\Bundle\Form\FormBuscador;

class ProductosController extends Controller
{

    public function listarAction(Request $request) {

        if($this->get("sistema.seguridad")->validar_session()) {

            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

            $conexion = $this->get("sistema.conexion");
            $productos = $conexion->listarProductos("");
            $cantidad_productos = count($productos);

            if($request->getMethod()=="POST") {
                $form = $this->createForm(FormBuscador::class,array());
                $form->handleRequest($request);
                $campos = $form->getData();
                $patron = $campos["nombreBuscar"];
                $productos_encontrados = $conexion->listarProductos($patron);
                $cantidad_productos_encontrados = count($productos_encontrados);
                return $this->render("SistemaBundle:Productos:listar.html.twig",
                                        array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"productos_encontrados"=>$productos_encontrados,
                                              "cantidad_productos_encontrados"=>$cantidad_productos_encontrados,
                                              "cantidad_productos"=>$cantidad_productos));
            } else {
                $form = $this->createForm(FormBuscador::class,array());
                return $this->render("SistemaBundle:Productos:listar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"productos_encontrados"=>$productos,"cantidad_productos_encontrados"=>$cantidad_productos,"cantidad_productos"=>$cantidad_productos));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function cargarEdicionProductoAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {

            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

            $conexion = $this->get("sistema.conexion");
            $producto = $conexion->cargarProducto($id);

            if($producto == null) {
                throw new NotFoundHttpException("Producto no encontrado");
            }

            $combo_proveedores = $conexion->cargarComboProveedores();

            $form = $this->createForm(FormEditarProducto::class,array("combo_proveedores"=>$combo_proveedores,"producto"=>$producto));
            return $this->render("SistemaBundle:Productos:editar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView()));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function cargarBorradoProductoAction($id) {
        if($this->get("sistema.seguridad")->validar_session()) {

            $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();
            $conexion = $this->get("sistema.conexion");
            $producto = $conexion->cargarProducto($id);

            if($producto == null) {
                throw new NotFoundHttpException("Producto no encontrado");
            }

            $form = $this->createForm(FormBorrarProducto::class,array("producto"=>$producto));
            return $this->render("SistemaBundle:Productos:borrar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView(),"producto"=>$producto));
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }        
    }

    public function agregarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");
                $funcion = $this->get("sistema.funciones");

                $combo_proveedores = $conexion->cargarComboProveedores();
                $form = $this->createForm(FormAgregarProducto::class,array("combo_proveedores"=>$combo_proveedores));
                $form->handleRequest($request);
                $campos = $form->getData();

                $nombre = $campos["nombre"];
                $descripcion = $campos["descripcion"];
                $precio = $campos["precio"];
                $proveedor = $campos["idProveedor"];
                $fecha_registro = $funcion->fecha_actual();

                $mensaje = "";
                $tipo = "";

                if($nombre!="" && $descripcion!="" && $precio !="" && is_numeric($proveedor) && fecha_registro!="") {
                    if($conexion->comprobar_existencia_producto_crear($nombre)) {
                        $mensaje = "El producto $nombre ya existe";
                        $tipo = "warning"; 
                    } else {
                        if($conexion->agregarProducto($nombre,$descripcion,$precio,$proveedor,$fecha_registro)) {
                            $mensaje = "Producto agregado";
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

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo == "success") {
                    return $this->redirect($this->generateUrl("sistema_listar_productos"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_agregar_producto"));
                }

            } else {

                $nombre_usuario = $this->get('sistema.seguridad')->recibirUsuarioEnSession();

                $conexion = $this->get("sistema.conexion");

                $combo_proveedores = $conexion->cargarComboProveedores();
                
                $form = $this->createForm(FormAgregarProducto::class,array("combo_proveedores"=>$combo_proveedores));
                return $this->render("SistemaBundle:Productos:agregar.html.twig",array("nombre_usuario"=>$nombre_usuario,"form"=>$form->createView()));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function editarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $conexion = $this->get("sistema.conexion");
                $funcion = $this->get("sistema.funciones");

                $combo_proveedores = $conexion->cargarComboProveedores();
                $form = $this->createForm(FormEditarProducto::class,array("combo_proveedores"=>$combo_proveedores));
                $form->handleRequest($request);
                $campos = $form->getData();

                $id = $campos["id"];
                $nombre = $campos["nombre"];
                $descripcion = $campos["descripcion"];
                $precio = $campos["precio"];
                $proveedor = $campos["idProveedor"];

                $mensaje = "";
                $tipo = "";

                if(is_numeric($id) && $nombre!="" && $descripcion!="" && $precio!="" && is_numeric($proveedor)) {
                    if($conexion->comprobar_existencia_producto_editar($id,$nombre)) {
                        $mensaje = "El producto $nombre ya existe";
                        $tipo = "warning"; 
                    } else {
                        if($conexion->editarProducto($id,$nombre,$descripcion,$precio,$proveedor)) {
                            $mensaje = "Producto editado";
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

                $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);
                $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                if($tipo == "success") {
                    return $this->redirect($this->generateUrl("sistema_listar_productos"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_cargar_editar_producto",array("id"=>$id)));
                }

            } else {
                return $this->redirect($this->generateUrl("sistema_listar_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

    public function borrarProductoAction(Request $request) {
        if($this->get("sistema.seguridad")->validar_session()) {
            if($request->getMethod()=="POST") {

                $form = $this->createForm(FormBorrarProducto::class);
                $form->handleRequest($request);
                $campos = $form->getData();

                if ($form->get('borrarProducto')->isClicked()) {

                    $conexion = $this->get("sistema.conexion");

                    $id = $campos["id"];

                    $mensaje = "";
                    $tipo = "";

                    if(is_numeric($id)) {
                        if($conexion->borrarProducto($id)) {
                            $mensaje = "Producto borrado";
                            $tipo = "success";
                        } else {
                            $mensaje = "Ha ocurrido un error en la base de datos";
                            $tipo = "error";
                        }
                    } else {
                        $mensaje = "ID Inválido";
                        $tipo = "warning";
                    }

                    $mensaje_listo = $this->get("sistema.funciones")->mensaje("Productos",$mensaje,$tipo);

                    $this->get("session")->getFlashBag()->add("mensaje",$mensaje_listo);

                    if($tipo == "success") {
                        return $this->redirect($this->generateUrl("sistema_listar_productos"));
                    } else {
                        return $this->redirect($this->generateUrl("sistema_cargar_borrar_producto",array("id"=>$id)));
                    }

                }
                elseif ($form->get('volverLista')->isClicked()) {
                    return $this->redirect($this->generateUrl("sistema_listar_productos"));
                } else {
                    return $this->redirect($this->generateUrl("sistema_listar_productos")); 
                }
            } else {
                return $this->redirect($this->generateUrl("sistema_listar_productos"));
            }
        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
    }

}
