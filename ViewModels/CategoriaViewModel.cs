using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CatálogoDeProductos.ViewModels;

partial class CategoriaViewModel(IRepositoryService<Categoria> categoriaService) : ObservableObject
{

    [ObservableProperty]
    private string? _textoBusquedaCategorias;

    partial void OnTextoBusquedaCategoriasChanged(string? value)
    {
        FiltrarCategorias(value);
    }

    private void FiltrarCategorias(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            Categorias = new ObservableCollection<Categoria>(categoriaService.GetAll());
        }
        else
        {
            var categoriasFiltradas = categoriaService.GetAll().Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
            Categorias = new ObservableCollection<Categoria>(categoriasFiltradas);
        }
    }

    [ObservableProperty]
    private ObservableCollection<Categoria> _categorias = new(categoriaService.GetAll());

    [ObservableProperty]
    private Categoria? _categoriaSeleccionada;

    [ObservableProperty]
    private int? _id = null;

    [ObservableProperty]
    private String? _nombre = String.Empty;

    [ObservableProperty]
    private String? _descripcion = String.Empty;

    private bool CanAddCategoria => (CategoriaSeleccionada == null && Id == null && !string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Descripcion));

    public bool CanEditDeleteDeselectCategoria => CategoriaSeleccionada != null;

    partial void OnNombreChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
    }

    partial void OnDescripcionChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
    }

    partial void OnCategoriaSeleccionadaChanged(Categoria? selectedCategoria)
    {
        if (selectedCategoria != null)
        {
            Nombre = selectedCategoria.Nombre;
            Descripcion = selectedCategoria.Descripcion;
        }
        else
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
        OnPropertyChanged(nameof(CanEditDeleteDeselectCategoria));
    }

    [RelayCommand(CanExecute = nameof(CanAddCategoria))]
    private void AddCategoria()
    {
        categoriaService.Add(new Categoria{ 
            Nombre = Nombre, 
            Descripcion = Descripcion
        });
        Categorias = new ObservableCollection<Categoria>(categoriaService.GetAll());
        Nombre = String.Empty;
        Descripcion = String.Empty;
        Id = null;
    }

    [RelayCommand]
    private void DeleteCategoria() {
        categoriaService.Delete(CategoriaSeleccionada);
        Categorias = new ObservableCollection<Categoria>(categoriaService.GetAll());
    }

    [RelayCommand]
    private void UpdateCategoria()
    {
        Categoria categoria = CategoriaSeleccionada;
        categoria.Nombre = Nombre;
        categoria.Descripcion = Descripcion;
        categoriaService.Update(categoria);
        Categorias = new ObservableCollection<Categoria>(categoriaService.GetAll());
    }
}
