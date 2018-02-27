#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pypyodbc

from Usuarios import Usuario
from Proveedores import Proveedor
from Productos import Producto

import os.path

from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas

from reportlab.graphics.charts.piecharts import Pie
from reportlab.graphics.charts.legends import Legend
from reportlab.graphics.shapes import Drawing

from reportlab.platypus.doctemplate import SimpleDocTemplate
from reportlab.platypus import Paragraph, Spacer

from reportlab.lib.styles import ParagraphStyle
from reportlab.lib.enums import TA_CENTER
from reportlab.lib.validators import Auto
from reportlab.lib import colors

class Conexion(object):
		
	def iniciar_conexion(self):
		self.__conexion = pypyodbc.connect('DRIVER={SQL Server};SERVER=SINDECIDIR-PC;DATABASE=sistema;UID=admin;PWD=123456')
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
		
	def cargarConsulta(self,sql):
		rows = ""
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute(sql)
			rows = cursor.fetchall()
			cursor.close()
			self.cerrar_conexion()
		except:
			pass
		return len(rows)
		
	def ejecutarConsulta(self,sql):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute(sql)
			self.__conexion.commit()
			cursor.close()
			self.cerrar_conexion()
			response = True
		except:
			resposne = False
		return response
		
	def ingreso_usuario(self,username,password):
		response = False
		try:
			rows = "select id_usuario from usuarios where usuario='" + username + "' and clave='" + password + "'"
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_producto_crear(self,nombre_producto):
		response = False
		try:
			rows = "select * from productos where nombre_producto like '"+nombre_producto+"'"
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_producto_editar(self,id_producto,nombre_producto):
		response = False
		try:
			rows = "select * from productos where nombre_producto like '" + nombre_producto + "' and id_producto!="+id_producto
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_proveedor_crear(self,nombre_empresa):
		response = False
		try:
			rows = "select * from proveedores where nombre_empresa like '" + nombre_empresa + "'"
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_proveedor_editar(self,id_proveedor,nombre_empresa):
		response = False
		try:
			rows = "select * from proveedores where nombre_empresa like '" + nombre_empresa + "' and id_proveedor!=" + id_proveedor
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_usuario_crear(self,nombre_usuario):
		response = False
		try:
			rows = "select * from usuarios where usuario like '" + nombre_usuario + "'"
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
		
	def comprobar_existencia_usuario_editar(self,nombre_usuario):
		response = False
		try:
			rows = "select * from usuarios where usuario like '" + nombre_usuario + "'"
			if(self.cargarConsulta(rows)>= 1):
				response = True
			else:
				response = False
		except:
			pass
		return response
					
	def es_admin(self,username):
		response = False
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("select tipo from usuarios where usuario='" + username + "'")
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

	def cargarNombreProveedor(self,id_proveedor):
		nombre_empresa = ""
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			cursor.execute("select nombre_empresa from proveedores where id_proveedor='" + str(id_proveedor) + "'")
			rows = cursor.fetchall()
			if not rows[0][0]=="":
				nombre_empresa = rows[0][0]
			cursor.close()
			self.cerrar_conexion()
		except:
			pass
			
		return nombre_empresa
		
	def listarProveedores(self,patron):
		proveedores = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores where nombre_empresa like '%"+patron+"%'"
			cursor.execute(sql)
			rows = cursor.fetchall()
			for row in rows:
				id_proveedor = row[0]
				nombre_empresa = row[1]
				direccion = row[2]
				telefono = row[3]
				fecha_registro = row[4]
				proveedor = Proveedor(id_proveedor,nombre_empresa,direccion,telefono,fecha_registro)
				proveedores.append(proveedor)
			self.cerrar_conexion()
		except:
			pass
		return proveedores
		
	def listarProductos(self,patron):
		productos = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos where nombre_producto like '%"+patron+"%'"
			cursor.execute(sql)
			rows = cursor.fetchall()
			for row in rows:
				id_producto = row[0]
				nombre_producto = row[1]
				descripcion = row[2]
				precio = row[3]
				id_proveedor = row[4]
				fecha_registro = row[5]
				producto = Producto(id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro)
				productos.append(producto)
			self.cerrar_conexion()
		except:
			pass
		return productos
		
	def listarUsuarios(self,patron):
		usuarios = []
		try:
			self.iniciar_conexion()
			cursor = self.__conexion.cursor()
			sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios where usuario like '%"+patron+"%'"
			cursor.execute(sql)
			rows = cursor.fetchall()
			for row in rows:
				id_usuario = row[0]
				nombre_usuario = row[1]
				clave = row[2]
				tipo = row[3]
				fecha_registro = row[4]
				usuario = Usuario(id_usuario,nombre_usuario,clave,tipo,fecha_registro)
				usuarios.append(usuario)
			self.cerrar_conexion()
		except:
			pass
		return usuarios
		
	# Reportes

	def generarListadoProductos(self):
	
		reporte = canvas.Canvas("listadoProductos.pdf", pagesize=letter)

		reporte.setFont("Helvetica",20)
		reporte.drawString(30,740,"Reporte de listado de productos")

		reporte.setFont("Helvetica", 12)
		reporte.drawString(30,700,"id_producto")
		reporte.drawString(100,700,"nombre_producto")
		reporte.drawString(210,700,"precio")
		reporte.drawString(260,700,"fecha_registro")
		reporte.drawString(350,700,"proveedor")

		reporte.setFont("Helvetica",8)

		linea = 700

		self.iniciar_conexion()
		cursor = self.__conexion.cursor()
		sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos"
		cursor.execute(sql)
		rows = cursor.fetchall()

		for row in rows:
			id_producto = row[0]
			nombre_producto = row[1]
			descripcion = row[2]
			precio = row[3]
			id_proveedor = row[4]
			fecha_registro = row[5]
			nombre_proveedor = self.cargarNombreProveedor(id_proveedor)
			#print(nombre_producto+"-"+str(id_proveedor)+"-"+nombre_proveedor)
			linea = linea - 20
			reporte.drawString(30,linea,str(id_producto))
			reporte.drawString(100,linea,str(nombre_producto))
			reporte.drawString(210,linea,str(precio))
			reporte.drawString(260,linea,str(fecha_registro))
			reporte.drawString(350,linea,str(nombre_proveedor))
	
		self.cerrar_conexion()

		reporte.save()
		
		if(os.path.isfile("listadoProductos.pdf")):
			return True
		else:
			return False
			
	def generarGraficoProductos(self):
		nombres = []
		precios = []
	 
		self.iniciar_conexion()
		cursor = self.__conexion.cursor()
		sql = "select nombre_producto,sum(precio) as precio_final from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor group by nombre_producto"
		cursor.execute(sql)
		rows = cursor.fetchall()

		for row in rows:
			nombre_producto = row[0]
			precio = row[1]
			nombres.append(nombre_producto)
			precios.append(precio)
			#print(nombre_producto+"-"+str(precio)+"-")
	
		self.cerrar_conexion()

		reporte = SimpleDocTemplate("graficoProductos.pdf")
		partes = []

		font_text = ParagraphStyle("test")
		font_text.textColor = "black"
		font_text.alignment = TA_CENTER
		font_text.fontSize = 20

		text = Paragraph("Reporte grafico de productos y sus precios",font_text)
		partes.append(text)
		draw = Drawing()
		pie = Pie()
		pie.width = 300
		pie.height = 200
		pie.x = 50
		pie.y = -100
		pie.data = precios
		pie.labels = nombres
		pie.slices.strokeWidth = 0.5

		legend = Legend() 
		legend.x               = 250
		legend.y               = -200 
		legend.dx              = 8  
		legend.dy              = 8  
		legend.fontName        = "Helvetica"  
		legend.fontSize        = 7  
		legend.boxAnchor       = "n"  
		legend.columnMaximum   = 10  
		legend.strokeWidth     = 1  
		legend.strokeColor     = colors.black  
		legend.deltax          = 75  
		legend.deltay          = 10  
		legend.autoXPadding    = 5  
		legend.yGap            = 0  
		legend.dxTextSpace     = 5  
		legend.alignment       = "right"  
		legend.dividerLines    = 1|2|4  
		legend.dividerOffsY    = 4.5  
		legend.subCols.rpad    = 30  
    
		legend.colorNamePairs  = [(
                            pie.slices[i].fillColor, 
                            (pie.labels[i][0:20], "$"+"%0.2f" % pie.data[i])
                           ) for i in xrange(len(pie.data))]
                           
		draw.add(legend)

		draw.add(pie)

		partes.append(draw)
		reporte.build(partes)
		
		if(os.path.isfile("graficoProductos.pdf")):
			return True
		else:
			return False
			
	def generarGraficoProveedores(self):
		nombres = []
		cantidades = []
	 
		self.iniciar_conexion()
		cursor = self.__conexion.cursor()
		sql = "select nombre_empresa,count(prod.id_proveedor) as cantidad from productos prod,proveedores prov where prod.id_proveedor=prov.id_proveedor group by nombre_empresa"
		cursor.execute(sql)
		rows = cursor.fetchall()

		for row in rows:
			nombre_empresa = row[0]
			cantidad = row[1]
			nombres.append(nombre_empresa)
			cantidades.append(cantidad)
			#print(nombre_empresa+"-"+str(cantidad)+"-")
	
		self.cerrar_conexion()

		reporte = SimpleDocTemplate("graficoProveedores.pdf")
		partes = []

		font_text = ParagraphStyle("test")
		font_text.textColor = "black"
		font_text.alignment = TA_CENTER
		font_text.fontSize = 20

		text = Paragraph("Reporte grafico de proveedores",font_text)
		partes.append(text)
		draw = Drawing()
		pie = Pie()
		pie.width = 300
		pie.height = 200
		pie.x = 50
		pie.y = -100
		pie.data = cantidades
		pie.labels = nombres
		pie.slices.strokeWidth = 0.5

		legend = Legend() 
		legend.x               = 250
		legend.y               = -200 
		legend.dx              = 8  
		legend.dy              = 8  
		legend.fontName        = "Helvetica"  
		legend.fontSize        = 7  
		legend.boxAnchor       = "n"  
		legend.columnMaximum   = 10  
		legend.strokeWidth     = 1  
		legend.strokeColor     = colors.black
		legend.deltax          = 75  
		legend.deltay          = 10  
		legend.autoXPadding    = 5  
		legend.yGap            = 0  
		legend.dxTextSpace     = 5  
		legend.alignment       = "right"  
		legend.dividerLines    = 1|2|4  
		legend.dividerOffsY    = 4.5  
		legend.subCols.rpad    = 30  
    
		legend.colorNamePairs  = [(
                            pie.slices[i].fillColor, 
                            (pie.labels[i][0:20], "%0.0f prod" % pie.data[i])
                           ) for i in xrange(len(pie.data))]
                           
		draw.add(legend)

		draw.add(pie)

		partes.append(draw)
		reporte.build(partes)
		
		if(os.path.isfile("graficoProveedores.pdf")):
			return True
		else:
			return False		
							
	def destroy(self):
		self.__conexion = None
