using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    class Program
    {
        static void Main(string[] args)
        {
            // ********************************** ZONE DE TEST **********************************


            // ******************************** FIN ZONE DE TEST ********************************
            var context = new PROJETSESSIONBD20657657Entities();
            Menu menu   = new Menu(context);
            using (context)
            {
                menu.MenuPrincipal();
            }
        }
    }
}