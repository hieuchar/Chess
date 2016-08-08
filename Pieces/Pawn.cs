using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pc, string loc) : base(ChessPiece.Pawn, pc, loc)
        {
            
        }

        public override bool CheckValidMove( string Destination)
        {
            throw new NotImplementedException();
        }        
    }
}
