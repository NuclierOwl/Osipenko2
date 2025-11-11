using Avalonia.Controls;
using OsipenkoN.Conect;
using OsipenkoN.Date;
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

            if (bd.Users.FirstOrDefault(a=> a.Name == login && a.Pasword == password) == null)
            bd.Add(
                new User
                {
                    Name = login,
                    Pasword = password,
                    Role = role,

                });
            bd.SaveChanges();
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

            if (users != null)
            {
                users.Name = loginbox.Text;
                users.Pasword = passbox.Text;
                users.Role = Rolebox.Text;
            }
            bd.SaveChanges();
        }
    }

    private void Unban_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (var bd = new bdBetka())
        {
            var razban = bd.Users.FirstOrDefault(a => a.Name == loginbox.Text && a.Pasword == passbox.Text);
            if (razban != null)
            {
                razban.Ban = false;
            }
            bd.SaveChanges();
        }
    }
}