using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Accueil.cs  ***********************************************************************************************
 **********     @Authors :                                             Date : 05 Avril 2021       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 **********                 * Edgard Koffi                                                        **********
 ***********************************************************************************************************/

namespace Queens_On_Board
{
    public partial class Form1 : Form
    {

        private JeuEchec jeu;
        private int tailleMatrice;
        private Matrice matrice;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menus();
        }

        
        void Menus()
        {
            this.Hide();
            bool flag = true;
            int menu;

            while (flag)
            {

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    "\n\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■" +
                    "\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ MENU PRINCIPAL ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■" +
                    "\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.ResetColor();

                Console.WriteLine("\nVoici les Options disponibles :" +
                  "\n\t1. Initilialiser l'Échiquier" +
                  "\n\t2. Générer la liste des solutions pour les reines sur l'échiquier" +
                   "\n\t3. Quitter\n");
                Console.Write("Selectionner l'Option : ");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine(" Entrer la taille de la Matrice");
                        tailleMatrice = Convert.ToInt32(Console.ReadLine());
                        matrice = new Matrice(tailleMatrice);
                        jeu = new JeuEchec(matrice);
                        break;

                    case 2:
                        if (jeu.EchequierEstResolvable())
                            jeu.printSolution();
                        else
                            Console.WriteLine("Désolé, La Solution n'existe pas !");
                        break;

                    case 3:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        flag = false;
                        Console.WriteLine("\n\t\t\tCopyright 2021 - Toute Reproduction Interdite\n\t\t\t\t\t\tMerci !");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Application.Exit();
                        break;

                    default:
                        Console.WriteLine("Saisir quelque chose de correct please");
                        break;
                }
            }

        }

    }
}
