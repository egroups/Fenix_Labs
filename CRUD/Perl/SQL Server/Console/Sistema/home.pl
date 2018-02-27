#!usr/bin/perl
# Written By Ismael Heredia in the year 2016

use Classes::Proveedores;
use Classes::Usuarios;
use Classes::Conexion;

use utf8;
use Digest::MD5 qw(md5_hex);
use POSIX qw(strftime);
use Cwd;

my $username_login = "";

login();

sub clean {
	system("cls");
	system("color b");
}

sub clean_login {
	system("cls");
	system("color c");
}

sub head {
	print "\n-- == Sistema == --\n";
}

sub isdigit {
	my $text = shift;
	if ($text=~/^-?\d+$/) {
		return 1;
	} else {
		return 0;
	}
}

sub getFecha {
	return strftime "%m/%d/%Y", localtime;
}

sub cargarReporte {
	my $nombre = shift;
	my $directory_me = getcwd();
	my $filename = $directory_me."/".$nombre;
	my $command = "\"".$filename."\" ";
	system($command);
}

sub listar_proveedores {
	
	print "\n[+] Nombre empresa : ";
	chomp(my $nombre_empresa = <STDIN>);
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProveedores($nombre_empresa);
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
	
		print "\n[+] Proveedores encontrados : ".$cantidad."\n";
		
		for my $proveedor(@lista) {
		
			my $id_proveedor = $proveedor->getId_proveedor();
			my $nombre_empresa = $proveedor->getNombre_empresa();
			my $direccion = $proveedor->getDireccion();
			my $telefono = $proveedor->getTelefono();
			my $fecha_registro = $proveedor->getFecha_registro();
		
			print "\n[+] ID : ".$id_proveedor."\n";
			print "[+] Nombre empresa : ".$nombre_empresa."\n";
			print "[+] Direccion : ".$direccion."\n";
			print "[+] Telefono : ".$telefono."\n";
			print "[+] Fecha Registro : ".$fecha_registro."\n\n";
		}

	} else {
		print "\n[-] No se encontraron proveedores\n";
	}
	
	$conexion_now->destroy();
	
}

sub listar_proveedores_ids {
	
	print "\n[+] Nombre empresa : ";
	chomp(my $nombre_empresa = <STDIN>);
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProveedores($nombre_empresa);
	
	print "\n------------ Proveedores Disponibles ------------\n";
	
	for my $proveedor(@lista) {
		
		my $id_proveedor = $proveedor->getId_proveedor();
		my $nombre_empresa = $proveedor->getNombre_empresa();
		my $direccion = $proveedor->getDireccion();
		my $telefono = $proveedor->getTelefono();
		my $fecha_registro = $proveedor->getFecha_registro();
		
		print "\n[+] ID : ".$id_proveedor."\t"."[+] Nombre empresa : ".$nombre_empresa;

	}
	
	$conexion_now->destroy();
	
	print "\n-------------------------------------------------\n";
	
}

sub agregar_proveedor {
	print "\n[+] Nombre empresa : ";
	chomp(my $nombre_empresa = <STDIN>);
	print "\n[+] Direccion : ";
	chomp(my $direccion = <STDIN>);
	print "\n[+] Telefono : ";
	chomp(my $telefono = <STDIN>);
	my $fecha_registro = getFecha();
	if($nombre_empresa eq "" or $direccion eq "" or $telefono eq "" or !isdigit($telefono)) {
		print "\n[-] Faltan datos\n";
		<STDIN>;
		menu_principal();
	} else {

		my $conexion_now = Conexion->new();
		
		if($conexion_now->comprobar_existencia_proveedor_crear($nombre_empresa)) {
			print "\n[-] El proveedor $nombre_empresa ya existe\n";
		} else {
		
			my $sql = "insert into proveedores values('" . $nombre_empresa . "','" . $direccion . "'," . $telefono . ",'" . $fecha_registro . "')";
				
			if($conexion_now->ejecutarConsulta($sql)) {
				print "\n[+] Registro agregado\n";
			} else {
				print "\n[-] Ha ocurrido un error en la base de datos\n";
			}
		
		}
		
		$conexion_now->destroy();
		
		<STDIN>;
		menu_principal();	
	}
	
}

