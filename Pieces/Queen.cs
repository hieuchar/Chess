using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(PieceColor pc, string loc) : base(ChessPiece.Queen, pc, loc)
        {
        }

        public override bool CheckValidMove(Location Destination)
        {
            if (MoveValidity.CheckQueenMove(Location, Destination))
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
