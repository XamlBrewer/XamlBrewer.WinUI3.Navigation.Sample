using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class BeerDetailsPage : Page
    {
        public BeerDetailsPage()
        {
            this.InitializeComponent();
            this.Loaded += BeerDetailsPage_Loaded;
        }

        private void BeerDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            var content = (Application.Current as App).Navigation.GetCurrentNavigationViewItem().Content.ToString();
            RoundTextBlock.Text = $"Welcome to {content}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Navigation through colleagues
            var navigation = (Application.Current as App).Navigation;
            var item = navigation.GetCurrentNavigationViewItem();
            var siblings = navigation.GetNavigationViewItems(this.GetType());
            var index = siblings.IndexOf(item);
            if (index > 0)
            {
                navigation.SetCurrentNavigationViewItem(siblings[index - 1]);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Navigation within parent
            var navigation = (Application.Current as App).Navigation;
            var item = navigation.GetCurrentNavigationViewItem();
            var mainItems = navigation.GetNavigationViewItems();
            foreach (var mainItem in mainItems)
            {
                // Find the parent
                if (mainItem.MenuItems.Contains(item))
                {
                    var siblings = mainItem.MenuItems;
                    var index = siblings.IndexOf(item);
                    if (index < siblings.Count - 1)
                    {
                        navigation.SetCurrentNavigationViewItem((NavigationViewItem)siblings[index + 1]);
                    }
                }
            }
        }
    }
}
