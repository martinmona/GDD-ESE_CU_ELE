use GD2C2016
go

create trigger triggerCargarAgendas on ESE_CU_ELE.Agenda instead of insert
as
begin
	declare @profesional numeric(18,0), @especialidad numeric(18,0), @dia tinyint, @horaInicio time(0), @horaFin time(0), @fechaFin date
	select @profesional=agen_profesional, @especialidad=agen_especialidad,@dia=agen_dia,@horaInicio=agen_hora_inicio, @horaFin=agen_hora_fin,@fechaFin=agen_fecha_fin from inserted

	if(((select sum(datediff(minute,agen_hora_inicio,agen_hora_fin)) from ESE_CU_ELE.Agenda where agen_profesional=@profesional and GETDATE()<agen_fecha_fin)+DATEDIFF(minute, @horaInicio,@horaFin))<2880)
	begin
		insert into ESE_CU_ELE.Agenda (agen_dia,agen_profesional,agen_especialidad,agen_hora_inicio,agen_hora_fin,agen_fecha_fin) values(@dia,@profesional,@especialidad,@horaInicio,@horaFin,@fechaFin)
	end
	else
	begin
		RAISERROR ( 'El profesional no puede sobrepasar las 48hs semanales', 16, 1) 
	end

end