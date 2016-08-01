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
        protected int pieceMove = 2;
        protected string[] fileInfo;
        public Parser(string[] lines)
        {
            fileInfo = lines;
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
                if (lineSplit[0].Length == 4)
                {
                    foreach (string s in lineSplit)
                    {
                        if (s.Length == 4)
                        {
                            output.Add(string.Format("Place the {0} {1} on {2}", ConvertCharacter(s[1]), ConvertCharacter(s[0]), s.Substring(2)));
                        }
                    }
                }
                else if (lineSplit[0].Length == 2)
                {
                    output.Add(ConvertMovement(lineSplit));
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
            if (s.Length >= 4)
            {
                return "Moves the king from " + s[0] + " to " + s[1] + " and moves the rook from " + s[2] + " to " + s[3];
            }
            result += string.Format("Move the piece from {0} to {1}", s[0], s[1].Substring(0,2));
            if (s[1].Length >= 3)
            {
                result += string.Format(" and captures the piece at {0}", s[1].Substring(0,2));
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




