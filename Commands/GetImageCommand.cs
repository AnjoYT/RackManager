using RackManager.Services;
using RackManager.ViewModels;

namespace RackManager.Commands
{
    class GetImageCommand : CommandBase
    {
        private readonly ImageService imageService;
        private readonly AddAnimalViewModel viewModel;
        public GetImageCommand(ImageService imageService, AddAnimalViewModel viewModel)
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
