use [master]
go

Create Database [DB_AnimaWeb]
go

use [DB_AnimaWeb]
go

CREATE TABLE [Roles]
(

 [idRoles]          tinyint NOT NULL ,
[descripcionRoles] varchar(20) NOT NULL ,


 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([idRoles] ASC)
);
GO

-- ************************************** [Persona]

CREATE TABLE [Persona]
(
 [idPersona] varchar(16) NOT NULL ,
 [nombre]    varchar(20) NOT NULL ,
 [apellidos] varchar(100) NOT NULL ,


 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED ([idPersona] ASC)
);
GO

-- ************************************** [Colaboradores]

CREATE TABLE [Colaboradores]
(
 [idColaborador] int IDENTITY (1, 1) NOT NULL ,
 [idPersona]     varchar(16) NOT NULL ,
 [Direccion]     varchar(20) NOT NULL ,
 [idRoles]       tinyint NOT NULL ,
 [nombreUsuario] varchar(20) NOT NULL ,
 [contrasena]    varchar(64) NOT NULL ,
 [correo]        varchar(150) NOT NULL ,
 [tel]           varchar(8) NOT NULL ,
 [estado]        bit NOT NULL ,


 CONSTRAINT [PK_Colaboradores] PRIMARY KEY CLUSTERED ([idColaborador] ASC),
 CONSTRAINT [FK_Colaboradores_Persona_idPersona] FOREIGN KEY ([idPersona])  REFERENCES [Persona]([idPersona]),
 CONSTRAINT [FK_Colaboradores_Roles_idRoles] FOREIGN KEY ([idRoles])  REFERENCES [Roles]([idRoles])
);
GO


CREATE NONCLUSTERED INDEX [FK_Colaboradores_Persona_idPersona] ON [Colaboradores] 
 (
  [idPersona] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Colaboradores_Roles_idRoles] ON [Colaboradores] 
 (
  [idRoles] ASC
 )

GO

-- ************************************** [documento]


CREATE TABLE [Documento]
(
 [idDocumento] int IDENTITY (1, 1) NOT NULL ,
 [titulo]     varchar(50) NOT NULL ,
 [fechaCreacion]     date NOT NULL ,
 [numeroVersion]     tinyint NOT NULL ,
 [fechaModificacion] date NOT NULL ,
 [Contenido]    varchar(3000) NOT NULL ,
 [idColaborador]   int NOT NULL ,
 [estado]        bit NOT NULL ,
 
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED ([idDocumento] ASC),
 CONSTRAINT [FK_Documentos_Colaboradores_idColaborador] FOREIGN KEY ([idColaborador])  REFERENCES [Colaboradores]([idColaborador])
);
GO

CREATE NONCLUSTERED INDEX [FK_Documentos_Colaboradores_idColaborador] ON [Documento] 
 (
  [idColaborador] ASC
 )

GO

-- ************************************** [documentoHistorial]

CREATE TABLE [DocumentoHistorial]
(
 [idDocumento] int IDENTITY (1, 1) NOT NULL ,
 [titulo]     varchar(50) NOT NULL ,
 [fechaCreacion]     date NOT NULL ,
 [numeroVersion]     tinyint NOT NULL ,
 [fechaModificacion] date NOT NULL ,
 [Contenido]    varchar(300) NOT NULL ,
 [estado]        bit NOT NULL ,
 [idColaborador]   int NOT NULL ,
 [idDoc]   int NOT NULL ,
 
 CONSTRAINT [PK_DocumentosHistorial] PRIMARY KEY CLUSTERED ([idDocumento] ASC),
 CONSTRAINT [FK_DocumentosHistorial_Colaboradores_idColaborador] FOREIGN KEY ([idColaborador])  REFERENCES [Colaboradores]([idColaborador]),
 CONSTRAINT [FK_DocumentosHistorial_Documentos_idDoc] FOREIGN KEY ([idDoc])  REFERENCES [Documento]([idDocumento])

);
GO

CREATE NONCLUSTERED INDEX [FK_DocumentosHistorial_Colaboradores_idColaborador] ON [DocumentoHistorial] 
 (
  [idColaborador] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_DocumentosHistorial_Documentos_idDoc] ON [DocumentoHistorial] 
 (
  [idDoc] ASC
 )

GO
