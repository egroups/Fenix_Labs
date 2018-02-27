# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.views.generic.edit import View
from django.contrib import messages
from app.services import Service
from app.functions import Function

# Create your views here.

service = Service()
function = Function()

class AdministracionView(View):

    template_name = 'administracion/index.html'

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(AdministracionView, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def get(self, request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        tipo_usuario = service.detectar_tipo_usuario(usuario_logeado)
        return render(request, 'administracion/index.html', {'usuario_logeado':usuario_logeado,'tipo_usuario':tipo_usuario})