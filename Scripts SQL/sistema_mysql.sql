--create database sistema;

--use sistema;

/*
create table usuarios(
	id_usuario int not null auto_increment,
	usuario nvarchar(100),
	clave nvarchar(100),
	tipo int,
	fecha_registro nvarchar(100),
	primary key(id_usuario)
);

create table proveedores(
	id_proveedor int not null auto_increment,
	nombre_empresa nvarchar(100),
	direccion nvarchar(100),
	telefono int,
	fecha_registro_proveedor nvarchar(100),
	primary key(id_proveedor)
);

create table productos(
	id_producto int not null auto_increment,
	nombre_producto nvarchar(100),
	descripcion nvarchar(100),
	precio int,
	id_proveedor int,
	fecha_registro nvarchar(100),
	primary key(id_producto),
	foreign key (id_proveedor) references proveedores(id_proveedor) 
);
*/

/*
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
*/

-- MARIADB

create table usuarios(
	id_usuario int not null auto_increment,
	usuario varchar(100),
	clave varchar(100),
	tipo int,
	fecha_registro varchar(100),
	primary key(id_usuario)
);

create table proveedores(
	id_proveedor int not null auto_increment,
	nombre_empresa varchar(100),
	direccion varchar(100),
	telefono int,
	fecha_registro_proveedor varchar(100),
	primary key(id_proveedor)
);

create table productos(
	id_producto int not null auto_increment,
	nombre_producto varchar(100),
	descripcion varchar(100),
	precio int,
	id_proveedor int,
	fecha_registro varchar(100),
	primary key(id_producto),
	foreign key (id_proveedor) references proveedores(id_proveedor) 
);