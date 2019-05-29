using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Lib.Entities;

namespace Bibliotheek.Lib.Services
{
    public class BoekenBeheer
    {
        public List<Boek> Boeken { get; set; }
        public BoekenBeheer()
        {
            Boeken = new List<Boek>();
        }

        public bool VoegBoekToe(Boek huidigeBoek)
        {
            bool gelukt = false;
            if (huidigeBoek != null)
            {
                Boeken.Add(huidigeBoek);
                //FoutBoodschap = null;
                gelukt = true;
            }
            else
            {
                //FoutBoodschap = FOUTBOODSCHAP;
            }
            return gelukt;
        }
    }
}
