CREATE PROCEDURE [dbo].actualizaJuego
@nombre varchar(30),
@descripcion varchar(200),
@precio decimal(9,2),
@foto varchar(30),
@categoria varchar(20)
AS

DECLARE @id int
	update Producto set descripcion=@descripcion, precio = @precio,imagen=@foto where nombre=@nombre ;
	select @id=id from Producto where nombre=@nombre;
	update Juego set categoria=@categoria where producto=@id;
	