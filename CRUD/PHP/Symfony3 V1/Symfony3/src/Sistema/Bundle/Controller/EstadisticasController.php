<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class EstadisticasController extends Controller
{
    public function indexAction()
    {
        if($this->get("sistema.seguridad")->validar_session()) {
            
            $em = $this->getDoctrine()->getManager();

            $conexion = $this->get("sistema.conexion");
            $productos = $conexion->buscar_productos("");
            $cantidad_productos = count($productos);

            $array_textos_grafico1 = array();
            $array_series_grafico1 = array();

            $array_textos_grafico2 = array();
            $array_series_grafico2 = array();

            $query = $em->createQuery("SELECT prod.nombreProducto,prod.precio FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id");

            $resultados = $query->getResult();   
            
            foreach($resultados as $resultado) {
                $nombreProducto = $resultado["nombreProducto"];
                $precio = $resultado["precio"];
                $serie  = array(
                    'name' => $nombreProducto,
                    'y' => (int) $precio
                );
                array_push($array_textos_grafico1,$nombreProducto);
                array_push($array_series_grafico1,$serie);
            }

            $textos_grafico1 = json_encode($array_textos_grafico1);
            $series_grafico1 =  json_encode($array_series_grafico1);

            $query = $em->createQuery("SELECT prov.nombreEmpresa,COUNT(prod.idProveedor) as cantidad FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id GROUP BY prov.nombreEmpresa");

            $resultados = $query->getResult();   
            
            foreach($resultados as $resultado) {
                $nombreEmpresa = $resultado["nombreEmpresa"];
                $cantidad = $resultado["cantidad"];
                $serie  = array(
                    'name' => $nombreEmpresa,
                    'y' => (int) $cantidad
                );
                array_push($array_textos_grafico2,$nombreEmpresa);
                array_push($array_series_grafico2,$serie);
            }

            $textos_grafico2 = json_encode($array_textos_grafico2);
            $series_grafico2 =  json_encode($array_series_grafico2);

            return $this->render("SistemaBundle:Estadisticas:reporte.html.twig",array("productos"=>$productos,"cantidad_productos"=>$cantidad_productos,"textos_grafico1"=>$textos_grafico1,"series_grafico1"=>$series_grafico1,"textos_grafico2"=>$textos_grafico2,"series_grafico2"=>$series_grafico2));

        } else {
            return $this->redirect($this->generateUrl("sistema_login"));
        }
 
    }
}
