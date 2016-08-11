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

        public override bool CheckValidMove(string Destination)
        {
            return MoveValidity.CheckQueenMove(Location, Destination);
        }
    }
}
