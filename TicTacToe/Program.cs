using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tic Tac Toe game

            do
            {
                do
                {
                    TicTacToe.PlayerTurn();
                    TicTacToe.EndTurn();
                }
                while (TicTacToe.GameFinishedCheck() == false);
            }
            while (TicTacToe.PlayAgain() == true);
        }
    }
}
