using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class blMenu
    {
        public void Create(Menu m) 
        {
            daMenu menu = new daMenu();
            menu.Create(m);
        }
        public async Task<List<Menu>> ReadAsync()
        {
            daMenu daMenu = new daMenu();
            return await daMenu.ReadAsync();
        }
    }
}
