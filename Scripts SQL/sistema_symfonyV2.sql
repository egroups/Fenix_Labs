--create database symfonyV2;

--use symfonyV2;

/*

create table tipos_usuarios(
	id int not null auto_increment,
	nombre varchar(100),
	primary key(id)
);

create table usuarios(
	id int not null auto_increment,
	nombre varchar(100),
	clave varchar(100),
	id_tipo int,
	fecha_registro varchar(100),
	primary key(id),
	foreign key (id_tipo) references tipos_usuarios(id)
);

create table proveedores(
	id int not null auto_increment,
	nombre varchar(100),
	direccion varchar(100),
	telefono int,
	fecha_registro varchar(100),
	primary key(id)
);

create table productos(
	id int not null auto_increment,
	nombre varchar(100),
	descripcion varchar(100),
	precio double,
	id_proveedor int,
	fecha_registro varchar(100),
	primary key(id),
	foreign key (id_proveedor) references proveedores(id) 
);
*/

/*

insert into tipos_usuarios(nombre) values('Administrador');
insert into tipos_usuarios(nombre) values('Usuario');

insert into usuarios(nombre,clave,id_tipo,fecha_registro) 
	values('supervisor','09348c20a019be0318387c08df7a783d',1,'2016-04-02');

insert into proveedores(nombre,direccion,telefono,fecha_registro) 
	values('empresa 1','calle 1',4975034,'2016-04-02');

insert into proveedores(nombre,direccion,telefono,fecha_registro) 
	values('empresa 2','calle 2',4646891,'2016-03-06');

insert into proveedores(nombre,direccion,telefono,fecha_registro) 
	values('empresa 3','calle 3',4646891,'2016-08-21');

insert into productos(nombre,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 1','descripci�n 1',200.20,1,'2016-03-01');

insert into productos(nombre,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 2','descripci�n 2',400,2,'2016-01-06');

insert into productos(nombre,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 3','descripci�n 3',500.55,3,'2016-08-02');

insert into productos(nombre,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 4','descripci�n 4',250,2,'2016-04-20');

insert into productos(nombre,descripcion,precio,id_proveedor,fecha_registro) 
	values('producto 5','descripci�n 5',750,3,'2016-8-23');
*/