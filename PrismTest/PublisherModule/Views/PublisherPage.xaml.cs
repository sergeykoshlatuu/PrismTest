using Xamarin.Forms;

namespace PublisherModule.Views
{
    public partial class PublisherPage : ContentPage
    {
        public PublisherPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
