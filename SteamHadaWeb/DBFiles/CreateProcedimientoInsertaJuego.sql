CREATE PROCEDURE [dbo].insertaJuego
@nombre varchar(30),
@descripcion varchar(200),
@precio decimal(9,2),
@foto varchar(30),
@categoria varchar(30),
@correo varchar(30)
AS

DECLARE @id int
	insert into Producto("nombre","descripcion","precio","fechaPublicacion","imagen") values(@nombre,@descripcion,@precio,GETDATE(),@foto);
	select @id=id from Producto where nombre=@nombre;
	insert into Juego values(@id,@categoria,@foto);
	insert into JuegosDesarrollados values(@id,@correo);
