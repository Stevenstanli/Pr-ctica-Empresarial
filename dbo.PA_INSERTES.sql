use [Practica_Empresarial]
go
Create procedure dbo.PA_InsertaHistoria
	--parametros
	@Historia varchar (500),
	@Mision varchar (500),
	@Vision varchar (500)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
	--Insertar datos en tabla [Historia]
	insert dbo.Historia values (@Historia,@Mision,@Vision,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaAyuda
	--parametros
	@Version_ varchar(25),
	@Manual_ varbinary (max)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Ayuda]
			insert dbo.Ayuda values (@Version_,@Manual_,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaCategoria
	--parametros
	@Nombre varchar (25)
as
BEGIN
	Declare
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Categoria]
			insert into dbo.Categoria values (@Nombre,@UltimoAcceso)
			
	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaPerfil
	--parametros
	@NombrePerfil varchar(25)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
	--Insertar datos en tabla [Perfil]
	insert dbo.Perfil values (@NombrePerfil,@UltimoAcceso)
	
	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaEstado
	--parametros
	@NombreEstado varchar(25)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
	--Insertar datos en tabla [Perfil]
	insert dbo.Estado values (@NombreEstado,@UltimoAcceso)
	
	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaImagen_
	--parametros
	@Imagen_ varbinary (max)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
	--Insertar datos en tabla [Imagen_]
	insert dbo.Imagen_ values (@Imagen_,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaProducto
	--parametros
	@ID_Categoria int,
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@Estado int
	
as
BEGIN
	DECLARE
	@UltimoAcceso datetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Producto]
			insert dbo.Producto values (@ID_Categoria,@ID_Imagen_,@Nombre,@Descripcion,@Estado,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaEvento
	--parametros
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@Estado int,
	@Fecha_Inicio smalldatetime,
	@Fecha_Final smalldatetime
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Evento]
			insert dbo.Evento values (@ID_Imagen_,@Nombre,@Descripcion,@Estado,@Fecha_Inicio,@Fecha_Final,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaPromocion
	--parametros
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@Estado int,
	@Fecha_Inicio smalldatetime,
	@Fecha_Final smalldatetime

as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime =GETDATE()
		BEGIN TRANSACTION
		--Insertar datos en tabla [Promocion]
		insert dbo.Promocion values (@ID_Imagen_,@Nombre,@Descripcion,@Estado,@Fecha_Inicio,@Fecha_Final,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaUsuario
	--parametros
	@ID_Perfil int,
	@Nombre varchar(25),
	@Apellido1 varchar(25),
	@Apellido2 varchar(25),
	@Estado int,
	@correo varchar(50)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE(),
	@Ultima_Modificacion smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Usuario]
			insert dbo.Usuario values (@ID_Perfil,@Nombre,@Apellido1,@Apellido2,
			@Estado,@correo,@UltimoAcceso,@Ultima_Modificacion)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaInicioSesion
	--parametros
	@ID_Usuario int,
	@contrasena varchar(500)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
	--Insertar datos en tabla [InicioSesion]
	insert dbo.InicioSesion values (@ID_Usuario,@contrasena,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaCotizacion
	--parametros
	@Nombre varchar(25),
	@Apellido1 varchar(25),
	@Apellido2 varchar(25),
	@Correo varchar (50),
	@Telefono int,
	@Asunto varchar(50),
	@Descripcion varchar(500)
as
BEGIN
	DECLARE
	@Fecha_Creacion smalldatetime = GETDATE(),
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Cotizacion]
			insert dbo.Cotizacion values (@Nombre,@Apellido1,@Apellido2,@Correo,@Telefono,@Asunto,@Descripcion,
				@Fecha_Creacion,@UltimoAcceso)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_InsertaCotizacionRespuesta
	--parametros
	@ID_Cotizacion int,
	@Asunto varchar(50),
	@Descripcion varchar(500)
as
BEGIN
	DECLARE
	@Fecha_Contestacion smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Insertar datos en tabla [Cotizacion]
			insert dbo.CotizacionRespuesta values (@ID_Cotizacion,@Asunto,@Descripcion,@Fecha_Contestacion)

	select SCOPE_IDENTITY();
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go