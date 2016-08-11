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
            return MoveValidity.CheckKingMove(Location, Destination);
        }
    }
}
