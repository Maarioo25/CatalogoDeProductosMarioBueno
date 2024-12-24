using CatálogoDeProductos.Views;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatálogoDeProductos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            resetearBordes();
            BordeInicio.Effect = null;
            MainContent.Content = new InicioView();
            
        }

        private void Arrastrar_Cabecera(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinimizarButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizarButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InicioView();
            resetearBordes();
            BordeInicio.Effect = null;
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductosView();
            resetearBordes();
            BordeProductos.Effect = null;
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CategoriasView();
            resetearBordes();
            BordeCategorias.Effect = null;
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ConfiguracionView();
            resetearBordes();
            BordeConfiguracion.Effect = null;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void resetearBordes()
        {
            BordeInicio.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            BordeProductos.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            BordeCategorias.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            BordeConfiguracion.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            BordeSalir.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
        }

    }
}
