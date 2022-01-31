using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Warenbestand_Fahrradladen.EventModels;
using Warenbestand_Fahrradladen.Models;

namespace Warenbestand_Fahrradladen.ViewModels
{
    class LoginViewModel : Screen
    {
        public LoginViewModel(ILoggedInUserModel loggedInUser, IEventAggregator events)
        {
            _loggedInUser = loggedInUser;
            _events = events;
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;

                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }


        }
        private string _password;
        private readonly ILoggedInUserModel _loggedInUser;
        private readonly IEventAggregator _events;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password);
            }
        }
        public void Login()
        {
            _loggedInUser.Name = UserName;
            if (UserName.Equals("Tim"))
            {
                _loggedInUser.Role = "Admin";
            }
            if (UserName.Equals("Drilon"))
            {
                _loggedInUser.Role = "Chef";
            }
            if (UserName.Equals("Adrian"))
            {
                _loggedInUser.Role = "Mitarbeiter";
            }

            _events.PublishOnUIThreadAsync(new LoginEvent());
        }
        public void OnPasswordChanged(PasswordBox source)
        {
            Password = source.Password;
        }

    }
}
