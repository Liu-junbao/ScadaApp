﻿using Prism.Ioc;
using ScadaApp.Views;
using System.Windows;
using Prism.Modularity;
using ScadaApp.Modules.ModuleName;
using ScadaApp.Services.Interfaces;
using ScadaApp.Services;

namespace ScadaApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
