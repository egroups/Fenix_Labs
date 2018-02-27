# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor,Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,ProductoForm

# Create your views here.

service = Service()
function = Function()

def sistema_producto_list(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = BuscadorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                patron = data['nombre_buscar']
                productos = service.listarProductos(patron)
                cantidad_productos = len(productos)
                return render(request, 'productos/producto_list.html', {'usuario_logeado':usuario_logeado,'form':form,'productos':productos,'cantidad_productos':cantidad_productos})
        else:              
            productos = service.listarProductos('')
            cantidad_productos = len(productos)
            return render(request, 'productos/producto_list.html', {'usuario_logeado':usuario_logeado,'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'productos':productos,'cantidad_productos':cantidad_productos})
    else:
        return redirect('sistema_login')

def sistema_producto_view(request):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        if request.method == 'POST':
            form = ProductoForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']
                if service.comprobar_existencia_producto_crear(nombre):
                    message_text = function.mensaje("Productos","El producto "+nombre+" ya existe","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_producto_view")
                else:
                    form.save()
                    message_text = function.mensaje("Productos","Producto registrado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_producto_list")
            else:
                message_text = function.mensaje("Productos","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect("sistema_producto_view")
        else:
            return render(request, 'productos/producto_form.html', {'usuario_logeado':usuario_logeado,'form':ProductoForm(),'new':True})
    else:
        return redirect('sistema_login')

def sistema_producto_edit(request,id_producto):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        producto = get_object_or_404(Producto, id=id_producto)
        if request.method == 'GET':
            form = ProductoForm(instance=producto)
        else:
            form = ProductoForm(request.POST,instance=producto)
            if form.is_valid():
                data = form.cleaned_data
                nombre = data['nombre']
                if service.comprobar_existencia_producto_editar(id_producto,nombre):
                    message_text = function.mensaje("Productos","El producto "+nombre+" ya existe","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect("sistema_producto_edit",id_producto)
                else:
                    form.save()
                    message_text = function.mensaje("Productos","Producto editado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
            else:
                message_text = function.mensaje("Productos","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text) 
                return redirect("sistema_producto_edit",id_producto)
            return redirect('sistema_producto_list')
        return render(request,'productos/producto_form.html',{'usuario_logeado':usuario_logeado,'form':form,'producto':producto})
    else:
        return redirect('sistema_login')

def sistema_producto_delete(request,id_producto):
    if service.validar_cookie(request):
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        producto = get_object_or_404(Producto, id=id_producto)
        if request.method == 'POST':
            if 'borrar_producto' in request.POST:
                producto.delete()
                message_text = function.mensaje("Productos","Producto borrado","success")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_producto_list')
            elif 'volver_lista' in request.POST:
                return redirect('sistema_producto_list')    
        return render(request,'productos/producto_delete.html',{'usuario_logeado':usuario_logeado,'producto':producto})
    else:
        return redirect('sistema_login')