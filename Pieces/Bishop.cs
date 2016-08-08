using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor pc, string loc) : base(ChessPiece.Bishop, pc, loc)
        {
        }

        public override bool CheckValidMove( string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if(!GameBoard.CheckSameColor(Location, Destination))
            {
                if(startXLocation == destXLocation || startYLocation == destYLocation)
                {
                    return false;
                }
                for(int i = 1; i <= Math.Abs(startXLocation - destXLocation); i++)
                {
                    if(startXLocation + i == destXLocation || startXLocation - i == destXLocation)
                    {
                        if (startYLocation + i == destYLocation || startYLocation - i == destYLocation)
                        {
                            if (!GameBoard.CheckDiagonalCollision(Location, Destination))
                            {
                                Location = Destination;
                                return true;
                            }
                        }
                    }
                }               
            }
            return false;

        }
    }
}
