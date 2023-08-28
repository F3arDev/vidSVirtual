create database dbSalaVirtual;

use dbSalaVirtual;
--Creacion de tablas--

--Tabla Usuario--
create table usuario(
	codUsuario int PRIMARY KEY,
	nombre varchar(50),
	cedula varchar(20),
	email varchar(50),
	telefono int,
	codRol int
)

--Tabla Estados--
create table estados(
	codEstado int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	descripcion varchar(10)
)

--Tabla Entidades--
create table entidades(
	codEntidad int IDENTITY(1,1) NOT NUlL PRIMARY KEY,
	descripcion varchar(30)
)

--Tabla Solicitud--
create table solicitud(
	codSolicitud int IDENTITY(1,1) NOT NUlL PRIMARY KEY,
	nomSolicitante varchar(50),
	cedSolicitante varchar (25),
	emailSolicitante varchar(45),
	telefono int,
	ciudad varchar(50),
	codEntidad int FOREIGN KEY REFERENCES entidades(codEntidad),
	fechaInicio DATETIME,
	fechafin DATETIME,
	expediente varchar(50),
	Activ_Realizar varchar(150),
	urlSesion text,
	codEstado int FOREIGN KEY REFERENCES estados(codEstado)
)

select * from solicitud
--DROP TABLE usuario;
--DROP TABLE solicitud;
--DROP TABLE entidades;
--DROP TABLE estados;

