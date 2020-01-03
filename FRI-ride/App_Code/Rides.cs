using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Rides
/// </summary>
namespace FRI_ride.Models
{
    public class Rides
    {
        public int Id_oglas { get; set; }
        public int Id_voznik { get; set; }
        public string Lokacija { get; set; }
        public string Cas_datum { get; set; }
    }
}