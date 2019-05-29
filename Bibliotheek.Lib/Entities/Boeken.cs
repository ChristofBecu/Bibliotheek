using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek.Lib.Entities
{
    public class Boeken
    {
        public string ISBN { get; set; }
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public decimal Prijs { get; set; }
        public Categorieen Categorie { get; set; }

        public Boeken(string isbn, string titel, string auteur, decimal prijs, Categorieen categorie)
        {
            ISBN = isbn;
            Titel = titel;
            Auteur = auteur;
            Prijs = prijs;
            Categorie = categorie;
        }

        public override string ToString()
        {
            return $"{Titel} - {Prijs}";
        }
    }
}
