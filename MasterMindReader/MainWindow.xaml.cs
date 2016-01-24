using BoardGameEngine;
using System;
using System.Collections.Generic;
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

namespace MasterMindReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameBoard board;
        private PlayerBot bot;

        public MainWindow()
        {
            InitializeComponent();

            board = new GameBoard();
            bot = new PlayerBot(board);
            bot.ChooseBoardElement(new Random());

            GameBoardControl.Data = board;
        }

        private void Window_ElementClick(object sender, GameBoardControl.GameBoardControlElementClickEventArgs e)
        {
            if (bot.AskLocation(e.RowIndex, e.ColumnIndex))
            {
                board.MarkYes(e.RowIndex, e.ColumnIndex);
            }
            else
            {
                board.MarkNo(e.RowIndex, e.ColumnIndex);
            }
        }
    }
}
