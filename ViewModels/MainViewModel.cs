using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace CatálogoDeProductos.ViewModels;

partial class MainViewModel(
        InicioViewModel inicioViewModel,
        ProductoViewModel productoViewModel,
        CategoriaViewModel categoriaViewModel,
        ConfiguracionViewModel configuracionViewModel,
        GraficosViewModel graficosViewModel
    ) : ObservableObject
{
    [ObservableProperty]
    private object _activeView = inicioViewModel;

    [ObservableProperty]
    private bool isWindowMaximized;

    public InicioViewModel InicioViewModel { get; } = inicioViewModel;
    public ProductoViewModel ProductoViewModel { get; } = productoViewModel;
    public CategoriaViewModel CategoriaViewModel { get; } = categoriaViewModel;
    public ConfiguracionViewModel ConfiguracionViewModel { get; } = configuracionViewModel;
    public GraficosViewModel GraficosViewModel { get; } = graficosViewModel;


    [ObservableProperty]
    private string? _textoBusqueda;

    partial void OnTextoBusquedaChanged(string? value)
    {
        ProductoViewModel.TextoBusquedaProductos = value;
        CategoriaViewModel.TextoBusquedaCategorias = value;
    }


    [RelayCommand]
    private void ActivateInicioView() => ActiveView = InicioViewModel;

    [RelayCommand]
    private void ActivateProductoView() => ActiveView = ProductoViewModel;

    [RelayCommand]
    private void ActivateCategoriaView() => ActiveView = CategoriaViewModel;

    [RelayCommand]
    private void ActivateConfiguracionView() => ActiveView = ConfiguracionViewModel;

    [RelayCommand]
    private void ActivateGraficosView()
    {
        ActiveView = GraficosViewModel;
        GraficosViewModel.RecargarGraficosCommand.Execute(this);
    }

    [RelayCommand]
    private void Salir() => Application.Current.Shutdown();

    [RelayCommand]
    private void Minimizar() => Application.Current.MainWindow.WindowState = WindowState.Minimized;

    [RelayCommand]
    private void Maximizar()
    {
        var window = Application.Current.MainWindow;

        if (window.WindowState == WindowState.Maximized)
        {
            window.WindowState = WindowState.Normal;
        }
        else
        {
            window.WindowState = WindowState.Maximized;
        }
    }
}
