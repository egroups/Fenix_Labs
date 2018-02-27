# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor
from app.services import Service
from app.functions import Function
from django.db.models import Count
import json

# Create your views here.

service = Service()
function = Function()

def sistema_estadisticas(request):

    textos_grafico1 = []
    series_grafico1 = []

    textos_grafico2 = []
    series_grafico2 = []

    productos = service.listarProductos('')
    cantidad_productos = len(productos)

    for producto in productos:
        nombre = producto.nombre
        precio = producto.precio
        textos_grafico1.append(nombre)
        data = {'name':nombre,'y':precio}
        series_grafico1.append(data)

    json_texto_grafico1 = json.dumps(textos_grafico1)
    json_series_grafico1 = json.dumps(series_grafico1)

    proveedores = Proveedor.objects.annotate(cantidad=Count('producto'))

    for proveedor in proveedores:
        nombre = proveedor.nombre
        cantidad = proveedor.cantidad
        textos_grafico2.append(nombre)
        data = {'name':nombre,'y':cantidad} 
        series_grafico2.append(data)

    json_texto_grafico2 = json.dumps(textos_grafico1)
    json_series_grafico2 = json.dumps(series_grafico2)

    usuario_logeado = service.recibirUsuarioEnSesion(request)

    return render(request, 'estadisticas/reporte.html', {'usuario_logeado':usuario_logeado,'productos':productos,'cantidad_productos':cantidad_productos,'textos_grafico1':json_texto_grafico1,'series_grafico1':json_series_grafico1,'textos_grafico2':json_texto_grafico2,'series_grafico2':json_series_grafico2})