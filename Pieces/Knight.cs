using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor pc, string loc) : base(ChessPiece.Knight, pc, loc)
        {

        }

        public override bool CheckValidMove(string Destination)
        {
            if (MoveValidity.CheckKnightMove(Location, Destination))
            {
                Location = Destination;
                return true;
            }
            else return false;
        }
    }
}
