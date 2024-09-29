using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class daReservation
    {
        AppDbContext db=new AppDbContext();
        public void Save(Reservation r)
        {
            db.Reservations.Add(r);
            db.SaveChanges();
        }
    }
}
