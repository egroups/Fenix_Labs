<?php

namespace Sistema\Bundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Productos
 */
class Productos
{

    /**
     * @ORM\ManyToOne(targetEntity="Proveedores", inversedBy="productos")
     * @ORM\JoinColumn(name="id_proveedor", referencedColumnName="id")
     */
    protected $proveedores;

    /**
     * @var int
     */
    private $id;

    /**
     * @var string
     */
    private $nombre;

    /**
     * @var string
     */
    private $descripcion;

    /**
     * @var int
     */
    private $precio;

    /**
     * @var int
     */
    private $idProveedor;

    /**
     * @var string
     */
    private $fechaRegistro;


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
     * Set nombre
     *
     * @param string $nombre
     *
     * @return Productos
     */
    public function setNombre($nombre)
    {
        $this->nombre = $nombre;

        return $this;
    }

    /**
     * Get nombre
     *
     * @return string
     */
    public function getNombre()
    {
        return $this->nombre;
    }

    /**
     * Set descripcion
     *
     * @param string $descripcion
     *
     * @return Productos
     */
    public function setDescripcion($descripcion)
    {
        $this->descripcion = $descripcion;

        return $this;
    }

    /**
     * Get descripcion
     *
     * @return string
     */
    public function getDescripcion()
    {
        return $this->descripcion;
    }

    /**
     * Set precio
     *
     * @param integer $precio
     *
     * @return Productos
     */
    public function setPrecio($precio)
    {
        $this->precio = $precio;

        return $this;
    }

    /**
     * Get precio
     *
     * @return int
     */
    public function getPrecio()
    {
        return $this->precio;
    }

    /**
     * Set idProveedor
     *
     * @param integer $idProveedor
     *
     * @return Productos
     */
    public function setIdProveedor($idProveedor)
    {
        $this->idProveedor = $idProveedor;

        return $this;
    }

    /**
     * Get idProveedor
     *
     * @return int
     */
    public function getIdProveedor()
    {
        return $this->idProveedor;
    }

    /**
     * Set fechaRegistro
     *
     * @param string $fechaRegistro
     *
     * @return Productos
     */
    public function setFechaRegistro($fechaRegistro)
    {
        $this->fechaRegistro = $fechaRegistro;

        return $this;
    }

    /**
     * Get fechaRegistro
     *
     * @return string
     */
    public function getFechaRegistro()
    {
        return $this->fechaRegistro;
    }
}
