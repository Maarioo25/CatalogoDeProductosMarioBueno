using System.Windows;
using System.Windows.Input;

namespace CatálogoDeProductos.Views;

public partial class MainView : Window
{
    public MainView()
    {
        AplicarTema();
        InitializeComponent();
    }

    private void Arrastrar_Cabecera(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void AplicarTema()
    {
        string tema = CatálogoDeProductos.Properties.Settings.Default.Tema;
        string rutaTema = tema == "Dark" ? "/Themes/Dark/DarkTheme.xaml" : "/Themes/Light/LightTheme.xaml";
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(rutaTema, UriKind.Relative) });
    }
}
