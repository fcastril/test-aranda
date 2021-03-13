using System;
using System.IO;
using System.Windows;
using test_arana.wpf.Class;
using test_arana.wpf.Models;

namespace test_arana.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResourceModel _res;
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
            this.lblSO.Visibility = Visibility.Hidden;
            this.lblMachine.Visibility = Visibility.Hidden;
            this.lblIP.Visibility = Visibility.Hidden;
            this.lblDD.Visibility = Visibility.Hidden;
            this.lblRam.Visibility = Visibility.Hidden;
            this.lblProcesador.Visibility = Visibility.Hidden;
            this.lblDate.Visibility = Visibility.Hidden;
            this.Export.Visibility = Visibility.Hidden;
        }
        private void btGetData_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            this.lblSO.Visibility = Visibility.Visible;
            this.lblMachine.Visibility = Visibility.Visible;
            this.lblIP.Visibility = Visibility.Visible;
            this.lblDD.Visibility = Visibility.Visible;
            this.lblRam.Visibility = Visibility.Visible;
            this.lblProcesador.Visibility = Visibility.Visible;
            this.lblDate.Visibility = Visibility.Visible;
            this.Export.Visibility = Visibility.Visible;

            GetData();

            this.lblSO.Content = $"Sistema Operativo: {_res.dd}";
            this.lblMachine.Content = $"Nombre Máquina: {_res.machine}";
            this.lblIP.Content = $"IP: {_res.ip}";
            this.lblDD.Content = $"Disco Duro: {_res.dd}";
            this.lblProcesador.Content = $"Procesador: {_res.procesador}";
            this.lblRam.Content = $"Memoría {_res.ram}";
            this.lblDate.Content = $"Fecha Elaboración: {_res.date.ToLongDateString()}";

            setData();



        }

        private void GetData()
        {
            _res = new ResourceModel();
            _res.so = Class.Resources.GetSO();
            _res.machine = Class.Resources.GetMachine();
            _res.ip = Class.Resources.GetIP();
            _res.dd = Class.Resources.GetDD();
            _res.procesador = Class.Resources.GetProcesador();
            _res.ram = Class.Resources.GetMemory();
            _res.date = DateTime.Now;
        }

        private void setData()
        {

            using (var dbContext = new MyDbContext())
            {
                string dbName = "arana.db";
                if (!File.Exists(dbName))
                {
                    dbContext.Database.EnsureCreated();
                }
                dbContext.ResourcesDT.Add(_res);
                dbContext.SaveChanges();
            }
            Console.ReadLine();
        }

        private void btExport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string file = $"aplicativo_aranda_{_res.date.ToString("yyyyMMddHHmmSS")}.txt";

            string texto = $"Sistema Operativo: {_res.dd}\n";
            texto += $"Nombre Máquina: {_res.machine}\n";
            texto += $"IP: {_res.ip}\n";
            texto += $"Disco Duro: {_res.dd}\n";
            texto += $"Procesador: {_res.procesador}\n";
            texto += $"Memoría {_res.ram}\n";
            texto += $"Fecha Elaboración: {_res.date}";

            using (StreamWriter ExportFile = File.AppendText(file))
            {
                ExportFile.WriteLine(texto);
                ExportFile.Close();
            }


        }
    }
}
