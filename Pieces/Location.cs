using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public struct Location
    {        
        public int X { get; set; }
        
        public int Y { get; set; }
        public Location (int y, int x)
        {
            Y = y;
            X = x;
        }

        public string ToChessFormat()
        {
            return string.Format("{0}{1}", (char)(X + 'A'), (8 - Y));
        }
        public static Location convertFromString(string Location)
        {
            Location = Location.ToLower();
            Location temp = new Pieces.Location { X = (Location[0] - 97), Y = (Location[1] - 49) };
            return temp;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}", (char)(X + 'A'), (Y+1));
        }
    }
}
