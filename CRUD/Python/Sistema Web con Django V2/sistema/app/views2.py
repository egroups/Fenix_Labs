# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.models import Producto,Proveedor,Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import LoginForm,BuscadorForm,ProductoForm,ProveedorForm,UsuarioForm,CambiarUsuarioForm,CambiarPasswordForm
from django.db.models import Count
import json

# Create your views here.

service = Service()
function = Function()

def listar(request):
    productos = service.listarProductos("")
    proveedores = service.listarProveedores("")
    usuarios = service.listarUsuarios("")
    return render(request, 'home/listar.html', {'productos': productos,'proveedores':proveedores,'usuarios':usuarios})

# Home

def sistema_home(request):
    if service.validar_cookie(request):
        return redirect('sistema_administracion')
    else:
        return render(request, 'login/index.html', {'form':LoginForm()})        

# Login

def sistema_login(request):
    if service.validar_cookie(request):
        return redirect('sistema_administracion')
    else:
        return render(request, 'login/index.html', {'form':LoginForm()})

def sistema_ingreso_usuario(request):
    if service.validar_cookie(request):
        return redirect('sistema_administracion')
    else:
        if request.method == 'POST':
            form = LoginForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                username = data['nombre_usuario']
                password = function.md5_encode(data['clave'])
                if service.ingreso_usuario(username,password):
                    nombre_tipo = service.detectar_tipo_usuario(username)
                    message_text = function.mensaje("Login","Bienvenido a la administracion "+nombre_tipo+" "+username,"success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    request.session['login'] = service.generarSesion(username,password)
                    return redirect('sistema_administracion')
                else:
                    message_text = function.mensaje("Login","Login invalido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_login')
            else:
                message_text = function.mensaje("Login","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text)
        return render(request, 'login/index.html', {'form':LoginForm()})

# LogOut

def sistema_logout(request):
    if service.validar_cookie(request):
        del request.session['login']
        message_text = function.mensaje("Cerrar Sesión","La sesión ha sido cerrada","success")
        messages.add_message(request, messages.SUCCESS,message_text)
        return redirect('sistema_login')
    else:
        return redirect('sistema_login')

# Administracion

def sistema_administracion(request):
    if service.validar_cookie(request):
        username = service.recibirUsuarioEnSesion(request)
        tipo_usuario = service.detectar_tipo_usuario(username)
        return render(request, 'administracion/index.html', {'username':username,'tipo_usuario':tipo_usuario})
    else:
        return redirect('sistema_login')

# Productos

def sistema_producto_list(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = BuscadorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                patron = data['nombre_buscar']
                productos = service.listarProductos(patron)
                cantidad_productos = len(productos)
                return render(request, 'productos/producto_list.html', {'form':form,'productos':productos,'cantidad_productos':cantidad_productos})
        else:              
            productos = service.listarProductos('')
            cantidad_productos = len(productos)
            return render(request, 'productos/producto_list.html', {'form':BuscadorForm(),'productos':productos,'cantidad_productos':cantidad_productos})
    else:
        return redirect('sistema_login')

def sistema_producto_view(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = ProductoForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre_producto = data['nombre_producto']
                if service.comprobar_existencia_producto_crear(nombre_producto):
                    message_text = function.mensaje("Productos","El producto "+nombre_producto+" ya existe","warning")
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
            return render(request, 'productos/producto_form.html', {'form':ProductoForm(),'new':True})
    else:
        return redirect('sistema_login')

def sistema_producto_edit(request,id_producto):
    if service.validar_cookie(request):
        producto = get_object_or_404(Producto, id=id_producto)
        if request.method == 'GET':
            form = ProductoForm(instance=producto)
        else:
            form = ProductoForm(request.POST,instance=producto)
            if form.is_valid():
                data = form.cleaned_data
                nombre_producto = data['nombre_producto']
                if service.comprobar_existencia_producto_editar(id_producto,nombre_producto):
                    message_text = function.mensaje("Productos","El producto "+nombre_producto+" ya existe","warning")
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
        return render(request,'productos/producto_form.html',{'form':form,'producto':producto})
    else:
        return redirect('sistema_login')

def sistema_producto_delete(request,id_producto):
    if service.validar_cookie(request):
        producto = get_object_or_404(Producto, id=id_producto)
        if request.method == 'POST':
            if 'borrar_producto' in request.POST:
                producto.delete()
                message_text = function.mensaje("Productos","Producto borrado","success")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_producto_list')
            elif 'volver_lista' in request.POST:
                return redirect('sistema_producto_list')    
        return render(request,'productos/producto_delete.html',{'producto':producto})
    else:
        return redirect('sistema_login')

# Proveedores

def sistema_proveedor_list(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = BuscadorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                patron = data['nombre_buscar']
                proveedores = service.listarProveedores(patron)
                cantidad_proveedores = len(proveedores)
                return render(request, 'proveedores/proveedor_list.html', {'form':form,'proveedores':proveedores,'cantidad_proveedores':cantidad_proveedores})
        else:              
            proveedores = service.listarProveedores('')
            cantidad_proveedores = len(proveedores)
            return render(request, 'proveedores/proveedor_list.html', {'form':BuscadorForm(),'proveedores':proveedores,'cantidad_proveedores':cantidad_proveedores})
    else:
        return redirect('sistema_login')

def sistema_proveedor_view(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = ProveedorForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre_empresa = data['nombre_empresa']                
                if service.comprobar_existencia_proveedor_crear(nombre_empresa):
                    message_text = function.mensaje("Proveedores","El proveedor "+nombre_empresa+" ya existe","warning")
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
            return render(request, 'proveedores/proveedor_form.html', {'form':ProveedorForm(),'new':True})
    else:
        return redirect('sistema_login')

def sistema_proveedor_edit(request,id_proveedor):
    if service.validar_cookie(request):
        proveedor = get_object_or_404(Proveedor, id=id_proveedor)
        if request.method == 'GET':
            form = ProveedorForm(instance=proveedor)
        else:
            form = ProveedorForm(request.POST,instance=proveedor)
            if form.is_valid():
                data = form.cleaned_data
                nombre_empresa = data['nombre_empresa']
                if service.comprobar_existencia_proveedor_editar(id_proveedor,nombre_empresa):
                    message_text = function.mensaje("Proveedores","El proveedor "+nombre_empresa+" ya existe","warning")
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
        return render(request,'proveedores/proveedor_form.html',{'form':form,'proveedor':proveedor})
    else:
        return redirect('sistema_login')

def sistema_proveedor_delete(request,id_proveedor):
    if service.validar_cookie(request):
        proveedor = get_object_or_404(Proveedor, id=id_proveedor)
        if request.method == 'POST':
            if 'borrar_proveedor' in request.POST:
                proveedor.delete()
                message_text = function.mensaje("Proveedores","Proveedor borrado","success")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_proveedor_list')
            elif 'volver_lista' in request.POST:
                return redirect('sistema_proveedor_list')    
        return render(request,'proveedores/proveedor_delete.html',{'proveedor':proveedor})
    else:
        return redirect('sistema_login')

# Usuarios

def sistema_usuario_list(request):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            if request.method == 'POST':
                form = BuscadorForm(request.POST)
                if form.is_valid():
                    data = form.cleaned_data
                    patron = data['nombre_buscar']
                    usuarios = service.listarUsuarios(patron)
                    cantidad_usuarios = len(usuarios)
                    return render(request, 'usuarios/usuario_list.html', {'form':form,'usuarios':usuarios,'cantidad_usuarios':cantidad_usuarios})
            else:              
                usuarios = service.listarUsuarios('')
                cantidad_usuarios = len(usuarios)
                return render(request, 'usuarios/usuario_list.html', {'form':BuscadorForm(),'usuarios':usuarios,'cantidad_usuarios':cantidad_usuarios})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_view(request):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            if request.method == 'POST':
                request.POST._mutable = True
                form = UsuarioForm(request.POST)
                if form.is_valid():
                    data = form.cleaned_data
                    nombre_usuario = data['nombre_usuario']
                    if service.comprobar_existencia_usuario_crear(nombre_usuario):
                        message_text = function.mensaje("Usuarios","El usuario "+nombre_usuario+" ya existe","warning")
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
                return render(request, 'usuarios/usuario_form.html', {'form':UsuarioForm(),'new':True})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_edit(request,id_usuario):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
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
            return render(request,'usuarios/usuario_form.html',{'form':form,'usuario':usuario})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

def sistema_usuario_delete(request,id_usuario):
    if service.validar_cookie(request):
        if service.validar_cookie_admin(request):
            usuario = get_object_or_404(Usuario, id=id_usuario)
            if request.method == 'POST':
                if 'borrar_usuario' in request.POST:
                    usuario.delete()
                    message_text = function.mensaje("Usuarios","Usuario borrado","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_usuario_list')
                elif 'volver_lista' in request.POST:
                    return redirect('sistema_usuario_list')    
            return render(request,'usuarios/usuario_delete.html',{'usuario':usuario})
        else:
            message_text = function.mensaje("Usuarios","Acceso Denegado","error")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_administracion')
    else:
        return redirect('sistema_login')

# Cuenta

def sistema_cambiar_usuario(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = CambiarUsuarioForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre_usuario = data['nombre_usuario']
                nuevo_usuario = data['nuevo_usuario']
                clave = function.md5_encode(data['clave'])
                if service.ingreso_usuario(nombre_usuario,clave):
                    if service.comprobar_existencia_usuario_crear(nuevo_usuario):
                        message_text = function.mensaje("Usuarios","El usuario "+nombre_usuario+" ya existe","warning")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect('sistema_cambiar_usuario')
                    else:
                        usuario = Usuario.objects.get(nombre_usuario=nombre_usuario)
                        usuario.nombre_usuario = nuevo_usuario
                        usuario.save()
                        del request.session['login']
                        message_text = function.mensaje("Cambiar Usuario","El usuario ha sido cambiado exitosamente, reinicie la aplicacion","success")
                        messages.add_message(request, messages.SUCCESS,message_text)
                        return redirect('sistema_login')
                else:
                    message_text = function.mensaje("Cambiar Usuario","Login invalido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_cambiar_usuario')

        else:
            nombre_usuario = service.recibirUsuarioEnSesion(request)
            form = CambiarUsuarioForm(initial={'nombre_usuario': nombre_usuario})
            return render(request, 'cuenta/cambiar_usuario.html', {'form':form})
    else:
        return redirect('sistema_login')

def sistema_cambiar_password(request):
    if service.validar_cookie(request):
        if request.method == 'POST':
            form = CambiarPasswordForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                nombre_usuario = data['nombre_usuario']
                clave = function.md5_encode(data['clave'])
                nueva_clave = function.md5_encode(data['nueva_clave'])
                if service.ingreso_usuario(nombre_usuario,clave):
                    usuario = Usuario.objects.get(nombre_usuario=nombre_usuario)
                    usuario.clave = nueva_clave
                    usuario.save()
                    del request.session['login']
                    message_text = function.mensaje("Cambiar Password","El password ha sido cambiado exitosamente, reinicie la aplicacion","success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_login')
                else:
                    message_text = function.mensaje("Cambiar Password","Login invalido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_cambiar_password')

        else:
            nombre_usuario = service.recibirUsuarioEnSesion(request)
            form = CambiarPasswordForm(initial={'nombre_usuario': nombre_usuario})
            return render(request, 'cuenta/cambiar_password.html', {'form':form})
    else:
        return redirect('sistema_login')

# Estadisticas

def sistema_estadisticas(request):

    textos_grafico1 = []
    series_grafico1 = []

    textos_grafico2 = []
    series_grafico2 = []

    productos = service.listarProductos('')
    cantidad_productos = len(productos)

    for producto in productos:
        nombre_producto = producto.nombre_producto
        precio = producto.precio
        textos_grafico1.append(nombre_producto)
        data = {'name':nombre_producto,'y':precio}
        series_grafico1.append(data)

    json_texto_grafico1 = json.dumps(textos_grafico1)
    json_series_grafico1 = json.dumps(series_grafico1)

    proveedores = Proveedor.objects.annotate(cantidad=Count('producto'))

    for proveedor in proveedores:
        nombre_empresa = proveedor.nombre_empresa
        cantidad = proveedor.cantidad
        textos_grafico2.append(nombre_empresa)
        data = {'name':nombre_empresa,'y':cantidad} 
        series_grafico2.append(data)

    json_texto_grafico2 = json.dumps(textos_grafico1)
    json_series_grafico2 = json.dumps(series_grafico2)

    return render(request, 'estadisticas/reporte.html', {'productos':productos,'cantidad_productos':cantidad_productos,'textos_grafico1':json_texto_grafico1,'series_grafico1':json_series_grafico1,'textos_grafico2':json_texto_grafico2,'series_grafico2':json_series_grafico2})