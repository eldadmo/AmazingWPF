using AmazingWPF.Screens;
using Caliburn.Micro;

namespace AmazingWPF.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.AllActive , IShellViewModel
    {
        public IMainViewModel MainViewModel { get; }

        public ShellViewModel(IMainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
    }
}