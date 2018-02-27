<?php

// Written By Ismael Heredia in the year 2016

class Cochera
{
    
    private $ambientes;
    private $dimensiones;
	private $auto;
    
    public function __construct()
    {
        $this->ambientes   = "";
        $this->dimensiones = "";
		$this->auto = "";
    }
    
    public static function CreateCochera($ambientes,$dimensiones,$auto)
    {
        $instance                 = new self();
        $instance->ambientes   = $ambientes;
        $instance->dimensiones = $dimensiones;
		$instance->auto   = $auto;
        return $instance;
    }
    
    public function getAmbientes()
    {
        return $this->ambientes;
    }
    
    public function setAmbientes($ambientes)
    {
        $this->ambientes = $ambientes;
    }
    
    public function getDimensiones()
    {
        return $this->dimensiones;
    }
    
    public function setDimensiones($dimensiones)
    {
        $this->dimensiones = $dimensiones;
    }
	
    public function getAuto()
    {
        return $this->auto;
    }
    
    public function setAuto($auto)
    {
        $this->auto = $auto;
    }
        
    public function __destruct()
    {
        $this->ambientes   = "";
        $this->dimensiones = "";
		$this->auto = "";
    }
    
    public function DatosCochera()
    {
    	return "-- Datos de la cochera -- " . "\n\n"
                . "[+] Ambientes : " . $this->ambientes . "\n"
                . "[+] Dimensiones : " . $this->dimensiones . "\n" . $this->auto->getMarca();
    }
	
    public function DatosCocheraCompleto()
    {
    	$contenido =  "-- Datos de la cochera -- " . "\n\n"
                . "[+] Ambientes : " . $this->ambientes . "\n"
                . "[+] Dimensiones : " . $this->dimensiones . "\n";
				
		if(!is_null($this->auto)) {
        	$contenido = $contenido . "\n-- Datos del auto --" . "\n\n"
                . "[+] Marca : " . $this->auto->getMarca() . "\n"
                . "[+] Numero de serie : " . $this->auto->getNumero_serie() . "\n";	
		}
		return $contenido;		
    }
	
    
}

?>