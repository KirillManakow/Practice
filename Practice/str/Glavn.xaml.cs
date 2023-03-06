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
using System.Windows.Threading;
using Up;

namespace Practice.Straniza
{
    /// <summary>
    /// Логика взаимодействия для Glavn.xaml
    /// </summary>
    public partial class Glavn : Page
    {

  
    private DispatcherTimer _timer;

    public static readonly DependencyProperty TickCounterProperty = DependencyProperty.Register(
        "TickCounter", typeof(int), typeof(Glavn), new PropertyMetadata(default(int)));
    Frame frame1;
    string user;
    List<Practice.Base.history> historys = new List<Practice.Base.history>();
    List<Practice.Base.Service> services = new List<Practice.Base.Service>();
    public Glavn(string User, Frame frame)
    {
        InitializeComponent();
        frame1 = frame;
        user = User;
        int count_hh = Base.Entities1.GetContext().history.Count();
        historys = Base.Entities1.GetContext().history.ToList();
        int time = 0;
        for (int j = count_hh - 1; j >= 0; j--)
        {
            if (historys[j].login == user)
            {
                DateTime b = (DateTime)historys[j].block;
                DateTime d = (DateTime)historys[j].date;
                int h = b.Hour - d.Hour;
                int m = b.Minute - d.Minute;
                time = 60 * h + m;
                break;
            }
        }
        DataContext = sp;
        DateTime dateTime = DateTime.Now;
        TickCounter = time;
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromMinutes(1d);
        _timer.Tick += new EventHandler(Timer_Tick);
        _timer.Start();
        int count = Base.Entities1.GetContext().Service.Count();
        services = Base.Entities1.GetContext().Service.ToList();
        sp.CountPage = 3;
        sp.Countlist = count;
        LViewTours.ItemsSource = services.Skip(0).Take(sp.CountPage).ToList();
        // kolvo_zapice(3);
    }
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    Strelki sp = new Strelki();
    private void kolvo_zapice(int kol)
    {
        try
        {
            sp.CountPage = Convert.ToInt32(kol); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
        }
        catch
        {
            sp.CountPage = services.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
        }
        sp.Countlist = services.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
        LViewTours.ItemsSource = services.Skip(0).Take(sp.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
        sp.CurrentPage = 1; // текущая страница - это страница 1
    }

    private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextBlock tb = (TextBlock)sender;

        switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
        {
            case "prev":
                sp.CurrentPage--;
                break;
            case "next":
                sp.CurrentPage++;
                break;
            case "prev1":
                sp.CurrentPage = 1;
                break;
            case "next1":
                {
                    List<Base.Service> fl = Base.Entities1.GetContext().Service.ToList();
                    int a = fl.Count;
                    int b = Convert.ToInt32(3);

                    if (a % b == 0)
                    {
                        sp.CurrentPage = a / b;
                    }
                    else
                    {
                        sp.CurrentPage = a / b + 1;
                    }

                }
                break;
            default:
                sp.CurrentPage = Convert.ToInt32(tb.Text);
                break;
        }
        LViewTours.ItemsSource = services.Skip(sp.CurrentPage * sp.CountPage - sp.CountPage).Take(sp.CountPage).ToList();
    }
    public int TickCounter
    {
        get { return (int)GetValue(TickCounterProperty); }
        set { SetValue(TickCounterProperty, value); }
    }
    public int soxr = 0;
    private void Timer_Tick(object sender, EventArgs e)
    {

        if (--TickCounter <= 0)
        {
            var timer = (DispatcherTimer)sender;
            timer.Stop();
            if (soxr == 0)
            {
                if (MessageBox.Show("Чтобы закончить работу и закрыть кабинет на кварцевание нажмите да, если хотите продолжить работу на 5 минут нажмите нет", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    TickCounter = 5;
                    _timer = new DispatcherTimer();
                    _timer.Interval = TimeSpan.FromMinutes(1d);
                    _timer.Tick += new EventHandler(Timer_Tick);
                    _timer.Start();
                    soxr = 1;
                }
                else
                {
                    MessageBox.Show("Закрытие программы");
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Закрытие программы");
                Environment.Exit(0);
            }
        }
    }
 }
}

