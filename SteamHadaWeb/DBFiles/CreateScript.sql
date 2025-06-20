--1
CREATE TABLE Noticia(
cod INT IDENTITY(1,1),
titulo VARCHAR(30),
cuerpo VARCHAR(100),
fecha date, 
hora time, 
foto VARCHAR(60),
url VARCHAR(60))

--2
CREATE TABLE Faqs(
cod INT IDENTITY(1,1) CONSTRAINT PK_Faqs PRIMARY KEY,
pregunta VARCHAR(200) NOT NULL,
respuesta VARCHAR(400))

--3
CREATE TABLE Oferta(
cod INT IDENTITY(1,1) CONSTRAINT PK_Oferta PRIMARY KEY,
titulo VARCHAR(30) NOT NULL,
cuerpo VARCHAR(1000),
fechaInicio date,
fechaExpiracion date)

--4
CREATE TABLE Evento(
cod INT IDENTITY(1,1) CONSTRAINT PK_Evento PRIMARY KEY, 
nombre VARCHAR(40),
descripcion VARCHAR(300), 
fechaInicio date,
horaInicio date, 
fechaFin date, 
horaFin time)

--5
CREATE TABLE Fisico(
evento INT CONSTRAINT PK_Fisico PRIMARY KEY, 
aforo INT,
localidad VARCHAR(40), 
provincia VARCHAR(40), 
direccion VARCHAR(100), 
precioEntrada DECIMAL(9,2),  
empresa VARCHAR(40), 
telefono VARCHAR(9),
email VARCHAR(30),
direccionEmpresa VARCHAR(100)
CONSTRAINT FK_Fisico_Evento 
	FOREIGN KEY(evento) 
	REFERENCES Evento(cod)
ON DELETE CASCADE ON UPDATE  CASCADE)

--6
CREATE TABLE Virtual(
evento INT CONSTRAINT PK_Virtual PRIMARY KEY,
autor VARCHAR(50), 
juego VARCHAR(50),
url VARCHAR(80),
CONSTRAINT FK_Virtual_Evento 
	FOREIGN KEY(evento) 
	REFERENCES Evento(cod)
ON DELETE CASCADE ON UPDATE  CASCADE)

--7
CREATE TABLE Producto(
id INT IDENTITY(1,1) CONSTRAINT PK_Producto PRIMARY KEY,
nombre VARCHAR(30),
descripcion VARCHAR(200),
imagen VARCHAR(40),
precio DECIMAL(9, 2),
fechaPublicacion DATE,
)

