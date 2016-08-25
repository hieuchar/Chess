using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Gameplay
    {
        public static void GameControl()
        {
            while(!Controller.checkMate)
            {
                StartTurn();
                GetInput();
            }
        }
        public static void StartTurn()
        {
            Console.WriteLine("{0}'s turn", CheckTurn.turnColor);
        }
        public static void GetInput()
        {            
            
            bool validStart = false;
            Location start = new Location();
            Piece startPiece = null;
            while (!validStart){
                Console.WriteLine("Pick a piece to move");
                start = Location.convertFromString(Console.ReadLine());
                startPiece = GameBoard.board[start.Y, start.X];
                if (startPiece == null || startPiece.GetValidMoves().Count() == 0)
                {
                    Console.WriteLine("That piece has no valid moves");
                }
                else if(!CheckTurn.CheckValidTurn(startPiece))
                {
                    Console.WriteLine("Not that piece's turn to move");
                }
                else
                {
                    foreach (Location move in startPiece.GetValidMoves())
                    {
                        validStart = true;
                        Console.WriteLine(move);
                    }
                }
            }
           
            bool validEnd = false;
            while (!validEnd)
            {
                Console.WriteLine("Pick a destination from the above");
                Location end = Location.convertFromString(Console.ReadLine());
                if (startPiece.GetValidMoves().Contains(end))
                {
                    validEnd = true;
                    Controller.MovePieces(start, end);
                }
            }
        }
    }
}
