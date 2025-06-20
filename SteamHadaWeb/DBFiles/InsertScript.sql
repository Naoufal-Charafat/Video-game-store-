
--Usuarios 
-- NOTA::      LOS PONGO COMO COMENTARIO PORQUE NORMALMENTE LOS USUARIOS SE REGISTRAN ELLOS MISMOS ATRAVES DE LA WEB

insert into Usuario("correo","nombre","apellidos","fechaIngreso","telefono","contrasena","foto","biografia")
values ('BoChen@juegos.es','KIKE','CHARAFAT','2012-02-21T18:10:00','699655421','123456789','imagenes/avatar.png','NADA');

insert into Usuario("correo","nombre","apellidos","fechaIngreso","telefono","contrasena","foto","biografia") 
values ('alguien123@gmail.com','Luis','González Bartolomé','2013-02-21T18:10:00','699655000','123456789','imagenes/avatar.png','Me encanta BoGames!');

insert into Usuario("correo","nombre","apellidos","fechaIngreso","telefono","contrasena","foto","biografia") 
values ('BoChen2@juegos.es','JOSE','FERNAND','2012-03-21T18:10:00','639555421','123456789','avatar.png','NADA');

insert into Usuario("correo","nombre","apellidos","fechaIngreso","telefono","contrasena","biografia", "foto") values ('ash31@alu.ua.es', 'Adrián', 'Sánchez Hernández', '2019-05-23','999999995', '123456', 'hola :)', 'imagenes/antiGames.jpg');
Insert into Cliente(usuario, saldo) values ('ash31@alu.ua.es', 0);
INSERT INTO Cliente ("usuario","saldo") VALUES ('BoChen@juegos.es','50')
INSERT INTO Cliente ("usuario","saldo") VALUES ('alguien123@gmail.com','17')
INSERT INTO Cliente ("usuario","saldo") VALUES ('BoChen2@juegos.es','50')

INSERT INTO Categoria(nombre, descripcion) VALUES ('Acción', 'Juegos para poner a prueba las habilidades del gamer como su velocidad y destreza');
INSERT INTO Categoria(nombre, descripcion) VALUES ('Aventuras', 'Juegos con tramas y ambientes desarrollados'); 
INSERT INTO Categoria(nombre, descripcion) VALUES ('Deportes', 'Juegos de deportes tales como futbol, tenis, bolos...');
INSERT INTO Categoria(nombre, descripcion) VALUES ('Disparos', 'Juegos de armas tanto en primera personna como en tercera');

--PRODUCTOS

