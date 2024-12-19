using RackManager.Stores;
using RackManager.ViewModels;

namespace RackManager.Commands
{
    public class NavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModel;

        public NavigationCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, Action<object>? action = null)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {

            _navigationStore.CurrentViewModel = _viewModel();
        }
    }
}
