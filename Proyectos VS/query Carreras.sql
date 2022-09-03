create database PII_U1_Ej1_Carrera
go
use PII_U1_Ej1_Carrera
go

create table Carreras(
id_carrera int identity(1,1),
nombre varchar(40),
titulo varchar(50),
constraint pk_carreras primary key (id_carrera)
)

create table Asignaturas(
id_asignatura int identity(1,1),
nombre varchar(50),
constraint pk_asignaturas primary key (id_asignatura)
)

create table Cuatrimestres(
id_cuatrimestre int identity(1,1),
descripcion varchar(15),
constraint pk_cuatrimestres primary key (id_cuatrimestre)
)

create table Detalle_Carreras(
id_detalle_carrera int identity(1,1),
id_carrera int,
anio_cursado date,
id_cuatrimestre int,
id_asignatura int,
constraint pk_detalle_carreras primary key (id_detalle_carrera),
constraint fk_carreras foreign key (id_carrera)
	references Carreras (id_carrera),
constraint fk_cuatrimestres foreign key (id_cuatrimestre)
	references Cuatrimestres (id_cuatrimestre),
constraint fk_asignaturas foreign key (id_asignatura)
	references Asignaturas (id_asignatura)
)

insert into Asignaturas (nombre) values (	'An�lisis Matem�tico I'	)
insert into Asignaturas (nombre) values (	'An�lisis Matem�tico I'	)
insert into Asignaturas (nombre) values (	'�lgebra y Geometr�a Anal�tica'	)
insert into Asignaturas (nombre) values (	'Matem�tica Discreta'	)
insert into Asignaturas (nombre) values (	'Sistemas y Organizaciones'	)
insert into Asignaturas (nombre) values (	'Algoritmo y Estructuras de Datos'	)
insert into Asignaturas (nombre) values (	'Arquitectura de Computadoras'	)
insert into Asignaturas (nombre) values (	'F�sica I'	)
insert into Asignaturas (nombre) values (	'Ingl�s I'	)
insert into Asignaturas (nombre) values (	'Qu�mica'	)
insert into Asignaturas (nombre) values (	'An�lisis Matem�tico II'	)
insert into Asignaturas (nombre) values (	'F�sica II'	)
insert into Asignaturas (nombre) values (	'An�lisis de Sistemas'	)
insert into Asignaturas (nombre) values (	'Sintaxis y Sem�ntica de los Lenguajes'	)
insert into Asignaturas (nombre) values (	'Paradigmas de Programaci�n'	)
insert into Asignaturas (nombre) values (	'Sistemas Operativos'	)
insert into Asignaturas (nombre) values (	'Sistemas de Representaci�n'	)
insert into Asignaturas (nombre) values (	'Probabilidades y Estad�sticas'	)
insert into Asignaturas (nombre) values (	'Dise�o de Sistemas'	)
insert into Asignaturas (nombre) values (	'Comunicaciones'	)
insert into Asignaturas (nombre) values (	'Matem�tica Superior' 	)
insert into Asignaturas (nombre) values (	'Gesti�n de Datos'	)
insert into Asignaturas (nombre) values (	'Ingenier�a y Sociedad'	)
insert into Asignaturas (nombre) values (	'Econom�a'	)
insert into Asignaturas (nombre) values (	'Ingl�s II'	)
insert into Asignaturas (nombre) values (	'Electivas'	)
