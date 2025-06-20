CREATE PROCEDURE [dbo].insertaCliente
@correo varchar(30),
@nombre varchar(10),
@apellidos varchar(20),
@telefono varchar(15),
@contrasena varchar(20),
@foto varchar(40),
@biografia varchar(250)
AS
begin
	insert Usuario values(@correo,@nombre,@apellidos,GETDATE(),@telefono,@contrasena,@foto,@biografia);
	insert Cliente values(@correo,0);
end;


