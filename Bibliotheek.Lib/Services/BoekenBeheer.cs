using System.Collections.Generic;
using Bibliotheek.Lib.Entities;
using Utilities.Lib;

namespace Bibliotheek.Lib.Services
{
    public class BoekenBeheer
    {
        public List<Boek> Boeken { get; set; }
        public BoekenBeheer()
        {
            Boeken = new List<Boek>();
        }

        private const string ERR_MESSAGE_INPUT_NOT_CORRECT = "invoer niet correct.\nprobeer opnieuw.";
        public string FoutBoodschap { get; set; }


        public bool VoegBoekToe(Boek huidigeBoek)
        {
            bool gelukt = false;
            if (huidigeBoek != null)
            {
                Boeken.Add(huidigeBoek);
                FoutBoodschap = null;
                gelukt = true;
            }
            else
            {
                FoutBoodschap = ERR_MESSAGE_INPUT_NOT_CORRECT;
            }
            return gelukt;
        }

        public void SlaOp(Boek boek)
        {
            if (boek != null)
            {
                if (ZoekId(boek.ISBN) == null)
                    VoegBoekToe(boek);
                else
                {
                    Wijzig(boek);
                }
            }
            else
            {
                FoutBoodschap = ERR_MESSAGE_INPUT_NOT_CORRECT;
            }
            SorteerOpTitel();
        }

        private bool Wijzig(Boek nieuweVersie)
        {
            bool gelukt = false;
            Boek oudeVersie = ZoekId(nieuweVersie.ISBN);
            if(VoegBoekToe(nieuweVersie))
            {
                Verwijder(oudeVersie);
                gelukt = true;
            }
            return gelukt;
        }
        public void Verwijder(Boek boek)
        {
            Boeken.Remove(boek);
        }

        private Boek ZoekId(string isbn)
        {
            Boek TeZoekenBoek = null;
            foreach (Boek zoekBoek in Boeken)
            {
                if (zoekBoek.ISBN == isbn)
                {
                    TeZoekenBoek = zoekBoek;
                    break;
                }
            }
            return TeZoekenBoek;
        }

        private void SorteerOpTitel()
        {
            Boeken = ClassFunctions.SortList<Boek>(Boeken, nameof(Boek.Titel));
        }

    }


}
