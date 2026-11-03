using System.Drawing;
using System.Windows.Forms;
using PokemonTCG.Core;
using PokemonTCG.WinForms;

namespace PokemonTCG.Tests
{
    [STATestClass]
    public class FrmPartieTests
    {
        private Joueur _joueur;
        private Joueur _adversaire;
        private CartePokemon _pikachu;
        private Attaque _eclair;
        private FrmPartie _form;

        [TestInitialize]
        public void Initialiser()
        {
            _pikachu = new CartePokemon("Pikachu", "Souris électrique", Rarete.Commune, 60, TypePokemon.Electrik);
            _eclair = new Attaque("Éclair", 20, 1);
            _pikachu.Attaques.Add(_eclair);

            var deck = new List<Carte>
            {
                _pikachu,
                new CarteEnergie("Énergie Électrik", TypePokemon.Electrik),
                new CarteEnergie("Énergie Électrik", TypePokemon.Electrik)
            };
            _joueur = new Joueur("Sacha", deck);

            var salameche = new CartePokemon("Salamèche", "Lézard de feu", Rarete.Commune, 70, TypePokemon.Feu);
            _adversaire = new Joueur("Régis", new List<Carte> { salameche });
            _adversaire.Piocher();
            _adversaire.JouerCarte(salameche);

            _form = new FrmPartie(_joueur, _adversaire);
            _form.Show();
        }

        [TestCleanup]
        public void Nettoyer()
        {
            _form.Dispose();
        }

        private T Trouver<T>(string nom) where T : Control
        {
            Control[] trouves = _form.Controls.Find(nom, true);
            Assert.AreEqual(1, trouves.Length, $"Contrôle introuvable : {nom}");
            return (T)trouves[0];
        }

        private void PiocherEtJouerPikachu()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            Trouver<ListBox>("lstMain").SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();
        }

        // ---------- tests fournis ----------
        [TestMethod]
        public void Piocher_Clic_AjouteLaCarteALaListeMain()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual("Deck : 2 carte(s)", Trouver<Label>("lblDeck").Text);
        }

        [TestMethod]
        public void Piocher_DeuxClics_AfficheUnMessageDErreur()
        {
            Button btnPiocher = Trouver<Button>("btnPiocher");
            btnPiocher.PerformClick();
            btnPiocher.PerformClick();
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }

        [TestMethod]
        public void JouerCarte_PokemonSelectionne_DevientPokemonActif()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            ListBox lstMain = Trouver<ListBox>("lstMain");
            lstMain.SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();
            Assert.AreSame(_pikachu, _joueur.PokemonActif);
            Assert.AreEqual(0, lstMain.Items.Count);
            StringAssert.Contains(Trouver<Label>("lblActif").Text, "Pikachu");
        }

        // ---------- tests à écrire ----------
        [TestMethod]
        public void JouerCarte_SansSelection_AfficheUnMessageDErreur()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            Trouver<Button>("btnJouerCarte").PerformClick();
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }

        [TestMethod]
        public void Attaquer_EnergieSuffisante_MetAJourLAdversaire()
        {
            PiocherEtJouerPikachu();
            Trouver<Button>("btnPasserTour").PerformClick();
            Trouver<Button>("btnPiocher").PerformClick();
            Trouver<ListBox>("lstMain").SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();

            Trouver<ComboBox>("cmbAttaques").SelectedIndex = 0;
            Trouver<Button>("btnAttaquer").PerformClick();

            Assert.AreEqual(50, _adversaire.PokemonActif.PointsDeVie);
            StringAssert.Contains(Trouver<Label>("lblActifAdversaire").Text, "PV : 50");
        }

        [TestMethod]
        public void Attaquer_SansAttaqueSelectionnee_AfficheUnMessageDErreur()
        {
            PiocherEtJouerPikachu();
            Trouver<Button>("btnAttaquer").PerformClick();
            Assert.AreEqual(70, _adversaire.PokemonActif.PointsDeVie);
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }

        [TestMethod]
        public void PasserSonTour_Clic_AutorisePiocherAuTourSuivant()
        {
            Button btnPiocher = Trouver<Button>("btnPiocher");
            btnPiocher.PerformClick();
            Trouver<Button>("btnPasserTour").PerformClick();
            btnPiocher.PerformClick();
            Assert.AreEqual(2, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual("Deck : 1 carte(s)", Trouver<Label>("lblDeck").Text);
        }

        // ---------- tests supplémentaires ----------
        [TestMethod]
        public void JouerCarte_EnergieSansPokemonActif_AfficheUnMessageDErreur()
        {
            Button btnPiocher = Trouver<Button>("btnPiocher");
            Button btnPasser = Trouver<Button>("btnPasserTour");
            ListBox lstMain = Trouver<ListBox>("lstMain");
            btnPiocher.PerformClick();   // Pikachu
            btnPasser.PerformClick();
            btnPiocher.PerformClick();   // Énergie
            lstMain.SelectedIndex = 1;   // l'énergie
            Trouver<Button>("btnJouerCarte").PerformClick();
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
            Assert.AreEqual(2, lstMain.Items.Count);
        }

        [TestMethod]
        public void Attaquer_EnergieManquante_AfficheUnMessageDErreur()
        {
            PiocherEtJouerPikachu();
            Trouver<ComboBox>("cmbAttaques").SelectedIndex = 0;
            Trouver<Button>("btnAttaquer").PerformClick();
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
            Assert.AreEqual(70, _adversaire.PokemonActif.PointsDeVie);
        }

        [TestMethod]
        public void JouerPokemonActif_ComboAttaquesContientUneAttaque()
        {
            PiocherEtJouerPikachu();
            Assert.AreEqual(1, Trouver<ComboBox>("cmbAttaques").Items.Count);
        }

        [TestMethod]
        public void EnergieAttachee_LabelEnergiesAfficheUn()
        {
            PiocherEtJouerPikachu();
            Trouver<Button>("btnPasserTour").PerformClick();
            Trouver<Button>("btnPiocher").PerformClick();
            Trouver<ListBox>("lstMain").SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();
            Assert.AreEqual("Énergies : 1", Trouver<Label>("lblEnergies").Text);
        }
    }
}
