using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    public class ListViewModel : Screen
    {

        public Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();
        private readonly IEventAggregator _events;
        public ListViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;

            Products = new BindableCollection<Ware>(ctx.Ware);
        }
        private int _index;


        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                NotifyOfPropertyChange(() => Index);
            }
        }

        private BindableCollection<Ware> _products;

        public BindableCollection<Ware> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ILoggedInUserModel _loggedInUser;

        public ILoggedInUserModel LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                _loggedInUser = value;
                NotifyOfPropertyChange(() => LoggedInUser);
                NotifyOfPropertyChange(() => CanAdd);
            }
        }

        public bool CanAdd
        {
            get
            {
                return LoggedInUser.Role.Equals("Admin") || LoggedInUser.Role.Equals("Leiter");
            }
        }

        public void Add()
        {
            _events.PublishOnUIThreadAsync(new AddEvent());
        }

        public void Remove()
        {
            _events.PublishOnUIThreadAsync(new RemoveEvent());
        }

        public void Store()
        {
            _events.PublishOnUIThreadAsync(new StoreEvent());
        }
        
        public void OnTextChanged(TextBox source)
        {
            string filter = source.Text.ToLower();

            Index = Products.IndexOf(Products.FirstOrDefault(x => x.Name.ToLower().Contains(filter)));
        }
    }
}
