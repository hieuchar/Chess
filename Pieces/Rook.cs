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

        public override bool CheckValidMove(Location Destination)
        {
            if( MoveValidity.CheckRookMove(Location, Destination))
            {                
                return true;
            }
            return false;
        }
        public override void MoveLocation(Location Destination)
        {
            Location = Destination;
        }
    }
}
