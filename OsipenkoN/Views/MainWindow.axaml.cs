using Avalonia.Controls;
using OsipenkoN.Conect;
using OsipenkoN.Date;
using System.Collections.Generic;
using System.Linq;

namespace OsipenkoN.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (var bd = new bdBetka())
        {
            string login = loginBox.Text;
            string pass = PassBox.Text;
            var user = bd.Users.FirstOrDefault(e => e.Name == login && e.Pasword == pass);

            if (user != null)
            {
                Window next = new Window();

                switch (user.Role)
                {
                    case ("Администратор"):
                        next = new AdminWindow();
                        next.Show();
                        this.Close();
                        break;
                    case ("Пользователь"):
                        next = new UserWindow();
                        next.Show();
                        this.Close();
                        break;
                    default:
                        next = new AdminWindow();
                        next.Show();
                        this.Close();
                        break;
                };


            }
        }
    }
}
