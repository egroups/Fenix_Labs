#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

class Usuario(object):

   def __init__(self, id="", nombre="", clave="",id_tipo="",fecha_registro=""):
       self.__id = id
       self.__nombre = nombre
       self.__clave = clave
       self.__id_tipo = id_tipo
       self.__fecha_registro = fecha_registro
              
   def getId(self):
       return self.__id

   def setId(self, id = ""):
       self.__id = id

   def getNombre(self):
       return self.__nombre

   def setNombre(self, nombre = ""):
       self.__nombre = nombre

   def getClave(self):
       return self.__clave

   def setClave(self, clave = ""):
       self.__clave = clave
    
   def getId_tipo(self):
       return self.__id_tipo

   def setId_tipo(self, id_tipo = ""):
       self.__id_tipo = id_tipo
       
   def getFecha_registro(self):
       return self.__fecha_registro

   def setFecha_registro(self, fecha_registro = ""):
       self.__fecha_registro = fecha_registro
       
   def toString(self):
     return "Usuario{id=%d, nombre=%s, clave=%s, id_tipo=%d, fecha_registro=%s}" % (self.__id,self.__nombre,self.__clave,self.__id_tipo,self.__fecha_registro)
   
   def destroy(self):
       self.__id = None
       self.__nombre = None
       self.__clave = None
       self.__tipo = None
       self.__fecha_registro = None
