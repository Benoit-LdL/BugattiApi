using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bugatti
{
    /* TO DO LIST
    1) -DONE-   RESTful API
       -DONE-   met EF.core (code first)
       -DONE-   en SQL databank

    2) 2 controllers
       met CRUD: Create, Read, Update, Delete => SQL = Insert, Select, Update, Delete
    
    3) datamodel met 3 klassen: 
        1X "1 op veel" relatie
        1X "veel op veel" relatie
        1X Kies zelf

    4) "hoofd" controller kan dit op properties:
        "paging"
        "sorting"
        "search"

    5) 5 verschillende ingebouwde validaties op API

    6) basis client applicatie vanwaaruit je je API aanspreekt (Angular, Ionic, gewoon HTML/Javascript,..)

    7) gebruikt van hypermedia lever meer punten. --ZIE REST.PDF

    8) login via client met OAuth/Open ID 

    9) Beveilig API deels met een JWT Token (bepaal zelf welk deel)

   10) Geef het JWT token vanuit je client (nadat de gebruiker is aangemeld) voor toegang beveiligde deel.
   
   11) Betrek 3rd party API via client of server.
   
   12) Deployment naar google cloud.
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
