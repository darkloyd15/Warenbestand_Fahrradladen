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
    class ListStoreViewModel : Screen
    {

        public Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();

        private readonly IEventAggregator _events;

        private readonly ILoggedInUserModel _loggedInUser;

        public ListStoreViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
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

        private decimal? _price = null;

        public decimal? Price
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
                NotifyOfPropertyChange(() => CanProductsPrice);

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
                if (ProductsName.Any(x => x.Equals(SelectedProductsName)))
                {
                    Price = ctx.Ware.FirstOrDefault(x => x.Name.Equals(SelectedProductsName)).Listenpreis * Convert.ToInt32(Quantity);
                    return true;
                }
                return false;

            }
        }
        public void Store()
        {
            Ware Bestellung = new Ware();
            Bestellung.Name = SelectedProductsName;
            Bestellung.Anzahl = Convert.ToInt32(Quantity);
            Bestellung.Listenpreis = Price / Bestellung.Anzahl;

            BindableCollection<Ware> Products = new BindableCollection<Ware>(ctx.Ware);
            if (Products.Any(x => x.Name.ToLower().Equals(SelectedProductsName.ToLower())))
            {
                Products[Products.IndexOf(Products.FirstOrDefault(x => x.Name.ToLower() == Bestellung.Name.ToLower()))].Anzahl += Bestellung.Anzahl;
                ctx.SaveChanges();
                MessageBox.Show($"Es wurden {Quantity} zu {SelectedProductsName} zurückgelegt");
            }
            else
            {                
                MessageBox.Show($"Das Produkt '{SelectedProductsName}' wurde nicht gefunden!");
            }
        }

    }
}
