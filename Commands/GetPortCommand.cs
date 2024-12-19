using RackManager.ViewModels;
using RackManager.Views;

namespace RackManager.Commands
{
    public class GetPortCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase, IArduinoConnection
    {
        private readonly TViewModel _viewModel;

        public GetPortCommand(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            var portSelectionView = new PortSelectionView();
            var portSelectionViewModel = new PortSelectionViewModel();
            portSelectionViewModel.PortSelected += OnPortSelected;
            portSelectionView.DataContext = portSelectionViewModel;
            if (portSelectionView.ShowDialog() == true)
            {

            }
        }
        private void OnPortSelected(object sender, string selectedPort)
        {
            _viewModel.CreateArduinoConnection(selectedPort);
        }
    }
}
