using ArduinoCOMLibrary;
using RackManager.Commands;
using RackManager.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RackManager.ViewModels
{
    public class PortSelectionViewModel : ViewModelBase
    {

        public event EventHandler<string> PortSelected;

        private string _selectedComPort;
        public ObservableCollection<string> AvailableComPorts { get; set; } = ArduinoConnector.AvailablePorts;
        public string SelectedComPort
        {
            get => _selectedComPort;
            set
            {
                _selectedComPort = value;
                OnPropertyChanged(nameof(SelectedComPort));
            }
        }
        public ICommand ConfirmCommand { get; set; }
        public PortSelectionViewModel()
        {
            ConfirmCommand = new RelayCommand<object>(ConfirmPortSelection);
        }
        public void SelectPort(string port)
        {
            SelectedComPort = port;
            OnPortSelected(port);
        }

        private void ConfirmPortSelection(object parameter)
        {
            OnPortSelected(SelectedComPort);

            if (parameter is PortSelectionView window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        private void OnPortSelected(string port)
        {
            PortSelected?.Invoke(this, port);
        }
    }
}

