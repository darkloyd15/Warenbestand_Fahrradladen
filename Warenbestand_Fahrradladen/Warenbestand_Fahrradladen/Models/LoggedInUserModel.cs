using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warenbestand_Fahrradladen.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