INSERT INTO Producto ("nombre","descripcion","precio","fechaPublicacion", "imagen") VALUES('One Piece World Seeker','Juego de piratas','15','2019-03-13', '11.png');
INSERT INTO Producto ("nombre","descripcion","precio","fechaPublicacion", "imagen") VALUES('Call of dutty','Juego de disparos','15','2019-09-12', '22.png');
INSERT INTO Producto ("nombre","descripcion","precio","fechaPublicacion", "imagen") VALUES('GTA5','Juego del año','15','2019-03-13', '11.png');
INSERT INTO Producto ("nombre","descripcion","precio","fechaPublicacion", "imagen") VALUES('Camiseta PLMAN','Camiseta del año','15','2019-03-13', 'plmanCamiseta.png');
INSERT INTO Juego ("producto","categoria") VALUES('1','Acción');
INSERT INTO Juego ("producto","categoria") VALUES('2','Disparos');
INSERT INTO Juego ("producto","categoria") VALUES('3','Disparos');
insert into Merchandising values(4,20,20);
INSERT INTO HiloForo(titulo, descripcion, fechaInicio, usuario) values ('Inaugurado el foro de Bogames', 'Por fin ya tenemos foro y funcionando:)', '2019-05-23T19:33:00', 'ash31@alu.ua.es')
INSERT INTO HiloForo(titulo, descripcion, fechaInicio, usuario) values ('NORMAS DEL FORO', 'Queridos BoGamers, como en toda comunidad en la nuestra también existen normas que detallaremos como sigue: <br/> 1. NO SE ESCRIBE EN MAYÚSCULAS <br/> 2. No se permiten comentarios obscenos o inapropiados. El respeto es lo primero <br/> 3. No hacer spam', '2019-05-23T21:15:26', 'ash31@alu.ua.es')
INSERT INTO HiloForo(titulo, descripcion, fechaInicio, usuario) values ('La adicción a los videojuegos y otros hábitos de escapismo', 'No va en broma el asunto. Si estás cansado descansa si no no te pongas excusas y haz lo que te combiene. Déjate las videojuegos, los logros no son reales.', '2019-05-23T21:33:20', 'ash31@alu.ua.es')
INSERT INTO HiloForo(titulo, descripcion, fechaInicio, usuario) values ('Trucos del GTA SA', 'Aquí podéis ir consultando y añadiendo los que encontreis', '2019-05-24T15:33:55', 'BoChen@juegos.es')
INSERT INTO HiloForo(titulo, descripcion, fechaInicio, usuario) values ('Vendo Seat Ibiza semi-nuevo 95.000 km gasolina URGE', 'Vendo Seat Ibiza semi-nuevo 95.000 km. SI ESTÁIS INTERESADOS LLAMARME A MI TELEFONO', '2019-05-24T18:25:05', 'alguien123@gmail.com')
INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (1,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 1),
		'Inaugurado el foro de Bogames',
		'2019-05-23T19:35:24',
		'ash31@alu.ua.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (1,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 1),
		'Hola a todos los usuarios, ¿qué tal por BoGames?',
		'2019-05-23T19:38:24',
		'ash31@alu.ua.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (1,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 1),
		'Nos encanta que podáis disfrutar del foro, si alguien tiene sugerencias estamos encantados de escucharlas',
		'2019-05-23T19:35:24',
		'ash31@alu.ua.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (2,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 2),
		'Enserio no se pueden usar mayúsculas?',
		'2019-05-23T22:35:24',
		'BoChen@juegos.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (2,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 2),
		'No, es MUY AGRESIVO',
		'2019-05-23T22:35:24',
		'alguien123@gmail.com')

		
INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (2,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 2),
		'Agresivo? jajajaja. Bueno, habrá que seguir las normas',
		'2019-05-23T22:35:24',
		'BoChen@juegos.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (2,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 2),
		'Tampoco te preocupes, no es algo personal. Pero no queda muy bien',
		'2019-05-23T22:35:24',
		'alguien123@gmail.com')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (3,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 3),
		'BoGamers, con todo el aprecio que os tengo os aviso de las consecuencias que tienen las addicciones entre ellas a los videojuegos',
		'2019-05-23T19:35:24',
		'ash31@alu.ua.es')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (4,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 4),
		'Yo usaba hesoyam para la vida y el dinero',
		'2019-05-23T19:35:24',
		'BoChen@juegos.es')
INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (4,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 4),
		'Es verdad qué recuerdos',
		'2019-05-23T19:35:24',
		'alguien123@gmail.com')

INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (5,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 5),
		'¿Qué crees que es esto, Forocoches? Reportado a la comunidad',
		'2019-05-23T19:35:24',
		'ash31@alu.ua.es')
INSERT INTO Mensaje(hiloForo, cod, mensaje, fechaHora, usuario)
	values (5,
		1 + (select ISNULL(max(cod), 0) from Mensaje where hiloForo = 5),
		'jajajajajajaj',
		'2019-05-23T19:35:24',
		'alguien123@gmail.com')


--JUEGO







--Cliente
-- NOTA::      LOS PONGO COMO COMENTARIO PORQUE NORMALMENTE se hace a nivel de programacion



--Pedido

--pedido del cliente [KIKE_CHARAFAT]
insert into Pedido("fecha","cliente", "importe", "producto") values('2012-02-22T18:10:00','BoChen2@juegos.es', '30', '1' )
insert into Pedido("fecha","cliente", "importe", "producto") values('2012-02-22T18:10:00','BoChen2@juegos.es', '45.00', '2')
insert into Pedido("fecha","cliente", "importe", "producto") values('2012-02-22T18:10:00','BoChen2@juegos.es', '3', '3')

--Linped

