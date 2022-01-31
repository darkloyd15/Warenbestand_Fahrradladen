using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using System.Windows;
>>>>>>> Drilon
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    class ListBuyViewModel : Screen
    {
<<<<<<< HEAD
        private readonly IEventAggregator _events;
        private readonly ILoggedInUserModel _loggedInUser;
        public List<string> list;
        public string Item { get; set; }
=======

        public Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();

        private readonly IEventAggregator _events;

        private readonly ILoggedInUserModel _loggedInUser;
>>>>>>> Drilon


        public ListBuyViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;
<<<<<<< HEAD
            list = new List<string> { "Test", "Text" };

        }


        public void Add()
        {
            _events.PublishOnUIThreadAsync(new AddEvent());
        }
=======


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


>>>>>>> Drilon
        public void Abort()
        {
            _events.PublishOnUIThreadAsync(new AbortEvent());
        }
<<<<<<< HEAD
=======


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

>>>>>>> Drilon
    }
}
