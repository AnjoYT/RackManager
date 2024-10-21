using System.Windows.Input;

namespace RackManager.ViewModels
{
    class ViewAnimalViewModel
    {
        public ICommand ModifyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ViewAnimalViewModel()
        {

        }

    }
}
