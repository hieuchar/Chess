using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class GameBoard
    {
        private int boardLength = 8;
        private int boardHeight = 8;
        public GameBoard()
        {
            GenerateBoard();
        }
        private void GenerateBoard()
        {
            for (int height = 0; height < boardHeight; height++)
            {
                for(int length = 0; length < boardLength; length++)
                {
                    Console.Write('-');
                    if (length == 7)
                    {
                        Console.WriteLine();
                    }
                    
                }
            }
        }
        
    }
}
