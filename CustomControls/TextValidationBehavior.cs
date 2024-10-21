using Microsoft.Xaml.Behaviors;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RackManager.CustomControls
{
    class TextValidationBehavior : Behavior<TextBox>
    {
        // Using a DependencyProperty as the backing store for AllowLetters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegexProperty =
            DependencyProperty.Register
            (
            "RegexValue",
            typeof(string),
            typeof(TextValidationBehavior)
            );


        public string RegexValue
        {
            get { return (string)GetValue(RegexProperty); }
            set { SetValue(RegexProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += PreviewTextInputHandler;
            AssociatedObject.PreviewKeyDown += PreviewKeyDownHandler;
            DataObject.AddPastingHandler(AssociatedObject, PasteEventHandler);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= PreviewTextInputHandler;
            AssociatedObject.PreviewKeyDown -= PreviewKeyDownHandler;
            DataObject.RemovePastingHandler(AssociatedObject, PasteEventHandler);
        }

        private void PasteEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.StringFormat))
            {
                if (!IsValid((String)e.DataObject.GetData(DataFormats.StringFormat)))
                {
                    e.CancelCommand();
                }
                Debug.WriteLine(e.Handled);
            }
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private bool IsValid(string text)
        {
            Regex regex = new Regex(RegexValue);
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;

        }
    }
}
