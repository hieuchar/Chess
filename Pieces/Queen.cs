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
            int startXLocation = Location[0] - 97;
            int startYLocation = Location[1] - 49;
            int destXLocation = Destination[0] - 97;
            int destYLocation = Destination[1] - 49;
            if (!GameBoard.CheckSameColor(Location, Destination))
            {
                if (startXLocation != destXLocation && startYLocation != destYLocation)
                {

                    if (Math.Abs(startXLocation - destXLocation) != Math.Abs(startYLocation - destYLocation))
                    {
                        if (!GameBoard.CheckDiagonalCollision(Location, Destination))
                        {
                            Location = Destination;
                            return true;
                        }
                    }

                }
                else if (GameBoard.CheckValidMove(Location, Destination))
                {
                    Location = Destination;
                    return true;
                }
            }
            return false;
        }
    }
}
