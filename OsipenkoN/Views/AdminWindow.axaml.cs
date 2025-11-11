using Avalonia.Controls;
using OsipenkoN.Conect;
using OsipenkoN.Date;
using System.Collections.Generic;
using System.Linq;

namespace OsipenkoN;

public partial class AdminWindow : Window
{
    public AdminWindow()
    {
        InitializeComponent();
    }

    private void Add_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (var bd = new bdBetka())
        {
            string login = loginbox.Text;
            string password = passbox.Text;
            string role = Rolebox.Text;

            if (login != null && password != null && (role == "Администратор" || role == "Пользователь"))
            {
                bd.Add(
                    new User
                    {
                        Name = login,
                        Pasword = password,
                        Role = role,

                    });
            }
        }
    }

    private void Edit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string login = loginbox.Text;
        string password = passbox.Text;
        string role = Rolebox.Text;
        using (var bd = new bdBetka())
        {
            var users = bd.Users.FirstOrDefault(a => a.Name == loginbox.Text);
        }
    }
}