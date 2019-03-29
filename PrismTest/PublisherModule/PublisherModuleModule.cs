using Prism.Ioc;
using Prism.Modularity;
using PublisherModule.Views;
using PublisherModule.ViewModels;

namespace PublisherModule
{
    public class PublisherModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PublisherListPage, PublisherListPageViewModel>();
            containerRegistry.RegisterForNavigation<PublisherPage, PublisherPageViewModel>();

        }
    }
}
