using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class daOrder
    {
        AppDbContext db = new AppDbContext();
        public void Create(Order o)
        {
            db.Orders.Add(o);
            db.SaveChanges();
        }
    }
}
