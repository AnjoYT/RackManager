using RackManager.ViewModels;

namespace RackManager.Stores
{
    public class NavigationStore
    {
        private ViewModelBase currentViewModel;
        public event Action CurrentViewChanged;
        public ViewModelBase CurrentViewModel
        {
            get { return this.currentViewModel; }
            set
            {
                this.currentViewModel = value;
                OnCurrentViewChanged();
            }
        }

        public void OnCurrentViewChanged()
        {
            CurrentViewChanged?.Invoke();
        }
    }
}
