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

namespace PublisherModule.ViewModels
{
	public class PublisherPageViewModel : BindableBase , INavigationAware
    {

        public PublisherPageViewModel(INavigationService navigationService, IPublisherService publisherService, IEventAggregator eventAggregator) 
        {
            _navigationService = navigationService;
            _publisherService = publisherService;
            _eventAggregator = eventAggregator;
            IsDeleteVisible = false;
        }


        #region variable and property
        IEventAggregator _eventAggregator;
        private IPublisherService _publisherService;
        private INavigationService _navigationService;

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value);
                IsDeleteVisible = true;
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _isDeleteVisible;
        public bool IsDeleteVisible
        {
            get { return _isDeleteVisible; }
            set { SetProperty(ref _isDeleteVisible, value); }
        }
        #endregion

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        void ExecuteSaveCommand()
        {
            Publisher publisher = new Publisher { Id = Id, Name = Name };
            _publisherService.AddPublisher(publisher);
            _navigationService.NavigateAsync("/Index/Navigation/PublisherListPage");
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Save succsesfull"));
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        void ExecuteDeleteCommand()
        {
            Publisher publisher = new Publisher { Id = Id, Name = Name };
            _publisherService.DeletePublisher(publisher);
            _navigationService.NavigateAsync("/Index/Navigation/PublisherListPage");
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Delete succsesfull"));
        }

       

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Publisher publisher = parameters.GetValue<Publisher>("model");
            Id = publisher.Id;
            Name = publisher.Name;
        }
    }
}
