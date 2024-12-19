namespace RackManager.ViewModels
{
    public interface IArduinoConnection
    {
        public void CreateArduinoConnection(string selectedPort);
        public void OnDataReceived(string data);
        public Dictionary<string, float> ParseArduinoData(string data);
    }
}
