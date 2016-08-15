using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveValidity
    {
        private static int startXLocation;
        private static int startYLocation;
        private static int destXLocation;
        private static int destYLocation;
        public static bool CheckBishopMove(string Location, string Destination)
        {
            startXLocation = Location[0] - 97;
            startYLocation = Location[1] - 49;
            destXLocation = Destination[0] - 97;
            destYLocation = Destination[1] - 49;
            if (!GameBoard.CheckSameColor(Location, Destination))
            {
                if (startXLocation == destXLocation || startYLocation == destYLocation)
                {
                    return false;
                }
                if (Math.Abs(startXLocation - destXLocation) == Math.Abs(startYLocation - destYLocation))
                {
                    if (!GameBoard.CheckDiagonalCollision(Location, Destination))
                    {                        
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CheckRookMove(string Location, string Destination)
        {
            startXLocation = Location[0] - 97;
            startYLocation = Location[1] - 49;
            destXLocation = Destination[0] - 97;
            destYLocation = Destination[1] - 49;
            if (startXLocation != destXLocation && startYLocation != destYLocation)
            {
                return false;
            }
            else if (GameBoard.CheckValidMove(Location, Destination))
            {                
                return true;
            }
            return false;
        }
        public static bool CheckKnightMove(string Location, string Destination)
        {
            startXLocation = Location[0] - 97;
            startYLocation = Location[1] - 49;
            destXLocation = Destination[0] - 97;
            destYLocation = Destination[1] - 49;
            if (Math.Abs(startXLocation - destXLocation) == 2)
            {
                if (Math.Abs(startYLocation - destYLocation) == 1)
                {
                    return true;
                }
                else return false;
            }
            else if (Math.Abs(startYLocation - destYLocation) == 2)
            {
                if (Math.Abs(startXLocation - destXLocation) == 1)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
        public static bool CheckQueenMove(string Location, string Destination)
        {
            return (CheckBishopMove(Location, Destination) || CheckRookMove(Location, Destination));
        }
        public static bool CheckKingMove(string Location, string Destination)
        {
            startXLocation = Location[0] - 97;
            startYLocation = Location[1] - 49;
            destXLocation = Destination[0] - 97;
            destYLocation = Destination[1] - 49;
            if (Math.Abs(startXLocation - destXLocation) > 1 || Math.Abs(startYLocation - destYLocation) > 1)
            {
                return false;
            }
            if (GameBoard.CheckValidMove(Location, Destination))
            {                
                return true;
            }
            return false;
        }
        public static bool CheckPawnMove(string Location, string Destination)
        {
            throw new NotImplementedException();
        }
        public static bool CheckForCheck(Piece c)
        {
            if (c.PieceType != ChessPiece.King)
            {
                Piece king = GameBoard.GetOpposingKing(c.Color);
                return c.CheckValidMove(king.Location);
            }
            else return false;
        }

    }
}
