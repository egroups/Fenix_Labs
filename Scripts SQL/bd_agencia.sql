--create database bd_agencia;

--use bd_agencia;

/*
create table clientes(
	id_cliente int identity(1,1) not null,
	nombre_empresa varchar(100),
	nombre_encargado varchar(100),
	telefono int,
	constraint pk_clientes primary key(id_cliente)
);

create table empleados(
	id_empleado int identity(1,1) not null,
	nombre_empleado varchar(100),
	fecha_nacimiento varchar(100),
	titulos varchar(200),
	experiencia varchar(200)
	constraint pk_empleados primary key(id_empleado)
);

create table puestos(
	id_puesto int identity(1,1) not null,
	nombre_puesto varchar(100),
	id_cliente int,
	cantidad_experiencia int,
	sueldo int,
	disponibilidad int
	constraint pk_puestos primary key(id_puesto),
	constraint fk_clientes foreign key(id_cliente) references clientes(id_cliente)
);

create table contratos(
	id_contrato int identity(1,1) not null,
	id_puesto int,
	id_empleado int,
	sueldo_real int,
	puntaje int
	constraint pk_contratos primary key(id_contrato),
	constraint fk_puestos foreign key(id_puesto) references puestos(id_puesto),
	constraint fk_empleados foreign key(id_empleado) references empleados(id_empleado)
);
*/

/*
insert into clientes(nombre_empresa,nombre_encargado,telefono) values('Fravega','Jose Hernandez','4375203');
insert into clientes(nombre_empresa,nombre_encargado,telefono) values('Telecom','Trinidad Ortega','4978530');
insert into clientes(nombre_empresa,nombre_encargado,telefono) values('Garbarino','Lucas Bustos','4631585');
insert into clientes(nombre_empresa,nombre_encargado,telefono) values('OCA','Consuelo Perez','4023675');
insert into clientes(nombre_empresa,nombre_encargado,telefono) values('Arcor','Arturo Fabre','4957502');

insert into empleados(nombre_empleado,fecha_nacimiento,titulos,experiencia) values('Luis Perez','6/7/1992','Operador de PC','3 años como freelance');
insert into empleados(nombre_empleado,fecha_nacimiento,titulos,experiencia) values('Manuel Palomar','2/2/1990','Analista en sistemas','Ninguna');
insert into empleados(nombre_empleado,fecha_nacimiento,titulos,experiencia) values('Paula Merino','4/3/1993','Programador','1 año como programador freelance');
insert into empleados(nombre_empleado,fecha_nacimiento,titulos,experiencia) values('Gerardo Ortiz','8/6/1990','Operador de grua','2 años en una construccion');
insert into empleados(nombre_empleado,fecha_nacimiento,titulos,experiencia) values('Isabel Pacheco','9/8/1991','Diseñador grafico','Ninguna');

insert into puestos(nombre_puesto,id_cliente,cantidad_experiencia,sueldo,disponibilidad) 
			values('Tecnico de PC',1,5,5000,1);
insert into puestos(nombre_puesto,id_cliente,cantidad_experiencia,sueldo,disponibilidad) 
			values('Programador',2,5,8000,1);
insert into puestos(nombre_puesto,id_cliente,cantidad_experiencia,sueldo,disponibilidad) 
			values('Diseñador grafico',3,5,7000,0);

insert into puestos(nombre_puesto,id_cliente,cantidad_experiencia,sueldo,disponibilidad) 
			values('Administrador de redes',4,5,9000,0);
insert into puestos(nombre_puesto,id_cliente,cantidad_experiencia,sueldo,disponibilidad) 
			values('Administrador de BD',5,8,6000,0);

insert into contratos(id_puesto,id_empleado,sueldo_real,puntaje) values(4,1,9000,80);
insert into contratos(id_puesto,id_empleado,sueldo_real,puntaje) values(5,2,12000,30);
insert into contratos(id_puesto,id_empleado,sueldo_real,puntaje) values(3,3,5000,90);
*/

--select sum(sueldo) from clientes c,puestos p where c.id_cliente=p.id_cliente and c.id_cliente='1' -- sueldo ofrecido
--select sum(sueldo_real) from puestos p,contratos c where p.id_puesto=c.id_puesto and id_cliente='4' -- sueldo real
-- select count(*) from clientes c,puestos p where c.id_cliente=p.id_cliente and c.id_cliente='1' -- cantidad de puestos
-- select avg(puntaje) from puestos p,contratos c where p.id_puesto=c.id_puesto and p.id_cliente='4' -- promedio 
--select e.id_empleado,sueldo,sueldo_real,sum(sueldo-sueldo_real) from empleados e,contratos c,puestos p where e.id_empleado=c.id_empleado and p.id_puesto=c.id_puesto group by e.id_empleado,sueldo,sueldo_real