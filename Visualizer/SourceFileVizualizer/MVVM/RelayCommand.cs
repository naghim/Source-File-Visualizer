namespace SourceFileVizualizer.MVVM
{
    using System;
    using System.Windows.Input;

    public class RelayCommand<T> : ICommand
    {
        private Action<T> executeAction;

        private Func<bool> canExecuteFunc;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            this.ExecuteAction = execute;
            this.CanExecuteFunc = canExecute;
        }

        public Action<T> ExecuteAction
        {
            get
            {
                return this.executeAction;
            }

            set
            {
                this.executeAction = value;
            }
        }

        public Func<bool> CanExecuteFunc
        {
            get
            {
                return this.canExecuteFunc;
            }

            set
            {
                this.canExecuteFunc = value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc.Invoke();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                if (parameter is T)
                {
                    this.ExecuteAction.Invoke((T)parameter);
                }
                else
                {
                    this.ExecuteAction.Invoke(default(T));
                }
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private Action executeAction;

        private Func<bool> canExecuteFunc;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.ExecuteAction = execute;
            this.CanExecuteFunc = canExecute;
        }

        public Action ExecuteAction
        {
            get
            {
                return this.executeAction;
            }

            set
            {
                this.executeAction = value;
            }
        }

        public Func<bool> CanExecuteFunc
        {
            get
            {
                return this.canExecuteFunc;
            }

            set
            {
                this.canExecuteFunc = value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc.Invoke();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                this.ExecuteAction.Invoke();
            }
        }
    }
}
