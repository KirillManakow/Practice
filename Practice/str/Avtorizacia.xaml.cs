﻿using System;
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
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Frame frame1;
        DateTime date;
        public Avtorizacia(Frame frame)
        {
            
            frame1 = frame;
            InitializeComponent();
            password1.Visibility = Visibility.Hidden;
            glas_show.Visibility = Visibility.Hidden;
            date = DateTime.Now;

        }

        public void vxod()
        {
            string user = login.Text;
            string pas = password.Password;
            int count = Base.Entities1.GetContext().users.Count();
            int count_hh = Base.Entities1.GetContext().history.Count();
            int count_w = Base.Entities1.GetContext().Workers.Count();
            worker = Base.Entities1.GetContext().Workers.ToList();
            Users = Base.Entities1.GetContext().users.ToList();
            historys = Base.Entities1.GetContext().history.ToList();
            for (int i = 0; i < count_w; i++)
            {
                if (worker[i].login == user)
                {
                    if (worker[i].password == pas)
                    {
                        for (int j = count_hh - 1; j >= 0; j--)
                        {
                            if (historys[j].login == user)
                            {
                                DateTime t = DateTime.Now;
                                if (historys[j].block != null)
                                {
                                    t = (DateTime)historys[j].block;
                                    t = t.AddMinutes(30);
                                }
                                if (DateTime.Now < historys[j].block || t <= DateTime.Now)
                                {
                                    vx = 1;
                                    int count_h = Base.Entities1.GetContext().history.Count();
                                    history_login[0].id = count_h + 1;
                                    history_login[0].login = user;
                                    history_login[0].date = DateTime.Now;
                                    history_login[0].ip = Dns.GetHostName();
                                    if (historys[j].block < DateTime.Now)
                                    {
                                        history_login[0].block = date.AddHours(2.5);
                                    }
                                    else
                                    {
                                        history_login[0].block = historys[j].block;
                                    }
                                    Base.Entities1.GetContext().history.Add(history_login[0]);
                                    Base.Entities1.GetContext().SaveChanges();
                                    frame1.Navigate(new Glavn(worker[i].login, frame1,1));
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Перерыв пол часа");
                                    vx = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (Users[i].login == user)
                {
                    if (Users[i].password == pas)
                    {
                        for (int j = count_hh - 1; j >= 0; j--)
                        {
                            if (historys[j].login == user)
                            {
                                DateTime t = DateTime.Now;
                                if (historys[j].block != null)
                                {
                                    t = (DateTime)historys[j].block;
                                    t = t.AddMinutes(30);
                                }
                                if (DateTime.Now < historys[j].block || t <= DateTime.Now)
                                {
                                    vx = 1;
                                    int count_h = Base.Entities1.GetContext().history.Count();
                                    history_login[0].id = count_h + 1;
                                    history_login[0].login = user;
                                    history_login[0].date = DateTime.Now;
                                    history_login[0].ip = Dns.GetHostName();
                                    if (historys[j].block < DateTime.Now)
                                    {
                                        history_login[0].block = date.AddHours(2.5);
                                    }
                                    else
                                    {
                                        history_login[0].block = historys[j].block;
                                    }
                                    Base.Entities1.GetContext().history.Add(history_login[0]);
                                    Base.Entities1.GetContext().SaveChanges();
                                    frame1.Navigate(new Glavn(Users[i].login, frame1, 1));
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Перерыв пол часа");
                                    vx = 1;
                                    break;
                                }
                            }


                        }
                    }
                }
            }
            if (vx == 0)
            {
                MessageBox.Show("Неверный логин или пароль");
                error++;
            }
        }
        public int vx = 0;
        List<Practice.Base.users>   Users = new List<Practice.Base.users>();
        List<Practice.Base.Workers> worker = new List<Practice.Base.Workers>();
        List<Practice.Base.history> history_login = new List<Practice.Base.history> { new Practice.Base.history() };
        List<Practice.Base.history> historys = new List<Practice.Base.history>();
        int error = 0;
        private void Entre_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Capcha capcha = new Capcha();
            if (error > 1)
            {
                capcha.ShowDialog();

                if (capcha.pr > 0)
                {
                    vx = 0;
                    vxod();
                }
            }
            else
            {
                vx = 0;
                vxod();
            }

        }


        private void Enter(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Registr(frame1));
        }

        private void glas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            password.Visibility = Visibility.Hidden;
            password1.Visibility = Visibility.Visible;
            glas.Visibility = Visibility.Hidden;
            glas_show.Visibility = Visibility.Visible;
            password1.Text = password.Password;
        }

        private void glas_show_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            password.Visibility = Visibility.Visible;
            password1.Visibility = Visibility.Hidden;
            glas.Visibility = Visibility.Visible;
            glas_show.Visibility = Visibility.Hidden;
            password.Password = password1.Text;
        }
    }
}
