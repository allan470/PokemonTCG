using PokemonTCG.Core;

namespace PokemonTCG.Tests
{
    [TestClass]
    public class JoueurTests
    {
        private CartePokemon _pikachu;
        private Attaque _eclair;
        private Joueur _joueur;
        private Joueur _adversaire;
        private CartePokemon _salameche;

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

            _salameche = new CartePokemon("Salamèche", "Lézard de feu", Rarete.Commune, 70, TypePokemon.Feu);
            _adversaire = new Joueur("Régis", new List<Carte> { _salameche });
            _adversaire.Piocher();
            _adversaire.JouerCarte(_salameche);
        }

        [TestMethod]
        public void Piocher_AjouteLaCarteALaMain()
        {
            Carte c = _joueur.Piocher();
            Assert.AreSame(_pikachu, c);
            Assert.AreEqual(1, _joueur.Main.Count);
            Assert.AreEqual(2, _joueur.Deck.Count);
        }

        [TestMethod]
        public void Piocher_DeuxFoisLeMemeTour_LeveException()
        {
            _joueur.Piocher();
            Assert.ThrowsExactly<InvalidOperationException>(() => _joueur.Piocher());
        }

        [TestMethod]
        public void JouerCarte_Pokemon_DevientActif()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            Assert.AreSame(_pikachu, _joueur.PokemonActif);
            Assert.AreEqual(0, _joueur.Main.Count);
        }

        [TestMethod]
        public void JouerCarte_EnergieSansPokemonActif_LeveException()
        {
            _joueur.Piocher();
            _joueur.PasserSonTour();
            _joueur.Piocher();
            Carte energie = _joueur.Main[1];
            Assert.ThrowsExactly<InvalidOperationException>(() => _joueur.JouerCarte(energie));
            Assert.AreEqual(2, _joueur.Main.Count);
        }

        [TestMethod]
        public void Attaquer_EnergieInsuffisante_LeveException()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            Assert.ThrowsExactly<InvalidOperationException>(() => _joueur.Attaquer(_eclair, _adversaire));
        }

        [TestMethod]
        public void Attaquer_EnergieSuffisante_InfligeLesDegats()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            _joueur.PasserSonTour();
            _joueur.Piocher();
            _joueur.JouerCarte(_joueur.Main[0]);
            int degats = _joueur.Attaquer(_eclair, _adversaire);
            Assert.AreEqual(20, degats);
            Assert.AreEqual(50, _adversaire.PokemonActif.PointsDeVie);
        }
    }
}
