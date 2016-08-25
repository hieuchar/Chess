using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public bool FirstMove { get; set; } = true;
        public Pawn(PieceColor pc, string loc) : base(ChessPiece.Pawn, pc, loc)
        {
            
        }

        public override bool CheckValidMove(Location Destination)
        {
            if (MoveValidity.CheckPawnMove(FirstMove, Location, Destination))
            {               
                return true;
            }
            return false;
        }
        public override void MoveLocation(Location Destination)
        {
            FirstMove = false;
            Location = Destination;
            if(Location.Y == 7 && Color == PieceColor.White || Location.Y == 0 && Color == PieceColor.Black)
            {
                GameBoard.PromotePawn(this);
            }
        }
    }
}
