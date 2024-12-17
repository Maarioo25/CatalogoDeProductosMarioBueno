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

## Estructura del Proyecto
El proyecto está diseñado siguiendo la arquitectura **MVVM**, con la siguiente estructura:

```plaintext
CatálogoDeProductos
├── Models/          # Modelos de datos (productos, configuraciones, etc.)
├── ViewModels/      # Lógica de la aplicación y enlace con la vista.
├── Views/           # Vistas.
├── Resources/       # Estilos y diccionarios de idiomas.
├── App.xaml         # Configuración de la aplicación.
├── MainWindow.xaml  # Ventana principal de la aplicación.
├── Assets/          # Iconos e imágenes.
```

## Funcionalidades

### Menú de Navegación Lateral
- Cambia entre las diferentes vistas de la aplicación de manera intuitiva.
- **Vistas disponibles:**
  - **Inicio**: Información general del catálogo.
  - **Productos**: Gestión y visualización del catálogo de productos.
  - **Configuración (Settings)**: Permite cambiar el idioma de la aplicación.

### Personalización de Botones
- Botones del menú lateral con un diseño personalizado.
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

### Animaciones (Opcional)
- Las transiciones entre vistas son fluidas y dinámicas.
- Botones y elementos interactivos cuentan con animaciones sutiles que mejoran la experiencia de usuario.
