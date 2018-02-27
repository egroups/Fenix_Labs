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

class FormAgregarProveedor extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {

        $builder->add('nombre',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese nombre'),'label' => false));
        $builder->add('direccion',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese dirección'),'label'=>false));
        $builder->add('telefono',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese teléfono'),'label'=>false));

        $builder->add('agregarProveedor',SubmitType::class, array('label' => 'Agregar', 'attr' => array('class' => 'btn btn-primary button_class center-block')));
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
        return 'sistema_bundle_proveedores';
    }


}
