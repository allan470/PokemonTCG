using PokemonTCG.Core;

namespace PokemonTCG.WinForms
{
    public partial class FrmPartie : Form
    {
        private readonly Joueur _joueur;
        private readonly Joueur _adversaire;

        public FrmPartie(Joueur joueur, Joueur adversaire)
        {
            InitializeComponent();
            _joueur = joueur;
            _adversaire = adversaire;
            grpJoueur.Text = _joueur.Nom;
            lstMain.DisplayMember = "Nom";
            lstBanc.DisplayMember = "Nom";
            cmbAttaques.DisplayMember = "Nom";
            ActualiserAffichage();
        }

        private void ActualiserAffichage()
        {
            lblDeck.Text = $"Deck : {_joueur.Deck.Count} carte(s)";

            lstMain.Items.Clear();
            lstMain.Items.AddRange(_joueur.Main.ToArray());

            lstBanc.Items.Clear();
            lstBanc.Items.AddRange(_joueur.Banc.ToArray());

            cmbAttaques.Items.Clear();
            if (_joueur.PokemonActif == null)
            {
                lblActif.Text = "Aucun Pokémon actif";
                lblEnergies.Text = "Énergies : 0";
            }
            else
            {
                lblActif.Text = _joueur.PokemonActif.Decrire();
                lblEnergies.Text = $"Énergies : {_joueur.PokemonActif.EnergiesAttachees}";
                cmbAttaques.Items.AddRange(_joueur.PokemonActif.Attaques.ToArray());
            }

            lblActifAdversaire.Text = _adversaire.PokemonActif == null
                ? "Aucun Pokémon actif"
                : _adversaire.PokemonActif.Decrire();
        }

        private void AfficherMessage(string texte, bool erreur)
        {
            lblMessage.Text = texte;
            lblMessage.ForeColor = erreur ? Color.Red : Color.Green;
        }

        private void btnPiocher_Click(object sender, EventArgs e)
        {
            try
            {
                Carte carte = _joueur.Piocher();
                AfficherMessage($"Vous avez pioché : {carte.Nom}.", false);
            }
            catch (InvalidOperationException ex)
            {
                AfficherMessage(ex.Message, true);
            }
            ActualiserAffichage();
        }

        private void btnJouerCarte_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItem == null)
            {
                AfficherMessage("Sélectionnez une carte.", true);
                return;
            }
            Carte carte = (Carte)lstMain.SelectedItem;
            try
            {
                _joueur.JouerCarte(carte);
                AfficherMessage($"Vous avez joué : {carte.Nom}.", false);
            }
            catch (InvalidOperationException ex)
            {
                AfficherMessage(ex.Message, true);
            }
            ActualiserAffichage();
        }

        private void btnAttaquer_Click(object sender, EventArgs e)
        {
            if (cmbAttaques.SelectedItem == null)
            {
                AfficherMessage("Sélectionnez une attaque.", true);
                return;
            }
            Attaque attaque = (Attaque)cmbAttaques.SelectedItem;
            try
            {
                int degats = _joueur.Attaquer(attaque, _adversaire);
                string msg = $"{attaque.Nom} inflige {degats} dégâts.";
                if (_adversaire.PokemonActif.EstKO)
                    msg += " Le Pokémon adverse est K.O. !";
                AfficherMessage(msg, false);
            }
            catch (InvalidOperationException ex)
            {
                AfficherMessage(ex.Message, true);
            }
            catch (ArgumentException ex)
            {
                AfficherMessage(ex.Message, true);
            }
            ActualiserAffichage();
        }

        private void btnPasserTour_Click(object sender, EventArgs e)
        {
            _joueur.PasserSonTour();
            AfficherMessage("Tour terminé.", false);
            ActualiserAffichage();
        }
    }
}
