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
using System.Windows.Shapes;
using Practice;
using Practice.Base;
using Practice.Straniza;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        object item;
        public Print(object Item)
        {
            InitializeComponent();
            item = Item;
            List<Results> results = new List<Results> { new Results() };
            results[0] = (Results)item;
            IdPrint.Text = Convert.ToString(results[0].id);
            Patient.Text = results[0].users.name;
            DatePrint.Text = Convert.ToString(results[0].date);
            NamePrint.Text = results[0].Service.Service1;
            PricePrint.Text = Convert.ToString(results[0].Service.Price);
            PricePrint_Copy.Text = Convert.ToString(results[0].Service.Price);
            PricePrint_Copy1.Text = Convert.ToString(results[0].Service.Price);
            PricePrint_Copy2.Text = Convert.ToString(results[0].Service.Price);
            PricePrint_Copy3.Text = Convert.ToString(results[0].Service.Price);
        }

        private async void Print_Otpr_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printd = new PrintDialog();
            if(printd.ShowDialog() ==true)
            {
                Print_Otpr.Visibility = Visibility.Collapsed;
                await Task.Delay(1000);
                printd.PrintVisual(Printgrid, "Отправлено на печать");
            }
         
            Close();
        }
    }
}
