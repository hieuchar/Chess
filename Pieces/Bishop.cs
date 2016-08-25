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

        public override bool CheckValidMove(Location Destination)
        {
            if (MoveValidity.CheckBishopMove(Location, Destination))
            {                
                return true;
            }
            else return false;
        }
        public override void MoveLocation(Location Destination)
        {
            Location = Destination;
        }
    }
}
