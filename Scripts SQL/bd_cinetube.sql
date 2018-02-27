--create database bd_cinetube

--use bd_cinetube

/*
create table administrador(
	id_admin int identity(1,1) not null,
	user_admin varchar(100),
	pass_admin varchar(100)
	constraint pk_administrador primary key(id_admin)
)

create table usuarios(
	id_usuario int identity(1,1) not null,
	usuario varchar(100),
	passw varchar(100)
	constraint pk_usuarios primary key(id_usuario)
)

create table sugerencias(
	id_sugerencia int identity(1,1) not null,
	nombre varchar(100),
	email	varchar(100),
	motivo varchar(100),
	tema varchar(100),
	mensaje varchar(200)
	constraint pk_sugerencia primary key(id_sugerencia)
)
*/

--insert into administrador(user_admin,pass_admin) values('supervisor','supervisor')