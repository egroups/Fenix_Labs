create table usuarios(
	id_usuario integer primary key autoincrement,
	usuario nvarchar(100),
	clave nvarchar(100),
	tipo integer,
	fecha_registro nvarchar(100)
);

create table proveedores(
	id_proveedor integer primary key autoincrement,
	nombre_empresa nvarchar(100),
	direccion nvarchar(100),
	telefono integer,
	fecha_registro_proveedor nvarchar(100)
);

create table productos(
	id_producto integer primary key autoincrement,
	nombre_producto nvarchar(100),
	descripcion nvarchar(100),
	precio integer,
	id_proveedor integer,
	fecha_registro nvarchar(100),
	constraint fk_productos foreign key (id_proveedor) references proveedores(id_proveedor) 
);

insert into usuarios(usuario,clave,tipo,fecha_registro) 
	values('supervisor','09348c20a019be0318387c08df7a783d',1,'2016-04-02');

insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) 
	values('empresa 1','calle 1',4975034,'2016-04-02');

insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) 
	values('empresa 2','calle 2',4646891,'2016-03-06');

insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) 
	values('empresa 3','calle 3',4646891,'2016-08-21');



insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 1','descripcion 1',200,1,'2016-03-01');

insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 2','descripcion 2',400,2,'2016-01-06');

insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 3','descripcion 3',500,3,'2016-08-02');

insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 4','descripcion 4',250,2,'2016-04-20');

insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 5','descripcion 5',750,3,'2016-8-23');