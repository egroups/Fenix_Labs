# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.services import Service
from app.functions import Function

# Create your views here.

service = Service()
function = Function()

def sistema_administracion(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        tipo_usuario = service.detectar_tipo_usuario(usuario_logeado)
        return render(request, 'administracion/index.html', {'usuario_logeado':usuario_logeado,'tipo_usuario':tipo_usuario})
    else:
        return redirect('sistema_login')