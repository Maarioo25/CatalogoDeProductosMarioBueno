using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace CatálogoDeProductos.ViewModels;

partial class GraficosViewModel(IRepositoryService<Categoria> categoriasService, IRepositoryService<Producto> productosService) : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<Producto> _productos;

    [ObservableProperty]
    private ObservableCollection<Categoria> _categorias;

    public ObservableCollection<ISeries> ProductosPorCategoriaGrafico { get; set; } = new();
    public ObservableCollection<ISeries> ProductosPorRangoDePreciosGrafico { get; set; } = new();

    [RelayCommand]
    private void RecargarGraficos()
    {
        _productos = new ObservableCollection<Producto>(productosService.GetAll());
        _categorias = new ObservableCollection<Categoria>(categoriasService.GetAll());
        ConfigurarProductosPorCategoria();
        ConfigurarProductosPorRangoDePrecios();
    }

    

    private void ConfigurarProductosPorCategoria()
    {
        ProductosPorCategoriaGrafico.Clear();

        var productosAgrupados = _productos.GroupBy(l => l.IdCategoria)
                                           .Select(group => new { Type = group.Key, Count = group.Count() });

        foreach (var grupo in productosAgrupados)
        {
            ProductosPorCategoriaGrafico.Add(new PieSeries<int>
            {
                Name = categoriasService.Get(grupo.Type.Value)?.Nombre ?? "Desconocido",
                Values = new[] { grupo.Count }
            });
        }
    }

    private void ConfigurarProductosPorRangoDePrecios()
    {
        ProductosPorRangoDePreciosGrafico.Clear();

        var rangosDePrecio = new List<(string Nombre, double Min, double Max)>
        {
            ("0€ - 20€", 0, 20),
            ("21€ - 75€", 21, 75),
            ("76€ - 150€", 76, 150),
            ("+150€", 150, double.MaxValue)
        };

        var productosAgrupados = _productos.GroupBy(p => rangosDePrecio.FirstOrDefault(r => p.Precio >= r.Min && p.Precio <= r.Max).Nombre)
                                           .Select(group => new { Rango = group.Key, Count = group.Count() });

        foreach (var grupo in productosAgrupados)
        {
            ProductosPorRangoDePreciosGrafico.Add(new PieSeries<int>
            {
                Name = grupo.Rango,
                Values = new[] { grupo.Count }
            });
        }
    }
}
