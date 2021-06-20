using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace XamlBrewer.WinUI3.Navigation.Sample.Views
{
    public sealed partial class FestivalDetailsPage : Page
    {
        public FestivalDetailsPage()
        {
            this.InitializeComponent();
            this.Loaded += FestivalDetailsPage_Loaded;
        }

        private void FestivalDetailsPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var festivalName = (Application.Current as App).Navigation.GetCurrentNavigationViewItem().Content.ToString();
            switch (festivalName)
            {
                case "Tomorrowland":
                    FestivalImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Tomorrowland.jpg"));
                    FestivalText.Text = "Tomorrowland is the largest dance music festival of this world. It is held in a village appropriately called 'Boom'.";
                    break;
                case "Rock Werchter":
                    FestivalImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/RockWerchter.jpg"));
                    FestivalText.Text = "Many years ago, some people said 'Let's organize a festival with a name that nobody can pronounce'. It became 'Torhout/Werchter'. Few years later they dropped the easy part from the name.";
                    break;
                default:
                    break;
            }
        }
    }
}
