using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class TicTacToe
    {
        private static readonly string[,] _defaultBoard =
        {
            {"1","2","3" },
            {"4","5","6" },
            {"7","8","9" }
        };

        private static string _userInput = "";
        private static int _row;
        private static int _col;
        private static int _turnCounter = 0;



        private static string _player = "X";

        // Create the Board
        public static void DisplayBoard()
        {
            Console.WriteLine(); // Aesthetic spacing

            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", _defaultBoard[0, 0], _defaultBoard[0, 1], _defaultBoard[0, 2]);
            Console.WriteLine("\t_____|_____|_____");

            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", _defaultBoard[1, 0], _defaultBoard[1, 1], _defaultBoard[1, 2]);
            Console.WriteLine("\t_____|_____|_____");

            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", _defaultBoard[2, 0], _defaultBoard[2, 1], _defaultBoard[2, 2]);
            Console.WriteLine("\t     |     |     ");

            Console.WriteLine(); // Aesthetic spacing
        }

        // Asks for input until input is integer.
        public static void ValidateInput()
        {
            bool askAgain = true;
            int input = 999;
            while (askAgain)
            {
                Console.WriteLine("Please choose a space on the game board to mark.");
                bool isInt = int.TryParse(Console.ReadLine(), out input);

                if (isInt) { askAgain = false; }
                else { Console.WriteLine("Invalid input. Please enter a number on the game board."); }
            }
            _userInput = input.ToString();
        }

        // Check to make sure requested play is legal
        public static bool ValidateMove()
        {
            // Search function for selection
            for (int i = 0; i < _defaultBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _defaultBoard.GetLength(1); j++)
                {
                    if (_defaultBoard[i, j] == _userInput)
                    //if (_defaultBoard[i, j] != "X" && _defaultBoard[i, j] != "O") *** This does weird shit
                    {
                        _row = i;
                        _col = j;
                        return true;
                    }
                }
            }
            // If input is out of bounds of game board or a valid square already played.
            Console.WriteLine("Invalid input. Please enter a number on the game board.");
            return false;
        }

        // Make move on game board
        public static void PlayerMove()
        {
            _defaultBoard[_row, _col] = _player;
            Console.Clear();
            DisplayBoard();
        }

        // Prompt Player
        public static void PromptPlayer()
        {
            if (_turnCounter % 2 == 0) { _player = "X"; }
            else { _player = "O"; }
            Console.WriteLine($"Player {_player}'s turn.");
        }

        // Player turn
        public static void PlayerTurn()
        {
            Console.Clear();
            DisplayBoard();
            PromptPlayer();
            do
            {
                ValidateInput();
            }
            while (ValidateMove() == false);
            PlayerMove();
        }

        // End turn; Switch Players
        public static void EndTurn()
        {
            _turnCounter++;
        }

        // Method to check for won board
        // Need to make this determine who winner is
        // Needs to read value, not just check matches exist... No
        // Alternatively, could just determine last player to move is winner on true
        // ^ That one. Way easier.
        public static bool WinnerCheck()
        {
            // Vertical and horizontal checks
            for (int i = 0; i < _defaultBoard.GetLength(0); i++)
            {
                // Horizontal
                if (_defaultBoard[i, 0] == _defaultBoard[i, 1] && _defaultBoard[i, 1] == _defaultBoard[i, 2])
                {
                    return true;
                }
                // Vertical
                if (_defaultBoard[0, i] == _defaultBoard[1, i] && _defaultBoard[1, i] == _defaultBoard[2, i])
                {
                    return true;
                }
            }
            // Diagonal checks
            if (_defaultBoard[0, 0] == _defaultBoard[1, 1] && _defaultBoard[1, 1] == _defaultBoard[2, 2])
            {
                return true;
            }
            if (_defaultBoard[0, 2] == _defaultBoard[1, 1] && _defaultBoard[1, 1] == _defaultBoard[2, 0])
            {
                return true;
            }
            return false;
        }

        // Check to see if board is fully played with no winner
        public static bool CatCheck()
        {
            for (int i = 0; i < _defaultBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _defaultBoard.GetLength(1); j++)
                {
                    if (int.TryParse(_defaultBoard[i, j], out _) == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Check for winner or impossible board.
        public static bool GameFinishedCheck()
        {
            if (WinnerCheck() == true)
            {
                Console.WriteLine($"Player {_player} wins! Congrats!");
                return true;
            }
            else if (CatCheck() == true)
            {
                Console.WriteLine("Cat Game. Nobody wins.");
                return true;
            }
            else { return false; }
        }

        public static void ResetBoard()
        {
            int tile = 1;
            for (int i = 0; i < _defaultBoard.GetLength(0); i++)
            {
                for (int j = 0; j < _defaultBoard.GetLength(1); j++)
                {
                    _defaultBoard[i, j] = tile.ToString();
                    tile++;
                }
            }
            _turnCounter = 0;
        }

        public static bool PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("Press 0(zero) + Enter to play again.");
            string cont = Console.ReadLine();
            if (cont == "0")
            {
                ResetBoard();
                return true;
            }
            else { return false; }
        }
    }
}
