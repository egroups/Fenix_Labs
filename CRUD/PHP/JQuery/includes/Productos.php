<?php

class Producto
{
    
    private $id_producto;
    private $nombre_producto;
    private $direccion;
    private $telefono;
    private $id_proveedor;
    private $fecha_registro;
    
    public function __construct()
    {
        $this->id_producto     = "";
        $this->nombre_producto = "";
        $this->descripcion     = "";
        $this->precio          = "";
        $this->fecha_registro  = "";
        $this->id_proveedor    = "";
    }
    
    public static function CreateProducto($id_producto, $nombre_producto, $descripcion, $precio, $id_proveedor, $fecha_registro)
    {
        $instance                  = new self();
        $instance->id_producto     = $id_producto;
        $instance->nombre_producto = $nombre_producto;
        $instance->descripcion     = $descripcion;
        $instance->precio          = $precio;
        $instance->id_proveedor    = $id_proveedor;
        $instance->fecha_registro  = $fecha_registro;
        return $instance;
    }
    
    public function getId_producto()
    {
        return $this->id_producto;
    }
    
    public function setId_producto($id_producto)
    {
        $this->id_producto = $id_producto;
    }
    
    public function getNombre_producto()
    {
        return $this->nombre_producto;
    }
    
    public function setNombre_producto($nombre_producto)
    {
        $this->nombre_producto = $nombre_producto;
    }
    
    public function getDescripcion()
    {
        return $this->descripcion;
    }
    
    public function setDescripcion($descripcion)
    {
        $this->descripcion = $descripcion;
    }
    
    public function getPrecio()
    {
        return $this->precio;
    }
    
    public function setPrecio($telefono)
    {
        $this->precio = $precio;
    }
    
    public function getFecha_registro()
    {
        return $this->fecha_registro;
    }
    
    public function setFecha_registro($fecha_registro)
    {
        $this->fecha_registro = $fecha_registro;
    }
    
    public function getId_proveedor()
    {
        return $this->id_proveedor;
    }
    
    public function setId_proveedor($id_proveedor)
    {
        $this->id_proveedor = $id_proveedor;
    }
    
    public function __destruct()
    {
        $this->id_producto     = "";
        $this->nombre_producto = "";
        $this->descripcion     = "";
        $this->precio          = "";
        $this->fecha_registro  = "";
        $this->id_proveedor    = "";
    }
    
    public function toString()
    {
        //return "Producto{" . "id_producto=" . $this->id_producto . ", nombre_producto=" . $this->nombre_producto . ", descripcion=" . $this->descripcion . ", precio=" . $this->precio . ", fecha_registro=" . $this->fecha_registro . ", id_proveedor=" . $this->id_proveedor . '}';
    }
    
}

?>