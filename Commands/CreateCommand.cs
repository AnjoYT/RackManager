using RackManager.Stores;
using RackManager.ViewModels;

namespace RackManager.Commands
{
    class CreateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly Func<TViewModel> viewModel;
        private readonly NavigationStore navigationStore;
        private readonly Action action;
        public CreateCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, Action action)
        {
            this.action = action;
            this.viewModel = viewModel;
            this.navigationStore = navigationStore;
        }
        //public override bool CanExecute(object? parameter)
        //{
        //    return base.CanExecute(parameter);
        //}
        public override void Execute(object? parameter)
        {
            action?.Invoke();
            navigationStore.CurrentViewModel = this.viewModel();
        }
    }
}