sub editar_proveedor {

	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProveedores();
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
		listar_proveedores_ids();
		print "\n[+] ID : ";
		chomp(my $id_proveedor = <STDIN>);
		if($id_proveedor eq "" or !isdigit($id_proveedor)) {
			print "\n[-] Datos invalidos\n";
		} else {
			
			print qq(
				
	============ Opciones ============
				
		[1] Editar nombre empresa
		[2] Editar direccion
		[3] Editar telefono
		[4] Volver al menu
				
	==================================
			
			);
			
			print "\n[+] Opcion : ";
			chomp(my $opcion = <STDIN>);	
			
			if($opcion ne "" and isdigit($opcion)) {
				if($opcion eq "1") {
					print "\n[+] Nombre empresa : ";
					chomp(my $nombre_empresa = <STDIN>);
					if($nombre_empresa eq "") {
						print "\n[-] Datos invalidos\n";
					} else {
						if($conexion_now->comprobar_existencia_proveedor_editar($id_proveedor,$nombre_empresa)) {
							print "\n[-] El proveedor $nombre_empresa ya existe\n";
						} else {
							my $sql = "update proveedores set nombre_empresa='" . $nombre_empresa . "' where id_proveedor=" . $id_proveedor;
							if($conexion_now->ejecutarConsulta($sql)) {
								print "\n[+] Registro actualizado\n";
							} else {
								print "\n[-] Ha ocurrido un error en la base de datos\n";
							}
						}						
					}			
				}elsif($opcion eq "2") {
					print "\n[+] Direccion : ";
					chomp(my $direccion = <STDIN>);
					if($direccion eq "") {
						print "\n[-] Datos invalidos\n";
					} else {
						my $sql = "update proveedores set direccion='" . $direccion . "' where id_proveedor=" . $id_proveedor;
						if($conexion_now->ejecutarConsulta($sql)) {
							print "\n[+] Registro actualizado\n";
						} else {
							print "\n[-] Ha ocurrido un error en la base de datos\n";
						}													
					}					
				}elsif($opcion eq "3") {
					print "\n[+] Telefono : ";
					chomp(my $telefono = <STDIN>);
					if($telefono eq "" or !isdigit($telefono)) {
						print "\n[-] Datos invalidos\n";
					} else {
						my $sql = "update proveedores set telefono=" . $telefono . " where id_proveedor=" . $id_proveedor;
						if($conexion_now->ejecutarConsulta($sql)) {
							print "\n[+] Registro actualizado\n";
						} else {
							print "\n[-] Ha ocurrido un error en la base de datos\n";
						}													
					}						
				}elsif($opcion eq "4") {
					menu_principal();
				} else {
					menu_principal();
				}
			} else {
				print "\n[-] Opcion no valida\n";
			}
							
		}
	} else {
		print "\n[-] No se encontraron proveedores disponibles\n";
	}
	
	$conexion_now->destroy();
	
}

sub borrar_proveedor {
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProveedores();
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
		listar_proveedores_ids();
		print "\n[+] ID : ";
		chomp(my $id_proveedor = <STDIN>);
		if($id_proveedor eq "" or !isdigit($id_proveedor)) {
			print "\n[-] Datos invalidos\n";
		} else {
			my $sql = "delete from proveedores where id_proveedor=" . $id_proveedor;
			if($conexion_now->ejecutarConsulta($sql)) {
				print "\n[+] Registro eliminado\n";
			} else {
				print "\n[-] Ha ocurrido un error en la base de datos\n";
			}	
		}
	} else {
		print "\n[-] No se encontraron proveedores disponibles\n";
	}
	
	$conexion_now->destroy();
	
}

