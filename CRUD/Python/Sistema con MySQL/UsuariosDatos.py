#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pymysql

from Usuarios import Usuario

class UsuarioDatos(object):
		
	def iniciar_conexion(self):
		self.__conexion = pymysql.connect("localhost","root","","sistemav2")
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
		
	def ingreso_usuario(self,username,password):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id FROM usuarios WHERE nombre = %s AND clave = %s", (username,password,))
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
				
	def listar(self,patron):
		usuarios = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id,nombre,clave,id_tipo,fecha_registro FROM usuarios WHERE nombre LIKE %s", ("%"+patron+"%",))
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				clave = row[2]
				tipo = row[3]
				fecha_registro = row[4]
				usuario = Usuario(id,nombre,clave,tipo,fecha_registro)
				usuarios.append(usuario)
			self.cerrar_conexion()
		except:
			pass
		return usuarios
					
	def es_admin(self,username):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT id_tipo FROM usuarios WHERE nombre = %s", (username,))
			rows = cursor.fetchall()
			if not rows[0][0]=="":
				tipo = rows[0][0]
				if tipo==1:
					response = True
				else:
					response = False
			cursor.close()
			self.cerrar_conexion()
		except:
			pass
		return response

	def agregar(self,usuario):
		response = False
		nombre = usuario.getNombre()
		clave = usuario.getClave()
		id_tipo = usuario.getId_tipo()
		fecha_registro = usuario.getFecha_registro()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("INSERT INTO usuarios(nombre,clave,id_tipo,fecha_registro) VALUES(%s,%s,%s,%s)", (nombre,clave,id_tipo,fecha_registro,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def editar(self,usuario):
		response = False
		id = usuario.getId()
		id_tipo = usuario.getId_tipo()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("UPDATE usuarios SET id_tipo = %s WHERE id = %s ", (id_tipo,id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def borrar(self,usuario):
		response = False
		id = usuario.getId()
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("DELETE FROM usuarios WHERE id = %s", (id,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response =  False
		return response

	def cambiar_usuario(self,usuario,nuevo_usuario):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("UPDATE usuarios SET nombre = %s WHERE nombre = %s ", (nuevo_usuario,usuario,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def cambiar_clave(self,usuario,nueva_clave):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("UPDATE usuarios SET clave = %s WHERE nombre = %s ", (nueva_clave,usuario,))
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			response = False
		return response

	def comprobar_existencia_usuario_crear(self,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM usuarios WHERE nombre LIKE %s", (nombre,))
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
		
	def comprobar_existencia_usuario_editar(self,nombre):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("SELECT * FROM usuarios WHERE nombre LIKE %s", (nombre,))
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
