﻿using System;
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
using Practice.Straniza;

namespace Practice.str
{
    /// <summary>
    /// Логика взаимодействия для add_rezult.xaml
    /// </summary>
    public partial class add_rezult : Page
    {
        Frame frame1;
        string user;
        public add_rezult(string User, Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            user = User;
            var allP = Entities1.GetContext().users.ToList();
            allP.Insert(0, new users
            {
                name = "Пациент"
            });
            Patient_ADD.ItemsSource = allP;
            Patient_ADD.SelectedIndex = 0;
            var allL = Entities1.GetContext().Workers.ToList();
            allL.Insert(0, new Workers
            {
                name = "Лаборант"
            });
            Laborant_ADD.ItemsSource = allL;
            Laborant_ADD.SelectedIndex = 0;
            var allS = Entities1.GetContext().Service.ToList();
            allS.Insert(0, new Service
            {
                Service1 = "Услуга"
            });
            Service_ADD.ItemsSource = allS;
            Service_ADD.SelectedIndex = 0;
        }

        private void AddR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Patient_ADD.SelectedIndex != 0 && Laborant_ADD.SelectedIndex != 0 && Service_ADD.SelectedIndex != 0 && Result_ADD.Text != "" && Date_Add.Text != null)
            {
                try
                {
                    List<Results> results = new List<Results> { new Results() };
                    
                    results[0].id_user = Patient_ADD.SelectedIndex;
                    results[0].id_work = Laborant_ADD.SelectedIndex;
                    results[0].id_service = Service_ADD.SelectedIndex;
                    results[0].result = Result_ADD.Text;
                    results[0].date = Convert.ToDateTime(Date_Add.Text);
                    Entities1.GetContext().Results.Add(results[0]);
                    Entities1.GetContext().SaveChanges();
                    frame1.Navigate(new Glavn(user, frame1, 1));
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте формат введенных данных");
                }
            }
        }



        private void back_rezult(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Glavn(user, frame1,1));
        }
    }
}

