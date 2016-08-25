using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Controller
    {
        public static List<string> placements = new List<string>();
        public static List<string[]> movements = new List<string[]>();
        public static bool checkMate = false;
        protected static int pieceYPlacement = 3;
        protected static int pieceXPlacement = 2;
        protected static int castlingLength = 4;
        protected static int pieceCaptureLength = 3;
        public static void PlacePieces()
        {
            foreach (string s in placements)
            {
                GameBoard.board[(s[pieceYPlacement] - 49), s[pieceXPlacement] - 97] = Piece.GeneratePiece(s);
            }
            GameBoard.GenerateBoard();
        }
       
        public static void MovePieces(Location start, Location end)
        {

            //Location start = Location.convertFromString(s[0]);
            //Location end = Location.convertFromString(s[1]);
            //int firstPieceX = GameBoard.ConvertFromAsciiLetter(s[0][0]);
            //int firstPieceY = GameBoard.ConvertFromAsciiNumber(s[0][1]);
            //int secondPieceX = GameBoard.ConvertFromAsciiLetter(s[1][0]);
            //int secondPieceY = GameBoard.ConvertFromAsciiNumber(s[1][1]);

            //if (s.Length == castlingLength)
            //{
            //    Console.WriteLine("Moves the king from " + s[0] + " to " + s[1] + " and moves the rook from " + s[2] + " to " + s[3]);
            //}
            //else {
            string result = "";
            if (GetValidityConditions(start, end))
            {
                Piece startingPiece = GameBoard.board[start.Y, start.X];
                Piece endPiece = GameBoard.board[end.Y, end.X];
                if (startingPiece.CheckValidMove(end))
                {
                    GameBoard.board[end.Y, end.X] = startingPiece;
                    GameBoard.board[start.Y, start.X] = null;
                    result += string.Format("Move the piece from {0} to {1}", start, end);
                    //if (s[1].Length == pieceCaptureLength)
                    //{
                    //    result += string.Format(" and captures the piece at {0}", start);
                    //}
                    if (startingPiece.PieceType == ChessPiece.King)
                    {
                        if (MoveValidity.KingMovementCheck(end, startingPiece))
                        {
                            GameBoard.board[start.Y, start.X] = startingPiece;
                            GameBoard.board[end.Y, end.X] = endPiece;
                            Console.WriteLine("The king cannot put itself into check/Or is still in check with that move");
                        }
                        else
                        {
                            startingPiece.MoveLocation(end);
                            Console.WriteLine(result);
                            GameBoard.GenerateBoard();
                            CheckTurn.ChangeTurn();
                        }
                    }
                    else if (MoveValidity.CheckForDefendingCheck(startingPiece))
                    {
                        GameBoard.board[start.Y, start.X] = startingPiece;
                        GameBoard.board[end.Y, end.X] = endPiece;
                        Console.WriteLine(string.Format("Cannot make that move, the {0} king would be put into check/is still in check", startingPiece.Color));
                    }
                    else
                    {
                        startingPiece.MoveLocation(end);
                        Console.WriteLine(result);
                        if (MoveValidity.CheckForAttackingCheck(GameBoard.board[end.Y, end.X]))
                        {
                            Console.WriteLine("{0} {1} has put {2} king into check.", GameBoard.board[end.Y, end.X].Color, GameBoard.board[end.Y, end.X].PieceType, GameBoard.board[end.Y, end.X].GetOpposing());
                            if (CheckForCheckmate(GameBoard.GetOpposingKing(startingPiece.Color)))
                            {
                                Console.WriteLine("Checkmate occurred. {0} player has won", startingPiece.Color);
                                checkMate = true;
                            }
                        }
                        GameBoard.GenerateBoard();
                        CheckTurn.ChangeTurn();
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Movement from {0} to {1} is not valid", start, end));
                }


            }
        }
        public static bool GetValidityConditions(Location start, Location end)
        {
            if (GameBoard.board[start.Y, start.X] != null)
            {
                if (CheckTurn.CheckValidTurn(GameBoard.board[start.Y, start.X]))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Not that piece's turn to move");
                    return false;
                }
            }
            else
            {
                Console.WriteLine(start.ToString() + " is empty");
                return false;
            }
        }
        public static int NumberOfPiecesCheck(Piece King)
        {
            Piece opposingKing = GameBoard.GetOpposingKing(King.Color);
            List<Piece> attackers = GameBoard.GetPiecesOfColor(opposingKing.Color);
            int numOfCheck = 0;
            foreach (Piece att in attackers)
            {
                if (att.CheckValidMove(King.Location))
                {
                    numOfCheck++;
                }
            }
            return numOfCheck;
        }
        public static bool CheckForCheckmate(Piece King)
        {
            List<Piece> defendingPieces = GameBoard.GetPiecesOfColor(King.Color);
            List<List<Location>> defendingMoves = new List<List<Location>>();
            List<Location> attackerPositions = new List<Location>();
            List<Location> kingMoves = King.GetValidMoves();
            List<Location> kingValidMoves = new List<Location>();
            GetAttackerPositions(King, -1, -1, attackerPositions);
            GetAttackerPositions(King, 0, -1, attackerPositions);
            GetAttackerPositions(King, 1, -1, attackerPositions);
            GetAttackerPositions(King, 1, 0, attackerPositions);
            GetAttackerPositions(King, 1, 1, attackerPositions);
            GetAttackerPositions(King, 0, 1, attackerPositions);
            GetAttackerPositions(King, -1, 1, attackerPositions);
            GetAttackerPositions(King, -1, 0, attackerPositions);
            GetKnightAttacks(King, attackerPositions);
            bool checkMate = false;
            bool kingNotStuck = false;
            foreach (Piece def in defendingPieces)
            {
                defendingMoves.Add(def.GetValidMoves());
            }
            if (NumberOfPiecesCheck(King) > 1)
            {
                foreach (Location move in kingMoves)
                {
                    //Console.WriteLine(move);
                    if (!MoveValidity.KingMovementCheck(move, King))
                    {
                        Console.WriteLine("Can move to {0}", move);
                        if (!kingNotStuck)
                        {
                            kingNotStuck = true;
                        }
                    }
                }
                checkMate = !kingNotStuck;
            }
            else
            {
                bool block = false;
                foreach (Piece dPiece in defendingPieces)
                {
                    if (!block)
                    {
                        foreach (Location move in dPiece.GetValidMoves())
                        {
                            if (dPiece.PieceType == ChessPiece.King)
                            {
                                Console.WriteLine(move);
                                if (!MoveValidity.KingMovementCheck(move, King))
                                {
                                    block = true;
                                }
                            }
                            else
                            {
                                block = attackerPositions.Contains(move);
                            }
                        }
                    }
                }
                checkMate = !block;
            }
            return checkMate;
        }
        //Checks if any knight can attack the king
        public static void GetKnightAttacks(Piece King, List<Location> list)
        {
            foreach (Piece p in GameBoard.board)
            {
                if (p != null)
                {
                    if (p.Color != King.Color)
                    {
                        if (p.PieceType == ChessPiece.Knight)
                        {
                            if (p.CheckValidMove(King.Location))
                            {
                                list.Add(p.Location);
                            }
                        }
                    }
                }
            }
        }
        public static void GetAttackerPositions(Piece King, int yIncrement, int xIncrement, List<Location> list)
        {
            int checkX = King.Location.X;
            int checkY = King.Location.Y;
            bool foundPiece = false;
            bool keepGoing = true;
            List<Location> dangerousPositions = new List<Location>();
            while (keepGoing)
            {
                checkX += yIncrement;
                checkY += xIncrement;
                if (keepGoing = ((checkX >= 0 && checkX < GameBoard.board.GetLength(0)) && (checkY >= 0 && checkY < GameBoard.board.GetLength(1))))
                {
                    Location checkLoc = new Location() { X = (byte)checkX, Y = (byte)checkY };
                    Piece temp = GameBoard.board[checkLoc.Y, checkLoc.X];
                    if (temp != null)
                    {
                        if (King.Color != temp.Color)
                        {
                            switch (temp.PieceType)
                            {
                                case ChessPiece.Bishop:
                                    if ((foundPiece = (Math.Abs(yIncrement) == 1 && Math.Abs(xIncrement) == 1)))
                                    {
                                        dangerousPositions.Add(checkLoc);
                                    }
                                    break;
                                case ChessPiece.Rook:
                                    if ((foundPiece = (yIncrement == 0 || xIncrement == 0)))
                                    {
                                        dangerousPositions.Add(checkLoc);
                                    }
                                    break;
                                case ChessPiece.Queen:
                                    foundPiece = true;
                                    dangerousPositions.Add(checkLoc);
                                    break;
                                case ChessPiece.Pawn:
                                    if (temp.CheckValidMove(King.Location))
                                    {
                                        foundPiece = true;
                                        dangerousPositions.Add(checkLoc);
                                    }
                                    break;
                            }
                        }
                        keepGoing = false;
                    }
                    else
                    {
                        dangerousPositions.Add(checkLoc);
                    }
                }
            }
            if (foundPiece)
            {
                list.AddRange(dangerousPositions);
            }
        }
    }
}
