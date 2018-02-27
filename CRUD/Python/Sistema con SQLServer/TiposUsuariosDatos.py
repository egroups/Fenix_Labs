#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pypyodbc

from TiposUsuarios import TipoUsuario

class TipoUsuarioDatos(object):
		
	def iniciar_conexion(self):
		self.__conexion = pypyodbc.connect('DRIVER={SQL Server};SERVER=SINDECIDIR-PC;DATABASE=sistemaV2;UID=admin;PWD=123456')
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
						
	def listar(self):
		tipos_usuarios = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("select id,nombre from tipos_usuarios")
			rows = cursor.fetchall()
			for row in rows:
				id = row[0]
				nombre = row[1]
				tipousuario = TipoUsuario(id,nombre)
				tipos_usuarios.append(tipousuario)
			self.cerrar_conexion()
		except:
			pass
		return tipos_usuarios
																
	def destroy(self):
		self.__conexion = None
