namespace SourceFileVizualizer.ViewModel
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using SourceFileVizualizer.MVVM;

    public class ChooseFileViewModel : ViewModelBase
    {
        public ChooseFileViewModel()
        {
            this.ChoseFileCommand = new RelayCommand(this.ChoseFileCommandExecute);
        }

        private void ChoseFileCommandExecute()
        {
            try
            {
                // Initialization.  
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Settings.  
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                // Verification  
                if (openFileDialog.ShowDialog() == true)
                {
                    MainWindowViewModel.Instance.TabControlSelectedIndex = 1;
                    VizualizeViewModel.Instance.filePath = openFileDialog.FileName;
                    VizualizeViewModel.Instance.FileName = openFileDialog.SafeFileName;
                    VizualizeViewModel.Instance.loadData();
                }
            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        public RelayCommand ChoseFileCommand { get; private set; }
    }
}
