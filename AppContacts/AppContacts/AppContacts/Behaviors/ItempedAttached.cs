using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppContacts.Behaviors
{
    public class ItempedAttached
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
            propertyName: "Command",
            returnType: typeof(ICommand),
            declaringType: typeof(ListView),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            validateValue: null,
            propertyChanged: OnItemTappedChanged);

        private static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ListView;
            if (control != null)
            {
                control.ItemTapped -= Control_ItemTapped;
                control.ItemTapped += Control_ItemTapped;
            }
        }

        private static void Control_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var control = sender as ListView;
            var command = GetItemTapped(control);
            if (command != null && command.CanExecute(e.Item))
            {
                command.Execute(e.Item);
            }
        }

        public static ICommand GetItemTapped(BindableObject bindable)
        {
            return (ICommand)bindable.GetValue(CommandProperty);
        }
        private static void SetItemTapped(BindableObject bindable, ICommand value)
        {
            bindable.SetValue(CommandProperty, value);
        }
        public ItempedAttached()
        {

        }
    }
}
