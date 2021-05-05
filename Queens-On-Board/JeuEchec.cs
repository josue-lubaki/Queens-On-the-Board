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
 * JeuEchec.cs
 * ========
 *      Cette Classe Permet d'initialiser le jeu de solution pour l'échiquier, génère la solution et calcul
 *      le nombre de K-prometteur total de la solution.
 *      
 *░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

namespace Queens_On_Board
{
    class JeuEchec
    {
        public int nombreK_prometteur { get; set; }
        private Matrice mMatrice;

        public JeuEchec(Matrice matrice)
        {
            this.mMatrice = matrice;
        }


        /*******************************************************************************************/
        /**
         * Methode qui vérifie si la reine est en sécurité (hors de danger) sur la ligne, colonne et diagonale
         * @return boolean
         */
        private bool estEnSecurite(int row, int col)
        {
            int i, j;

            /* vérifier les colonnes pour une ligne fixe */
            for (i = 0; i < col; i++)
                if (mMatrice[row, i] == 1)
                    return false;

            /* Vérifier la diagonale gauche supérieur de l'échiquier */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (mMatrice[i, j] == 1)
                    return false;

            /* Vérifier la diagonale gauche inférieure de l'échiquier */
            for (i = row, j = col; j >= 0 && i < mMatrice.ColSize; i++, j--)
                if (mMatrice[i, j] == 1)
                    return false;

            return true;
        }


        /*******************************************************************************************/
        /** Methode qui résout le problèée de la reine d'une manière recursive 
         * @return void
         */
        private bool ResolutionPartielle(int col)
        {
            /* Si toutes les reines sont placées, on retourne vrai */
            if (col >= mMatrice.RowSize)
                return true;

            /* on essaye de placer une reine sur toutes les lignes une par une */
            for (int i = 0; i < mMatrice.RowSize; i++)
            {

                //verifie si une reine peut etre placee dans la ligne i(++) d'une colonne (col) bien precise sans conflit 
                if (estEnSecurite(i, col))
                {
                    //mettre la reine a la position  board[i,col] 
                    mMatrice[i, col] = 1;
                    nombreK_prometteur++;

                    //passer a la colone suivante et refaire l'operation pour inserer la reine  
                    if (ResolutionPartielle(col + 1) == true)
                        return true;

                    /* si placer une reine board[i,col]
                    ne mene pas a une solution alors on enleve la reine du board[i,col] */
                    mMatrice[i, col] = 0; // BACKTRACK
                }
            }

            //Si la reine ne peut  etre placée dans aucune ligne dans cette colone , on retourne faux
            return false;
        }


        /*******************************************************************************************/
        /**
         * Methode qui permet de vérifier si une solution existe pour la taille demandée
         * @return boolean
         * */
        public bool EchequierEstResolvable()
        {
            if (ResolutionPartielle(0) == false)
                return false;

            return true;
        }


        /*******************************************************************************************/
        /**
         * Methode qui permet d'imprimer les resulats (positionnment des reines sur l'échiquier
         * @return void
         * */
        public void printSolution()
        {
            Console.WriteLine(mMatrice.ToString());
        }

       
    }
}
