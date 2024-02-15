using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Comms;
using WpfApp1.Model;
using WpfApp1.Stores;
using WpfApp1.ViewModel;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Interface _interface;
        private readonly NavStore _navStore;
        private readonly WybieratorFrajdyVM WFVM;
        public App()
        {
            _interface = new Interface("Generator Frajdy");
            _navStore = new NavStore();
            WFVM = new WybieratorFrajdyVM(_interface, _navStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navStore.CurrentVM = new WybieratorFrajdyVM(_interface, _navStore);
            MainWindow = new MainWindow()
            {
                DataContext = new GlowneVM(_navStore)
            };
            MainWindow.Show();
            
            base.OnStartup(e);
        }
         
    }
}