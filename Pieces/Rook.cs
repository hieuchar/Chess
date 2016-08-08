using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(PieceColor pc, string loc) : base(ChessPiece.Rook, pc, loc)
        {
        }

        public override bool CheckValidMove(string Destination)
        {
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (startXLocation != destXLocation && startYLocation != destYLocation)
            {
                return false;
            }
            else if (GameBoard.CheckValidMove(Location, Destination))
            {                
                Location = Destination;
                return true;
            }
            return false;
        }
    }
}
