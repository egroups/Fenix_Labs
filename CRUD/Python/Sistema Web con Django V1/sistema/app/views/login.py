# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.contrib import messages
from app.services import Service
from app.functions import Function
from app.forms import LoginForm

# Create your views here.

service = Service()
function = Function()

def sistema_login(request):
    if service.validar_cookie(request):
        return redirect('sistema_administracion')
    else:
        if request.method == 'POST':
            form = LoginForm(request.POST)
            if form.is_valid():
                data = form.cleaned_data
                username = data['usuario']
                password = function.md5_encode(data['clave'])
                if service.ingreso_usuario(username,password):
                    nombre_tipo = service.detectar_tipo_usuario(username)
                    message_text = function.mensaje("Login","Bienvenido a la administración "+nombre_tipo+" "+username,"success")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    request.session['login'] = service.generarSesion(username,password)
                    return redirect('sistema_administracion')
                else:
                    message_text = function.mensaje("Login","Login inválido","warning")
                    messages.add_message(request, messages.SUCCESS,message_text)
                    return redirect('sistema_login')
            else:
                message_text = function.mensaje("Login","Faltan datos","warning")
                messages.add_message(request, messages.SUCCESS,message_text)
        return render(request, 'login/index.html', {'form':LoginForm()})

def sistema_logout(request):
    if service.validar_cookie(request):
        del request.session['login']
        message_text = function.mensaje("Cerrar Sesión","La sesión ha sido cerrada","success")
        messages.add_message(request, messages.SUCCESS,message_text)
        return redirect('sistema_login')
    else:
        return redirect('sistema_login')