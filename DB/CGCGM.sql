USE [master]
GO

--DROP DATABASE [CgcGenericMethods];
GO

CREATE DATABASE [CgcGenericMethods];
GO

USE [CgcGenericMethods];
GO

CREATE SCHEMA [seg];
GO

CREATE TABLE seg.Usuarios
(
Id int not null primary key identity(1,1),
NombreUsuario varchar(100) not null,
Nombres varchar(200) not null,
Apellidos varchar(200) not null,
CorreoCorporativo varchar(250) not null,
ContraseniaCorporativa varchar(20) not null
);
GO

insert into seg.Usuarios(NombreUsuario, Nombres, Apellidos, CorreoCorporativo, ContraseniaCorporativa)
values ('pdominguez', 'Nataly Paola', 'Dominguez Landaverde', 'pdominguez@landaverde.com', '@_jmercadillo')

insert into seg.Usuarios(NombreUsuario, Nombres, Apellidos, CorreoCorporativo, ContraseniaCorporativa)
values ('jmercadillo', 'Josué Ulises', 'Mercadillo Flores', 'jmercadillo@flores.com', '@_jmercadillo14.2')

GO

CREATE SCHEMA [cat];
GO

CREATE TABLE cat.Catalogos
(
Id int not null primary key identity(1,1),
Tabla varchar(100) not null,
Campo varchar(100) not null,
Codigo char(3) not null,
Valor varchar(100) not null
);
GO

INSERT INTO cat.Catalogos(Tabla, Campo, Codigo, Valor)
VALUES('Tareas', 'EstadoId', '001', 'SIN ESTADO'),
('Tareas', 'EstadoId', '002', 'PENDIENTE'),
('Tareas', 'EstadoId', '003', 'CADUCADO'),
('Tareas', 'EstadoId', '004', 'FINALIZADO');
GO

CREATE SCHEMA [age];
GO

CREATE TABLE age.Agendas
(
Id int not null primary key identity(1,1),
Nombre varchar(100) not null,
Descripcion varchar(250) null
);
GO

CREATE TABLE age.Tareas
(
Id int not null primary key identity(1,1),
AgendaId int not null references age.Agendas(Id),
Nombre varchar(100) not null,
Descripcion varchar(500) null,
EstadoId int not null references cat.Catalogos(Id),
FechaVencimiento Date null,
FechaRecordatorio DateTime null
);
GO

CREATE TABLE age.AgendasUsuarios
(
Id int not null primary key identity(1,1),
UsuarioId int not null references seg.Usuarios(Id),
AgendaId int not null references age.Agendas(Id),
);
GO