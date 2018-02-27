<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Services;

use Doctrine\ORM\EntityManager;
use Symfony\Component\HttpFoundation\Session\Session;
use Sistema\Bundle\Entity\Productos;
use Sistema\Bundle\Entity\Proveedores;
use Sistema\Bundle\Entity\Usuarios;
use Sistema\Bundle\Entity\TiposUsuarios;

class Conexion
{

	private $em;
    private $session;

    public function __construct(EntityManager $em,Session $session)
    {
    	$this->em = $em;
    	$this->session = $session;
    }

    public function ingreso_usuario($username,$password){
        $contenido = $this->session->get('login');
        $check = $this->em->getRepository("SistemaBundle:Usuarios")->findOneBy(array("nombre"=>$username,"clave"=>$password));
        if($check) {
            return true;
        } else {
            return false;
        }
    }

    public function detectar_tipo_usuario($username) {
        $query = $this->em->createQuery("SELECT t.nombre FROM SistemaBundle:Usuarios u JOIN SistemaBundle:TiposUsuarios t WHERE u.idTipo=t.id AND u.nombre = :username"); 
        $query->setParameter('username',$username);
        $data = $query->getResult(); 
        $nombre_tipo = $data[0]["nombre"];
        return $nombre_tipo;
    }

    public function cargarIdUsuario($username) {
        $query = $this->em->createQuery("SELECT u.id FROM SistemaBundle:Usuarios u WHERE u.nombre = :username"); 
        $query->setParameter('username',$username);
        $data = $query->getResult(); 
        $id = $data[0]["id"];
        return $id;
    }

