# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor,Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,ProveedorForm

# Create your views here.

service = Service()
function = Function()

def sistema_proveedor_list(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = BuscadorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                patron = data['nombre_buscar']
                proveedores = service.listarProveedores(patron)
                cantidad_proveedores = len(proveedores)
                return render(request, 'proveedores/proveedor_list.html', {'usuario_logeado':usuario_logeado,'form':form,'proveedores':proveedores,'cantidad_proveedores':cantidad_proveedores})
        else:              
            proveedores = service.listarProveedores('')
            cantidad_proveedores = len(proveedores)
            return render(request, 'proveedores/proveedor_list.html', {'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'proveedores':proveedores,'cantidad_proveedores':cantidad_proveedores})
    else:
        return redirect('sistema_login')

def sistema_proveedor_view(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = ProveedorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']                
                if service.comprobar_existencia_proveedor_crear(nombre):
                    message_text = function.mensaje("Proveedores","El proveedor "+nombre+" ya existe","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_proveedor_view")
                else:
                    form.save()
                    message_text = function.mensaje("Proveedores","Proveedor registrado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_proveedor_list")
            else:
                message_text = function.mensaje("Proveedores","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect("sistema_proveedor_view")
        else:
            usuario = service.recibirUsuarioEnSesion(request)
            return render(request, 'proveedores/proveedor_form.html', {'usuario_logeado':usuario_logeado,'form':ProveedorForm(),'new':True})
    else:
        return redirect('sistema_login')

def sistema_proveedor_edit(request,id_proveedor):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        proveedor = get_object_or_404(Proveedor, id=id_proveedor)
        if request.method == 'GET':
            form = ProveedorForm(instance=proveedor)
        else:
            form = ProveedorForm(request.POST,instance=proveedor)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']
                if service.comprobar_existencia_proveedor_editar(id_proveedor,nombre):
                    message_text = function.mensaje("Proveedores","El proveedor "+nombre+" ya existe","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_proveedor_edit",id_proveedor)
                else:
                    form.save()
                    message_text = function.mensaje("Proveedores","Proveedor editado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
            else:
                message_text = function.mensaje("Proveedores","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text)  
                return redirect("sistema_proveedor_edit",id_proveedor)    
            return redirect('sistema_proveedor_list')
        return render(request,'proveedores/proveedor_form.html',{'usuario_logeado':usuario_logeado,'form':form,'proveedor':proveedor})
    else:
        return redirect('sistema_login')

def sistema_proveedor_delete(request,id_proveedor):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        proveedor = get_object_or_404(Proveedor, id=id_proveedor)
        if request.method == 'POST':
            if 'borrar_proveedor' in request.POST:
                proveedor.delete()
                message_text = function.mensaje("Proveedores","Proveedor borrado","success")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_proveedor_list')
            elif 'volver_lista' in request.POST:
                return redirect('sistema_proveedor_list')    
        return render(request,'proveedores/proveedor_delete.html',{'usuario_logeado':usuario_logeado,'proveedor':proveedor})
    else:
        return redirect('sistema_login')