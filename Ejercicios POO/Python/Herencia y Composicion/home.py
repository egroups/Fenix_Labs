#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Written By Ismael Heredia in the year 2016

from Autos import Auto
from Cocheras import Cochera
from Edificios import Edificio
from Casas import Casa

auto = Auto("Bora 2009", "EJS748")
print(auto.DatosAuto()+"\n")

cochera = Cochera(1, "2.60 x 3.35", auto)
#cochera = Cochera(1, "2.60 x 3.35",None)
print(cochera.DatosCochera()+"\n")

edificio = Edificio("40x40",3)
print(edificio.DatosEdificio()+"\n")

casa = Casa("40x40",3,"Felipe Olmos", 4876972, "Test 2047", cochera)
#print(casa.DatosCasa()+"\n")
print(casa.DatosCasaCompleto()+"\n")

cochera.destroy()
auto.destroy()
edificio.destroy()
casa.destroy()

	
