# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.core.urlresolvers import reverse_lazy
from django.views.generic.edit import View,FormView
from django.contrib import messages
from app.models import Usuario
from app.services import Service
from app.functions import Function
from app.forms import CambiarUsuarioForm,CambiarClaveForm

# Create your views here.

service = Service()
function = Function()

class CambiarUsuarioFormView(FormView):

    template_name = 'cuenta/cambiar_usuario.html'
    form_class = CambiarUsuarioForm
    success_url = reverse_lazy('sistema_login')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(CambiarUsuarioFormView, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
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
                del self.request.session['login']
                message_text = function.mensaje("Cambiar Usuario","El usuario ha sido cambiado exitosamente, reinicie la aplicación","success")
                messages.add_message(self.request, messages.SUCCESS,message_text)
                return super(CambiarUsuarioFormView, self).form_valid(form)
        else:
            message_text = function.mensaje("Cambiar Usuario","Login inválido","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect('sistema_cambiar_usuario')            

    def form_invalid(self,form):
        message_text = function.mensaje("Cambiar Usuario","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect('sistema_cambiar_usuario')

    def get_initial(self):
        nombre = service.recibirUsuarioEnSesion(self.request)
        return { 'nombre': nombre }

    def get_context_data(self, **kwargs):
        context = super(CambiarUsuarioFormView, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['usuario_logeado'] = usuario_logeado
        return context

class CambiarClaveFormView(FormView):

    template_name = 'cuenta/cambiar_clave.html'
    form_class = CambiarClaveForm
    success_url = reverse_lazy('sistema_login')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(CambiarClaveFormView, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        nombre = data['nombre']
        clave = function.md5_encode(data['clave'])
        nueva_clave = function.md5_encode(data['nueva_clave'])
        if service.ingreso_usuario(nombre,clave):
            usuario = Usuario.objects.get(nombre=nombre)
            usuario.clave = nueva_clave
            usuario.save()
            del self.request.session['login']
            message_text = function.mensaje("Cambiar Clave","La clave ha sido cambiada exitosamente, reinicie la aplicación","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(CambiarClaveFormView, self).form_valid(form)
        else:
            message_text = function.mensaje("Cambiar Clave","Login inválido","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect('sistema_cambiar_clave')         

    def form_invalid(self,form):
        message_text = function.mensaje("Cambiar Clave","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect('sistema_cambiar_usuario')

    def get_initial(self):
        nombre = service.recibirUsuarioEnSesion(self.request)
        return { 'nombre': nombre }

    def get_context_data(self, **kwargs):
        context = super(CambiarClaveFormView, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['usuario_logeado'] = usuario_logeado
        return context