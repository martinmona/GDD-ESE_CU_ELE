USE [GD2C2016]
GO

drop procedure ESE_CU_ELE.AsignarNroConsulta
drop procedure ESE_CU_ELE.SPAgregarBono
drop procedure ESE_CU_ELE.SPObtenerBonosSinUsar
drop procedure ESE_CU_ELE.SPRegistrarLlegada
drop procedure ESE_CU_ELE.SPRegistrarResultado
drop procedure ESE_CU_ELE.SPCancelarTurnoAfiliado
drop procedure ESE_CU_ELE.SPCancelarTurnoProfesional
drop procedure ESE_CU_ELE.AsignarFecha
drop procedure ESE_CU_ELE.SPObtenerAgendas
drop procedure ESE_CU_ELE.ListadoEspecialidadesBonos
drop procedure ESE_CU_ELE.ListadoAfiliadosBonos
drop procedure ESE_CU_ELE.ListadoProfesionalesMenosHoras
drop procedure ESE_CU_ELE.SPListadoProfesionalesPorPlan
drop procedure ESE_CU_ELE.SPListadoCancelaciones
drop FUNCTION ESE_CU_ELE.ObtenerFecha
drop FUNCTION ESE_CU_ELE.FechaMaxima
drop FUNCTION ESE_CU_ELE.FechaMinima



DROP TABLE ESE_CU_ELE.Item
DROP TABLE ESE_CU_ELE.Compra
DROP TABLE ESE_CU_ELE.Bono
DROP TABLE ESE_CU_ELE.Consulta_Medica

DROP TABLE ESE_CU_ELE.Fecha
DROP TABLE ESE_CU_ELE.Cancelacion
DROP TABLE ESE_CU_ELE.TipoCancelacion
DROP TABLE ESE_CU_ELE.Turno
DROP TABLE ESE_CU_ELE.Agenda
DROP TABLE ESE_CU_ELE.EspecialidadXProfesional
DROP TABLE ESE_CU_ELE.Especialidad
DROP TABLE ESE_CU_ELE.Modificacion
DROP TABLE ESE_CU_ELE.RolXUsuario
DROP TABLE ESE_CU_ELE.Usuario
DROP TABLE ESE_CU_ELE.Profesional
DROP TABLE ESE_CU_ELE.Afiliado
DROP TABLE ESE_CU_ELE.Planes
DROP TABLE ESE_CU_ELE.Persona
DROP TABLE ESE_CU_ELE.RolXFuncionalidad
DROP TABLE ESE_CU_ELE.Rol
DROP TABLE ESE_CU_ELE.Funcionalidad
DROP TABLE ESE_CU_ELE.TipoEspecialidad





DROP SCHEMA [ESE_CU_ELE]
