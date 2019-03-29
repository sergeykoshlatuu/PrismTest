using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthorModule.ViewModels
{
	public class AuthorListPageViewModel : BindableBase
	{
        public AuthorListPageViewModel(INavigationService navigationService, IAuthorService authorService)
        {
            _authorService = authorService;
            _navigationService = navigationService;
            Authors = _authorService.LoadListAuthors();
            ItemTappedCommand = new DelegateCommand<object>(ListView_ItemTappedMethod);
        }

        INavigationService _navigationService;
        IAuthorService _authorService;

        private List<Author> _authors;
        public List<Author> Authors
        {
            get { return _authors; }
            set { SetProperty(ref _authors, value); }
        }

        private DelegateCommand _navigateToAuthorPageCommand;
        public DelegateCommand NavigateToAuthorPageCommand =>
            _navigateToAuthorPageCommand ?? (_navigateToAuthorPageCommand = new DelegateCommand(ExecuteNavigateToAuthorPageCommand));

        void ExecuteNavigateToAuthorPageCommand()
        {
            _navigationService.NavigateAsync("AuthorPage", null, false, false);
        }

        public DelegateCommand<object> ItemTappedCommand { get; set; }


        private void ListView_ItemTappedMethod(object parameter)
        {
            var author = parameter as Author;
            var navigationParams = new NavigationParameters();
            navigationParams.Add("model", author);
            _navigationService.NavigateAsync("AuthorPage", navigationParams,false,false);
        }
    }
}

