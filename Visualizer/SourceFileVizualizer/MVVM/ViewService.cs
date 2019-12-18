namespace SourceFileVizualizer.MVVM
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    public class ViewService
    {
        private static Dictionary<Type, Type> registeredViews;

        private static Dictionary<ViewModelBase, Window> openedWindows;

        static ViewService()
        {
            registeredViews = new Dictionary<Type, Type>();
            openedWindows = new Dictionary<ViewModelBase, Window>();
        }

        public static void RegisterView(Type viewModel, Type window)
        {
            registeredViews[viewModel] = window;
        }

        public static void ShowDialog(ViewModelBase viewModel, ViewModelBase parent = null)
        {
            Type windowType;

            if (registeredViews.TryGetValue(viewModel.GetType(), out windowType))
            {
                Window window = Activator.CreateInstance(windowType) as Window;

                if (window != null)
                {
                    window.DataContext = viewModel;

                    openedWindows[viewModel] = window;

                    if (parent != null)
                    {
                        Window parentWindow;
                        if (openedWindows.TryGetValue(parent, out parentWindow))
                        {
                            window.Owner = parentWindow;
                        }
                    }

                    window.ShowDialog();
                }
            }
        }

        public static void CloseDialog(ViewModelBase viewModel)
        {
            Window windowToClose;

            if (openedWindows.TryGetValue(viewModel, out windowToClose))
            {
                windowToClose.Close();
                openedWindows.Remove(viewModel);
            }
        }

        public static void AddMainWindowToOpened(ViewModelBase viewModel, Window window)
        {
            if (viewModel != null && window != null)
            {
                openedWindows[viewModel] = window;
            }
        }
    }
}
