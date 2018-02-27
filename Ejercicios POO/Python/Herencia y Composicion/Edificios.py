#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2016

class Edificio(object):

   def __init__(self, medidas="", ambientes=""):
       self.__medidas = medidas
       self.__ambientes = ambientes
              
   def getMedidas(self):
       return self.__medidas

   def setMedidas(self, medidas = ""):
       self.__medidas = medidas

   def getAmbientes(self):
       return self.__ambientes

   def setAmbientes(self, ambientes = ""):
       self.__ambientes = ambientes
           
   def DatosEdificio(self):
       return "-- Datos del edificio --\n\n[+] Medidas : %s\n[+] Ambientes : %d" % (self.__medidas,self.__ambientes)
          
   def destroy(self):
       self.__medidas = None
       self.__ambientes = None

