# Written By Ismael Heredia in the year 2017

from django.db import models

# Create your models here.

class Proveedor(models.Model):
    nombre = models.CharField(max_length=150)
    direccion = models.TextField()
    telefono = models.IntegerField()
    fecha_registro = models.DateField(auto_now_add=True)

    def __str__(self):
        return self.nombre

class Producto(models.Model):
    nombre = models.CharField(max_length=150)
    descripcion = models.TextField()
    precio = models.FloatField()
    proveedor = models.ForeignKey(Proveedor)
    fecha_registro = models.DateField(auto_now_add=True)

    def __str__(self):
        return self.nombre

class TipoUsuario(models.Model):
    nombre = models.CharField(max_length=150)

    def __str__(self):
        return self.nombre

class Usuario(models.Model):
    nombre = models.CharField(max_length=150)
    clave = models.CharField(max_length=150)
    tipo = models.ForeignKey(TipoUsuario)
    fecha_registro = models.DateField(auto_now_add=True)

    def __str__(self):
        return self.nombre

class Login(models.Model):
    usuario = models.CharField(max_length=150)
    clave = models.CharField(max_length=150)

    class Meta:
        managed = False

    def __str__(self):
        return self.usuario

class Buscador(models.Model):
    nombre_buscar = models.CharField(max_length=150)

    class Meta:
        managed = False

    def __str__(self):
        return self.nombre_buscar

class CambiarUsuario(models.Model):
    nombre = models.CharField(max_length=150)
    nuevo_nombre = models.CharField(max_length=150)
    clave = models.CharField(max_length=150)

    class Meta:
        managed = False

    def __str__(self):
        return self.nombre

class CambiarClave(models.Model):
    nombre = models.CharField(max_length=150)
    clave = models.CharField(max_length=150)
    nueva_clave = models.CharField(max_length=150)

    class Meta:
        managed = False

    def __str__(self):
        return self.nombre