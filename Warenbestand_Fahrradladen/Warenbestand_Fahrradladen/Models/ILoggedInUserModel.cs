using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warenbestand_Fahrradladen.Models
{
    public interface ILoggedInUserModel
    {
        string Name { get; set; }
        string Role { get; set; }

        
    }
}
