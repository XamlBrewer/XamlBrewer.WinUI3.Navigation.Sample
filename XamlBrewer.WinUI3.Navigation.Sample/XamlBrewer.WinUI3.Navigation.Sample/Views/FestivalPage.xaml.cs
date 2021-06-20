using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class FestivalPage : Page
    {
        public FestivalPage()
        {
            this.InitializeComponent();
        }

        private void Hyperlink_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var navigation = (Application.Current as App).Navigation;
            navigation.GetCurrentNavigationViewItem().IsExpanded = true;
            var festivalItem = navigation.GetNavigationViewItems(typeof(FestivalDetailsPage)).First();
            navigation.SetCurrentNavigationViewItem(festivalItem);
        }

        private void Hyperlink1_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var navigation = (Application.Current as App).Navigation;
            navigation.GetCurrentNavigationViewItem().IsExpanded = true;
            var festivalItem = navigation.GetNavigationViewItems(typeof(FestivalDetailsPage), "Rock Werchter").First();
            navigation.SetCurrentNavigationViewItem(festivalItem);
        }
    }
}
