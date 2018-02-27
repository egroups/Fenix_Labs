#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import hashlib,os,sys
from time import gmtime, strftime

from Usuarios import Usuario
from Proveedores import Proveedor
from Productos import Producto

from ProductosDatos import ProductoDatos
from ProveedoresDatos import ProveedorDatos
from TiposUsuariosDatos import TipoUsuarioDatos
from UsuariosDatos import UsuarioDatos
from ReportesDatos import ReporteDatos

global username_login

global productosDatos
global proveedorDatos
global usuarioDatos
global reportesDatos

username_login = ""

productosDatos = ProductoDatos()
proveedoresDatos = ProveedorDatos()
tiposUsuariosDatos = TipoUsuarioDatos()
usuariosDatos = UsuarioDatos()
reportesDatos = ReporteDatos()

def getFecha():
	return strftime("%m/%d/%Y", gmtime())

def valid_digit(text):
	return text.isdigit()

def md5_encode(text):
	encode = hashlib.md5()
	encode.update(text.encode("utf-8"))
	return encode.hexdigest()

def clean_login():
	os.system("cls")
	os.system("color c")
	
def clean():
	os.system("cls")
	os.system("color b")
	
def head():
    print("\n-- == Sistema == --\n")

def listar_proveedores():
	
	print("\n[+] Nombre : ")
	patron = input()
	proveedores = proveedoresDatos.listar(patron)
	cantidad = len(proveedores)
	if(cantidad >= 1):
		print("[+] Proveedores encontrados %d" % (cantidad));
		for proveedor in proveedores:
			id = proveedor.getId()
			nombre = proveedor.getNombre()
			direccion = proveedor.getDireccion()
			telefono = proveedor.getTelefono()
			fecha_registro = proveedor.getFecha_registro()

			print("\n[+] ID : %d" % (id))
			print("[+] Nombre : %s" % (nombre))
			print("[+] Dirección : %s" % (direccion))
			print("[+] Teléfono : %d" % (telefono))
			print("[+] Fecha Registro : %s" % (fecha_registro))
	else:
		print("\n[-] No se encontraron proveedores\n")

def listar_proveedores_ids():
	print("\n[+] Nombre de Proveedor : ")
	patron = input()
	proveedores = proveedoresDatos.listar(patron)
	cantidad = len(proveedores)
	if(cantidad >= 1):
		print("------------ Proveedores Disponibles ------------\n")
		for proveedor in proveedores:
			id = proveedor.getId()
			nombre = proveedor.getNombre()
			direccion = proveedor.getDireccion()
			telefono = proveedor.getTelefono()
			fecha_registro = proveedor.getFecha_registro()
			print("[+] ID : %d [+] Nombre : %s" % (id,nombre))
		print("\n-------------------------------------------------")
	else:
		print("\n[-] No se encontraron proveedores\n")
		
def listar_productos():
	print ("\n[+] Nombre : ")
	patron = input()
	productos = productosDatos.listar(patron)
	cantidad = len(productos)
	if(cantidad >= 1):
		print("[+] Productos encontrados %d" % (cantidad));
		for producto in productos:
			id = producto.getId()
			nombre = producto.getNombre()
			descripcion = producto.getDescripcion()
			precio = producto.getPrecio()
			id_proveedor = producto.getId_proveedor()
			nombre_proveedor = proveedoresDatos.cargarNombreProveedor(id_proveedor)
			fecha_registro = producto.getFecha_registro()
						
			print("\n[+] ID : %d" % (id))
			print("[+] Nombre : %s" % (nombre))
			print("[+] Descripción : %s" % (descripcion))
			print("[+] Precio : %d" % (precio))
			print("[+] Proveedor : %s" % (nombre_proveedor))
			print("[+] Fecha Registro : %s" % (fecha_registro))
	else:
		print("\n[-] No se encontraron productos disponibles\n")	
	
