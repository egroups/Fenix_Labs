#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2016

class Auto(object):

   def __init__(self, marca="", numero_serie=""):
       self.__marca = marca
       self.__numero_serie = numero_serie
              
   def getMarca(self):
       return self.__marca

   def setMarca(self, marca = ""):
       self.__marca = marca

   def getNumero_serie(self):
       return self.__numero_serie

   def setNumero_serie(self, numero_serie = ""):
       self.__numero_serie = numero_serie
           
   def DatosAuto(self):
       return "-- Datos del auto --\n\n[+] Marca : %s\n[+] Numero serie : %s" % (self.__marca,self.__numero_serie)
          
   def destroy(self):
       self.__marca = None
       self.__numero_serie = None

