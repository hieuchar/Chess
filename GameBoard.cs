using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chess
{
    public static class GameBoard
    {
        private static int boardLength = 8;
        private static int boardHeight = 8;
        private static Piece[,] board = new Piece[boardHeight, boardLength];
        public static void StartBoard()
        {
            string[] inputFile = Environment.GetCommandLineArgs();
            if (File.Exists(inputFile[1]))
            {
                Parser p = new Parser(ReadFile(inputFile[1]), board);
            }
            else
            {
                MessageBox.Show(inputFile[1] + " does not exist");
                Application.Current.Shutdown();
            }
            GenerateBoard();
        }
        public static void GenerateBoard()
        {
            for (int height = 0; height < boardHeight; height++)
            {
                for (int length = 0; length < boardLength; length++)
                {
                    if (length == 0)
                    {
                        Console.Write('|');
                    }
                    Console.Write(board[height, length]);
                    if (board[height, length] == null)
                    {
                        Console.Write(" ");
                    }
                    Console.Write('|');
                    if (length == 7)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
        private static string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
        public static bool CheckValidMove(string Location, string Destination)
        {
            if (!CheckSameColor(Location, Destination))
            {
                if (!CheckStraightCollision(Location, Destination)) return true;
            }
            return false;
        }
        public static bool CheckSameColor(string Location, string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (board[destYLocation, destXLocation] != null)
                return (board[startYLocation, startXLocation].Color == board[destYLocation, destXLocation].Color);
            else return false;
        }
        public static bool CheckStraightCollision(string Location, string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (startXLocation == destXLocation)
            {
                if (startYLocation < destYLocation)
                {
                    for (int i = 1; i < destYLocation - startYLocation; i++)
                    {
                        if (board[startYLocation + i, startXLocation] != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < startYLocation - destYLocation; i++)
                    {
                        if (board[startYLocation - i, startXLocation] != null)
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (startXLocation < destXLocation)
                {
                    for (int i = 1; i < destXLocation - startXLocation; i++)
                    {
                        if (board[startYLocation, startXLocation + i] != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < startXLocation - destXLocation; i++)
                    {
                        if (board[startYLocation, startXLocation + i] != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool CheckDiagonalCollision(string Location, string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (startYLocation < destYLocation)
            {
                if (startXLocation < destXLocation)
                {
                    for (int i = 1; i < Math.Abs(startXLocation - destXLocation); i++)
                    {
                        if (board[startYLocation + i, startXLocation + i] != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < Math.Abs(startXLocation - destXLocation); i++)
                    {
                        if (board[startYLocation + i, startXLocation - i] != null)
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (startXLocation < destXLocation)
                {
                    for (int i = 1; i < Math.Abs(startXLocation - destXLocation); i++)
                    {
                        if (board[startYLocation - i, startXLocation + i] != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < Math.Abs(startXLocation - destXLocation); i++)
                    {
                        if (board[startYLocation - i, startXLocation - i] != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
