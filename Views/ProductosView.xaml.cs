using System.Windows;
using System.Windows.Controls;

namespace CatálogoDeProductos.Views;

public partial class ProductosView : UserControl
{
    public ProductosView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ListaProductos.SelectedItem = null;
    }

}
