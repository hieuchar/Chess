using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public ChessPiece PieceType { get; set; }
        public PieceColor Color { get; set; }
        public string Location { get; set; }
        private Dictionary<ChessPiece, char> pieces = new Dictionary<ChessPiece, char>()
        {
            {ChessPiece.Queen, 'Q' },
            {ChessPiece.King, 'K' },
            {ChessPiece.Knight, 'N'},
            {ChessPiece.Pawn, 'P' },
            {ChessPiece.Rook, 'R' },
            {ChessPiece.Bishop, 'B'}
        };
        public Piece(ChessPiece piece, PieceColor pc, string loc)
        {
            PieceType = piece;
            Color = pc;
            Location = loc;
        }
        public abstract bool CheckValidMove(string destination);
        public static Piece GeneratePiece(string gen)
        {

            switch(gen[0])
            {
                case 'Q':
                    return new Queen(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                case 'K':
                    return new King(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                case 'N':
                    return new Knight(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                case 'R':
                    return new Rook(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                case 'P':
                    return new Pawn(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                case 'B':
                    return new Bishop(gen[1] == 'l' ? PieceColor.White : PieceColor.Black, gen.Substring(2));
                default:
                    return null;
            }
        }
        public override string ToString()
        {
            if(Color == PieceColor.White)
            {
                return pieces[PieceType] + "";
            }
            else return (pieces[PieceType] + "").ToLower();

        }
    }
    
    public enum PieceColor
    {
        White,
        Black            
    }
    public enum ChessPiece
    {
        Rook,
        Bishop,
        Pawn,
        Knight,
        Queen,
        King
    }
    
}
