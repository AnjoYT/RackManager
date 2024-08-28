using System.ComponentModel;

namespace RackManager.Services
{
    public class ImageService
    {
        public event EventHandler? ImageLoaded;
        public string ImagePath { get; private set; }
        private readonly FileDialogService fileDialogService;
        private string filter = "Image Files (*.img;*.png;*.jpg)|*.img;*.png;*.jpg";
        public ImageService()
        {
            fileDialogService = new FileDialogService();
        }
        public string Open()
        {
            ImagePath = fileDialogService.Open(filter);
            OnImageLoaded(this, new PropertyChangedEventArgs(nameof(this.ImagePath)));
            return ImagePath;
        }
        public void OnImageLoaded(object? sender, PropertyChangedEventArgs e)
        {
            ImageLoaded?.Invoke(sender, e);
        }
    }
}
