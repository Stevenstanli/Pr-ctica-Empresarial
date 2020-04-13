use [Practica_Empresarial]
go
create procedure dbo.PA_ActualizarHistoria
	--parametros
	@ID_Historia int,
	@Historia varchar (500),
	@Mision varchar (500),
	@Vision varchar (500)

as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Historia]
			update dbo.Historia set Historia = @Historia,Mision = @Mision,Vision = @Vision, Ultima_Modificacion = @UltimoAcceso
				where ID_Historia = @ID_Historia

			select @ID_Historia
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarAyuda
	--parametros
	@ID_Ayuda int,
	@Version_ varchar(25),
	@Manual_ varbinary (max)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()	
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Ayuda]
			update dbo.Ayuda set Version_ = @Version_,Manual_ = @Manual_ ,Ultima_Modificacion = @UltimoAcceso
				where ID_Ayuda = @ID_Ayuda

			select @ID_Ayuda
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarCategoria
	--parametros
	@ID_Categoria int,
	@NombreCategoria varchar (25)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Categoria]
			update dbo.Categoria set NombreCategoria = @NombreCategoria, Ultima_Modificacion = @UltimoAcceso
				where ID_Categoria = @ID_Categoria

			select @ID_Categoria
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarPerfil
	--parametros
	@ID_Perfil int,
	@NombrePerfil varchar(25)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Perfil]
			update dbo.Perfil set NombrePerfil = @NombrePerfil, Ultima_Modificacion = @UltimoAcceso
				where ID_Perfil = @ID_Perfil

				select @ID_Perfil
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarEstado
	--parametros
	@ID_Estado int,
	@NombreEstado varchar(50)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Perfil]
			update dbo.Estado set NombreEstado = @NombreEstado, Ultima_Modificacion = @UltimoAcceso
				where ID_Estado = @ID_Estado

				select @ID_Estado
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarImagen_
	--parametros
	@ID_Imagen_ int,
	@Imagen_ varbinary (max)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Imagen_]
			update dbo.Imagen_ set Imagen_ = @Imagen_, Ultima_Modificacion = @UltimoAcceso
				where ID_Imagen_ = @ID_Imagen_

			select @ID_Imagen_
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarProducto
	--parametros
	@ID_Producto int,
	@ID_Categoria int,
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@ID_Estado int
as
BEGIN
	DECLARE
	@UltimoAcceso datetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Producto]
			update dbo.Producto set ID_Categoria = @ID_Categoria, ID_Imagen_ = @ID_Imagen_, NombreProducto = @Nombre, Descripcion = @Descripcion , ID_Estado = @ID_Estado , Ultima_Modificacion = @UltimoAcceso
				where ID_Producto = @ID_Producto

				select  @ID_Producto
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarEvento
	--parametros
	@ID_Evento int,
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@ID_Estado int,
	@Fecha_Inicio smalldatetime,
	@Fecha_Final smalldatetime
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Evento]
			update dbo.Evento set ID_Imagen_ = @ID_Imagen_, NombreEvento = @Nombre, Descripcion = @Descripcion, ID_Estado = @ID_Estado, Fecha_Inicio = @Fecha_Inicio, Fecha_Final = @Fecha_Final, Ultima_Modificacion = @UltimoAcceso
				where ID_Evento = @ID_Evento

			select @ID_Evento
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarPromocion
	--parametros
	@ID_Promocion int,
	@ID_Imagen_ int,
	@Nombre varchar(25),
	@Descripcion varchar(50),
	@ID_Estado int,
	@Fecha_Inicio smalldatetime,
	@Fecha_Final smalldatetime
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Promocion]
			update dbo.Promocion set ID_Imagen_ = @ID_Imagen_, NombrePromocion = @Nombre, Descripcion = @Descripcion, ID_Estado = @ID_Estado, Fecha_Inicio = @Fecha_Inicio, Fecha_Final = @Fecha_Final, Ultima_Modificacion = @UltimoAcceso
				where ID_Promocion = @ID_Promocion

			select @ID_Promocion
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarUsuario
	--parametros
	@ID_Usuario int,
	@ID_Perfil tinyint,
	@Nombre varchar(25),
	@Apellido1 varchar(25),
	@Apellido2 varchar(25),
	@ID_Estado int,
	@correo varchar(50)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE(),
	@Ultima_Modificacion smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Usuario]
			update dbo.Usuario set ID_Perfil = @ID_Perfil, NombreUsuario = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2,ID_Estado = @ID_Estado, 
			correo = @correo, Ultimo_Acceso = @UltimoAcceso, Ultima_Modificacion = @Ultima_Modificacion
				where ID_Usuario = @ID_Usuario

			select @ID_Usuario
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarContrasena
	--parametros
	@ID_Usuario int,
	@Contrasena varchar(500)
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [InicioSesion]
			update dbo.InicioSesion set Contrasena = @Contrasena, Ultima_Modificacion = @UltimoAcceso
				where ID_Usuario = @ID_Usuario

			select @ID_Usuario
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_ActualizarCotizacion
	--parametros
	@ID_Cotizacion int
as
BEGIN
	DECLARE
	@UltimoAcceso smalldatetime = GETDATE()
		BEGIN TRANSACTION
			--Actualizar datos en tabla [Cotizacion]
			update dbo.Cotizacion set Ultimo_Acceso = @UltimoAcceso
				where ID_Cotizacion = @ID_Cotizacion
			select @ID_Cotizacion
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go