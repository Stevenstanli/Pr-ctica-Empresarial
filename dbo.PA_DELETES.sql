use [Practica_Empresarial]
go
create procedure dbo.PA_EliminarHistoria
	--parametros
	@ID_Historia int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Historia]
		delete from dbo.Historia where ID_Historia = @ID_Historia
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarAyuda
	--parametros
	@ID_Ayuda int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Ayuda]
		delete from dbo.Ayuda where ID_Ayuda = @ID_Ayuda
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarImagen
	--parametros
	@ID_Imagen_ int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Imagen]
		delete from dbo.Imagen_ where ID_Imagen_ = @ID_Imagen_
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarCategoria
	--parametros
	@ID_Categoria int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Categoria]
		delete from dbo.Categoria where ID_Categoria = @ID_Categoria
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarPerfil
	--parametros
	@ID_Perfil int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Perfil]
		delete from dbo.Perfil where ID_Perfil = @ID_Perfil
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarEstado
	--parametros
	@ID_Estado int
as
BEGIN
	BEGIN TRY
		--Borrara datos de tabla [Estado]
		delete from dbo.Estado where ID_Estado = @ID_Estado
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarProducto
	--parametros
	@ID_Producto int,
	@ID_Imagen_ int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [Imagen]
		delete from dbo.Imagen_ where ID_Imagen_ = @ID_Imagen_
		--Borrara datos de tabla [Producto]
		delete from dbo.Producto where ID_Producto = @ID_Producto
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarEvento
	--parametros
	@ID_Evento int,
	@ID_Imagen_ int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [Imagen]
		delete from dbo.Imagen_ where ID_Imagen_ = @ID_Imagen_
		--Borrara datos de tabla [Evento]
		delete from dbo.Evento where ID_Evento = @ID_Evento
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarPromocion
	--parametros
	@ID_Promocion int,
	@ID_Imagen_ int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [Imagen]
		delete from dbo.Imagen_ where ID_Imagen_ = @ID_Imagen_
		--Borrara datos de tabla [Promocion]
		delete from dbo.Promocion where ID_Promocion = @ID_Promocion
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarUsuario
	--parametros
	@ID_Usuario int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [Imagen]
		delete from dbo.InicioSesion where ID_Usuario = @ID_Usuario
		--Borrara datos de tabla [Usuario]
		delete from dbo.Usuario where ID_Usuario = @ID_Usuario
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarCotizacion
	--parametros
	@ID_Cotizacion int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [CotizacionRespuesta]
		delete from dbo.CotizacionRespuesta where ID_Cotizacion = @ID_Cotizacion
		--Borrara datos de tabla [Cotizacion]
		delete from dbo.Cotizacion where ID_Cotizacion = @ID_Cotizacion
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go
create procedure dbo.PA_EliminarCotizacionRespuesta
	--parametros
	@ID_CotizacionRespuesta int
as
BEGIN
	BEGIN TRY
		--Borrará datos de tabla [CotizacionRespuesta]
		delete from dbo.CotizacionRespuesta where ID_CotizacionRespuesta = @ID_CotizacionRespuesta
		select 1
	END TRY
	BEGIN CATCH
		select 0
	END CATCH
END
go