# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor,Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import CambiarUsuarioForm,CambiarClaveForm

# Create your views here.

service = Service()
function = Function()

def sistema_cambiar_usuario(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = CambiarUsuarioForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']
                nuevo_nombre = data['nuevo_nombre']
                clave = function.md5_encode(data['clave'])
                if service.ingreso_usuario(nombre,clave):
                    if service.comprobar_existencia_usuario_crear(nuevo_nombre):
                        message_text = function.mensaje("Usuarios","El usuario "+nombre+" ya existe","warning")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect('sistema_cambiar_usuario')
                    else:
                        usuario = Usuario.objects.get(nombre=nombre)
                        usuario.nombre = nuevo_nombre
                        usuario.save()
                        del request.session['login']
                        message_text = function.mensaje("Cambiar Usuario","El usuario ha sido cambiado exitosamente, reinicie la aplicación","success")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect('sistema_login')
                else:
                    message_text = function.mensaje("Cambiar Usuario","Login inválido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_cambiar_usuario')

        else:
            form = CambiarUsuarioForm(initial={'nombre': usuario_logeado})
            return render(request, 'cuenta/cambiar_usuario.html', {'usuario_logeado':usuario_logeado,'form':form})
    else:
        return redirect('sistema_login')

def sistema_cambiar_clave(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = CambiarClaveForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']
                clave = function.md5_encode(data['clave'])
                nueva_clave = function.md5_encode(data['nueva_clave'])
                if service.ingreso_usuario(nombre,clave):
                    usuario = Usuario.objects.get(nombre=nombre)
                    usuario.clave = nueva_clave
                    usuario.save()
                    del request.session['login']
                    message_text = function.mensaje("Cambiar Clave","La clave ha sido cambiada exitosamente, reinicie la aplicación","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_login')
                else:
                    message_text = function.mensaje("Cambiar Clave","Login inválido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_cambiar_clave')

        else:
            form = CambiarClaveForm(initial={'nombre': usuario_logeado})
            return render(request, 'cuenta/cambiar_clave.html', {'usuario_logeado':usuario_logeado,'form':form})
    else:
        return redirect('sistema_login')