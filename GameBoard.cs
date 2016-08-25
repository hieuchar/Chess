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
        public static Piece[,] board = new Piece[boardHeight, boardLength];
        public static Dictionary<string, ChessPiece> pawnPromotion = new Dictionary<string, ChessPiece>()
        {
            {"Q", ChessPiece.Queen },
            {"B", ChessPiece.Bishop},
            {"N", ChessPiece.Knight},
            {"R", ChessPiece.Rook}           
        };
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
        public static bool CheckValidMove(Location Location, Location Destination)
        {
            if (!CheckSameColor(Location, Destination))
            {
                if (!CheckStraightCollision(Location, Destination)) return true;
            }
            return false;
        }
        public static void PromotePawn(Piece pawn)
        {
            PieceColor tC = pawn.Color;
            Location tL = pawn.Location;
            Console.WriteLine("Please select a piece type to promote your pawn to");
            Console.WriteLine(" 'Q' : Queen");
            Console.WriteLine(" 'B' : Bishop");
            Console.WriteLine(" 'N' : Knight");
            Console.WriteLine(" 'R' : Rook");
            ChessPiece s = pawnPromotion[Console.ReadLine().ToUpper()];
            GameBoard.board[tL.Y, tL.X] = Piece.GeneratePiece(s, tC, tL);
        }
        public static bool CheckSameColor(Location Location, Location Destination)
        {
            int startXLocation = Location.X;
            int startYLocation = Location.Y;
            int destXLocation = Destination.X;
            int destYLocation = Destination.Y;
            if (board[destYLocation, destXLocation] != null)
                return (board[startYLocation, startXLocation].Color == board[destYLocation, destXLocation].Color);
            else return false;
        }
        public static bool CheckStraightCollision(Location Location, Location Destination)
        {
            int startXLocation = Location.X;
            int startYLocation = Location.Y;
            int destXLocation = Destination.X;
            int destYLocation = Destination.Y;
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
                        if (board[startYLocation, startXLocation - i] != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool CheckDiagonalCollision(Location Location, Location Destination)
        {
            int startXLocation = Location.X;
            int startYLocation = Location.Y;
            int destXLocation = Destination.X;
            int destYLocation = Destination.Y;
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
        public static int ConvertFromAsciiLetter(int target)
        {
            return target - 97;
        }
        public static int ConvertFromAsciiNumber(int target)
        {
            return target - 49;
        }
        public static Piece GetOpposingKing(PieceColor c)
        {
            foreach(Piece p in board)
            {
                if (p != null)
                {
                    if (p.PieceType == ChessPiece.King && p.Color != c)
                    {
                        return p;
                    }
                }
            }
            return null;
        }
        public static Piece GetSameKing(PieceColor c)
        {
            foreach (Piece p in board)
            {
                if (p != null)
                {
                    if (p.PieceType == ChessPiece.King && p.Color == c)
                    {
                        return p;
                    }
                }
            }
            return null;
        }
        public static List<Piece> GetPiecesOfColor(PieceColor C)
        {
            List<Piece> pieces = new List<Piece>();
            foreach(Piece p in board)
            {
                if(p != null)
                {
                    if(p.Color == C)
                    {
                        pieces.Add(p);
                    }
                }
            }
            return pieces;
        }
    }
}
