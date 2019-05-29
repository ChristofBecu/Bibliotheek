using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bibliotheek.Lib.Entities;
using Bibliotheek.Lib.Services;
using Utilities.Lib;


namespace Bibliotheek.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boek huidigBoek;
        BoekenBeheer boekenBeheer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategorie.ItemsSource = Enum.GetValues(typeof(Categorieen));
            BeheerKnoppen();
        }

        private Boek MaakBoekAan()
        {
            Boek nieuwBoek = null;
            try
            {
                string isbn = txtIsbn.Text;
                string titel = txtTitel.Text;
                string auteur = txtAuteur.Text;
                decimal prijs = decimal.Parse(txtPrijs.Text);
                Categorieen categorie = (Categorieen)cmbCategorie.SelectedItem;
                nieuwBoek = new Boek(isbn, titel, auteur, prijs, categorie);
                if (huidigBoek != null)
                    nieuwBoek.ISBN = huidigBoek.ISBN;
            }
            catch (Exception)
            {

                Console.WriteLine("Aanmaak van instance niet gelukt\n");
            }
            return nieuwBoek;
        }

        private void KoppelVariabeleLijsten()
        {
            lstBoeken.ItemsSource = boekenBeheer.Boeken;
            lstBoeken.Items.Refresh();
        }

        private void BeheerKnoppen()
        {
            btnOpslaan.IsEnabled = false;
            btnVerwijderen.IsEnabled = false;
            if (huidigBoek != null)
                btnVerwijderen.IsEnabled = true;
            if (MaakBoekAan() != null)
                btnOpslaan.IsEnabled = true;
        }

        private void InputChanged(object sender, RoutedEventArgs e)
        {
            BeheerKnoppen();
        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            GuiFunctions.ClearPanel(grdMain);
        }
    }
}
