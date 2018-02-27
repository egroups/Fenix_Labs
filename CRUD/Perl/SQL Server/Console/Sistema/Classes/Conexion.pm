# Written By Ismael Heredia in the year 2016

package Conexion;

use DBI;
use Try::Tiny;
use Classes::Proveedores;
use Classes::Productos;
use PDF::Report;

my $conexion;

sub new {
    my $class = shift;
    my $self = {};
    bless $self,$class;
    return $self;
}

sub abrir_conexion {
	$conexion =  DBI->connect("dbi:ODBC:Driver={SQL Server};Server=localhost\\SQLEXPRESS;Database=sistema;UID=admin;PWD=123456") or die "Can't connect to $data_source: $DBI::errstr";                                                  
}

sub cerrar_conexion {
	$conexion->disconnect;
}

sub cargarConsulta {
	
	my $sql = shift;
	my $cantidad = "0";
	
	abrir_conexion();
	
	my @rows = ();
	
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
		
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		$cantidad++;
	}
	
	$consulta->finish();
	
	cerrar_conexion();
	
	return $cantidad;

}

sub ejecutarConsulta {
	
	my $self = shift;
	my $sql = shift;
	
	my $response = 0;

	try {	
		abrir_conexion();
		my @rows = ();
		my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
		$consulta->execute() or die("\n\nQUERY ERROR:\n\n$DBI::errstr");
		$consulta->finish();
		cerrar_conexion();
		$response = 1;
		
	} catch {
		$response = 0;
	};
		
	return $response;

}

