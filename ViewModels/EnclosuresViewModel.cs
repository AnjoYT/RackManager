using RackManager.Models;
using RackManager.Services;
using RackManager.Stores;
using System.Collections.ObjectModel;

namespace RackManager.ViewModels
{
    class EnclosuresViewModel : ViewModelBase
    {
        private readonly EnclosureService _enclosureService;
        private readonly NavigationStore _store;

        public ObservableCollection<EnclosureModel> Cards => _enclosureService.enclosures;

        public EnclosuresViewModel(NavigationStore store, EnclosureService serviceService)
        {
            _enclosureService = serviceService;
            _store = store;
        }
    }
}
