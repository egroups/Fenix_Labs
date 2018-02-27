<?php

class Proveedor
{
    
    private $id_proveedor;
    private $nombre_empresa;
    private $direccion;
    private $telefono;
    private $fecha_registro;
    
    public function __construct()
    {
        $this->id_proveedor   = "";
        $this->nombre_empresa = "";
        $this->direccion      = "";
        $this->telefono       = "";
        $this->fecha_registro = "";
    }
    
    public static function CreateProveedor($id_proveedor, $nombre_empresa, $direccion, $telefono, $fecha_registro)
    {
        $instance                 = new self();
        $instance->id_proveedor   = $id_proveedor;
        $instance->nombre_empresa = $nombre_empresa;
        $instance->direccion      = $direccion;
        $instance->telefono       = $telefono;
        $instance->fecha_registro = $fecha_registro;
        return $instance;
    }
    
    public function getId_proveedor()
    {
        return $this->id_proveedor;
    }
    
    public function setId_proveedor($id_proveedor)
    {
        $this->id_proveedor = $id_proveedor;
    }
    
    public function getNombre_empresa()
    {
        return $this->nombre_empresa;
    }
    
    public function setNombre_empresa($nombre_empresa)
    {
        $this->nombre_empresa = $nombre_empresa;
    }
    
    public function getDireccion()
    {
        return $this->direccion;
    }
    
    public function setDireccion($direccion)
    {
        $this->direccion = $direccion;
    }
    
    public function getTelefono()
    {
        return $this->telefono;
    }
    
    public function setTelefono($telefono)
    {
        $this->telefono = $telefono;
    }
    
    public function getFecha_registro()
    {
        return $this->fecha_registro;
    }
    
    public function setFecha_registro($fecha_registro)
    {
        $this->fecha_registro = $fecha_registro;
    }
    
    public function __destruct()
    {
        $this->id_proveedor   = "";
        $this->nombre_empresa = "";
        $this->direccion      = "";
        $this->telefono       = "";
        $this->fecha_registro = "";
    }
    
    public function toString()
    {
        return "Proveedor{" . "id_proveedor=" . $this->id_proveedor . ", nombre_empresa=" . $this->nombre_empresa . ", direccion=" . $this->direccion . ", telefono=" . $this->telefono . ", fecha_registro=" . $this->fecha_registro . '}';
    }
    
}

?>