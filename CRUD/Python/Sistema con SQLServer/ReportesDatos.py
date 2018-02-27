#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

import pypyodbc

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

class ReporteDatos(object):
		
	def iniciar_conexion(self):
		self.__conexion = pypyodbc.connect('DRIVER={SQL Server};SERVER=SINDECIDIR-PC;DATABASE=sistemaV2;UID=admin;PWD=123456')
		
	def cerrar_conexion(self):
		try:
			self.__conexion.close()
		except:
			pass
		
	def generarListadoProductos(self):
	
		reporte = canvas.Canvas("listadoProductos.pdf", pagesize=letter)

		reporte.setFont("Helvetica",20)
		reporte.drawString(30,740,"Reporte de listado de productos")

		reporte.setFont("Helvetica", 12)
		reporte.drawString(30,700,"id")
		reporte.drawString(100,700,"nombre")
		reporte.drawString(210,700,"precio")
		reporte.drawString(260,700,"fecha_registro")
		reporte.drawString(350,700,"proveedor")

		reporte.setFont("Helvetica",8)

		linea = 700

		self.iniciar_conexion()
		cursor = self.__conexion.cursor()
		cursor.execute("SELECT prod.id,prod.nombre,prod.descripcion,prod.precio,prod.id_proveedor,prod.fecha_registro,prov.nombre FROM productos prod,proveedores prov WHERE prod.id_proveedor=prov.id")
		rows = cursor.fetchall()

		for row in rows:
			id = row[0]
			nombre = row[1]
			descripcion = row[2]
			precio = row[3]
			id_proveedor = row[4]
			fecha_registro = row[5]
			nombre_proveedor = row[6]
			linea = linea - 20
			reporte.drawString(30,linea,str(id))
			reporte.drawString(100,linea,str(nombre))
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
		sql = "SELECT prod.nombre,SUM(prod.precio) AS precio_final FROM productos prod,proveedores prov WHERE prod.id_proveedor=prov.id GROUP BY prod.nombre"
		cursor.execute(sql)
		rows = cursor.fetchall()

		for row in rows:
			nombre_producto = row[0]
			precio = row[1]
			nombres.append(nombre_producto)
			precios.append(precio)

		self.cerrar_conexion()

		reporte = SimpleDocTemplate("graficoProductos.pdf")
		partes = []

		font_text = ParagraphStyle("test")
		font_text.textColor = "black"
		font_text.alignment = TA_CENTER
		font_text.fontSize = 20

		text = Paragraph("Reporte gráfico de productos y sus precios",font_text)
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
		sql = "SELECT prov.nombre,COUNT(prod.id_proveedor) AS cantidad FROM productos prod,proveedores prov WHERE prod.id_proveedor=prov.id GROUP BY prov.nombre"
		cursor.execute(sql)
		rows = cursor.fetchall()

		for row in rows:
			nombre = row[0]
			cantidad = row[1]
			nombres.append(nombre)
			cantidades.append(cantidad)
	
		self.cerrar_conexion()

		reporte = SimpleDocTemplate("graficoProveedores.pdf")
		partes = []

		font_text = ParagraphStyle("test")
		font_text.textColor = "black"
		font_text.alignment = TA_CENTER
		font_text.fontSize = 20

		text = Paragraph("Reporte gráfico de proveedores",font_text)
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
