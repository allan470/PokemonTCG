namespace PokemonTCG.Core
{
    public class Joueur
    {
        public const int TailleBancMax = 5;
        public string Nom { get; }
        public List<Carte> Deck { get; }
        public List<Carte> Main { get; } = new List<Carte>();
        public CartePokemon PokemonActif { get; private set; }
        public List<CartePokemon> Banc { get; } = new List<CartePokemon>();

        private bool _aPioche = false;
        private bool _energieAttachee = false;

        public Joueur(string nom, List<Carte> deck)
        {
            this.Nom = nom;
            this.Deck = deck;
        }

        public Carte Piocher()
        {
            if (_aPioche)
                throw new InvalidOperationException("Vous avez déjà pioché ce tour.");
            if (Deck.Count == 0)
                throw new InvalidOperationException("Le deck est vide.");

            Carte carte = Deck[0];
            Deck.RemoveAt(0);
            Main.Add(carte);
            _aPioche = true;
            return carte;
        }

        public void JouerCarte(Carte carte)
        {
            if (!Main.Contains(carte))
                throw new InvalidOperationException("Cette carte n'est pas dans votre main.");

            switch (carte)
            {
                case CartePokemon pokemon:
                    if (PokemonActif == null)
                    {
                        PokemonActif = pokemon;
                    }
                    else
                    {
                        if (Banc.Count >= TailleBancMax)
                            throw new InvalidOperationException("Le banc est plein.");
                        Banc.Add(pokemon);
                    }
                    break;

                case CarteEnergie:
                    if (PokemonActif == null)
                        throw new InvalidOperationException("Aucun Pokémon actif pour recevoir l'énergie.");
                    if (_energieAttachee)
                        throw new InvalidOperationException("Une énergie a déjà été attachée ce tour.");
                    PokemonActif.AttacherEnergie();
                    _energieAttachee = true;
                    break;

                case CarteDresseur dresseur:
                    Console.WriteLine(dresseur.Effet);
                    break;

                default:
                    throw new InvalidOperationException("Type de carte inconnu.");
            }
            Main.Remove(carte);
        }

        /// <summary>Retourne les dégâts infligés.</summary>
        public int Attaquer(Attaque attaque, Joueur adversaire)
        {
            if (PokemonActif == null || adversaire.PokemonActif == null)
                throw new InvalidOperationException("Un des deux joueurs n'a pas de Pokémon actif.");
            if (PokemonActif.EstKO || adversaire.PokemonActif.EstKO)
                throw new InvalidOperationException("Un Pokémon est K.O.");
            if (!PokemonActif.Attaques.Contains(attaque))
                throw new ArgumentException("Cette attaque n'appartient pas au Pokémon actif.");
            if (PokemonActif.EnergiesAttachees < attaque.Cout)
                throw new InvalidOperationException("Énergies insuffisantes.");

            int pvAvant = adversaire.PokemonActif.PointsDeVie;
            adversaire.PokemonActif.RecevoirDegats(attaque.Degats);
            return pvAvant - adversaire.PokemonActif.PointsDeVie;
        }

        public void PasserSonTour()
        {
            _aPioche = false;
            _energieAttachee = false;
        }
    }
}
