using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace CatálogoDeProductos.ViewModels;

partial class ProductoViewModel(IRepositoryService<Producto> productoService) : ObservableObject
{
    [ObservableProperty]
    private string? _textoBusquedaProductos;

    partial void OnTextoBusquedaProductosChanged(string? value)
    {
        FiltrarProductos(value);
    }

    private void FiltrarProductos(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            Productos = new ObservableCollection<Producto>(productoService.GetAll());
        }
        else
        {
            var productosFiltrados = productoService.GetAll().Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
            Productos = new ObservableCollection<Producto>(productosFiltrados);
        }
    }



    [ObservableProperty]
    private ObservableCollection<Producto> _productos = new(productoService.GetAll());

    [ObservableProperty]
    private Producto? _productoSeleccionado = null;

    [ObservableProperty]
    private int? _id = null;

    [ObservableProperty]
    private String? _nombre = String.Empty;

    [ObservableProperty]
    private double? _precio = null;

    [ObservableProperty]
    private String? _descripcion = String.Empty;

    [ObservableProperty]
    private int? _idCategoria = null;

    [ObservableProperty]
    private string? _uriImagen = String.Empty;

    private bool CanAddProducto => (ProductoSeleccionado == null && Id == null && !string.IsNullOrEmpty(Nombre) && Precio != null && !string.IsNullOrEmpty(Descripcion) && IdCategoria != null);

    public bool CanEditDeleteDeselectProducto => ProductoSeleccionado != null;

    partial void OnNombreChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnDescripcionChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnPrecioChanged(double? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnIdCategoriaChanged(int? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnUriImagenChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
        OnPropertyChanged(nameof(ProductoSeleccionado));
    }



    partial void OnProductoSeleccionadoChanged(Producto? productoSeleccionado)
    {
        if (productoSeleccionado != null)
        {
            Id = productoSeleccionado.Id;
            Nombre = productoSeleccionado.Nombre;
            Descripcion = productoSeleccionado.Descripcion;
            Precio = productoSeleccionado.Precio;
            IdCategoria = productoSeleccionado.IdCategoria;
            UriImagen = productoSeleccionado.UriImagen;
        }
        else
        {
            Id = null;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = null;
            IdCategoria = null;
            UriImagen = null;
        }

        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
        OnPropertyChanged(nameof(CanEditDeleteDeselectProducto));
    }


    [RelayCommand]
    private void CambiarImagen()
    {
        OpenFileDialog ventana = new OpenFileDialog
        {
            Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
            Title = "Seleccionar imagen del producto"
        };
        if (ventana.ShowDialog() == true)
        {
            UriImagen = ventana.FileName;
            OnPropertyChanged(nameof(UriImagen));
        }
    }

    [RelayCommand(CanExecute = nameof(CanAddProducto))]
    private void AddProducto()
    {
        productoService.Add(new Producto
        {
            Nombre = Nombre,
            Precio = Precio,
            Descripcion = Descripcion,
            IdCategoria = IdCategoria,
            UriImagen = UriImagen
        });
        Productos = new ObservableCollection<Producto>(productoService.GetAll());
        Nombre = String.Empty;
        Descripcion = String.Empty;
        Id = null;
        Precio = null;
        IdCategoria = null;
        UriImagen = null;
    }


    [RelayCommand]
    private void DeleteProducto()
    {
        productoService.Delete(ProductoSeleccionado);
        Productos = new ObservableCollection<Producto>(productoService.GetAll());
    }

    

    [RelayCommand]
    private void UpdateProducto()
    {
        Producto producto = ProductoSeleccionado;
        producto.Nombre = Nombre;
        producto.Descripcion = Descripcion;
        producto.Precio = Precio;
        producto.IdCategoria = IdCategoria;
        producto.UriImagen = UriImagen;
        productoService.Update(producto);
        Productos = new ObservableCollection<Producto>(productoService.GetAll());
    }
}
