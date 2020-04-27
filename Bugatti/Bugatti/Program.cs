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
    1) DONE Je bouwt een ASP Core 3.x RESTful API in combinatie met EF.core (code first) en een SQL databank over een bepaald onderwerp.
    2) Deze API moet minstens 2 controllers bevatten met alle CRUD actions
    3) Het datamodel moet bestaan uit minstens 3 klassen, waarbij er een "1 op veel" relatie is alsook een "veel op veel" relatie (dit laatste moet je zelf verder uitzoeken waar nodig)
    4) In de "hoofd" controller moet er kunnen worden gewerkt met "paging", "sorting" en "search" op meerdere properties
    5) Voorzie minimum 5 verschillende ingebouwde validaties op de API
    6) Voorzie ook een(basis) client applicatie vanwaaruit je je API aanspreekt.De technologie mag je zelf kiezen(Angular, Ionic, gewoon HTML/Javascript,..),
       voorzie schermen om de functionaliteit van je API te kunnen testen en gebruiken.
    7) Werken met hypermedia links om je API naar de "next level" te tillen levert uiteraard meer punten op.
    8) Voorzie je client app van een login mogelijkheid aan de hand van OAuth/Open ID 
    9) Beveilig je API deels met een JWT Token (bepaal zelf welk deel)
   10) Geef het JWT token vanuit je client (nadat de gebruiker is aangemeld) mee naar je API om toegang te bekomen tot het beveiligde deel.
   11) Betrek eveneens een 3rd party API die op het internet beschikbaar is bij jouw project. Er zijn enorm veel API's beschikbaar. Neem bij voorkeur een API die goed aansluit bij je project. Roep deze aan vanuit de frontend (client) of vanuit de backend (server).
   12) Deployment naar google cloud (je google cloud credits zijn beperkt dus contacteer me zeker als dit gelukt is zodat je niet zonder credits valt en het nog niet hebt kunnen tonen dat het gelukt was)
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
