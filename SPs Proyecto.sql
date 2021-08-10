use DB_AnimaWeb
/*--------------Procedimientos almacenados-----------------*/

--Procedimiento almacenado de Login sobre tabla Colaboradores
CREATE PROCEDURE SPLogueo(
	@nombreUsuario VARCHAR(20),
	@contrasena VARCHAR(64)
)
AS 
BEGIN 
	SELECT * FROM Colaboradores
		WHERE nombreUsuario=@nombreUsuario and contrasena=@contrasena
END
go
--Prueba de Ejecución Login
EXEC SPLogueo
			@nombreUsuario = 'jsua',
			@contrasena = 'test1234'




--Procedimiento almacenado de Insertar sobre tabla Documentos

CREATE PROCEDURE SPInsertarDocumento
    @titulo AS VARCHAR(50),
    @fechaCreacion AS DATE,
	@numeroVersion AS TINYINT,
	@fechaModificacion AS DATE,
	@Contenido AS VARCHAR(300),
	@idColaborador AS INT,
	@estado AS BIT

AS
BEGIN
        INSERT INTO Documento(titulo,fechaCreacion,numeroVersion,fechaModificacion,Contenido,idColaborador,estado) 
		VALUES (@titulo, @fechaCreacion, @numeroVersion,@fechaModificacion, @Contenido,@idColaborador, @estado)
END
GO

--Prueba de Ejecución Insertar 
Exec SPInsertarDocumento
    @titulo = 'Prueba titulo',
    @fechaCreacion = '2020-07-31',
    @numeroVersion = 1,
	@fechaModificacion = '2020-07-31',
	@Contenido = 'Prueba contenido,prueba contenido, prueba contenido',
	@idColaborador = 1,
	@estado = 0

--Procedimiento almacenado de Actualizar sobre tabla Documentos y Procedimiento almacenado Insertar sobre Documentos Historial

CREATE PROCEDURE SPActualizarDocumento
	@idDocumento AS INT,
    @titulo AS VARCHAR(50),
	@tituloHistorial AS VARCHAR(50),
	@fechaCreacionHistorial AS DATE,
	@numeroVersion AS TINYINT,
	@numeroVersionHistorial AS TINYINT,
	@fechaModificacion AS DATE,
	@fechaModificacionHistorial AS DATE,
	@Contenido AS VARCHAR(3000),
	@ContenidoHistorial AS VARCHAR(3000),
	@idColaborador AS INT,
	@idColaboradorHistorial AS INT,
	@estado AS BIT,
	@estadoHistorial AS BIT

AS
BEGIN

        UPDATE Documento SET	
		                        titulo = @titulo,
								numeroVersion = @numeroVersion,
								fechaModificacion = @fechaModificacion,
								Contenido = @Contenido,
								idColaborador = @idColaborador,
								estado = @estado

		WHERE  idDocumento = @idDocumento

		INSERT INTO DocumentoHistorial(titulo,fechaCreacion,numeroVersion,fechaModificacion,Contenido,estado,idColaborador,idDoc) 
		VALUES (@tituloHistorial, @fechaCreacionHistorial, @numeroVersionHistorial,@fechaModificacionHistorial, @ContenidoHistorial,@estadoHistorial,@idColaboradorHistorial, @idDocumento)

END
GO

--Prueba de Ejecución Actualizar
Exec SPActualizarDocumento
        @idDocumento = 2,
		@titulo = 'Prueba tituloActualizacion',
		@tituloHistorial = 'Prueba titulo',
		@fechaCreacion = '2020-07-31',
		@fechaCreacionHistorial = '2020-07-31',
		@numeroVersion = 2,
		@numeroVersionHistorial = 1,
		@fechaModificacion = '2020-08-01',
		@fechaModificacionHistorial = '2020-07-31',
		@Contenido = 'Prueba contenido,prueba contenido, prueba contenido',
		@ContenidoHistorial = 'Prueba contenido,prueba contenido, prueba contenido',
		@idColaborador = 2,
		@idColaboradorHistorial = 1,
		@estado = 1,
		@estadoHistorial = 0,
		@idDoc = 2



--Procedimiento almacenado de Seleccionar Documento por ID

CREATE PROCEDURE SPSeleccionarDocumento
    @idDocumento AS INT

AS
BEGIN

     SELECT titulo, fechaCreacion, numeroVersion, fechaModificacion, Contenido, idColaborador, estado 
    FROM   Documento  
    WHERE  (idDocumento = @idDocumento)
END
GO

--Prueba de Ejecución Seleccionar por ID
Exec SPSeleccionarDocumento
	 @idDocumento = 2


--Procedimiento almacenado de Seleccionar DocumentoHistorial por ID

CREATE PROCEDURE SPSeleccionarDocumentoHistorial
    @idDocumento AS INT

AS
BEGIN

     SELECT titulo, fechaCreacion, numeroVersion, fechaModificacion, Contenido,estado,idColaborador,idDoc
    FROM   DocumentoHistorial 
    WHERE  (idDocumento = @idDocumento)
END
GO

--Prueba de Ejecución Seleccionar por ID
Exec SPSeleccionarDocumentoHistorial
	 @idDocumento = 1


--Procedimiento almacenado de Seleccionar TODOS sobre tabla Documentos Historial

CREATE PROCEDURE SPSeleccionarTodosDocumentosHistorial

AS
BEGIN

     SELECT titulo, fechaCreacion, numeroVersion, fechaModificacion, Contenido, estado, idColaborador, idDoc
    FROM   DocumentoHistorial
END
GO

--Prueba de Ejecución Seleccionar todos
Exec SPSeleccionarTodosDocumentosHistorial

use DB_AnimaWeb
CREATE PROCEDURE SP_listar_documentos_sin_aprobar
AS
BEGIN

SELECT idDocumento as idDocumento, titulo as Titulo,fechaCreacion as Fecha_Creacion, numeroVersion as version,Contenido as Contenido,idColaborador as Colaborador,estado as Estado
FROM Documento AS doc WHERE doc.estado = 0;
   
END
GO
Exec SP_listar_documentos_sin_aprobar


CREATE PROCEDURE SP_aprobar_doc
	@idDocumento AS INT,
	@estado AS BIT

AS
BEGIN

        UPDATE Documento SET	
							estado = @estado

		WHERE  idDocumento = @idDocumento

END
GO

Exec SP_aprobar_doc 1,0