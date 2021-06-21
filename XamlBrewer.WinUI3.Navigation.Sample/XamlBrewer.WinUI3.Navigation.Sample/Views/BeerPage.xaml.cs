using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class BeerPage : Page
    {
        public BeerPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var beerItem = (Application.Current as App).Navigation.GetNavigationViewItems(this.GetType()).First();
            beerItem.MenuItems.Add(new NavigationViewItem
            {
                Content = $"Round {beerItem.MenuItems.Count + 1}",
                Tag = typeof(BeerDetailsPage).FullName
            });
            beerItem.IsExpanded = true;
        }
    }
}
