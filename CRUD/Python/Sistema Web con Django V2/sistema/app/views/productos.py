# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.core.urlresolvers import reverse_lazy
from django.views.generic import ListView,CreateView,UpdateView,DeleteView
from django.contrib import messages
from app.models import Producto
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,ProductoForm

# Create your views here.

service = Service()
function = Function()

class ProductoList(ListView):

    template_name = 'productos/producto_list.html'

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProductoList, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        form_class = BuscadorForm(request.POST)
        if form_class.is_valid():
            data = form_class.cleaned_data
            patron = data['nombre_buscar']
            object_list = service.listarProductos(patron)
            return render(request, self.template_name, {'form':form_class,'object_list': object_list })

    def get(self, request, *args, **kwargs):
        object_list = service.listarProductos('')
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        return render(request, self.template_name, {'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'object_list': object_list })

class ProductoCreate(CreateView):
    model = Producto
    form_class = ProductoForm
    template_name = 'productos/producto_form.html'
    success_url = reverse_lazy('sistema_producto_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProductoCreate, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        nombre = data['nombre']
        if service.comprobar_existencia_producto_crear(nombre):
            message_text = function.mensaje("Productos","El producto "+nombre+" ya existe","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect("sistema_producto_view")
        else:
            form.save()
            message_text = function.mensaje("Productos","Producto registrado","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(ProductoCreate, self).form_valid(form)

    def form_invalid(self, form):
        message_text = function.mensaje("Productos","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect("sistema_producto_view") 

    def get_context_data(self, **kwargs):
        context = super(ProductoCreate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = True
        context['usuario_logeado'] = usuario_logeado
        return context

class ProductoUpdate(UpdateView):
    model = Producto
    form_class = ProductoForm
    template_name = 'productos/producto_form.html'
    success_url = reverse_lazy('sistema_producto_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProductoUpdate, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        id_producto = self.kwargs['pk']
        nombre = data['nombre']
        if service.comprobar_existencia_producto_editar(id_producto,nombre):
            message_text = function.mensaje("Productos","El producto "+nombre+" ya existe","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect("sistema_producto_view")
        else:
            form.save()
            message_text = function.mensaje("Productos","Producto editado","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(ProductoUpdate, self).form_valid(form)

    def form_invalid(self, form):
        message_text = function.mensaje("Productos","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect("sistema_producto_view",id_producto) 

    def get_context_data(self, **kwargs):
        context = super(ProductoUpdate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = False
        context['usuario_logeado'] = usuario_logeado
        return context

class ProductoDelete(DeleteView):
    model = Producto
    template_name = 'productos/producto_delete.html'
    success_url = reverse_lazy('sistema_producto_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            return super(ProductoDelete, self).dispatch(request, *args, **kwargs)
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        if "volver_lista" in request.POST:
            return redirect("sistema_producto_list") 
        else:
            return super(ProductoDelete, self).post(request, *args, **kwargs)

    def delete(self, request, *args, **kwargs):
        message_text = function.mensaje("Productos","Producto borrado","success")
        messages.add_message(request, messages.SUCCESS,message_text)
        return super(ProductoDelete, self).delete(request, *args, **kwargs)

    def get_context_data(self, **kwargs):
        context = super(ProductoDelete, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['usuario_logeado'] = usuario_logeado
        return context