# Written By Ismael Heredia in the year 2016

package Usuarios;

sub new {
    my $class = shift;
    my $self = {};
    bless $self,$class;
    return $self;
}

sub new2 {
    my $class = shift;
    my ($id_usuario,$nombre,$password,$tipo,$fecha_registro) = @_;
    my $self = {};
    $self->{id_usuario} = $id_usuario;
    $self->{nombre} = $nombre;
    $self->{password} = $password;
    $self->{tipo} = $tipo;
    $self->{fecha_registro} = $fecha_registro;
    bless $self,$class;
    return $self;
}

sub getId_usuario {
	my $self = shift;
	return $self->{id_usuario};
}

sub setId_usuario {
    my ($self,$id_usuario) = @_;
    $self->{id_id_usuario} = $id_usuario;
}
 
sub getNombre {
	my $self = shift;
	return $self->{nombre};
} 

sub setNombre {
    my ($self,$nombre) = @_;
    $self->{nombre} = $nombre;
}

sub getPassword {
	my $self = shift;
	return $self->{password};
} 

sub setPassword {
    my ($self,$password) = @_;
    $self->{password} = $password;
}

sub getTipo {
	my $self = shift;
	return $self->{tipo};
} 

sub setTipo {
    my ($self,$tipo) = @_;
    $self->{tipo} = $tipo;
}

sub getFecha_registro {
	my $self = shift;
	return $self->{fecha_registro};
} 

sub setFecha_registro {
    my ($self,$fecha_registro) = @_;
    $self->{telefono} = $fecha_registro;
}

sub ToString {
	my $self = shift;
	return "Usuario{" . "id_usuario=" . $self->{id_usuario} . ", nombre=" . $self->{nombre} . ", password=" . $self->{password} . ", tipo=" . $self->{tipo} . ", fecha_registro=" . $self->{fecha_registro} . '}';
}

sub destroy
{
   my $self=shift;
   delete ($self->{id_usuario});
   delete ($self->{nombre});
   delete ($self->{password});
   delete ($self->{tipo});
   delete ($self->{fecha_registro});
}

1;