sub listar_productos {
	
	print "\n[+] Nombre producto : ";
	chomp(my $nombre_producto = <STDIN>);
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProductos($nombre_producto);
	
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
	
		print "\n[+] Productos encontrados : ".$cantidad."\n";
		
		for my $producto(@lista) {
		
			my $id_producto = $producto->getId_producto();
			my $nombre_producto = $producto->getNombre_producto();
			my $descripcion = $producto->getDescripcion();
			my $precio = $producto->getPrecio();
			my $id_proveedor = $producto->getId_proveedor();
			my $nombre_proveedor = $conexion_now->cargarNombreProveedor($id_proveedor);
			my $fecha_registro = $producto->getFecha_registro();
		
			print "\n[+] ID : ".$id_producto."\n";
			print "[+] Nombre producto : ".$nombre_producto."\n";
			print "[+] Descripcion : ".$descripcion."\n";
			print "[+] Precio : ".$precio."\n";
			print "[+] Proveedor : ".$nombre_proveedor."\n";
			print "[+] Fecha Registro : ".$fecha_registro."\n\n";

		}
	
	} else {
		print "\n[-] No se encontraron productos disponibles\n";
	}
	
	$conexion_now->destroy();	
}

sub listar_productos_ids {
	
	print "\n[+] Nombre producto : ";
	chomp(my $nombre_producto = <STDIN>);
		
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProductos($nombre_producto);
	
	my $cantidad = scalar(@lista);
	
	print "\n------------ Productos Disponibles ------------\n";
				
	for my $producto(@lista) {
		
		my $id_producto = $producto->getId_producto();
		my $nombre_producto = $producto->getNombre_producto();
		my $descripcion = $producto->getDescripcion();
		my $precio = $producto->getPrecio();
		my $id_proveedor = $producto->getId_proveedor();
		my $nombre_proveedor = $conexion_now->cargarNombreProveedor($id_proveedor);
		my $fecha_registro = $producto->getFecha_registro();
		
		print "\n[+] ID : ".$id_producto."\t"."[+] Nombre producto : ".$nombre_producto;

	}	
	
	print "\n-------------------------------------------------\n";
		
	$conexion_now->destroy();	
}

sub agregar_producto {

	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProveedores();
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
		print "\n[+] Nombre producto : ";
		chomp(my $nombre_producto = <STDIN>);
		print "\n[+] Descripcion : ";
		chomp(my $descripcion = <STDIN>);
		print "\n[+] Precio : ";
		chomp(my $precio = <STDIN>);
		listar_proveedores_ids();
		print "\n[+] ID Proveedor : ";
		chomp(my $id_proveedor = <STDIN>);
		if($nombre_producto eq "" or $descripcion eq "" or $precio eq "" or !isdigit($precio) or $id_proveedor eq "" or !isdigit($id_proveedor)) {
			print "\n[-] Faltan datos\n";
			<STDIN>;
			menu_principal();			
		} else {
			
			my $conexion_now = Conexion->new();
			
			if($conexion_now->comprobar_existencia_producto_crear($nombre_producto)) {
				print "\n[-] El producto $nombre_producto ya existe\n";
			} else {
			
				my $fecha_registro = getFecha();
		
				my $sql = "insert into productos values('" . $nombre_producto . "','" . $descripcion . "'," . $precio . "," . $id_proveedor . ",'" . $fecha_registro . "')";
				
				if($conexion_now->ejecutarConsulta($sql)) {
					print "\n[+] Registro agregado\n";
				} else {
					print "\n[-] Ha ocurrido un error en la base de datos\n";
				}
			
			}
		
			$conexion_now->destroy();
		
			<STDIN>;
			menu_principal();	
					
		}
	} else {
		print "\n[-] No se encontraron proveedores disponibles\n";
	}
	
}

