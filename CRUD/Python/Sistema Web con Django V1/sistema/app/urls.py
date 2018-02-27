# Written By Ismael Heredia in the year 2017

from django.conf.urls import include, url
from app.views import home,login,administracion,productos,proveedores,usuarios,cuenta,estadisticas

urlpatterns = [

    url(r'^$', home.sistema_home, name='sistema_home'),

    url(r'^login/$',  login.sistema_login, name='sistema_login'),
    url(r'^administracion/logout/$',  login.sistema_logout, name='sistema_logout'),

    url(r'^administracion/$',  administracion.sistema_administracion, name='sistema_administracion'),

    url(r'^administracion/productos/$',  productos.sistema_producto_list, name='sistema_producto_list'),
    url(r'^administracion/productos/agregar$',  productos.sistema_producto_view, name='sistema_producto_view'),
    url(r'^administracion/productos/editar/(?P<id_producto>\d+)/$',  productos.sistema_producto_edit, name='sistema_producto_edit'),
    url(r'^administracion/productos/borrar/(?P<id_producto>\d+)/$',  productos.sistema_producto_delete, name='sistema_producto_delete'),

    url(r'^administracion/proveedores/$',  proveedores.sistema_proveedor_list, name='sistema_proveedor_list'),
    url(r'^administracion/proveedores/agregar$',  proveedores.sistema_proveedor_view, name='sistema_proveedor_view'),
    url(r'^administracion/proveedores/editar/(?P<id_proveedor>\d+)/$',  proveedores.sistema_proveedor_edit, name='sistema_proveedor_edit'),
    url(r'^administracion/proveedores/borrar/(?P<id_proveedor>\d+)/$',  proveedores.sistema_proveedor_delete, name='sistema_proveedor_delete'),

    url(r'^administracion/usuarios/$',  usuarios.sistema_usuario_list, name='sistema_usuario_list'),
    url(r'^administracion/usuarios/agregar$',  usuarios.sistema_usuario_view, name='sistema_usuario_view'),
    url(r'^administracion/usuarios/editar/(?P<id_usuario>\d+)/$',  usuarios.sistema_usuario_edit, name='sistema_usuario_edit'),
    url(r'^administracion/usuarios/borrar/(?P<id_usuario>\d+)/$',  usuarios.sistema_usuario_delete, name='sistema_usuario_delete'),

    url(r'^administracion/cambiar_usuario/$',  cuenta.sistema_cambiar_usuario, name='sistema_cambiar_usuario'),
    url(r'^administracion/cambiar_clave/$',  cuenta.sistema_cambiar_clave, name='sistema_cambiar_clave'),
    url(r'^administracion/estadisticas/$',  estadisticas.sistema_estadisticas, name='sistema_estadisticas'),

]