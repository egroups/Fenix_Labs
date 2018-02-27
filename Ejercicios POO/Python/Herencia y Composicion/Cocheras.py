#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2016

from Autos import Auto

class Cochera(object):

   def __init__(self, ambientes="", dimensiones="",auto=""):
       self.__ambientes = ambientes
       self.__dimensiones = dimensiones
       self.__auto = auto
        
   def getAmbientes(self):
       return self.__ambientes

   def setAmbientes(self,ambientes = ""):
       self.__ambientes = ambientes

   def getDimensiones(self):
       return self.__dimensiones

   def setDimensiones(self, dimensiones = ""):
       self.__dimensiones = dimensiones
       
   def getAuto(self):
       return self.__auto

   def setAuto(self,auto = ""):
       self.__auto = auto
           
   def DatosCochera(self):
       contenido = ""
       contenido +=  "-- Datos de la cochera --\n\n[+] Ambientes : %d\n[+] Dimensiones : %s" % (self.__ambientes,self.__dimensiones)
       if self.__auto!=None:
           contenido += "\n-- Datos del auto --\n\n[+] Marca : %s\n[+] Numero de serie : %s" % (self.__auto.getMarca(),self.__auto.getNumero_serie())
       return contenido
          
   def destroy(self):
       self.__ambientes = None
       self.__dimensiones = None
       self.__auto = None

