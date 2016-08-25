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
        public Location Location { get; set; }
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
            Location = Location.convertFromString(loc);
        }        
        public abstract bool CheckValidMove(Location destination);
        public abstract void MoveLocation(Location Destination);
        public List<Location> GetValidMoves()
        {
            List<Location> validMoves = new List<Location>();
            for(int y = 0; y < 8; y++)
            {
                for(int x = 0; x < 8; x++)
                {
                    Location temp = new Location(y, x);
                    if(CheckValidMove(temp))
                    {
                        validMoves.Add(temp);
                    }
                }
            }
            return validMoves;
        }
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
        public static Piece GeneratePiece(ChessPiece c, PieceColor p, Location l)
        {
            switch (c)
            {
                case ChessPiece.Queen:
                    return new Queen(p, l.ToString().ToLower());
                case ChessPiece.King:
                    return new King(p, l.ToString().ToLower());
                case ChessPiece.Knight:
                    return new Knight(p, l.ToString().ToLower());
                case ChessPiece.Rook:
                    return new Rook(p, l.ToString().ToLower());
                case ChessPiece.Pawn:
                    return new Pawn(p, l.ToString().ToLower());
                case ChessPiece.Bishop:
                    return new Bishop(p, l.ToString().ToLower());
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
        public string GetOpposing()
        {
            if (Color.Equals(PieceColor.White))
            {
                return "Black";
            }
            else return "White";
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
