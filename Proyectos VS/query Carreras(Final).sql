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
--------------------------------------------------------------------------------------------
insert into Carreras(nombre) values('Ingenier�a Civil')
insert into Carreras(nombre) values('Ingenier�a El�ctrica')
insert into Carreras(nombre) values('Ingenier�a Electr�nica')
insert into Carreras(nombre) values('Ingenier�a Industrial')
insert into Carreras(nombre) values('Ingenier�a Mec�nica')
insert into Carreras(nombre) values('Ingenier�a Naval')
insert into Carreras(nombre) values('Ingenier�a Qu�mica')
insert into Carreras(nombre) values('Ingenier�a en Sistemas de Informaci�n')
insert into Carreras(nombre) values('Ingenier�a Textil')
----
----------------------------------------------------------------------------------------

insert into Detalle_Carreras(id_carrera,id_asignatura,anio_cursado,cuatrimestre)
values(1,1,1,1)

/*
select c.id_carrera 'Cod. Carrera', c.nombre 'Carrera', a.nombre 'Materia', d.anio_cursado 'A�o', d.cuatrimestre 'Cuatrimestre'
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
	select c.nombre Carrera,a.id_asignatura 'Cod. Materia', a.nombre Materia, d.anio_cursado A�o, d.cuatrimestre Cuatrimestre
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