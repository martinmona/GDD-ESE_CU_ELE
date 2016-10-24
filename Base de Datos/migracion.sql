USE [GD2C2016]
GO

CREATE SCHEMA [ESE_CU_ELE] AUTHORIZATION [gd]
GO

CREATE TABLE ESE_CU_ELE.Funcionalidad (func_codigo numeric(18,0) primary key IDENTITY(1,1), func_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Rol (rol_codigo numeric(18,0) primary key IDENTITY(1,1),rol_nombre varchar(255),rol_habilitado bit)

CREATE TABLE ESE_CU_ELE.RolXFuncionalidad (rolxf_func_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Funcionalidad(func_codigo), rolxf_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxf_func_codigo,rolxf_rol_codigo))

CREATE TABLE ESE_CU_ELE.Persona (pers_codigo numeric(18,0) primary key IDENTITY(1,1), pers_nombre varchar(255), pers_apellido varchar(255), pers_sexo varchar(255), pers_fecha_nacimiento datetime, pers_tipo_documento varchar(255),pers_numero_documento numeric(18,0), pers_mail varchar(255), pers_direccion varchar(255),pers_telefono numeric(18,0))

CREATE TABLE ESE_CU_ELE.Planes (plan_codigo numeric(18,0) primary key,plan_descripcion varchar(255), plan_bono_Consulta numeric(18,0), plan_bono_Farmacia numeric(18,0))

--FIJARSE SI LA PRIMARY KEY DE AFILIADO Y PROFESIONAL ES LA FOREIGN KEY DE PERSONA
CREATE TABLE ESE_CU_ELE.Afiliado (afil_codigo_persona numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo),afil_estado_civil varchar(255), afil_numero numeric(18,0), afil_numero_familiar numeric(18,0), afil_codigo_plan numeric(18,0) foreign key references ESE_CU_ELE.Planes(plan_codigo), primary key (afil_codigo_persona))

CREATE TABLE ESE_CU_ELE.Profesional (prof_codigo_persona numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), prof_codigo_matricula numeric(18,0), primary key (prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Usuario(usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), usua_username varchar(255), usua_contrasena nvarchar(255), usua_intentos int, usua_habilitado bit,primary key(usua_codigo))

CREATE TABLE ESE_CU_ELE.RolXUsuario (rolxu_usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Usuario(usua_codigo), rolxu_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxu_usua_codigo,rolxu_rol_codigo) )

CREATE TABLE ESE_CU_ELE.Modificacion (modi_codigo numeric(18,0) primary key IDENTITY(1,1), modi_afiliado numeric(18,0), modi_fecha datetime,modi_motivo varchar(255), modi_plan_viejo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Planes(plan_codigo))

CREATE TABLE ESE_CU_ELE.Especialidad (espe_codigo numeric(18,0) primary key, espe_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.EspecialidadXProfesional (espexp_codigo_profesional numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Profesional(prof_codigo_persona), espexp_codigo_especialidad numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Especialidad(espe_codigo), primary key (espexp_codigo_profesional,espexp_codigo_especialidad))

CREATE TABLE ESE_CU_ELE.Agenda (agen_codigo numeric(18,0) IDENTITY(1,1), agen_profesional numeric(18,0) , agen_especialidad numeric (18,0), primary key (agen_codigo), FOREIGN KEY (agen_profesional, agen_especialidad) REFERENCES ESE_CU_ELE.EspecialidadXProfesional(espexp_codigo_profesional, espexp_codigo_especialidad))

--CREATE TABLE ESE_CU_ELE.Turno (turn_codigo numeric(18,0) primary key, turn_codigo_agenda numeric (18,0) foreign key references ESE_CU_ELE.Agenda(agen_codigo), turn_codigo_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), turn_hora datetime, turn_llegada datetime)
CREATE TABLE ESE_CU_ELE.Turno (turn_codigo numeric(18,0) primary key, turn_codigo_afiliado numeric(18,0) foreign key references ESE_CU_ELE.Afiliado(afil_codigo_persona), turn_hora datetime, turn_profesional numeric (18,0) foreign key references ESE_CU_ELE.Profesional(prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Cancelacion (canc_codigo_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo), tipo varchar(255), detalle varchar(255),primary key(canc_codigo_turno))

CREATE TABLE ESE_CU_ELE.Bono (bono_codigo numeric(18,0) primary key, bono_numero_consulta_medica numeric(18,0), bono_plan numeric(18,0), bono_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona), bono_precio numeric(18,0))
--Ver como manejar consulta medica y cancelacion
CREATE TABLE ESE_CU_ELE.Consulta_Medica (cons_codigo_turno numeric(18,0) foreign key references ESE_CU_ELE.Turno(turn_codigo),cons_bono numeric(18,0) foreign key references ESE_CU_ELE.Bono(bono_codigo), cons_resultado varchar(255), cons_hora_llegada datetime, cons_sintomas varchar(255), cons_enfermedades varchar(255),primary key(cons_codigo_turno))

