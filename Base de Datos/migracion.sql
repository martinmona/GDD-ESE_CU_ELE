USE [GD2C2016]
GO

CREATE SCHEMA [ESE_CU_ELE] AUTHORIZATION [gd]
GO


--CREA LAS TABLAS

CREATE TABLE ESE_CU_ELE.Funcionalidad (func_codigo numeric(18,0) primary key IDENTITY(1,1), func_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Rol (rol_codigo numeric(18,0) primary key IDENTITY(1,1),rol_nombre varchar(255),rol_habilitado bit)

CREATE TABLE ESE_CU_ELE.RolXFuncionalidad (rolxf_func_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Funcionalidad(func_codigo), rolxf_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxf_func_codigo,rolxf_rol_codigo))

CREATE TABLE ESE_CU_ELE.Persona (pers_codigo numeric(18,0) primary key IDENTITY(1,1), pers_nombre varchar(255), pers_apellido varchar(255), pers_sexo varchar(255), pers_fecha_nacimiento datetime, pers_tipo_documento varchar(255),pers_numero_documento numeric(18,0), pers_mail varchar(255), pers_direccion varchar(255),pers_telefono numeric(18,0), pers_tipo varchar(255))

CREATE TABLE ESE_CU_ELE.Planes (plan_codigo numeric(18,0) primary key,plan_descripcion varchar(255), plan_bono_Consulta numeric(18,0), plan_bono_Farmacia numeric(18,0))

CREATE TABLE ESE_CU_ELE.Afiliado (afil_codigo_persona numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo),afil_estado_civil varchar(255), afil_numero numeric(18,0), afil_numero_familiar numeric(18,0), afil_codigo_plan numeric(18,0) foreign key references ESE_CU_ELE.Planes(plan_codigo), primary key (afil_codigo_persona))

CREATE TABLE ESE_CU_ELE.Profesional (prof_codigo_persona numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), prof_codigo_matricula numeric(18,0), primary key (prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Usuario(usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), usua_username varchar(255), usua_contrasena binary(32), usua_intentos int, usua_habilitado bit,usua_fecha_inhabilitado datetime, primary key(usua_codigo))

CREATE TABLE ESE_CU_ELE.RolXUsuario (rolxu_usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Usuario(usua_codigo), rolxu_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxu_usua_codigo,rolxu_rol_codigo) )

CREATE TABLE ESE_CU_ELE.Modificacion (modi_codigo numeric(18,0) primary key IDENTITY(1,1), modi_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), modi_fecha datetime,modi_motivo varchar(255), modi_plan_viejo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Planes(plan_codigo))

CREATE TABLE ESE_CU_ELE.TipoEspecialidad (tipo_codigo numeric(18,0) primary key, tipo_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Especialidad (espe_codigo numeric(18,0) primary key, espe_descripcion varchar(255), espe_tipo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.TipoEspecialidad (tipo_codigo))

CREATE TABLE ESE_CU_ELE.EspecialidadXProfesional (espexp_codigo_profesional numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Profesional(prof_codigo_persona), espexp_codigo_especialidad numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Especialidad(espe_codigo), primary key (espexp_codigo_profesional,espexp_codigo_especialidad))

CREATE TABLE ESE_CU_ELE.Agenda (agen_codigo numeric(18,0) IDENTITY(1,1), agen_profesional numeric(18,0) , agen_especialidad numeric (18,0),agen_dia tinyint, agen_hora_inicio time(0), agen_hora_fin time(0), agen_fecha_inicio date,agen_fecha_fin date, primary key (agen_codigo), FOREIGN KEY (agen_profesional, agen_especialidad) REFERENCES ESE_CU_ELE.EspecialidadXProfesional(espexp_codigo_profesional, espexp_codigo_especialidad))

--El estado del turno es Pedido, Cancelado, Esperando y Atendido
CREATE TABLE ESE_CU_ELE.Turno (turn_codigo numeric(18,0) primary key, turn_codigo_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona),turn_especialidad numeric(18,0), turn_fecha datetime, turn_profesional numeric (18,0),turn_estado varchar(20),FOREIGN KEY (turn_profesional,turn_especialidad) REFERENCES ESE_CU_ELE.EspecialidadXProfesional(espexp_codigo_profesional, espexp_codigo_especialidad))
--LOS TIPOS DE CANCELACION SON POR ENFERMEDAD, PERSONALES Y OTROS
CREATE TABLE ESE_CU_ELE.TipoCancelacion (tipoc_codigo numeric(18,0) primary key identity(1,1), tipoc_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Cancelacion (canc_codigo_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo), canc_tipo numeric(18,0) foreign key references ESE_CU_ELE.TipoCancelacion (tipoc_codigo), canc_detalle varchar(255),primary key(canc_codigo_turno))

