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
        public List<Results> results = new List<Results> { };
        List<Results> r = new List<Results> { new Results() };
        public Print(string User, Frame frame, List<Results> resultat, object itemm)
        {
            InitializeComponent();
            frame1 = frame;
            user = User;
            item = itemm;
            results = resultat;
            //patient_pr.Text = results[0].users.name;
            //Laborant_pr.Text = results[0].Workers.name;
            //Service_pr.Text =results[0].Service.Service1;          
            //price_pr.Text = results[0].Service.Price.ToString();
            //Rezult_pr.Text = results[0].result;
            //Date_pr.Text = results[0].date.ToString();

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
