using Microsoft.Win32;

namespace RackManager.Services
{
    class FileDialogService
    {
        public string Open(string filtering)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = filtering
            };
            if (dialog.ShowDialog() is true)
            {
                return dialog.FileName ?? string.Empty;
            }
            return string.Empty;
        }

    }
}