sub ingreso_usuario {
	
	my $self = shift;
	
	my($username,$password) = @_;

	my $response = 0;
	
	my $sql = "select id_usuario from usuarios where usuario='" . $username . "' and clave='" . $password . "'";
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

#

sub comprobar_existencia_producto_crear {
	
	my $self = shift;
	
	my($nombre_producto) = @_;

	my $response = 0;
	
	my $sql = "select * from productos where nombre_producto like '".$nombre_producto."'";
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

sub comprobar_existencia_producto_editar {
	
	my $self = shift;
	
	my($id_producto,$nombre_producto) = @_;

	my $response = 0;
	
	my $sql = "select * from productos where nombre_producto like '" . $nombre_producto . "' and id_producto!=".$id_producto;
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

sub comprobar_existencia_proveedor_crear {
	
	my $self = shift;
	
	my($nombre_empresa) = @_;

	my $response = 0;
	
	my $sql = "select * from proveedores where nombre_empresa like '" . $nombre_empresa . "'";
			
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

sub comprobar_existencia_proveedor_editar {
	
	my $self = shift;
	
	my($id_proveedor,$nombre_empresa) = @_;

	my $response = 0;
	
	my $sql = "select * from proveedores where nombre_empresa like '" . $nombre_empresa . "' and id_proveedor!=" . $id_proveedor;
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

sub comprobar_existencia_usuario_crear {
	
	my $self = shift;
	
	my($nombre_usuario) = @_;

	my $response = 0;
	
	my $sql = "select * from usuarios where usuario like '" . $nombre_usuario . "'";
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

sub comprobar_existencia_usuario_editar {
	
	my $self = shift;
	
	my($nombre_usuario) = @_;

	my $response = 0;
	
	my $sql = "select * from usuarios where usuario like '" . $nombre_usuario . "'";
		
	my $cantidad = cargarConsulta($sql);
	
	if($cantidad >= 1) {
		$response = 1;
	} else {
		$response = 0;
	}
	return $response;
}

#

sub es_admin {
	
	my $self = shift;
	my($username) = @_;
	
	my $response = 0;
	
	abrir_conexion();
	
	my @rows = ();
	my $sql = "select tipo from usuarios where usuario='" . $username . "'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	@rows = $consulta->fetchrow_array();

	my $tipo = @rows[0];
	
	if($tipo eq "1") {
		$response = 1;
	} else {
		$response = 0;
	}

	$consulta->finish();	
	
	cerrar_conexion();
	
	return $response;
	
}

sub cargarNombreProveedor {
	
	my $self = shift;
	my($id_proveedor) = @_;
	
	my $nombre_proveedor = "";
	
	abrir_conexion();
	
	my @rows = ();
	my $sql = "select nombre_empresa from proveedores where id_proveedor='" . $id_proveedor . "'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	@rows = $consulta->fetchrow_array();

	my $nombre_proveedor = @rows[0];

	$consulta->finish();	
	
	cerrar_conexion();
	
	return $nombre_proveedor;
	
}

sub cargarNombreProveedorOut {
	
	my($id_proveedor) = @_;
	
	my $nombre_proveedor = "";
	
	abrir_conexion();
	
	my @rows = ();
	my $sql = "select nombre_empresa from proveedores where id_proveedor='" . $id_proveedor . "'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	@rows = $consulta->fetchrow_array();

	my $nombre_proveedor = @rows[0];

	$consulta->finish();	
	
	cerrar_conexion();
	
	return $nombre_proveedor;
	
}

sub listarProveedores {
	
	my $self = shift;
	my $patron = shift;

	abrir_conexion();
	
	my @proveedores = ();
	my @rows = ();
	my $sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores where nombre_empresa like '%".$patron."%'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		my $id_proveedor = @rows[0];
		my $nombre_empresa = @rows[1];
		my $direccion = @rows[2];
		my $telefono = @rows[3];
		my $fecha_registro = @rows[4];
		
		#my $proveedor = Proveedores->new();
		#$proveedor->setId_proveedor($id_proveedor);
		#$proveedor->setNombre_empresa($nombre_empresa);
		#$proveedor->setDireccion($direccion);
		#$proveedor->setTelefono($telefono);
		#$proveedor->setFecha_registro($fecha_registro);
		
		my $proveedor = Proveedores->new2($id_proveedor,$nombre_empresa,$direccion,$telefono,$fecha_registro);
		
		push(@proveedores,$proveedor);
	}

	$consulta->finish();
	
	cerrar_conexion();
	
	return @proveedores;

}

sub listarProductos {
	
	my $self = shift;
	my $patron = shift;

	abrir_conexion();
	
	my @productos = ();
	my @rows = ();
	my $sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos where nombre_producto like '%".$patron."%'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		my $id_producto = @rows[0];
		my $nombre_producto = @rows[1];
		my $descripcion = @rows[2];
		my $precio = @rows[3];
		my $id_proveedor = @rows[4];
		my $fecha_registro = @rows[5];
		
		#my $producto = Productos->new();
		#$producto->setId_producto($id_producto);
		#$producto->setNombre_producto($nombre_producto);
		#$producto->setDescripcion($descripcion);
		#$producto->setPrecio($precio);
		#$producto->setFecha_registro($fecha_registro);
		#$producto->setId_proveedor($id_proveedor);

		my $producto = Productos->new2($id_producto,$nombre_producto,$descripcion,$precio,$id_proveedor,$fecha_registro);
		
		push(@productos,$producto);
	}

	$consulta->finish();
	
	cerrar_conexion();
	
	return @productos;

}

sub listarUsuarios {
	
	my $self = shift;
	my $patron = shift;

	abrir_conexion();
	
	my @usuarios = ();
	my @rows = ();
	my $sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios where usuario like '%".$patron."%'";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		my $id_usuario = @rows[0];
		my $usuario = @rows[1];
		my $clave = @rows[2];
		my $tipo = @rows[3];
		my $fecha_registro = @rows[4];
		
		#my $usuario = Usuarios->new();
		#$usuario->setId_usuario($id_usuario);
		#$usuario->setNombre($usuario);
		#$usuario->setPassword($clave);
		#$usuario->setTipo($tipo);
		#$usuario->setFecha_registro($fecha_registro);
		
		my $usuario = Usuarios->new2($id_usuario,$usuario,$clave,$tipo,$fecha_registro);
		
		push(@usuarios,$usuario);
	}

	$consulta->finish();
	
	cerrar_conexion();
	
	return @usuarios;

}

# Reportes

sub generarListadoProductos {
	
	my $self = shift;
	
	my $pdf = new PDF::Report( PageSize => "A4", PageOrientation => "Portrait");
	my %hash_info = ( Author => "Reporte", Creator => "Perl v5.10.1",
	Subject => "Reporte", Title => "Reporte", CreationDate => "D:20110703112700");

	$pdf->setInfo(%hash_info);
	$pdf->newpage(1);
	$pdf->setFont("Helvetica-bold");

	my ($width, $height) = $pdf->getPageDimensions();

	$pdf->setSize(25);
	$pdf->centerString(0, $width, $height-80, "Reporte de listado de productos");

	$pdf->setSize(16);
	
	my $text1 = "id_producto";
	my $text2 = "nombre_producto";
	my $text3 = "precio";
	my $text4 = "fecha_registro";
	my $text5 = "proveedor";
 
	$pdf->addParagraph($text1, 30, $height-150, $width-60, 30, 25, 10);
	$pdf->addParagraph($text2, 130, $height-150, $width-90, 30, 25, 10);
	$pdf->addParagraph($text3, 280, $height-150, $width-90, 30, 25, 10);
	$pdf->addParagraph($text4, 340, $height-150, $width-90, 30, 25, 10);
	$pdf->addParagraph($text5, 460, $height-150, $width-90, 30, 25, 10);

	$pdf->setFont("Helvetica");

	my $lineas = "150";

	abrir_conexion();

	my @rows;
	my $sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
	
		my $id_producto = @rows[0];
		my $nombre_producto = @rows[1];
		my $descripcion = @rows[2];
		my $precio = @rows[3];
		my $id_proveedor = @rows[4];
		my $fecha_registro = @rows[5];
		my $nombre_proveedor = cargarNombreProveedorOut($id_proveedor);
		
		$lineas = $lineas + 30;
				
		$pdf->addParagraph($id_producto, 30, $height-$lineas, $width-60, 30, 25, 10);
		$pdf->addParagraph($nombre_producto, 130, $height-$lineas, $width-90, 30, 25, 10);
		$pdf->addParagraph($precio, 280, $height-$lineas, $width-90, 30, 25, 10);
		$pdf->addParagraph($fecha_registro, 340, $height-$lineas, $width-90, 30, 25, 10);
		$pdf->addParagraph($nombre_proveedor, 460, $height-$lineas, $width-90, 30, 25, 10);
			
	}
	
	$pdf->saveAs("listadoProductos.pdf");
	
	if(-f "listadoProductos.pdf") {
		return 1;
	} else {
		return 0;
	}
	
}


sub generarGraficoProductos {
	
	my $self = shift;
	
	my @productos;
	my @precios;

	abrir_conexion();

	my @rows;
	my $sql = "select nombre_producto,sum(precio) from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor group by nombre_producto";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		my $nombre_producto = $rows[0];
		my $precio = $rows[1];
		push(@productos,$nombre_producto." - "."\$".$precio);
		push(@precios,$precio);
	}

	my $pdf = new PDF::Report( PageSize => "A4", PageOrientation => "Portrait");
	my %hash_info = ( Author => "Reporte", Creator => "Perl v5.10.1",
	Subject => "Reporte", Title => "Reporte", CreationDate => "D:20110703112700");

	$pdf->setInfo(%hash_info);
	$pdf->newpage(1);
	$pdf->setFont("Helvetica-bold");

	my ($width, $height) = $pdf->getPageDimensions();

	$pdf->setSize(25);
	$pdf->centerString(0, $width, $height-80, "Reporte grafico de productos segun precios");

	$pdf->drawPieGraph($width/2, $height-300,150, \@precios, \@productos);

	$pdf->saveAs("graficoProductos.pdf");

	cerrar_conexion();
	
	if(-f "graficoProductos.pdf") {
		return 1;
	} else {
		return 0;
	}
							
}

sub generarGraficoProveedores {
	
	my $self = shift;
	
	my @empresas;
	my @cantidades;

	abrir_conexion();

	my @rows;
	my $sql = "select nombre_empresa,count(prod.id_proveedor) from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor group by nombre_empresa";
	my $consulta = $conexion->prepare($sql) or die("\n\nPREPARE ERROR:\n\n$DBI::errstr");
	$consulta->execute or die("\n\nQUERY ERROR:\n\n$DBI::errstr");

	while(@rows = $consulta->fetchrow_array()) { 
		my $nombre_empresa = $rows[0];
		my $cantidad_productos = $rows[1];
		push(@empresas,$nombre_empresa." - ".$cantidad_productos." productos");
		push(@cantidades,$cantidad_productos);
	}

	my $pdf = new PDF::Report( PageSize => "A4", PageOrientation => "Portrait");
	my %hash_info = ( Author => "Reporte", Creator => "Perl v5.10.1",
	Subject => "Reporte", Title => "Reporte", CreationDate => "D:20110703112700");

	$pdf->setInfo(%hash_info);
	$pdf->newpage(1);
	$pdf->setFont("Helvetica-bold");

	my ($width, $height) = $pdf->getPageDimensions();

	$pdf->setSize(25);
	$pdf->centerString(0, $width, $height-80, "Reporte grafico de proveedores");

	$pdf->drawPieGraph($width/2, $height-300,150, \@cantidades, \@empresas);

	$pdf->saveAs("graficoProveedores.pdf");

	cerrar_conexion();
	
	if(-f "graficoProveedores.pdf") {
		return 1;
	} else {
		return 0;
	}	
		
}

#

sub destroy
{
   my $self=shift;
}

1;
