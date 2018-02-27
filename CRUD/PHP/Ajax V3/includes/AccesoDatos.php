<?php

// Written by Ismael Heredia in the year 2017

include_once("Conexion.php");

class AccesoDatos {
  
   public function __construct(){

   }

   // Productos

   public function listarProductos($patron) {
      $productos = array();
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM productos WHERE nombre LIKE :patron');
      $sql->execute(array('patron' => '%'.$patron.'%'));
      $resultado = $sql->fetchAll();
      foreach ($resultado as $fila) {
        $id = $fila['id'];
        $nombre = $fila['nombre'];
        $descripcion = $fila['descripcion'];
        $precio = $fila['precio'];
        $id_proveedor = $fila['id_proveedor'];
        $fecha_registro = $fila['fecha_registro'];
        $producto = Producto::CreateProducto($id,$nombre,$descripcion,$precio,$id_proveedor,$fecha_registro);
        array_push($productos,$producto);
      }
      foreach ($productos as $producto) {
        $sql = $conn->prepare('SELECT * FROM proveedores WHERE id = :id');
        $sql->execute(array('id' => $producto->getId_proveedor()));
        $resultado = $sql->fetch();  
        $id = $resultado['id'];
        $nombre = $resultado['nombre'];
        $direccion = $resultado['direccion'];
        $telefono = $resultado['telefono'];
        $fecha_registro = $resultado['fecha_registro']; 
        $proveedor = Proveedor::CreateProveedor($id,$nombre,$direccion,$telefono,$fecha_registro);
        $producto->setProveedor($proveedor);     
      }
      $conexion->cerrar_conexion();
      return $productos;   
   }

   public function cargarProducto($id) {
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM productos WHERE id = :id');
      $sql->execute(array('id' => $id));
      $resultado = $sql->fetch();
      $id = $resultado['id'];
      $nombre = $resultado['nombre'];
      $descripcion = $resultado['descripcion'];
      $precio = $resultado['precio'];
      $id_proveedor = $resultado['id_proveedor'];
      $fecha_registro = $resultado['fecha_registro'];
      $producto = Producto::CreateProducto($id,$nombre,$descripcion,$precio,$id_proveedor,$fecha_registro);
      $sql = $conn->prepare('SELECT * FROM proveedores WHERE id = :id');
      $sql->execute(array('id' => $producto->getId_proveedor()));
      $resultado = $sql->fetch();  
      $id = $resultado['id'];
      $nombre = $resultado['nombre'];
      $direccion = $resultado['direccion'];
      $telefono = $resultado['telefono'];
      $fecha_registro = $resultado['fecha_registro']; 
      $proveedor = Proveedor::CreateProveedor($id,$nombre,$direccion,$telefono,$fecha_registro);
      $producto->setProveedor($proveedor);  
      $conexion->cerrar_conexion();
      return $producto;   
   }  

   public function agregarProducto($producto) {
      $nombre = $producto->getNombre();
      $descripcion = $producto->getDescripcion();
      $precio = $producto->getPrecio();
      $id_proveedor = $producto->getId_proveedor();
      $fecha_registro = $producto->getFecha_registro();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('INSERT INTO productos(nombre,descripcion,precio,id_proveedor,fecha_registro) VALUES(:nombre,:descripcion,:precio,:id_proveedor,:fecha_registro)');
        $sql->execute(array('nombre' => $nombre,'descripcion' => $descripcion,'precio' => $precio,'id_proveedor' => $id_proveedor,'fecha_registro'=>$fecha_registro)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      }     
   }

