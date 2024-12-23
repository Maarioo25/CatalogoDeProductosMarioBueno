using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatálogoDeProductos.Views
{
    public partial class ConfiguracionView : UserControl
    {
        public ConfiguracionView()
        {
            InitializeComponent();
            resetearBordes();
        }

        private void btnClaro_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOscuro_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void resetearBordes()
        {
            btnClaro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
            btnOscuro.Effect = new DropShadowEffect { Color = Colors.Black, BlurRadius = 10, ShadowDepth = 5 };
        }
    }
}
