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
        private char[,] gameBoard;
        public Parser(string[] lines, char[,] board)
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
                    output.Add(ConvertMovement(lineSplit));
                }
                else {
                    foreach (string s in lineSplit)
                    {
                        if (s.Length == piecePlacement)
                        {
                            output.Add(string.Format("Place the {0} {1} on {2}", ConvertCharacter(s[pieceColorIndex]), ConvertCharacter(s[pieceIndex]), s.Substring(pieceLocation)));
                            int y = s[pieceYPlacement] - 48;
                            int x = s[pieceXPlacement] - 97;
                            Console.WriteLine(y + "," + x  + " " + s[pieceYPlacement] + "," +  s[pieceXPlacement] + s[pieceIndex]);                           
                            gameBoard[8 - (s[pieceYPlacement] - 48), s[pieceXPlacement] - 97] = s[pieceIndex];                 
                                                        
                        }
                    }
                }

            }
            Write();
        }

        private string ConvertCharacter(char c)
        {
            return chessPieces[c];
        }
        private string ConvertMovement(string[] s)
        {
            string result = "";
            if (s.Length == castling)
            {
                return "Moves the king from " + s[0] + " to " + s[1] + " and moves the rook from " + s[2] + " to " + s[3];
            }
            result += string.Format("Move the piece from {0} to {1}", s[0], s[1].Substring(0, 2));
            if (s[1].Length == pieceCapture)
            {
                result += string.Format(" and captures the piece at {0}", s[1].Substring(0, 2));
            }
            return result;
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




