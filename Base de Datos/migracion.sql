USE [GD2C2016]
GO

CREATE SCHEMA [ESE_CU_ELE] AUTHORIZATION [gd]
GO

CREATE TABLE ESE_CU_ELE.Funcionalidad (func_codigo numeric(18,0) primary key IDENTITY(1,1), func_descripcion varchar(255))

CREATE TABLE ESE_CU_ELE.Rol (rol_codigo numeric(18,0) primary key IDENTITY(1,1),rol_nombre varchar(255),rol_habilitado bit)

CREATE TABLE ESE_CU_ELE.RolXFuncionalidad (rolxf_func_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Funcionalidad(func_codigo), rolxf_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxf_func_codigo,rolxf_rol_codigo))

CREATE TABLE ESE_CU_ELE.Persona (pers_codigo numeric(18,0) primary key, pers_nombre varchar(255), pers_apellido varchar(255), pers_sexo varchar(255), pers_fecha_nac datetime, pers_tipo_documento varchar(255),pers_numero_documento numeric(18,0), pers_mail varchar(255), pers_direccion varchar(255),pers_telefono numeric(18,0))

CREATE TABLE ESE_CU_ELE.Planes (plan_codigo numeric(18,0) primary key,plan_descripcion varchar(255), plan_bono_Consulta numeric(18,0), plan_bono_Farmacia numeric(18,0))

--FIJARSE SI LA PRIMARY KEY DE AFILIADO Y PROFESIONA ES LA FOREIGN KEY DE PERSONA
CREATE TABLE ESE_CU_ELE.Afiliado (afil_codigo_persona numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo),afil_estado_civil varchar(255), afil_numero numeric(18,0), afil_numero_familiar numeric(18,0), afil_codigo_plan numeric(18,0) foreign key references ESE_CU_ELE.Planes(plan_codigo), primary key (afil_codigo_persona))

CREATE TABLE ESE_CU_ELE.Profesional (prof_codigo_persona numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), prof_codigo_matricula numeric(18,0), primary key (prof_codigo_persona))

CREATE TABLE ESE_CU_ELE.Usuario(usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Persona(pers_codigo), usua_username varchar(255), usua_contrasena nvarchar(255), usua_intentos int, usua_habilitado bit,primary key(usua_codigo))

CREATE TABLE ESE_CU_ELE.RolXUsuario (rolxu_usua_codigo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Usuario(usua_codigo), rolxu_rol_codigo numeric(18,0)FOREIGN KEY REFERENCES ESE_CU_ELE.Rol(rol_codigo), primary key(rolxu_usua_codigo,rolxu_rol_codigo) )

CREATE TABLE ESE_CU_ELE.Modificacion (modi_codigo numeric(18,0) primary key IDENTITY(1,1), modi_afiliado numeric(18,0), modi_fecha datetime,modi_motivo varchar(255), modi_plan_viejo numeric(18,0) FOREIGN KEY REFERENCES ESE_CU_ELE.Planes(plan_codigo))

insert into ESE_CU_ELE.Planes (plan_codigo,plan_descripcion,plan_bono_Consulta,plan_bono_Farmacia) select distinct(Plan_Med_Codigo),Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia from gd_esquema.Maestra



