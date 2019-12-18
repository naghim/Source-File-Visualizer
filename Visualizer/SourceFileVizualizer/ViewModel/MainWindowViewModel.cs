namespace SourceFileVizualizer.ViewModel
{
    using SourceFileVizualizer.MVVM;

    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        private VizualizeViewModel vizualizeVM;
        private ChooseFileViewModel chooseFileVM;
        private int tabControlSelectedIndex;

        public MainWindowViewModel()
        {
            this.ChooseFileVM = new ChooseFileViewModel();
            this.VizualizeVM = new VizualizeViewModel();
            MainWindowViewModel.Instance = this;
        }

        public int TabControlSelectedIndex
        {
            get => this.tabControlSelectedIndex;
            set
            {
                this.tabControlSelectedIndex = value;
                this.RaisePropertyChanged();
            }
        }

        public VizualizeViewModel VizualizeVM
        {
            get => this.vizualizeVM;
            set
            {
                this.vizualizeVM = value;
                this.RaisePropertyChanged();
            }
        }

        public ChooseFileViewModel ChooseFileVM
        {
            get => this.chooseFileVM;
            set
            {
                this.chooseFileVM = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
