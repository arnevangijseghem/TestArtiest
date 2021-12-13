using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestArtiest.Models
{
    public class Artiest
    {
        public int ArtiestId { get; set; }
        public string Naam { get; set; }
        public int AantalLuisteraars { get; set; }
        public string Label { get; set; }
        public override string ToString()
        {
            return Naam;
        }
    }
}