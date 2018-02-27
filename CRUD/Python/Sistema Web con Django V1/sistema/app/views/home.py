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

def sistema_home(request):
    if service.validar_cookie(request):
        return redirect('sistema_administracion')
    else:
        return render(request, 'login/index.html', {'form':LoginForm()})  