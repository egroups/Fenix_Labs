# Written By Ismael Heredia in the year 2017

from app.functions import Function
from app.models import Producto
from app.models import Proveedor
from app.models import Usuario

class Service(object):

    def ingreso_usuario(self,username,password):
        response = False
        function = Function()
        try:
            o = Usuario.objects.get(nombre=username, clave=password)
            response = True
        except Usuario.DoesNotExist:
            response = False
        return response

    def detectar_tipo_usuario(self,username):
        try:
            usuario = Usuario.objects.get(nombre=username)
            nombre_tipo = usuario.tipo.nombre
            return nombre_tipo
        except Exception as e:
            pass

    def generarSesion(self,username,password):
        function = Function()
        contenido = function.base64_encode(username+":"+password)
        return contenido

    def recibirUsuarioEnSesion(self,request):
        function = Function()
        username = ""
        if 'login' in request.session:
            contenido = function.base64_decode(request.session['login'])
            datos = contenido.split(":")
            if datos:
                username = datos[0]
        return username

    def validar_cookie(self,request):
        function = Function()
        response = False
        if 'login' in request.session:
            contenido = function.base64_decode(request.session['login'])
            datos = contenido.split(":")
            if datos:
                username = datos[0]
                password = datos[1]
                if self.ingreso_usuario(username,password):
                    response = True
                else:
                    response = False
        return response

    def validar_cookie_admin(self,request):
        function = Function()
        response = False

        if 'login' in request.session:
            contenido = function.base64_decode(request.session['login'])
            datos = contenido.split(":")
            if datos:
                username = datos[0]
                password = datos[1]
                if self.detectar_tipo_usuario(username) == 'Administrador':
                    if self.ingreso_usuario(username,password):
                        response = True
                    else:
                        response = False
                else:
                    response = False

        return response

    def listarProductos(self,patron):
        try:
	        return Producto.objects.filter(nombre__icontains=patron).order_by('id')
        except Exception as e:
            pass

    def listarProveedores(self,patron):
        try:
            return Proveedor.objects.filter(nombre__icontains=patron).order_by('id')
        except Exception as e:
            pass

    def listarUsuarios(self,patron):
        try:
    	    return Usuario.objects.filter(nombre__icontains=patron).order_by('id')
        except Exception as e:
            pass

    def comprobar_existencia_producto_crear(self,nombre):
        response = False
        try:
            o = Producto.objects.get(nombre=nombre)
            response = True
        except Producto.DoesNotExist:
            response = False
        return response

    def comprobar_existencia_producto_editar(self,id,nombre):
        if Producto.objects.filter(nombre=nombre).exclude(id=id).exists():
            return True
        else:
            return False

    def comprobar_existencia_proveedor_crear(self,nombre):
        response = False
        try:
            o = Proveedor.objects.get(nombre=nombre)
            response = True
        except Proveedor.DoesNotExist:
            response = False
        return response

    def comprobar_existencia_proveedor_editar(self,id,nombre):
        if Proveedor.objects.filter(nombre=nombre).exclude(id=id).exists():
            return True
        else:
            return False

    def comprobar_existencia_usuario_crear(self,nombre):
        response = False
        try:
            o = Usuario.objects.get(nombre=nombre)
            response = True
        except Usuario.DoesNotExist:
            response = False
        return response

    def destroy(self):
        pass