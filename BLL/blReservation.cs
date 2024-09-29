using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class blReservation
    {
        
        public void SaveReservation(Reservation res)
        {
            daReservation reservation = new daReservation();
            reservation.Save(res);
        }
    }
}
