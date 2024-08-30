namespace RackManager.Services
{
    public class ImageService
    {
        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                if (value != null)
                {
                    imagePath = value;
                }
            }
        }
        private readonly FileDialogService fileDialogService;
        private string filter => "Image Files (*.img;*.png;*.jpg)|*.img;*.png;*.jpg";
        public ImageService()
        {
            fileDialogService = new FileDialogService();
        }
        public string Open()
        {
            ImagePath = fileDialogService.Open(filter);
            return ImagePath;
        }
    }
}
