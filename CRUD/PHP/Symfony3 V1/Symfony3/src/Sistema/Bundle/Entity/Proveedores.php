<?php

namespace Sistema\Bundle\Entity;

use Doctrine\ORM\Mapping as ORM;
use Doctrine\Common\Collections\ArrayCollection;

/**
 * Proveedores
 */
class Proveedores
{

    /**
     * @ORM\OneToMany(targetEntity="Productos", mappedBy="proveedores")
     */
    protected $productos;
 
    public function __construct()
    {
        $this->productos = new ArrayCollection();
    }

    /**
     * @var int
     */
    private $id;

    /**
     * @var string
     */
    private $nombreEmpresa;

    /**
     * @var string
     */
    private $direccion;

    /**
     * @var int
     */
    private $telefono;

    /**
     * @var string
     */
    private $fechaRegistroProveedor;


    /**
     * Get id
     *
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set nombreEmpresa
     *
     * @param string $nombreEmpresa
     *
     * @return Proveedores
     */
    public function setNombreEmpresa($nombreEmpresa)
    {
        $this->nombreEmpresa = $nombreEmpresa;

        return $this;
    }

    /**
     * Get nombreEmpresa
     *
     * @return string
     */
    public function getNombreEmpresa()
    {
        return $this->nombreEmpresa;
    }

    /**
     * Set direccion
     *
     * @param string $direccion
     *
     * @return Proveedores
     */
    public function setDireccion($direccion)
    {
        $this->direccion = $direccion;

        return $this;
    }

    /**
     * Get direccion
     *
     * @return string
     */
    public function getDireccion()
    {
        return $this->direccion;
    }

    /**
     * Set telefono
     *
     * @param integer $telefono
     *
     * @return Proveedores
     */
    public function setTelefono($telefono)
    {
        $this->telefono = $telefono;

        return $this;
    }

    /**
     * Get telefono
     *
     * @return int
     */
    public function getTelefono()
    {
        return $this->telefono;
    }

    /**
     * Set fechaRegistroProveedor
     *
     * @param string $fechaRegistroProveedor
     *
     * @return Proveedores
     */
    public function setFechaRegistroProveedor($fechaRegistroProveedor)
    {
        $this->fechaRegistroProveedor = $fechaRegistroProveedor;

        return $this;
    }

    /**
     * Get fechaRegistroProveedor
     *
     * @return string
     */
    public function getFechaRegistroProveedor()
    {
        return $this->fechaRegistroProveedor;
    }
}
