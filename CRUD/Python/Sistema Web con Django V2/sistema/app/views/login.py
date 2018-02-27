# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.core.urlresolvers import reverse_lazy
from django.views.generic.edit import View,FormView
from django.contrib import messages
from app.services import Service
from app.functions import Function
from app.forms import LoginForm

# Create your views here.

service = Service()
function = Function()

class LoginFormView(FormView):

    template_name = 'login/index.html'
    form_class = LoginForm
    success_url = reverse_lazy('sistema_administracion')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return redirect('sistema_administracion')
        else:
            return super(LoginFormView, self).dispatch(request, *args, **kwargs)

    def form_valid(self, form):
        data = form.cleaned_data
        username = data['usuario']
        password = function.md5_encode(data['clave'])
        if service.ingreso_usuario(username,password):
            nombre_tipo = service.detectar_tipo_usuario(username)
            message_text = function.mensaje("Login","Bienvenido a la administración "+nombre_tipo+" "+username,"success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            self.request.session['login'] = service.generarSesion(username,password)
            return super(LoginFormView, self).form_valid(form)
        else:
            message_text = function.mensaje("Login","Login inválido","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect('sistema_login')

    def form_invalid(self,form):
        message_text = function.mensaje("Login","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect('sistema_login')

class LogoutView(View):
    
    def get(self, request):
        if service.validar_cookie(request):
            del request.session['login']
            message_text = function.mensaje("Cerrar Sesión","La sesión ha sido cerrada","success")
            messages.add_message(request, messages.SUCCESS,message_text)
            return redirect('sistema_login')
        else:
            return redirect('sistema_login')