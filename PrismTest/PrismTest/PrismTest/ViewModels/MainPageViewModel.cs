using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PrismTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IModuleManager _moduleManager;

        public MainPageViewModel(INavigationService navigationService, IModuleManager moduleManager)
            : base(navigationService)
        {
            _moduleManager = moduleManager;
            Title = "Main Page";
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
          

        }

        public DelegateCommand<string> NavigateCommand { get; }

        private async void OnNavigateCommandExecuted(string path)
        {
            _moduleManager.LoadModule("BookModuleModule");
            _moduleManager.LoadModule("AuthorModuleModule");
            _moduleManager.LoadModule("PublisherModuleModule");
            await NavigationService.NavigateAsync(path);
        }

        private DelegateCommand _navigateToBooksPageCommand;
        public DelegateCommand NavigateToBooksPageCommand =>
            _navigateToBooksPageCommand ?? (_navigateToBooksPageCommand = new DelegateCommand(ExecuteNavigateToBooksPageCommand));
        void ExecuteNavigateToBooksPageCommand()
        {
            _moduleManager.LoadModule("BookModuleModule");
            NavigationService.NavigateAsync("BookListPage");
        }


        private DelegateCommand _navigateToAuthorPageCommand;
        public DelegateCommand NavigateToAuthorsPageCommand =>
            _navigateToAuthorPageCommand ?? (_navigateToAuthorPageCommand = new DelegateCommand(ExecuteNavigateToAuthorsPageCommand));
        void ExecuteNavigateToAuthorsPageCommand()
        {
            _moduleManager.LoadModule("AuthorModuleModule");
            NavigationService.NavigateAsync("AuthorListPage");
        }


        private DelegateCommand _navigateToPublishersPageCommand;
        public DelegateCommand NavigateToPublishersPageCommand =>
            _navigateToPublishersPageCommand ?? (_navigateToPublishersPageCommand = new DelegateCommand(ExecuteNavigateToPublishersPageCommand));
        void ExecuteNavigateToPublishersPageCommand()
        {
            _moduleManager.LoadModule("PublisherModuleModule");
            NavigationService.NavigateAsync("PublisherListPage");
        }
    }
}
