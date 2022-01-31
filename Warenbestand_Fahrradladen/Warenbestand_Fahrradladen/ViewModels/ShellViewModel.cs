using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warenbestand_Fahrradladen.EventModels;

namespace Warenbestand_Fahrradladen.ViewModels
{
<<<<<<< HEAD
    class ShellViewModel : Conductor<object>, IHandle<LoginEvent>, IHandle<AddEvent>, IHandle<RemoveEvent>, IHandle<StoreEvent>
=======
    class ShellViewModel : Conductor<object>, IHandle<LoginEvent>, IHandle<AddEvent>, IHandle<RemoveEvent>, IHandle<StoreEvent>, IHandle<AbortEvent>
>>>>>>> Drilon
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            ActivateItemAsync(IoC.Get<LoginViewModel>());
            _events = events;
            events.SubscribeOnPublishedThread(this);
        }
        private bool _logoutSwitch = false;

        public bool LogoutSwitch
        {
            get { return _logoutSwitch; }
            set
            {
                _logoutSwitch = value;
                NotifyOfPropertyChange(() => LogoutSwitch);
                NotifyOfPropertyChange(() => CanLogout);

            }
        }


        public bool CanLogout
        {
            get
            {
                return LogoutSwitch;
            }
        }
        public void Logout()
        {
            LogoutSwitch = false;
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public Task HandleAsync(LoginEvent message, CancellationToken cancellationToken)
        {
            LogoutSwitch = true;
            return ActivateItemAsync(IoC.Get<ListViewModel>());
        }

        public Task HandleAsync(StoreEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(IoC.Get<ListStoreViewModel>());
        }

        public Task HandleAsync(RemoveEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(IoC.Get<ListSellViewModel>());
        }

        public Task HandleAsync(AddEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(IoC.Get<ListBuyViewModel>());
        }
<<<<<<< HEAD
=======

        public Task HandleAsync(AbortEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(IoC.Get<ListViewModel>());
        }
>>>>>>> Drilon
    }
}
