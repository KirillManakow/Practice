using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Frame frame1;
        public Registr(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void Back_avt(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Avtorizacia(frame1));
        }

        private void registration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                string log = login.Text;
                string pas = password.Text;
                string pas1 = password_repeat.Text;
                string names = name.Text;
                if (log != "")
                {
                    if (pas != "")
                    {
                        if (pas1 != "")
                        {
                            if (pas == pas1)
                            {
                                List<Practice.Base.users> user = new List<Practice.Base.users>() { new Base.users() };
                                int count = Base.Entities1.GetContext().users.Count();
                                user[0].id = count + 1;
                                user[0].login = log;
                                user[0].ip = Dns.GetHostName();
                                user[0].password = pas;
                                user[0].name = names;
                                Base.Entities1.GetContext().users.Add(user[0]);
                                Base.Entities1.GetContext().SaveChanges();
                                frame1.Navigate(new Avtorizacia(frame1));
                            }
                            else
                            {
                                MessageBox.Show("Пароли не совпадают");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Повторите пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин");
                }

            }
        }

    }

