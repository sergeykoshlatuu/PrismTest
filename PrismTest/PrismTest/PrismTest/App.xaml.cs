using Prism;
using Prism.Ioc;
using Prism.Modularity;
using PrismTest.ViewModels;
using PrismTest.Views;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Services;
using Unity.Lifetime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismTest
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
            

        }

        public IDatabaseConnectionService DBService { get; private set; }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/Index/Navigation/BookListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>("Index");

            DBService = this.Container.Resolve<IDatabaseConnectionService>();
            containerRegistry.RegisterInstance<IBookService>(new BookService(DBService));
            containerRegistry.RegisterInstance<IAuthorService>(new AuthorsService(DBService));
            containerRegistry.RegisterInstance<IPublisherService>(new PublisherService(DBService));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<BookModule.BookModuleModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<AuthorModule.AuthorModuleModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<PublisherModule.PublisherModuleModule>(InitializationMode.WhenAvailable);

        }

    }
}