sub editar_producto {
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProductos();
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
		listar_productos_ids();
		print "\n[+] ID : ";
		chomp(my $id_producto = <STDIN>);
		if($id_producto eq "" or !isdigit($id_producto)) {
			print "\n[-] Datos invalidos\n";
		} else {
			
			print qq(
				
	============ Opciones ============
				
		[1] Editar nombre producto
		[2] Editar descripcion
		[3] Editar precio
		[4] Editar proveedor
		[5] Volver al menu
				
	==================================
			
			);
						
			print "\n[+] Opcion : ";
			chomp(my $opcion = <STDIN>);
			
			if($opcion ne "" and isdigit($opcion)) {
				
				if($opcion eq "1") {
					print "\n[+] Nombre producto : ";
					chomp(my $nombre_producto = <STDIN>);
					if($nombre_producto eq "") {
						print "\n[-] Datos invalidos\n";
					} else {
						if($conexion_now->comprobar_existencia_producto_editar($id_producto,$nombre_producto)) {
							print "\n[-] El producto $nombre_producto ya existe\n";
						} else {						
							my $sql = "update productos set nombre_producto='" . $nombre_producto . "' where id_producto=" . $id_producto;
							if($conexion_now->ejecutarConsulta($sql)) {
								print "\n[+] Registro actualizado\n";
							} else {
								print "\n[-] Ha ocurrido un error en la base de datos\n";
							}	
						}
					 }
															
				} elsif($opcion eq "2") {
					print "\n[+] Descripcion : ";
					chomp(my $descripcion = <STDIN>);	
					if($descripcion eq "") {
						print "\n[-] Datos invalidos\n";						
					} else {
						my $sql = "update productos set descripcion='" . $descripcion . "' where id_producto=" . $id_producto;
						if($conexion_now->ejecutarConsulta($sql)) {
							print "\n[+] Registro actualizado\n";
						} else {
							print "\n[-] Ha ocurrido un error en la base de datos\n";
						}	
					}			
				} elsif($opcion eq "3") {
					print "\n[+] Precio : ";
					chomp(my $precio = <STDIN>);
					if($precio eq "" or !isdigit($precio)) {
						print "\n[-] Datos invalidos\n";														
					} else {
						my $sql = "update productos set precio=" . $precio . " where id_producto=" . $id_producto;
						if($conexion_now->ejecutarConsulta($sql)) {
							print "\n[+] Registro actualizado\n";
						} else {
							print "\n[-] Ha ocurrido un error en la base de datos\n";
						}	
					}					
				} elsif($opcion eq "4") {
					listar_proveedores_ids();
					print "\n[+] Nuevo ID Proveedor : ";
					chomp(my $id_proveedor = <STDIN>);	
					if($id_proveedor eq "" or !isdigit($id_proveedor)) {
						print "\n[-] Datos invalidos\n";
					} else {
						
						my $sql = "update productos set id_proveedor=" . $id_proveedor . " where id_producto=" . $id_producto;
						if($conexion_now->ejecutarConsulta($sql)) {
							print "\n[+] Registro actualizado\n";
						} else {
							print "\n[-] Ha ocurrido un error en la base de datos\n";
						}
												
					}
				} elsif($opcion eq "5") {
					menu_principal();
				} else {
					menu_principal();
				}	
				
			} else {
				print "\n[-] Opcion no valida\n";
			}			
		}
	} else {
		print "\n[-] No se encontraron productos disponibles\n";
	}
	
	$conexion_now->destroy();
	
}

