# Written By Ismael Heredia in the year 2016

package Productos;

sub new {
    my $class = shift;
    my $self = {};
    bless $self,$class;
    return $self;
}

sub new2 {
    my $class = shift;
    my ($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor,$fecha_registro) = @_;
    my $self = {};
    $self->{id_producto} = $id_producto;
    $self->{nombre_producto} = $nombre_producto;
    $self->{descripcion} = $descripcion;
    $self->{precio} = $precio;
    $self->{id_proveedor} = $id_proveedor;
    $self->{fecha_registro} = $fecha_registro;
    bless $self,$class;
    return $self;
}

sub getId_producto {
	my $self = shift;
	return $self->{id_producto};
}

sub setId_producto {
    my ($self,$id_producto) = @_;
    $self->{id_producto} = $id_producto;
}
 
sub getNombre_producto {
	my $self = shift;
	return $self->{nombre_producto};
} 

sub setNombre_producto {
    my ($self,$nombre_producto) = @_;
    $self->{nombre_producto} = $nombre_producto;
}

sub getDescripcion {
	my $self = shift;
	return $self->{descripcion};
} 

sub setDescripcion {
    my ($self,$descripcion) = @_;
    $self->{descripcion} = $descripcion;
}

sub getPrecio {
	my $self = shift;
	return $self->{precio};
} 

sub setPrecio {
    my ($self,$precio) = @_;
    $self->{telefono} = $precio;
}

sub getFecha_registro {
	my $self = shift;
	return $self->{fecha_registro};
} 

sub setFecha_registro {
    my ($self,$fecha_registro) = @_;
    $self->{telefono} = $fecha_registro;
}

sub getId_proveedor {
	my $self = shift;
	return $self->{id_proveedor};
}

sub setId_proveedor {
    my ($self,$id_proveedor) = @_;
    $self->{id_proveedor} = $id_proveedor;
}

sub ToString {
	my $self = shift;
	return "Producto{" . "id_producto=" . $self->{id_producto} . ", nombre_producto=" . $self->{nombre_producto} . ", descripcion=" . $self->{descripcion} . ", precio=" . $self->{precio} . ", fecha_registro=" . $self->{fecha_registro} . ", id_proveedor=" . $self->{id_proveedor} . '}';
}

sub destroy
{
   my $self=shift;
   delete ($self->{id_producto});
   delete ($self->{nombre_producto});
   delete ($self->{descripcion});
   delete ($self->{precio});
   delete ($self->{fecha_registro});
   delete ($self->{id_proveedor});
}

1;
