#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2016

from Edificios import Edificio
from Cocheras import Cochera

class Casa(Edificio):

   def __init__(self, medidas="",ambientes="",dueno="", telefono="",direccion="",cochera=""):
       Edificio.__init__(self,medidas,ambientes)
       self.__dueno = dueno
       self.__telefono = telefono
       self.__direccion = direccion
       self.__cochera = cochera
              
   def getDueno(self):
       return self.__dueno

   def setDueno(self, dueno = ""):
       self.__dueno = dueno

   def getTelefono(self):
       return self.__telefono

   def setTelefono(self, telefono = ""):
       self.__telefono = telefono
       
   def getDireccion(self):
       return self.__direccion

   def setDireccion(self, direccion = ""):
       self.__direccion = direccion
       
   def getCochera(self):
       return self.__cochera

   def setCochera(self, cochera = ""):
       self.__cochera = cochera
           
   def DatosCasa(self):
       contenido = ""
       contenido += "-- Datos del terreno --\n\n[+] Medidas : %s\n[+] Ambientes : %d\n\n" % (self.getMedidas(),self.getAmbientes())
       contenido += "-- Datos de la casa --\n\n[+] Dueno : %s\n[+] Telefono : %d\n[+] Direccion : %s\n" % (self.__dueno,self.__telefono,self.__direccion)
       if self.__cochera!=None:
           contenido += "[+] Cochera : %s" % (self.__cochera.getDimensiones())
       return contenido
		
   def DatosCasaCompleto(self):
       contenido = ""
       contenido += "-- Datos del terreno --\n\n[+] Medidas : %s\n[+] Ambientes : %d\n\n" % (self.getMedidas(),self.getAmbientes())
       contenido += "-- Datos de la casa --\n\n[+] Dueno : %s\n[+] Telefono : %d\n[+] Direccion : %s\n" % (self.__dueno,self.__telefono,self.__direccion)
       if self.__cochera!=None:
           contenido += "\n-- Datos de la cochera --\n\n[+] Ambientes : %d\n[+] Dimensiones : %s\n" % (self.__cochera.getAmbientes(),self.__cochera.getDimensiones())
           if self.__cochera.getAuto()!=None:
               contenido += "\n-- Datos del auto --\n\n[+] Marca : %s\n[+] Numero serie : %s" % (self.__cochera.getAuto().getMarca(),self.__cochera.getAuto().getNumero_serie())
       return contenido
          
   def destroy(self):
       self.__dueno = None
       self.__telefono = None
       self.__direccion = None
       self.__cochera = None

