<?php

// Written By Ismael Heredia in the year 2016

class Edificio
{
    
    public $medidas;
    public $ambientes;
    
    public function __construct()
    {
        $this->medidas   = "";
        $this->ambientes = "";
    }
    
    public static function CreateEdificio($medidas,$ambientes)
    {
        $instance                 = new self();
        $instance->medidas   = $medidas;
        $instance->ambientes = $ambientes;
        return $instance;
    }
    
    public function getMedidas()
    {
        return $this->medidas;
    }
    
    public function setMedidas($medidas)
    {
        $this->medidas = $medidas;
    }
    
    public function getAmbientes()
    {
        return $this->ambientes;
    }
    
    public function setAmbientes($ambientes)
    {
        $this->ambientes = $ambientes;
    }
        
    public function __destruct()
    {
        $this->medidas   = "";
        $this->ambientes = "";
    }
    
    public function DatosEdificio()
    {
    	return "-- Datos del terreno --" . "\n\n"
            . "[+] Medidas : " . $this->medidas . "\n"
            . "[+] Ambientes : " . $this->ambientes;
    }
    
}

?>