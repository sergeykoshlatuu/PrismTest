using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTestClassLibrary.Interfaces;
using PrismTestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublisherModule.ViewModels
{
	public class PublisherListPageViewModel : BindableBase
	{
       
            public PublisherListPageViewModel(INavigationService navigationService, IPublisherService publisherService)
        {
            _navigationService = navigationService;
                _publisherService = publisherService;
                Publishers = _publisherService.LoadListPublisher();
                ItemTappedCommand = new DelegateCommand<object>(ListView_ItemTappedMethod);

            }

            IPublisherService _publisherService;
        INavigationService  _navigationService;

        public DelegateCommand<object> ItemTappedCommand { get; set; }

        private List<Publisher> _publishers;
        public List<Publisher> Publishers
        {
            get { return _publishers; }
            set { SetProperty(ref _publishers, value); }
        }

        private DelegateCommand _navigateToPublishersPageCommand;
        public DelegateCommand NavigateToPublisherPageCommand =>
            _navigateToPublishersPageCommand ?? (_navigateToPublishersPageCommand = new DelegateCommand(ExecuteNavigateToPublishersPageCommand));

        void ExecuteNavigateToPublishersPageCommand()
        {
            _navigationService.NavigateAsync("PublisherPage");
        }

        private void ListView_ItemTappedMethod(object Publisher)
        {
            var publisher = Publisher as Publisher;
            var navigationParams = new NavigationParameters();
            navigationParams.Add("model", publisher);
            _navigationService.NavigateAsync("PublisherPage", navigationParams);
        }
    }
}
