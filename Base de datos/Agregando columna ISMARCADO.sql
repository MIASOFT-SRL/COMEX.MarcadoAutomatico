/*
	Gregagndo la columna ISMARCADO a la tabla USERINFO
	Nota.- Importante no dejar en null el nuevo campo creado,
	ponerle como valor por defecto false(0).
*/
alter table USERINFO add ISMARCADO bit null default 0
go
--Actualizando el campo ISMARCADO
update USERINFO set ISMARCADO = 0