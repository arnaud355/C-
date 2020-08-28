using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesOC
{
    /*
     Mis à part héritage en cascade, une classe ne peut pas hériter de plusieurs
     classes, en revanche, elle peut hériter de plusieurs interfaces.
     */
    public class Avion : IVolantMotorise, IRoulant
    {
        public int NombrePropulseurs { get; set; }
        public string NomDuCommandant { get; set; }
        public void Voler()
        {
            Console.WriteLine("Je vole grâce à " + NombrePropulseurs + " moteurs");
        }
        public void DemarrerLeMoteur()
        {
            Console.WriteLine("Démarrage moteur: \"vrooommmmmmm\"");
        }
        public void Rouler()
        {
            Console.WriteLine("Je Roule");
        }
    }
}
