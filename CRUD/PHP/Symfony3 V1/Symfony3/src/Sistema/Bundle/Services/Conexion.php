<?php

// Written By Ismael Heredia in the year 2017

namespace Sistema\Bundle\Services;

use Doctrine\ORM\EntityManager;
use Symfony\Component\HttpFoundation\Session\Session;
use Sistema\Bundle\Entity\Productos;
use Sistema\Bundle\Entity\Proveedores;
use Sistema\Bundle\Entity\Usuarios;

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
        $check = $this->em->getRepository("SistemaBundle:Usuarios")->findOneBy(array("usuario"=>$username,"clave"=>$password));
        if($check) {
            return true;
        } else {
            return false;
        }
    }

    public function detectar_tipo_usuario($username) {
        $query = $this->em->createQuery("SELECT u.id,u.tipo FROM SistemaBundle:Usuarios u WHERE u.usuario = :username"); 
        $query->setParameter('username',$username);
        $data = $query->getResult(); 
        $tipo = $data[0]["tipo"];
        $nombre_tipo = "";
        if($tipo=="1") {
            $nombre_tipo = "Administrador";
        } else {
            $nombre_tipo = "Usuario";
        }
        return $nombre_tipo;
    }

    public function cargarIdUsuario($username) {
        $query = $this->em->createQuery("SELECT u.id,u.tipo FROM SistemaBundle:Usuarios u WHERE u.usuario = :username"); 
        $query->setParameter('username',$username);
        $data = $query->getResult(); 
        $id = $data[0]["id"];
        return $id;
    }

    public function buscar_productos($patron) {
        $query = $this->em->createQuery("SELECT prod.id,prod.nombreProducto,prod.descripcion,prod.precio,prod.idProveedor,prod.fechaRegistro,prov.nombreEmpresa FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id AND prod.nombreProducto LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $productos = $query->getResult();
        return $productos;     
    }

    public function buscar_proveedores($patron) {
        $query = $this->em->createQuery("SELECT p.id,p.nombreEmpresa,p.direccion,p.telefono,p.fechaRegistroProveedor FROM SistemaBundle:Proveedores p WHERE p.nombreEmpresa LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $proveedores = $query->getResult();
        return $proveedores;
    }

    public function buscar_usuarios($patron) {
        $query = $this->em->createQuery("SELECT u.id,u.usuario,u.clave,u.tipo,u.fechaRegistro FROM SistemaBundle:Usuarios u WHERE u.usuario LIKE :patron");
        $query->setParameter('patron',"%".$patron."%");
        $usuarios = $query->getResult();
        return $usuarios;
    }

    public function cargarProducto($id) {
        $query = $this->em->createQuery("SELECT prod.id,prod.nombreProducto,prod.descripcion,prod.precio,prod.idProveedor,prod.fechaRegistro,prov.nombreEmpresa FROM SistemaBundle:Productos prod JOIN SistemaBundle:Proveedores prov WHERE prod.idProveedor=prov.id AND prod.id = :id");
        $query->setParameter('id',$id);
        $producto = $query->getResult()[0];    
        return $producto;    
    }

    public function cargarProveedor($id) {
        $query = $this->em->createQuery("SELECT p.id,p.nombreEmpresa,p.direccion,p.telefono,p.fechaRegistroProveedor FROM SistemaBundle:Proveedores p WHERE p.id = :id");
        $query->setParameter('id',$id);
        $proveedor = $query->getResult()[0];
        return $proveedor;
    }

    public function cargarUsuario($id) {
        $query = $this->em->createQuery("SELECT u.id,u.usuario,u.clave,u.tipo,u.fechaRegistro FROM SistemaBundle:Usuarios u WHERE u.id LIKE :id");
        $query->setParameter('id',$id);
        $usuario = $query->getResult()[0];
        return $usuario;
    }

    public function agregarProducto($nombre_producto,$descripcion,$precio,$id_proveedor,$fecha_registro) {
        try {
            $p = new Productos();
            $p->setNombreProducto($nombre_producto);
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

    public function editarProducto($id,$nombre_producto,$descripcion,$precio,$id_proveedor) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Productos")->find($id);
            $p->setNombreProducto($nombre_producto);
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

    public function agregarProveedor($nombre_empresa,$direccion,$telefono,$fecha_registro) {
        try {
            $p = new Proveedores();
            $p->setNombreEmpresa($nombre_empresa);
            $p->setDireccion($direccion);
            $p->setTelefono($telefono);
            $p->setFechaRegistroProveedor($fecha_registro);
            $this->em->persist($p);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function editarProveedor($id,$nombre_empresa,$direccion,$telefono) {
        try {
            $p = $this->em->getRepository("SistemaBundle:Proveedores")->find($id);
            $p->setNombreEmpresa($nombre_empresa);
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

    public function agregarUsuario($usuario,$clave,$tipo,$fecha_registro) {
        try {
            $u = new Usuarios();
            $u->setUsuario($usuario);
            $u->setClave($clave);
            $u->setTipo($tipo);
            $u->setFechaRegistro($fecha_registro);
            $this->em->persist($u);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function asignarUsuario($id,$tipo) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $u->setTipo($tipo);
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
            $u->setUsuario($nuevo_nombre);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

    public function cambiarPasswordUsuario($id,$nuevo_password) {
        try {
            $u = $this->em->getRepository("SistemaBundle:Usuarios")->find($id);
            $u->setClave($nuevo_password);
            $this->em->flush();
            return true;
        } catch(Exception $e) {
            return false;
        }
    }

}