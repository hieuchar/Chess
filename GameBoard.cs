using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chess
{
    public class GameBoard
    {
        private static int boardLength = 8;
        private static int boardHeight = 8;
        private char[,] board = new char[boardHeight, boardLength];
        public GameBoard()
        {            
            string[] inputFile = Environment.GetCommandLineArgs();
            if (File.Exists(inputFile[1]))
            {
                Parser p = new Parser(ReadFile(inputFile[1]), board);
            }
            else
            {
                MessageBox.Show(inputFile[1] + " does not exist");
                Application.Current.Shutdown();
            }                       
            GenerateBoard();
        }
        private void GenerateBoard()
        {
            for (int height = 0; height < boardHeight; height++)
            {
                for(int length = 0; length < boardLength; length++)
                {
                    if(length == 0)
                    {
                        Console.Write('|');
                    }
                    Console.Write(board[height,length]);                    
                    Console.Write('|');                    
                    if (length == 7)
                    {
                        Console.WriteLine();
                    }                    
                }                
            }
        }
        private string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

    }
}
