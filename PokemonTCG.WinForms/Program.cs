using PokemonTCG.Core;

namespace PokemonTCG.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var pikachu = new CartePokemon("Pikachu", "Souris électrique",
                Rarete.Commune, 60, TypePokemon.Electrik);
            pikachu.Attaques.Add(new Attaque("Éclair", 20, 1));

            var deckJoueur = new List<Carte> { pikachu };
            for (int i = 0; i < 4; i++)
                deckJoueur.Add(new CarteEnergie("Énergie Électrik", TypePokemon.Electrik));

            var salameche = new CartePokemon("Salamèche", "Lézard de feu",
                Rarete.Commune, 70, TypePokemon.Feu);
            var deckAdversaire = new List<Carte> { salameche };

            var joueur = new Joueur("Sacha", deckJoueur);
            var adversaire = new Joueur("Régis", deckAdversaire);
            adversaire.Piocher();
            adversaire.JouerCarte(salameche);

            Application.Run(new FrmPartie(joueur, adversaire));
        }
    }
}
