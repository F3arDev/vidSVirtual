Use dbSalasVirtuales
--VwUsuarioDetalles
CREATE VIEW
	VwUsuarioDetalles AS
SELECT
	u.UsuarioID,
	u.Nombre,
	ur.UsuarioRolID AS RolId,
	ur.Descripcion AS Rol,
	u.Departamento,
	en.EntidadID,
	en.descripcion AS Entidad
FROM
	Usuario AS u
	INNER JOIN UsuarioRol AS ur ON u.UsuarioID = ur.UsuarioRolID 
	INNER JOIN Entidad AS en ON u.EntidadID = u.EntidadID
GO

select * from VwUsuarioDetalles
GO

--VwSolicitudDetalles
CREATE VIEW
	VwSolicitudDetalles AS
SELECT
	s.SolicitudID,
	u.UsuarioID AS SolicitanteID,
	u.Nombre AS SolicitanteNombre,
	s.FechaRegistro,
	s.FechaInicio,
	s.FechaFin,
	s.HoraInicio,
	s.HoraFin,
	u.Departamento,
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
	INNER JOIN Entidad e ON e.EntidadID = e.EntidadID
	INNER JOIN EstadoSolicitud es ON s.EstadoSolicitudID = es.EstadoSolicitudID
	INNER JOIN EstadoRegistro er ON s.EstadoRegistroID = er.EstadoRegistroID;
GO

select * from VwSolicitudDetalles
GO

--VwRolesRutas
CREATE VIEW
	VwRolesRutas AS
SELECT
	RR.UsuarioRolID,
	UR.descripcion AS Rol,
	RR.RutaID,
	RR.NombreRuta
FROM RolesRutas AS RR
	INNER JOIN UsuarioRol AS UR ON RR.UsuarioRolID = UR.UsuarioRolID;
GO

select * from VwRolesRutas