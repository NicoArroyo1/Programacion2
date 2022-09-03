create proc sp_materias_carrera
@carrera int
as
begin
	select a.id_asignatura, a.nombre, d.anio_cursado, d.cuatrimestre
	from Asignaturas a
	join Detalle_Carreras d on d.id_asignatura = a.id_asignatura
	join Carreras c on c.id_carrera = d.id_carrera
	where c.id_carrera = @carrera
end

