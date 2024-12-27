using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace CatálogoDeProductos.Views
{
    public partial class ConfiguracionView : UserControl
    {
        public ConfiguracionView()
        {
            InitializeComponent();
            addBordesLenguaje();
            addBordesTema();
            setLanguajeSeleccionado();
            setTemaSeleccionado();
        }

        private void setLanguajeSeleccionado()
        {

            if (Thread.CurrentThread.CurrentUICulture.Name == "es-ES")
            {
                btnEsp.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "en-EN")
            {
                btnEng.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
            {
                btnFra.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "de-DE")
            {
                btnAle.Effect = null;
            }
        }

        private void setTemaSeleccionado()
        {
            if (Application.Current.Resources.MergedDictionaries.Count > 0)
            {
                if (Application.Current.Resources.MergedDictionaries[0].Source.OriginalString == "Themes/Light/LightTheme.xaml")
                {
                    btnClaro.Effect = null;
                }
                else
                {
                    btnOscuro.Effect = null;
                }
            }
        }

        private void btnClaro_Click(object sender, RoutedEventArgs e)
        {
            btnClaro.Effect = null;
            btnOscuro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Themes/Light/LightTheme.xaml", UriKind.Relative) });
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.iconoInicio.Source = new BitmapImage(new Uri("Assets/Icons/Home_Light.png", UriKind.Relative));
            mainWindow.iconoProductos.Source = new BitmapImage(new Uri("Assets/Icons/Productos_Light.png", UriKind.Relative));
            mainWindow.iconoCategorias.Source = new BitmapImage(new Uri("Assets/Icons/Categorias_Light.png", UriKind.Relative));
            mainWindow.iconoConfiguracion.Source = new BitmapImage(new Uri("Assets/Icons/Configuracion_Light.png", UriKind.Relative));
            mainWindow.iconoSalir.Source = new BitmapImage(new Uri("Assets/Icons/Salir_Light.png", UriKind.Relative));
        }

        private void btnOscuro_Click(object sender, RoutedEventArgs e)
        {
            btnOscuro.Effect = null;
            btnClaro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Themes/Dark/DarkTheme.xaml", UriKind.Relative) });
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.iconoInicio.Source = new BitmapImage(new Uri("Assets/Icons/Home_Dark.png", UriKind.Relative));
            mainWindow.iconoProductos.Source = new BitmapImage(new Uri("Assets/Icons/Productos_Dark.png", UriKind.Relative));
            mainWindow.iconoCategorias.Source = new BitmapImage(new Uri("Assets/Icons/Categorias_Dark.png", UriKind.Relative));
            mainWindow.iconoConfiguracion.Source = new BitmapImage(new Uri("Assets/Icons/Configuracion_Dark.png", UriKind.Relative));
            mainWindow.iconoSalir.Source = new BitmapImage(new Uri("Assets/Icons/Salir_Dark.png", UriKind.Relative));

        }

        private void btnEsp_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("es-ES");

        }

        private void btnEng_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("en-EN");

        }

        private void btnFra_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("fr-FR");
        }

        private void btnAle_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("de-DE");
        }

        private void addBordesLenguaje()
        {
            
            btnEsp.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnEng.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnFra.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnAle.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
        }

        private void addBordesTema()
        {
            btnClaro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnOscuro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
        }

        private void RefreshWindow(string culture)
        {
            var estabaMaximizada = Application.Current.MainWindow.WindowState == WindowState.Maximized;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);

            MainWindow newWindow = new MainWindow();
            newWindow.MainContent.Content = new ConfiguracionView();

            if (estabaMaximizada)
            {
                newWindow.WindowState = WindowState.Maximized;
            }

            if (Application.Current.Resources.MergedDictionaries[0].Source.OriginalString == "Themes/Light/LightTheme.xaml")
            {
                newWindow.iconoInicio.Source = new BitmapImage(new Uri("Assets/Icons/Home_Light.png", UriKind.Relative));
                newWindow.iconoProductos.Source = new BitmapImage(new Uri("Assets/Icons/Productos_Light.png", UriKind.Relative));
                newWindow.iconoCategorias.Source = new BitmapImage(new Uri("Assets/Icons/Categorias_Light.png", UriKind.Relative));
                newWindow.iconoConfiguracion.Source = new BitmapImage(new Uri("Assets/Icons/Configuracion_Light.png", UriKind.Relative));
                newWindow.iconoSalir.Source = new BitmapImage(new Uri("Assets/Icons/Salir_Light.png", UriKind.Relative));
            }            
            else
            {
                newWindow.iconoInicio.Source = new BitmapImage(new Uri("Assets/Icons/Home_Dark.png", UriKind.Relative));
                newWindow.iconoProductos.Source = new BitmapImage(new Uri("Assets/Icons/Productos_Dark.png", UriKind.Relative));
                newWindow.iconoCategorias.Source = new BitmapImage(new Uri("Assets/Icons/Categorias_Dark.png", UriKind.Relative));
                newWindow.iconoConfiguracion.Source = new BitmapImage(new Uri("Assets/Icons/Configuracion_Dark.png", UriKind.Relative));
                newWindow.iconoSalir.Source = new BitmapImage(new Uri("Assets/Icons/Salir_Dark.png", UriKind.Relative));
            }

            newWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = newWindow;
            newWindow.resetearBordes();
            newWindow.BordeConfiguracion.Effect = null;
        }

    }
}
