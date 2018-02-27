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

class FormEditarUsuario extends AbstractType
{
    /**
     * {@inheritdoc}
     */
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $options = $options["data"];
        $datos_tipos = $options["combo_tipos"];
        $usuario = $options["usuario"];

        $id = $usuario["id"];
        $nombre = $usuario["nombre"];
        $clave = "******";
        $tipo = $usuario["idTipo"];

        $builder->add('id',HiddenType::class,array('label' => false,'data'=> $id));        

        $builder->add('nombre',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese nombre','readonly'=>'readonly'),'label' => false,'data'=>$nombre));
        $builder->add('clave',TextType::class,array('attr'=>array('class'=>'form-control','placeholder'=>'Ingrese clave','readonly'=>'readonly'),'label'=>false,'data'=>$clave));
 
        $builder->add('tipo',ChoiceType::class,array('choices' => $datos_tipos,'attr'=>array('class'=>'form-control'),'data'=>$tipo));

        $builder->add('editarUsuario',SubmitType::class, array('label' => 'Editar', 'attr' => array('class' => 'btn btn-primary button_class center-block')));
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
        return 'sistema_bundle_usuarios';
    }


}