CREATE TABLE ESE_CU_ELE.Consulta_Medica (cons_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo), cons_hora_llegada datetime, cons_sintomas varchar(255), cons_enfermedades varchar(255),primary key(cons_turno))

--El bono usado tiene un valor en numero de consulta medica y en turno
CREATE TABLE ESE_CU_ELE.Bono (bono_codigo numeric(18,0) primary key, bono_turno_consulta numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Consulta_Medica(cons_turno), bono_numero_consulta_medica numeric(18,0), bono_plan numeric(18,0),bono_fecha_compra datetime, bono_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona), bono_precio decimal(8,2))

CREATE TABLE ESE_CU_ELE.Compra (comp_codigo numeric(18,0) primary key IDENTITY(1,1), comp_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona), comp_fecha datetime, comp_total decimal(8,2))

CREATE TABLE ESE_CU_ELE.Item (item_codigo numeric(18,0) primary key identity(1,1), item_compra numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Compra(comp_codigo), item_bono numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Bono(bono_codigo))

go



--COMIENZA A MIGRAR LOS DATOS

insert into ESE_CU_ELE.Planes (plan_codigo,plan_descripcion,plan_bono_Consulta,plan_bono_Farmacia) select distinct(Plan_Med_Codigo),Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia from gd_esquema.Maestra

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono,pers_tipo) select Paciente_Nombre, Paciente_Apellido, 'No Definido',Paciente_Fecha_Nac,'DNI',Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono,'Afiliado' from gd_esquema.Maestra where Paciente_Dni is not null group by Paciente_Nombre, Paciente_Apellido, Paciente_Fecha_Nac,Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono order by Paciente_Dni

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono,pers_tipo) select Medico_Nombre, Medico_Apellido, 'No Definido',Medico_Fecha_Nac,'DNI',Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono,'Profesional' from gd_esquema.Maestra where Medico_Dni is not null group by Medico_Nombre, Medico_Apellido, Medico_Fecha_Nac,Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono order by Medico_Dni

--Se le asigna el numero de afiliado igual al codigo autoincremental
insert into ESE_CU_ELE.Afiliado (afil_codigo_persona, afil_estado_civil, afil_numero, afil_numero_familiar,afil_codigo_plan) select  pers_codigo,'No definido',pers_codigo,01,Plan_Med_Codigo from gd_esquema.Maestra, ESE_CU_ELE.Persona where Paciente_Dni=pers_numero_documento group by pers_codigo,pers_codigo,Plan_Med_Codigo
--Se le asigna el numero de matricula igual al codigo autoincremental
insert into ESE_CU_ELE.Profesional (prof_codigo_persona,prof_codigo_matricula) select pers_codigo,pers_codigo from gd_esquema.Maestra, ESE_CU_ELE.Persona where Medico_Dni = pers_numero_documento and Medico_Dni is not null group by pers_codigo,pers_codigo


insert into ESE_CU_ELE.TipoEspecialidad (tipo_codigo,tipo_descripcion) select Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion from gd_esquema.Maestra where Tipo_Especialidad_Codigo is not null group by Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion order by 1

insert into ESE_CU_ELE.Especialidad (espe_codigo, espe_descripcion, espe_tipo) select Especialidad_Codigo,Especialidad_Descripcion, Tipo_Especialidad_Codigo from gd_esquema.Maestra where Especialidad_Codigo is not null group by Especialidad_Codigo,Especialidad_Descripcion, Tipo_Especialidad_Codigo order by Especialidad_Codigo

insert into ESE_CU_ELE.EspecialidadXProfesional (espexp_codigo_especialidad,espexp_codigo_profesional) select Especialidad_Codigo, (select pers_codigo from ESE_CU_ELE.Persona where m1.Medico_Dni=pers_numero_documento) from gd_esquema.Maestra "m1" where Especialidad_Codigo is not null group by Especialidad_Codigo, Medico_Dni


