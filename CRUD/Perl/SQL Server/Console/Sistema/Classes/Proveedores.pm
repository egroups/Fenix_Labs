# Written By Ismael Heredia in the year 2016

package Proveedores;

sub new {
    my $class = shift;
    my $self = {};
    bless $self,$class;
    return $self;
}

sub new2 {
    my $class = shift;
    my ($id_proveedor,$nombre_empresa,$direccion,$telefono,$fecha_registro) = @_;
    my $self = {};
    $self->{id_proveedor} = $id_proveedor;
    $self->{nombre_empresa} = $nombre_empresa;
    $self->{direccion} = $direccion;
    $self->{telefono} = $telefono;
    $self->{fecha_registro} = $fecha_registro;
    bless $self,$class;
    return $self;
}

sub getId_proveedor {
	my $self = shift;
	return $self->{id_proveedor};
}

sub setId_proveedor {
    my ($self,$id_proveedor) = @_;
    $self->{id_proveedor} = $id_proveedor;
}
 
sub getNombre_empresa {
	my $self = shift;
	return $self->{nombre_empresa};
} 

sub setNombre_empresa {
    my ($self,$nombre_empresa) = @_;
    $self->{nombre_empresa} = $nombre_empresa;
}

sub getDireccion {
	my $self = shift;
	return $self->{direccion};
} 

sub setDireccion {
    my ($self,$direccion) = @_;
    $self->{direccion} = $direccion;
}

sub getTelefono {
	my $self = shift;
	return $self->{telefono};
} 

sub setTelefono {
    my ($self,$telefono) = @_;
    $self->{telefono} = $telefono;
}

sub getFecha_registro {
	my $self = shift;
	return $self->{fecha_registro};
} 

sub setFecha_registro {
    my ($self,$fecha_registro) = @_;
    $self->{fecha_registro} = $fecha_registro;
}

sub ToString {
	my $self = shift;
	return "Proveedor{" . "id_proveedor=" . $self->{id_proveedor} . ", nombre_empresa=" . $self->{nombre_empresa} . ", direccion=" . $self->{direccion} . ", telefono=" . $self->{telefono} . ", fecha_registro=" . $self->{fecha_registro} . '}'; 
}

sub destroy
{
   my $self=shift;
   delete ($self->{id_proveedor});
   delete ($self->{nombre_empresa});
   delete ($self->{direccion});
   delete ($self->{telefono});
   delete ($self->{fecha_registro});
}

1;
