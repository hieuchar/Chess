using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    public class CheckTurn
    {
        private static PieceColor turnColor = PieceColor.White;
        public static bool CheckValidTurn(Piece p)
        {
            //bool valid = p.Color == turnColor;            
            //return valid;
            return true;
        }
        public static void ChangeTurn()
        {
            turnColor = turnColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }
    }
}
