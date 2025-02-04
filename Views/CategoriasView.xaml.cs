using System.Windows;
using System.Windows.Controls;

namespace CatálogoDeProductos.Views;

public partial class CategoriasView : UserControl
{
    public CategoriasView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ListaCategorias.SelectedItem = null;
    }
}
