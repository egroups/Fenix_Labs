# Written By Ismael Heredia in the year 2017

from django.conf.urls import include, url
from app.views import home,login,administracion,productos,proveedores,usuarios,cuenta,estadisticas

urlpatterns = [

    url(r'^$', home.HomeView.as_view(), name='sistema_home'),

    url(r'^login/$',  login.LoginFormView.as_view(), name='sistema_login'),
    url(r'^administracion/logout/$',  login.LogoutView.as_view(), name='sistema_logout'),

    url(r'^administracion/$',  administracion.AdministracionView.as_view(), name='sistema_administracion'),

    url(r'^administracion/productos/$',  productos.ProductoList.as_view(), name='sistema_producto_list'),
    url(r'^administracion/productos/agregar$',  productos.ProductoCreate.as_view(), name='sistema_producto_view'),
    url(r'^administracion/productos/editar/(?P<pk>\d+)/$',  productos.ProductoUpdate.as_view(), name='sistema_producto_edit'),
    url(r'^administracion/productos/borrar/(?P<pk>\d+)/$',  productos.ProductoDelete.as_view(), name='sistema_producto_delete'),

    url(r'^administracion/proveedores/$',  proveedores.ProveedorList.as_view(), name='sistema_proveedor_list'),
    url(r'^administracion/proveedores/agregar$',  proveedores.ProveedorCreate.as_view(), name='sistema_proveedor_view'),
    url(r'^administracion/proveedores/editar/(?P<pk>\d+)/$',  proveedores.ProveedorUpdate.as_view(), name='sistema_proveedor_edit'),
    url(r'^administracion/proveedores/borrar/(?P<pk>\d+)/$',  proveedores.ProveedorDelete.as_view(), name='sistema_proveedor_delete'),

    url(r'^administracion/usuarios/$',  usuarios.UsuarioList.as_view(), name='sistema_usuario_list'),
    url(r'^administracion/usuarios/agregar$',  usuarios.UsuarioCreate.as_view(), name='sistema_usuario_view'),
    url(r'^administracion/usuarios/editar/(?P<pk>\d+)/$',  usuarios.UsuarioUpdate.as_view(), name='sistema_usuario_edit'),
    url(r'^administracion/usuarios/borrar/(?P<pk>\d+)/$',  usuarios.UsuarioDelete.as_view(), name='sistema_usuario_delete'),

    url(r'^administracion/cambiar_usuario/$',  cuenta.CambiarUsuarioFormView.as_view(), name='sistema_cambiar_usuario'),
    url(r'^administracion/cambiar_clave/$',  cuenta.CambiarClaveFormView.as_view(), name='sistema_cambiar_clave'),
    url(r'^administracion/estadisticas/$',  estadisticas.EstadisticasView.as_view(), name='sistema_estadisticas'),

]