    public function listarProductos($patron) {
        $query = $this->em->createQuery("SELECT prod.id,prod.nombre,prod.descripcion,prod.precio,prod.idProveedor,prod.fechaRegistro,prov.nombre AS nombreProveedor FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id AND prod.nombre LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $productos = $query->getResult();
        return $productos;     
    }

    public function listarProveedores($patron) {
        $query = $this->em->createQuery("SELECT p.id,p.nombre,p.direccion,p.telefono,p.fechaRegistro FROM SistemaBundle:Proveedores p WHERE p.nombre LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $proveedores = $query->getResult();
        return $proveedores;
    }

    public function cargarComboProveedores() {
        $arrays = array();
        $query = $this->em->createQuery("SELECT p.id,p.nombre FROM SistemaBundle:Proveedores p");
        $proveedores = $query->getResult();
        foreach($proveedores as $proveedor) {
            $id_proveedor = $proveedor["id"];
            $nombre_proveedor = $proveedor["nombre"];
            $arrays[$nombre_proveedor] = $id_proveedor;
        }       
        return $arrays;
    }

    public function listarUsuarios($patron) {
        $query = $this->em->createQuery("SELECT u.id,u.nombre,u.clave,u.idTipo,u.fechaRegistro,t.nombre AS nombreTipo FROM SistemaBundle:Usuarios u JOIN SistemaBundle:TiposUsuarios t WHERE u.idTipo=t.id AND u.nombre LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $usuarios = $query->getResult();
        return $usuarios;
    }

    public function cargarComboTipoUsuario() {
        $arrays = array();
        $query = $this->em->createQuery("SELECT t.id,t.nombre FROM SistemaBundle:TiposUsuarios t");
        $tipos = $query->getResult();
        foreach($tipos as $tipo) {
            $id_tipo = $tipo["id"];
            $nombre_tipo = $tipo["nombre"];
            $arrays[$nombre_tipo] = $id_tipo;
        }       
        return $arrays;
    }

    public function cargarProducto($id) {
        $query = $this->em->createQuery("SELECT prod.id,prod.nombre,prod.descripcion,prod.precio,prod.idProveedor,prod.fechaRegistro,prov.nombre as nombreProveedor FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id AND prod.id = :id");
        $query->setParameter('id',$id);
        $producto = $query->getResult()[0];    
        return $producto;    
    }

    public function cargarProveedor($id) {
        $query = $this->em->createQuery("SELECT p.id,p.nombre,p.direccion,p.telefono,p.fechaRegistro FROM SistemaBundle:Proveedores p WHERE p.id = :id");
        $query->setParameter('id',$id);
        $proveedor = $query->getResult()[0];
        return $proveedor;
    }

    public function cargarUsuario($id) {
        $query = $this->em->createQuery("SELECT u.id,u.nombre,u.clave,u.idTipo,u.fechaRegistro FROM SistemaBundle:Usuarios u WHERE u.id LIKE :id");
        $query->setParameter('id',$id);
        $usuario = $query->getResult()[0];
        return $usuario;
    }

    public function agregarProducto($nombre,$descripcion,$precio,$id_proveedor,$fecha_registro) {
        try {
            $p = new Productos();
            $p->setNombre($nombre);
            $p->setDescripcion($descripcion);
            $p->setPrecio($precio);
            $p->setIdProveedor($id_proveedor);
            $p->setFechaRegistro($fecha_registro);
            $this->em->persist($p);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function editarProducto($id,$nombre,$descripcion,$precio,$id_proveedor) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Productos")->find($id);
            $p->setNombre($nombre);
            $p->setDescripcion($descripcion);
            $p->setPrecio($precio);
            $p->setIdProveedor($id_proveedor);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function borrarProducto($id) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Productos")->find($id);
            $this->em->remove($p);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }        
    }

    public function agregarProveedor($nombre,$direccion,$telefono,$fecha_registro) {
        try {
            $p = new Proveedores();
            $p->setNombre($nombre);
            $p->setDireccion($direccion);
            $p->setTelefono($telefono);
            $p->setFechaRegistro($fecha_registro);
            $this->em->persist($p);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function editarProveedor($id,$nombre,$direccion,$telefono) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Proveedores")->find($id);
            $p->setNombre($nombre);
            $p->setDireccion($direccion);
            $p->setTelefono($telefono);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function borrarProveedor($id) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Proveedores")->find($id);
            $this->em->remove($p);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }        
    }

    public function agregarUsuario($nombre,$clave,$id_tipo,$fecha_registro) {
        try {
            $u = new Usuarios();
            $u->setNombre($nombre);
            $u->setClave($clave);
            $u->setIdTipo($id_tipo);
            $u->setFechaRegistro($fecha_registro);
            $this->em->persist($u);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function asignarUsuario($id,$id_tipo) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $u->setIdTipo($id_tipo);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function borrarUsuario($id) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $this->em->remove($u);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }        
    }

    public function cambiarNombreUsuario($id,$nuevo_nombre) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $u->setNombre($nuevo_nombre);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function cambiarClaveUsuario($id,$nuevo_password) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $u->setClave($nuevo_password);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function comprobar_existencia_producto_crear($nombre) {

        $query = $this->em->createQuery("SELECT p.id FROM SistemaBundle:Productos p WHERE p.nombre = :nombre");
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

    public function comprobar_existencia_producto_editar($id,$nombre) {

        $query = $this->em->createQuery("SELECT p.id FROM SistemaBundle:Productos p where p.nombre = :nombre AND p.id != :id");
        $query->setParameter('id',$id);
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

    public function comprobar_existencia_proveedor_crear($nombre) {

        $query = $this->em->createQuery("SELECT p.id FROM SistemaBundle:Proveedores p WHERE p.nombre = :nombre");
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

    public function comprobar_existencia_proveedor_editar($id,$nombre) {

        $query = $this->em->createQuery("SELECT p.id FROM SistemaBundle:Proveedores p where p.nombre = :nombre AND p.id != :id");
        $query->setParameter('id',$id);
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

    public function comprobar_existencia_usuario_crear($nombre) {

        $query = $this->em->createQuery("SELECT u.id FROM SistemaBundle:Usuarios u WHERE u.nombre = :nombre");
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

    public function comprobar_existencia_usuario_editar($id,$nombre) {

        $query = $this->em->createQuery("SELECT u.id FROM SistemaBundle:Usuarios u where u.nombre = :nombre AND u.id != :id");
        $query->setParameter('id',$id);
        $query->setParameter('nombre',$nombre);
        $cantidad = count($query->getResult());
        if($cantidad >= 1) {
            return true;
        } else {
            return false;
        }
    }

}