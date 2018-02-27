#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

class Producto(object):

   def __init__(self, id="", nombre="", descripcion="",precio="",id_proveedor="",fecha_registro=""):
       self.__id = id
       self.__nombre = nombre
       self.__descripcion = descripcion
       self.__precio = precio
       self.__id_proveedor = id_proveedor
       self.__fecha_registro = fecha_registro
              
   def getId(self):
       return self.__id

   def setId(self, id = ""):
       self.__id = id

   def getNombre(self):
       return self.__nombre

   def setNombre(self, nombre = ""):
       self.__nombre = nombre

   def getDescripcion(self):
       return self.__descripcion

   def setDescripcion(self, descripcion = ""):
       self.__descripcion = descripcion
    
   def getPrecio(self):
       return self.__precio

   def setPrecio(self, precio = ""):
       self.__precio = precio
       
   def getId_proveedor(self):
       return self.__id_proveedor

   def setId_proveedor(self, id_proveedor = ""):
       self.__id_proveedor = id_proveedor
       
   def getFecha_registro(self):
       return self.__fecha_registro

   def setFecha_registro(self, fecha_registro = ""):
       self.__fecha_registro = fecha_registro
       
   def toString(self):
       return "Producto{id=%d, nombre=%s, descripcion=%s, precio=%d, fecha_registro=%s, id_proveedor=%d}" % (self.__id,self.__nombre,self.__descripcion,self.__precio,self.__fecha_registro,self.__id_proveedor)

   def destroy(self):
       self.__id = None
       self.__nombre = None
       self.__descripcion = None
       self.__precio = None
       self.__id_proveedor = None
       self.__fecha_registro = None