sub borrar_producto {
	
	my $conexion_now = Conexion->new();
	
	my @lista = $conexion_now->listarProductos();
		
	my $cantidad = scalar(@lista);
	
	if($cantidad >= 1) {
		listar_productos_ids();
		print "\n[+] ID : ";
		chomp(my $id_producto = <STDIN>);
		if($id_producto eq "" or !isdigit($id_producto)) {
			print "\n[-] Datos invalidos\n";
		} else {
			my $sql = "delete from productos where id_producto=" . $id_producto;
			if($conexion_now->ejecutarConsulta($sql)) {
				print "\n[+] Registro eliminado\n";
			} else {
				print "\n[-] Ha ocurrido un error en la base de datos\n";
			}	
		}
	} else {
		print "\n[-] No se encontraron productos disponibles\n";
	}
	
	$conexion_now->destroy();
	
}

sub cambiar_usuario {
	print "\n[+] Usuario actual : ";
	chomp(my $usuario_actual = <STDIN>);
	print "\n[+] Password actual : ";
	chomp(my $password_actual = <STDIN>);
	print "\n[+] Nuevo nombre de usuario : ";
	chomp(my $nuevo_usuario = <STDIN>);
	
	if($usuario_actual eq "" or $password_actual eq "" or $nuevo_usuario eq "") {
		print "\n[-] Datos invalidos\n";
	} else {
	
		my $password_encoded = md5_hex($password_actual);
		my $conexion_now = Conexion->new();

		if($conexion_now->ingreso_usuario($usuario_actual,$password_encoded)) {
			
			if($conexion_now->comprobar_existencia_usuario_editar($nuevo_usuario)) {
				print "\n[-] El usuario $nuevo_usuario ya existe\n";
			} else {			
				my $sql = "update usuarios set usuario='" . $nuevo_usuario . "' where usuario='" . $usuario_actual . "'";
				if($conexion_now->ejecutarConsulta($sql)) {
					print "\n[+] Nombre de usuario cambiado\n";
					print "\n[.] Debera reiniciar el sistema para efectuar los cambios\n";
					<STDIN>;
					exit 1;
				} else {
					print "\n[-] Ha ocurrido un error en la base de datos\n";
				}
			}	
					
		} else {
			print "\n[-] Datos de usuarios incorrectos\n";
		}
		$conexion_now->destroy();
	}	
}

sub cambiar_password {
	print "\n[+] Usuario actual : ";
	chomp(my $usuario_actual = <STDIN>);
	print "\n[+] Password actual : ";
	chomp(my $password_actual = <STDIN>);
	print "\n[+] Nuevo password : ";
	chomp(my $nuevo_password = <STDIN>);
	
	if($usuario_actual eq "" or $password_actual eq "" or $nuevo_password eq "") {
		print "\n[-] Datos invalidos\n";
	} else {
	
		my $password_encoded = md5_hex($password_actual);
		my $conexion_now = Conexion->new();

		if($conexion_now->ingreso_usuario($usuario_actual,$password_encoded)) {
			my $nuevo_password_encoded = md5_hex($nuevo_password);
			my $sql = "update usuarios set clave='" . $nuevo_password_encoded . "' where usuario='" . $usuario_actual . "'";
			if($conexion_now->ejecutarConsulta($sql)) {
				print "\n[+] Password de usuario cambiado\n";
				print "\n[.] Debera reiniciar el sistema para efectuar los cambios\n";
				<STDIN>;
				exit 1;
			} else {
				print "\n[-] Ha ocurrido un error en la base de datos\n";
			}			
		} else {
			print "\n[-] Datos de usuarios incorrectos\n";
		}
		$conexion_now->destroy();
	}	
}

