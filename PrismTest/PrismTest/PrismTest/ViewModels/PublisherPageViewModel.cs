//using Prism.Commands;
//using Prism.Mvvm;
//using Prism.Navigation;
//using PrismTest.Interfaces;
//using PrismTest.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace PrismTest.ViewModels
//{
//    public class PublisherPageViewModel : ViewModelBase
//    {
//        public PublisherPageViewModel(INavigationService navigationService, IPublisherService publisherService) : base(navigationService)
//        {
//            _publisherService = publisherService;
//        }

//        #region variable and property

//        private IPublisherService _publisherService;

//        private int _id;
//        public int Id
//        {
//            get { return _id; }
//            set { SetProperty(ref _id, value); }
//        }

//        private string _name;
//        public string Name
//        {
//            get { return _name; }
//            set { SetProperty(ref _name, value); }
//        }

//        #endregion

//        private DelegateCommand _saveCommand;
//        public DelegateCommand SaveCommand =>
//            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

//        void ExecuteSaveCommand()
//        {
//            Publisher publisher = new Publisher { Id = Id, Name = Name };
//            _publisherService.AddPublisher(publisher);
//            NavigationService.NavigateAsync("PublishersPage");
//        }

//        private DelegateCommand _deleteCommand;
//        public DelegateCommand DeleteCommand =>
//            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

//        void ExecuteDeleteCommand()
//        {
//            Publisher publisher = new Publisher { Id = Id, Name = Name };
//            _publisherService.DeletePublisher(publisher);
//            NavigationService.NavigateAsync("PublishersPage");
//        }

//        public override void OnNavigatedTo(INavigationParameters parameters)
//        {
//            Publisher publisher = parameters.GetValue<Publisher>("model");
//            Id = publisher.Id;
//            Name = publisher.Name;
//        }
//    }
//}
