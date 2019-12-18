namespace SourceFileVizualizer
{
    using SourceFileVizualizer.MVVM;
    using SourceFileVizualizer.View;
    using SourceFileVizualizer.ViewModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.OpenMainWindow();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
        }

        /// <summary>
        /// Opens the main window.
        /// </summary>
        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }
    }
}
