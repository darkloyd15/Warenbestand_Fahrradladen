using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    class ListStoreViewModel
    {

        private readonly IEventAggregator _events;
        private readonly ILoggedInUserModel _loggedInUser;
        public List<string> list;
        public string Item { get; set; }
        public ListStoreViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;
            list = new List<string> { "Test", "Text" };
        }

        public void Store()
        {
            _events.PublishOnUIThreadAsync(new StoreEvent());
        }

        public void Abort()
        {
            _events.PublishOnUIThreadAsync(new AbortEvent());
        }
    }
}
