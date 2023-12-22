CREATE DATABASE dbSalasVirtuales;
go

USE dbSalasVirtuales;
go
--TABLA ESTADO SOLICITUD
BEGIN TRY
CREATE TABLE EstadoSolicitud (
	EstadoSolicitudID int identity(1, 1) NOT NULL,
	Descripcion varchar(16) NOT NULL,
	primary key (EstadoSolicitudID)
)
END TRY
BEGIN CATCH
    -- Captura la excepción y muestra un mensaje de error
    PRINT 'Error al crear la tabla: ' + ERROR_MESSAGE();
END CATCH;
go



--TABLA ESTADO DEL REGISTRO
CREATE TABLE EstadoRegistro (
	EstadoRegistroID int identity (1, 1) NOT NULL,
	Descripcion varchar(32) NOT NULL,
	primary key (EstadoRegistroID)
);
go

--Simular Gaia
CREATE TABLE UsuarioRol (
	UsuarioRolID int IDENTITY (1, 1) NOT NULL,
	Descripcion varchar(64) NOT NULL,
	primary key (UsuarioRolID)
);
go

--Entidad
CREATE TABLE Entidad (
	EntidadID int IDENTITY (1, 1) NOT NULL,
	Descripcion varchar(64) NOT NULL,
	primary key (EntidadID),
);
go

CREATE TABLE RolesRutas (
	RutaID int IDENTITY (1, 1) NOT NULL,
	UsuarioRolID int,
	NombreRuta varchar(255),
	primary key (RutaID),
	FOREIGN KEY (UsuarioRolID) REFERENCES UsuarioRol (UsuarioRolID)
);
go

CREATE TABLE Usuario (
	UsuarioID int IDENTITY (1, 1) NOT NULL,
	Nombre varchar(64) NOT NULL,
	UsuarioRolID int NOT NULL,
	EntidadID int,
	primary key (UsuarioID),
	FOREIGN KEY (UsuarioRolID) REFERENCES UsuarioRol (UsuarioRolID),
	FOREIGN KEY (EntidadID) REFERENCES Entidad (EntidadID)
);
go

CREATE TABLE Solicitud (
		SolicitudID int IDENTITY (1, 1) NOT NULL,
		SolicitanteID int NOT NULL,
		FechaRegistro date NOT NULL DEFAULT CONVERT(date, GETDATE()),--Agregar por defecto la fecha de insersion del dato,
		--Regitra la fecha de Creacion del Registro
		--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
		FechaInicio date NOT NULL,
		FechaFin date NOT NULL,
		HoraInicio Time(0) NOT NULL,
		HoraFin Time(0) NOT NULL,
		EntidadID int NOT NULL,
		Expediente varchar(128) NOT NULL,
		Actividad varchar(256) NOT NULL,
		UrlSesion varchar(256) NOT NULL DEFAULT 'Sin Generar',
		Motivo varchar(256) NOT NULL DEFAULT 'Sin Motivo',
		EstadoSolicitudID int NOT NULL DEFAULT 1,
		--Estado de la Solicitud
		EstadoRegistroID INT NOT NULL DEFAULT 1,
		--Estado del Registro
		primary key (SolicitudID),
		FOREIGN KEY (SolicitanteID) REFERENCES Usuario (UsuarioID),
		FOREIGN KEY (EntidadID) REFERENCES Entidad (EntidadID),
		FOREIGN KEY (EstadoSolicitudID) REFERENCES EstadoSolicitud (EstadoSolicitudID),
		FOREIGN KEY (EstadoRegistroID) REFERENCES EstadoRegistro (EstadoRegistroID)
);
GO



CREATE TABLE LogSolicitud (
		SolicitudID int PRIMARY KEY IDENTITY (1, 1) NOT NULL,
		SolicitanteID int NOT NULL,
		FechaRegistro date NOT NULL,
		--Regitra la fecha de Creacion del Registro
		--Fecha de Inicio y Fin de la Sesion, Datos Solicitud
		FechaInicio date NOT NULL,
		FechaFin date NOT NULL,
		HoraInicio Time(0) NOT NULL,
		HoraFin Time(0) NOT NULL,
		EntidadID int NOT NULL,
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
		FOREIGN KEY (UsuarioModificaID) REFERENCES Usuario (UsuarioID)
	);
GO

begin try

SELECT
	*
FROM
	RolesRutas
END TRY
BEGIN CATCH
    -- Captura la excepción y muestra un mensaje de error
    PRINT 'Error al crear la tabla: ' + ERROR_MESSAGE();
END CATCH
go
--db SalaViirtuales



select
	*
from
	EstadoSolicitud;

select
	*
from
	UsuarioRol;

-- Actualizar la descripci�n 'aprobante' a 'nueva_descripcion_aprobante'
UPDATE UsuarioRol
SET
	descripcion = 'aprobante'
WHERE
	descripcion = 'APROBANTE';

-- Actualizar la descripci�n 'solicitante' a 'nueva_descripcion_solicitante'
UPDATE UsuarioRol
SET
	descripcion = 'solicitante'
WHERE
	descripcion = 'Solicitante';

select
	*
from
	Usuario;

select
	*
from
	SolicitudHistorial;

select
	*
from
	VwDepMunicipio;

select
	*
from
	Entidad;

DELETE FROM Solicitud;
DBCC CHECKIDENT ('Solicitud', RESEED, 0);


UPDATE Solicitud
SET
	EstadoSolicitudID = 2
WHERE
	SolicitudID = 2;



	
--CREATE TABLE
--	VwDepMunicipio (
--		VwDepMunicipioID int PRIMARY KEY IDENTITY (1, 1) NOT NULL,
--		Departamento varchar(64) NOT NULL,
--		Municipio varchar(64) NOT NULL,
--		EntidadID int NOT NULL,
--		CONSTRAINT FK_ENTIDADID FOREIGN KEY (EntidadID) REFERENCES Entidad (EntidadID)
--	);