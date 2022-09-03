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

insert into Asignaturas (nombre) values (	'Análisis Matemático I'	)
insert into Asignaturas (nombre) values (	'Análisis Matemático I'	)
insert into Asignaturas (nombre) values (	'Álgebra y Geometría Analítica'	)
insert into Asignaturas (nombre) values (	'Matemática Discreta'	)
insert into Asignaturas (nombre) values (	'Sistemas y Organizaciones'	)
insert into Asignaturas (nombre) values (	'Algoritmo y Estructuras de Datos'	)
insert into Asignaturas (nombre) values (	'Arquitectura de Computadoras'	)
insert into Asignaturas (nombre) values (	'Física I'	)
insert into Asignaturas (nombre) values (	'Inglés I'	)
insert into Asignaturas (nombre) values (	'Química'	)
insert into Asignaturas (nombre) values (	'Análisis Matemático II'	)
insert into Asignaturas (nombre) values (	'Física II'	)
insert into Asignaturas (nombre) values (	'Análisis de Sistemas'	)
insert into Asignaturas (nombre) values (	'Sintaxis y Semántica de los Lenguajes'	)
insert into Asignaturas (nombre) values (	'Paradigmas de Programación'	)
insert into Asignaturas (nombre) values (	'Sistemas Operativos'	)
insert into Asignaturas (nombre) values (	'Sistemas de Representación'	)
insert into Asignaturas (nombre) values (	'Probabilidades y Estadísticas'	)
insert into Asignaturas (nombre) values (	'Diseño de Sistemas'	)
insert into Asignaturas (nombre) values (	'Comunicaciones'	)
insert into Asignaturas (nombre) values (	'Matemática Superior' 	)
insert into Asignaturas (nombre) values (	'Gestión de Datos'	)
insert into Asignaturas (nombre) values (	'Ingeniería y Sociedad'	)
insert into Asignaturas (nombre) values (	'Economía'	)
insert into Asignaturas (nombre) values (	'Inglés II'	)
insert into Asignaturas (nombre) values (	'Electivas'	)
