<<<<<<< HEAD
﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

>>>>>>> Drilon
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
<<<<<<< HEAD
    class ListSellViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private readonly ILoggedInUserModel _loggedInUser;
        public List<string> list;
        public string Item { get; set; }
=======

    public class ListSellViewModel : Screen
    {
        public Warenbestand_FahrradladenEntities ctx = new Warenbestand_FahrradladenEntities();

        private readonly IEventAggregator _events;

        private readonly ILoggedInUserModel _loggedInUser;


>>>>>>> Drilon
        public ListSellViewModel(IEventAggregator events, ILoggedInUserModel loggedInUser)
        {
            _events = events;
            _loggedInUser = loggedInUser;
<<<<<<< HEAD
            list = new List<string> { "Test", "Text" };
        }

        public List<string> TestListe
        {
            get
            {
                return list;
            }
        }
        public void Remove()
        {
            _events.PublishOnUIThreadAsync(new RemoveEvent());
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


        public void Sell()
        {
            Ware ware = ctx.Ware.FirstOrDefault(x => x.Name.Equals(SelectedProductsName));
            if (ware.Anzahl < Convert.ToInt32(Quantity))
            {
                MessageBox.Show("Anzahl der ausgewählten Produkte sind nicht im Lager verfügbar!");
            }
            else
            {
                ware.Anzahl = ware.Anzahl - Convert.ToInt32(Quantity);
                ctx.SaveChanges();
                MessageBox.Show($"Es wurden {Quantity} Stücke von {SelectedProductsName} entfernt!");
            }
        }

>>>>>>> Drilon
    }
}
