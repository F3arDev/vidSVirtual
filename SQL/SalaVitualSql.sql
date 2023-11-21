CREATE DATABASE dbSalasVirtuales;

USE dbSalasVirtuales;

--TABLA ESTADO SOLICITUD
CREATE TABLE EstadoSolicitud
(
	EstadoSolicitudID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(8) NOT NULL
);

--TABLA ESTADO DEL REGISTRO
CREATE TABLE EstadoRegistro
(
	EstadoRegistroID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(32) NOT NULL
);

--Simular Gaia
CREATE TABLE UsuarioRol
(
	UsuarioRolID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(64) NOT NULL
);

CREATE TABLE Usuario
(
	UsuarioID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre varchar(64) NOT NULL,
	UsuarioRolID int NOT NULL,
	CONSTRAINT FK_USUARIOROLID FOREIGN KEY (UsuarioRolID) REFERENCES UsuarioRol(UsuarioRolID)
);

CREATE TABLE RolesRutas
(
	RutaID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UsuarioRolID int,
	NombreRuta varchar(255),
	-- Ajusta el tamaño según tus necesidades

	-- Agrega la clave foránea para la relación con UsuarioRol
	FOREIGN KEY (UsuarioRolID) REFERENCES UsuarioRol(UsuarioRolID)
);

--Simular VwDepMunicipio PJN
CREATE TABLE Entidad
(
	EntidadID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(64) NOT NULL
);

CREATE TABLE VwDepMunicipio
(
	VwDepMunicipioID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Departamento varchar(64) NOT NULL,
	Municipio varchar(64) NOT NULL,
	EntidadID int NOT NULL,
	CONSTRAINT FK_ENTIDADID FOREIGN KEY (EntidadID) REFERENCES Entidad(EntidadID)
);

--db SalaViirtuales
CREATE TABLE Solicitud
(
	SolicitudID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SolicitanteID int NOT NULL,
	FechaRegistro date NOT NULL,
	--Regitra la fecha de Creacion del Registro
	--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
	FechaInicio date NOT NULL,
	FechaFin date NOT NULL,
	HoraInicio Time(0) NOT NULL,
	HoraFin Time(0) NOT NULL,
	VwDepMunicipioID int NOT NULL,
	Expediente varchar(128) NOT NULL,
	Actividad varchar(256) NOT NULL,
	UrlSesion varchar(256) NOT NULL DEFAULT 'Sin Generar',
	Motivo varchar(256) NOT NULL DEFAULT 'Sin Motivo',

	EstadoSolicitudID int NOT NULL DEFAULT 1,
	--Estado de la Solicitud
	EstadoRegistroID INT NOT NULL DEFAULT 1,
	--Estado del Registro

	CONSTRAINT FK_SOLICITANTEID FOREIGN KEY (SolicitanteID) REFERENCES Usuario(UsuarioID),
	CONSTRAINT FK_VWDEPMUNICIPIOID FOREIGN KEY (VwDepMunicipioID) REFERENCES VwDepMunicipio(VwDepMunicipioID),
	CONSTRAINT FK_ESTADOSOLICITUDID FOREIGN KEY (EstadoSolicitudID) REFERENCES EstadoSolicitud(EstadoSolicitudID),
	CONSTRAINT FK_ESTADOREGISTROID FOREIGN KEY (EstadoRegistroID) REFERENCES EstadoRegistro(EstadoRegistroID)
);

CREATE TABLE SolicitudHistorial
(
	SolicitudID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SolicitanteID int NOT NULL,
	FechaRegistro date NOT NULL,
	--Regitra la fecha de Creacion del Registro
	--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
	FechaInicio date NOT NULL,
	FechaFin date NOT NULL,
	HoraInicio Time(0) NOT NULL,
	HoraFin Time(0) NOT NULL,
	VwDepMunicipioID int NOT NULL,
	Expediente varchar(128) NOT NULL,
	Actividad varchar(256) NOT NULL,
	UrlSesion varchar(256) NOT NULL DEFAULT 'Sin Generar',
	Motivo varchar(256) NOT NULL DEFAULT 'Sin Motivo',

	EstadoSolicitudID int NOT NULL DEFAULT 1,
	--Estado de la Solicitud
	EstadoRegistroID INT NOT NULL DEFAULT 1,
	--Estado del Registro

	--Nuevos Campos
	FechaModificacion date,
	UsuarioModificaID int,
	CONSTRAINT FK_USUARIOMODIFICAID FOREIGN KEY (UsuarioModificaID) REFERENCES Usuario(UsuarioID)
);