sub listar_usuarios {
	
	print "\n[+] Nombre usuario : ";
	chomp(my $nombre_usuario = <STDIN>);
	
	my $conexion_now = Conexion->new();
	
	if($conexion_now->es_admin($username_login)) {
		
		my @lista = $conexion_now->listarUsuarios($nombre_usuario);
	
		my $cantidad = scalar(@lista);
	
		if($cantidad >= 1) {
	
			print "\n[+] Usuarios encontrados : ".$cantidad."\n";
		
			for my $usuario(@lista) {
		
				my $id_usuario = $usuario->getId_usuario();
				my $nombre = $usuario->getNombre();
				my $clave = $usuario->getPassword();
				my $tipo = $usuario->getTipo();
				my $fecha_registro = $usuario->getFecha_registro();
				
				my $nombre_tipo = "";
				if($tipo eq "1") {
					$nombre_tipo = "Administrador";
				} else {
					$nombre_tipo = "Usuario";
				}
		
				print "\n[+] ID : ".$id_usuario."\n";
				print "[+] Usuario : ".$nombre."\n";
				#print "[+] Clave : ".$clave."\n";
				print "[+] Tipo : ".$nombre_tipo."\n";
				print "[+] Fecha Registro : ".$fecha_registro."\n\n";

			}
	
		} else {
			print "\n[-] No se encontraron usuarios\n";
		}
	
	} else {
		print "\n[-] Acceso Denegado\n";
	}
	
	$conexion_now->destroy();	
}

sub agregar_usuario {
	
	my $conexion_now = Conexion->new();
	
	if($conexion_now->es_admin($username_login)) {
				
		print "\n[+] Nombre : ";
		chomp(my $nombre = <STDIN>);
		print "\n[+] Password : ";
		chomp(my $password = <STDIN>);
		print qq(
	
			----- Tipos -----
			[1] Usuario
			[2] Administrador
			-----------------
		);
		print "\n[+] Tipo : ";
		chomp(my $tipo = <STDIN>);
		my $fecha_registro = getFecha();
		if($nombre eq "" or $password eq "" or $tipo eq "" or !isdigit($tipo)) {
			print "\n[-] Faltan datos\n";
			<STDIN>;
			menu_principal();
		} else {
		
			my $tipo_real = "";
		
			if($tipo eq "1") {
				$tipo_real = "2";
			}
			elsif($tipo eq "2") {
				$tipo_real = "1";
			} else {
				$tipo_real = "2";
			}
		
			my $password_encoded = md5_hex($password);
			
			if($conexion_now->comprobar_existencia_usuario_crear($nombre)) {
				print "\n[-] El usuario $nombre ya existe\n";
			} else {
		
				my $sql = "insert into usuarios values('" . $nombre . "','" . $password_encoded . "'," . $tipo_real . ",'" . $fecha_registro . "')";
				
				if($conexion_now->ejecutarConsulta($sql)) {
					print "\n[+] Registro agregado\n";
				} else {
					print "\n[-] Ha ocurrido un error en la base de datos\n";
				}
			
			}
		
		}
	
	} else {
		print "\n[-] Acceso Denegado\n";
	}
	
	$conexion_now->destroy();
		
	<STDIN>;
	menu_principal();	
	
}

sub listar_usuarios_ids {
	
	print "\n[+] Nombre usuario : ";
	chomp(my $nombre_usuario = <STDIN>);
		
	my $conexion_now = Conexion->new();
	
	if($conexion_now->es_admin($username_login)) {
	
		my @lista = $conexion_now->listarUsuarios($nombre_usuario);
	
		my $cantidad = scalar(@lista);
	
		print "\n------------ Usuarios Disponibles ------------\n";
				
		for my $usuario(@lista) {

			my $id_usuario = $usuario->getId_usuario();
			my $nombre = $usuario->getNombre();
			my $clave = $usuario->getPassword();
			my $tipo = $usuario->getTipo();
			my $fecha_registro = $usuario->getFecha_registro();
		
			print "\n[+] ID : ".$id_usuario."\t"."[+] Nombre : ".$nombre;

		}	
	
		print "\n-------------------------------------------------\n";
	
	} else {
		print "\n[-] Acceso Denegado\n";
	}
		
	$conexion_now->destroy();	
}

