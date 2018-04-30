USE [master]
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
values ('jmercadillo', 'Josu� Ulises', 'Mercadillo Flores', 'jmercadillo@flores.com', '@_jmercadillo14.2')

GO

--SELECT Id, NombreUsuario, Nombres, Apellidos, CorreoCorporativo, ContraseniaCorporativa FROM seg.Usuarios;

CREATE SCHEMA [age];
GO

CREATE TABLE age.Agendas
(
Id int not null primary key identity(1,1),
Nombre varchar(100) not null,
Descripcion varchar(500) not null
);
GO

CREATE TABLE age.Tareas
(
Id int not null primary key identity(1,1),
AgendaId int not null references age.Agendas(Id),
Nombre varchar(100) not null,
Descripcion varchar(500) not null
);
GO

CREATE TABLE age.AgendasUsuarios
(
Id int not null primary key identity(1,1),
UsuarioId int not null references seg.Usuarios(Id),
AgendaId int not null references age.Agendas(Id),
);
GO