using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    public class ProduitNonEnStockException : Exception
    {
        public ProduitNonEnStockException(string nomProduit) : base("Le produit " + nomProduit + " n'est pas en stock")
        {
        }

        public static Produit ChargerProduit(string nomProduit)
        {
            Produit produit = new Produit(); // à remplacer par le chargement du produit
            if (produit.Stock <= 0)
                throw new ProduitNonEnStockException(nomProduit);
            return produit;
        }
    }
}
