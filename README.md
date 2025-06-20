# 🎮 BoGames - Plataforma de Videojuegos Online

![ASP.NET](https://img.shields.io/badge/ASP.NET-4.6.1-blue)
![C#](https://img.shields.io/badge/C%23-7.0-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-red)
![Bootstrap](https://img.shields.io/badge/Bootstrap-3.2.0-purple)

## 📝 Descripción

**BoGames** es una plataforma web completa de comercio electrónico especializada en videojuegos, similar a Steam. Desarrollada con ASP.NET Web Forms, ofrece una experiencia integral para jugadores, desarrolladores y administradores.

## 🌟 Características Principales

### 🛒 **Tienda Online**
- 📂 Catálogo de juegos organizado por categorías:
  - 🔫 Acción
  - 🗺️ Aventuras  
  - 🎯 Disparos
  - ⚽ Deportes
- 🎁 Sección de merchandising
- 🔍 Sistema de búsqueda y filtrado avanzado
- 💰 Carrito de compras integrado

### 👤 **Sistema de Usuarios**
- 📝 Registro tradicional con email
- 📘 Login con Facebook integrado
- 👨‍💻 Tres tipos de usuarios:
  - 🎮 **Cliente**: Compra juegos y productos
  - 💻 **Desarrollador**: Sube y gestiona sus juegos
  - 👮 **Administrador**: Control total del sistema
- 🖼️ Personalización de perfil con avatar
- 💸 Sistema de saldo para clientes

### 🎯 **Funcionalidades Especiales**

#### 📚 **Biblioteca Personal**
- 🎮 Acceso a todos los juegos comprados
- 📊 Visualización organizada en grid

#### 💬 **Comunidad**
- 🗣️ **Foro**: Sistema completo de hilos y mensajes
- 🎪 **Eventos**: 
  - 🏢 Eventos físicos (conferencias, torneos)
  - 📹 Eventos virtuales (videos, streams)
- 🎰 **Sorteos**: Participación en sorteos de juegos

#### 📄 **Gestión Administrativa**
- 🧾 Generación de facturas en PDF
- 📞 Sistema de reclamaciones
- ❓ FAQ dinámico
- 📧 Envío automático de correos de bienvenida

### 🛠️ **Panel de Desarrollador**
- ⬆️ Subida de nuevos juegos
- ✏️ Edición de información y precios
- 🗑️ Eliminación de juegos
- 📈 Gestión de catálogo personal

## 🏗️ Arquitectura del Proyecto

```
SteamHada/
├── 📁 SteamHadaLib/          # Biblioteca de clases (Lógica de negocio)
│   ├── CAD/                  # Capa de Acceso a Datos
│   └── EN/                   # Entidades de Negocio
│
├── 📁 SteamHadaWeb/          # Aplicación Web
│   ├── 📄 *.aspx            # Páginas web
│   ├── 📁 imagenes/         # Recursos visuales
│   ├── 📁 style/            # Estilos CSS
│   └── 📁 App_Data/         # Base de datos local
│
└── 📄 SteamHada.sln         # Solución de Visual Studio
```

## 💻 Tecnologías Utilizadas

- **Backend**: 
  - 🔷 ASP.NET Web Forms 4.6.1
  - 🔶 C# 7.0
  - 🗄️ SQL Server LocalDB
  
- **Frontend**:
  - 🎨 HTML5 + CSS3
  - ⚡ JavaScript/jQuery
  - 🎯 Bootstrap 3.2.0
  
- **Integraciones**:
  - 📘 Facebook SDK (Login social)
  - 📄 Apitron PDF Kit (Generación de facturas)
  - 📧 SMTP Gmail (Envío de correos)

## 🚀 Instalación y Configuración

### Prerrequisitos
- Visual Studio 2017 o superior
- .NET Framework 4.6.1
- SQL Server LocalDB
- IIS Express

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/steamhada.git
   ```

2. **Abrir la solución**
   - Abrir `SteamHada.sln` en Visual Studio

3. **Restaurar paquetes NuGet**
   - Click derecho en la solución → Restaurar paquetes NuGet

4. **Configurar la base de datos**
   - La base de datos LocalDB se creará automáticamente
   - Ejecutar los scripts SQL en `DBFiles/` si es necesario

5. **Configurar Facebook App** (opcional)
   - Crear una app en [Facebook Developers](https://developers.facebook.com/)
   - Actualizar el `appId` en `index.Master`

6. **Ejecutar el proyecto**
   - Establecer `SteamHadaWeb` como proyecto de inicio
   - Presionar F5 para ejecutar

## 📸 Capturas de Pantalla

### 🏠 Página Principal
- Ofertas destacadas
- Juegos populares
- Navegación intuitiva

### 🎮 Catálogo de Juegos
- Vista en grid con imágenes
- Filtros por categoría
- Sistema de búsqueda

### 👤 Perfil de Usuario
- Gestión de datos personales
- Cambio de avatar
- Historial de compras

## 🔐 Seguridad

- 🔒 Autenticación segura con hash de contraseñas
- 🛡️ Validación de formularios cliente/servidor
- 🚫 Control de acceso basado en roles
- 🔐 Protección contra inyección SQL con procedimientos almacenados

## 📊 Modelo de Datos

El sistema cuenta con las siguientes entidades principales:

- **Usuario**: Base para Cliente, Desarrollador y Administrador
- **Producto**: Base para Juego y Merchandising
- **Evento**: Base para EventoFisico y EventoVirtual
- **Facturacion**: Gestión de pedidos y reclamaciones
- **HiloForo** y **Mensaje**: Sistema de foros
- **Sorteo**: Gestión de sorteos

## 🤝 Contribución

¡Las contribuciones son bienvenidas! Por favor:

1. Fork el proyecto
2. Crea tu rama de características (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto fue desarrollado con fines educativos como parte de un proyecto universitario.

## 👥 Equipo de Desarrollo

Proyecto desarrollado por estudiantes de la Universidad de Alicante para la asignatura de Herramientas Avanzadas de Desarrollo de Aplicaciones (HADA).

---

⭐ **¡No olvides dejar tu estrella si te ha gustado el proyecto!** ⭐
