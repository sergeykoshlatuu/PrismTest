using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookModule.ViewModels
{
	public class BookPageViewModel : BindableBase, INavigationAware
    {
        public BookPageViewModel(INavigationService navigationService, IBookService bookService, IAuthorService authorService, IPublisherService publisherService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            Authors = _authorService.LoadListAuthors();
            Publishers = _publisherService.LoadListPublisher();
        }

        #region Var and props
        INavigationService _navigationService;
        IBookService _bookService;
        IAuthorService _authorService;
        IPublisherService _publisherService;

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }

        private int _authorId;
        public int AuthorId
        {
            get { return _authorId; }
            set { SetProperty(ref _authorId, value); }
        }

        private int _publisherId;
        public int PublisherId
        {
            get { return _publisherId; }
            set { SetProperty(ref _publisherId, value); }
        }

        private Author _selectedAuthors;
        public Author SelectedAuthors
        {
            get { return _selectedAuthors; }
            set { SetProperty(ref _selectedAuthors, value);
                AuthorId = SelectedAuthors.Id;
            }
        }

        private List<Author> _authors;
        public List<Author> Authors
        {
            get { return _authors; }
            set { SetProperty(ref _authors, value); }
        }

        private Publisher _selectedPublisher;
        public Publisher SelectedPublisher
        {
            get { return _selectedPublisher; }
            set { SetProperty(ref _selectedPublisher, value);
                PublisherId = SelectedPublisher.Id;
            }
        }

        private List<Publisher> publishers;
        public List<Publisher> Publishers
        {
            get { return publishers; }
            set { SetProperty(ref publishers, value); }
        }
        #endregion

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Book book = parameters.GetValue<Book>("model");
            Id = book.Id;
            Name = book.Name;
            Year = book.Year;
            AuthorId = book.AuthorId;
            PublisherId = book.PublisherId;
            SelectedAuthors = Authors.Find(x => x.Id == book.AuthorId);
            SelectedPublisher = Publishers.Find(x => x.Id == book.PublisherId);

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        void ExecuteSaveCommand()
        {
            Book book = new Book { Id = Id, AuthorId = AuthorId, Name = Name, PublisherId = PublisherId, Year = Year };
            _bookService.AddBook(book);
            _navigationService.NavigateAsync("MainPage");
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        void ExecuteDeleteCommand()
        {

            Book book = new Book { Id = Id, AuthorId = AuthorId, Name = Name, PublisherId = PublisherId, Year = Year };
            _bookService.DeleteBook(book);
            _navigationService.NavigateAsync("MainPage");
        }
    }
}
