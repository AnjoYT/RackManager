using System.Windows.Input;

namespace RackManager.Commands
{
    public class NavigationCommand : CommandBase
    {
        public ICommand AnimalCommand { get; set; }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
