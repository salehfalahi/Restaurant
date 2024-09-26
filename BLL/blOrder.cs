using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BLL
{
    public class blOrder
    {
        public void Create(Order o)
        {
            daOrder daorder = new daOrder();
            daorder.Create(o);
        }
    }
}
