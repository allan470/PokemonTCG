using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTCG.Core
{
    public enum Rarete { Commune, PeuCommune, Rare, HoloRare, UltraRare }
    public enum TypePokemon
    {
        Plante, Feu, Eau, Electrik, Psy, Combat, Obscurite, Metal, Normal
    }
    public class Attaque
    {
        public string Nom { get; }
        public int Degats { get; }
        public int Cout { get; } // nombre d'énergies requises
        public Attaque(string nom, int degats, int cout)
        {
            this.Nom = nom;
            this.Degats = degats;
            this.Cout = cout;
        }
    }
    public abstract class Carte
    {
        public string Nom { get; }
        public string Description { get; }
        public Rarete Rarete { get; }
        protected Carte(string nom, string description, Rarete rarete)
        {
            this.Nom = nom;
            this.Description = description;
            this.Rarete = rarete;
        }
        public virtual string Decrire()
        {
            return this.Nom + " (" + this.Rarete + ") : " + this.Description;
            
        }
    }
    public class CartePokemon : Carte
    {
        public int PointsDeVie { get; private set; }
        public TypePokemon Type { get; }
        public int EnergiesAttachees { get; private set; }
        public List<Attaque> Attaques { get; } = new List<Attaque>();
        public bool EstKO
        {
            get
            {
                if (this.PointsDeVie <= 0)
                {
                    return true;
                }
                return false;
            }
        }
        public CartePokemon(string nom, string description, Rarete rarete,
        int pv, TypePokemon type)
        : base(nom, description, rarete) // transmis à la classe mère
        {
            this.PointsDeVie = pv;
            this.Type = type;
            this.EnergiesAttachees = 0; 
        }
        public void AttacherEnergie()
        {
            this.EnergiesAttachees += 1;
            
        }
        public void RecevoirDegats(int degats)
        {
            if (degats < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if (this.PointsDeVie - degats <= 0)
            {
                this.PointsDeVie = 0;
            }
            else 
            { 
                this.PointsDeVie -= degats;
            }
            
        }
        public override string Decrire()
        {
            return base.Decrire() + "\n | PV : " + this.PointsDeVie + "\n |Type : " + this.Type;
            
        }
    }
    public class CarteEnergie : Carte
    {
        public TypePokemon Type { get; }
        public CarteEnergie(string nom, TypePokemon type)
        : base(nom, "Carte énergie", Rarete.Commune)
        {
            this.Type = type;
        }
    }
    public class CarteDresseur : Carte
    {
        public string Categorie { get; } // Objet, Supporter ou Stade
        public string Effet { get; }
        public CarteDresseur(string nom, Rarete rarete, string categorie, string effet)
        : base(nom, effet, rarete)
        {
           this.Categorie = categorie;
           this.Effet = effet;
        }
    }
}
