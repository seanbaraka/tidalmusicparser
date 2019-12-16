using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TidalMusicPlayer.DataModels;

namespace TidalMusicPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var accxt = new AccountsContext();
            accxt.Database.Migrate();
            accxt.Users.Add(new User
            {
                Username = "andrewjobel",
                Password = "12345678"
            });
            base.OnStartup(e);
        }
    }
}
