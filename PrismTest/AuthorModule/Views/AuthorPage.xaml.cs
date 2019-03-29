using Xamarin.Forms;

namespace AuthorModule.Views
{
    public partial class AuthorPage : ContentPage
    {
        public AuthorPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
