#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pypyodbc

from Proveedores import Proveedor

class ProveedorDatos(object):
		
	def iniciar_conexion(self):
		self.__conexion = pypyodbc.connect('DRIVER={SQL Server};SERVER=SINDECIDIR-PC;DATABASE=sistemaV2;UID=admin;PWD=123456')
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
		
	def listar(self,patron):
		proveedores = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id,nombre,direccion,telefono,fecha_registro FROM proveedores WHERE nombre LIKE ?", ("%"+patron+"%",))
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				direccion = row[2]
				telefono = row[3]
				fecha_registro = row[4]
				proveedor = Proveedor(id,nombre,direccion,telefono,fecha_registro)
				proveedores.append(proveedor)
			self.cerrar_conexion()
		except:
			pass
		return proveedores

	def cargar(self,id):
		proveedor = Proveedor()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id,nombre,direccion,telefono,fecha_registro FROM proveedores WHERE id = ?", (id,))
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				direccion = row[2]
				telefono = row[3]
				fecha_registro = row[4]
				proveedor = Proveedor(id,nombre,direccion,telefono,fecha_registro)
			self.cerrar_conexion()
		except:
			pass
		return proveedor

	def cargarNombreProveedor(self,id):
		nombre_empresa = ""
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT nombre FROM proveedores WHERE id = ?", (id,))
			rows = cursor.fetchall()
			if not rows[0][0]=="":
				nombre_empresa = rows[0][0]
			cursor.close()
			self.cerrar_conexion()
		except:
			pass
			
		return nombre_empresa

	def agregar(self,proveedor):
		response = False
		id = proveedor.getId()
		nombre = proveedor.getNombre()
		direccion = proveedor.getDireccion()
		telefono = proveedor.getTelefono()
		fecha_registro = proveedor.getFecha_registro()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("INSERT INTO proveedores VALUES(?,?,?,?)", (nombre,direccion,telefono,fecha_registro,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def editar(self,proveedor):
		response = False
		id = proveedor.getId()
		nombre = proveedor.getNombre()
		direccion = proveedor.getDireccion()
		telefono = proveedor.getTelefono()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("UPDATE proveedores SET nombre = ?, direccion = ?, telefono = ? WHERE id = ? ", (nombre,direccion,telefono,id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def borrar(self,proveedor):
		response = False
		id = proveedor.getId()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("DELETE FROM proveedores WHERE id = ?", (id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response =  False
		return response

	def comprobar_existencia_proveedor_crear(self,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM proveedores WHERE nombre LIKE ?", (nombre,))
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
		
	def comprobar_existencia_proveedor_editar(self,id,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM proveedores WHERE nombre LIKE ? AND id != ?", (nombre,id,))
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
