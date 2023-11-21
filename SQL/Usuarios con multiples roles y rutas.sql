use dbSalasVirtuales;

CREATE TABLE Usuarios (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50),
    contraseña NVARCHAR(50)
);

CREATE TABLE Roles (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50)
);


CREATE TABLE Permisos (
    id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50),
    ruta NVARCHAR(100)
);

CREATE TABLE UsuariosRoles (
    usuario_id INT,
    rol_id INT,
    PRIMARY KEY (usuario_id, rol_id),
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(id),
    FOREIGN KEY (rol_id) REFERENCES Roles(id)
);

CREATE TABLE RolesPermisos (
    rol_id INT,
    permiso_id INT,
    PRIMARY KEY (rol_id, permiso_id),
    FOREIGN KEY (rol_id) REFERENCES Roles(id),
    FOREIGN KEY (permiso_id) REFERENCES Permisos(id)
);


-- Insertar Usuario
INSERT INTO Usuarios (nombre, contraseña) VALUES ('Fredd', '123');

-- Insertar Roles
INSERT INTO Roles (nombre) VALUES ('admin');
INSERT INTO Roles (nombre) VALUES ('empleado');

-- Insertar Permisos
INSERT INTO Permisos (nombre, ruta) VALUES ('/admin/dashboard', '/admin/dashboard');
INSERT INTO Permisos (nombre, ruta) VALUES ('/admin/usuarios', '/admin/usuarios');
INSERT INTO Permisos (nombre, ruta) VALUES ('/empleado/dashboard', '/empleado/dashboard');
INSERT INTO Permisos (nombre, ruta) VALUES ('/empleado/tareas', '/empleado/tareas');

-- Asignar Roles a Usuario
INSERT INTO UsuariosRoles (usuario_id, rol_id) VALUES (1, 1); -- admin
INSERT INTO UsuariosRoles (usuario_id, rol_id) VALUES (1, 2); -- empleado

-- Asignar Permisos a Roles
INSERT INTO RolesPermisos (rol_id, permiso_id) VALUES (1, 1); -- admin - /admin/dashboard
INSERT INTO RolesPermisos (rol_id, permiso_id) VALUES (1, 2); -- admin - /admin/usuarios
INSERT INTO RolesPermisos (rol_id, permiso_id) VALUES (2, 3); -- empleado - /empleado/dashboard
INSERT INTO RolesPermisos (rol_id, permiso_id) VALUES (2, 4); -- empleado - /empleado/tareas


CREATE VIEW VistaRolesUsuarios AS
SELECT 
    UR.usuario_id,
    R.nombre AS nombre_rol,
    RP.permiso_id,
    P.nombre AS nombre_permiso,
    P.ruta
FROM UsuariosRoles UR
JOIN RolesPermisos RP ON UR.rol_id = RP.rol_id
JOIN Roles R ON UR.rol_id = R.id
JOIN Permisos P ON RP.permiso_id = P.id;

CREATE VIEW VistaRolesPermisos AS
SELECT
    RP.rol_id,
    R.nombre AS nombre_rol,
    RP.permiso_id,
    P.nombre AS nombre_permiso,
    P.ruta
FROM RolesPermisos RP
JOIN Roles R ON RP.rol_id = R.id
JOIN Permisos P ON RP.permiso_id = P.id;


select * from VistaRolesPermisos
select * from VistaRolesUsuarios