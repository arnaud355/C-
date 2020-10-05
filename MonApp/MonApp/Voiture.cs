using System;
using System.Collections.Generic;
using System.Text;

namespace MonApp
{
    public class Voiture
    {
        public int Vitesse { get; set; }
        public string Couleur { get; set; }

        public Voiture()
        {
            this.Vitesse = 5;
        }
        public Voiture(int vitesse,string couleur)
        {
            this.Vitesse = vitesse;
            this.Couleur = couleur;
        }
        public void Rouler()
        {
            Console.WriteLine("Je roule à " + this.Vitesse + " km/h");
        }

        public void Accelerer(int acceleration)
        {
            this.Vitesse += acceleration;
            this.Rouler();
        }
    }
}
