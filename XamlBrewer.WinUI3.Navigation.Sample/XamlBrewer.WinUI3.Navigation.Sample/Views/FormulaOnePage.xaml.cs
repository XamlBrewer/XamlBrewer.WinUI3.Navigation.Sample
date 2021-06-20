using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class FormulaOnePage : Page
    {
        public FormulaOnePage()
        {
            this.InitializeComponent();
        }

        private void Hyperlink_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var navigation = (Application.Current as App).Navigation;
            var festivalItem = navigation.GetNavigationViewItems(typeof(FestivalPage)).First();
            navigation.SetCurrentNavigationViewItem(festivalItem);
        }
    }
}
