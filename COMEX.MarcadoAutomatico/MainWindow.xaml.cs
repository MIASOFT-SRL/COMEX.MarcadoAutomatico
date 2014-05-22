using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace COMEX.MarcadoAutomatico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbCriterio.Focus();
            //StackPanel skpImagen
            BitmapImage source = new BitmapImage();
            source.BeginInit();
            string ruta = "imagenes/usuario.png";
            source.UriSource = new Uri(ruta, UriKind.Relative);
            source.EndInit();
            Image imgUsuario = new Image() { Stretch = Stretch.Fill, Source = source };
            StackPanel skpImagen = new StackPanel() { Width = 100, Orientation = Orientation.Vertical };
            skpImagen.Children.Add(imgUsuario);

            //StackPanel skpDetalleItem
            Label lbl1 = new Label() { Content = "Nombre :", FontWeight = FontWeights.Bold };
            Label lbl2 = new Label() { Content = "Jose Luis Vidal Sejas" };
            StackPanel skpDetalleItem = new StackPanel() { Height = 31, Orientation = Orientation.Horizontal };
            skpDetalleItem.Children.Add(lbl1);
            skpDetalleItem.Children.Add(lbl2);

            //StackPanel skpDetalle
            StackPanel skpDetalle = new StackPanel() { Width = 437, Height = 130 };
            skpDetalle.Children.Add(skpDetalleItem);

            //Agregando al TextBlock
            TextBlock txbAuxiliar = new TextBlock() { Width = 600, Height = 146 };
            txbAuxiliar.Inlines.Add(skpImagen);
            txbAuxiliar.Inlines.Add(skpDetalle);

            //Agregando al ListBox
            lbEmpleados.Items.Add(txbAuxiliar);
        }
    }
}
