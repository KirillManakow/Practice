using Practice.Straniza;
using Practice.Base;
using Practice.Straniza;
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

namespace Practice.str
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Page
    {
        Frame frame1;
        string user;
        object item;
        List<Results> results = new List<Results> { };
        public List<Results> r = new List<Results> { new Results() };

        public Print(string User, Frame frame, object itemm, List<Results> r)
        {
            InitializeComponent();          
            frame1 = frame;
            user = User;
            item = itemm;
            results = Entities1.GetContext().Results.ToList();
            var allP = Entities1.GetContext().users.ToList();
            allP.Insert(0, new users
            {
                name = "Пациент"
            });
            patient_pr.ItemsSource = allP;
            var allL = Entities1.GetContext().Workers.ToList();
            allL.Insert(0, new Workers
            {
                name = "Лаборант"
            });
            Laborant_pr.ItemsSource = allL;
            var allS = Entities1.GetContext().Service.ToList();
            allS.Insert(0, new Service
            {
                Service1 = "Услуга"
            });
            Service_pr.ItemsSource = allS;
            r[0] = (Results)item;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].id == r[0].id)
                {
                    patient_pr.SelectedIndex = results[i].id_user;
                    Laborant_pr.SelectedIndex = (int)results[i].id_work;
                    Service_pr.SelectedIndex = (int)results[i].id_service;
                    Rezult_pr.Text = results[i].result;
                    Date_pr.Text = Convert.ToString(results[i].date);
                }
            }
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Glavn(user, frame1,1));
        }
      
        private void prints_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Билет отправлен на печать");
            frame1.Navigate(new Glavn(user, frame1,1));
        }
    }
}
