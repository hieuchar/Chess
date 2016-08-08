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
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if(Math.Abs(startXLocation - destXLocation) == 2)
            {
                if (Math.Abs(startYLocation - destYLocation) == 1)
                {
                    return true;
                }
                else return false;
            }
            else if (Math.Abs(startYLocation - destYLocation) == 2)
            {
                if (Math.Abs(startXLocation - destXLocation) == 1)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}
