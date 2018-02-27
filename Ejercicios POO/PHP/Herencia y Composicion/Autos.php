<?php

// Written By Ismael Heredia in the year 2016

class Auto
{
    
    private $marca;
    private $numero_serie;
    
    public function __construct()
    {
        $this->marca   = "";
        $this->numero_serie = "";
    }
    
    public static function CreateAuto($marca,$numero_serie)
    {
        $instance                 = new self();
        $instance->marca   = $marca;
        $instance->numero_serie = $numero_serie;
        return $instance;
    }
    
    public function getMarca()
    {
        return $this->marca;
    }
    
    public function setMarca($marca)
    {
        $this->marca = $marca;
    }
    
    public function getNumero_serie()
    {
        return $this->numero_serie;
    }
    
    public function setNumero_serie($numero_serie)
    {
        $this->numero_serie = $numero_serie;
    }
        
    public function __destruct()
    {
        $this->marca   = "";
        $this->numero_serie = "";
    }
    
    public function DatosAuto()
    {
        return "-- Datos del auto --" . "\n\n"
            . "[+] Marca : " . $this->marca . "\n"
            . "[+] Numero de serie : " . $this->numero_serie;
    }
    
}

?>