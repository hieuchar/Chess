using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(PieceColor pc, string loc) : base(ChessPiece.King, pc, loc)
        {

        }
        public override bool CheckValidMove(string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (Math.Abs(startXLocation - destXLocation) > 1 || Math.Abs(startYLocation - destYLocation) > 1)
            {
                return false;
            }
            if( GameBoard.CheckValidMove(Location, Destination))
            {
                Location = Destination;
                return true;
            }
            return false;
        }
    }
}
