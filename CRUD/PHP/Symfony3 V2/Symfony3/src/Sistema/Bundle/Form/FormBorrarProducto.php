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

class FormBorrarProducto extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $options = $options["data"];
        $producto = $options["producto"];

        $id = $producto["id"];

        $builder->add('id',HiddenType::class,array('label' => false,'data'=> $id));        

        $builder->add('borrarProducto',SubmitType::class, array('label' => 'Eliminar', 'attr' => array('class' => 'btn-lg btn-danger btn-block')));
        $builder->add('volverLista',SubmitType::class, array('label' => 'Volver', 'attr' => array('class' => 'btn-lg btn-primary btn-block')));
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
