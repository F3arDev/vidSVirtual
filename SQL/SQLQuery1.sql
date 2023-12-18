EXEC sp_rename 'SolicitudHistorial', 'LogSolicitud', 'COLUMN';

select * from Entidad

select * from Usuario

ALTER TABLE Usuario
ADD EntidadID INT;

-- Agregar la clave foránea a la tabla Usuario
ALTER TABLE Usuario
ADD FOREIGN KEY (EntidadID) REFERENCES Entidad(EntidadID);


UPDATE Usuario
SET EntidadID = 1
WHERE UsuarioID = 3;






SELECT 
    FK.name AS ForeignKeyName,
    TP.name AS TableName
FROM 
    sys.foreign_keys FK
    INNER JOIN sys.tables TP ON TP.object_id = FK.parent_object_id
WHERE 
    FK.referenced_object_id = OBJECT_ID('Entidad');


ALTER TABLE Usuario
DROP CONSTRAINT FK_EntidadID;

DROP TABLE UsuarioRol;




ALTER TABLE Usuario
ADD CONSTRAINT FK_Entidad_Usuario
    FOREIGN KEY (EntidadID)
    REFERENCES Entidad(EntidadID);

	SELECT *
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_NAME = 'FK_EntidadID';
