--create database Producciones

--use Producciones

/*
create table Responsable(
	codigo int not null,
	nombreResponsable nvarchar(50)
	constraint pk_Responsable primary key(codigo)
)

create table Componente(
	codComponente int not null,
	descComponente nvarchar(50)
	constraint pk_Componente primary key(codComponente)
)

create table Produccion(
	codigoProduccion int not null,
	codigoResponsable int,
	fecha nvarchar(12),
	codComponente int,
	cantidadProduccion int
	constraint pk_Produccion primary key(codigoProduccion),
	constraint fk_Responsable foreign key(codigoResponsable) references Responsable(codigo),
	constraint fk_Componente foreign key(codComponente) references Componente(codComponente)
)
*/
