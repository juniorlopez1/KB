
use [master]
go

Create Database [DB_Green_Planet]
go

use [DB_Green_Planet]
go


-- ************************************** [Roles]

CREATE TABLE [Roles]
(

 [idRoles]          tinyint NOT NULL ,
[descripcionRoles] varchar(20) NOT NULL ,


 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([idRoles] ASC)
);
GO








-- ************************************** [Provincia]

CREATE TABLE [Provincia]
(
 [idProvincia]     tinyint NOT NULL ,
 [nombreProvincia] varchar(10) NOT NULL ,


 CONSTRAINT [PK_provincia] PRIMARY KEY CLUSTERED ([idProvincia] ASC)
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








-- ************************************** [Material]

CREATE TABLE [Material]
(
 [idMaterial]          tinyint NOT NULL ,
 [descripcionMaterial] varchar(50) NOT NULL ,


 CONSTRAINT [PK_TipoMaterial] PRIMARY KEY CLUSTERED ([idMaterial] ASC)
);
GO








-- ************************************** [EstadosRecoleccion]

CREATE TABLE [EstadosRecoleccion]
(
 [idEstadosRecoleccion] tinyint NOT NULL ,
 [NombreEstado]         varchar(10) NOT NULL ,


 CONSTRAINT [PK_EstadosRecoleccion] PRIMARY KEY CLUSTERED ([idEstadosRecoleccion] ASC)
);
GO








-- ************************************** [EstadosCupon]

CREATE TABLE [EstadosCupon]
(
 [idEstadosCupon] tinyint NOT NULL ,
 [Descripcion]    varchar(10) NOT NULL ,


 CONSTRAINT [PK_EstadosCupon] PRIMARY KEY CLUSTERED ([idEstadosCupon] ASC)
);
GO








-- ************************************** [InventarioMaterial]

CREATE TABLE [InventarioMaterial]
(
 [idInventarioMaterial] tinyint IDENTITY (1, 1) NOT NULL ,
 [idMaterial]           tinyint NOT NULL ,
 [peso]                 decimal(5,2) NOT NULL ,


 CONSTRAINT [PK_InventarioMaterial] PRIMARY KEY CLUSTERED ([idInventarioMaterial] ASC),
 CONSTRAINT [FK_InventarioMaterial_Material_idMaterial] FOREIGN KEY ([idMaterial])  REFERENCES [Material]([idMaterial])
);
GO


CREATE NONCLUSTERED INDEX [FK_InventarioMaterial_Material_idMaterial] ON [InventarioMaterial] 
 (
  [idMaterial] ASC
 )

GO







-- ************************************** [ComercioAfiliado]

CREATE TABLE [ComercioAfiliado]
(
 [idComercioAfiliado] tinyint IDENTITY (1, 1) NOT NULL ,
 [idRoles]            tinyint NOT NULL ,
 [nombreComercio]     varchar(50) NOT NULL ,
 [nombreUsuario]      varchar(20) NOT NULL ,
 [contrasena]         varchar(64) NOT NULL ,
 [telefono]           varchar(8) NOT NULL ,
 [correo]             varchar(150) NOT NULL ,
 [estado]             bit NOT NULL ,


 CONSTRAINT [PK_ComercioAfiliado] PRIMARY KEY CLUSTERED ([idComercioAfiliado] ASC),
 CONSTRAINT [FK_ComercioAfiliado_Roles_idRoles] FOREIGN KEY ([idRoles])  REFERENCES [Roles]([idRoles])
);
GO


CREATE NONCLUSTERED INDEX [FK_ComercioAfiliado_Roles_idRoles] ON [ComercioAfiliado] 
 (
  [idRoles] ASC
 )

GO







-- ************************************** [Canton]

CREATE TABLE [Canton]
(
 [idCanton]     tinyint NOT NULL ,
 [nombreCanton] varchar(20) NOT NULL ,
 [idProvincia]  tinyint NOT NULL ,


 CONSTRAINT [PK_canton] PRIMARY KEY CLUSTERED ([idCanton] ASC),
 CONSTRAINT [FK_Canton_Provincia_idProvincia] FOREIGN KEY ([idProvincia])  REFERENCES [Provincia]([idProvincia])
);
GO


CREATE NONCLUSTERED INDEX [FK_Canton_Provincia_idProvincia] ON [Canton] 
 (
  [idProvincia] ASC
 )

GO







-- ************************************** [Distrito]

CREATE TABLE [Distrito]
(
 [idDistrito]     tinyint NOT NULL ,
 [idCanton]       tinyint NOT NULL ,
 [nombreDistrito] varchar(50) NOT NULL ,


 CONSTRAINT [PK_Distrito] PRIMARY KEY CLUSTERED ([idDistrito] ASC),
 CONSTRAINT [FK_Distrito_Canton_idCanton] FOREIGN KEY ([idCanton])  REFERENCES [Canton]([idCanton])
);
GO


CREATE NONCLUSTERED INDEX [FK_Distrito_Canton_idCanton] ON [Distrito] 
 (
  [idCanton] ASC
 )

GO







-- ************************************** [DetalleCupon]

CREATE TABLE [DetalleCupon]
(
 [idDetalleCupon]     int IDENTITY (1, 1) NOT NULL ,
 [idComercioAfiliado] tinyint NOT NULL ,
 [DescCupon]          varchar(100) NOT NULL ,
 [CantidadHojas]      smallint NOT NULL ,
 [imagen]             varbinary(50) NOT NULL ,


 CONSTRAINT [PK_DetalleCupon] PRIMARY KEY CLUSTERED ([idDetalleCupon] ASC),
 CONSTRAINT [FK_DetalleCupon_ComercioAfiliado_idComercioAfiliado] FOREIGN KEY ([idComercioAfiliado])  REFERENCES [ComercioAfiliado]([idComercioAfiliado])
);
GO


CREATE NONCLUSTERED INDEX [FK_DetalleCupon_ComercioAfiliado_idComercioAfiliado] ON [DetalleCupon] 
 (
  [idComercioAfiliado] ASC
 )

GO







-- ************************************** [CuentasXcobrar]

CREATE TABLE [CuentasXcobrar]
(
 [idCuentasXcobrar]     int NOT NULL ,
 [idInventarioMaterial] tinyint NOT NULL ,
 [pesoEntregado]        decimal(5,2) NOT NULL ,
 [monto]                int NOT NULL ,
 [fecha]                date NOT NULL ,


 CONSTRAINT [PK_CuentasXcobrar] PRIMARY KEY CLUSTERED ([idCuentasXcobrar] ASC),
 CONSTRAINT [FK_CuentasXcobrar_InventarioMaterial_idInventarioMaterial] FOREIGN KEY ([idInventarioMaterial])  REFERENCES [InventarioMaterial]([idInventarioMaterial])
);
GO


CREATE NONCLUSTERED INDEX [FK_CuentasXcobrar_InventarioMaterial_idInventarioMaterial] ON [CuentasXcobrar] 
 (
  [idInventarioMaterial] ASC
 )

GO







-- ************************************** [Direcciones]

CREATE TABLE [Direcciones]
(
 [idDireccion]     int IDENTITY (1, 1)NOT NULL ,
 [idDistrito]      tinyint NOT NULL ,
 [nombreDireccion] varchar(200) NOT NULL ,


 CONSTRAINT [PK_direcciones] PRIMARY KEY CLUSTERED ([idDireccion] ASC),
 CONSTRAINT [FK_Direcciones_Distrito_idDistrito] FOREIGN KEY ([idDistrito])  REFERENCES [Distrito]([idDistrito])
);
GO


CREATE NONCLUSTERED INDEX [FK_Direcciones_Distrito_idDistrito] ON [Direcciones] 
 (
  [idDistrito] ASC
 )

GO







-- ************************************** [Colaboradores]

CREATE TABLE [Colaboradores]
(
 [idColaborador] int IDENTITY (1, 1) NOT NULL ,
 [idPersona]     varchar(16) NOT NULL ,
 [idDireccion]   int NOT NULL ,
 [idRoles]       tinyint NOT NULL ,
 [nombreUsuario] varchar(20) NOT NULL ,
 [contrasena]    varchar(64) NOT NULL ,
 [correo]        varchar(150) NOT NULL ,
 [tel]           varchar(8) NOT NULL ,
 [estado]        bit NOT NULL ,


 CONSTRAINT [PK_Colaboradores] PRIMARY KEY CLUSTERED ([idColaborador] ASC),
 CONSTRAINT [FK_Colaboradores_Direccion_idDireccion] FOREIGN KEY ([idDireccion])  REFERENCES [Direcciones]([idDireccion]),
 CONSTRAINT [FK_Colaboradores_Persona_idPersona] FOREIGN KEY ([idPersona])  REFERENCES [Persona]([idPersona]),
 CONSTRAINT [FK_Colaboradores_Roles_idRoles] FOREIGN KEY ([idRoles])  REFERENCES [Roles]([idRoles])
);
GO


CREATE NONCLUSTERED INDEX [FK_Colaboradores_Direccion_idDireccion] ON [Colaboradores] 
 (
  [idDireccion] ASC
 )

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







-- ************************************** [Clientes]

CREATE TABLE [Clientes]
(
 [idCliente]     int IDENTITY (1, 1) NOT NULL ,
 [idPersona]     varchar(16) NOT NULL ,
 [idDireccion]   int NOT NULL ,
 [idRoles]       tinyint NOT NULL ,
 [nombreUsuario] varchar(20) NOT NULL ,
 [contrasena]    varchar(64) NOT NULL ,
 [correo]        varchar(150) NULL ,
 [tel]           varchar(8) NULL ,
 [estado]        bit NOT NULL ,
 [hojas]         smallint NOT NULL ,


 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([idCliente] ASC),
 CONSTRAINT [FK_Clientes_Direccion_idDireccion] FOREIGN KEY ([idDireccion])  REFERENCES [Direcciones]([idDireccion]),
 CONSTRAINT [FK_Clientes_Persona_idPersona] FOREIGN KEY ([idPersona])  REFERENCES [Persona]([idPersona]),
 CONSTRAINT [FK_Clientes_Roles_idRoles] FOREIGN KEY ([idRoles])  REFERENCES [Roles]([idRoles])
);
GO


CREATE NONCLUSTERED INDEX [FK_Clientes_Direccion_idDireccion] ON [Clientes] 
 (
  [idDireccion] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Clientes_Persona_idPersona] ON [Clientes] 
 (
  [idPersona] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Clientes_Roles_idRoles] ON [Clientes] 
 (
  [idRoles] ASC
 )

GO







-- ************************************** [Recoleccion]

CREATE TABLE [Recoleccion]
(
 [idRecoleccion]        int NOT NULL ,
 [idCliente]            int NOT NULL ,
 [idEstadosRecoleccion] tinyint NOT NULL ,
 [totalHojas]           smallint NOT NULL ,


 CONSTRAINT [PK_recoleccion] PRIMARY KEY CLUSTERED ([idRecoleccion] ASC),
 CONSTRAINT [FK_Recoleccion_Clientes_idClientes] FOREIGN KEY ([idCliente])  REFERENCES [Clientes]([idCliente]),
 CONSTRAINT [FK_Recoleccion_EstadosRecoleccion_idEstadosRecoleccion] FOREIGN KEY ([idEstadosRecoleccion])  REFERENCES [EstadosRecoleccion]([idEstadosRecoleccion])
);
GO


CREATE NONCLUSTERED INDEX [FK_Recoleccion_Clientes_idClientes] ON [Recoleccion] 
 (
  [idCliente] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Recoleccion_EstadosRecoleccion_idEstadosRecoleccion] ON [Recoleccion] 
 (
  [idEstadosRecoleccion] ASC
 )

GO







-- ************************************** [Cupones]

CREATE TABLE [Cupones]
(
 [idCupones]        int IDENTITY (1, 1) NOT NULL ,
 [idDetalleCupon]   int NOT NULL ,
 [idCliente]        int NULL ,
 [idEstadosCupon]   tinyint NOT NULL ,
 [fechaIngreso]     date NOT NULL ,
 [fechaVencimiento] date NOT NULL ,


 CONSTRAINT [PK_Cupones] PRIMARY KEY CLUSTERED ([idCupones] ASC),
 CONSTRAINT [FK_Cupones_Clientes_idClientes] FOREIGN KEY ([idCliente])  REFERENCES [Clientes]([idCliente]),
 CONSTRAINT [FK_Cupones_DetalleCupon_idDetalleCupon] FOREIGN KEY ([idDetalleCupon])  REFERENCES [DetalleCupon]([idDetalleCupon]),
 CONSTRAINT [FK_Cupones_EstadosCupon_idEstadosCupon] FOREIGN KEY ([idEstadosCupon])  REFERENCES [EstadosCupon]([idEstadosCupon])
);
GO


CREATE NONCLUSTERED INDEX [FK_Cupones_Clientes_idClientes] ON [Cupones] 
 (
  [idCliente] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Cupones_DetalleCupon_idDetalleCupon] ON [Cupones] 
 (
  [idDetalleCupon] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Cupones_EstadosCupon_idEstadosCupon] ON [Cupones] 
 (
  [idEstadosCupon] ASC
 )

GO







-- ************************************** [AreaCobertura]

CREATE TABLE [AreaCobertura]
(
 [idAreaCobertura] int NOT NULL ,
 [idProvincia]     tinyint NOT NULL ,
 [idColaborador]   int NOT NULL ,


 CONSTRAINT [PK_AreaCobertura] PRIMARY KEY CLUSTERED ([idAreaCobertura] ASC),
 CONSTRAINT [FK_AreaCobertura_Colaborador_idColaborador] FOREIGN KEY ([idColaborador])  REFERENCES [Colaboradores]([idColaborador]),
 CONSTRAINT [FK_AreaCobertura_Provincia_idProvincia] FOREIGN KEY ([idProvincia])  REFERENCES [Provincia]([idProvincia])
);
GO


CREATE NONCLUSTERED INDEX [FK_AreaCobertura_Colaborador_idColaborador] ON [AreaCobertura] 
 (
  [idColaborador] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_AreaCobertura_Provincia_idProvincia] ON [AreaCobertura] 
 (
  [idProvincia] ASC
 )

GO







-- ************************************** [MaterialesXrecoleccion]

CREATE TABLE [MaterialesXrecoleccion]
(
 [idMaterialesXrecoleccion] int NOT NULL ,
 [idRecoleccion]            int NOT NULL ,
 [idMaterial]               tinyint NOT NULL ,
 [pesoRecoleccion]          decimal(5,2) NOT NULL ,


 CONSTRAINT [PK_MaterialesXrecoleccion] PRIMARY KEY CLUSTERED ([idMaterialesXrecoleccion] ASC),
 CONSTRAINT [FK_MaterialesXrecoleccion_Material_idMaterial] FOREIGN KEY ([idMaterial])  REFERENCES [Material]([idMaterial]),
 CONSTRAINT [FK_MaterialesXrecoleccion_Recoleccion_idRecoleccion] FOREIGN KEY ([idRecoleccion])  REFERENCES [Recoleccion]([idRecoleccion])
);
GO


CREATE NONCLUSTERED INDEX [FK_MaterialesXrecoleccion_Material_idMaterial] ON [MaterialesXrecoleccion] 
 (
  [idMaterial] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_MaterialesXrecoleccion_Recoleccion_idRecoleccion] ON [MaterialesXrecoleccion] 
 (
  [idRecoleccion] ASC
 )

GO







-- ************************************** [DireccionXrecoleccion]

CREATE TABLE [DireccionXrecoleccion]
(
 [idDireccionXrecoleccion] int NOT NULL ,
 [idRecoleccion]           int NOT NULL ,
 [idDireccion]             int NOT NULL ,


 CONSTRAINT [PK_DireccionXrecoleccion] PRIMARY KEY CLUSTERED ([idDireccionXrecoleccion] ASC),
 CONSTRAINT [FK_DireccionXrecoleccion_Direccion_idDireccion] FOREIGN KEY ([idDireccion])  REFERENCES [Direcciones]([idDireccion]),
 CONSTRAINT [FK_DireccionXrecoleccion_Recoleccion_idRecoleccion] FOREIGN KEY ([idRecoleccion])  REFERENCES [Recoleccion]([idRecoleccion])
);
GO


CREATE NONCLUSTERED INDEX [FK_DireccionXrecoleccion_Direccion_idDireccion] ON [DireccionXrecoleccion] 
 (
  [idDireccion] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_DireccionXrecoleccion_Recoleccion_idRecoleccion] ON [DireccionXrecoleccion] 
 (
  [idRecoleccion] ASC
 )

GO







-- ************************************** [Agenda]

CREATE TABLE [Agenda]
(
 [idAgenda]      int NOT NULL ,
 [idColaborador] int NOT NULL ,
 [idRecoleccion] int NOT NULL ,


 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED ([idAgenda] ASC),
 CONSTRAINT [FK_Agenda_Colaborador_idColaborador] FOREIGN KEY ([idColaborador])  REFERENCES [Colaboradores]([idColaborador]),
 CONSTRAINT [FK_Agenda_Recoleccion_idRecoleccion] FOREIGN KEY ([idRecoleccion])  REFERENCES [Recoleccion]([idRecoleccion])
);
GO


CREATE NONCLUSTERED INDEX [FK_Agenda_Colaborador_idColaborador] ON [Agenda] 
 (
  [idColaborador] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_Agenda_Recoleccion_idRecoleccion] ON [Agenda] 
 (
  [idRecoleccion] ASC
 )

GO






-- ************************************** [Datos Quemados]


use DB_Green_Planet
go
------------Provincias-------
insert into Provincia values (1,'San José')
insert into Provincia values (2,'Alajuela')
insert into Provincia values (3,'Cartago')
insert into Provincia values (4,'Heredia')

---------------canton------------------

--san josé
insert into Canton values (1,'San José',1)
insert into Canton values (2,'Escazú',1)
insert into Canton values (3,'Desamparados',1)
insert into Canton values (4,'Aserrí',1)
insert into Canton values (5,'Goicoechea',1)
insert into Canton values (6,'Vásquez de Coronado',1)
insert into Canton values (7,'Tibás',1)
insert into Canton values (8,'Moravia',1)
insert into Canton values (9,'Montes de Oca',1)
insert into Canton values (10,'Curridabat',1)

--Alajuela
insert into Canton values (11,'Alajuela',2)

--Cartago
insert into Canton values (12,'Cartago',3)
insert into Canton values (13,'La Unión',3)
insert into Canton values (14,'Paraíso',3)

--Heredia
insert into Canton values (15,'Heredia',4)
insert into Canton values (16,'Barva',4)
insert into Canton values (17,'Santo Domingo',4)
insert into Canton values (18,'Santa Bárbara',4)
insert into Canton values (19,'San Rafael',4)
insert into Canton values (20,'San Isidro',4)
insert into Canton values (21,'Belén',4)
insert into Canton values (22,'Flores',4)
insert into Canton values (23,'San Pablo',4)

-------------------------Distritos-------------
----San José---
--San José
insert into Distrito values (1,1,'Carmen')
insert into Distrito values (2,1,'Merced')
insert into Distrito values (3,1,'Zapote')
insert into Distrito values (4,1,'San Francisco de Dos Ríos')
insert into Distrito values (5,1,'Uruca')
insert into Distrito values (6,1,'Mata Redonda')
insert into Distrito values (7,1,'Pavas')
insert into Distrito values (8,1,'San Sebastián')

--Escazú
insert into Distrito values (9,2,'San Antonio')
insert into Distrito values (10,2,'San Rafael')

--Desamparados 

insert into Distrito values (11,3,'San Miguel')
insert into Distrito values (12,3,'San Juan de Dios')
insert into Distrito values (13,3,'San Antonio')
insert into Distrito values (14,3,'Frailes')

--Aserri
insert into Distrito values (15,4,'Aserrí')
insert into Distrito values (16,4,'Tarbaca')
insert into Distrito values (17,4,'San Gabriel')
insert into Distrito values (18,4,'Monterrey')

--Goicoechea
insert into Distrito values (19,5,'San Francisco')
insert into Distrito values (20,5,'Calle blancos')
insert into Distrito values (21,5,'Mataplatano')
insert into Distrito values (22,5,'Ipis')
insert into Distrito values (23,5,'Rancho Redondo')
insert into Distrito values (24,5,'Purral')

--Vásquez de Coronado
insert into Distrito values (25,6,'San Isidro')
insert into Distrito values (26,6,'San Rafael')
insert into Distrito values (27,6,'Dulce Nombre de Jesús')
insert into Distrito values (28,6,'Cascajal')

--Tíbas
insert into Distrito values (29,7,'Llorente')
insert into Distrito values (30,7,'San Juan')
insert into Distrito values (31,7,'Cinco Esquinas')

--Moravia
insert into Distrito values (32,8,'San Vicente')
insert into Distrito values (33,8,'San Jerónimo')
insert into Distrito values (34,8,'La Trinidad')

--Montes de Oca
insert into Distrito values (35,9,'San Pedro')
insert into Distrito values (36,9,'Sabanilla')
insert into Distrito values (37,9,'Mercedes,')
insert into Distrito values (38,9,'San Rafael')

--Curridabat
insert into Distrito values (39,10,'Curridabat')
insert into Distrito values (40,10,'Granadilla')
insert into Distrito values (41,10,'Sánchez')


--------Alajuela-------
--alajuela
insert into Distrito values (42,11,'Alajuela')
insert into Distrito values (43,11,'San Antonio')
insert into Distrito values (44,11,'Guácima')
insert into Distrito values (45,11,'San Isidro')
insert into Distrito values (46,11,'Sabanilla')
insert into Distrito values (47,11,'Turrucares')
insert into Distrito values (48,11,'Tambor')
insert into Distrito values (49,11,'Rio Segundo')
insert into Distrito values (50,11,'San Jose')


-------------Cartago-----------
--cartago
insert into Distrito values (51,12,'Carmen')
insert into Distrito values (52,12,'Guadalupe')
insert into Distrito values (53,12,'Corralillo')

--La Union
insert into Distrito values (54,13,'Tres ríos')
insert into Distrito values (55,13,'San Diego')
insert into Distrito values (56,13,'Dulce nombre')

--Paraiso
insert into Distrito values (57,14,'Paraíso')

-----------------heredia--------
--heredia
insert into Distrito values (58,15,'Heredia')
insert into Distrito values (59,15,'Mercedes')
insert into Distrito values (60,15,'San Francisco')
insert into Distrito values (61,15,'Ulloa')

--Barva
insert into Distrito values (62,16,'San Pedro')
insert into Distrito values (63,16,'San Pablo')
insert into Distrito values (64,16,'San Roque')
insert into Distrito values (65,16,'Santa Lucia')

--San Domingo
insert into Distrito values (66,17,'San Vicente')
insert into Distrito values (67,17,'San Miguel')
insert into Distrito values (68,17,'Paracito')
insert into Distrito values (69,17,'Santo Tomas')
insert into Distrito values (70,17,'Santa Rosa')

--santa barbara
insert into Distrito values (71,18,'Santo Domingo')

--Sn Rafael
insert into Distrito values (72,19,'San Josecito')
insert into Distrito values (73,19,'Santiago')
insert into Distrito values (74,19,'Angeles')
insert into Distrito values (75,19,'Concepcion')

--san Isidro
insert into Distrito values (76,20,'San Isidro')

--Belen
insert into Distrito values (77,21,'La Ribera')
insert into Distrito values (78,21,'La Asunción')

--Flores
insert into Distrito values (79,22,'San Joaquín')
insert into Distrito values (80,22,'Barrantes')
insert into Distrito values (81,22,'Llorente')

--san pablo
insert into Distrito values (82,23,'San Pablo')


----------------------------  Datos Roles

use [DB_Green_Planet]
go

Insert Into Roles (idRoles, descripcionRoles) 	
Values (1, 'Administrador') ,
           (2, 'Secretaria') ,
           (3, 'Clientes') ,
           (4, 'Comercio afiliado') ,
           (5, 'Recolector');
go		   
----------------------------- Datos EstadosRecoleccion

Insert Into EstadosRecoleccion (idEstadosRecoleccion, NombreEstado)
Values   (1, 'Gestionada'),
		    (2, 'En proceso'),
		    (3, 'Pendiente'),
		    (4, 'Cancelado');
go
----------------------------- Datos EstadosCupon


Insert Into EstadosCupon (idEstadosCupon, Descripcion)
Values  (1, 'Vencido'),
		    (2, 'Canjeado'),
		    (3, 'Adquirido');
go			
----------------------------- Datos Material

Insert Into Material (idMaterial, descripcionMaterial)
values  (1, 'Latas de alumunio'),
		(2, 'Carton'),
		(3, 'Papel'),
		(4, 'Botellas plásticas'),
		(5, 'Botellas de polietileno'),
		(6, 'Botellas de vidrio'),
		(7, 'Tetra brik');
go
