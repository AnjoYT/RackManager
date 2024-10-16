using System.Windows;
using System.Windows.Controls;

namespace RackManager.CustomControls
{
    class ButtonTemplateSelector : DataTemplateSelector
    {
        //FUTURE NOTE: create generalized version for button and card selectors
        public DataTemplate versionOne { get; set; }
        public DataTemplate versionTwo { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is not null)
            {
                return versionOne;
            }
            else
            {
                return versionTwo;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
