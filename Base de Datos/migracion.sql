USE [GD2C2016]
GO

CREATE SCHEMA [ESE_CU_ELE] AUTHORIZATION [gd]
GO

CREATE TABLE ESE_CU_ELE.Funcionalidad (func_codigo numeric(18,0) primary key IDENTITY(1,1), func_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Rol (rol_codigo numeric(18,0) primary key IDENTITY(1,1),rol_nombre varchar(255),rol_habilitado bit)

CREATE TABLE ESE_CU_ELE.RolXFuncionalidad (rolxf_func_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Funcionalidad(func_codigo), rolxf_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxf_func_codigo,rolxf_rol_codigo))

CREATE TABLE ESE_CU_ELE.Persona (pers_codigo numeric(18,0) primary key IDENTITY(1,1), pers_nombre varchar(255), pers_apellido varchar(255), pers_sexo varchar(255), pers_fecha_nacimiento datetime, pers_tipo_documento varchar(255),pers_numero_documento numeric(18,0), pers_mail varchar(255), pers_direccion varchar(255),pers_telefono numeric(18,0), pers_tipo varchar(255))

CREATE TABLE ESE_CU_ELE.Planes (plan_codigo numeric(18,0) primary key,plan_descripcion varchar(255), plan_bono_Consulta numeric(18,0), plan_bono_Farmacia numeric(18,0))

--FIJARSE SI LA PRIMARY KEY DE AFILIADO Y PROFESIONAL ES LA FOREIGN KEY DE PERSONA
CREATE TABLE ESE_CU_ELE.Afiliado (afil_codigo_persona numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo),afil_estado_civil varchar(255), afil_numero numeric(18,0), afil_numero_familiar numeric(18,0), afil_codigo_plan numeric(18,0) foreign key references ESE_CU_ELE.Planes(plan_codigo), primary key (afil_codigo_persona))

CREATE TABLE ESE_CU_ELE.Profesional (prof_codigo_persona numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), prof_codigo_matricula numeric(18,0), primary key (prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Usuario(usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), usua_username varchar(255), usua_contrasena binary(32), usua_intentos int, usua_habilitado bit,primary key(usua_codigo))

CREATE TABLE ESE_CU_ELE.RolXUsuario (rolxu_usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Usuario(usua_codigo), rolxu_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxu_usua_codigo,rolxu_rol_codigo) )

CREATE TABLE ESE_CU_ELE.Modificacion (modi_codigo numeric(18,0) primary key IDENTITY(1,1), modi_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), modi_fecha datetime,modi_motivo varchar(255), modi_plan_viejo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Planes(plan_codigo))

CREATE TABLE ESE_CU_ELE.Especialidad (espe_codigo numeric(18,0) primary key, espe_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.EspecialidadXProfesional (espexp_codigo_profesional numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Profesional(prof_codigo_persona), espexp_codigo_especialidad numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Especialidad(espe_codigo), primary key (espexp_codigo_profesional,espexp_codigo_especialidad))

CREATE TABLE ESE_CU_ELE.Agenda (agen_codigo numeric(18,0) IDENTITY(1,1), agen_profesional numeric(18,0) , agen_especialidad numeric (18,0), primary key (agen_codigo), FOREIGN KEY (agen_profesional, agen_especialidad) REFERENCES ESE_CU_ELE.EspecialidadXProfesional(espexp_codigo_profesional, espexp_codigo_especialidad))

--CREATE TABLE ESE_CU_ELE.Turno (turn_codigo numeric(18,0) primary key, turn_codigo_agenda numeric (18,0) foreign key references ESE_CU_ELE.Agenda(agen_codigo), turn_codigo_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), turn_hora datetime, turn_llegada datetime)
CREATE TABLE ESE_CU_ELE.Turno (turn_codigo numeric(18,0) primary key, turn_codigo_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), turn_hora datetime, turn_profesional numeric (18,0) foreign key references ESE_CU_ELE.Profesional(prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Cancelacion (canc_codigo_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo), tipo varchar(255), detalle varchar(255),primary key(canc_codigo_turno))

CREATE TABLE ESE_CU_ELE.Bono (bono_codigo numeric(18,0) primary key, bono_numero_consulta_medica numeric(18,0), bono_plan numeric(18,0),bono_fecha_compra datetime, bono_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona), bono_precio numeric(18,0))
--Ver como manejar consulta medica y cancelacion
CREATE TABLE ESE_CU_ELE.Consulta_Medica (cons_codigo_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo),cons_bono numeric(18,0) foreign key references ESE_CU_ELE.Bono(bono_codigo), cons_resultado varchar(255), cons_hora_llegada datetime, cons_sintomas varchar(255), cons_enfermedades varchar(255),primary key(cons_codigo_turno))

CREATE TABLE ESE_CU_ELE.Compra (comp_codigo numeric(18,0) primary key IDENTITY(1,1), comp_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona), comp_fecha datetime)

CREATE TABLE ESE_CU_ELE.Item (item_codigo numeric(18,0) primary key identity(1,1), item_compra numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Compra(comp_codigo), item_bono numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Bono(bono_codigo))




