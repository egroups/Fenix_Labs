--drop database personal

--create database personal;

use personal;

/*
create table profesiones(
	id int identity(1,1) not null,
	nombre nvarchar(100),
	constraint pk_profesiones primary key(id)
);

create table empleados(
	id int identity(1,1) not null,
	nombre nvarchar(100),
	direccion nvarchar(100),
	telefono int,
	sexo nvarchar(100),
	id_profesion int
	constraint pk_empleados primary key(id),
	constraint fk_empleados foreign key (id_profesion) references profesiones(id) 
);
*/

/*
insert into profesiones(nombre) values('Abogado');
insert into profesiones(nombre) values('M�dico');
insert into profesiones(nombre) values('Programador');
insert into profesiones(nombre) values('Dise�ador Web');
insert into profesiones(nombre) values('Arquitecto');

insert into empleados(nombre,direccion,telefono,sexo,id_profesion) 
	values('Ram�n Serrano','Catamarca 200','4526790','Masculino',1);

insert into empleados(nombre,direccion,telefono,sexo,id_profesion)
	values('Andr�s L�pez','Sevilla 140','4702561','Masculino',2);
	
insert into empleados(nombre,direccion,telefono,sexo,id_profesion)
	values('Enrique Vi�a','Villarreal 794','4729561','Masculino',3);
	
insert into empleados(nombre,direccion,telefono,sexo,id_profesion)
	values('Raquel S�nchez','Castell�n 401','4624187','Femenino',4);
	
insert into empleados(nombre,direccion,telefono,sexo,id_profesion) 
	values('Isabel Pacheco','Cartagena 320','4917305','Femenino',5);
*/