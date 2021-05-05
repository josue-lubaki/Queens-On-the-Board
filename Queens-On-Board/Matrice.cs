using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Accueil.cs  ***********************************************************************************************
 **********     @Authors :                                             Date : 05 Avril 2021       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 **********                 * Edgard Koffi                                                        **********
 ***********************************************************************************************************/
/*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
 * Matrice.cs
 * ========
 *      la Structure de données Utilisée pour stocker les données
 *      
 *░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

namespace Queens_On_Board
{
    class Matrice
    {
        /**********************************************************************************************/
        /***************                VARIABLES INSTANCES & CONSTRUCTEUR              ***************/
        /**********************************************************************************************/
        private int[,] data;
        public Matrice(int dimension)
        {
            this.data = new int[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Data[i, j] = 0;
                }
            }
        }
        public int[,] Data
        {
            get { return data; }
            set { data = value; }
        }


        /**********************************************************************************************/
        /***************                    DIMENSION DE LA MATRICE                     ***************/
        /**********************************************************************************************/
        /** Obtenir la Taille de la Matrice : Ligne et Colonne 
         *  @param RowSize : Nombre des lignes contenues dans la matrice
         *  @param ColSize : Nombre des Colonnes contenues dans la matrice 
         *  
         *  @return int    */
        public int RowSize
        {
            get { return data.GetLength(0); }
        }
        public int ColSize
        {
            get { return data.GetLength(1); }
        }

        /**********************************************************************************************/
        /***************                MANIPULATION DES DONNEES DE LA MATRICE          ***************/
        /**********************************************************************************************/
        /** Obtenir un élement en particulier du Tableau 
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  
         *  @return double  
         */
        public int GetElement(int ligne, int colonne)
        {
            return Data[ligne, colonne];
        }

        /** Modifier un élement en particulier du Tableau
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  3ième Paramètre : Correspond à la nouvelle Valeur à Insérer 
         *  
         *  @return void    */
        public void SetElement(int ligne, int colonne, int value)
        {
            Data[ligne, colonne] = value;
        }

        /**
         Transposée de la Matrice
        */
        /** Opération : Transposé d'une Matrice 
         *  Condition : La Matrice doit être Carrée afin de trouver sa Transposée 
         *  
         *  @return Matrice */
        public Matrice Transposee
        {
            get
            {
                try
                {
                    if (!EstCarree)
                        throw new Exception("La Matrice n'est pas carrée : Impossible de Calculer la transposee | return 'null'");
                    Matrice matrix = new Matrice(ColSize);
                    for (int i = 0; i < RowSize; i++)
                    {
                        for (int j = 0; j < ColSize; j++)
                        {
                            if (i == j) // Pour ne pas modifier la Trace
                            {
                                matrix[i, j] = Data[i, j];
                                break;
                            }
                            // Swap
                            int tempo = Data[i, j];
                            matrix[i, j] = Data[j, i];
                            matrix[j, i] = tempo;
                        }
                    }
                    return matrix;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                    return null;
                }
            }
        }

        /**
         */
        /** Opération : Est Carree ? 
         *  Cette fonction renvoi <<True>> si la Matrice est Carrée (2 par 2 || 3 par 3 ||...) 
         *  Condition : Nombre de Colonne == Nombres de ligne 
         *
         *  @return bool */
        public bool EstCarree
        {
            get
            {
                return (RowSize == ColSize) ? true : false;
            }
        }





        /**********************************************************************************************/
        /****************                FORMAT DE SORTIE                               ***************/
        /**********************************************************************************************/
        /** Indexeur de la matrice 
         *  1er Paramètre : Correspond au numero de Ligne 
         *  2ème Paramètre : Correspond au numero de la Colonne 
         *  
         *  @return double  */
        public int this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public override string ToString()
        {
            string output = "\n";
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                    output += " " + (this[i, j]==1 ? " Q " : "---") + " ";
                output += "\n\n";
            }
            return output;

        }
    }

}
