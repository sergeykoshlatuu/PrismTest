using Xamarin.Forms;

namespace BookModule.Views
{
    public partial class BookPage : ContentPage
    {
        public BookPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
