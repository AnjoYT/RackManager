using System.Windows;

namespace RackManager.Commands
{
    public class RelayCommand<T> : CommandBase
    {
        private readonly Action<T> _action;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                _action?.Invoke((T)parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
