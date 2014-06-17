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

        private Image getImagen(string pathImage)
        {
            BitmapImage source = new BitmapImage();
            source.BeginInit();
            string ruta = pathImage;
            source.UriSource = new Uri(ruta, UriKind.Relative);
            source.EndInit();
            return new Image() { Stretch = Stretch.Fill, Source = source };
        }

        private StackPanel getSkpImagen(string position)
        {
            //StackPanel skpImagen
            StackPanel skpImagen = new StackPanel() 
            {
                Width = 100, 
                Orientation = Orientation.Vertical,
                Name = "skpImagen" + position
            };
            Image imgUsuario = getImagen();
            skpImagen.Children.Add(imgUsuario);
            return skpImagen;
        }

        private StackPanel getSkpMarcado(bool isMarcado, string position)
        {
            CheckBox cbx = new CheckBox() 
            { 
                Name = "cbxMarcado_" + position, 
                IsChecked = isMarcado 
            };
            Image img = getImagen("imagenes/U-560-C.png");
            img.Name = "img_" + position;
            img.Width = 176;
            img.ToolTip = "Marcado automático";
            img.MouseDown += new MouseButtonEventHandler (Image_MouseDown);

            StackPanel SkpMarcado = new StackPanel() 
            {
                Height = 128, Width = 218, 
                Orientation = Orientation.Horizontal, 
                Name = ("skpMarcado_" + position) 
            };
            SkpMarcado.Children.Add(cbx);
            SkpMarcado.Children.Add(img);

            return SkpMarcado;
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

        private StackPanel getSkpDetalle(string codigo, string nombre, string cargo, string departamento, string position)
        {
            //StackPanel skpDetalle
            StackPanel skpDetalleItem1 = getSkpDetalleItem("Código :", codigo);
            skpDetalleItem1.Name = "skpDetalleItem1";
            StackPanel skpDetalleItem2 = getSkpDetalleItem("Nombre :", nombre);
            skpDetalleItem2.Name = "skpDetalleItem2";
            StackPanel skpDetalleItem3 = getSkpDetalleItem("Cargo :", cargo);
            skpDetalleItem3.Name = "skpDetalleItem3";
            StackPanel skpDetalleItem4 = getSkpDetalleItem("Departamento :", departamento);
            skpDetalleItem4.Name = "skpDetalleItem4";
            StackPanel skpDetalle = new StackPanel() 
            { 
                Width = 312, 
                Height = 130,
                Name = "skpDetalle_" + position
            };
            skpDetalle.Children.Add(skpDetalleItem1);
            skpDetalle.Children.Add(skpDetalleItem2);
            skpDetalle.Children.Add(skpDetalleItem3);
            skpDetalle.Children.Add(skpDetalleItem4);
            return skpDetalle;
        }

        private StackPanel skpPrincipal(string codigo, string nombre, string cargo, string departamento, bool isMarcado, string position)
        {
            //Agregando al TextBlock
            StackPanel skpImagen = getSkpImagen(position);
            StackPanel skpDetalle = getSkpDetalle(codigo, nombre, cargo, departamento,position);
            StackPanel skpMarcado = getSkpMarcado(isMarcado, position);
            StackPanel skpPrincipal = new StackPanel() 
            {
                Width = 639, Height = 146, 
                Orientation = Orientation.Horizontal, 
                Name = "skpPrincipal_" + position 
            };
            skpPrincipal.Children.Add(skpImagen);
            skpPrincipal.Children.Add(skpDetalle);
            skpPrincipal.Children.Add(skpMarcado);

            return skpPrincipal;
        }

        #endregion

        #region"Eventos personalizados"

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)e.Source;
            string name = img.Name;
            string[] l = name.Split('_');
            int pos = int.Parse(l[1]);

            StackPanel skp = lbEmpleados.Items[pos] as StackPanel;
            StackPanel skpAuxiliar = (StackPanel)skp.Children[2];
            CheckBox cbx = (CheckBox)skpAuxiliar.Children[0];

            cbx.IsChecked = cbx.IsChecked == false ? true : false;
        }

        #endregion

        #region "Metodos"

        private List<Datos.USERINFO> getEmpleados()
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            return db.USERINFO.ToList();
        }

        private List<Datos.USERINFO> getEmpleados(string criterio)
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            return db.USERINFO.Where(u => u.NAME.ToUpper().Contains(criterio.ToUpper())).ToList();
        }

        private void generarListaEmpleados()
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            List<Datos.USERINFO> lista = getEmpleados();
            lbEmpleados.Items.Clear();
            int pos = 0;
            foreach (Datos.USERINFO empleado in lista)
            {
                Datos.DEPARTMENTS deparatamento = db.DEPARTMENTS.FirstOrDefault(d => d.DEPTID == empleado.DEFAULTDEPTID);

                if (deparatamento == null)
                {
                    deparatamento = new Datos.DEPARTMENTS() { DEPTNAME = "Desconcido" };
                }

                //Agregando al ListBox
                lbEmpleados.Items.Add(skpPrincipal(empleado.BADGENUMBER, empleado.NAME, empleado.TITLE, deparatamento.DEPTNAME,(bool)empleado.ISMARCADO, pos.ToString()));
                pos++;
            }
        }

        private void generarListaEmpleados(string criterio)
        {
            Datos.dbComexEntities db = new Datos.dbComexEntities();
            List<Datos.USERINFO> lista = getEmpleados(criterio);
            lbEmpleados.Items.Clear();
            int pos = 0;
            foreach (Datos.USERINFO empleado in lista)
            {
                Datos.DEPARTMENTS deparatamento = db.DEPARTMENTS.FirstOrDefault(d => d.DEPTID == empleado.DEFAULTDEPTID);

                if (deparatamento == null)
                {
                    deparatamento = new Datos.DEPARTMENTS() { DEPTNAME = "Desconcido" };
                }

                //Agregando al ListBox
                lbEmpleados.Items.Add(skpPrincipal(empleado.BADGENUMBER, empleado.NAME, empleado.TITLE, deparatamento.DEPTNAME, (bool)empleado.ISMARCADO, pos.ToString()));
                pos++;
            }
        }

        private List<Datos.USERINFO> getCodigoEmpleados()
        {
          
            List<Datos.USERINFO> empleados = new List<Datos.USERINFO>();
            foreach (var item in lbEmpleados.Items)
            {
                if (item is StackPanel)
                {
                    Datos.USERINFO empleado = new Datos.USERINFO();
                    StackPanel skp = (StackPanel)item;
                    StackPanel skpDetalle = (StackPanel)skp.Children[1];
                    StackPanel skpMarcado = (StackPanel)skp.Children[2];
                    StackPanel skpDetalleItem = (StackPanel)skpDetalle.Children[0];
                    Label lbl = (Label)skpDetalleItem.Children[1];
                    CheckBox cbx = (CheckBox)skpMarcado.Children[0];
                    empleado.BADGENUMBER = lbl.Content.ToString();
                    empleado.ISMARCADO = cbx.IsChecked;
                    empleados.Add(empleado);
                }
            }
            return empleados;
        }

        private int getHora()
        {
            string[] time = txbHora.Text.Split(':');
            string hora = time[0];
            hora = hora.TrimStart('0');
            int h = 0;
            if (int.TryParse(hora, out h))
            {
                return h;
            }
            else
            {
                return h;
            }
        }
        private int getMinuto()
        {
            string[] time = txbHora.Text.Split(':');
            string minuto = time[1];
            minuto = minuto.TrimStart('0');
            int m = 0;
            if (int.TryParse(minuto, out m))
            {
                return m;
            }
            else
            {
                return m;
            }
        }
        private int getSegundo()
        {
            string[] time = txbHora.Text.Split(':');
            string segundo = time[2];
            segundo = segundo.TrimStart('0');
            int s = 0;
            if (int.TryParse(segundo, out s))
            {
                return s;
            }
            else
            {
                return s;
            }
        }
        private bool validarHora(string hora)
        {
            if (hora.Contains(':'))
            {
                string[] vhora = hora.Split(':');
                if (vhora.Length == 3)
                {
                    string ho = vhora[0];
                    string mi = vhora[1];
                    string se = vhora[2];
                    ho = ho.Equals("00") || ho.Equals("0") ? "0" : ho.TrimStart('0');
                    mi = mi.Equals("00") || mi.Equals("0") ? "0" : mi.TrimStart('0');
                    se = se.Equals("00") || se.Equals("0") ? "0" : se.TrimStart('0');
                    int h = 0;
                    int m = 0;
                    int s = 0;

                    if (int.TryParse(ho, out h))
                    {
                        if (h >= 0 && h <= 23)
                        {
                            if (int.TryParse(mi, out m))
                            {
                                if (m >= 0 && m <= 59)
                                {
                                    if (int.TryParse(se, out s))
                                    {
                                        if (s >= 0 && s <= 59)
                                        {
                                            return true;
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool validarSeleccionlbEmpleados()
        {
            if (lbEmpleados.SelectedIndex >= 0)
            {
                return true;
            }
            return false;
        }
        private bool validarEstado()
        {
            if (cbEstado.SelectedIndex >= 0)
            {
                return true;
            }
            return false;
        }
        private bool validarFecha()
        {
            if (dpFecha.SelectedDate != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbHora.MaxLength = 8;
            txbCriterio.Focus();
            generarListaEmpleados();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Datos.dbComexEntities db = new Datos.dbComexEntities();
                List<Datos.USERINFO> empleados = getCodigoEmpleados();

                foreach (Datos.USERINFO empleadoModificado in empleados)
                {
                    Datos.USERINFO empleado = db.USERINFO.FirstOrDefault(em => em.BADGENUMBER == empleadoModificado.BADGENUMBER);
                    if (empleado != null)
                    {
                        empleado.ISMARCADO = empleadoModificado.ISMARCADO;
                    }
                }
                //Guardando los cambios
                db.SaveChanges();
                //Generando de nuevo a los empleados
                generarListaEmpleados();
                
                MessageBox.Show("Se guardaron los cambios correctamente", "MiaSoft srl", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception r)
            {
                string fecha = DateTime.Now.ToString();
                string nombre = DateTime.Now.Year.ToString()
                    + DateTime.Now.Month.ToString().PadLeft(2, '0')
                    + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".txt";
                string ruta = "Log/" + nombre;
                using (StreamWriter escribir = new StreamWriter(ruta, true))
                {
                    escribir.WriteLine(fecha + "    " + r.Message + "   Source:" + r.Source + "     " + r.TargetSite);
                }
                MessageBox.Show("No se pudieron guardar los cambios generados" + Environment.NewLine + "Si el problema persiste comuníquese con su administrador de sistemas", "MiaSoft srl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbCriterio_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txb = (TextBox)e.Source;
            string criterio = txb.Text;
            if (txb.Text.Length > 2)
            {
                generarListaEmpleados(criterio);
            }
            if (txb.Text.Length == 0)
            {
                generarListaEmpleados();
            }
        }

        private void btnAñadirRegistro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validaciones
                if (!validarSeleccionlbEmpleados())
                {
                    MessageBox.Show("No se ha seleccionado ningun empleado");
                    return;
                }
                if (!validarEstado())
                {
                    MessageBox.Show("No se ha seleccionado un estado");
                    cbEstado.Focus();
                    return;
                }
                if (!validarFecha())
                {
                    MessageBox.Show("No se ha seleccionado una fecha");
                    dpFecha.Focus();
                    return;
                }
                if (!validarHora(txbHora.Text))
                {
                    MessageBox.Show("El formato de la hora no es el correcto");
                    txbHora.Focus();
                    return;
                }

                Datos.dbComexEntities db = new Datos.dbComexEntities();
                //Buscando el BADGENUMBER
                StackPanel skp = (StackPanel)lbEmpleados.SelectedItem;
                StackPanel skpDetalle = (StackPanel)skp.Children[1];
                StackPanel skpDetalleItem = (StackPanel)skpDetalle.Children[0];
                Label lbl = (Label)skpDetalleItem.Children[1];
                //Obteniendo al empleado
                string BADGENUMBER = lbl.Content.ToString();
                Datos.USERINFO empleado = db.USERINFO.FirstOrDefault(em => em.BADGENUMBER.Equals(BADGENUMBER));
                Datos.Machines dispositivo = db.Machines.Take(1).ToList()[0];
                //cargando el registro
                Datos.CHECKINOUT marcado = new Datos.CHECKINOUT();
                marcado.USERID = empleado.USERID;
                DateTime? fechaAux = dpFecha.SelectedDate == null ? DateTime.Now : dpFecha.SelectedDate;
                int h = getHora();
                int m = getMinuto();
                int s = getSegundo();
                if (h == 0 && m == 0 && s == 0)
                {
                    if (MessageBox.Show("Esta seguro de que quiere colocar esta hora 00:00:00","MiaSoft srl", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                DateTime fechaRegistro = new DateTime(fechaAux.Value.Year, fechaAux.Value.Month, fechaAux.Value.Day, h, m, s);
                marcado.CHECKTIME = fechaRegistro;
                int estado = cbEstado.SelectedIndex;
                marcado.CHECKTYPE = estado == 0 ? "I" : "O";
                marcado.VERIFYCODE = 1;
                marcado.SENSORID = dispositivo.MachineNumber.ToString();
                marcado.WorkCode = 0;
                marcado.sn = "0351140200162";
                marcado.UserExtFmt = 1;

                //añadiendo el registro
                db.CHECKINOUT.Add(marcado);
                db.SaveChanges();

                MessageBox.Show("Se añadio correctamente el registro");
            }
            catch (Exception r)
            {
                string fecha = DateTime.Now.ToString();
                string nombre = DateTime.Now.Year.ToString()
                    + DateTime.Now.Month.ToString().PadLeft(2, '0')
                    + DateTime.Now.Day.ToString().PadLeft(2, '0') + ".txt";
                string ruta = "Log/" + nombre;
                using (StreamWriter escribir = new StreamWriter(ruta, true))
                {
                    escribir.WriteLine(fecha + "    " + r.Message + "   Source:" + r.Source + "     " + r.TargetSite);
                }
                MessageBox.Show("No se pudo añadir el registro" + Environment.NewLine + "Si el problema persiste comuníquese con su administrador de sistemas", "MiaSoft srl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}