/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            

            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
    
        /*
         * Fonction de la formule polonaise
         */

        static float Polonaise (String formule)
            {
            try
            {
                // Tranormation formule en vecteur
                string[] vec = formule.Split(' ');
                // nombre de cases remplis
                int nbCase = vec.Length;


                // Boucle tant qu'il reste plus d'une case
                while (nbCase > 1)
                {
                    float resultat = 0;
                    int k = nbCase - 1;
                    // Boucle pour s'arrêter sur un signe en commençant par la fin
                    while (k > 0 && vec[k] != "+" && vec[k] != "-" && vec[k] != "*" && vec[k] != "/")
                    {
                        k--;
                    }
                    // Récupération des deux valeurs numérique
                    float val1 = float.Parse(vec[k + 1]);
                    float val2 = float.Parse(vec[k + 2]);


                    // Calcule des valeurs récupérer 
                    switch (vec[k])
                    {
                        case "+": resultat = val1 + val2; break;
                        case "-": resultat = val1 - val2; break;
                        case "*": resultat = val1 * val2; break;
                        case "/":
                            if (val2 == 0)
                            {
                                return float.NaN;
                            }
                            resultat = val1 / val2; break;

                    }
                    // Stokage et conversion du resultat dans la bonne case
                    vec[k] = resultat.ToString();

                    // Décalages de 2 cases pour la suite du vecteur (supression de 2 cases)
                    for (int i = k + 1; i < nbCase - 2; i++)
                    {
                        vec[i] = vec[i + 2];
                    }
                    nbCase -= 2;

                }

                return float.Parse(vec[0]); 
            }
            catch
            {
                // Erreur rencontrée 
                return float.NaN;
            }

        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
            Console.ReadLine();
        }
    }
}
