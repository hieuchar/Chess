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
        public static bool CheckBishopMove(Location loc, Location Destination)
        {
            startXLocation = loc.X;
            startYLocation = loc.Y;
            destXLocation = Destination.X;
            destYLocation = Destination.Y;
            if (!GameBoard.CheckSameColor(loc, Destination))
            {
                if (startXLocation == destXLocation || startYLocation == destYLocation)
                {
                    return false;
                }
                if (Math.Abs(startXLocation - destXLocation) == Math.Abs(startYLocation - destYLocation))
                {
                    if (!GameBoard.CheckDiagonalCollision(loc, Destination))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CheckPawnMove(bool firstMove, Location loc, Location Destination)
        {
            Piece pawn = GameBoard.board[loc.Y, loc.X];
            startXLocation = loc.X;
            startYLocation = loc.Y;
            destXLocation = Destination.X;
            destYLocation = Destination.Y;
            int yDirection = pawn.Color == PieceColor.White ? 1 : -1;
            if (firstMove)
            {
                if (GameBoard.board[startYLocation + yDirection, startXLocation] == null)
                {
                    if (startXLocation == destXLocation && destYLocation == startYLocation + (yDirection * 2))
                    {
                        return true;
                    }
                    else if (startXLocation == destXLocation && destYLocation == startYLocation + yDirection)
                    {
                        return true;
                    }
                    else return false;
                }
                else if (startXLocation != destXLocation && Math.Abs(startXLocation - destXLocation) == 1)
                {
                    if (startYLocation + yDirection == destYLocation && GameBoard.board[destYLocation, destXLocation] != null)
                    {
                        if (!GameBoard.CheckSameColor(loc, Destination)) return true;
                        else return false;
                    }
                    else return false;
                }
                else
                {
                    return false;
                }
            }
            else if (startXLocation == destXLocation && destYLocation == startYLocation + yDirection)
            {
                if (GameBoard.board[destYLocation, destXLocation] == null) return true;
                else return false;
            }
            else if (startXLocation != destXLocation && Math.Abs(startXLocation - destXLocation) == 1)
            {
                if (startYLocation + yDirection == destYLocation && GameBoard.board[destYLocation, destXLocation] != null)
                {
                    if (!GameBoard.CheckSameColor(loc, Destination)) return true;
                    else return false;
                }
                else return false;
            }
            else return false;

            //if (firstMove)
            //{
            //    if (startXLocation == destXLocation)
            //    {
            //        if (yDirection == -1)
            //        {
            //            if (destYLocation >= startYLocation + yDirection * 2 && destYLocation < startYLocation)
            //            {
            //                if (GameBoard.board[destYLocation, destXLocation] == null && GameBoard.CheckStraightCollision(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //        else
            //        {
            //            if (destYLocation <= startYLocation + yDirection && destYLocation > startYLocation)
            //            {
            //                if (GameBoard.board[destYLocation, destXLocation] == null && GameBoard.CheckStraightCollision(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //    }
            //    else if(yDirection == -1)
            //    {
            //        if ((startYLocation - destYLocation == 1) && (Math.Abs(startXLocation - destXLocation) == 1))
            //        {
            //            if (GameBoard.board[destYLocation, destXLocation] != null )
            //            {
            //                if (!GameBoard.CheckSameColor(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }                    
            //        else return false;
            //    }
            //    else if (yDirection == 1)
            //    {
            //        if ((destYLocation - startYLocation == 1) && (Math.Abs(startXLocation - destXLocation) == 1))
            //        {
            //            if (GameBoard.board[destYLocation, destXLocation] != null)
            //            {
            //                if (!GameBoard.CheckSameColor(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //        else return false;
            //    }
            //    else return false;
            //}
            //else
            //{
            //    if (startXLocation == destXLocation)
            //    {
            //        if (yDirection == -1)
            //        {
            //            if (destYLocation >= startYLocation + yDirection  && destYLocation < startYLocation)
            //            {
            //                if (GameBoard.board[destYLocation, destXLocation] == null && GameBoard.CheckStraightCollision(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //        else
            //        {
            //            if (destYLocation <= startYLocation + yDirection  && destYLocation > startYLocation)
            //            {
            //                if (GameBoard.board[destYLocation, destXLocation] == null && GameBoard.CheckStraightCollision(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //    }
            //    else if (yDirection == -1)
            //    {
            //        if ((startYLocation - destYLocation == 1) && (Math.Abs(startXLocation - destXLocation) == 1))
            //        {
            //            if (GameBoard.board[destYLocation, destXLocation] != null)
            //            {
            //                if (!GameBoard.CheckSameColor(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //        else return false;
            //    }
            //    else if (yDirection == 1)
            //    {
            //        if ((destYLocation - startYLocation == 1) && (Math.Abs(startXLocation - destXLocation) == 1))
            //        {
            //            if (GameBoard.board[destYLocation, destXLocation] != null)
            //            {
            //                if (!GameBoard.CheckSameColor(loc, Destination))
            //                {
            //                    return true;
            //                }
            //                else return false;
            //            }
            //            else return false;
            //        }
            //        else return false;
            //    }
            //    else return false;
            //}
        }
        public static bool CheckRookMove(Location loc, Location Destination)
        {
            startXLocation = loc.X;
            startYLocation = loc.Y;
            destXLocation = Destination.X;
            destYLocation = Destination.Y;
            if (startXLocation != destXLocation && startYLocation != destYLocation)
            {
                return false;
            }
            else if (GameBoard.CheckValidMove(loc, Destination))
            {
                return true;
            }
            return false;
        }
        public static bool CheckKnightMove(Location loc, Location Destination)
        {
            startXLocation = loc.X;
            startYLocation = loc.Y;
            destXLocation = Destination.X;
            destYLocation = Destination.Y;
            if (Math.Abs(startXLocation - destXLocation) == 2)
            {
                if (Math.Abs(startYLocation - destYLocation) == 1)
                {
                    if (GameBoard.board[destYLocation, destXLocation] != null)
                    {
                        return !GameBoard.CheckSameColor(loc, Destination);
                    }
                    else
                    {
                        return true;
                    }
                }
                else return false;
            }
            else if (Math.Abs(startYLocation - destYLocation) == 2)
            {
                if (Math.Abs(startXLocation - destXLocation) == 1)
                {
                    if (GameBoard.board[destYLocation, destXLocation] != null)
                    {
                        return !GameBoard.CheckSameColor(loc, Destination);
                    }
                    else
                    {
                        return true;
                    }
                }
                else return false;
            }
            return false;
        }
        public static bool CheckQueenMove(Location loc, Location Destination)
        {
            return (CheckBishopMove(loc, Destination) || CheckRookMove(loc, Destination));
        }
        public static bool CheckKingMove(Location loc, Location Destination)
        {
            startXLocation = loc.X;
            startYLocation = loc.Y;
            destXLocation = Destination.X;
            destYLocation = Destination.Y;
            if (Math.Abs(startXLocation - destXLocation) > 1 || Math.Abs(startYLocation - destYLocation) > 1)
            {
                return false;
            }
            if (GameBoard.CheckValidMove(loc, Destination))
            {
                return true;
            }
            return false;
        }
        public static bool CheckPawnMove(string loc, string Destination)
        {
            throw new NotImplementedException();
        }
        public static bool CheckForAttackingCheck(Piece c)
        {
            if (c.PieceType != ChessPiece.King)
            {
                Piece king = GameBoard.GetOpposingKing(c.Color);
                return c.CheckValidMove(king.Location);
            }
            else return false;
        }
        public static bool CheckForDefendingCheck(Piece c)
        {
            foreach (Piece p in GameBoard.board)
            {
                if (p != null)
                {
                    if (p.Color != c.Color)
                    {
                        if (CheckForAttackingCheck(p))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool KingMovementCheck(Location Destination, Piece King)
        {
            foreach (Piece p in GameBoard.board)
            {
                if (p != null)
                {
                    if (p.Color != King.Color)
                    {
                        if (p.CheckValidMove(Destination))
                        {
                            Console.WriteLine("{0} at {1} can hit {2}", p, p.Location, Destination);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
