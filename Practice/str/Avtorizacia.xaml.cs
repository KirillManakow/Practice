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

namespace Practice.Straniza
{
    /// <summary>
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Frame frame1;
        public Avtorizacia(Frame frame)
        {
            frame1 = frame;
            InitializeComponent();

        }

        public int vx = 0;
        List<Practice.users> Users = new List<Practice.users>();
        List<Practice.Workers> worker = new List<Practice.Workers>();
        List<Practice.history> history_enter = new List<Practice.history> {new history()};
        private void Entre_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Capcha capcha = new Capcha();
            capcha.Show();

            string user = login.Text;
            string pas = password.Password;
            int count = Entities1.GetContext().users.Count();
            int count_w = Entities1.GetContext().Workers.Count();
            worker = Entities1.GetContext().Workers.ToList();
            Users = Entities1.GetContext().users.ToList();
            for (int i = 0; i < count_w; i++)
            {
                if (worker[i].login == user)
                {
                    if (worker[i].password == pas)
                    {
                        frame1.Navigate(new Glavn(worker[i].login,frame1));
                        vx = 1;
                        int count_h = Entities1.GetContext().history.Count();
                        history_enter[0].id = count_h + 1;
                        history_enter[0].login = user;
                        history_enter[0].date = DateTime.Now;
                        Entities1.GetContext().history.Add(history_enter[0]);
                        Entities1.GetContext().SaveChanges();
                        break;
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (Users[i].login == user)
                {
                    if (Users[i].password == pas)
                    {
                        frame1.Navigate(new Glavn(Users[i].login, frame1));
                        vx = 1;
                        int count_h = Entities1.GetContext().history.Count();
                        history_enter[0].id = count_h + 1;
                        history_enter[0].login = user;
                        history_enter[0].date = DateTime.Now;
                        Entities1.GetContext().history.Add(history_enter[0]);
                        Entities1.GetContext().SaveChanges();
                        break;
                    }
                }
            }
            if (vx == 0)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Enter(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Registr(frame1));
        }
    }
}