--insert into Linped("importe","cantidad","numPedido","producto") values('30','1','1','6')
--insert into Linped("importe","cantidad","numPedido","producto") values('30','1','1','7')


--FAQ
insert into Faqs("pregunta", "respuesta") values('¿Cómo participar en el foro?', 'Debes estar loggeado')


--Sorteo
--sorteo 1
INSERT INTO Sorteo ("nombre","descripcion","imagen","fechaHora")
VALUES('!!!Sorteamos PlayStation 4¡¡¡',
'¡Hola a todos!
Estamos a finales de mayo y aún estamos un poco de resaca después 
del lanzamiento de God of War, el cual nos ha encantado y,
por eso mismo, queremos sortear una copia entre todos nuestros 
seguidores. Si queréis saber más sobre el título podéis leer 
nuestro análisis.',
'sorteogodOFwar.jpg',
'2019-05-02T18:10:00')

--sorteo 2
INSERT INTO Sorteo ("nombre","descripcion","imagen","fechaHora")
VALUES('!!!Sorteamos Pubg lite¡¡¡',
'¡Hola a todos!
En esta ocasión sortearemos un clave digital de PlayerUnknown’s Battlegrounds para Steam (PC), por lo cual solo habrá un ganador en este sorteo.
El ganador recibirá el título de manera digital, que podrá ser canjeado en Steam.',
'sorteoPUBGlite.jpg',
'2019-05-10T18:10:00')

--sorteo 3
INSERT INTO Sorteo ("nombre","descripcion","imagen","fechaHora")
VALUES('!!!Sorteamos  PlayStatio¡¡',
'A pesar de que tenemos un sorteo en marcha, creemos que esto no es suficiente, 
y gracias a Av a n c e, que muy amablemente nos han cedido cuatro juegos para sortear,
hemos querido seguir agradeciéndoos todo lo que nos habéis ayudado a conseguir, 
con algún que otro premio más.',
'sorteoPACK2juegos.jpg',
'2019-05-15T18:10:00')

--sorteo 4
INSERT INTO Sorteo ("nombre","descripcion","imagen","fechaHora")
VALUES('!!!Sorteamos VIDEO JUEGOS¡¡¡',
'Sorteamos todos estos juegos solo hace falta darle a like y suscribanse XD XD XD XD.',
'sorteo_varios juegos.jpg',
'2019-05-16T18:10:00')
--Biblioteca  
insert Biblioteca values(1,'bo_el_mejor@hotmail.com',CURRENT_TIMESTAMP)
insert Biblioteca values(2,'bo_el_mejor@hotmail.com',CURRENT_TIMESTAMP)
insert Biblioteca values(3,'bo_el_mejor@hotmail.com',CURRENT_TIMESTAMP)
--Pedido
insert Pedido values(CURRENT_TIMESTAMP,10,1,'bo_el_mejor@hotmail.com')
insert Pedido values(CURRENT_TIMESTAMP,20,2,'bo_el_mejor@hotmail.com')
insert Pedido values(CURRENT_TIMESTAMP,20,3,'bo_el_mejor@hotmail.com')
GO
--Eventos
SET IDENTITY_INSERT Evento ON
insert into Evento ("cod", "nombre", "descripcion")
values ('01',
'E3 Ubisoft',
'Presentamos nuevo Assassins Creed y más sorpresas...')
GO
insert into Fisico ("evento", "localidad", "provincia", "precioEntrada", "telefono", "email")
values ('01',
'Alicante',
'Provincia',
'50',
'965487699',
'ubisoft@gmail.com')
GO
insert into Evento ("cod") values ('02')
GO
insert into Virtual ("evento", "juego", "autor", "url")
values ('02',
'Death Stranding',
'Hideo Kojima',
'https://www.youtube.com/embed/voMw7-OiOhg')

													--------------LOS SELECT--------------

--PARA LA BIBLIOTECA
--select DISTINCT  pr.nombre, j.categoria, pr.descripcion,pr.imagen
	--from Producto pr,  Juego j,  Pedido pe,  Linped l 
	--where  pe.cliente='BoChen2@juegos.es' and pe.numPedido=l.numPedido and l.producto=pr.id and pr.id=j.producto ;