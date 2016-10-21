USE [GD2C2016]
GO

CREATE SCHEMA [ESE_CU_ELE] AUTHORIZATION [gd]
GO

CREATE TABLE ESE_CU_ELE.Funcionalidad (codigo int primary key IDENTITY(1,1), descripcion char(40))

CREATE TABLE ESE_CU_ELE.Planes (codigo numeric(18,0) primary key,descripcion varchar(255), bono_Consulta numeric(18,0), bono_Farmacia numeric(18,0))

insert into ESE_CU_ELE.Planes (codigo,descripcion,bono_Consulta,bono_Farmacia) select distinct(Plan_Med_Codigo),Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia from gd_esquema.Maestra

