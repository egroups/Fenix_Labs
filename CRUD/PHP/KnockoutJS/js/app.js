function AppViewModel() {

  var self = this;

  self.productos = ko.observableArray([]);
  self.nombre_buscar_producto = ko.observable('');

  self.proveedores = ko.observableArray([]);
  self.nombre_buscar_proveedor = ko.observable('');

  self.usuarios = ko.observableArray([]);
  self.nombre_buscar_usuario = ko.observable('');

  self.id_producto = ko.observable();
  self.nombre_producto = ko.observable();
  self.descripcion = ko.observable();
  self.precio = ko.observable();
  self.proveedor = ko.observable();

  self.id_proveedor = ko.observable(),
  self.nombre_empresa = ko.observable();
  self.direccion = ko.observable();
  self.telefono =  ko.observable(); 

  self.id_usuario = ko.observable(),
  self.usuario = ko.observable();
  self.clave = ko.observable();
  self.tipo =  ko.observable(); 
  self.nombre_tipo =  ko.observable(); 

  self.getUsername = function() {

    var usuario;
    
    $.ajax({
      type: 'POST',
      url: "includes/ABM.php",
      data: {'type' : 'getUsernameCookie'},
      dataType: 'json',
      async: false,
      success: function(result){idata = result;}
    });

    usuario = idata["message"];

    return usuario;

  };

  self.generarBienvenida = function() {

    var url = window.location.pathname;
    var filename = url.substring(url.lastIndexOf('/')+1);

      if(filename=="administracion.php") {

      var username = self.getUsername();

        var idata;
        $.ajax({
          type: 'POST',
          url: "includes/ABM.php",
          data: {'type' : 'checkTipoUsuario','username' : username},
          dataType: 'json',
          async: false,
          success: function(result){idata = result;}
        });

        var tipo_usuario = idata["message"];

        var contenido = "<h1><center>Bienvenido "+ tipo_usuario + " " + username + " a la administracion</center></h1>";

        return contenido;
    
    } 

  };

  self.nombre_usuario = self.getUsername();
  self.nuevo_usuario = ko.observable();
  self.actual_contraseña = ko.observable();
  self.nueva_contraseña = ko.observable();

  self.textoBienvenida = ko.observable(self.generarBienvenida());

  self.mostrarFormProductos = ko.observable(false);
  self.mostrarFormProveedores = ko.observable(false);
  self.mostrarFormUsuarios = ko.observable(false);
  self.mostrarFormCambiarUsuario = ko.observable(false);
  self.mostrarFormCambiarPassword = ko.observable(false);
  self.mostrarFormEstadisticas = ko.observable(false);
  self.mostrarBienvenida = ko.observable(true);

  var Producto = {
  	id: self.id,
  	nombre_producto : self.nombre_producto,
  	descripcion : self.descripcion,
  	precio : self.precio,
  	id_proveedor : self.id_proveedor
  };

  var Proveedor = {
  	id: self.id,
  	nombre_empresa : self.nombre_empresa,
  	direccion : self.direccion,
  	telefono : self.telefono
  };

  var Usuario = {
    id: self.id,
    usuario: self.usuario,
    clave: self.clave,
    tipo: self.tipo,
    nombre_tipo: self.nombre_tipo
  };  

  self.fecha_actual = function() {
  	var currentdate = new Date(); 	
  	var fecha = currentdate.getDate() + "/" + (currentdate.getMonth()+1) + "/" + currentdate.getFullYear();
  	return fecha;  	
  }

  self.listProductos = function() {

  	var idata;

    $.ajax({
     url: "includes/ABM.php",
	   data: {'type' : 'getProductos'},
	   dataType: 'json',
     cache: false,
     type: 'POST',
	   async: false,
     success: function (data) {
         idata = data;
     }
    });

    return idata;

  };

  self.listProveedores = function() {

  	var idata;

    $.ajax({
      url: "includes/ABM.php",
	   data: {'type' : 'getProveedores'},
	   dataType: 'json',
     cache: false,
     type: 'POST',
	   async: false,
      success: function (data) {
        idata = data;
      }
    });

    return idata;

  };

  self.listUsuarios = function() {

    var idata;

    $.ajax({
     url: "includes/ABM.php",
     data: {'type' : 'getUsuarios'},
     dataType: 'json',
     cache: false,
     type: 'POST',
     async: false,
     success: function (data) {
         idata = data;
     }
    });

    return idata;

  };

  self.IniciarSesion = function() {
    
    var username = Usuario.usuario;
    var password = Usuario.clave;

    var form_ready = true;

    if(username()==null) {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
      $("input[name='username']").focus();
      form_ready = false;  
    } else {
      $("div[name='form-group-username']").removeClass('has-error');
      $("div[name='form-group-username']").addClass('has-success');
      $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
    }
    
    if(password()==null) {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
      $("input[name='password']").focus();
      form_ready = false;  
    } else {
      $("div[name='form-group-password']").removeClass('has-error');
      $("div[name='form-group-password']").addClass('has-success');
      $("input[name='password']").attr("placeholder", "Ingrese password");
    }

    if(form_ready==true) {

      $("div[name='form-group-username']").removeClass('has-success');
      $("div[name='form-group-password']").removeClass('has-success');

      var idata;
      
      $.ajax({
        type: 'POST',
        url: "includes/ABM.php",
        data: {'type' : 'ingresoUsuario','username' : username(),'password' : password()},
        dataType: 'json',
        async: false,
        success: function(result){idata = result;}
      });

      var respuesta = idata["message"];

      if(respuesta=="1") {

        var idata2;
        $.ajax({
          type: 'POST',
          url: "includes/ABM.php",
          data: {'type' : 'checkTipoUsuario','username' : username()},
          dataType: 'json',
          async: false,
          success: function(result){idata2 = result;}
        });

        var tipo_usuario = idata2["message"];
        
        swal({
          title: "Iniciar sesion",
          text: "Bienvenido "+ tipo_usuario + " " + username() + " a la administracion",
          type:"success",
          html:true,
          animation: false
        },function() {
         window.location.href = "administracion.php";  
         });

      } else {

        swal({
          title: 'Iniciar sesion',
          text: "Login incorrecto",
          type:'warning',
          html:true,
          animation: false
        });

      }

        self.Usuario(null);

        self.limpiarDatosUsuario();

    }

  }

  self.CerrarSesion = function() {

    var idata;
    $.ajax({
      type: 'POST',
      url: "includes/ABM.php",
      data: {'type' : 'cerrarSesion'},
      dataType: 'json',
      async: false,
      success: function(result){idata = result;}
    });

    swal({
        title: "Cerrrar sesion",
        text: "Las cookies han sido borradas",
        type:"success",
        html:true,
        animation: false
     },function() {
      window.location.href = "index.php";  
     });

  }

  self.MostrarProductos = function() {
    self.mostrarFormProductos(true);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(false);
  }

  self.MostrarProveedores = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(true);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(false);
  }

  self.MostrarUsuarios = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(true);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(false);
  }

  self.MostrarCambiarUsuario = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(true);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(false);
  }

  self.MostrarCambiarPassword = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(true);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(false);
  }

  self.MostrarEstadisticas = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(true);
    self.mostrarBienvenida(false);
  }

  self.MostrarInicio = function() {
    self.mostrarFormProductos(false);
    self.mostrarFormProveedores(false);
    self.mostrarFormUsuarios(false);
    self.mostrarFormCambiarUsuario(false);
    self.mostrarFormCambiarPassword(false);
    self.mostrarFormEstadisticas(false);
    self.mostrarBienvenida(true);
  }

  self.refrescarListaProveedores = function() {

    self.Proveedores(self.listProveedores().data); 
  	self.buscador_proveedores("");

  }

  self.refrescarListaProductos = function() {

    self.Productos(self.listProductos().data); 
    self.buscador_productos("");

  }

  self.refrescarListaUsuarios = function() {

    self.Usuarios(self.listUsuarios().data); 
    self.buscador_usuarios("");

  }

  self.Producto = ko.observable();
  self.Productos = ko.observableArray();
  self.Proveedor = ko.observable();
  self.Proveedores = ko.observableArray();
  self.Usuario = ko.observable();
  self.Usuarios = ko.observableArray();

  self.Productos(self.listProductos().data); 
  self.Proveedores(self.listProveedores().data); 
  self.Usuarios(self.listUsuarios().data); 

  self.ProductosEncontrados = ko.observableArray();
  self.ProveedoresEncontrados = ko.observableArray();
  self.UsuariosEncontrados = ko.observableArray();

  self.buscador_productos = function(value) {

    self.ProductosEncontrados.removeAll();

    //if (value == '') return;

    for (var i = 0; i < self.Productos().length; i++) {
      if (self.Productos()[i]["nombre_producto"].toLowerCase().indexOf(value.toLowerCase()) >= 0) {
        self.ProductosEncontrados.push(self.Productos()[i]);
      }
    }

  };

  self.buscador_proveedores = function(value) {

    self.ProveedoresEncontrados.removeAll();

    //if (value == '') return;

    for (var i = 0; i < self.Proveedores().length; i++) {
      if (self.Proveedores()[i]["nombre_empresa"].toLowerCase().indexOf(value.toLowerCase()) >= 0) {
      	self.ProveedoresEncontrados.push(self.Proveedores()[i]);
      }
    }
  };

  self.buscador_usuarios = function(value) {

    self.UsuariosEncontrados.removeAll();

    //if (value == '') return;

    for (var i = 0; i < self.Usuarios().length; i++) {
      if (self.Usuarios()[i]["usuario"].toLowerCase().indexOf(value.toLowerCase()) >= 0) {
        self.UsuariosEncontrados.push(self.Usuarios()[i]);
      }
    }

  };

  self.limpiarDatosProducto = function () {
    self.id_producto("");
    self.nombre_producto("");
    self.descripcion("");
    self.precio("");
    self.id_proveedor("");
  }

  self.AgregarProducto = function() {
	  
    var nombre_producto_check = Producto.nombre_producto;
    var descripcion_check = Producto.descripcion;
    var precio_check = Producto.precio;
    var proveedor_check = Producto.id_proveedor;

    var form_ready = true;  

    if(nombre_producto_check()==null) {
      form_ready = false;
      $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
      $("div[name='form-group-nombre']").addClass('has-error');
      $("input[name='nombre_producto']").focus();
    } else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_producto']").attr("placeholder", "Ingrese nombre de producto");
    }

    if(descripcion_check()==null) {
      form_ready = false;
      $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
      $("div[name='form-group-descripcion']").addClass('has-error');
      $("textarea[name='descripcion']").focus(); 
    } else {
      $("div[name='form-group-descripcion']").removeClass('has-error');
      $("div[name='form-group-descripcion']").addClass('has-success');
      $("textarea[name='descripcion']").attr("placeholder", "Ingrese descripcion");
    } 

    if(precio_check()==null) {
      form_ready = false;
      $("input[name='precio']").attr("placeholder", "Falta precio");
      $("div[name='form-group-precio']").addClass('has-error');
      $("input[name='precio']").focus();  
    } else {
      $("div[name='form-group-precio']").removeClass('has-error');
      $("div[name='form-group-precio']").addClass('has-success');
      $("input[name='precio']").attr("placeholder", "Ingrese precio");
    } 

    if(proveedor_check()==null) {
      form_ready = false;
      $("div[name='form-group-proveedor']").addClass('has-error');
      $("select[name='proveedor']").focus();  
    } else {
      $("div[name='form-group-proveedor']").removeClass('has-error');
      $("div[name='form-group-proveedor']").addClass('has-success');
    }

    if(form_ready==true) {

      $("div[name='form-group-nombre']").addClass('has-success');
      $("div[name='form-group-descripcion']").addClass('has-success');
      $("div[name='form-group-precio']").addClass('has-success');
      $("div[name='form-group-proveedor']").addClass('has-success');

      $.post("includes/ABM.php",{type:"addProducto",nombre_producto:nombre_producto_check,descripcion:descripcion_check,precio:precio_check,proveedor:proveedor_check}, function(data) {
 
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Productos",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Productos",
            text: data.message,
            type: "warning" 
          });         
        }

        self.Producto(null);

        self.refrescarListaProductos();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-descripcion']").removeClass('has-success');
        $("div[name='form-group-precio']").removeClass('has-success');
        $("div[name='form-group-proveedor']").removeClass('has-success');

        self.limpiarDatosProducto();

      });
    }

  };

  self.editarProducto = function(Producto) {
  	  self.Producto(Producto);
  };

  self.CancelarEdicionProducto = function () {
    self.Producto(null);
  }

  self.borrarProducto = function(Producto) {
    swal({
      title: "Productos",
      text: "¿ Esta seguro de borrar el producto "+Producto.nombre_producto+" ?",
      type: "warning",
      showCancelButton: true,
      confirmButtonColor: "#DD6B55",
      confirmButtonText: "Borrar",
      cancelButtonText: "Cancelar",
      closeOnConfirm: false,
      closeOnCancel: false
    },
    function(isConfirm){
      if (isConfirm) {
        var id = Producto.id;
        $.post("includes/ABM.php",{type:"borrarProducto",id_producto:id}, function(data) {
          
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Productos",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Productos",
            text: data.message,
            type: "warning" 
          });         
        }

         self.refrescarListaProductos();

        });
      } else {
          swal("Productos", "Borrado cancelado", "error");
      }
    });
  };

  self.GrabarEdicionProducto = function() {

    var Producto = self.Producto();

    var nombre_producto_check = Producto.nombre_producto;
    var descripcion_check = Producto.descripcion;
    var precio_check = Producto.precio;
    var proveedor_check = Producto.id_proveedor;
    
    var form_ready = true;

    if(nombre_producto_check == "") {
      form_ready = false;
      $("input[name='nombre_producto']").attr("placeholder", "Falta nombre de producto");
      $("div[name='form-group-nombre']").addClass('has-error');
      $("input[name='nombre_producto']").focus();
    } else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_producto']").attr("placeholder", "Ingrese nombre de producto");
    }

    if(descripcion_check == "") {
      form_ready = false;
      $("textarea[name='descripcion']").attr("placeholder", "Falta la descripcion");
      $("div[name='form-group-descripcion']").addClass('has-error');
      $("textarea[name='descripcion']").focus(); 
    } else {
      $("div[name='form-group-descripcion']").removeClass('has-error');
      $("div[name='form-group-descripcion']").addClass('has-success');
      $("textarea[name='descripcion']").attr("placeholder", "Ingrese descripcion");
    } 

    if(precio_check == "") {
      form_ready = false;
      $("input[name='precio']").attr("placeholder", "Falta precio");
      $("div[name='form-group-precio']").addClass('has-error');
      $("input[name='precio']").focus();  
    } else {
      $("div[name='form-group-precio']").removeClass('has-error');
      $("div[name='form-group-precio']").addClass('has-success');
      $("input[name='precio']").attr("placeholder", "Ingrese precio");
    } 

    if(proveedor_check == "") {
      form_ready = false;
      $("div[name='form-group-proveedor']").addClass('has-error');
      $("select[name='proveedor']").focus();  
    } else {
      $("div[name='form-group-proveedor']").removeClass('has-error');
      $("div[name='form-group-proveedor']").addClass('has-success');
    }

    if(form_ready==true) {

      $("div[name='form-group-nombre']").addClass('has-success');
      $("div[name='form-group-descripcion']").addClass('has-success');
      $("div[name='form-group-precio']").addClass('has-success');
      $("div[name='form-group-proveedor']").addClass('has-success');

      $.post("includes/ABM.php",{type:"updateProducto",id_producto:Producto.id,nombre_producto:Producto.nombre_producto,descripcion:Producto.descripcion,precio:Producto.precio,proveedor:Producto.id_proveedor}, function(data) {
 
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Productos",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Productos",
            text: data.message,
            type: "warning" 
          });         
        }

        self.Producto(null);

        self.refrescarListaProductos();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-descripcion']").removeClass('has-success');
        $("div[name='form-group-precio']").removeClass('has-success');
        $("div[name='form-group-proveedor']").removeClass('has-success');

        self.limpiarDatosProducto();

      });

    }

  };

  self.limpiarDatosProveedor = function () {
    self.id_proveedor("");
    self.nombre_empresa("");
    self.direccion("");
    self.telefono("");
  }

  self.AgregarProveedor = function() {

  	var nombre_empresa_check = Proveedor.nombre_empresa;
  	var direccion_check = Proveedor.direccion;
  	var telefono_check = Proveedor.telefono;
  	var fecha_registro_check = self.fecha_actual();
  	
    var form_ready = true;

  	if(nombre_empresa_check()==null) {
      form_ready = false;
      $("div[name='form-group-nombre']").removeClass('has-success');    
  	  $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
  	  $("div[name='form-group-nombre']").addClass('has-error');
  	  $("input[name='nombre_empresa']").focus(); 
  	} else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_empresa']").attr("placeholder", "Ingrese nombre de empresa");
    }
  	if(direccion_check()==null) {
      form_ready = false;
      $("div[name='form-group-direccion']").removeClass('has-success');
  	  $("input[name='direccion']").attr("placeholder", "Falta direccion");
  	  $("div[name='form-group-direccion']").addClass('has-error');
  	  $("input[name='direccion']").focus();
  	} else {
      $("div[name='form-group-direccion']").removeClass('has-error');
      $("div[name='form-group-direccion']").addClass('has-success');
      $("input[name='direccion']").attr("placeholder", "Ingrese direccion");
    }
    if(telefono_check()==null) {
      form_ready = false;
      $("div[name='form-group-telefono']").removeClass('has-success');
  	  $("input[name='telefono']").attr("placeholder", "Falta telefono");
  	  $("div[name='form-group-telefono']").addClass('has-error');
  	  $("input[name='telefono']").focus();
  	} else {
      $("div[name='form-group-telefono']").removeClass('has-error');
      $("div[name='form-group-telefono']").addClass('has-success');
      $("input[name='telefono']").attr("placeholder", "Ingrese telefono");
    }

    if(form_ready==true) {

  	  $("div[name='form-group-nombre']").addClass('has-success');
  	  $("div[name='form-group-direccion']").addClass('has-success');
  	  $("div[name='form-group-telefono']").addClass('has-success');

      $.post("includes/ABM.php",{type:"addProveedor",nombre_empresa:nombre_empresa_check,direccion:direccion_check,telefono:telefono_check,fecha_registro:fecha_registro_check}, function(data) {
    		
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Proveedores",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Proveedores",
            text: data.message,
            type: "warning" 
          });         
        }

    		self.refrescarListaProveedores();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-direccion']").removeClass('has-success');
        $("div[name='form-group-telefono']").removeClass('has-success');

        self.limpiarDatosProveedor();

       });

    }

  };
  self.GrabarEdicionProveedor = function() {

  	var Proveedor = self.Proveedor();

    var nombre_empresa_check = Proveedor.nombre_empresa;
    var direccion_check = Proveedor.direccion;
    var telefono_check = Proveedor.telefono;
    
    var form_ready = true;

    if(nombre_empresa_check == "") {
      form_ready = false;
      $("div[name='form-group-nombre']").removeClass('has-success');    
      $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
      $("div[name='form-group-nombre']").addClass('has-error');
      $("input[name='nombre_empresa']").focus(); 
    } else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_empresa']").attr("placeholder", "Ingrese nombre de empresa");
    }
    if(direccion_check == "") {
      form_ready = false;
      $("div[name='form-group-direccion']").removeClass('has-success');
      $("input[name='direccion']").attr("placeholder", "Falta direccion");
      $("div[name='form-group-direccion']").addClass('has-error');
      $("input[name='direccion']").focus();
    } else {
      $("div[name='form-group-direccion']").removeClass('has-error');
      $("div[name='form-group-direccion']").addClass('has-success');
      $("input[name='direccion']").attr("placeholder", "Ingrese direccion");
    }
    if(telefono_check == "") {
      form_ready = false;
      $("div[name='form-group-telefono']").removeClass('has-success');
      $("input[name='telefono']").attr("placeholder", "Falta telefono");
      $("div[name='form-group-telefono']").addClass('has-error');
      $("input[name='telefono']").focus();
    } else {
      $("div[name='form-group-telefono']").removeClass('has-error');
      $("div[name='form-group-telefono']").addClass('has-success');
      $("input[name='telefono']").attr("placeholder", "Ingrese telefono");
    }

    if(form_ready==true) {

    	$.post("includes/ABM.php",{type:"updateProveedor",id_proveedor:Proveedor.id,nombre_empresa:Proveedor.nombre_empresa,direccion:Proveedor.direccion,telefono:Proveedor.telefono}, function(data) {

        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Proveedores",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Proveedores",
            text: data.message,
            type: "warning" 
          });         
        }

    		self.Proveedor(null);

        self.refrescarListaProveedores();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-direccion']").removeClass('has-success');
        $("div[name='form-group-telefono']").removeClass('has-success');

        self.limpiarDatosProveedor();

      });

    }

  };

  self.CancelarEdicionProveedor = function () {
    self.Proveedor(null);
  }

  self.editarProveedor = function(Proveedor) {
  	  self.Proveedor(Proveedor);
  };

  self.borrarProveedor = function(Proveedor) {
    swal({
      title: "Proveedores",
      text: "¿ Esta seguro de borrar el proveedor "+Proveedor.nombre_empresa+" ?",
      type: "warning",
      showCancelButton: true,
      confirmButtonColor: "#DD6B55",
      confirmButtonText: "Borrar",
      cancelButtonText: "Cancelar",
      closeOnConfirm: false,
      closeOnCancel: false
    },
    function(isConfirm){
      if (isConfirm) {
        var id = Proveedor.id;
        $.post("includes/ABM.php",{type:"borrarProveedor",id_proveedor:id}, function(data) {

        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Proveedores",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Proveedores",
            text: data.message,
            type: "warning" 
          });         
        }

         self.refrescarListaProveedores();

        }); 
      } else {
          swal("Proveedores", "Borrado cancelado", "error");
      }
    });
  };

  self.limpiarDatosUsuario = function () {
    self.id_usuario("");
    self.usuario("");
    self.clave("");
    self.tipo("");
  }

  self.AgregarUsuario = function() {

    var nombre_usuario_check = Usuario.usuario;
    var clave_check = Usuario.clave;
    var tipo_check = Usuario.tipo;
    var fecha_registro_check = self.fecha_actual();

    var form_ready = true;

    if(nombre_usuario_check()==null) {
      form_ready = false;
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
      $("input[name='nombre_usuario']").focus();
    } else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_usuario']").attr("placeholder", "Ingrese nombre de usuario");
    }

    if(clave_check()==null) {
      form_ready = false;
      $("textarea[name='password']").attr("placeholder", "Falta el password");
      $("div[name='form-group-password']").addClass('has-error');
      $("textarea[name='password']").focus(); 
    } else {
      $("div[name='form-group-password']").removeClass('has-error');
      $("div[name='form-group-password']").addClass('has-success');
      $("textarea[name='password']").attr("placeholder", "Ingrese password");
    } 

    if(tipo_check()==null) {
      form_ready = false;
      $("div[name='form-group-tipo']").addClass('has-error');
      $("select[name='tipo']").focus();  
    } else {
      $("div[name='form-group-tipo']").removeClass('has-error');
      $("div[name='form-group-tipo']").addClass('has-success');
    }

    if(form_ready==true) {

      $("div[name='form-group-nombre']").addClass('has-success');
      $("div[name='form-group-password']").addClass('has-success');
      $("div[name='form-group-tipo']").addClass('has-success');

      $.post("includes/ABM.php",{type:"addUsuario",nombre_usuario:nombre_usuario_check,password:clave_check,tipo:tipo_check,fecha_registro:fecha_registro_check}, function(data) {
 
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Usuarios",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Usuarios",
            text: data.message,
            type: "warning" 
          });         
        }

        self.Usuario(null);

        self.refrescarListaUsuarios();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-password']").removeClass('has-success');
        $("div[name='form-group-tipo']").removeClass('has-success');

        self.limpiarDatosUsuario();

      });
    }

  };

  self.CancelarEdicionUsuario = function () {
    self.Usuario(null);
  }

  self.editarUsuario = function(Usuario) {
      self.Usuario(Usuario);
  };

  self.GrabarEdicionUsuario = function() {

    var Usuario = self.Usuario();

    var nombre_usuario_check = Usuario.usuario;
    var clave_check = Usuario.clave;
    var tipo_check = Usuario.tipo;
    var fecha_registro_check = self.fecha_actual();

    var form_ready = true;

    if(nombre_usuario_check == "") {
      form_ready = false;
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
      $("input[name='nombre_usuario']").focus();
    } else {
      $("div[name='form-group-nombre']").removeClass('has-error');
      $("div[name='form-group-nombre']").addClass('has-success');
      $("input[name='nombre_usuario']").attr("placeholder", "Ingrese nombre de usuario");
    }

    if(clave_check == "") {
      form_ready = false;
      $("textarea[name='password']").attr("placeholder", "Falta el password");
      $("div[name='form-group-password']").addClass('has-error');
      $("textarea[name='password']").focus(); 
    } else {
      $("div[name='form-group-password']").removeClass('has-error');
      $("div[name='form-group-password']").addClass('has-success');
      $("textarea[name='password']").attr("placeholder", "Ingrese password");
    } 

    if(tipo_check == "") {
      form_ready = false;
      $("div[name='form-group-tipo']").addClass('has-error');
      $("select[name='tipo']").focus();  
    } else {
      $("div[name='form-group-tipo']").removeClass('has-error');
      $("div[name='form-group-tipo']").addClass('has-success');
    }

    if(form_ready==true) {

      $("div[name='form-group-nombre']").addClass('has-success');
      $("div[name='form-group-password']").addClass('has-success');
      $("div[name='form-group-tipo']").addClass('has-success');

      $.post("includes/ABM.php",{type:"updateUsuario",id_usuario:Usuario.id,tipo:Usuario.tipo}, function(data) {
 
        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Usuarios",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Usuarios",
            text: data.message,
            type: "warning" 
          });         
        }

        self.Usuario(null);

        self.refrescarListaUsuarios();

        $("div[name='form-group-nombre']").removeClass('has-success');
        $("div[name='form-group-password']").removeClass('has-success');
        $("div[name='form-group-tipo']").removeClass('has-success');

        self.limpiarDatosUsuario();

      });
    }

  };

  self.borrarUsuario = function(Usuario) {
    swal({
      title: "Usuarios",
      text: "¿ Esta seguro de borrar el usuario "+Usuario.usuario+" ?",
      type: "warning",
      showCancelButton: true,
      confirmButtonColor: "#DD6B55",
      confirmButtonText: "Borrar",
      cancelButtonText: "Cancelar",
      closeOnConfirm: false,
      closeOnCancel: false
    },
    function(isConfirm){
      if (isConfirm) {
        var id = Usuario.id;
        $.post("includes/ABM.php",{type:"borrarUsuario",id_usuario:id}, function(data) {

        var data = jQuery.parseJSON(data);

        if(data.success) {
          swal({ 
            title: "Usuarios",
            text: data.message,
            type: "success" 
          });
        } else {
           swal({ 
            title: "Usuarios",
            text: data.message,
            type: "warning" 
          });         
        }

        self.refrescarListaUsuarios();

        });  
      } else {
          swal("Usuarios", "Borrado cancelado", "error");
      }
    });
  };

  self.CambiarUsuario = function() {

    var nombre_usuario_check = self.nombre_usuario;
    var nuevo_usuario_check = self.nuevo_usuario;
    var actual_contraseña_check = self.actual_contraseña;

    var form_ready = true;

    if(nombre_usuario_check=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
      $("input[name='username']").focus();
      form_ready = false;
    } else {
      $("div[name='form-group-username']").removeClass('has-error');
      $("div[name='form-group-username']").addClass('has-success');
      $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
    }

    if(nuevo_usuario_check()==null) {
      $("input[name='new_username']").attr("placeholder", "Falta nuevo usuario");
      $("div[name='form-group-new-username']").addClass('has-error');
      $("input[name='new_username']").focus();
      form_ready = false;
    } else {
      $("div[name='form-group-new-username']").removeClass('has-error');
      $("div[name='form-group-new-username']").addClass('has-success'); 
      $("input[name='new_username']").attr("placeholder", "Ingrese nuevo usuario");
    }

    if(actual_contraseña_check()==null) {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").removeClass('has-success');  
      $("div[name='form-group-password']").addClass('has-error');
      $("input[name='password']").focus();
      form_ready = false;
    } else {
      $("div[name='form-group-password']").removeClass('has-error');
      $("div[name='form-group-password']").addClass('has-success'); 
      $("input[name='password']").attr("placeholder", "Ingrese password");
    }

    if(form_ready==true) {

      $("div[name='form-group-username']").addClass('has-success');
      $("div[name='form-group-new-username']").addClass('has-success');   
      $("div[name='form-group-password']").addClass('has-success');

      $.post("includes/ABM.php",{type:"changeUsername",username:nombre_usuario_check,new_username:nuevo_usuario_check(),password:actual_contraseña_check()}, function(data) {
      
        var data = jQuery.parseJSON(data);

        $("div[name='form-group-username']").removeClass('has-success');
        $("div[name='form-group-new-username']").removeClass('has-success');    
        $("div[name='form-group-password']").removeClass('has-success');

        self.nombre_usuario = "";
        self.nuevo_usuario = "";
        self.actual_contraseña = "";

        var idata;
        $.ajax({
          type: 'POST',
          url: "includes/ABM.php",
          data: {'type' : 'cerrarSesion'},
          dataType: 'json',
          async: false,
          success: function(result){idata = result;}
        });

        swal({
            title: "Cerrrar sesion",
            text: data.message,
            type:"success",
            html:true,
            animation: false
        },function() {
          window.location.href = "index.php";  
        });

      });

    }

  };

  self.CambiarPassword = function() {

    var nombre_usuario_check = self.nombre_usuario;
    var actual_contraseña_check = self.actual_contraseña;
    var nueva_contraseña_check = self.nueva_contraseña;

    var form_ready = true;

    if(nombre_usuario_check=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
      $("input[name='username']").focus();
      form_ready = false;
    } else {
        $("div[name='form-group-username']").removeClass('has-error');
        $("div[name='form-group-username']").addClass('has-success'); 
        $("input[name='username']").attr("placeholder", "Ingrese nombre de usuario");
    }
    
    if(actual_contraseña_check()==null) {
      $("input[name='anterior_password']").attr("placeholder", "Falta contraseña actual");
      $("div[name='form-group-anterior-password']").addClass('has-error');
      $("input[name='anterior_password']").focus();
      form_ready = false;  
    } else {
        $("div[name='form-group-anterior-password']").removeClass('has-error');
        $("div[name='form-group-anterior-password']").addClass('has-success');
        $("input[name='anterior_password']").attr("placeholder", "Ingrese contraseña actual");
    }
    
    if(nueva_contraseña_check()==null) {
      $("input[name='new_password']").attr("placeholder", "Falta nueva contraseña");
      $("div[name='form-group-new-password']").addClass('has-error');
      $("input[name='new-password']").focus();
      form_ready = false;
    } else {
        $("div[name='form-group-new-password']").removeClass('has-error');
        $("div[name='form-group-new-password']").addClass('has-success');
        $("input[name='new_password']").attr("placeholder", "Ingrese nueva contraseña");
    }

    if(form_ready==true) {

      $("div[name='form-group-username']").addClass('has-success'); 
      $("div[name='form-group-anterior-password']").addClass('has-success');
      $("div[name='form-group-new-password']").addClass('has-success');

      $.post("includes/ABM.php",{type:"changePassword",username:nombre_usuario_check,anterior_password:actual_contraseña_check(),new_password:nueva_contraseña_check()}, function(data) {

        var data = jQuery.parseJSON(data);

        $("div[name='form-group-username']").removeClass('has-success');  
        $("div[name='form-group-anterior-password']").removeClass('has-success');
        $("div[name='form-group-new-password']").removeClass('has-success');

        $("input[name='username']").val("");
        $("input[name='anterior_password']").val("");
        $("input[name='new-password']").val("");

          var idata;
          $.ajax({
            type: 'POST',
            url: "includes/ABM.php",
            data: {'type' : 'cerrarSesion'},
            dataType: 'json',
            async: false,
            success: function(result){idata = result;}
          });

        swal({
            title: "Cerrrar sesion",
            text: data.message,
            type:"success",
            html:true,
            animation: false
        },function() {
          window.location.href = "index.php";  
        });

      });

    }

  };

}

var viewModel = new AppViewModel();
viewModel.nombre_buscar_producto.subscribe(viewModel.buscador_productos);
viewModel.nombre_buscar_proveedor.subscribe(viewModel.buscador_proveedores);
viewModel.nombre_buscar_usuario.subscribe(viewModel.buscador_usuarios);
ko.applyBindings(viewModel);