def listar_productos_ids():
	print("\n[+] Nombre : ")
	patron = input()
	productos = productosDatos.listar(patron)
	cantidad = len(productos)
	if(cantidad >= 1):
		print("------------ Productos Disponibles ------------\n")
		for producto in productos:
			id = producto.getId()
			nombre = producto.getNombre()
			descripcion = producto.getDescripcion()
			precio = producto.getPrecio()
			id_proveedor = producto.getId_proveedor()
			nombre_proveedor = proveedoresDatos.cargarNombreProveedor(id_proveedor)
			fecha_registro = producto.getFecha_registro()		
			print("[+] ID : %d [+] Nombre : %s" % (id,nombre));

		print("\n-------------------------------------------------")	
	else:
		print("\n[-] No se encontraron productos disponibles\n")		

def listar_tipos_ids():
	tipos = tiposUsuariosDatos.listar()
	cantidad = len(tipos)
	if(cantidad >= 1):
		print("------------ Tipos Disponibles ------------\n")
		for tipo in tipos:
			id = tipo.getId()
			nombre = tipo.getNombre()		
			print("[+] ID : %d [+] Nombre : %s" % (id,nombre));

		print("\n-------------------------------------------------")	
	else:
		print("\n[-] No se encontraron tipos disponibles\n")	

def listar_usuarios():
	print("\n[+] Nombre : ")
	patron = input()
	if(usuariosDatos.es_admin(username_login)):
		usuarios = usuariosDatos.listar(patron)
		cantidad = len(usuarios)
		if(cantidad >= 1):
			print("[+] Usuarios encontrados %d" % (cantidad));
			for usuario in usuarios:
				id = usuario.getId()
				nombre = usuario.getNombre()
				clave = usuario.getClave()
				id_tipo = usuario.getId_tipo()
				fecha_registro = usuario.getFecha_registro()
				nombre_tipo = ""
			
				if(id_tipo==1):
					nombre_tipo = "Administrador"
				else:
					nombre_tipo = "Usuario"
				
				print("\n[+] ID : %d" % (id))
				print("[+] Nombre : %s" % (nombre))
				print("[+] Tipo : %s" % (nombre_tipo))
				print("[+] Fecha Registro : %s" % (fecha_registro))
		else:
			print("\n[-] No se encontraron usuarios\n")
	else:
		print("\n[-] Acceso Denegado\n")
	
def listar_usuarios_ids():
	print("\n[+] Nombre : ")
	patron = input()
	if(usuariosDatos.es_admin(username_login)):
		usuarios = usuariosDatos.listar(patron)
		cantidad = len(usuarios)
		if(cantidad >= 1):
			print("------------ Usuarios Disponibles ------------\n")
			for usuario in usuarios:
				id = usuario.getId()
				nombre = usuario.getNombre()
				clave = usuario.getClave()
				id_tipo = usuario.getId_tipo()
				fecha_registro = usuario.getFecha_registro()
				nombre_tipo = ""
				if(id_tipo==1):
					nombre_tipo = "Administrador"
				else:
					nombre_tipo = "Usuario"
				print("[+] ID : %d [+] Nombre : %s [+] Tipo : %s " % (id,nombre,nombre_tipo));
			print("\n-------------------------------------------------")
		else:
			print("\n[-] No se encontraron usuarios\n")
	else:
		print("\n[-] Acceso Denegado\n")
	
def agregar_proveedor():
	print("[+] Nombre empresa : ")
	nombre = input()
	print("\n[+] Dirección : ")
	direccion = input()
	print("\n[+] Teléfono : ")
	telefono = input()
	if(nombre=="" or direccion=="" or telefono=="" or not valid_digit(telefono)):
		print("\n[-] Faltan datos\n")
		input()
		menu_principal()
	else:
		proveedor = Proveedor()
		proveedor.setNombre(nombre)
		proveedor.setDireccion(direccion)
		proveedor.setTelefono(telefono)
		proveedor.setFecha_registro(getFecha())

		if(proveedoresDatos.comprobar_existencia_proveedor_crear(nombre)):
			print("\n[-] El proveedor %s ya existe\n" % (nombre))
		else:
			if(proveedoresDatos.agregar(proveedor)):
				print("\n[+] Registro agregado\n")
			else:
				print("\n[-] Ha ocurrido un error en la base de datos\n")
		input()
		menu_principal()
		