sub borrar_usuario {
	
	my $conexion_now = Conexion->new();
	
	if($conexion_now->es_admin($username_login)) {
	
		my @lista = $conexion_now->listarUsuarios();
		
		my $cantidad = scalar(@lista);
	
		if($cantidad >= 1) {
			listar_usuarios_ids();
			print "\n[+] ID : ";
			chomp(my $id_usuario = <STDIN>);
			if($id_usuario eq "" or !isdigit($id_usuario)) {
			print "\n[-] Datos invalidos\n";
			} else {
				my $sql = "delete from usuarios where id_usuario=" . $id_usuario;
				if($conexion_now->ejecutarConsulta($sql)) {
					print "\n[+] Registro eliminado\n";
				} else {
					print "\n[-] Ha ocurrido un error en la base de datos\n";
				}	
			}
		} else {
			print "\n[-] No se encontraron usuarios\n";
		}
	
	} else {
		print "\n[-] Acceso Denegado\n";
	}
	
	$conexion_now->destroy();
	
}

sub asignar_usuario {
	
	my $conexion_now = Conexion->new();
	
	if($conexion_now->es_admin($username_login)) {
	
		my @lista = $conexion_now->listarUsuarios();
		
		my $cantidad = scalar(@lista);
	
		if($cantidad >= 1) {
			listar_usuarios_ids();
			print "\n[+] ID : ";
			chomp(my $id_usuario = <STDIN>);
			print qq(
	
				----- Tipos -----
				[1] Usuario
				[2] Administrador
				-----------------
			);
			print "\n[+] Tipo : ";
			chomp(my $tipo = <STDIN>);
			if($id_usuario eq "" or !isdigit($id_usuario) or $tipo eq "" or !isdigit($tipo)) {
				print "\n[-] Datos invalidos\n";
			} else {
			
				my $tipo_real = "";
		
				if($tipo eq "1") {
					$tipo_real = "2";
				}
				elsif($tipo eq "2") {
					$tipo_real = "1";
				} else {
					$tipo_real = "2";
				}
		
				my $sql = "update usuarios set tipo=".$tipo_real." where id_usuario='".$id_usuario."'";
				if($conexion_now->ejecutarConsulta($sql)) {
					print "\n[+] Registro actualizado\n";
				} else {
					print "\n[-] Ha ocurrido un error en la base de datos\n";
				}	
			}
		} else {
			print "\n[-] No se encontraron usuarios\n";
		}
	
	} else {
		print "\n[-] Acceso Denegado\n";
	}
	
	$conexion_now->destroy();	
	
}

