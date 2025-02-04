using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows;

namespace CatálogoDeProductos.ViewModels;

public partial class ConfiguracionViewModel : ObservableObject
{
    [RelayCommand]
    private void CambiarTemaClaro() => CambiarTema("Light");

    [RelayCommand]
    private void CambiarTemaOscuro() => CambiarTema("Dark");

    [RelayCommand]
    private void CambiarEsp() => CambiarLenguaje("es-ES");
    
    [RelayCommand]
    private void CambiarIng() => CambiarLenguaje("en-EN");

    [RelayCommand]
    private void CambiarFra() => CambiarLenguaje("fr-FR");
    
    [RelayCommand]
    private void CambiarAle() => CambiarLenguaje("de-DE");
    
    private void CambiarTema(string ruta)
    {
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri($"/Themes/{ruta}/{ruta}Theme.xaml", UriKind.Relative) });
        Properties.Settings.Default.Tema = ruta;
        Properties.Settings.Default.Save();
    }
    private void CambiarLenguaje(string cultura)
    {
        Properties.Settings.Default.Idioma = cultura;
        Properties.Settings.Default.Save();

        MessageBoxResult resultado = MessageBox.Show(
            Resources.Resources.txtAviso,
            Resources.Resources.txtCambioDeIdioma,
            MessageBoxButton.YesNo,
            MessageBoxImage.Information
        );

        if (resultado == MessageBoxResult.Yes)
        {
            string? rutaApp = Environment.ProcessPath;
            if (rutaApp != null)
            {
                Process.Start(rutaApp);
            }
            Application.Current.Shutdown();
        }


    }

}
