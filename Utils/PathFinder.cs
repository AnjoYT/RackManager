using System.IO;

namespace RackManager.CustomControls
{
    public class PathFinder
    {
        public static string RelativePath(string pathRelativeToDir, string file)
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string folderPath = Path.Combine(projectDirectory, pathRelativeToDir);
            string filePath = Path.Combine(folderPath, file);
            return filePath;
        }
    }
}
