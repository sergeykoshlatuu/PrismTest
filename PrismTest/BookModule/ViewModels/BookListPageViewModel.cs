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
	public class BookListPageViewModel : BindableBase
	{
      
        public BookListPageViewModel(INavigationService navigationService, IBookService bookService) 
        {
            _bookService = bookService;
            _navigationService = navigationService;
            Books = _bookService.LoadListBook();
            ItemTappedCommand = new DelegateCommand<object>(ListView_ItemTappedMethod);
        }
        INavigationService _navigationService;
        IBookService _bookService;
        private List<Book> _books;
        public List<Book> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }

        private DelegateCommand _navigateToBookPageCommand;
        public DelegateCommand NavigateToBookPageCommand =>
            _navigateToBookPageCommand ?? (_navigateToBookPageCommand = new DelegateCommand(ExecuteNavigateToBookPageCommand));

        void ExecuteNavigateToBookPageCommand()
        {
            _navigationService.NavigateAsync("BookPage", null, false, false);
        }

        public DelegateCommand<object> ItemTappedCommand { get; set; }


        private void ListView_ItemTappedMethod(object books)
        {
            var book = books as Book;
            var navigationParams = new NavigationParameters();
            navigationParams.Add("model", book);
            _navigationService.NavigateAsync("BookPage", navigationParams,false,false);
        }
    }
}
