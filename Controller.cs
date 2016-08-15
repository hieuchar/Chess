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
        protected static int pieceYPlacement = 3;
        protected static int pieceXPlacement = 2;
        protected static int castlingLength = 4;
        protected static int pieceCaptureLength = 3;
        public static void PlacePieces()
        {
            foreach(string s in placements)
            {
                GameBoard.board[(s[pieceYPlacement] - 49), s[pieceXPlacement] - 97] = Piece.GeneratePiece(s);
            }
        }
        public static void MovePieces()
        {
            foreach (string[] s in movements)
            {
                int firstPieceX = GameBoard.ConvertFromAsciiLetter(s[0][0]);
                int firstPieceY = GameBoard.ConvertFromAsciiNumber(s[0][1]);
                int secondPieceX = GameBoard.ConvertFromAsciiLetter(s[1][0]);
                int secondPieceY = GameBoard.ConvertFromAsciiNumber(s[1][1]);
                string result = "";
                if (s.Length == castlingLength)
                {
                    Console.WriteLine("Moves the king from " + s[0] + " to " + s[1] + " and moves the rook from " + s[2] + " to " + s[3]);
                }
                else {

                    if (GameBoard.board[firstPieceY, firstPieceX] != null)
                    {
                        if (CheckTurn.CheckValidTurn(GameBoard.board[firstPieceY, firstPieceX]))
                        {
                            if (GameBoard.board[firstPieceY, firstPieceX].CheckValidMove(s[1].Substring(0, 2)))
                            {
                                GameBoard.board[secondPieceY, secondPieceX] = GameBoard.board[firstPieceY, firstPieceX];
                                GameBoard.board[firstPieceY, firstPieceX] = null;
                                result += string.Format("Move the piece from {0} to {1}", s[0], s[1].Substring(0, 2));
                                if (s[1].Length == pieceCaptureLength)
                                {
                                    result += string.Format(" and captures the piece at {0}", s[1].Substring(0, 2));
                                }
                                Console.WriteLine(result);
                                if (MoveValidity.CheckForCheck(GameBoard.board[secondPieceY, secondPieceX]))
                                {
                                    Console.WriteLine("{0} {1} has put {2} king into check.", GameBoard.board[secondPieceY, secondPieceX].Color, GameBoard.board[secondPieceY, secondPieceX].PieceType, GameBoard.board[secondPieceY, secondPieceX].GetOpposing());
                                }
                                CheckTurn.ChangeTurn();
                                GameBoard.GenerateBoard();
                            }
                            else
                            {
                                Console.WriteLine(string.Format("Movement from {0} to {1} is not valid", s[0], s[1].Substring(0, 2)));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not that piece's turn to move");
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0} is empty", s[0]));
                    }
                }

            }
        }
    }
}
