using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queens_On_Board
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResoudreEchequier(8);
        }

        private static int nombreK_prometteur = 0;

        /**
        * Methode qui permet d'afficher toutes les cases de l'échiquier
        * @return void
        */
        void AfficherSolution(Matrice board)
        {
            for (int i = 0; i < board.ColSize; i++)
            {
                for (int j = 0; j < board.ColSize; j++)
                    Console.Write(" " + board[i, j]
                                      + " ");
                Console.WriteLine();
            }
        }

        
        /**
         * Methode qui vérifie si la reine est en sécurité (hors de danger) sur la ligne, colonne et diagonale
         * @return boolean
         */
        bool estEnSecurite(Matrice board, int row, int col)
        {
            int i, j;

            /* vérifier les colonnes pour une ligne fixe */
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            /* Vérifier la diagonale gauche supérieur de l'échiquier */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Vérifier la diagonale gauche inférieure de l'échiquier */
            for (i = row, j = col; j >= 0 && i < board.ColSize; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        /* Methode qui résout le problèée de la reine d'une manière recursive */
        bool ResolutionPartielle(Matrice board, int col)
        {
            /* Si toutes les reines sont placées, on retourne vrai */
            if (col >= board.RowSize)
                return true;

            /* on essaye de placer une reine sur toutes les lignes une par une */
            for (int i = 0; i < board.RowSize; i++)
            {
               
                //verifie si une reine peut etre placee dans la ligne i(++) d'une colonne (col) bien precise sans conflit 
                if (estEnSecurite(board, i, col))
                {
                    //mettre la reine a la position  board[i,col] 
                    board[i, col] = 1;
                    nombreK_prometteur++;

                    //passer a la colone suivante et refaire l'operation pour inserer la reine  
                    if (ResolutionPartielle(board, col + 1) == true)
                        return true;

                    /* si placer une reine board[i,col]
                    ne mene pas a une solution alors on enleve la reine du board[i,col] */
                    board[i, col] = 0; // BACKTRACK
                }
            }


            //Si la reine ne peut  etre placée dans aucune ligne dans cette colone , on retourne faux
           
            return false;
        }

        
        bool ResoudreEchequier(int N)
        {
            Matrice matrice = new Matrice(N);

            if (ResolutionPartielle(matrice, 0) == false)
            {
                Console.Write("La Solution n'existe pas !");
                return false;
            }

            AfficherSolution(matrice);
            Console.Write("Voici le nombre de k-prometteurs produits avant : " + nombreK_prometteur);
            return true;
        }

    }
}
