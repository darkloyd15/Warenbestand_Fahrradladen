using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    public class ListViewModel : Screen
    {
        Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();
        private readonly IEventAggregator _events;

        public List<string> list;
        public string Item { get; set; }

        public ListViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;            
            Products = new BindableCollection<Ware>(ctx.Ware);
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
                return LoggedInUser.Role.Equals("Admin") || LoggedInUser.Role.Equals("Chef");
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


        //Testliste einfügen

        //public void Search()
        //{
        //    Item = SearchItem.Name;
        //}




        public void OnTextChanged(TextBox source)
        {
            string searchStr = source.Text;
            // Zurücksetzen des Filters

            // Typumwandlung der Liste mit der Cast() Methode
            //var Listeneu = Products.Cast<string>();
            //String n = list.FirstOrDefault(x => x.ToLower().Contains(searchStr));
            //Products.FirstOrDefault(x => x.ToLower().Contains(searchStr));
        }


    }
}