INSERT INTO EstadoSolicitud
	(descripcion)
VALUES
	('PEN'),
	--Pendiente
	('APR'),
	--Aprobado
	('REC');
--Rechazado

INSERT INTO EstadoRegistro
	(descripcion)
VALUES
	('ACT'),
	--activo
	('DEB'),
	--de Baja
	('BOR');
--Borrado

INSERT INTO UsuarioRol
	(descripcion)
VALUES
	('APROBANTE'),
	('Solicitante');

INSERT INTO Usuario
	(Nombre, UsuarioRolID)
VALUES
	('Juan', 1),
	('Fredd', 2),
	('Moises', 1);

INSERT INTO Entidad
	(descripcion)
VALUES
	('CSJ');

INSERT INTO VwDepMunicipio
	(Departamento, Municipio, EntidadID)
VALUES
	('Managua', 'Managua', 1);

-- Insertar valor en la tabla Solicitud
INSERT INTO Solicitud
	(SolicitanteID, FechaRegistro, FechaInicio, FechaFin, HoraInicio, HoraFin, VwDepMunicipioID, Expediente, Actividad, Motivo)
VALUES
	(1, '2023-09-20', '2023-09-21', '2023-09-22', '08:00:00', '17:00:00', 1, 'Exp001', 'Reunion', 'Reunion de trabajo'),
	(2, '2023-09-21', '2023-09-23', '2023-09-24', '09:00:00', '18:00:00', 1, 'Exp002', 'Conferencia', 'Conferencia anual');

INSERT INTO RolesRutas
	(UsuarioRolID, NombreRuta)
VALUES
	(1, '/aprobante'),
	(1, '/aprobante/inicio'),
	(1, '/admin/dashboard')
	GO



select *
from EstadoSolicitud;
select *
from EstadoRegistro;
select *
from Usuario;
select *
from SolicitudHistorial;
select *
from VwDepMunicipio;
select *
from Entidad;


DELETE FROM Solicitud;
DBCC CHECKIDENT ('Solicitud', RESEED, 1);

UPDATE Solicitud	
SET 
    EstadoSolicitudID = 2
WHERE SolicitudID = 2;


CREATE VIEW VwSolicitudDetalles
AS
	SELECT
		s.SolicitudID,
		u.UsuarioID AS SolicitanteID,
		u.Nombre AS SolicitanteNombre,
		s.FechaRegistro,
		s.FechaInicio,
		s.FechaFin,
		s.HoraInicio,
		s.HoraFin,
		v.VwDepMunicipioID,
		v.Departamento,
		v.Municipio,
		e.EntidadID,
		e.descripcion AS Entidad,
		s.Expediente,
		s.Actividad,
		s.UrlSesion,
		s.Motivo,
		es.EstadoSolicitudID,
		es.descripcion AS EstadoSolicitud,
		er.EstadoRegistroID,
		er.descripcion AS EstadoRegistro
	FROM
		Solicitud s
		INNER JOIN Usuario u ON s.SolicitanteID = u.UsuarioID
		INNER JOIN VwDepMunicipio v ON s.VwDepMunicipioID = v.VwDepMunicipioID
		INNER JOIN Entidad e ON v.EntidadID = e.EntidadID
		INNER JOIN EstadoSolicitud es ON s.EstadoSolicitudID = es.EstadoSolicitudID
		INNER JOIN EstadoRegistro er ON s.EstadoRegistroID = er.EstadoRegistroID;


CREATE VIEW VwUsuarioDetalles
AS
	SELECT
		u.UsuarioID,
		u.Nombre,
		ur.UsuarioRolID AS RolId,
		ur.descripcion AS Rol
	FROM
		Usuario AS u
		INNER JOIN UsuarioRol AS ur ON u.UsuarioID = ur.UsuarioRolID
GO


CREATE TABLE GuardRutas
(
	RutaID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(50),
	_URL VARCHAR(255)
)


select *
from VwSolicitudDetalles;
select *
from VwUsuarioDetalles;

