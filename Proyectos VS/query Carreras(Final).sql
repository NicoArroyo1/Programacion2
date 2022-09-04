create database PII_U1_Ej1_Carrera
go
use PII_U1_Ej1_Carrera
go

create table Carreras(
id_carrera int identity(1,1),
nombre varchar(40),
constraint pk_carreras primary key (id_carrera)
)

create table Asignaturas(
id_asignatura int identity(1,1),
nombre varchar(50),
constraint pk_asignaturas primary key (id_asignatura)
)

create table Detalle_Carreras(
id_detalle_carrera int identity(1,1),
id_carrera int,
id_asignatura int,
anio_cursado int,
cuatrimestre int,
constraint pk_detalle_carreras primary key (id_detalle_carrera),
constraint fk_carreras foreign key (id_carrera)
	references Carreras (id_carrera),
constraint fk_asignaturas foreign key (id_asignatura)
	references Asignaturas (id_asignatura),
)

------------------------------------------------------------------------------------------------------------------
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
--------------------------------------------------------------------------------------------
insert into Carreras(nombre) values('Ingeniería Civil')
insert into Carreras(nombre) values('Ingeniería Eléctrica')
insert into Carreras(nombre) values('Ingeniería Electrónica')
insert into Carreras(nombre) values('Ingeniería Industrial')
insert into Carreras(nombre) values('Ingeniería Mecánica')
insert into Carreras(nombre) values('Ingeniería Naval')
insert into Carreras(nombre) values('Ingeniería Química')
insert into Carreras(nombre) values('Ingeniería en Sistemas de Información')
insert into Carreras(nombre) values('Ingeniería Textil')
----
----------------------------------------------------------------------------------------

insert into Detalle_Carreras(id_carrera,id_asignatura,anio_cursado,cuatrimestre)
values(1,1,1,1)

/*
select c.id_carrera 'Cod. Carrera', c.nombre 'Carrera', a.nombre 'Materia', d.anio_cursado 'Año', d.cuatrimestre 'Cuatrimestre'
from Carreras c
join Detalle_Carreras d on d.id_carrera = c.id_carrera
join Asignaturas a on a.id_asignatura = d.id_asignatura
*/

--PROCEDIMIENTOS ALMACENADOS-----------------------------------------------------------------------------

create proc sp_asignaturas
as
select id_asignatura Codigo, nombre Materia from Asignaturas
----------------------------------------------------------------------------------------------------------
create proc sp_carreras
as
select * from Carreras
----------------------------------------------------------------------------------------------------------
create proc sp_materias_carrera
@carrera int
as
begin
	select c.nombre Carrera,a.id_asignatura 'Cod. Materia', a.nombre Materia, d.anio_cursado Año, d.cuatrimestre Cuatrimestre
	from Asignaturas a
	join Detalle_Carreras d on d.id_asignatura = a.id_asignatura
	join Carreras c on c.id_carrera = d.id_carrera
	where c.id_carrera = @carrera
end
----------------------------------------------------------------------------------------------------------------------------
create proc sp_proximo_nro_carrera
@proximo int output
as
begin
	select @proximo = MAX(id_carrera)+1 from Carreras
end
------------------------------------------------------------------------------------------------------------------------------
create proc sp_insertar_carrera
@nombre varchar(50), @id_carrera int output
as
begin
	insert into Carreras(nombre) values(@nombre)
	select @id_carrera = MAX(id_carrera) from Carreras
end
-------------------------------------------------------------------------------------------------------------------------------
create proc sp_insertar_detalle
@carrera int, @asign int, @anio int, @cuat int
as
begin
	insert into Detalle_Carreras(id_carrera,id_asignatura,anio_cursado,cuatrimestre)
	values(@carrera,@asign,@anio,@cuat)
end
------------------------------------------------------------------------------------------------------------------------------