# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.core.urlresolvers import reverse_lazy
from django.views.generic import ListView,CreateView,UpdateView,DeleteView
from django.contrib import messages
from app.models import Proveedor
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,ProveedorForm

# Create your views here.

service = Service()
function = Function()

class ProveedorList(ListView):

    template_name = 'proveedores/proveedor_list.html'

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProveedorList, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        form_class = BuscadorForm(request.POST)
        if form_class.is_valid():
            data = form_class.cleaned_data
            patron = data['nombre_buscar']
            object_list = service.listarProveedores(patron)
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            return render(request, self.template_name, {'usuario_logeado':usuario_logeado,'form':form_class,'object_list': object_list })

    def get(self, request, *args, **kwargs):
        object_list = service.listarProveedores('')
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        return render(request, self.template_name, {'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'object_list': object_list })

class ProveedorCreate(CreateView):
    model = Proveedor
    form_class = ProveedorForm
    template_name = 'proveedores/proveedor_form.html'
    success_url = reverse_lazy('sistema_proveedor_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProveedorCreate, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        nombre = data['nombre']
        if service.comprobar_existencia_proveedor_crear(nombre):
            message_text = function.mensaje("Proveedores","El proveedor "+nombre+" ya existe","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect("sistema_proveedor_view")
        else:
            form.save()
            message_text = function.mensaje("Proveedores","Proveedor registrado","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(ProveedorCreate, self).form_valid(form)

    def form_invalid(self, form):
        message_text = function.mensaje("Proveedores","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect("sistema_proveedor_view") 

    def get_context_data(self, **kwargs):
        context = super(ProveedorCreate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = True
        context['usuario_logeado'] = usuario_logeado
        return context

class ProveedorUpdate(UpdateView):
    model = Proveedor
    form_class = ProveedorForm
    template_name = 'proveedores/proveedor_form.html'
    success_url = reverse_lazy('sistema_proveedor_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProveedorUpdate, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        id_proveedor = self.kwargs['pk']
        nombre = data['nombre']
        if service.comprobar_existencia_proveedor_editar(id_proveedor,nombre):
            message_text = function.mensaje("Proveedores","El proveedor "+nombre+" ya existe","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect("sistema_proveedor_view")
        else:
            form.save()
            message_text = function.mensaje("Proveedores","Proveedor editado","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(ProveedorUpdate, self).form_valid(form)

    def form_invalid(self, form):
        message_text = function.mensaje("Proveedores","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect("sistema_proveedor_view",id_proveedor) 

    def get_context_data(self, **kwargs):
        context = super(ProveedorUpdate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = False
        context['usuario_logeado'] = usuario_logeado
        return context

class ProveedorDelete(DeleteView):
    model = Proveedor
    template_name = 'proveedores/proveedor_delete.html'
    success_url = reverse_lazy('sistema_proveedor_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProveedorDelete, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        if "volver_lista" in request.POST:
            return redirect("sistema_proveedor_list") 
        else:
            return super(ProveedorDelete, self).post(request, *args, **kwargs)

    def delete(self, request, *args, **kwargs):
        message_text = function.mensaje("Proveedores","Proveedor borrado","success")
        messages.add_message(request, messages.SUCCESS,message_text)
        return super(ProveedorDelete, self).delete(request, *args, **kwargs)

    def get_context_data(self, **kwargs):
        context = super(ProveedorDelete, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['usuario_logeado'] = usuario_logeado
        return context