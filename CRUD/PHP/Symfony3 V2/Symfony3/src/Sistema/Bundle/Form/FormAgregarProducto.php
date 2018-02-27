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

class FormAgregarProducto extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $options = $options["data"];

        $datos_proveedores = $options["combo_proveedores"];

        $builder->add('nombre',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese nombre'),'label' => false));
        $builder->add('descripcion',TextareaType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese descripción','rows'=>3),'label'=>false));
        $builder->add('precio',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese precio'),'label'=>false));

        $builder->add('idProveedor',ChoiceType::class,array('choices' => $datos_proveedores,'placeholder'=>'Seleccione proveedor','attr'=>array('class'=>'form-control')));

        $builder->add('agregarProducto',SubmitType::class, array('label' => 'Agregar', 'attr' => array('class' => 'btn btn-primary button_class center-block')));
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
