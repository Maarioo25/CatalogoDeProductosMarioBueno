# Catálogo de Productos - Mario Bueno López

## Descripción
Esta es una aplicación de escritorio desarrollada en **WPF** siguiendo el patrón de diseño **MVVM**. Su objetivo es gestionar un catálogo de productos con un sistema de navegación moderno, estilizado e internacionalizado.

---

## Requisitos
### Técnicos:
- **.NET Framework**: Compatible con la versión 8.0 o superior.
- **Lenguaje**: C#.
- **Diseño UI**: Windows Presentation Foundation (WPF).

### Sistema:
- Windows 10/11.

---

## Características principales
- Gestión de productos: Añade, edita, elimina y visualiza productos de manera sencilla.
- Gestión de categorias: Añade, edita, elimina y visualiza categorias de manera sencilla.
- Interfaz intuitiva: Diseño limpio y fácil de usar para una experiencia de usuario óptima.
- Búsqueda y filtrado: Busca de productos y/o categorias por nombre.
- Persistencia de datos: Almacenamiento en Base de Datos para la persistencia de datos.
- Gráficas personalizadas: Muestra información de manera visual en gráficas intuitivas.

---

## Estructura del Proyecto
El proyecto está diseñado siguiendo la arquitectura **MVVM**, con la siguiente estructura:

```plaintext
├── Assets/              # Iconos e imágenes.
   ├── Icons/            
   ├── Images/
├── Data/                # Enlace directo con la base de datos.
├── Models/              # Modelos de datos (productos, categorías, etc.)
├── Properties/          # Almacenamiento de los ajustes de la app.
├── Repositories/        # Conexión entre los servicios y la base de datos.
├── Resources/           # Diccionarios de idiomas.
├── Services/            # Conexión entre los ViewModels y la capa de repositorios.
├── Themes/              # Temas y Templates de la aplicación.
├── VieModels/           # Lógica de la aplicación y enlace con las vistas.
├── Views/               # Vistas.
├── App.xaml             # Inicialización de la aplicación e inyección de dependencias.
```

## Funcionalidades

### Menú de Navegación Lateral
- Cambia entre las diferentes vistas de la aplicación de manera intuitiva.
- **Vistas disponibles:**
  - **Inicio**: Información de contacto.
  - **Productos**: Gestión y visualización del catálogo de productos.
  - **Categorías**: Gestión y visualización de las categorías de productos.
  - **Configuración**: Permite cambiar el tema y el idioma de la aplicación.
  - **Gráficas**: Muestra gráficas relacionadas con los productos.
  - **Salir**: Cierra la aplicación.

### Personalización de Botones
- Botones del menú lateral con un diseño personalizado y con animaciones personalizadas.
- Los botones funcionan como `RadioButton`, asegurando que solo una vista esté activa a la vez.

### Estilos y Diseño
- La aplicación utiliza un esquema de colores personalizado.

### Internacionalización
- La aplicación está disponible en varios idiomas:
  - **Español**.
  - **Inglés**.
  - **Francés**.
  - **Alemán**.
- Cambia el idioma desde la página de **Configuración**.
- Las etiquetas y textos se actualizan automáticamente según el idioma seleccionado.

### Animaciones
- Los botones y elementos interactivos cuentan con animaciones sutiles que mejoran la experiencia de usuario.
