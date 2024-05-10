using BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class daMenu
    {
        AppDbContext db = new AppDbContext();


        public void Create(Menu s)
        {
            db.Menus.Add(s);
            db.SaveChanges();
        }
        public async Task<List<Menu>> ReadAsync()
        {
            return await db.Menus.ToListAsync();
        }
    }
}
