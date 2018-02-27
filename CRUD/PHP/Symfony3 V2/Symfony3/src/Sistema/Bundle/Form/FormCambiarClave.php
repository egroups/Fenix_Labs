<?php

namespace Sistema\Bundle\Form;

use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\OptionsResolver\OptionsResolver;

use Symfony\Component\Form\Extension\Core\Type\HiddenType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\PasswordType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\ButtonType;
use Symfony\Component\Form\Extension\Core\Type\TextareaType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;

class FormCambiarClave extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $options = $options["data"];

        $usuario = $options["usuario"];

        $id = $usuario["id"];
        $nombre_usuario = $usuario["nombre"];
        $clave = $usuario["clave"];
        $tipo = $usuario["tipo"];

        $builder->add('id',HiddenType::class,array('label' => false,'data'=> $id));  

        $builder->add('usuario',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese usuario','readonly'=>'readonly'),'label' => false,'data'=>$nombre_usuario));
        $builder->add('actual_clave',PasswordType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese actual clave'),'label' => false));
        $builder->add('nueva_clave',PasswordType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese nueva clave'),'label' => false));
        $builder->add('cambiarClave',SubmitType::class, array('label' => 'Cambiar', 'attr' => array('class' => 'btn btn-primary button_class center-block')));
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
        return 'sistema_bundle_cambiar_clave';
    }


}
