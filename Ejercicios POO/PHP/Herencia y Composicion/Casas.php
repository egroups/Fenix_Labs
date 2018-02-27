<?php

// Written By Ismael Heredia in the year 2016

class Casa extends Edificio
{
    
    private $dueño;
    private $telefono;
	private $direccion;
	private $cochera;
    
    public function __construct()
    {
        $this->dueño   = "";
        $this->telefono = "";
		$this->direccion = "";
		$this->cochera = "";
    }
    
    public static function CreateCasa($medidas,$ambientes,$dueño,$telefono,$direccion,$cochera)
    {
        $instance                 = new self();
		$instance->medidas   = $medidas;
		$instance->ambientes   = $ambientes;
        $instance->dueño   = $dueño;
        $instance->telefono = $telefono;
		$instance->direccion = $direccion;
		$instance->cochera = $cochera;
        return $instance;
    }
    
    public function getDueño()
    {
        return $this->dueño;
    }
    
    public function setDueño($dueño)
    {
        $this->dueño = $dueño;
    }
    
    public function getTelefono()
    {
        return $this->telefono;
    }
    
    public function setTelefono($telefono)
    {
        $this->telefono = $telefono;
    }
	
    public function getDireccion()
    {
        return $this->direccion;
    }
    
    public function setDireccion($direccion)
    {
        $this->direccion = $direccion;
    }
	
    public function getCochera()
    {
        return $this->cochera;
    }
    
    public function setCochera($cochera)
    {
        $this->cochera = $cochera;
    }
        
    public function __destruct()
    {
        $this->dueño   = "";
        $this->telefono = "";
		$this->direccion = "";
		$this->cochera = "";
    }
	
    public function DatosCasa()
    {
    	$contenido = "";
		
        $contenido = $contenido . "-- Datos del terreno --" . "\n\n" .
                "[+] Medidas : " . $this->medidas . "\n" .
                "[+] Ambientes : " . $this->ambientes . "\n\n";

         $contenido = $contenido . "-- Datos de la casa --" . "\n\n"
            . "[+] Dueño : " . $this->dueño . "\n"
            . "[+] Telefono : " . $this->telefono . "\n"
            . "[+] Direccion : " . $this->direccion . "\n";
		
		if(!is_null($this->cochera)) {	
    		$contenido =  $contenido . "[+] Cochera : " . $this->cochera->getDimensiones() . "\n";
		}
					
		return $contenido;
    }
    
    public function DatosCasaCompleto()
    {
    	$contenido = "";
		
        $contenido = $contenido . "-- Datos del terreno --" . "\n\n" .
                "[+] Medidas : " . $this->medidas . "\n" .
                "[+] Ambientes : " . $this->ambientes . "\n\n";

         $contenido = $contenido . "-- Datos de la casa --" . "\n\n"
            . "[+] Dueño : " . $this->dueño . "\n"
            . "[+] Telefono : " . $this->telefono . "\n"
            . "[+] Direccion : " . $this->direccion . "\n";
		
		if(!is_null($this->cochera)) {
			
    		$contenido =  $contenido . "\n-- Datos de la cochera -- " . "\n\n"
                . "[+] Ambientes : " . $this->cochera->getAmbientes() . "\n"
                . "[+] Dimensiones : " . $this->cochera->getDimensiones() . "\n";
		
				
			if(!is_null($this->cochera->getAuto())) {
        		$contenido = $contenido . "\n-- Datos del auto --" . "\n\n"
                . "[+] Marca : " . $this->cochera->getAuto()->getMarca() . "\n"
                . "[+] Numero de serie : " . $this->cochera->getAuto()->getNumero_serie() . "\n";	
			}
		
		}
			
		return $contenido;
    }
    
}

?>