using Prism.Ioc;
using Prism.Modularity;
using AuthorModule.Views;
using AuthorModule.ViewModels;

namespace AuthorModule
{
    public class AuthorModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AuthorListPage, AuthorListPageViewModel>();
            containerRegistry.RegisterForNavigation<AuthorPage, AuthorPageViewModel>();

        }
    }
}
