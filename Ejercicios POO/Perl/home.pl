#!usr/bin/perl
# Written By Ismael Heredia in the year 2016

use Classes::Productos;
use Classes::Proveedores;
use Classes::Usuarios;

#my $producto = Productos->new2(1,"test","test",123,1,"test");
#my $proveedor = Proveedores->new2(1,"test","test",123,"test");	
#my $usuario = Usuarios->new2(1,"test","test",1,"test");

my $producto = Productos->new();
$producto->setNombre_producto("test");

my $proveedor = Proveedores->new();
$proveedor->setNombre_empresa("test");

my $usuario = Usuarios->new();
$usuario->setNombre("test");

print $producto->ToString()."\n";
print $proveedor->ToString()."\n";
print $usuario->ToString()."\n";