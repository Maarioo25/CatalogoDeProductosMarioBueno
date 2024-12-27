using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace CatálogoDeProductos.Views
{
    public partial class ConfiguracionView : UserControl
    {
        public ConfiguracionView()
        {
            InitializeComponent();
            resetearBordesTheme();
            resetearBordesLanguaje();
            setLanguajeSeleccionado();
            setThemeSeleccionado();
        }

        private void setThemeSeleccionado()
        {
            //throw new System.NotImplementedException();
        }

        private void setLanguajeSeleccionado()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "es")
            {
                btnEsp.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "en")
            {
                btnEng.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "fr")
            {
                btnFra.Effect = null;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "de")
            {
                btnAle.Effect = null;
            }
        }

        private void btnClaro_Click(object sender, RoutedEventArgs e)
        {
            resetearBordesTheme();
            btnClaro.Effect = null;
        }

        private void btnOscuro_Click(object sender, RoutedEventArgs e)
        {
            resetearBordesTheme();
            btnOscuro.Effect = null;
        }

        private void resetearBordesTheme()
        {
            btnClaro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnOscuro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
        }

        private void btnEsp_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("es");
            resetearBordesLanguaje();
            btnEsp.Effect = null;

        }

        private void btnEng_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("en");
            resetearBordesLanguaje();
            btnEng.Effect = null;

        }

        private void btnFra_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("fr");
            resetearBordesLanguaje();
            btnFra.Effect = null;
        }

        private void btnAle_Click(object sender, RoutedEventArgs e)
        {
            RefreshWindow("de");
            resetearBordesLanguaje();
            btnAle.Effect = null;
        }

        private void resetearBordesLanguaje()
        {
            btnEsp.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnEng.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnFra.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnAle.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
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

            newWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = newWindow;
            newWindow.resetearBordes();
            newWindow.BordeConfiguracion.Effect = null;
        }

    }
}
