--create database bd_curso

--use bd_curso

/*
create table curso(
	id_curso int identity(1,1) not null,
	nombre_curso varchar(100)
	constraint pk_curso primary key(id_curso)
)

create table alumnos(
	id_alumno int identity(1,1) not null,
	nombre_alumno varchar(100),
	legajo int,
	notas varchar(100)
	constraint pk_alumnos primary key(id_alumno)
)
*/

select * from alumnos