def editar_proveedor():
	proveedores = proveedoresDatos.listar("")
	cantidad = len(proveedores)
	if(cantidad >= 1):	
		listar_proveedores_ids()
		print("\n[+] ID : ")
		id = input()
		
		if(id=="" or not valid_digit(id)):
			print("\n[-] Datos invalidos\n")
		else:

			proveedor = proveedoresDatos.cargar(id)
		
			id = proveedor.getId()
			nombre = proveedor.getNombre()
			direccion = proveedor.getDireccion()
			telefono = proveedor.getTelefono()
			fecha_registro = proveedor.getFecha_registro()

			print("\n============ Datos ============")
			print("[+] ID : %d" % (id))
			print("[+] Nombre : %s" % (nombre))
			print("[+] Dirección : %s" % (direccion))
			print("[+] Teléfono : %d" % (telefono))
			print("[+] Fecha Registro : %s" % (fecha_registro))
			print("==================================")
				
			print("\n[+] Nombre : ")
			nombre = input()

			print("\n[+] Dirección : ")
			direccion = input()
			
			print("\n[+] Teléfono : ")
			telefono = input()

			proveedor.setNombre(nombre)
			proveedor.setDireccion(direccion)
			proveedor.setTelefono(telefono)

			if(proveedoresDatos.comprobar_existencia_proveedor_editar(id,nombre)):
				print("\n[-] El proveedor %s ya existe\n" % (nombre))
			else:
				if(proveedoresDatos.editar(proveedor)):
					print("\n[+] Registro actualizado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
				
		
	else:
		print("\n[-] No se encontraron proveedores disponibles\n")		
		
def borrar_proveedor():

	proveedores = proveedoresDatos.listar("")
	cantidad = len(proveedores)
	if(cantidad >= 1):	
		listar_proveedores_ids()
		print("\n[+] ID : ")
		id = input()
		if(id=="" or not valid_digit(id)):
			print("\n[-] Datos invalidos\n")
		else:
			sql = "delete from proveedores where id=" + id
			proveedor = Proveedor()
			proveedor.setId(id)
			if(proveedoresDatos.borrar(proveedor)):
				print("\n[+] Registro eliminado\n")
			else:
				print("\n[-] Ha ocurrido un error en la base de datos\n")
	else:
		print("\n[-] No se encontraron proveedores disponibles\n")		
	
def agregar_producto():
	proveedores = proveedoresDatos.listar("")
	cantidad = len(proveedores)
	if(cantidad >= 1):
		print("[+] Nombre : ")
		nombre = input()
		print("\n[+] Descripción : ")
		descripcion = input()
		print("\n[+] Precio : ")
		precio = input()
		listar_proveedores_ids()
		print("\n[+] ID Proveedor : ")
		id_proveedor = input()
		if(nombre=="" or descripcion=="" or precio=="" or not valid_digit(precio) or id=="" or not valid_digit(id_proveedor)):
			print("\n[-] Faltan datos\n")
			input()
			menu_principal()
		else:
			producto = Producto()
			producto.setNombre(nombre)
			producto.setDescripcion(descripcion)
			producto.setPrecio(precio)
			producto.setId_proveedor(id_proveedor)
			producto.setFecha_registro(getFecha())

			if(productosDatos.comprobar_existencia_producto_crear(nombre)):
				print("\n[-] El producto %s ya existe\n" % (nombre))
			else:
				if(productosDatos.agregar(producto)):
					print("\n[+] Registro agregado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
		input()
		menu_principal()
	else:
		print("\n[-] No se encontraron proveedores disponibles\n")	
	
def editar_producto():
	productos = productosDatos.listar("")
	cantidad = len(productos)
	if(cantidad >= 1):	
		listar_productos_ids()
		print("\n[+] ID : ")
		id = input()
		if(id=="" or not valid_digit(id)):
			print("\n[-] Datos invalidos\n")
		else:

			producto = productosDatos.cargar(id)

			id = producto.getId()
			nombre = producto.getNombre()
			descripcion = producto.getDescripcion()
			precio = producto.getPrecio()
			id_proveedor = producto.getId_proveedor()
			nombre_proveedor = proveedoresDatos.cargarNombreProveedor(id_proveedor)
			fecha_registro = producto.getFecha_registro()
			
			print("\n============ Datos ============")		
			print("\n[+] ID : %d" % (id))
			print("[+] Nombre : %s" % (nombre))
			print("[+] Descripción : %s" % (descripcion))
			print("[+] Precio : %d" % (precio))
			print("[+] Proveedor : %s" % (nombre_proveedor))
			print("[+] Fecha Registro : %s" % (fecha_registro))
			print("==================================")

			print("\n[+] Nombre producto : ")
			nombre = input()

			print("\n[+] Descripción : ")
			descripcion = input()	

			print("\n[+] Precio : ")
			precio = input()

			listar_proveedores_ids()
			print("\n[+] ID Proveedor : ")
			id_proveedor = input()

			producto.setNombre(nombre)
			producto.setPrecio(precio)
			producto.setId_proveedor(id_proveedor)

			if(productosDatos.comprobar_existencia_producto_editar(id,nombre)):
				print("\n[-] El producto %s ya existe\n" % (nombre))
			else:
				if(productosDatos.editar(producto)):
					print("\n[+] Registro actualizado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
	else:
		print("\n[-] No se encontraron proveedores disponibles\n")		
	
def borrar_producto():
	productos = productosDatos.listar("")
	cantidad = len(productos)
	if(cantidad >= 1):	
		listar_productos_ids()
		print("\n[+] ID : ")
		id = input()
		if(id=="" or not valid_digit(id)):
			print("\n[-] Datos invalidos\n")
		else:
			producto = Producto()
			producto.setId(id)
			if(productosDatos.borrar(producto)):
				print("\n[+] Registro eliminado\n")
			else:
				print("\n[-] Ha ocurrido un error en la base de datos\n")
	else:
		print("\n[-] No se encontraron proveedores disponibles\n")		
			
def agregar_usuario():
	if(usuariosDatos.es_admin(username_login)):
		print("[+] Nombre : ")
		nombre = input()
		print("\n[+] Clave : ")
		clave = input()
		listar_tipos_ids()
		print("\n[+] Tipo : ")
		id_tipo = input()
		if(nombre=="" or clave=="" or id_tipo=="" or not valid_digit(id_tipo)):
			print("\n[-] Faltan datos\n")
			input()
			menu_principal()
		else:	
			clave_encoded = md5_encode(clave)

			usuario = Usuario()
			usuario.setNombre(nombre)
			usuario.setClave(clave_encoded)
			usuario.setId_tipo(id_tipo)
			usuario.setFecha_registro(getFecha())

			if(usuariosDatos.comprobar_existencia_usuario_crear(nombre)):
				print("\n[-] El usuario %s ya existe\n" % (nombre))
			else:
				if(usuariosDatos.agregar(usuario)):
					print("\n[+] Registro agregado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
	else:
		print("\n[-] Acceso Denegado\n")
	input()
	menu_principal()
	
def asignar_usuario():
	if(usuariosDatos.es_admin(username_login)):
		usuarios = usuariosDatos.listar("")
		cantidad = len(usuarios)
		if(cantidad >= 1):	

			listar_usuarios_ids()

			print("\n[+] ID : ")
			id = input()

			listar_tipos_ids()

			print("\n[+] Tipo : ")
			id_tipo = input()

			if(id=="" or not valid_digit(id) or id_tipo=="" or not valid_digit(id_tipo)):
				print("\n[-] Datos invalidos\n")
			else:
				usuario = Usuario()
				usuario.setId(id)
				usuario.setId_tipo(id_tipo)

				if(usuariosDatos.editar(usuario)):
					print("\n[+] Registro actualizado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
			
		else:
			print("\n[-] No se encontraron usuarios\n")	
	else:
		print("\n[-] Acceso Denegado\n")

def borrar_usuario():
	if(usuariosDatos.es_admin(username_login)):
		usuarios = usuariosDatos.listar("")
		cantidad = len(usuarios)
		if(cantidad >= 1):	
			listar_usuarios_ids()
			print("\n[+] ID : ")
			id = input()
			if(id=="" or not valid_digit(id)):
				print("\n[-] Datos invalidos\n")
			else:
				usuario = Usuario()
				usuario.setId(id)
				if(usuariosDatos.borrar(usuario)):
					print("\n[+] Registro eliminado\n")
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
		else:
			print("\n[-] No se encontraron usuarios\n")	
	else:
		print("\n[-] Acceso Denegado\n")	
		
def cambiar_usuario():
	print("[+] Usuario actual : ")
	usuario_actual = input()
	print("\n[+] Clave actual : ")
	clave_actual = input()
	print("\n[+] Nuevo nombre de usuario : ")
	nuevo_usuario = input()
	if(usuario_actual=="" or clave_actual=="" or nuevo_usuario==""):
		print("\n[-] Datos invalidos\n")
	else:
		clave_encoded = md5_encode(clave_actual)
		if(usuariosDatos.ingreso_usuario(usuario_actual,clave_encoded)):
			if(usuariosDatos.comprobar_existencia_usuario_editar(nuevo_usuario)):
				print("\n[-] El usuario %s ya existe\n" % (nuevo_usuario))
			else:
				if(usuariosDatos.cambiar_usuario(usuario_actual,nuevo_usuario)):
					print("\n[+] Nombre de usuario cambiado\n")
					print("[.] Debera reiniciar el sistema para efectuar los cambios\n")
					input()
					sys.exit(1)
				else:
					print("\n[-] Ha ocurrido un error en la base de datos\n")
		else:
			print("\n[-] Datos de usuarios incorrectos\n")			
		
def cambiar_clave():
	print("[+] Usuario actual : ")
	usuario_actual = input()
	print("\n[+] Clave actual : ")
	clave_actual = input()
	print("\n[+] Nuevo password : ")
	nueva_clave = input()
	if(usuario_actual=="" or clave_actual=="" or nueva_clave==""):
		print("\n[-] Datos invalidos\n")
	else:
		clave_encoded = md5_encode(clave_actual)
		if(usuariosDatos.ingreso_usuario(usuario_actual,clave_encoded)):
			nueva_clave_encoded = md5_encode(nueva_clave)
			if(usuariosDatos.cambiar_clave(usuario_actual,nueva_clave_encoded)):
				print("\n[+] Password de usuario cambiado\n")
				print("[.] Debera reiniciar el sistema para efectuar los cambios\n")
				input()
				sys.exit(1)		
			else:
				print("\n[-] Ha ocurrido un error en la base de datos\n")
		else:
			print("\n[-] Datos de usuarios incorrectos\n")
					
def menu_principal():

	clean()
	
	tipo_usuario = ""
	
	if(usuariosDatos.es_admin(username_login)):
		tipo_usuario = "administrador"
	else:
		tipo_usuario = "usuario"

	print("[+] Bienvenido "+tipo_usuario+" "+username_login)
	
	menu_output = '''
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
	10 - Asignar Usuario
	11 - Borrar Usuario
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
'''

	print(menu_output)
	
	print("\n[+] Seleccione opcion : ")
	opcion = input()
	
	if (opcion=="1"):
		print("\n---- Agregar producto ----\n")
		agregar_producto()
	elif(opcion=="2"):
		editar_producto()	
		input()
		menu_principal()
	elif(opcion=="3"):
		print("\n---- Borrar producto ----\n")
		borrar_producto()
		input()
		menu_principal()
	elif(opcion=="4"):
		print("\n---- Listar productos ----\n")
		listar_productos()
		input()
		menu_principal()
	elif(opcion=="5"):
		print("\n---- Agregar proveedor ----\n")
		agregar_proveedor()
	elif(opcion=="6"):
		print("\n---- Editar proveedor ----\n")
		editar_proveedor()
		input()
		menu_principal()
	elif(opcion=="7"):
		print("\n---- Borrar proveedor ----\n")
		borrar_proveedor()
		input()
		menu_principal()
	elif(opcion=="8"):
		print("\n---- Listar proveedores ----\n")
		listar_proveedores()
		input()
		menu_principal()
	elif(opcion=="9"):
		print("\n---- Agregar usuario ----\n")
		agregar_usuario()
	elif(opcion=="10"):
		print("\n---- Asigar usuario ----\n")
		asignar_usuario()
		input()
		menu_principal()
	elif(opcion=="11"):
		print("\n---- Borrar usuario ----\n")
		borrar_usuario()
		input()
		menu_principal()
	elif(opcion=="12"):
		print("\n---- Listar usuarios ----\n")
		listar_usuarios()
		input()
		menu_principal()
	elif(opcion=="13"):
		print("\n---- Listar reporte de productos ----\n\n")
		if(reportesDatos.generarListadoProductos()):
			print("[+] Reporte PDF generado\n")
		else:
			print("[-] Ha ocurrido un error generando el PDF\n")
		input()
		menu_principal()
	elif(opcion=="14"):
		print("\n---- Generar gráfico de productos ----\n\n")
		if(reportesDatos.generarGraficoProductos()):
			print("[+] Reporte PDF generado\n")
		else:
			print("[-] Ha ocurrido un error generando el PDF\n")
		input()
		menu_principal()
	elif(opcion=="15"):
		print("\n---- Generar gráfico de proveedores ----\n\n")
		if(reportesDatos.generarGraficoProveedores()):
			print("[+] Reporte PDF generado\n")
		else:
			print("[-] Ha ocurrido un error generando el PDF\n")
		input()
		menu_principal()
	elif(opcion=="16"):
		print("\n---- Cambiar usuario ----\n")
		cambiar_usuario()
		input()
		menu_principal()
	elif(opcion=="17"):
		print("\n---- Cambiar password ----\n")
		cambiar_clave()
		input()
		menu_principal()
	elif(opcion=="18"):
		print("\n[+] Presione enter para salir del sistema\n")
		input("")
		sys.exit(1)
	else:
		menu_principal()
	

def login():
	clean_login()
	head()
	print("[+] Ingrese usuario : ")
	usuario = input()
	print("\n[+] Ingrese password : ")
	password = input()
	if(usuario=="" or password==""):
		print("\n[-] Faltan datos\n")
		input("")
		login()
	else:
		password_encoded = md5_encode(password)
		if(usuariosDatos.ingreso_usuario(usuario,password_encoded)):		
			global username_login
			username_login = usuario
			if(usuariosDatos.es_admin(usuario)):
				print("\n[+] Bienvenido administrador %s al sistema\n" % (usuario))
			else:
				print("\n[+] Bienvenido usuario %s al sistema\n" % (usuario))
			input("")
			menu_principal()
		else:
			print("\n[-] Datos incorrectos\n")
			input("")
			login()
login()
