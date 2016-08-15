using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            //GenerateGrid();
            GameBoard.StartBoard();
            
            
        }
        #region Grid Generation
        //public void GenerateGrid()
        //{
        //    for(int i = 0; i < gridSize; i++)
        //    {
        //        for(int x = 0; x < gridSize; x++)
        //        {
        //            Button temp = new Button();
        //            temp.Background = i % 2 == 0 ? x % 2 == 0 ? Brushes.SandyBrown : Brushes.SaddleBrown : x % 2 == 1 ? Brushes.SandyBrown : Brushes.SaddleBrown;
        //            temp.BorderBrush = Brushes.Black;
        //            ChessGrid.Children.Add(temp);
        //        }
        //    }
        //}
        #endregion
        private string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
