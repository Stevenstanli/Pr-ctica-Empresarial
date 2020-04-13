Create database Practica_Empresarial
go
use [Practica_Empresarial]
go
Create table dbo.Historia(
ID_Historia tinyint primary key identity not null,
Historia varchar (500) not null,
Mision varchar (500) not null,
Vision varchar (500) not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Categoria(
ID_Categoria int primary key identity not null,
NombreCategoria varchar (25) not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Imagen_(
ID_Imagen_ int primary key identity not null,
Imagen_ varbinary (max) not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Estado(
ID_Estado int primary key identity not null,
NombreEstado varchar (25) not null,
Ultima_Modificacion smalldatetime not null
)
Create table dbo.Producto(
ID_Producto int primary key identity not null,
ID_Categoria int foreign key (ID_Categoria) references dbo.Categoria not null,
ID_Imagen_ int foreign key (ID_Imagen_) references dbo.Imagen_ not null,
NombreProducto varchar (25) not null,
Descripcion varchar (50) not null,
ID_Estado int foreign key (ID_Estado) references dbo.Estado not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Evento(
ID_Evento int primary key identity not null,
ID_Imagen_ int foreign key (ID_Imagen_) references dbo.Imagen_ not null,
NombreEvento varchar (25) not null,
Descripcion varchar (50) not null,
ID_Estado int foreign key (ID_Estado) references dbo.Estado not null,
Fecha_Inicio smalldatetime not null,
Fecha_Final smalldatetime not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Promocion(
ID_Promocion int primary key identity not null,
ID_Imagen_ int foreign key (ID_Imagen_) references dbo.Imagen_ not null,
NombrePromocion varchar (25) not null,
Descripcion varchar (50) not null,
ID_Estado int foreign key (ID_Estado) references dbo.Estado not null,
Fecha_Inicio smalldatetime not null,
Fecha_Final smalldatetime not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Perfil(
ID_Perfil int primary key identity not null,
NombrePerfil varchar (25) not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Usuario(
ID_Usuario int primary key identity not null,
ID_Perfil int foreign key (ID_Perfil) references dbo.Perfil not null,
NombreUsuario varchar (25) not null,
Apellido1 varchar (25) not null,
Apellido2 varchar (25) not null,
ID_Estado int foreign key (ID_Estado) references dbo.Estado not null,
correo varchar (50) not null,
Ultimo_Acceso smalldatetime not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.InicioSesion(
ID_InicioSesion int primary key identity not null,
ID_Usuario int foreign key (ID_Usuario) references dbo.Usuario not null,
Contrasena varchar(500) not null,
Ultima_Modificacion smalldatetime not null
)
go
Create table dbo.Cotizacion(
ID_Cotizacion int primary key identity not null,
Nombre varchar (25) not null,
Apellido1 varchar (25) not null,
Apellido2 varchar (25) not null,
Correo varchar (50) not null,
Telefono int not null,
Asunto varchar (50) not null,
Descripcion varchar (500) not null,
Fecha_Creacion smalldatetime not null,
Ultimo_Acceso smalldatetime not null
)
go
Create table dbo.CotizacionRespuesta(
ID_CotizacionRespuesta int primary key identity not null,
ID_Cotizacion int foreign key (ID_Cotizacion) references dbo.Cotizacion not null,
Asunto varchar (50) not null,
Descripcion varchar (500) not null,
Fecha_Contestacion smalldatetime not null
)
go
Create table dbo.Ayuda(
ID_Ayuda int primary key identity not null,
Version_ varchar (25) not null,
Manual_ varbinary (max) not null,
Ultima_Modificacion smalldatetime not null
)
go