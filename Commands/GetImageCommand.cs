using RackManager.Services;
using RackManager.ViewModels;

namespace RackManager.Commands
{
    class GetImageCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase, IGetImage
    {
        private readonly ImageService imageService;
        private readonly TViewModel viewModel;
        public GetImageCommand(ImageService imageService, TViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.imageService = imageService;
        }
        public override void Execute(object? parameter)
        {

            viewModel.Image = this.imageService.Open();
        }
    }
}
