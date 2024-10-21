using RackManager.Stores;
using RackManager.ViewModels;

namespace RackManager.Commands
{
    public class NavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<TViewModel> viewModel;

        public NavigationCommand(NavigationStore navigationStore, Func<TViewModel> viewModel)
        {
            this.navigationStore = navigationStore;
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = this.viewModel();
        }
    }
}
