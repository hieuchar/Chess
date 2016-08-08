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
                if (Math.Abs(startXLocation - destXLocation) != Math.Abs(startYLocation - destYLocation))
                {
                    if (!GameBoard.CheckDiagonalCollision(Location, Destination))
                    {
                        Location = Destination;
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
