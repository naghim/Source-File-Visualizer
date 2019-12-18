namespace SourceFileVizualizer.MVVM
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
