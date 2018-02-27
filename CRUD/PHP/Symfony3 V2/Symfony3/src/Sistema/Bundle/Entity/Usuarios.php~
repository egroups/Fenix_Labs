<?php

namespace Sistema\Bundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Usuarios
 */
class Usuarios
{

    /**
     * @ORM\ManyToOne(targetEntity="TipoUsuario", inversedBy="tipo_usuario")
     * @ORM\JoinColumn(name="id_tipo", referencedColumnName="id")
     */
    protected $tipo_usuario;

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
    private $clave;

    /**
     * @var int
     */
    private $idTipo;

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
     * @return Usuarios
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
     * Set clave
     *
     * @param string $clave
     *
     * @return Usuarios
     */
    public function setClave($clave)
    {
        $this->clave = $clave;

        return $this;
    }

    /**
     * Get clave
     *
     * @return string
     */
    public function getClave()
    {
        return $this->clave;
    }

    /**
     * Set idTipo
     *
     * @param integer $idTipo
     *
     * @return Usuarios
     */
    public function setIdTipo($idTipo)
    {
        $this->idTipo = $idTipo;

        return $this;
    }

    /**
     * Get idTipo
     *
     * @return int
     */
    public function getIdTipo()
    {
        return $this->idTipo;
    }

    /**
     * Set fechaRegistro
     *
     * @param string $fechaRegistro
     *
     * @return Usuarios
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
