﻿using System.Windows;
using it.DBProvider;
using it.logonprovider;

namespace it.HLClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var dbProvider = new MongoDbProvider();
            var logonProvider = new WindowsLogonProvider();
            var hlIntegration = new Integration(dbProvider, logonProvider);
            var mainWindow = new MainWindow();
            
            mainWindow.SubmitButtonClickEvent += hlIntegration.Melden;
            
            mainWindow.Show();
        }
    }
}
