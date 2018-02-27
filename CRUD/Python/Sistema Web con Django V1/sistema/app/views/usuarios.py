# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor,Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,UsuarioForm

# Create your views here.

service = Service()
function = Function()

def sistema_usuario_list(request):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            if request.method == 'POST':
                form = BuscadorForm(request.POST)
                if form.is_valid():
                    data = form.cleaned_data
                    patron = data['nombre_buscar']
                    usuarios = service.listarUsuarios(patron)
                    cantidad_usuarios = len(usuarios)
                    return render(request, 'usuarios/usuario_list.html', {'usuario_logeado':usuario_logeado,'form':form,'usuarios':usuarios,'cantidad_usuarios':cantidad_usuarios})
            else:              
                usuarios = service.listarUsuarios('')
                cantidad_usuarios = len(usuarios)
                return render(request, 'usuarios/usuario_list.html', {'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'usuarios':usuarios,'cantidad_usuarios':cantidad_usuarios})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_view(request):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            if request.method == 'POST':
                request.POST._mutable = True
                form = UsuarioForm(request.POST)
                if form.is_valid():
                    data = form.cleaned_data
                    nombre = data['nombre']
                    if service.comprobar_existencia_usuario_crear(nombre):
                        message_text = function.mensaje("Usuarios","El usuario "+nombre+" ya existe","warning")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect("sistema_usuario_view")
                    else:
                        obj = form.save(commit=False)
                        password_encoded = function.md5_encode(obj.clave)
                        obj.clave = password_encoded
                        obj.save()
                        message_text = function.mensaje("Usuarios","Usuario registrado","success")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect("sistema_usuario_list")
                else:
                    message_text = function.mensaje("Usuarios","Faltan datos","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_usuario_view")
            else:
                return render(request, 'usuarios/usuario_form.html', {'usuario_logeado':usuario_logeado,'form':UsuarioForm(),'new':True})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_edit(request,id_usuario):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            usuario = get_object_or_404(Usuario, id=id_usuario)
            if request.method == 'GET':
                form = UsuarioForm(instance=usuario)
            else:
                form = UsuarioForm(request.POST,instance=usuario)
                tipo = form.data['tipo']
                if tipo is not None:
                    usuario.tipo = TipoUsuario.objects.get(id=tipo)
                    usuario.save()
                    message_text = function.mensaje("Usuarios","Usuario editado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                else:
                    message_text = function.mensaje("Usuarios","Faltan datos","warning")
                    messages.add_message(request, messages.SUCCESS,message_text) 
                    return redirect('sistema_usuario_edit',id_usuario)     
                return redirect('sistema_usuario_list')
            return render(request,'usuarios/usuario_form.html',{'usuario_logeado':usuario_logeado,'form':form,'usuario':usuario})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_delete(request,id_usuario):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            usuario = get_object_or_404(Usuario, id=id_usuario)
            if request.method == 'POST':
                if 'borrar_usuario' in request.POST:
                    usuario.delete()
                    message_text = function.mensaje("Usuarios","Usuario borrado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_usuario_list')
                elif 'volver_lista' in request.POST:
                    return redirect('sistema_usuario_list')    
            return render(request,'usuarios/usuario_delete.html',{'usuario_logeado':usuario_logeado,'usuario':usuario})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')
