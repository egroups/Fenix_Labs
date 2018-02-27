#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

class Proveedor(object):

   def __init__(self, id="", nombre="", direccion="",telefono="",fecha_registro=""):
       self.__id = id
       self.__nombre = nombre
       self.__direccion = direccion
       self.__telefono = telefono
       self.__fecha_registro = fecha_registro
              
   def getId(self):
       return self.__id

   def setId(self, id = ""):
       self.__id = id

   def getNombre(self):
       return self.__nombre

   def setNombre(self, nombre = ""):
       self.__nombre = nombre

   def getDireccion(self):
       return self.__direccion

   def setDireccion(self, direccion = ""):
       self.__direccion = direccion
    
   def getTelefono(self):
       return self.__telefono

   def setTelefono(self, telefono = ""):
       self.__telefono = telefono
       
   def getFecha_registro(self):
       return self.__fecha_registro

   def setFecha_registro(self, fecha_registro = ""):
       self.__fecha_registro = fecha_registro
       
   def toString(self):
       return "Proveedor{id=%d, nombre=%s, direccion=%s, telefono=%d, fecha_registro=%s}" % (self.__id,self.__nombre,self.__direccion,self.__telefono,self.__fecha_registro)

   def destroy(self):
       self.__id = None
       self.__nombre = None
       self.__direccion = None
       self.__telefono = None
       self.__fecha_registro = None