--Se toma como fecha de compra de bono a Compra_Bono_Fecha
insert into ESE_CU_ELE.Bono (bono_codigo,bono_turno_consulta, bono_fecha_compra, bono_plan, bono_afiliado, bono_precio) select Bono_Consulta_Numero,Turno_Numero, Compra_Bono_Fecha, Plan_Med_Codigo, (select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento=m1.Paciente_Dni),(select plan_bono_Consulta from ESE_CU_ELE.Planes where plan_codigo=m1.Plan_Med_Codigo) from gd_esquema.Maestra "m1" where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null group by Plan_Med_Codigo,Paciente_Dni, Bono_Consulta_Numero, Compra_Bono_Fecha,Turno_Numero

insert into ESE_CU_ELE.Turno (turn_codigo,turn_fecha,turn_codigo_afiliado, turn_profesional, turn_especialidad, turn_estado) select Turno_Numero, Turno_Fecha, (select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Paciente_Dni),(select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Medico_Dni), Especialidad_Codigo, 'Pedido' from gd_esquema.Maestra "m1" where Turno_Numero is not null group by Turno_Numero,Turno_Fecha, Paciente_Dni, Medico_Dni,Especialidad_Codigo order by Turno_Numero

--Se toma como hora de llegada a Bono_Consulta_Fecha_Impresion
insert into ESE_CU_ELE.Consulta_Medica (cons_turno,cons_hora_llegada,cons_sintomas, cons_enfermedades) select Turno_Numero, Bono_Consulta_Fecha_Impresion, Consulta_Sintomas, Consulta_Enfermedades from gd_esquema.Maestra  where Consulta_Sintomas is not null group by Paciente_Dni,Turno_Numero, Bono_Consulta_Numero, Bono_Consulta_Fecha_Impresion, Consulta_Sintomas, Consulta_Enfermedades
--ACTUALIZA EL CAMPO TURNO PARA EL CUAL SE USO EL BONO
update ESE_CU_ELE.Bono set bono_turno_consulta = Turno_Numero from ESE_CU_ELE.Bono INNER JOIN  gd_esquema.Maestra ON bono_codigo=Bono_Consulta_Numero where gd_esquema.Maestra.Turno_Numero is not null

--ACTUALIZA EL ESTADO DE LOS TURNOS USADOS
update ESE_CU_ELE.Turno set turn_estado='Atendido' from ESE_CU_ELE.Consulta_Medica where cons_turno=turn_codigo



--El nombre de usuario y la contraseña son el nombre+codigo y apellido de la persona
insert into ESE_CU_ELE.Usuario (usua_codigo,usua_username,usua_contrasena,usua_habilitado,usua_intentos) select pers_codigo,CONCAT(pers_nombre,pers_codigo),HASHBYTES('SHA2_256', pers_apellido),1,0 from ESE_CU_ELE.Persona
insert into ESE_CU_ELE.Persona (pers_nombre,pers_tipo) values ('Admin','Admin')
insert into ESE_CU_ELE.Usuario(usua_codigo,usua_username,usua_contrasena,usua_habilitado,usua_intentos) values ((select pers_codigo from ESE_CU_ELE.Persona where pers_tipo='admin'),'admin',HASHBYTES('SHA2_256', 'w23e'),1,0)

--Creo los roles
insert into ESE_CU_ELE.Rol (rol_nombre, rol_habilitado) values('Afiliado',1)
insert into ESE_CU_ELE.Rol (rol_nombre, rol_habilitado) values('Administrativo',1)
insert into ESE_CU_ELE.Rol (rol_nombre, rol_habilitado) values('Profesional',1)

--Asigno roles a los usuarios
insert into ESE_CU_ELE.RolXUsuario (rolxu_rol_codigo,rolxu_usua_codigo) select 1,afil_codigo_persona from ESE_CU_ELE.Afiliado
insert into ESE_CU_ELE.RolXUsuario (rolxu_rol_codigo,rolxu_usua_codigo) select 3,prof_codigo_persona from ESE_CU_ELE.Profesional
insert into ESE_CU_ELE.RolXUsuario (rolxu_rol_codigo,rolxu_usua_codigo) values (2,(select pers_codigo from ESE_CU_ELE.Persona where pers_tipo='Admin'))