CREATE TABLE ESE_CU_ELE.Compra (comp_codigo numeric(18,0) primary key , comp_afiliado numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Afiliado(afil_codigo_persona))

CREATE TABLE ESE_CU_ELE.Item (item_codigo numeric(18,0) primary key identity(1,1), item_compra numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Compra(comp_codigo), item_bono numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Bono(bono_codigo))




insert into ESE_CU_ELE.Planes (plan_codigo,plan_descripcion,plan_bono_Consulta,plan_bono_Farmacia) select distinct(Plan_Med_Codigo),Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia from gd_esquema.Maestra

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono) select Paciente_Nombre, Paciente_Apellido, 'No Definido',Paciente_Fecha_Nac,'DNI',Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono from gd_esquema.Maestra group by Paciente_Nombre, Paciente_Apellido, Paciente_Fecha_Nac,Paciente_Dni,Paciente_Mail,Paciente_Direccion,Paciente_Telefono order by Paciente_Dni

insert into ESE_CU_ELE.Persona (pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono) select Medico_Nombre, Medico_Apellido, 'No Definido',Medico_Fecha_Nac,'DNI',Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono from gd_esquema.Maestra group by Medico_Nombre, Medico_Apellido, Medico_Fecha_Nac,Medico_Dni,Medico_Mail,Medico_Direccion,Medico_Telefono order by Medico_Dni
--Se le asigna el numero de afiliado igual al codigo autoincremental
insert into ESE_CU_ELE.Afiliado (afil_codigo_persona, afil_estado_civil, afil_numero, afil_numero_familiar) select  pers_codigo,'No definido',pers_codigo,0 from gd_esquema.Maestra, ESE_CU_ELE.Persona where Paciente_Dni=pers_numero_documento group by pers_codigo,pers_codigo
--Se le asigna el numero de matricula igual al codigo autoincremental
insert into ESE_CU_ELE.Profesional (prof_codigo_persona,prof_codigo_matricula) select pers_codigo,pers_codigo from gd_esquema.Maestra, ESE_CU_ELE.Persona where Medico_Dni = pers_numero_documento group by pers_codigo,pers_codigo

insert into ESE_CU_ELE.Turno (turn_codigo,turn_hora,turn_codigo_afiliado, turn_profesional) select Turno_Numero, Turno_Fecha, (select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Paciente_Dni),(select pers_codigo from ESE_CU_ELE.Persona where pers_numero_documento = m1.Medico_Dni) from gd_esquema.Maestra "m1" where Turno_Numero >0 group by Turno_Numero,Turno_Fecha, Paciente_Dni, Medico_Dni order by Turno_Numero
--Ver a quien corresponde cada consulta
insert into ESE_CU_ELE.Consulta_Medica (cons_sintomas, cons_enfermedades) select Consulta_Sintomas, Consulta_Enfermedades from gd_esquema.Maestra where Consulta_Sintomas is not null

insert into ESE_CU_ELE.Especialidad (espe_codigo, espe_descripcion) select Especialidad_Codigo,Especialidad_Descripcion from gd_esquema.Maestra where Especialidad_Codigo is not null group by Especialidad_Codigo,Especialidad_Descripcion order by Especialidad_Codigo

--Ver compra bono y fecha impresion. a quien corresponden
