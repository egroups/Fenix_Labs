<?php

namespace Sistema\Bundle\Form;

use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\OptionsResolver\OptionsResolver;

use Symfony\Component\Form\Extension\Core\Type\HiddenType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\ButtonType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;

class FormEditarProducto extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $options = $options["data"];
        $datos_proveedores = $options["combo_proveedores"];
        $producto = $options["producto"];

        $id = $producto["id"];
        $nombre = $producto["nombre"];
        $descripcion = $producto["descripcion"];
        $precio = $producto["precio"];
        $idProveedor = $producto["idProveedor"];

        $builder->add('id',HiddenType::class,array('label' => false,'data'=> $id));        
        $builder->add('nombre',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese nombre'),'label' => false,'data'=>$nombre));
        $builder->add('descripcion',TextareaType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese descripción','rows'=>3),'label'=>false,'data'=>$descripcion));
        $builder->add('precio',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese precio'),'label'=>false,'data'=>$precio));

        $builder->add('idProveedor',ChoiceType::class,array('choices' => $datos_proveedores,'placeholder'=>'Seleccione proveedor','attr'=>array('class'=>'form-control'),'data'=>$idProveedor));

        $builder->add('editarProducto',SubmitType::class, array('label' => 'Editar', 'attr' => array('class' => 'btn btn-primary button_class center-block')));
    }
    
    /**
     * {@inheritdoc}
     */
    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults(array(
            'data_class' => null
        ));
    }

    /**
     * {@inheritdoc}
     */
    public function getBlockPrefix()
    {
        return 'sistema_bundle_productos';
    }


}
