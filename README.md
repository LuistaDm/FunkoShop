🧸 FunkoShop

Aplicación web de una tienda online de Funko Pops desarrollada como proyecto académico para la materia Programación Web.

El proyecto comenzó como una aplicación realizada con HTML, CSS y JavaScript y posteriormente fue migrado a ASP.NET Core MVC, incorporando persistencia de datos, autenticación, sesiones y un carrito de compras.

🚀 Tecnologías utilizadas
C#
ASP.NET Core MVC (.NET 9)
Entity Framework Core
SQL Server
Bootstrap 5
HTML5
CSS3
JavaScript
Git / GitHub
✨ Funcionalidades
🏠 Página de inicio con distintas secciones.
🛍️ Catálogo de productos.
🔎 Búsqueda de productos por nombre.
📄 Vista de detalle de cada producto.
🛒 Carrito de compras utilizando Session.
➕ Agregar productos al carrito.
➖ Quitar productos del carrito.
🔢 Contador de productos en el carrito.
👤 Registro de usuarios.
🔐 Inicio y cierre de sesión.
💾 Persistencia de usuarios, productos y compras mediante Entity Framework Core.
🧾 Finalización de compras.
🔗 Asociación entre usuarios y compras.
📱 Diseño responsive utilizando Bootstrap 5.
🗄️ Base de datos

La aplicación utiliza SQL Server y Entity Framework Core para la persistencia de información.

Las principales entidades utilizadas son:

Usuario
Producto
Compra
CompraDetalle

La relación principal del sistema permite asociar un usuario con sus compras y cada compra con los productos adquiridos.

🛒 Flujo de compra

El flujo principal de la aplicación es:

Tienda
   ↓
Detalle del producto
   ↓
Agregar al carrito
   ↓
Carrito
   ↓
Iniciar sesión / Registrarse
   ↓
Finalizar compra
   ↓
Guardar compra en la base de datos
   ↓
Vaciar carrito
   ↓
Confirmación de compra
🎨 Diseño

La interfaz fue desarrollada utilizando principalmente Bootstrap 5, aprovechando:

Grid System
Cards
Navbar
Forms
Buttons
Alerts
Badges
Utilities de espaciado y alineación
Responsive breakpoints

Se buscó reducir al mínimo el uso de CSS personalizado y resolver la maquetación mediante las herramientas proporcionadas por Bootstrap.

📚 Objetivo académico

El objetivo del proyecto es aplicar de manera práctica los conceptos vistos durante la materia, principalmente:

Arquitectura MVC.
Controllers y Views.
Modelos y relaciones entre entidades.
Entity Framework Core.
Migraciones.
Acceso a bases de datos.
Manejo de sesiones.
Formularios y validaciones.
Bootstrap y diseño responsive.
👨‍💻 Autor

Luis Domin

Proyecto realizado con fines académicos.
