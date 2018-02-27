#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pypyodbc

from Productos import Producto

class ProductoDatos(object):
		
	def iniciar_conexion(self):
		self.__conexion = pypyodbc.connect('DRIVER={SQL Server};SERVER=SINDECIDIR-PC;DATABASE=sistemaV2;UID=admin;PWD=123456')
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
											
	def listar(self,patron):
		productos = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id,nombre,descripcion,precio,id_proveedor,fecha_registro FROM productos WHERE nombre LIKE ?", ("%"+patron+"%",))
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				descripcion = row[2]
				precio = row[3]
				id_proveedor = row[4]
				fecha_registro = row[5]
				producto = Producto(id,nombre,descripcion,precio,id_proveedor,fecha_registro)
				productos.append(producto)
			self.cerrar_conexion()
		except:
			pass
		return productos

	def cargar(self,id):
		producto = Producto()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id,nombre,descripcion,precio,id_proveedor,fecha_registro FROM productos WHERE id = ?", (id,))
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				descripcion = row[2]
				precio = row[3]
				id_proveedor = row[4]
				fecha_registro = row[5]
				producto = Producto(id,nombre,descripcion,precio,id_proveedor,fecha_registro)
			self.cerrar_conexion()
		except:
			pass
		return producto

	def agregar(self,producto):
		response = False
		nombre = producto.getNombre()
		descripcion = producto.getDescripcion()
		precio = producto.getPrecio()
		id_proveedor = producto.getId_proveedor()
		fecha_registro = producto.getFecha_registro()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("INSERT INTO productos VALUES(?,?,?,?,?)", (nombre,descripcion,precio,id_proveedor,fecha_registro,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def editar(self,producto):
		response = False
		id = producto.getId()
		nombre = producto.getNombre()
		descripcion = producto.getDescripcion()
		precio = producto.getPrecio()
		id_proveedor = producto.getId_proveedor()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("UPDATE productos SET nombre = ?, descripcion = ?, precio = ?, id_proveedor = ? WHERE id = ? ", (nombre,descripcion,precio,id_proveedor,id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def borrar(self,producto):
		response = False
		id = producto.getId()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("DELETE FROM productos WHERE id = ?", (id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response =  False
		return response

	def comprobar_existencia_producto_crear(self,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM productos WHERE nombre LIKE ?", (nombre,))
			rows = cursor.fetchall()
			cursor.close()
			self.cerrar_conexion()
			if(len(rows) >= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_producto_editar(self,id,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM productos WHERE nombre LIKE ? AND id != ?", (nombre,id,))
			rows = cursor.fetchall()
			cursor.close()
			self.cerrar_conexion()
			if(len(rows) >= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
							
	def destroy(self):
		self.__conexion = None
