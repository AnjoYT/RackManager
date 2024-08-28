using RackManager.Services;

namespace RackManager.Commands
{
    class GetImageCommand : CommandBase
    {
        private readonly ImageService imageService;
        public GetImageCommand(ImageService imageService)
        {
            this.imageService = imageService;
        }
        public override void Execute(object? parameter)
        {
            this.imageService.Open();
        }
    }
}
