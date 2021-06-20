using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class HomePage : Page
    {
        private static NavigationViewItem BeerItem => (Application.Current as App).Navigation.GetNavigationViewItems(typeof(BeerPage)).First();

        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Since we're not storing the state here, we have to derive it from the menu.
            BeerCheckBox.IsChecked = BeerItem.Visibility == Visibility.Visible;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BeerItem.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BeerItem.Visibility = Visibility.Collapsed;
        }

        private void Hyperlink_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var navigation = (Application.Current as App).Navigation;
            var festivalItem = navigation.GetNavigationViewItems(typeof(AboutPage)).First();
            navigation.SetCurrentNavigationViewItem(festivalItem);
        }
    }
}
