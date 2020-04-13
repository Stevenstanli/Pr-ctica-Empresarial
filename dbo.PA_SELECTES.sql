use [Practica_Empresarial]
go
Create procedure dbo.PA_SelectHistoria
as
BEGIN
		BEGIN TRANSACTION
			-- Selecciona datos de la tabla [Historia]
			Select ID_Historia, Historia, Mision, Vision
				from dbo.Historia
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
create procedure dbo.PA_SelectAyuda
	--parametros
	@ID_Ayuda int
as
BEGIN
		BEGIN TRANSACTION
		-- Selecciona datos de la tabla [Ayuda]
		Select ID_Ayuda, Version_, Manual_
			from dbo.Ayuda
				where ID_Ayuda = CASE @ID_Ayuda
				WHEN -1 THEN ID_Ayuda ELSE @ID_Ayuda
				END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectCategoria
	--parametros
	@ID_Categoria int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Categoria]
			Select ID_Categoria, NombreCategoria
				from Categoria
					where ID_Categoria = CASE @ID_Categoria
						WHEN -1 THEN ID_Categoria ELSE @ID_Categoria
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectPerfil
	--parametros
	@ID_Perfil int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Perfil]
			Select ID_Perfil, NombrePerfil
				from dbo.Perfil
					where ID_Perfil = CASE @ID_Perfil
						WHEN -1 THEN ID_Perfil ELSE @ID_Perfil
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectEstado
	--parametros
	@ID_Estado int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Estado]
			Select ID_Estado, NombreEstado
				from dbo.Estado
					where ID_Estado = CASE @ID_Estado
						WHEN -1 THEN ID_Estado ELSE @ID_Estado
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectImagen_
	--parametros
	@ID_Imagen_ int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Imagen]
			Select ID_Imagen_, Imagen_
				from Imagen_
					where ID_Imagen_ = CASE @ID_Imagen_
						WHEN -1 THEN ID_Imagen_ ELSE @ID_Imagen_
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectProductosXCategoria
	--parametros
	@ID_Categoria int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Producto] por su categoria
			Select P.ID_Producto,P.ID_Categoria,I.Imagen_,P.NombreProducto,P.Descripcion,E.NombreEstado
				from Producto P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = i.ID_Imagen_ inner join dbo.Estado E
						on P.ID_Estado = E.ID_Estado
							where ID_Categoria = CASE @ID_Categoria 
								WHEN -1 THEN ID_Producto ELSE @ID_Categoria
								END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectProductosXCategoriaXEstado
	--parametros
	@ID_Categoria int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Producto] por su categoria
			Select P.ID_Producto,P.ID_Categoria,I.Imagen_,P.NombreProducto,P.Descripcion
				from Producto P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = i.ID_Imagen_ 
						where P.ID_Categoria = @ID_Categoria AND P.ID_Estado = 1
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectProductos
	--parametros
	@ID_Producto int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Producto]
			Select P.ID_Producto, C.NombreCategoria, I.Imagen_,P.NombreProducto, P.Descripcion, E.NombreEstado
				from Producto P inner join dbo.Categoria C
					on P.ID_Categoria = C.ID_Categoria inner join dbo.Imagen_ I
						on P.ID_Imagen_ = i.ID_Imagen_ inner join dbo.Estado E
							on P.ID_Estado = E.ID_Estado
								where ID_Producto = CASE @ID_Producto
									WHEN -1 THEN ID_Producto ELSE @ID_Producto
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectProductoVerificacion
	--parametros
	@ID_Producto int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Producto]
			Select P.ID_Producto, P.ID_Categoria, P.ID_Imagen_, I.Imagen_,P.NombreProducto, P.Descripcion, P.ID_Estado
				from Producto P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = i.ID_Imagen_ 
						where ID_Producto = @ID_Producto
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectProductosXEstado
	--parametros
	@ID_Producto int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Producto]
			Select P.ID_Producto, I.Imagen_,P.NombreProducto, P.Descripcion
				from Producto P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = i.ID_Imagen_ 
						where P.ID_Estado = 1
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectEvento
	--parametros
	@ID_Evento int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Evento]
			Select E.ID_Evento, I.Imagen_, E.NombreEvento, E.Descripcion, ES.NombreEstado, E.Fecha_Inicio, E.Fecha_Final
				from dbo.Evento E inner join dbo.Imagen_ I
					on E.ID_Imagen_ = I.ID_Imagen_ inner join dbo.Estado ES
						on E.ID_Estado = ES.ID_Estado
							where E.ID_Evento = CASE @ID_Evento
								WHEN -1 THEN E.ID_Evento ELSE @ID_Evento
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectEventoVerificacion
	--parametros
	@ID_Evento int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Evento]
			Select E.ID_Evento, E.ID_Imagen_, I.Imagen_, E.NombreEvento, E.Descripcion, E.ID_Estado, E.Fecha_Inicio, E.Fecha_Final
				from dbo.Evento E inner join dbo.Imagen_ I
					on E.ID_Imagen_ = I.ID_Imagen_
						where E.ID_Evento = @ID_Evento
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectEventoXEstado
	--parametros
	@ID_Evento int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Evento]
			Select E.ID_Evento, I.Imagen_, E.NombreEvento, E.Descripcion, E.Fecha_Inicio, E.Fecha_Final
				from dbo.Evento E inner join dbo.Imagen_ I
					on E.ID_Imagen_ = I.ID_Imagen_ 
						where E.ID_Estado = 1
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectPromocion
	--parametros
	@ID_Promocion int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Promoción]
			Select P.ID_Promocion, I.Imagen_, P.NombrePromocion, P.Descripcion, E.NombreEstado, P.Fecha_Inicio, P.Fecha_Final
				from dbo.Promocion P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = I.ID_Imagen_ inner join dbo.Estado E
						on P.ID_Estado = E.ID_Estado
							where P.ID_Promocion = CASE @ID_Promocion
								WHEN -1 THEN P.ID_Promocion ELSE @ID_Promocion
								END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectPromocionVerificacion
	--parametros
	@ID_Promocion int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Promoción]
			Select P.ID_Promocion,P.ID_Imagen_, I.Imagen_, P.NombrePromocion, P.Descripcion, P.ID_Estado, P.Fecha_Inicio, P.Fecha_Final
				from dbo.Promocion P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = I.ID_Imagen_
						where P.ID_Promocion = @ID_Promocion
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectPromocionXEstado
	--parametros
	@ID_Promocion int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar los datos en la tabla [Promoción]
			Select P.ID_Promocion, I.Imagen_, P.NombrePromocion, P.Descripcion, P.Fecha_Inicio, P.Fecha_Final
				from dbo.Promocion P inner join dbo.Imagen_ I
					on P.ID_Imagen_ = I.ID_Imagen_
						where P.ID_Estado = 1
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectUsuario
	--parametros
	@ID_Usuario int
