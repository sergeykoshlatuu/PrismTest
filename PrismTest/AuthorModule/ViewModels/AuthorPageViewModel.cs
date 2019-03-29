using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTestClassLibrary.Events;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthorModule.ViewModels
{
	public class AuthorPageViewModel : BindableBase , INavigationAware
    {
        public AuthorPageViewModel(INavigationService navigationService, IAuthorService authorService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _authorService = authorService;
            IsDeleteVisible = false;
        }


        #region Var and props
        private INavigationService _navigationService;
        private IAuthorService _authorService;
        private IEventAggregator _eventAggregator;

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); IsDeleteVisible = true; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private bool _isDeleteVisible;
        public bool IsDeleteVisible
        {
            get { return _isDeleteVisible ; }
            set { SetProperty(ref _isDeleteVisible, value); }
        }

        #endregion

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Author author = parameters.GetValue<Author>("model");
          
            Id = author.Id;
            FirstName = author.FirstName;
            LastName = author.LastName;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        void ExecuteSaveCommand()
        {
            Author author = new Author { Id = Id, FirstName = FirstName,LastName=LastName };
            _authorService.AddAuthors(author);
            _navigationService.NavigateAsync("/Index/Navigation/AuthorListPage");
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Save succsesfull"));
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        void ExecuteDeleteCommand()
        {
            Author author = new Author { Id = Id, FirstName = FirstName, LastName = LastName };
            _authorService.DeleteAuthors(author);
            _navigationService.NavigateAsync("/Index/Navigation/AuthorListPage");
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Delete succsesfull"));
        }
    }
}

