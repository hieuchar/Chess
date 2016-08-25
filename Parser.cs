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
        protected static List<string[]> instructionLine = new List<string[]>();
        
        protected static List<string> output = new List<string>();


        //protected static Dictionary<char, string> chessPieces = new Dictionary<char, string>()
        //{
        //    {'Q', "Queen" },
        //    {'K', "King" },
        //    {'B', "Bishop"},
        //    {'N', "Knight"},
        //    {'R', "Rook" },
        //    {'P', "Pawn" },
        //    {'l', "White" },
        //    {'d', "Black" }
        //};
        protected int piecePlacement = 4;
        protected int pieceLocation = 2;

        //protected int pieceIndex = 0;
        //protected int pieceColorIndex = 1;
        //protected int pieceYPlacement = 3;
        //protected int pieceXPlacement = 2;

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
            Controller.PlacePieces();
            //Controller.MovePieces();
            Gameplay.GameControl();
        }
        private void Seperate()
        {
            foreach (string[] lineSplit in instructionLine)
            {
                if (lineSplit[0].Length == pieceLocation)
                {
                    Controller.movements.Add(lineSplit);                    
                }
                else
                {
                    foreach (string s in lineSplit)
                    {
                        if (s.Length == piecePlacement)
                        {
                            Controller.placements.Add(s);
                           // output.Add(string.Format("Place the {0} {1} on {2}", ConvertCharacter(s[pieceColorIndex]), ConvertCharacter(s[pieceIndex]), s.Substring(pieceLocation)));                          
                        }
                    }
                }
            }
            //Write();
        }
        //private string ConvertCharacter(char c)
        //{
        //    return chessPieces[c];
        //}
        //private void ConvertMovement(string[] s)
        //{
            
        //}
        //private void Write()
        //{
        //    Console.WriteLine("Writing moves");
        //    foreach (string s in output)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}
    }
}