sub menu_principal {
	
	clean();
	
	my $tipo_usuario = "";

	my $conexion_now = Conexion->new();
	if($conexion_now->es_admin($username_login)) {
		$tipo_usuario = "administrador";
	} else {
		$tipo_usuario = "usuario";
	}
	$conexion_now->destroy();

	print qq(
	
	[+] Bienvenido $tipo_usuario $username_login
	
	========================
		    Opciones
	========================
	
	------ Productos -------
	
	1 - Agregar Producto
	2 - Editar Producto
	3 - Borrar Producto
	4 - Listar Productos
	
	------------------------
	
	------ Proveedores -----
	
	5 - Agregar Proveedor
	6 - Editar Proveedor
	7 - Borrar Proveedor
	8 - Listar Proveedores
	
	------------------------
	
	------ Usuarios --------
	
	9 - Agregar Usuario
	10 - Borrar Usuario
	11 - Asignar Usuario
	12 - Listar Usuarios
	
	------------------------
	
	----- Estadisticas -----
	
	13 - Listar productos
	14 - Grafico Productos
	15 - Grafico Proveedores
		
	------------------------
	
	-------- Cuenta --------
	
	16 - Cambiar usuario
	17 - Cambiar password
	
	------------------------
	
	18 - Salir
	
	);
	
	print "\n[+] Seleccione opcion : ";
	chomp(my $opcion = <STDIN>);
	
	if($opcion eq "1") {
		print "\n---- Agregar producto ----\n";
		agregar_producto();
	} elsif($opcion eq "2") {
		print "\n---- Editar producto ----\n";
		editar_producto();	
		<STDIN>;
		menu_principal();	
	} elsif ($opcion eq "3") {
		print "\n---- Borrar producto ----\n";
		borrar_producto();
		<STDIN>;
		menu_principal();		
	} elsif($opcion eq "4") {
		print "\n---- Listar productos ----\n";
		listar_productos();
		<STDIN>;
		menu_principal();		
	} elsif($opcion eq "5") {
		print "\n---- Agregar proveedor ----\n";
		agregar_proveedor();
	} elsif($opcion eq "6") {
		print "\n---- Editar proveedor ----\n";
		editar_proveedor();
		<STDIN>;
		menu_principal();	
	} elsif($opcion eq "7") {
		print "\n---- Borrar proveedor ----\n";
		borrar_proveedor();
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "8") {
		print "\n---- Listar proveedores ----\n";
		listar_proveedores();
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "9") {
		print "\n---- Agregar usuario ----\n";
		agregar_usuario();
	} elsif($opcion eq "10") {
		print "\n---- Borrar usuario ----\n";
		borrar_usuario();
		<STDIN>;
		menu_principal();		
	} elsif($opcion eq "11") {
		print "\n---- Asigar usuario ----\n";
		asignar_usuario();
		<STDIN>;
		menu_principal();			
	} elsif($opcion eq "12") {
		print "\n---- Listar usuarios ----\n";
		listar_usuarios();
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "13") {
		print "\n---- Listar reporte de productos ----\n\n";
		if($conexion_now->generarListadoProductos()) {
			print "[+] Reporte PDF generado\n";
			cargarReporte("listadoProductos.pdf");
		} else {
			print "[-] Ha ocurrido un error generando el PDF\n";
		}
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "14") {
		print "\n---- Generar grafico de productos ----\n\n";
		if($conexion_now->generarGraficoProductos()) {
			print "[+] Reporte PDF generado\n";
			cargarReporte("graficoProductos.pdf");
		} else {
			print "[-] Ha ocurrido un error generando el PDF\n";
		}
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "15") {
		print "\n---- Generar grafico de proveedores ----\n\n";
		if($conexion_now->generarGraficoProveedores()) {
			print "[+] Reporte PDF generado\n";
			cargarReporte("graficoProveedores.pdf");
		} else {
			print "[-] Ha ocurrido un error generando el PDF\n";
		}
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "16") {
		print "\n---- Cambiar usuario ----\n";
		cambiar_usuario();
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "17") {
		print "\n---- Cambiar password ----\n";
		cambiar_password();
		<STDIN>;
		menu_principal();
	} elsif($opcion eq "18") {
		print "\n[+] Presione enter para salir del sistema\n";
		<STDIN>;
		exit 1;
	} else {
		menu_principal();
	}
	
}

sub login {
	
	clean_login();
	head();
		
	print  "\n[+] Ingrese usuario : ";
	chomp(my $usuario = <STDIN>);
	print  "\n[+] Ingrese password : ";
	chomp(my $password = <STDIN>);
	
	if($usuario eq "" or $password eq "") {
		print "\n[-] Faltan datos\n";
		<STDIN>;
		login();
	} else {
	
	my $password_encoded = md5_hex($password);
	
	my $conexion_now = Conexion->new();

	if($conexion_now->ingreso_usuario($usuario,$password_encoded)) {
		$username_login = $usuario;
		if($conexion_now->es_admin($usuario)) {
			print "\n[+] Bienvenido administrador $usuario al sistema\n";
		} else {
			print "\n[+] Bienvenido usuario $usuario al sistema\n";
		}
		<STDIN>;
		menu_principal();
	} else {
		print "\n[-] Datos incorrectos\n";
		<STDIN>;
		login();		
	}
	
	$conexion_now->destroy();
	
	}
	
}

#
	
