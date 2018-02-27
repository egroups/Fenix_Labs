# Written By Ismael Heredia in the year 2017

from django.shortcuts import render,redirect,get_object_or_404
from django.http import HttpResponse
from django.core.urlresolvers import reverse_lazy
from django.views.generic import ListView,CreateView,UpdateView,DeleteView
from django.contrib import messages
from app.models import Usuario,TipoUsuario
from app.services import Service
from app.functions import Function
from app.forms import BuscadorForm,UsuarioForm

# Create your views here.

service = Service()
function = Function()

class UsuarioList(ListView):

    template_name = 'usuarios/usuario_list.html'

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            if service.validar_cookie_admin(request):
                return super(UsuarioList, self).dispatch(request, *args, **kwargs)
            else:
                message_text = function.mensaje("Usuarios","Acceso Denegado","error")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_administracion')
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        form_class = BuscadorForm(request.POST)
        if form_class.is_valid():
            data = form_class.cleaned_data
            patron = data['nombre_buscar']
            object_list = service.listarUsuarios(patron)
            usuario_logeado = service.recibirUsuarioEnSesion(request)
            return render(request, self.template_name, {'usuario_logeado':usuario_logeado,'form':form_class,'object_list': object_list })

    def get(self, request, *args, **kwargs):
        object_list = service.listarUsuarios('')
        usuario_logeado = service.recibirUsuarioEnSesion(request)
        return render(request, self.template_name, {'usuario_logeado':usuario_logeado,'form':BuscadorForm(),'object_list': object_list })

class UsuarioCreate(CreateView):
    model = Usuario
    form_class = UsuarioForm
    template_name = 'usuarios/usuario_form.html'
    success_url = reverse_lazy('sistema_usuario_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            if service.validar_cookie_admin(request):
                return super(UsuarioCreate, self).dispatch(request, *args, **kwargs)
            else:
                message_text = function.mensaje("Usuarios","Acceso Denegado","error")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_administracion')
        else:
            return redirect('sistema_login')

    def form_valid(self, form):
        data = form.cleaned_data
        nombre = data['nombre']
        if service.comprobar_existencia_usuario_crear(nombre):
            message_text = function.mensaje("Usuarios","El usuario "+nombre+" ya existe","warning")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return redirect("sistema_usuario_view")
        else:
            obj = form.save(commit=False)
            password_encoded = function.md5_encode(obj.clave)
            obj.clave = password_encoded
            obj.save()
            message_text = function.mensaje("Usuarios","Usuario registrado","success")
            messages.add_message(self.request, messages.SUCCESS,message_text)
            return super(UsuarioCreate, self).form_valid(form)

    def form_invalid(self, form):
        message_text = function.mensaje("Usuarios","Faltan datos","warning")
        messages.add_message(self.request, messages.SUCCESS,message_text)
        return redirect("sistema_usuario_view") 

    def get_context_data(self, **kwargs):
        context = super(UsuarioCreate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = True
        context['usuario_logeado'] = usuario_logeado
        return context

class UsuarioUpdate(UpdateView):
    model = Usuario
    form_class = UsuarioForm
    template_name = 'usuarios/usuario_form.html'
    success_url = reverse_lazy('sistema_usuario_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            if service.validar_cookie_admin(request):
                return super(UsuarioUpdate, self).dispatch(request, *args, **kwargs)
            else:
                message_text = function.mensaje("Usuarios","Acceso Denegado","error")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_administracion')
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        id_usuario = self.kwargs['pk']
        usuario = get_object_or_404(Usuario, id=id_usuario)
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

    def get_context_data(self, **kwargs):
        context = super(UsuarioUpdate, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['new'] = False
        context['usuario_logeado'] = usuario_logeado
        return context

class UsuarioDelete(DeleteView):
    model = Usuario
    template_name = 'usuarios/usuario_delete.html'
    success_url = reverse_lazy('sistema_usuario_list')

    def dispatch(self, request, *args, **kwargs):
        if service.validar_cookie(request):
            if service.validar_cookie_admin(request):
                return super(UsuarioDelete, self).dispatch(request, *args, **kwargs)
            else:
                message_text = function.mensaje("Usuarios","Acceso Denegado","error")
                messages.add_message(request, messages.SUCCESS,message_text)
                return redirect('sistema_administracion')
        else:
            return redirect('sistema_login')

    def post(self, request, *args, **kwargs):
        if "volver_lista" in request.POST:
            return redirect("sistema_usuario_list") 
        else:
            return super(UsuarioDelete, self).post(request, *args, **kwargs)

    def delete(self, request, *args, **kwargs):
        message_text = function.mensaje("Usuarios","Usuario borrado","success")
        messages.add_message(request, messages.SUCCESS,message_text)
        return super(UsuarioDelete, self).delete(request, *args, **kwargs)

    def get_context_data(self, **kwargs):
        context = super(UsuarioDelete, self).get_context_data(**kwargs)
        usuario_logeado = service.recibirUsuarioEnSesion(self.request)
        context['usuario_logeado'] = usuario_logeado
        return context