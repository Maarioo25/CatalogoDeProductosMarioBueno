using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;
using CatálogoDeProductos.Services;
using CatálogoDeProductos.ViewModels;
using CatálogoDeProductos.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.IO;
using System.Windows;

namespace CatálogoDeProductos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string idioma = CatálogoDeProductos.Properties.Settings.Default.Idioma;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);

            ServiceCollection services = new();

            services.AddSingleton<MainView>();
            services.AddTransient<InicioView>();
            services.AddTransient<ProductosView>();
            services.AddTransient<CategoriasView>();
            services.AddTransient<ConfiguracionView>();
            services.AddTransient<GraficosView>();


            services.AddTransient<MainViewModel>();
            services.AddTransient<InicioViewModel>();
            services.AddTransient<ProductoViewModel>();
            services.AddTransient<CategoriaViewModel>();
            services.AddTransient<ConfiguracionViewModel>();
            services.AddTransient<GraficosViewModel>();


            services.AddSingleton<IRepository<Producto>, ProductoRepository>();
            services.AddSingleton<IRepository<Categoria>, CategoriaRepository>();


            services.AddTransient<IRepositoryService<Producto>, ProductoService>();
            services.AddTransient<IRepositoryService<Categoria>, CategoriaService>();


            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=WpfAppDb;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=true;"));

            var serviceProvider = services.BuildServiceProvider();



            //Esta parte del código solo se ejecuta si la base de datos está vacia, por lo que solo se va a ejecutar la primera vez que ejecutes la
            //aplicación en una base de datos nueva.
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();

                if (!dbContext.Categorias.Any())
                {
                    dbContext.Categorias.Add(new Categoria { Nombre = "Zapatos", Descripcion = "Categoría de zapatos" });
                    dbContext.Categorias.Add(new Categoria { Nombre = "Abrigos", Descripcion = "Categoría de abrigos" });
                    dbContext.Categorias.Add(new Categoria { Nombre = "Pantalones", Descripcion = "Categoría de pantalones" });
                    dbContext.Categorias.Add(new Categoria { Nombre = "Camisetas", Descripcion = "Categoría de camisetas" });
                    dbContext.Categorias.Add(new Categoria { Nombre = "Calcetines", Descripcion = "Categoría de calcetines" });
                    dbContext.SaveChanges();
                }

                if (!dbContext.Productos.Any())
                {
                    dbContext.Productos.Add(new Producto { Nombre = "Nike Air Jordan 1 Low", Precio = 149.99, Descripcion = "Zapatillas Air Jordan 1 Low", IdCategoria = 1, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Air_Jordan_1_Low.png") });
                    dbContext.Productos.Add(new Producto { Nombre = "Adidas Campus", Precio = 125.99, Descripcion = "Zapatillas Campus de Adidas", IdCategoria = 1, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Adidas_Campus.jpeg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Abrigo North Face", Precio = 99.99, Descripcion = "Abrigo de la marca North Face", IdCategoria = 2, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Abrigo_NorthFace.jpg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Pantalones Adidas", Precio = 49.99, Descripcion = "Pantalones de la marca Adidas", IdCategoria = 3, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Pantalones_Adidas.jpeg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Camiseta Amiri", Precio = 79.99, Descripcion = "Camiseta de la marca Amiri", IdCategoria = 4, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Camiseta_Amiri.jpeg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Pantalones Nike", Precio = 45.99, Descripcion = "pantalones de la marca Nike", IdCategoria = 3, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Pantalon_Nike.jpeg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Abrigo Puma", Precio = 85.00, Descripcion = "Abrigo de la marca Puma", IdCategoria = 2, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Abrigo_Puma.jpg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Calcetines Jordan", Precio = 9.99, Descripcion = "Calcetines de la marca Jordan", IdCategoria = 5, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Calcetines_Jordan.jpg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Calcetines Primark", Precio = 4.99, Descripcion = "Calcetines del Primark", IdCategoria = 5, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Calcetines_Primark.jpg") });
                    dbContext.Productos.Add(new Producto { Nombre = "Camiseta Puma", Precio = 29.99, Descripcion = "Camiseta de la marca Puma", IdCategoria = 4, UriImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Camiseta_Puma.jpg") });
                    dbContext.SaveChanges();
                }
                dbContext.SaveChanges();
            }



            var view = serviceProvider.GetService<MainView>();
            view.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();
        }
    }
}
