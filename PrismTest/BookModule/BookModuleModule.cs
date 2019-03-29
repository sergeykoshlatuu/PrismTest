using Prism.Ioc;
using Prism.Modularity;
using BookModule.Views;
using BookModule.ViewModels;

namespace BookModule
{
    public class BookModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BookListPage, BookListPageViewModel>();
            containerRegistry.RegisterForNavigation<BookPage, BookPageViewModel>();

        }
    }
}
