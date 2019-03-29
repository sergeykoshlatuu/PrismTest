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
//	public class PublishersPageViewModel : ViewModelBase
//	{
//        public PublishersPageViewModel(INavigationService navigationService, IPublisherService publisherService):base(navigationService)
//        {
//            _publisherService = publisherService;
//            Publishers = _publisherService.LoadListPublisher();
//            ItemTappedCommand = new DelegateCommand<object>(ListView_ItemTappedMethod);

//        }

//        IPublisherService _publisherService;

//        public DelegateCommand<object> ItemTappedCommand { get; set; }

//        private List<Publisher> _publishers;
//        public List<Publisher>Publishers
//        {
//            get { return _publishers; }
//            set { SetProperty(ref _publishers, value); }
//        }

//        private DelegateCommand _navigateToPublishersPageCommand;
//        public DelegateCommand NavigateToPublisherPageCommand =>
//            _navigateToPublishersPageCommand ?? (_navigateToPublishersPageCommand = new DelegateCommand(ExecuteNavigateToPublishersPageCommand));

//        void ExecuteNavigateToPublishersPageCommand()
//        {
//            NavigationService.NavigateAsync("PublisherPage");
//        }

//        private void ListView_ItemTappedMethod(object Publisher)
//        {
//            var publisher = Publisher as Publisher;
//            var navigationParams = new NavigationParameters();
//            navigationParams.Add("model", publisher);
//            NavigationService.NavigateAsync("PublisherPage", navigationParams);
//        }
//    } 
//}
