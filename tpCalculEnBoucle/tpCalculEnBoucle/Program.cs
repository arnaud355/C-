using System;
using System.Collections.Generic;

namespace tpCalculEnBoucle
{
    class Program
    {
        static int CalculSommeEntiers(int minNum,int maxNum)
        {
                       
            int i = 0;
            int sum = 0;
            int compteur = minNum;
            int taille = maxNum - minNum;
            List<int> listeNum = new List<int>();
            listeNum.Add(compteur);
            for(i = 0;i < taille; i++)
            {
                compteur += 1;
                listeNum.Add(compteur);
            }
            
            foreach (int ele in listeNum)
            {
                sum = sum + ele;
            }

            return sum;
        }
        static double CalculMoyenne(List<double> liste)
        {
            double sum = 0;
            double ave = 0;
            foreach (double ele in liste)
            {
                sum = sum + ele;
            }
            ave = sum / liste.Count;
            return ave;
        }
        static int CalculEntiersMultiple(int num1,int num2)
        {
            int i = 0;
            int j = 0;
            int ele1 = 0;
            int ele2 = 0;
            
            int number = 1;
            int sum = 0;
            int maxBoundary = 100;
            List<int> listeNum1 = new List<int>();
            List<int> listeNum2 = new List<int>();
            List<int> listeNumCommom = new List<int>();

            for (i = 0;i < maxBoundary; i++)
            {
                if(number % num1 == 0)
                {
                    listeNum1.Add(number);
                }
                if (number % num2 == 0)
                {
                    listeNum2.Add(number);
                }
                number += 1;
            }
            for(i = 0;i < listeNum1.Count; i++)
            {
                ele1 = listeNum1[i];
                
                for (j = 0; j < listeNum2.Count; j++)
                {
                    ele2 = listeNum2[j];
                    
                    if(ele2 == ele1)
                    {
                        listeNumCommom.Add(ele2);
                        break;
                    }
                }
            }
            foreach (int ele in listeNumCommom)
            {
                Console.WriteLine(ele);

            }
            foreach (int ele in listeNumCommom)
            {
                sum = sum + ele;
                
            }
            return sum;

        }
        static void Main(string[] args)
        {
            
            Console.WriteLine(CalculSommeEntiers(1, 10));
            Console.WriteLine(CalculSommeEntiers(1, 100));
            List<double> liste = new List<double> { 1.0, 5.5, 9.9, 2.8, 9.6 };
           
            Console.WriteLine("Moyenne:" + CalculMoyenne(liste));
            int num1 = 3;
            int num2 = 5;
            Console.WriteLine("Somme des entiers de 3 et 5:" + CalculEntiersMultiple(num1,num2));
        }
    }
}