as
BEGIN
		BEGIN TRANSACTION
		-- Selecciona datos de la tabla [Usuario]
		Select U.ID_Usuario, U.ID_Perfil,P.NombrePerfil, U.NombreUsuario, U.Apellido1, U.Apellido2, E.NombreEstado, U.correo
			from dbo.Usuario U inner join dbo.Perfil P
				on U.ID_Perfil = P.ID_Perfil inner join dbo.Estado E
					on U.ID_Estado = E.ID_Estado
						where U.ID_Usuario = CASE @ID_Usuario
							WHEN -1 THEN U.ID_Usuario ELSE @ID_Usuario
							END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectUsuarioVerificar
	--parametros
	@ID_Usuario int
as
BEGIN
		BEGIN TRANSACTION
		-- Selecciona datos de la tabla [Usuario]
		Select U.ID_Usuario, U.ID_Perfil, U.NombreUsuario, U.Apellido1, U.Apellido2, U.ID_Estado, U.correo
			from dbo.Usuario U
				where U.ID_Usuario = @ID_Usuario
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectInicioSesion
	--parametros
	@Correo varchar (50),
	@Contrasena varchar(500)
as
BEGIN
		BEGIN TRY
		-- Selecciona datos de la tabla [Usuario, InicioSesion]
		select U.ID_Usuario, U.NombreUsuario, U.ID_Estado, U.ID_Perfil
			from dbo.Usuario U inner join dbo.InicioSesion I
				on U.ID_Usuario = I.ID_InicioSesion
					where U.correo = @Correo and I.contrasena = @Contrasena
		END TRY
		BEGIN CATCH
			RETURN -1
		END CATCH
END
go
Create procedure dbo.PA_SelectCotizacion
	--parametros
	@ID_Cotizacion int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar datos en tabla [Cotizacion]
			select ID_Cotizacion, Nombre, Apellido1, Apellido2, Correo, Telefono, Asunto, Descripcion, Fecha_Creacion
				from dbo.Cotizacion
					where ID_Cotizacion = CASE @ID_Cotizacion
						WHEN -1 THEN ID_Cotizacion ELSE @ID_Cotizacion
			END
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectCotizacionRespuesta
	--parametros
	@ID_Cotizacion int
as
BEGIN
		BEGIN TRANSACTION
			--Seleccionar datos en tabla [Cotizacion]
			select ID_CotizacionRespuesta, Asunto, Descripcion, Fecha_Contestacion
				from dbo.CotizacionRespuesta
					where ID_Cotizacion = @ID_Cotizacion
	IF @@ERROR = 0
	COMMIT TRANSACTION
	ELSE
	ROLLBACK TRANSACTION
END
go
Create procedure dbo.PA_SelectCorreoVerificacion
	--parametros
	@Correo varchar (50)
as
BEGIN
		BEGIN TRY
		-- Selecciona datos de la tabla [Usuario, InicioSesion]
		select U.ID_Usuario
			from dbo.Usuario U 
				where U.correo = @Correo 
		END TRY
		BEGIN CATCH
			RETURN -1
		END CATCH
END
go
