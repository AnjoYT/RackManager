using RackManager.Models;
using System.Windows;
using System.Windows.Controls;

namespace RackManager.CustomControls
{
    public class CardTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SnakeTemplate { get; set; }
        public DataTemplate AddCardTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BaseCardModel card)
            {
                if (card.IsAddCard)
                {
                    return AddCardTemplate;
                }
                else if (card is SnakeModel)
                {
                    return SnakeTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
