using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    class ListBuyViewModel : Screen
    {
        public Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();

        private readonly IEventAggregator _events;

        private readonly ILoggedInUserModel _loggedInUser;

        public ListBuyViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;

            ctx.Ware.ToList().ForEach(x => ProductsName.Add(x.Name));
        }

        private BindingList<string> _productsName = new BindingList<string>();

        private string _selectedProductsName;

        public string SelectedProductsName
        {
            get { return _selectedProductsName; }
            set
            {
                _selectedProductsName = value;
                NotifyOfPropertyChange(() => SelectedProductsName);
                NotifyOfPropertyChange(() => CanProductsPrice);
            }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }

        }

        
        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }

        public BindingList<string> ProductsName
        {
            get { return _productsName; }
            set
            {
                _productsName = value;
                NotifyOfPropertyChange(() => ProductsName);
            }
        }

        public void Abort()
        {
            _events.PublishOnUIThreadAsync(new AbortEvent());
        }

        public bool CanProductsPrice
        {
            get
            {
                return ctx.Ware.Any(x=> x.Name.Equals(SelectedProductsName));
            }
        }
        public void Sell()
        {
            //Ware ware = new
            //if ()
            //{

            //}
            //else
            //{

            //}
        }
    }
}
