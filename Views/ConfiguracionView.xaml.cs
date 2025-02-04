using System.Windows.Controls;

namespace CatálogoDeProductos.Views;

public partial class ConfiguracionView : UserControl
{
    public ConfiguracionView()
    {
        InitializeComponent();
        revisarIdioma();
        revisarTema();
    }

    private void revisarTema()
    {
        switch (Properties.Settings.Default.Tema)
        {
            case "Dark": btnOscuro.IsChecked = true; break;
            case "Light": btnClaro.IsChecked = true; break;
        }
    }

    private void revisarIdioma()
    {
        switch (Thread.CurrentThread.CurrentUICulture.ToString())
        {
            case "es-ES": btnEsp.IsChecked = true; break;
            case "de-DE": btnAle.IsChecked = true; break;
            case "en-EN": btnEng.IsChecked = true; break;
            case "fr-FR": btnFra.IsChecked = true; break;
        }
    }
}