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
        #region "Design Controls"

        private Image getImagen()
        {
            BitmapImage source = new BitmapImage();
            source.BeginInit();
            string ruta = "imagenes/usuario.png";
            source.UriSource = new Uri(ruta, UriKind.Relative);
            source.EndInit();
            return new Image() { Stretch = Stretch.Fill, Source = source };
        }

        private StackPanel getSkpImagen()
        {
            //StackPanel skpImagen
            StackPanel skpImagen = new StackPanel() { Width = 100, Orientation = Orientation.Vertical };
            Image imgUsuario = getImagen();
            skpImagen.Children.Add(imgUsuario);
            return skpImagen;
        }

        private StackPanel getSkpDetalleItem(string name, string descripcion)
        {
            //StackPanel skpDetalleItem
            Label lbl1 = new Label() { Content = name, FontWeight = FontWeights.Bold };
            Label lbl2 = new Label() { Content = descripcion };

            StackPanel skpDetalleItem = new StackPanel() { Height = 31, Orientation = Orientation.Horizontal };
            skpDetalleItem.Children.Add(lbl1);
            skpDetalleItem.Children.Add(lbl2);
            return skpDetalleItem;
        }

        private StackPanel getSkpDetalle(string codigo, string nombre, string cargo, string departamento)
        {
            //StackPanel skpDetalle
            StackPanel skpDetalleItem1 = getSkpDetalleItem("Código :", codigo);
            StackPanel skpDetalleItem2 = getSkpDetalleItem("Nombre :", nombre);
            StackPanel skpDetalleItem3 = getSkpDetalleItem("Cargo :", cargo);
            StackPanel skpDetalleItem4 = getSkpDetalleItem("Departamento :", departamento);
            StackPanel skpDetalle = new StackPanel() { Width = 437, Height = 130 };
            skpDetalle.Children.Add(skpDetalleItem1);
            skpDetalle.Children.Add(skpDetalleItem2);
            skpDetalle.Children.Add(skpDetalleItem3);
            skpDetalle.Children.Add(skpDetalleItem4);
            return skpDetalle;
        }

        private TextBlock getTextBlock(string codigo, string nombre, string cargo, string departamento)
        {
            //Agregando al TextBlock
            StackPanel skpImagen = getSkpImagen();
            StackPanel skpDetalle = getSkpDetalle(codigo, nombre, cargo, departamento);
            TextBlock txbAuxiliar = new TextBlock() { Width = 600, Height = 146 };
            txbAuxiliar.Inlines.Add(skpImagen);
            txbAuxiliar.Inlines.Add(skpDetalle);
            return txbAuxiliar;
        }

        #endregion

        #region "Metodos"

        private List<Datos.USERINFO> getEmpleados()
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            return db.USERINFO.ToList();
        }

        private void generarListaEmpleados()
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            List<Datos.USERINFO> lista = getEmpleados();
            lbEmpleados.Items.Clear();
            foreach (Datos.USERINFO empleado in lista)
            {
                Datos.DEPARTMENTS deparatamento = db.DEPARTMENTS.FirstOrDefault(d => d.DEPTID == empleado.DEFAULTDEPTID);

                if (deparatamento == null)
                {
                    deparatamento = new Datos.DEPARTMENTS() { DEPTNAME = "Desconcido" };
                }

                //Agregando al ListBox
                lbEmpleados.Items.Add(getTextBlock(empleado.BADGENUMBER,empleado.NAME,empleado.TITLE,deparatamento.DEPTNAME));
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbCriterio.Focus();
            //generarListaEmpleados();
        }
    }
}