   public function editarProducto($producto) {
      $id = $producto->getId();
      $nombre = $producto->getNombre();
      $descripcion = $producto->getDescripcion();
      $precio = $producto->getPrecio();
      $id_proveedor = $producto->getId_proveedor();
      $fecha_registro = $producto->getFecha_registro();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('UPDATE productos SET nombre = :nombre, descripcion = :descripcion, precio = :precio, id_proveedor = :id_proveedor WHERE id = :id');
        $sql->execute(array('nombre' => $nombre,'descripcion' => $descripcion,'precio' => $precio,'id_proveedor' => $id_proveedor,'id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function borrarProducto($producto) {
      $id = $producto->getId();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('DELETE FROM productos WHERE id = :id');
        $sql->execute(array('id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function comprobarExistenciaProductoCrear($nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM productos WHERE nombre = :nombre');
      $sql->execute(array('nombre' => $nombre));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   public function comprobarExistenciaProductoEditar($id,$nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM productos WHERE nombre = :nombre AND id != :id');
      $sql->execute(array('nombre' => $nombre,'id' => $id));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   // Proveedores

   public function listarProveedores($patron) {
      $proveedores = array();
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM proveedores WHERE nombre LIKE :patron');
      $sql->execute(array('patron' => '%'.$patron.'%'));
      $resultado = $sql->fetchAll();
      foreach ($resultado as $fila) {
        $id = $fila['id'];
        $nombre = $fila['nombre'];
        $direccion = $fila['direccion'];
        $telefono = $fila['telefono'];
        $fecha_registro = $fila['fecha_registro'];
        $proveedor = Proveedor::CreateProveedor($id,$nombre,$direccion,$telefono,$fecha_registro);
        array_push($proveedores,$proveedor);
      }
      $conexion->cerrar_conexion();
      return $proveedores; 
   }

   public function cargarProveedor($id) {
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM proveedores WHERE id = :id');
      $sql->execute(array('id' => $id));
      $resultado = $sql->fetch();
      $id = $resultado['id'];
      $nombre = $resultado['nombre'];
      $direccion = $resultado['direccion'];
      $telefono = $resultado['telefono'];
      $fecha_registro = $resultado['fecha_registro'];
      $proveedor = Proveedor::CreateProveedor($id,$nombre,$direccion,$telefono,$fecha_registro);
      $conexion->cerrar_conexion();
      return $proveedor; 
   }

   public function agregarProveedor($proveedor) {
      $nombre = $proveedor->getNombre();
      $direccion = $proveedor->getDireccion();
      $telefono = $proveedor->getTelefono();
      $fecha_registro = $proveedor->getFecha_registro();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('INSERT INTO proveedores(nombre,direccion,telefono,fecha_registro) VALUES(:nombre,:direccion,:telefono,:fecha_registro)');
        $sql->execute(array('nombre' => $nombre,'direccion' => $direccion,'telefono' => $telefono,'fecha_registro'=>$fecha_registro)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      }     
   }

   public function editarProveedor($proveedor) {
      $id = $proveedor->getId();
      $nombre = $proveedor->getNombre();
      $direccion = $proveedor->getDireccion();
      $telefono = $proveedor->getTelefono();
      $fecha_registro = $proveedor->getFecha_registro();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('UPDATE proveedores SET nombre = :nombre, direccion = :direccion, telefono = :telefono WHERE id = :id');
        $sql->execute(array('nombre' => $nombre,'direccion' => $direccion,'telefono' => $telefono,'id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function borrarProveedor($proveedor) {
      $id = $proveedor->getId();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('DELETE FROM proveedores WHERE id = :id');
        $sql->execute(array('id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function comprobarExistenciaProveedorCrear($nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM proveedores WHERE nombre = :nombre');
      $sql->execute(array('nombre' => $nombre));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   public function comprobarExistenciaProveedorEditar($id,$nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM proveedores WHERE nombre = :nombre AND id != :id');
      $sql->execute(array('nombre' => $nombre,'id' => $id));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   // Usuarios

   public function listarUsuarios($patron) {
      $usuarios = array();
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM usuarios WHERE nombre LIKE :patron');
      $sql->execute(array('patron' => '%'.$patron.'%'));
      $resultado = $sql->fetchAll();
      foreach ($resultado as $fila) {
        $id = $fila['id'];
        $nombre = $fila['nombre'];
        $clave = $fila['clave'];
        $tipo = $fila['id_tipo'];
        $fecha_registro = $fila['fecha_registro'];
        $usuario = Usuario::CreateUsuario($id,$nombre,$clave,$tipo,$fecha_registro);
        array_push($usuarios,$usuario);
      }
      foreach ($usuarios as $usuario) {
        $sql = $conn->prepare('SELECT * FROM tipos_usuarios WHERE id = :id');
        $sql->execute(array('id' => $usuario->getId_tipo()));
        $resultado = $sql->fetch();
        $id = $resultado['id'];
        $nombre = $resultado['nombre'];
        $tipo = TipoUsuario::CreateTipoUsuario($id,$nombre); 
        $usuario->setTipo($tipo);       
      }
      $conexion->cerrar_conexion();
      return $usuarios;  
   }

   public function cargarUsuario($id) {
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM usuarios WHERE id = :id');
      $sql->execute(array('id' => $id));
      $resultado = $sql->fetch();
      $id = $resultado['id'];
      $nombre = $resultado['nombre'];
      $clave = $resultado['clave'];
      $tipo = $resultado['id_tipo'];
      $fecha_registro = $resultado['fecha_registro'];
      $usuario = Usuario::CreateUsuario($id,$nombre,$clave,$tipo,$fecha_registro);
      $sql = $conn->prepare('SELECT * FROM tipos_usuarios WHERE id = :id');
      $sql->execute(array('id' => $usuario->getId_tipo()));
      $resultado = $sql->fetch();
      $id = $resultado['id'];
      $nombre = $resultado['nombre'];
      $tipo = TipoUsuario::CreateTipoUsuario($id,$nombre); 
      $usuario->setTipo($tipo);   
      $conexion->cerrar_conexion();
      return $usuario;  
   }

   public function agregarUsuario($usuario) {
      $nombre = $usuario->getNombre();
      $clave = $usuario->getClave();
      $id_tipo = $usuario->getId_tipo();
      $fecha_registro = $usuario->getFecha_registro();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('INSERT INTO usuarios(nombre,clave,id_tipo,fecha_registro) VALUES(:nombre,:clave,:id_tipo,:fecha_registro)');
        $sql->execute(array('nombre' => $nombre,'clave' => $clave,'id_tipo' => $id_tipo,'fecha_registro'=>$fecha_registro)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      }     
   }

   public function editarUsuario($usuario) {
      $id = $usuario->getId();
      $id_tipo = $usuario->getId_tipo();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('UPDATE usuarios SET id_tipo = :id_tipo WHERE id = :id');
        $sql->execute(array('id_tipo' => $id_tipo,'id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function borrarUsuario($usuario) {
      $id = $usuario->getId();
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('DELETE FROM usuarios WHERE id = :id');
        $sql->execute(array('id'=>$id)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function comprobarExistenciaUsuarioCrear($nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM usuarios WHERE nombre = :nombre');
      $sql->execute(array('nombre' => $nombre));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   public function comprobarExistenciaUsuarioEditar($id,$nombre) {
      $response = false;
      $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT * FROM usuarios WHERE nombre = :nombre AND id != :id');
      $sql->execute(array('nombre' => $nombre,'id' => $id));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   // Tipos de usuarios

   public function listarTiposUsuarios($patron) {
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $tipos = array();
      $sql = $conn->prepare('SELECT * FROM tipos_usuarios WHERE nombre LIKE :patron');
      $sql->execute(array('patron' => '%'.$patron.'%'));
      $resultado = $sql->fetchAll();
      foreach ($resultado as $fila) {
        $id = $fila['id'];
        $nombre = $fila['nombre'];
        $tipo = TipoUsuario::CreateTipoUsuario($id,$nombre);
        array_push($tipos,$tipo);
      }
      $conexion->cerrar_conexion();
      return $tipos;  
   }

   // Controles de usuarios

   public function ingreso_usuario($usuario,$clave) {
      $response = false;
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT id FROM usuarios WHERE nombre = :usuario AND clave = :clave');
      $sql->execute(array('usuario' => $usuario, 'clave' => $clave));
      $resultado = $sql->fetchAll();
      $cantidad = count($resultado);
      if($cantidad >= 1) {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }
   
   public function es_admin($usuario) {
      $response = false;
   	  $conexion = new Conexion();
      $conexion->abrir_conexion();
      $conn = $conexion->retornar_conexion();
      $sql = $conn->prepare('SELECT id_tipo FROM usuarios WHERE nombre = :usuario');
      $sql->execute(array('usuario' => $usuario));
      $resultado = $sql->fetch();
      $id_tipo = $resultado['id_tipo'];
      if($id_tipo=='1') {
        $response = true;
      } else {
        $response = false;
      }
      $conexion->cerrar_conexion();
      return $response;
   }

   // Cuenta

   public function cambiarUsuario($usuario,$nuevo_usuario) {
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('UPDATE usuarios SET nombre = :nuevo_usuario WHERE nombre = :usuario');
        $sql->execute(array('usuario'=>$usuario,'nuevo_usuario'=>$nuevo_usuario)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }

   public function cambiarClave($usuario,$nueva_clave) {
      try {
        $conexion = new Conexion();
        $conexion->abrir_conexion();
        $conn = $conexion->retornar_conexion();
        $sql = $conn->prepare('UPDATE usuarios SET clave = :nueva_clave WHERE nombre = :usuario');
        $sql->execute(array('usuario'=>$usuario,'nueva_clave'=>$nueva_clave)); 
        $conexion->cerrar_conexion();
        return true;
      } catch (PDOException $e) {
        return false;
      } 
   }
            	   
   public function __destruct(){
   }  
   
}

?>