--8
CREATE TABLE Merchandising(
producto INT CONSTRAINT PK_Merchandising PRIMARY KEY,
peso DECIMAL(9,2),
volumen DECIMAL(9,2)
CONSTRAINT FK_Merchandising_Producto
    FOREIGN KEY(producto)
    REFERENCES Producto(id)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--9
CREATE TABLE Categoria(
nombre VARCHAR(30) CONSTRAINT PK_Categoria PRIMARY KEY,
descripcion VARCHAR(200) NOT NULL
)

--10
CREATE TABLE Juego(
producto INT CONSTRAINT PK_Juego PRIMARY KEY,
categoria VARCHAR(30), --NOT NULL
CONSTRAINT FK_Juego_Producto
    FOREIGN KEY (producto)
    REFERENCES Producto(id)
    ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Juego_Categoria
    FOREIGN KEY (categoria)
    REFERENCES Categoria(nombre)
    ON UPDATE CASCADE ON DELETE SET NULL
)

--11
CREATE TABLE Usuario (
correo VARCHAR(30) NOT NULL  CONSTRAINT PK_Usuario PRIMARY KEY,
nombre VARCHAR(10) NOT NULL,
apellidos VARCHAR(30) NOT NULL,
fechaIngreso date,
telefono VARCHAR(15),
contrasena VARCHAR(20) NOT NULL,
foto VARCHAR(40),
biografia VARCHAR(250)
)

--12
CREATE TABLE Cliente(
usuario VARCHAR(30) CONSTRAINT PK_Cliente PRIMARY KEY,
saldo int,
CONSTRAINT FK_Usuario_Cliente
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--13
CREATE TABLE Desarrollador(
usuario VARCHAR(30),
comison int,
CONSTRAINT PK_Desarrollador
    PRIMARY KEY(usuario),
CONSTRAINT FK_Desarrollador_Usuario
    FOREIGN KEY(usuario)
    REFERENCES Usuario(correo)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--14
CREATE TABLE Administrador(
usuario VARCHAR(30) CONSTRAINT PK_Administrador PRIMARY KEY,
CONSTRAINT FK_Administrador_Cliente
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--15
CREATE TABLE Sorteo(
cod INT IDENTITY(1,1) CONSTRAINT PK_Sorteo PRIMARY KEY,
nombre VARCHAR(50) NOT NULL,
descripcion VARCHAR(300) NOT NULL,
fechaHora DATETIME NOT NULL,
imagen VARCHAR(30) null,

administrador VARCHAR(30),
CONSTRAINT FK_Sorteo_Administrador
    FOREIGN KEY (administrador)
    REFERENCES Administrador(usuario)
    ON DELETE SET NULL ON UPDATE CASCADE
)

--16
CREATE TABLE Baneado(
usuario VARCHAR(30) CONSTRAINT PK_Baneado PRIMARY KEY,
causa VARCHAR(100),
fechaHora DATETIME,
fechaExpiracion DATE,
administrador VARCHAR(30), --NOT NULL
CONSTRAINT FK_Baneado_Usuario
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Baneado_Administrador
    FOREIGN KEY (administrador)
    REFERENCES Administrador(usuario)
    --ON DELETE SET NULL ON UPDATE CASCADE -- Error: may cause cycles or multiple cascade paths
)

--17
CREATE TABLE Pedido(
numPedido INT IDENTITY(1,1) CONSTRAINT PK_Pedido PRIMARY KEY,
fecha date, 
--lo añadido para que se compre un solo producto por compra
importe decimal(20, 2) NOT NULL, producto INT,
cliente varchar(30) CONSTRAINT FK_Cliente_Pedido 
	FOREIGN KEY (cliente) 
	REFERENCES Cliente(usuario),
--para referenciar el producto
CONSTRAINT FK_Pedido_Producto 
	FOREIGN KEY (producto) 
	REFERENCES Producto(id)	
on DELETE set NULL ON UPDATE CASCADE)


--SOY RAMA X7146766E SE NESESITA ESTA TABLA PARA BIBLIOTECA MUY IMPORTANTE 
CREATE TABLE Linped(
linea INT IDENTITY(1,1),
importe decimal(20,2) NOT NULL,
cantidad INT NOT NULL, 
numPedido INT,
producto INT NOT NULL
CONSTRAINT PK_Linped PRIMARY KEY(linea, numpedido),
CONSTRAINT FK_Linped_Pedido 
FOREIGN KEY (numPedido) 
REFERENCES Pedido(numPedido),
CONSTRAINT FK_Linped_Producto 
FOREIGN KEY (producto) 
REFERENCES Producto(id)
)

--19
CREATE TABLE Reclamacion(
cod INT IDENTITY(1,1) CONSTRAINT PK_Reclamacion PRIMARY KEY,
titulo VARCHAR(40) NOT NULL,
cuerpo VARCHAR(500) NOT NULL,
fechaHora datetime,
pedido INT CONSTRAINT FK_pedido_Pedido 
	FOREIGN KEY (pedido) 
	REFERENCES Pedido(numPedido)
CONSTRAINT UK_pedido_Pedido unique NOT NULL) --C.Alt)

--20
CREATE TABLE Sugerencia(
cod INT IDENTITY(1,1) CONSTRAINT PK_Sugerencia PRIMARY KEY,
titulo VARCHAR(80),
cuerpo VARCHAR(500),
usuario VARCHAR(30), --NOT NULL
CONSTRAINT FK_Sugerencia_Usuario
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    ON DELETE SET NULL ON UPDATE CASCADE
)

--21
CREATE TABLE HiloForo(
numero INT IDENTITY(1,1) CONSTRAINT PK_HiloForo PRIMARY KEY,
titulo VARCHAR(100) NOT NULL,
descripcion VARCHAR(800) NOT NULL,
fechaInicio DATETIME NOT NULL,
usuario VARCHAR(30), --NOT NULL
CONSTRAINT FK_HiloForo_Usuario
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    ON DELETE SET NULL ON UPDATE CASCADE
)

--22
CREATE TABLE Mensaje(
hiloForo INT,
cod INT,
mensaje VARCHAR(800) NOT NULL,
fechaHora DATETIME NOT NULL,
usuario VARCHAR(30), --NOT NULL
CONSTRAINT PK_Mensaje
    PRIMARY KEY (hiloForo, cod),
CONSTRAINT FK_Mensaje_HiloForo
    FOREIGN KEY (hiloForo)
    REFERENCES HiloForo(numero)
    ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Usuario
    FOREIGN KEY (usuario)
    REFERENCES Usuario(correo)
    --ON DELETE CASCADE ON UPDATE CASCADE --
)

--23
CREATE TABLE Valoracion(
id INT IDENTITY(1,1) CONSTRAINT PK_Valoracion PRIMARY KEY,
fecha DATE NOT NULL,
estrellas INT CONSTRAINT CHECK_BETWEEN_0_AND_5 CHECK (estrellas >= 0 and estrellas<=5) NOT NULL,
comentario VARCHAR(300)
)

--24
CREATE TABLE JuegosDesarrollados(
juego INT,
desarrollador VARCHAR(30),
CONSTRAINT PK_JuegosDesarrollados
    PRIMARY KEY (juego, desarrollador),
CONSTRAINT FK_JuegosDesarrollados_Juego
    FOREIGN KEY (juego)
    REFERENCES Juego(producto)
    ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_JuegosDesarrollados_Desarrollador
    FOREIGN KEY (desarrollador)
    REFERENCES Desarrollador(usuario)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--25
CREATE TABLE Biblioteca(
juego INT,
cliente VARCHAR(30),
fechaCompra DATE,
CONSTRAINT PK_Biblioteca
    PRIMARY KEY (juego, cliente),
CONSTRAINT FK_Biblioteca_Juego
    FOREIGN KEY (juego)
    REFERENCES Juego(producto)
    ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_Biblioteca_Cliente
    FOREIGN KEY (cliente)
    REFERENCES Cliente(usuario)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--26
CREATE TABLE ValorarJuego(
juego INT,
cliente VARCHAR(30),
valoracion INT CONSTRAINT UK_ValorarJuego UNIQUE NOT NULL, --C. Alt
CONSTRAINT PK_ValorarJuego
    PRIMARY KEY (juego),
CONSTRAINT FK_ValorarJuego_Biblioteca
    FOREIGN KEY (juego, cliente)
    REFERENCES Biblioteca(juego, cliente)
    ON DELETE CASCADE ON UPDATE CASCADE
)