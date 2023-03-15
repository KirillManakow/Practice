using Aspose.BarCode.Generation;
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
using Practice;
using Practice.Base;
using Practice.str;
using Practice.Straniza;

namespace Practice.str
{
    /// <summary>
    /// Логика взаимодействия для add_service.xaml
    /// </summary>
    public partial class add_service : Page
    {

        Frame frame1;
        string user;
        public add_service(string User, Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            user = User;
        }

        private async void AddS_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ServiceA.Text != "" && PriceA.Text != "")
            {
                try
                {
                    List<Service> services = new List<Service> { new Service() };
                    List<Service> services1 = new List<Service> { new Service() };
                    services1 = Entities1.GetContext().Service.ToList();
                    services[0].Service1 = ServiceA.Text;
                    services[0].Price = Convert.ToDouble(PriceA.Text);
                    Entities1.GetContext().Service.Add(services[0]);
                    Entities1.GetContext().SaveChanges();
                    await Task.Delay(500);
                    services1 = Entities1.GetContext().Service.ToList();
                    BarcodeGenerator generator = new BarcodeGenerator(EncodeTypes.Code128, Convert.ToString(services1.Last().id + 1));
                    var imageType = "Png";
                    // установить разрешение
                    generator.Parameters.Resolution = 400;
                    string imagePath = "barcode" + (services1.Last().id) + ".Png";
                    string path = System.IO.Path.GetFullPath(imagePath);
                    // сгенерировать штрих-код          
                    generator.Save(imagePath, BarCodeImageFormat.Png);
                    services1.Last().barcode = path;
                    Entities1.GetContext().SaveChanges();
                    frame1.Navigate(new Glavn(user, frame1, 1));
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте формат введенных данных");
                }
            }
        }

      
        private void back_service(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Glavn(user, frame1, 1));
        }
    }
}
