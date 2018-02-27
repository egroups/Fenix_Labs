# Written By Ismael Heredia in the year 2017

from django import forms

from app.models import Login,Buscador,Producto,Proveedor,Usuario,CambiarUsuario,CambiarClave

class LoginForm(forms.ModelForm):
    
    class Meta:

        model = Login
        
        fields=[
            'usuario',
            'clave',
        ]
        
        labels = {
            'usuario' : 'Usuario',
            'clave' : 'Clave',
        }

        widgets = {
            'usuario' : forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese usuario'}),
            'clave' : forms.PasswordInput(attrs={'class':'form-control','placeholder':'Ingrese clave'}),    
        }

class BuscadorForm(forms.ModelForm):
    
    class Meta:

        model = Buscador
        
        fields=[
            'nombre_buscar',
        ]
        
        labels = {
            'nombre_buscar' : 'Nombre',
        }

        widgets = {
            'nombre_buscar' : forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre a buscar'}), 
        }

    def __init__(self, *args, **kwargs):
        super(BuscadorForm, self).__init__(*args, **kwargs)
        self.fields['nombre_buscar'].required = False

class ProductoForm(forms.ModelForm):
    
    class Meta:
        
        model = Producto

        fields = [
            'nombre',
            'descripcion',
            'precio',
            'proveedor',
        ]

        labels = {
            'nombre':'Nombre',
            'descripcion':'Descripción',
            'precio':'Precio',
            'proveedor':'Proveedor',
        }

        widgets = {
            'nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre'}),
            'descripcion':forms.Textarea(attrs={'class':'form-control','rows':3,'placeholder':'Ingrese descripción'}),
            'precio':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese precio'}),
            'proveedor':forms.Select(attrs={'class':'form-control'}),        
        }

class ProveedorForm(forms.ModelForm):
    
    class Meta:
        
        model = Proveedor

        fields = [
            'nombre',
            'direccion',
            'telefono',
        ]

        labels = {
            'nombre':'Nombre',
            'direccion':'Dirección',
            'telefono':'Teléfono',
        }

        widgets = {
            'nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre'}),
            'direccion':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese dirección'}),
            'telefono':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese teléfono'}),       
        }

class UsuarioForm(forms.ModelForm):
    
    class Meta:
        
        model = Usuario

        fields = [
            'nombre',
            'clave',
            'tipo',
        ]

        labels = {
            'nombre':'Nombre',
            'clave':'Clave',
            'tipo':'Tipo',
        }

        widgets = {
            'nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre'}),
            'clave':forms.PasswordInput(attrs={'class':'form-control','placeholder':'Ingrese clave'}),
            'tipo':forms.Select(attrs={'class':'form-control'}),        
        }

class CambiarUsuarioForm(forms.ModelForm):
    
    class Meta:

        model = CambiarUsuario
        
        fields = [
            'nombre',
            'nuevo_nombre',
            'clave',
        ]

        labels = {
            'nombre':'Nombre',
            'nuevo_nombre':'Nuevo nombre',
            'clave':'Clave',
        }

        widgets = {   
            'nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre','readonly':'readonly'}),
            'nuevo_nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nuevo nombre'}),
            'clave':forms.PasswordInput(attrs={'class':'form-control','placeholder':'Ingrese clave'}),       
        }

class CambiarClaveForm(forms.ModelForm):
    
    class Meta:

        model = CambiarClave
        
        fields = [
            'nombre',
            'clave',
            'nueva_clave',
        ]

        labels = {
            'nombre':'Nombre',
            'clave':'Clave',
            'nueva_clave':'Nueva clave',
        }

        widgets = {   
            'nombre':forms.TextInput(attrs={'class':'form-control','placeholder':'Ingrese nombre','readonly':'readonly'}),
            'clave':forms.PasswordInput(attrs={'class':'form-control','placeholder':'Ingrese clave'}),
            'nueva_clave':forms.PasswordInput(attrs={'class':'form-control','placeholder':'Ingrese nueva clave'}),       
        }