--Insert Datos

INSERT INTO
	EstadoSolicitud (descripcion)
VALUES
	('PEN'),
	--Pendiente
	('APR'),
	--Aprobado
	('REC');
go

--Rechazado
INSERT INTO
	EstadoRegistro (descripcion)
VALUES
	('ACT'),
	--activo
	('DEB'),
	--de Baja
	('BOR');
	
go

--Borrado
INSERT INTO
	UsuarioRol (descripcion)
VALUES
	('aprobante'),
	('solicitante');
go

INSERT INTO
	Usuario (Nombre, UsuarioRolID)
VALUES
	('Juan', 1),
	('Fredd', 2),
	('Moises', 1);
go

INSERT INTO
	Entidad (descripcion)
VALUES
	('CSJ');
go

INSERT INTO
	VwDepMunicipio (Departamento, Municipio, EntidadID)
VALUES
	('Managua', 'Managua', 1);
go

-- Insertar valor en la tabla Solicitud
INSERT INTO
	Solicitud (
		SolicitanteID,
		FechaRegistro,
		FechaInicio,
		FechaFin,
		HoraInicio,
		HoraFin,
		VwDepMunicipioID,
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
	(2, '/solicitante/registros') 
	
GO
