using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RackManager.Utils
{
    public static class CommandExtensions
    {
        // Define the attached property "Command" to store ICommand instances.
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command", // The name of the attached property.
                typeof(ICommand), // The type of the property (ICommand).
                typeof(CommandExtensions), // The owner type, which is the CommandExtensions class.
                new PropertyMetadata(null, OnCommandChanged)); // Default value is null, and OnCommandChanged is the callback method when the property changes.

        // Method to retrieve the command attached to the StackPanel.
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty); // Get the value of the Command attached property from the DependencyObject (e.g., StackPanel).
        }

        // Method to set the command on the StackPanel.
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value); // Set the value of the Command attached property on the DependencyObject (e.g., StackPanel).
        }

        // This method is called whenever the Command property is set or changed.
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StackPanel stackPanel) // Check if the DependencyObject is a StackPanel.
            {
                // Unsubscribe from any existing Loaded event handler to avoid multiple subscriptions.
                stackPanel.Loaded -= OnStackPanelLoaded;
                // Subscribe to the Loaded event of the StackPanel.
                stackPanel.Loaded += OnStackPanelLoaded;
            }
        }

        // Event handler method that gets called when the StackPanel is loaded into the visual tree.
        private static void OnStackPanelLoaded(object sender, RoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel; // Cast the sender to a StackPanel.
            var command = GetCommand(stackPanel); // Retrieve the command attached to this StackPanel.

            if (command != null && command.CanExecute(null)) // Check if the command is not null and can be executed.
            {
                command.Execute(null); // Execute the command with no parameters.
            }
        }
    }
}
