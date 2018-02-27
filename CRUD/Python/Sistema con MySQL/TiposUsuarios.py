#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2017

class TipoUsuario(object):

   def __init__(self, id="", nombre=""):
       self.__id = id
       self.__nombre = nombre
              
   def getId(self):
       return self.__id

   def setId(self, id = ""):
       self.__id = id

   def getNombre(self):
       return self.__nombre

   def setNombre(self, nombre = ""):
       self.__nombre = nombre
       
   def toString(self):
     return "TipoUsuario{id=%d, nombre=%s}" % (self.__id,self.__nombre)
   
   def destroy(self):
       self.__id = None
       self.__nombre = None