--Creo las funcionalidades
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('ABM de Rol')--Admin
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Registro de Usuario')--Admin *No implementar
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('ABM de Afiliados')--Admin 
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('ABM de Profesional')--Admin *No implementar
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('ABM de Especialidades Medicas')--Admin *No implementar
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('ABM de Plan')--Admin *No Implementar
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Registrar Agenda Profesional')--Admin y Profesional *No implementar
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Compra de Bonos')--Afiliado
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Pedir Turno')--Afiliado
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Regsitro de Llegada para Atencion Medica')--Admin
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Cancelar Atencion Medica')--Afiliado y Profesional
insert into ESE_CU_ELE.Funcionalidad (func_descripcion) values('Listado Estadistico')--Admin

--Asigno funcionalidades a los usuarios
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (1,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (2,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (3,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (4,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (5,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (6,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (7,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (8,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (10,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (12,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (7,3)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (11,3)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (8,1)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (9,1)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (11,1)


--Creo tipos de cancelaciones
insert into ESE_CU_ELE.TipoCancelacion (tipoc_descripcion) values ('Enfermedad')
insert into ESE_CU_ELE.TipoCancelacion (tipoc_descripcion) values ('Imprevisto Personal')
insert into ESE_CU_ELE.TipoCancelacion (tipoc_descripcion) values ('Otro')

insert into ESE_CU_ELE.Compra (comp_afiliado,comp_fecha,comp_total) select bono_afiliado,bono_fecha_compra,SUM(bono_precio) from ESE_CU_ELE.Bono group by bono_afiliado,bono_fecha_compra order by bono_afiliado
insert into ESE_CU_ELE.Item (item_bono, item_compra) select bono_codigo,(select comp_codigo from ESE_CU_ELE.Compra where bono_fecha_compra=comp_fecha and bono_afiliado=comp_afiliado) from ESE_CU_ELE.Bono

--Se toma por cada día y especialidad la hora mas temprana y mas tarde que atendio. La fecha fin se toma del ultimo turno asignado por ese profesional para esa especialidad
insert into ESE_CU_ELE.Agenda (agen_profesional,agen_especialidad, agen_dia, agen_hora_fin, agen_hora_inicio,agen_fecha_inicio, agen_fecha_fin) select t1.turn_profesional,t1.turn_especialidad, datepart(weekday, t1.turn_fecha), (select convert(time, MAX(t2.turn_fecha), 108) from ESE_CU_ELE.Turno t2 where datepart(weekday, t2.turn_fecha)=datepart(weekday, t1.turn_fecha)and t1.turn_especialidad=t2.turn_especialidad and t1.turn_profesional=t2.turn_profesional), (select convert(time, min(t3.turn_fecha), 108) from ESE_CU_ELE.Turno t3 where datepart(weekday, t3.turn_fecha)=datepart(weekday, t1.turn_fecha)and t1.turn_especialidad=t3.turn_especialidad and t1.turn_profesional=t3.turn_profesional),(select convert(date, min(t5.turn_fecha), 111) from ESE_CU_ELE.Turno t5 where t1.turn_especialidad=t5.turn_especialidad and t1.turn_profesional=t5.turn_profesional), (select convert(date, max(t4.turn_fecha), 111) from ESE_CU_ELE.Turno t4 where t1.turn_especialidad=t4.turn_especialidad and t1.turn_profesional=t4.turn_profesional) from ESE_CU_ELE.Turno t1  group by t1.turn_profesional,t1.turn_especialidad, datepart(weekday, t1.turn_fecha) order by 1,2,3


go

--TRIGGER QUE VERIFICA QUE EL PROFESIONAL NO SOBREPASE LAS 48hs SEMANALES

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
go

--TRIGGER PARA AGREGAR EN LA TABLA ITEM AL REALIZAR LA COMPRA

create trigger triggerCargarBono on ESE_CU_ELE.Bono instead of insert
as
begin
	declare @codigo numeric(18,0), @numeroConsultaMedica numeric(18,0), @plan numeric(18,0), @fechaCompra datetime, @afiliado numeric(18,0), @precio numeric(18,0)
	select @afiliado=bono_afiliado,@precio=bono_precio,@plan=bono_plan,@fechaCompra=bono_fecha_compra,@numeroConsultaMedica=bono_numero_consulta_medica from inserted

	select  top 1 @codigo=bono_codigo from ESE_CU_ELE.Bono order by bono_codigo desc
	set @codigo=@codigo+1
	insert into ESE_CU_ELE.Bono (bono_codigo,bono_afiliado,bono_fecha_compra,bono_numero_consulta_medica,bono_plan,bono_precio) values (@codigo,@afiliado,@fechaCompra,@numeroConsultaMedica,@plan,@precio)
	insert into ESE_CU_ELE.Item (item_bono,item_compra) values (@codigo,(select comp_codigo from ESE_CU_ELE.Compra where comp_fecha=@fechaCompra))
end
go


--STORED PROCEDURE QUE ASIGNA UN VALOR AL CAMPO NUMERO CONSULTA MEDICA PARA LOS BONOS CARGADOS EN LA MIGRACIÓN

create procedure ESE_CU_ELE.AsignarNroConsulta
as
Begin
	set nocount on
	declare @bono numeric(18,0)
	declare @afiliado numeric(18,0)
	declare @afiliado_estatico numeric(18,0)
	set @afiliado_estatico = 0
	declare @cantidadAcum numeric(18,0)
	set @cantidadAcum = 0
	declare unCursor cursor for select bono_codigo, bono_afiliado from ESE_CU_ELE.bono order by bono_afiliado, bono_codigo
	open unCursor
	fetch next from unCursor into @bono, @afiliado
	while @@FETCH_STATUS = 0
	Begin
		if(@afiliado_estatico <> @afiliado)
		Begin
			set @afiliado_estatico = @afiliado
			set @cantidadAcum = 0
		End
		set @cantidadAcum = @cantidadAcum + 1
		update ESE_CU_ELE.Bono set bono_numero_consulta_medica = @cantidadAcum where bono_codigo = @bono
		fetch next from unCursor into @bono, @afiliado
	End
	close unCursor
	deallocate unCursor
End
go

set nocount on;
exec ESE_CU_ELE.AsignarNroConsulta
go



--STORED PROCEDURE AGREGAR BONO

Create procedure ESE_CU_ELE.SPAgregarBono (@afiliado numeric(18,0),@plan numeric (18,0),@precio decimal(8,2),@fecha datetime)
as
begin
	declare @bono_id numeric(18,0)
	insert into ESE_CU_ELE.Bono (bono_afiliado,bono_plan,bono_precio,bono_fecha_compra) values(@afiliado,@plan,@precio,@fecha)
end
go

Create procedure ESE_CU_ELE.SPObtenerBonosSinUsar (@afiliado numeric(18,0),@plan numeric (18,0))
as
begin
	select bono_codigo,bono_fecha_compra,bono_precio from ESE_CU_ELE.Bono,ESE_CU_ELE.Afiliado where bono_numero_consulta_medica is null and afil_numero=@afiliado and bono_afiliado=afil_codigo_persona and bono_plan=@plan 
end
go


--STORED PROCEDURE REGISTRAR LLEGADA DE AFILIADO
create procedure ESE_CU_ELE.SPRegistrarLlegada(@afiliado numeric(18,0),@bono numeric(18,0),@turno numeric(18,0))
as
begin
	set nocount on;
	BEGIN TRANSACTION;
	BEGIN TRY
		update ESE_CU_ELE.Turno set turn_estado ='Esperando' where turn_codigo=@turno
		insert into ESE_CU_ELE.Consulta_Medica (cons_turno,cons_hora_llegada) values (@turno,getdate())
		update ESE_CU_ELE.Bono set bono_afiliado = @afiliado, bono_turno_consulta=@turno,bono_numero_consulta_medica=(select count(*) from ESE_CU_ELE.Bono where bono_afiliado=@afiliado and bono_numero_consulta_medica is not null)+1 where bono_codigo=@bono
    COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
	
    DECLARE @error int,
            @message varchar(4000);

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE();


      ROLLBACK TRANSACTION;

    RAISERROR ('Error al registrar llegada: %d: %s', 16, 1, @error, @message);
END CATCH;
end

go


--STORED PROCEDURE REGISTRAR RESULTADO DE LA ATENCION
create procedure ESE_CU_ELE.SPRegistrarResultado(@consulta numeric(18,0),@sintomas varchar(255),@enfermedades varchar(255),@fecha datetime)
as
begin
	set nocount on;
	BEGIN TRANSACTION;
	BEGIN TRY
		update ESE_CU_ELE.Turno set turn_estado ='Atendido' where turn_codigo=@consulta
		update ESE_CU_ELE.Consulta_Medica set cons_hora_llegada= @fecha, cons_sintomas=@sintomas,cons_enfermedades=@enfermedades where cons_turno = @consulta
		
    COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
	
    DECLARE @error int,
            @message varchar(4000);

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE();


      ROLLBACK TRANSACTION;

    RAISERROR ('Error al registrar llegada: %d: %s', 16, 1, @error, @message);
END CATCH;
end

go

--STORED PROCEDURE CANCELACION POR PARTE DE UN AFILIADO
create procedure ESE_CU_ELE.SPCancelarTurnoAfiliado(@turno numeric(18,0),@tipo numeric(18,0),@motivo varchar(255))
as
begin
	set nocount on;
	BEGIN TRANSACTION;
	BEGIN TRY
		update ESE_CU_ELE.Turno set turn_estado ='Cancelado' where turn_codigo=@turno
		insert into ESE_CU_ELE.Cancelacion (canc_codigo_turno,canc_tipo,canc_detalle) values (@turno,@tipo,@motivo) 
		
    COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
	
    DECLARE @error int,
            @message varchar(4000);

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE();


      ROLLBACK TRANSACTION;

    RAISERROR ('Error al registrar llegada: %d: %s', 16, 1, @error, @message);
END CATCH;
end

go

--STORED PROCEDURE CANCELACION POR PARTE DE UN PROFESIONAL
/*	SI LA AGENDA ESTÁ DENTRO DE LA FRANJA HORARIA SE ELIMINA.
	SI FINALIZA DENTRO DEL RANGO SE MODIFICA LA FECHA DE FINALIZACION
	SI INICIA DENTRO DEL RANGO SE MODIFICA LA FECHA DE INICIO
	SI LA FRANJA DE CANCELACION ESTA DENTRO DEL INICIO Y FIN DE AGENDA, SE MODIFICARÁ EL FIN DE LA AGENDA Y SE INSERTARÁ UNA NUEVA CON INICIO IGUAL AL FIN DE LA FRANJA

create procedure ESE_CU_ELE.SPCancelarTurnoProfesional(@profesional numeric(18,0), @fechaDesde datetime,@fechaHasta datetime,@tipo numeric(18,0),@motivo varchar(255))
as
begin
	set nocount on;
	BEGIN TRANSACTION;
	BEGIN TRY
		declare @turno numeric(18,0)
		declare unCursor cursor for select turn_codigo from ESE_CU_ELE.Turno where turn_profesional=@profesional and datepart(date,turn_fecha) >= @fechaDesde and datepart(date,turn_fecha) <=@fechaHasta
		open unCursor
		fetch next from unCursor into @turno
		while @@FETCH_STATUS = 0
		Begin
			update ESE_CU_ELE.Turno set turn_estado ='Cancelado' where turn_codigo=@turno
			insert into ESE_CU_ELE.Cancelacion (canc_codigo_turno,canc_tipo,canc_detalle) values (@turno,@tipo,@motivo) 	
		End
		close unCursor
		deallocate unCursor
		declare @agenda numeric(18,0)
		declare unCursor cursor for select agen_codigo from ESE_CU_ELE.Agenda where turn_profesional=@profesional and datepart(date,turn_fecha) >= @fechaDesde and datepart(date,turn_fecha) <=@fechaHasta
		open unCursor
		fetch next from unCursor into @turno
		while @@FETCH_STATUS = 0
		Begin
			update ESE_CU_ELE.Turno set turn_estado ='Cancelado' where turn_codigo=@turno
			insert into ESE_CU_ELE.Cancelacion (canc_codigo_turno,canc_tipo,canc_detalle) values (@turno,@tipo,@motivo) 	
		End
		close unCursor
		deallocate unCursor
		
    COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
	
    DECLARE @error int,
            @message varchar(4000);

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE();


      ROLLBACK TRANSACTION;

    RAISERROR ('Error al registrar llegada: %d: %s', 16, 1, @error, @message);
END CATCH;
end

go
*/