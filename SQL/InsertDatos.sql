--Insert Datos

INSERT INTO
	EstadoSolicitud (Descripcion)
VALUES
	('Pendiente'),
	--Pendiente
	('Aprobado'),
	--Aprobado
	('Rechazado');
go

--Rechazado
INSERT INTO
	EstadoRegistro (Descripcion)
VALUES
	('Activo'),
	--activo
	('De Baja'),
	--de Baja
	('Borrado');
go

--Borrado
INSERT INTO
	UsuarioRol (descripcion)
VALUES
	('aprobante'),
	('solicitante');
go




INSERT INTO
	Entidad (descripcion)
VALUES
	('CSJ');
go

INSERT INTO
	Usuario (Nombre, UsuarioRolID, EntidadID, Departamento)
VALUES
	('Juan', 1,1,'Managua'),
	('Fredd', 2,1,'Managua'),
	('Moises', 1,1,'Managua');
go


-- Insertar valor en la tabla Solicitud
INSERT INTO	Solicitud (
		SolicitanteID,
		FechaRegistro,
		FechaInicio,
		FechaFin,
		HoraInicio,
		HoraFin,
		EntidadID,
		Expediente,
		Actividad,
		Motivo
	)
VALUES
	(
		1,
		'2023-09-20',
		'2023-09-21',
		'2023-09-22',
		'08:00:00',
		'17:00:00',
		1,
		'Exp001',
		'Reunion',
		'Reunion de trabajo'
	),
	(
		2,
		'2023-09-21',
		'2023-09-23',
		'2023-09-24',
		'09:00:00',
		'18:00:00',
		1,
		'Exp002',
		'Conferencia',
		'Conferencia anual'
	);
go

INSERT INTO
	RolesRutas (UsuarioRolID, NombreRuta)
VALUES
	(2, '/solicitante'),
	(2, '/solicitante/inicio'),
	(2, '/solicitante/solicitar'),
	(2, '/solicitante/registros'),
	(1, '/aprobante'),
	(1, '/aprobante/inicio'),
	(1, '/aprobante/solicitudes'),
	(1, '/aprobante/registros') 	
GO


