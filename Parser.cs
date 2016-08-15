using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Parser
    {
        protected List<string[]> instructionLine = new List<string[]>();
        protected List<string> output = new List<string>();
        protected Dictionary<char, string> chessPieces = new Dictionary<char, string>()
        {
            {'Q', "Queen" },
            {'K', "King" },
            {'B', "Bishop" },
            {'N', "Knight" },
            {'R', "Rook" },
            {'P', "Pawn" },
            {'l', "White" },
            {'d', "Black" }
        };
        protected int piecePlacement = 4;
        protected int pieceCapture = 3;
        protected int pieceLocation = 2;
        protected int castling = 4;
        protected int pieceIndex = 0;
        protected int pieceColorIndex = 1;
        protected int pieceYPlacement = 3;
        protected int pieceXPlacement = 2;

        protected string[] fileInfo;
        private Piece[,] gameBoard;
        public Parser(string[] lines, Piece[,] board)
        {
            fileInfo = lines;
            gameBoard = board;
            SplitLines();
        }
        private void SplitLines()
        {
            foreach (string i in fileInfo)
            {
                string[] splitLine = i.Split(' ');
                instructionLine.Add(splitLine);
            }
            Seperate();
        }
        private void Seperate()
        {
            foreach (string[] lineSplit in instructionLine)
            {
                if (lineSplit[0].Length == pieceLocation)
                {
                    ConvertMovement(lineSplit);
                }
                else {
                    foreach (string s in lineSplit)
                    {
                        if (s.Length == piecePlacement)
                        {
                            output.Add(string.Format("Place the {0} {1} on {2}", ConvertCharacter(s[pieceColorIndex]), ConvertCharacter(s[pieceIndex]), s.Substring(pieceLocation)));
                            gameBoard[(s[pieceYPlacement] - 49), s[pieceXPlacement] - 97] = Piece.GeneratePiece(s);

                        }
                    }
                }
            }
            //Write();
        }

        private string ConvertCharacter(char c)
        {
            return chessPieces[c];
        }
        private void ConvertMovement(string[] s)
        {
            int firstPieceX = (s[0][0]) - 97;
            int firstPieceY = (s[0][1]) - 49;
            int secondPieceX = (s[1][0]) - 97;
            int secondPieceY = (s[1][1]) - 49;
            string result = "";
            if (s.Length == castling)
            {
                Console.WriteLine("Moves the king from " + s[0] + " to " + s[1] + " and moves the rook from " + s[2] + " to " + s[3]);
            }
            else {

                if (gameBoard[firstPieceY, firstPieceX] != null)
                {
                    if (CheckTurn.CheckValidTurn(gameBoard[firstPieceY, firstPieceX]))
                    {
                        if (gameBoard[firstPieceY, firstPieceX].CheckValidMove(s[1].Substring(0, 2)))
                        {
                            gameBoard[secondPieceY, secondPieceX] = gameBoard[firstPieceY, firstPieceX];
                            gameBoard[firstPieceY, firstPieceX] = null;
                            result += string.Format("Move the piece from {0} to {1}", s[0], s[1].Substring(0, 2));
                            if (s[1].Length == pieceCapture)
                            {
                                result += string.Format(" and captures the piece at {0}", s[1].Substring(0, 2));
                            }                                                      
                            Console.WriteLine(result);
                            if (MoveValidity.CheckForCheck(gameBoard[secondPieceY, secondPieceX]))
                            {
                                Console.WriteLine("{0} {1} has put {2} king into check.", gameBoard[secondPieceY, secondPieceX].Color, gameBoard[secondPieceY, secondPieceX].PieceType, gameBoard[secondPieceY, secondPieceX].GetOpposing());
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
        private void Write()
        {
            Console.WriteLine("Writing moves");
            foreach (string s in output)
            {
                Console.WriteLine(s);
            }
        }
    }
}