insert into ESE_CU_ELE.Planes (plan_codigo,plan_descripcion,plan_bono_Consulta,plan_bono_Farmacia) select distinct(Plan_Med_Codigo),Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia from gd_esquema.Maestra

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono,pers_tipo) select Paciente_Nombre, Paciente_Apellido, 'No Definido',Paciente_Fecha_Nac,'DNI',Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono,'Afiliado' from gd_esquema.Maestra where Paciente_Dni is not null group by Paciente_Nombre, Paciente_Apellido, Paciente_Fecha_Nac,Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono order by Paciente_Dni

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono,pers_tipo) select Medico_Nombre, Medico_Apellido, 'No Definido',Medico_Fecha_Nac,'DNI',Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono,'Medico' from gd_esquema.Maestra where Medico_Dni is not null group by Medico_Nombre, Medico_Apellido, Medico_Fecha_Nac,Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono order by Medico_Dni

--Se le asigna el numero de afiliado igual al codigo autoincremental
insert into ESE_CU_ELE.Afiliado (afil_codigo_persona, afil_estado_civil, afil_numero, afil_numero_familiar,afil_codigo_plan) select  pers_codigo,'No definido',pers_codigo,0,Plan_Med_Codigo from gd_esquema.Maestra, ESE_CU_ELE.Persona where Paciente_Dni=pers_numero_documento group by pers_codigo,pers_codigo,Plan_Med_Codigo
--Se le asigna el numero de matricula igual al codigo autoincremental
insert into ESE_CU_ELE.Profesional (prof_codigo_persona,prof_codigo_matricula) select pers_codigo,pers_codigo from gd_esquema.Maestra, ESE_CU_ELE.Persona where Medico_Dni = pers_numero_documento and Medico_Dni is not null group by pers_codigo,pers_codigo
--Se toma como fecha de compra de bono a Compra_Bono_Fecha
insert into ESE_CU_ELE.Bono (bono_codigo, bono_fecha_compra, bono_plan, bono_afiliado, bono_precio) select Bono_Consulta_Numero, Compra_Bono_Fecha, Plan_Med_Codigo, (select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento=m1.Paciente_Dni),(select plan_bono_Consulta from ESE_CU_ELE.Planes where plan_codigo=m1.Plan_Med_Codigo) from gd_esquema.Maestra "m1" where Bono_Consulta_Numero is not null and Compra_Bono_Fecha is not null group by Plan_Med_Codigo,Paciente_Dni, Bono_Consulta_Numero, Compra_Bono_Fecha

update ESE_CU_ELE.Bono set bono_numero_consulta_medica = Turno_Numero from ESE_CU_ELE.Bono INNER JOIN  gd_esquema.Maestra ON bono_codigo=Bono_Consulta_Numero where gd_esquema.Maestra.Turno_Numero is not null

insert into ESE_CU_ELE.Turno (turn_codigo,turn_hora,turn_codigo_afiliado, turn_profesional) select Turno_Numero, Turno_Fecha, (select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Paciente_Dni),(select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Medico_Dni) from gd_esquema.Maestra "m1" where Turno_Numero is not null group by Turno_Numero,Turno_Fecha, Paciente_Dni, Medico_Dni order by Turno_Numero
--Se toma como hora de llegada a Bono_Consulta_Fecha_Impresion
insert into ESE_CU_ELE.Consulta_Medica (cons_codigo_turno, cons_bono,cons_hora_llegada,cons_sintomas, cons_enfermedades) select Turno_Numero, Bono_Consulta_Numero, Bono_Consulta_Fecha_Impresion, Consulta_Sintomas, Consulta_Enfermedades from gd_esquema.Maestra  where Consulta_Sintomas is not null group by Turno_Numero, Bono_Consulta_Numero, Bono_Consulta_Fecha_Impresion, Consulta_Sintomas, Consulta_Enfermedades

insert into ESE_CU_ELE.Especialidad (espe_codigo, espe_descripcion) select Especialidad_Codigo,Especialidad_Descripcion from gd_esquema.Maestra where Especialidad_Codigo is not null group by Especialidad_Codigo,Especialidad_Descripcion order by Especialidad_Codigo

insert into ESE_CU_ELE.EspecialidadXProfesional (espexp_codigo_especialidad,espexp_codigo_profesional) select Especialidad_Codigo, (select pers_codigo from ESE_CU_ELE.Persona where m1.Medico_Dni=pers_numero_documento) from gd_esquema.Maestra "m1" where Especialidad_Codigo is not null group by Especialidad_Codigo, Medico_Dni
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
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (10,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (12,2)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (7,3)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (11,3)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (8,1)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (9,1)
insert into ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) values (11,1)

insert into ESE_CU_ELE.Compra (comp_afiliado,comp_fecha) select bono_afiliado,bono_fecha_compra from ESE_CU_ELE.Bono group by bono_afiliado,bono_fecha_compra order by bono_afiliado
insert into ESE_CU_ELE.Item (item_bono, item_compra) select bono_codigo,(select comp_codigo from ESE_CU_ELE.Compra where bono_fecha_compra=comp_fecha and bono_afiliado=comp_afiliado) from ESE_CU_ELE.Bono