CREATE DATABASE dbSalasVirtuales;

USE dbSalasVirtuales;

--TABLA ESTADO SOLICITUD
CREATE TABLE EstadoSolicitud (
	EstadoSolicitudID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(8) NOT NULL
);

--TABLA ESTADO DEL REGISTRO
CREATE TABLE EstadoRegistro(
	EstadoRegistroID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(32) NOT NULL
)

--Simular Gaia
CREATE TABLE UsuarioRol(
	UsuarioRolID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(64) NOT NULL
)

CREATE TABLE Usuario(
	UsuarioID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre varchar(64) NOT NULL,
	UsuarioRolID int NOT NULL,
	CONSTRAINT FK_USUARIOROLID FOREIGN KEY (UsuarioRolID) REFERENCES UsuarioRol(UsuarioRolID)
)

--Simular VwDepMunicipio PJN
CREATE TABLE Entidad(
	EntidadID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(64) NOT NULL
)

CREATE TABLE VwDepMunicipio(
	VwDepMunicipioID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Departamento varchar(64) NOT NULL,
	Municipio varchar(64) NOT NULL,
	EntidadID int NOT NULL,
	CONSTRAINT FK_ENTIDADID FOREIGN KEY (EntidadID) REFERENCES Entidad(EntidadID)
)

--db SalaViirtuales
CREATE TABLE Solicitud (
	SolicitudID	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SolicitanteID int NOT NULL,
	FechaRegistro date NOT NULL, --Regitra la fecha de Creacion del Registro
	--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
	FechaInicio	date NOT NULL,
	FechaFin date NOT NULL,
	HoraInicio Time(0) NOT NULL,
	HoraFin	Time(0) NOT NULL,         
	VwDepMunicipioID int NOT NULL,
	Expediente varchar(128) NOT NULL,
	Actividad varchar(256) NOT NULL,
	UrlSesion varchar(256) NOT NULL DEFAULT 'Sin Generar',
	Motivo varchar(256)	NOT NULL DEFAULT 'Sin Motivo',

	EstadoSolicitudID int NOT NULL DEFAULT 1, --Estado de la Solicitud
	EstadoRegistroID INT NOT NULL DEFAULT 1, --Estado del Registro

	CONSTRAINT FK_SOLICITANTEID FOREIGN KEY (SolicitanteID) REFERENCES Usuario(UsuarioID),
	CONSTRAINT FK_VWDEPMUNICIPIOID FOREIGN KEY (VwDepMunicipioID) REFERENCES VwDepMunicipio(VwDepMunicipioID),
	CONSTRAINT FK_ESTADOSOLICITUDID FOREIGN KEY (EstadoSolicitudID) REFERENCES EstadoSolicitud(EstadoSolicitudID),
	CONSTRAINT FK_ESTADOREGISTROID FOREIGN KEY (EstadoRegistroID) REFERENCES EstadoRegistro(EstadoRegistroID)
);

CREATE TABLE SolicitudHistorial (
		SolicitudID	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
		SolicitanteID int NOT NULL,
		FechaRegistro date NOT NULL, --Regitra la fecha de Creacion del Registro
		--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
		FechaInicio	date NOT NULL,
		FechaFin date NOT NULL,
		HoraInicio Time(0) NOT NULL,
		HoraFin	Time(0) NOT NULL,         
		VwDepMunicipioID int NOT NULL,
		Expediente varchar(128) NOT NULL,
		Actividad varchar(256) NOT NULL,
		UrlSesion varchar(256) NOT NULL DEFAULT 'Sin Generar',
		Motivo varchar(256)	NOT NULL DEFAULT 'Sin Motivo',

		EstadoSolicitudID int NOT NULL DEFAULT 1, --Estado de la Solicitud
		EstadoRegistroID INT NOT NULL DEFAULT 1, --Estado del Registro

		--Nuevos Campos
		FechaModificacion date,
		UsuarioModificaID int,
		CONSTRAINT FK_USUARIOMODIFICAID FOREIGN KEY (UsuarioModificaID) REFERENCES Usuario(UsuarioID)
);

INSERT INTO EstadoSolicitud (descripcion) VALUES
	('PEN'), --Pendiente
	('APR'), --Aprobado
	('REC'); --Rechazado

INSERT INTO EstadoRegistro (descripcion) VALUES
	('ACTIVO'),
	('DE BAJA'),
	('BORRADO');

INSERT INTO UsuarioRol (descripcion) VALUES
	('APROBANTE'),
	('Solicitante');

INSERT INTO Usuario (Nombre, UsuarioRolID) VALUES
	('Juan', 1),
	('Fredd', 2),
	('Moises', 1);

INSERT INTO Entidad (descripcion) VALUES
	('CSJ');

INSERT INTO VwDepMunicipio (Departamento, Municipio, EntidadlID) VALUES
	('Managua', 'Managua', 1);

-- Insertar valor en la tabla Solicitud
INSERT INTO Solicitud (SolicitanteID, FechaRegistro, FechaInicio, FechaFin, HoraInicio, HoraFin, VwDepMunicipioID, Expediente, Actividad, UrlSesion, Motivo)
VALUES 
(1, '2023-09-20', '2023-09-21', '2023-09-22', '08:00', '17:00', 1, 'Exp001', 'Reunión', 'https://ejemplo.com/sesion1', 'Reunión de trabajo'),
(2, '2023-09-21', '2023-09-23', '2023-09-24', '09:00', '18:00', 1, 'Exp002', 'Conferencia', 'https://ejemplo.com/sesion2', 'Conferencia anual');


select * from EstadoSolicitud;
select * from EstadoRegistro;
select * from Solicitud;
select * from SolicitudHistorial;
select * from VwDepMunicipio;
select * from Entidad;