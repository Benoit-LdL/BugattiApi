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

    //TO DO LIST
    #region --DONE--
    /*
        1)  -DONE-   RESTful API
            -DONE-   met EF.core (code first)
            -DONE-   en SQL databank

        2)  -DONE-2 controllers
            met CRUD: Create, Read, Update, Delete => SQL = Insert, Select, Update, Delete
     */
    #endregion
    /*
    
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


    /* TIPS
     * wees consistent in je naamgevingen (model: klasse, relaties, controllers, routes,..), gebruik enkelvoud en meervoud op de juiste plaatsen zoals ik heb aangegeven in de cursus.
     Ook wat betreft taal: gebruik ofwel Engels, ofwel Nederlands maar niet door elkaar (dus geen model met people en films). Gebruik ook de juiste routes, zie hiervoor de richtlijnen van REST.

     * zorg voor robuuste code in de controllers. Geef de juiste status code terug (bv. als een ID niet gevonden wordt moet er een status 404 ("NOT found") worden teruggestuurd en bv.
     geen 500 ("internal server error") (door bv. een exceptie van EF op de server omdat dat deze het object niet vind in de db)

     * client app: demonstreer hier de functionaliteit van je API, dus de CRUD operaties, GET met ID) maar ook paging, sorting & filtering. Voorzie bv.
     een zoekveld waarin de gebruiker kan typen en terwijl worden er calls gedaan naar je API die dan zal filteren aan server zijde (dus  "server side filtering").
     Gebruik ook de validatie JSON data om in je client aan de gebruiker de foutmeldingen weer te geven bij een POST/PUT. Als je dat alles doet voor 1 controller is dat voldoende, moet dus niet pers� voor alle controllers voorzien worden.
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
